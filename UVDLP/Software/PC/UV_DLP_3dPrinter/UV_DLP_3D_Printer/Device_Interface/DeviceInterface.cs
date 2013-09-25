using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Timers;
using System.IO;
using UV_DLP_3D_Printer.Drivers;
using UV_DLP_3D_Printer.Configs;


namespace UV_DLP_3D_Printer
{
    /*
     This class is the main interface to communicate with the printer
     * it controls the serial connection to the machine and provides 
     * data back from the machine (such as temperature readout)
     * This printer interface will support a *very limited subset of g-code commands
     * that it will use to control the printer
     * I'm not sure if choosing GCodes/MCodes is the *right choice,
     * but hey, whatever works for now...
     * 
     * I'm including a few manual commands in here because i intend on implementing a printer control panel
     * that can manually jog and set temperatures
     * 
     * the DeviceInterface can only handle one command at a time (by design)
     * the previous command must either time out or respond
     * 
     * GCode listing 
     * 
     * G1 - Coordinated Motion
     * G28 - Home given Axes to maximum
     * G92 - Define current position on axes
     * 
     * 
     * MCode listing
     * M0 Unconditional Halt
     * M17 enable motor(s)
     * M18 disable motor(s)     
     * M109 Snnn set build platform temperature in degrees Celsuis
     * M128 get position
     * 
     * 
     * 
     * The printer has the following features:
     * Z axis stepper motor
     * HBP 
     * fluid pump
     * z Min / z Max limit switches
     * 
     * 
     */

    public enum ePIStatus 
    {
        eTimedout, // the last command timed out
        eReady, // ready for next command
        eError, // something went wrong
        eConnected, // device is now connected
        eDisconnected // device disconnected
    }

    public class DeviceInterface
    {
        //declare a delegate for the outside world to listen in
        public delegate void DeviceInterfaceStatus(ePIStatus status, String Command);
        public delegate void DeviceDataReceived(DeviceDriver device, byte[] data, int length); // raw data
        public delegate void DeviceLineReceived(DeviceDriver device, string line); // line of data terminated by a \r\n

        public DeviceInterfaceStatus StatusEvent;
        public DeviceDataReceived DataEvent;
        public DeviceLineReceived LineDataEvent;
        private DeviceDriver m_driver; //support for a single device driver 
        private bool m_ready; // ready to send a command
        private byte[] m_databufA;
        private byte[] m_databufB;
        private const int BUFF_SIZE = 4096;
        private const char TERMCHAR = '\n';
        public DeviceInterface() 
        {
            m_driver = null;
            m_ready = true;
            m_databufA = null;// new byte[BUFF_SIZE];
            m_databufB = null;// new byte[BUFF_SIZE];
        }

        // get and set the printdriver
        public DeviceDriver Driver
        {
            get { return m_driver; }
            set 
            {
                if (m_driver != null)
                {
                    DeviceDriver olddriver = m_driver;
                    if(olddriver.Connected == true)
                        olddriver.Disconnect(); // disconnect the old driver
                    //remove the old device driver delegates
                    olddriver.DataReceived -= new DeviceDriver.DataReceivedEvent(DriverDataReceivedEvent);
                    olddriver.DeviceStatus -= new DeviceDriver.DeviceStatusEvent(DriverDeviceStatusEvent);
                }
                //set the new driver
                m_driver = value; 
                //and bind the delegates to listen to events
                m_driver.DataReceived += new DeviceDriver.DataReceivedEvent(DriverDataReceivedEvent);
                m_driver.DeviceStatus += new DeviceDriver.DeviceStatusEvent(DriverDeviceStatusEvent);
            }
        }
        public void Configure(ConnectionConfig cc) 
        {
            Driver.Configure(cc);
        }
        public void DriverDeviceStatusEvent(DeviceDriver device, eDeviceStatus status) 
        {
            switch (status) 
            {
                case eDeviceStatus.eError:
                    if (StatusEvent != null)
                    {
                        StatusEvent(ePIStatus.eError, "I/O Error");
                    }                    
                    break;
                case eDeviceStatus.eConnect:                    
                    if (StatusEvent != null) 
                    {
                        StatusEvent(ePIStatus.eConnected, "Connected");
                    }
                    break;
                case eDeviceStatus.eDisconnect:
                    if (StatusEvent != null)
                    {
                        StatusEvent(ePIStatus.eDisconnected, "Disconnected");
                    }
                    break;

            }
        }

        // this is called when we receive data from the device driver
        // one or more full lines can be received here
        void DriverDataReceivedEvent(DeviceDriver device, byte[] data, int length) 
        {
            try
            {
                m_ready = true;
                // raise the data event
                if (DataEvent != null)
                {
                    DataEvent(device, data, length);
                }
                //raise a data event notifying that we're ready for the next command
                if (StatusEvent != null)
                {
                    StatusEvent(ePIStatus.eReady, "Ready");
                }

                // copy the data into the A buffer
                int termpos = -1;
                // copy the data into the 'A' buffer
                // need to copy into the end of the A buffer
                if (m_databufA == null)
                {
                    m_databufA = CopyData(0, data, 0, length);
                    
                }
                else
                {
                    m_databufA = AddBuffers(m_databufA, data);
                }
                termpos = Term_Pos(m_databufA, m_databufA.Length);
                while (termpos != -1)
                {
                    m_databufB = CopyData(0, m_databufA, 0, termpos + 1);
                    string result = System.Text.Encoding.ASCII.GetString(m_databufB); // should this be ascii?
                    m_ready = true;

                    if (LineDataEvent != null)
                    {
                        LineDataEvent(device, result); // raise an event for each complete line we receive
                    }
                    m_databufB =  CopyData(0, m_databufA, termpos + 1,(m_databufA.Length - (termpos + 1)));
                    m_databufA =  CopyData(0, m_databufB, 0, m_databufB.Length);
                    termpos = Term_Pos(m_databufA, m_databufA.Length); // check again
                }
            }
            catch (Exception ex) 
            {
               // DebugLogger.Instance().LogError(ex.Message);  // this is erroring on the null driver for some reason
            }
        }

        public static int Term_Pos(byte[] buffer, int len)
        {
            for (int c = 0; c < len; c++)
            {
                if (buffer[c] == TERMCHAR)
                {
                    return c;
                }
            }
            return -1;
        }  

        public static byte[] AddBuffers(byte[] Abuf, byte[] Bbuf)
        {
            byte []retbuf = new byte[Abuf.Length + Bbuf.Length ];
            int c=0;
            for(c=0;c<Abuf.Length;c++)
            {
                retbuf[c]=Abuf[c];     		
            }
            for(int i=0;i<Bbuf.Length;i++)
            {
                retbuf[c++] = Bbuf[i];     		
            }
            return retbuf;     	
        }
        public static byte[] CopyData(int dst_start, byte[] srcbuffer, int src_start, int datalen)
        {
            try
            {

                byte[] dstbuffer = new byte[datalen];
                for (int c = 0; c < datalen; c++) 
                {
                    dstbuffer[dst_start + c] = srcbuffer[src_start + c];
                }
                return dstbuffer;

            }
            catch (Exception e)
            {
                //DebugLogger.Instance().LogError(e.Message); // error with null driver causing issues, look into it
                return null;
                //DebugLogger.Instance().LogRecord("DM_Utils:CopyData: Error copying byte data " + e.Message);
            }
        }
        /*
        //Sends the GCode command for recieving current position
        public void SendGetPosition() 
        {
            String command = "M114\r\n";
            SendCommandToDevice(command);
        }
        */
        public bool Connected { get { return m_driver.Connected; } }

        /*
         This function moves the Z axis to the specified position in mm 
         * at the specified feed rate
         */
        /*
        public void MoveTo(double zpos,double rate) 
        {
            String command = "G1 Z"  + zpos + " F" + rate + "\r\n";
            SendCommandToDevice(command);
        }
        */
        /*
         This function moves the Z axis to by the distance in mm 
         * at the specified feed rate
         */
        public void Move(double zpos, double rate)
        {
            String command = "G1 Z" + zpos + " F" + rate + "\r\n";
            SendCommandToDevice("G91\r\n"); 
            SendCommandToDevice(command);
            SendCommandToDevice("G90\r\n");            
        }
        /*
         This function moves the X (Tilt/Slide) axis to by the distance in mm 
         * at the specified feed rate
         */
        public void MoveX(double xpos, double rate)
        {
            String command = "G1 X" + xpos + " F" + rate + "\r\n";
            SendCommandToDevice("G91\r\n");
            SendCommandToDevice(command);
            SendCommandToDevice("G90\r\n");
        }
        /*
         This function moves the Y (Tilt/Slide) axis to by the distance in mm 
         * at the specified feed rate
         */
        public void MoveY(double ypos, double rate)
        {
            String command = "G1 Y" + ypos + " F" + rate + "\r\n";
            SendCommandToDevice("G91\r\n");
            SendCommandToDevice(command);
            SendCommandToDevice("G90\r\n");
        }
        public bool Disconnect() 
        {
            m_ready = false;
            return m_driver.Disconnect();
        }
        public bool Connect()
        {
            try
            {
                m_ready = true;
                return m_driver.Connect();
            }
            catch (Exception ) 
            {
                return false;
            }
        }
        /// <summary>
        /// This will be true if the device is ready for another command
        /// </summary>
        /// <returns></returns>
        public bool ReadyForCommand() 
        {
            return m_ready;
        }

        public bool SendCommandToDevice(String command) 
        {
            try
            {
                if (m_driver.Write(command) > 0) 
                {
                    m_ready = false;
                    return true;
                }                                
                return false;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
