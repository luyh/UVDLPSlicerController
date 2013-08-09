using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Drivers
{
    public class GenericDriver : DeviceDriver
    {
        public GenericDriver() 
        {
            m_drivertype = eDriverType.eGENERIC;
        }
        public override bool Connect() 
        {
            try
            {
                m_serialport.Open();
                if (m_serialport.IsOpen)
                {
                    m_connected = true;
                    RaiseDeviceStatus(this, eDeviceStatus.eConnect);
                    return true;
                }
            }catch(Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
            return false;
        }
        public override bool Disconnect() 
        {
            try
            {
                m_serialport.Close();
                m_connected = false;
                RaiseDeviceStatus(this, eDeviceStatus.eDisconnect);
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
            
        }
        
        public override int Write(byte[] data, int len) 
        {
            m_serialport.Write(data, 0, len);
            return len;
        }
        public override int Write(String line) 
        {
            int len = -1;
            len = line.Length;
            string newln = "";
            //check to see if the line is blank, or starts with a comment
            // if it does, don't send the comment to the firmware
            if (line.StartsWith("(")) 
            {
                return len;
            }
            else if (line.Contains('('))
            {
                // this line does not start with a comment, but contains a comment,
                // split the line and give only the first portion
                String[] Lines = line.Split('(');
                if (Lines.Length > 0)
                {
                    newln = Lines[0];
                    newln += "\r\n"; // make sure to capp it off
                    m_serialport.Write(newln); // write the portion without the comment                    
                }
            }
            else // write the line as normal
            {
                m_serialport.Write(line);                
                return line.Length;
            }
            return len;
        }
    }
}
