using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Timers;
using System.Threading;
namespace UV_DLP_3D_Printer.Drivers
{
    /// <summary>
    /// </summary>
    public class UnciaDriver : GenericDriver
    {
        char lastCharSent;
        bool stockUnciaFirmware;
        //Timer m_reqtimer;
        //private static double s_interval = 250; // 1/4 second
        public UnciaDriver()
        {
            
            m_drivertype = eDriverType.eUNCIA; // set correct driver type
            stockUnciaFirmware = true;
         //   m_reqtimer = new Timer();
         //   m_reqtimer.Interval = s_interval;
         //   m_reqtimer.Elapsed += new ElapsedEventHandler(m_reqtimer_Elapsed);
            UVDLPApp.Instance().m_deviceinterface.AlwaysReady = true; // don't look for gcode responses, always assume we're ready for the next command.
        }

        /// <summary>
        /// override the base class implementation of the connect
        /// so we can start the timer
        /// </summary>
        /// <returns></returns>
        public override bool Connect()
        {
            bool ret = false;
            try
            {
                ret = base.Connect();

                if (ret)
                { //this means that we've connected, and it's time to try to talk to our printer.
                    bool pingStatus = pingUncia();
                    if (pingStatus)
                    { //this means that we've successfully sent the char 'P' to the Uncia

                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return ret;
            }
        }
        /// <summary>
        /// Override the base class implementation of the disconnect
        /// in order to stop the request status timer
        /// </summary>
        /// <returns></returns>
        public override bool Disconnect()
        {
            try
            {
                bool ret = base.Disconnect();
                
                return ret;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// This class updates what the last char sent to the Uncia was. It assumes that 
        /// you are only sending one char at a time! (i.e. cmd[].Length == 1)
        /// </summary>
        private void setLastCharSent(byte[] cmd)
        {   //This method assumes that we are sending only 1 char at a time!
            lastCharSent = (char)cmd[0];
        }

        /// <summary>
        /// This is a class that will ping the Uncia printer by sending it
        /// a specific pinging char.
        /// </summary>
        private bool pingUncia()
        {
            try
            {
                byte[] cmd;
                cmd = new byte[1];
                char pingChar = 'P';
                cmd[0] = (byte)pingChar;  //Set our pinging char

                Write(cmd, 1);            //Sending it
                setLastCharSent(cmd);

                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
            return false;
        }

        /// <summary>
        /// This function starts looking at the 2 character in the line (index 1)
        /// and will read characters until the whitespace
        /// and return the g/m code
        /// </summary>
        /// <param name="?"></param>
        /// <returns>int</returns>
        private int GetGMCode(string line)
        {
            try
            {
                int idx = 1;
                string val = "";
                string ss = line.Substring(idx, 1);
                while (ss != " " && ss != "\r" && idx < line.Length)
                {
                    ss = line.Substring(idx++, 1);
                    val += ss;
                }
                int retval = int.Parse(val);
                return retval;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
            return -1;
        }


        /// <summary>
        /// This class looks at a line of code, and strips out the commands. It then
        /// returns the numeric value of the code.
        /// </summary>
        private double GetGCodeValDouble(string line, char var)
        {
            try
            {
                // scan the string, looking for the specified var
                // starting at the next position, start reading characters
                // until a space occurs or we reach the end of the line
                double val = 0;
                int idx = line.IndexOf(var);
                if (idx != -1)
                {
                    // found the character
                    //look for the next space or end of line
                    string sval = "";
                    string ss = line.Substring(idx++, 1);
                    while (ss != " " && ss != "\r" && idx < line.Length)
                    {
                        ss = line.Substring(idx++, 1);
                        sval += ss;
                    }
                    val = double.Parse(sval.Trim());
                }
                return val;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
                return 0.0;
            }
        }



        /// <summary>
        /// This interprets the gcode/mcode
        /// generates a command, and sends the data to the port
        /// it returns number of bytes written
        /// </summary>
        /// <param name="line"></param>
        private int InterpretGCode(string line)
        {
            try
            {
                int retval = 0;
                string ln = line.Trim(); // trim the line to remove any leading / trailing whitespace
                ln = ln.ToUpper(); // convert to all upper case for easier processing
                int code = -1;
                byte[] cmd;
                cmd = new byte[1];
                //int delay = 1;//0; //slow delay. I think fast delay is 0

                if (ln.StartsWith("G"))
                {
                    code = GetGMCode(line);
                    switch (code)
                    {
                        case -1:// error getting g/mcode
                            DebugLogger.Instance().LogError("Error getting G/M code: " + line);
                            break;
                        case 1: // G1 movement command - 
                            // C
                            double zval = GetGCodeValDouble(line, 'Z');
                            cmd[0] = (byte)'E'; // enable the stepper motor
                            Write(cmd, 1);
                            setLastCharSent(cmd);
                            //Thread.Sleep(delay); // add a delay between steps

                            //convert that to steps - 90 steps per mm
                            double zsteps = zval * 87; // 3000 steps /mm ? // 9 steps = 100 microns = .1mm
                            int iZStep = (int)Math.Abs(zsteps); // get the ABS value
                            if (zval > 0)
                            {
                                cmd[0] = (byte)'F';// forward direction                            
                            }
                            else 
                            {
                                cmd[0] = (byte)'R';
                            }
                            Write(cmd, 1); // write the direction byte
                            setLastCharSent(cmd);
                            //

                            cmd[0] = (byte)'S';

                            for (int c = 0; c < (int)iZStep; c++) 
                            {
                                Write(cmd, 1);
                                setLastCharSent(cmd);
                              //  Thread.Sleep(delay); // add a delay between steps
                            }
                                
                            break;
                        case 28: // G28 Homing command
                          //  retval = Write(cmd, 8); // send the command
                            break;
                    }
                }
                else if (ln.StartsWith("M"))
                {
                    code = GetGMCode(line);
                    switch (code)
                    {
                        case -1:// error getting g/mcode
                            DebugLogger.Instance().LogError("Error getting G/M code: " + line);
                            break;
                        
                        case 17: // M17 Turn Motors On command
                            cmd[0] = (byte)'E'; // enable the stepper motor
                            Write(cmd, 1);
                            setLastCharSent(cmd);
                            break;

                        case 18: // M18 Turn Motors Off command
                            cmd[0] = (byte)'D'; // Disable the stepper motor
                            Write(cmd, 1);
                            setLastCharSent(cmd);
                            break;


                        //This case doesn't exist in GCode, but sending 'P' will 
                            //ping the machine. The default firmware responds with
                            //a DEC value of 68, which translates to the char 'D'.
                            //We are able to use this to determine if an Uncia
                            //has a modified firmware.
                    }
                }
                return retval;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
                return 0; // error writing / decoding
            }
        }
        /// <summary>
        /// We're overriding the read here
        /// We're going to need to listen to the system status messages sent back from the printer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void m_serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int read = m_serialport.Read(m_buffer, 0, m_serialport.BytesToRead);
            byte[] data = new byte[read];
            for (int c = 0; c < read; c++)
            {
                data[c] = m_buffer[c];


        //        char c1 = (char)data[c];
        //        System.Diagnostics.Debug.Write(c1.ToString()); Used these commented lines to
        //          listen in on the Uncia <--> CWS serial comms.
            }
        //    System.Diagnostics.Debug.WriteLine("");

            if (data.Length < 1)
            {   //We received more than just one char, so it's an 'ok/r/n'
                Log(data, read);
                RaiseDataReceivedEvent(this, data, read);
            }
            else
            {
                char c1 = (char)data[0];
                switch (c1)
                {
                    case 'C':// Aperture Closed
                        UnciaDataReceived(data, read);
                        break;
                    case 'd':// Motors Disabled
                        UnciaDataReceived(data, read);
                        break;
                    case 'e':// Motors Enabled
                        UnciaDataReceived(data, read);
                        break;
                    case 'f':// Forward direction set
                        UnciaDataReceived(data, read);
                        break;
                    case 'O':// Aperture Opened
                        UnciaDataReceived(data, read);
                        break;
                    case 'r':// Reverse direction set
                        UnciaDataReceived(data, read);
                        break;
                    case 's':// Motor stepped
                        UnciaDataReceived(data, read);
                        break;
                    case 'D':// The firmware being used is stock
                        if (lastCharSent == 'P')
                        { //Did we ping the printer?
                            stockUnciaFirmware = true; //The firmware returned the last char of 'Sedgewick3D'
                            //   so we know it's running stock.
                        }
                        UnciaDataReceived(data, read);
                        break;
                    case 'N':// The firmware being used is modified!
                        if (lastCharSent == 'P')
                        { //Did we ping the printer?
                            stockUnciaFirmware = false; //We know that it's using Pomeroy's modified firmware
                        }

                        UnciaDataReceived(data, read);
                        break;
                }
            }    
            // we're also going to have to raise an event to the deviceinterface indicating that we're 
            // ready for the next command, because this is different than the standard
            // gcode implementation where the device interface looks for a 'ok',
            //we'll probably have to also raise a signal to the deviceinterface NOT to look for the ok
            // so it doen't keep adding up buffers. -- This is done by the AlwaysReady = true;
        }


        /// <summary>
        /// This method sets CWS to "AlwaysReady" mode (So we can ignore 'ok' responses).
        /// It then sends the data, and returns CWS to standard mode.
        /// </summary>
        private void UnciaDataReceived(byte[] data, int len)
        { 
            UVDLPApp.Instance().m_deviceinterface.AlwaysReady = true;
            Log(data, len);
            RaiseDataReceivedEvent(this, data, len);
            UVDLPApp.Instance().m_deviceinterface.AlwaysReady = false;

        }

        public override int Write(String line)
        {
            try
            {
                int sent = 0;
                string tosend = RemoveComment(line);
                lock (_locker) // ensure synchronization
                {
                    line = RemoveComment(line);
                    if (line.Trim().Length > 0)
                    {
                        Log(line);
                        if (stockUnciaFirmware)
                        {  //if the Uncia is using the stock firmware, we need to send chars.
                            sent = InterpretGCode(line);
                        }
                        else if (!DoPassthrough(line))
                        {
                        //If we aren't using stock Uncia firmware, we're going to assume that that
                        //  firmware will then use normal GCode commands. We can just send the 
                        //  commands as normal.
                        m_serialport.Write(line);
                        }
                    }
                    return sent;
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
                return 0;
            }
        }
    }
}
