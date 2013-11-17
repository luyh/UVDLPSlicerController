using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Timers;
using UV_DLP_3D_Printer.Configs;
using System.Threading;
namespace UV_DLP_3D_Printer.Drivers
{
    /*
     This is a base class for a generic device driver class used to communicate with the printer
     * or whatever device we're talking with.
     */
    public enum eDriverType
    {
        eNULL_DRIVER, // the driver for testing when a mavchine is not connected, it always returns OK
        eGENERIC, // whatever class of driver you call this, I've been using sailfish, and it seems to work great
        eRF_3DLPRINTER, // the Italian Robot Factory 3DLPrinter
    }
    public enum eDeviceStatus 
    {
        eConnect, // when the device connects, this event is raised
        eDisconnect, // when the device disconnect function is called, this is raised
        eError, //when an error occurs reading or writing, this occurs
        // timeout happens at the device interface level
    }
    
    public abstract class DeviceDriver
    {
        public delegate void DeviceStatusEvent(DeviceDriver device, eDeviceStatus status);
        public delegate void DataReceivedEvent(DeviceDriver device, byte[] data, int length);
        protected bool m_connected = false;
        protected SerialPort m_serialport;
        protected eDriverType m_drivertype;
        public DataReceivedEvent DataReceived; // a delegate to notify when data is received
        public DeviceStatusEvent DeviceStatus;
        protected ConnectionConfig m_config; // the serial port configuration
        protected byte[] m_buffer;

        private Thread m_readthread = null;
        private bool m_readthreadrunning = false;

        protected DeviceDriver() 
        {
            m_serialport = new SerialPort();
            m_buffer = new byte[8192];

            m_serialport.DataReceived += new SerialDataReceivedEventHandler(m_serialport_DataReceived);
            // Mono doesn't support the DataRecieved event, so we need to poll for the data
            if (UVDLPApp.RunningPlatform() != UVDLPApp.Platform.Windows) 
            {
                // if we're not windows, we need to poll for data
                m_readthread = new Thread(new ThreadStart(Mono_Serial_ReadThread));
                m_readthreadrunning = true;
                m_readthread.Start();
            }
        }
        private void Mono_Serial_ReadThread() 
        {
            try
            {
                if (m_readthreadrunning) 
                {
                    // try to read from serial port,
                    // if we have one or more bytes available, pass it off to the m_serialport_DataReceived function
                    if (m_serialport.BytesToRead > 0) 
                    {
                        m_serialport_DataReceived(null, null);
                    }
                }
                Thread.Sleep(0); // yield the remainder of the timeslice
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        void m_serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int read = m_serialport.Read(m_buffer, 0, m_serialport.BytesToRead);
            byte []data = new byte[read];
            for (int c = 0; c < read; c++) 
            {
                data[c] = m_buffer[c];
            }
            RaiseDataReceivedEvent(this, data, read);
        }

        public bool Connected { get { return m_connected; } }
        protected void RaiseDeviceStatus(DeviceDriver device,eDeviceStatus status) 
        {
            if (DeviceStatus != null) 
            {
                DeviceStatus(device,status);
            }
        }
        protected void RaiseDataReceivedEvent(DeviceDriver device, byte[] data, int length) 
        {
            if (DataReceived != null) 
            {
                DataReceived(device, data, length);
            }
        }
        public eDriverType DriverType
        {
            get { return m_drivertype; }
        }
        public abstract bool Connect();
        public abstract bool Disconnect();
        public abstract int Write(byte[] data, int len);
        public abstract int Write(String line);
        public void Configure(ConnectionConfig cc) 
        {
            m_config = cc;
            m_serialport.BaudRate = cc.speed;
            m_serialport.DataBits = cc.databits;
            m_serialport.Parity = cc.parity;
            m_serialport.Handshake = cc.handshake;
            m_serialport.PortName = cc.comname;
        }
    }
}
