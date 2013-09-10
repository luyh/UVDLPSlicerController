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
        eDisconnected, // device disconnected
        eTemperatureData // Temperature data was received
    }

    public class DeviceInterface
    {
        //declare a delegate for the outside world to listen in
        public delegate void DeviceInterfaceStatus(ePIStatus status, String Command);
        public delegate void DeviceDataReceived(DeviceDriver device, byte[] data, int length); // raw data
        public delegate void DeviceLineReceived(DeviceDriver device, string line); // line of data terminated by a \r\n

        private double m_HBPtemp = -1; // heated platform be temperature
        private double m_Ext0Temp = -1; // extruder 0 temperature
        public DeviceInterfaceStatus StatusEvent;
        public DeviceDataReceived DataEvent;
        public DeviceLineReceived LineDataEvent;
        private DeviceDriver m_driver; //support for a single device driver 
        protected Timer m_timeouttimer;
        protected Timer m_tempchecktimer;
        private const int DEF_TEMPCHECK = 3000;// 3 seconds
        private const int DEF_TIMEOUT = 500;// 500 millisecond default timeout
        protected int m_timeoutms; 

        public DeviceInterface() 
        {
            m_timeoutms = DEF_TIMEOUT;
            m_timeouttimer = new Timer();
            m_timeouttimer.Elapsed += new ElapsedEventHandler(m_timeouttimer_Elapsed);
            m_timeouttimer.Interval = m_timeoutms;
            m_tempchecktimer = new Timer();
            m_tempchecktimer.Elapsed += new ElapsedEventHandler(m_tempchecktimer_Elapsed);
            m_tempchecktimer.Interval = DEF_TEMPCHECK;
            m_driver = null;
            
        }
        /// <summary>
        /// Return the temperature of the HBP
        /// </summary>
        public double HBP_Temp 
        {
            get { return m_HBPtemp; }
        }
        /// <summary>
        /// return the temperature of Extruder 0
        /// </summary>
        public double Ext0_Temp 
        {
            get { return m_Ext0Temp; }
        }

        public bool MonitorTemps 
        {
            get 
            {
                return false;
                
            }
            set 
            {
                if (value == true)
                {
                    m_tempchecktimer.Start();
                }
                else 
                {
                    m_tempchecktimer.Stop();
                }
            }
        }
        void m_tempchecktimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            //send a gcode to query temps
            SendCommandToDevice("M105\r\n");
        }

        void m_timeouttimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // the command that was sent last has now timed out
            if (StatusEvent != null)
            {
                StatusEvent(ePIStatus.eTimedout, "Command Timed Out");
                DebugLogger.Instance().LogRecord("Command Timed out");
                m_timeouttimer.Enabled = false;
            }
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
                // stop the watchdog timer
                m_timeouttimer.Enabled = false; // disable the timer
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

                string result = System.Text.Encoding.UTF8.GetString(data);
                // split it into multiple lines
                string[] lines = result.Split('\n');
                foreach (string line in lines)
                {
                    if (LineDataEvent != null) 
                    {
                        LineDataEvent(device, line);
                    }
                    //now parse the response to look for temperature reporting events

                    //convert to string
                    string ln = line.Trim();
                    
                    //ok T:201 B:117 
                    String[] parts = line.Split(' '); // split on spaces
                    bool temp = false;
                    if (parts.Length > 1)  // if this is more than just an 'ok'
                    {
                        try
                        {
                            foreach (string part in parts)
                            {
                                if (part.StartsWith("T"))
                                {
                                    string[] tmp = part.Split(':');
                                    m_Ext0Temp = double.Parse(tmp[1]);
                                    temp = true;
                                }
                                if (part.StartsWith("B"))
                                {
                                    string[] tmp = part.Split(':');
                                    m_HBPtemp = double.Parse(tmp[1]);
                                    temp = true;
                                }

                            }
                        }
                        catch (Exception ex) { }

                    }
                    if (temp)
                    {
                        if (StatusEvent != null)
                        {
                            StatusEvent(ePIStatus.eTemperatureData, "Temperatures read");
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
            
            }
        }

        public int TimeoutMS
        {
            get { return m_timeoutms; }
            set { m_timeoutms = value; }
        }

        //Sends the GCode command for recieving current position
        public void SendGetPosition() 
        {
            String command = "M114\r\n";
            SendCommandToDevice(command);
        }
       // public int GetHBPTemp { get { return m_HBPtemp; } }

        public bool Connected { get { return m_driver.Connected; } }

        /*
         This function moves the Z axis to the specified position in mm 
         * at the specified feed rate
         */
        public void MoveTo(double zpos,double rate) 
        {
            String command = "G1 Z"  + zpos + " F" + rate + "\r\n";
            SendCommandToDevice(command);
        }

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


        /*
         This function stops all movement and motion
         */
        public void StopAll() 
        {
            SendCommandToDevice("M0\r\n");
        }
        /*
         This function will enable or disable the motors in the printer
         * based on the sent value
         */
        public void EnableMotors(bool val) 
        {
            if (val)
            {
                SendCommandToDevice("M17\r\n");
            }
            else 
            {
                SendCommandToDevice("M18\r\n");
            }            
        }
        /*
         This function sets the HBP Temperature
         */
        public void SetHBPTemp(int celsius) 
        {
            String sendstr = "M109 S";
            sendstr += celsius + "\r\n";
            SendCommandToDevice(sendstr);
            //M109 Snnn
        }
        public bool Disconnect() 
        {
            return m_driver.Disconnect();
        }
        public bool Connect()
        {
            try
            {
                return m_driver.Connect();
            }
            catch (Exception ) 
            {
                return false;
            }
        }


        public bool SendCommandToDevice(String command) 
        {
            try
            {
                if (m_driver.Write(command) > -1) 
                {
                    //start a timer                    
                    m_timeouttimer.Enabled = true;
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
