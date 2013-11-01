using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UV_DLP_3D_Printer.Configs;
using System.IO;

namespace UV_DLP_3D_Printer
{
    /*
     This class holds some basic information about the printer's machine configuration
     * such as:
     * DLP resolution
     * Build Platform Width/Height/Length(Z)
     * calculated x/y dpi (or dpmm)
     * 
     */
    public class MachineConfig
    {
        public enum eMachineType          // indicates the major machine type
        {
            FDM,
            UV_DLP
        }
        public const int FILE_VERSION = 1; // this should change every time the format changes
        public double m_XDLPRes; // the X resolution of the DLP projector in pixels
        public double m_YDLPRes; // the Y resolution of the DLP projector in pixels
        public double m_PlatXSize; // the X size of the build platform in mm
        public double m_PlatYSize; // the Y size of the build platform in mm
        public double m_PlatZSize; // the Z size of the Z axis length in mm
        private double m_Xpixpermm; // the calculated pixels per mm
        private double m_Ypixpermm; // the calculated pixels per mm
        private double m_XMaxFeedrate;// in mm/min 
        private double m_YMaxFeedrate;// in mm/min 
        private double m_ZMaxFeedrate;// in mm/min 
        private string m_monitorid; // which monitor we're using
        public eMachineType m_machinetype;

        public String m_description; // a description
        public String m_name; // the profile name
        public String m_filename;// the filename of this profile. (not saved)
        public DeviceDriverConfig m_driverconfig;



        public bool Load(string filename)
        {
            m_filename = filename;
            m_name = Path.GetFileNameWithoutExtension(filename);
            bool retval = false;
            XmlHelper xh = new XmlHelper();
            bool fileExist = xh.Start(m_filename, "MachineConfig");
            XmlNode mc = xh.m_toplevel;

            m_XDLPRes = xh.GetDouble(mc, "DLP_X_Res", 1024.0);
            m_YDLPRes = xh.GetDouble(mc, "DLP_Y_Res", 768.0);
            m_PlatXSize = xh.GetDouble(mc, "PlatformXSize", 102.0);
            m_PlatYSize = xh.GetDouble(mc, "PlatformYSize", 77.0);
            m_PlatZSize = xh.GetDouble(mc, "PlatformZSize", 100.0);
            m_Xpixpermm = xh.GetDouble(mc, "PixPermmX", m_XDLPRes / m_PlatXSize);
            m_Ypixpermm = xh.GetDouble(mc, "PixPermmY", m_YDLPRes / m_PlatYSize);
            m_XMaxFeedrate = xh.GetDouble(mc, "MaxXFeedRate", 100.0);
            m_YMaxFeedrate = xh.GetDouble(mc, "MaxYFeedRate", 100.0);
            m_ZMaxFeedrate = xh.GetDouble(mc, "MaxZFeedRate", 100.0);
            m_monitorid = xh.GetString(mc, "MonitorID", "");
            m_machinetype = (eMachineType)xh.GetEnum(mc, "MachineType", typeof(eMachineType), eMachineType.UV_DLP);
            CalcPixPerMM();

            if (m_driverconfig.Load(xh, mc))
            {
                retval = true;
            }
            if (!fileExist)
            {
                xh.Save(FILE_VERSION);
            }
            return retval;
        }


        public bool Save(string filename)
        {
            bool retval = false;
            m_filename = filename;
            m_name = Path.GetFileNameWithoutExtension(filename);
            XmlHelper xh = new XmlHelper();
            bool fileExist = xh.Start(m_filename, "MachineConfig");
            XmlNode mc = xh.m_toplevel;
            xh.SetParameter(mc, "DLP_X_Res", m_XDLPRes);
            xh.SetParameter(mc, "DLP_Y_Res", m_YDLPRes);
            xh.SetParameter(mc, "PlatformXSize", m_PlatXSize);
            xh.SetParameter(mc, "PlatformYSize", m_PlatYSize);
            xh.SetParameter(mc, "PlatformZSize", m_PlatZSize);
            xh.SetParameter(mc, "PixPermmX", m_Xpixpermm);
            xh.SetParameter(mc, "PixPermmY", m_Ypixpermm);
            xh.SetParameter(mc, "MaxXFeedRate", m_XMaxFeedrate);
            xh.SetParameter(mc, "MaxYFeedRate", m_YMaxFeedrate);
            xh.SetParameter(mc, "MaxZFeedRate", m_ZMaxFeedrate);
            xh.SetParameter(mc, "MonitorID", m_monitorid);
            xh.SetParameter(mc, "MachineType", m_machinetype);
            if (m_driverconfig.Save(xh, mc))
            {
                retval = true;
            }
            xh.Save(FILE_VERSION);
            return retval;
        }
        public MachineConfig()
        {
            m_XDLPRes = 1024;
            m_YDLPRes = 768;
            m_PlatXSize = 102.0;
            m_PlatYSize = 77.0;
            m_PlatZSize = 100; // 100 mm default, we have to load this
            m_XMaxFeedrate = 100;
            m_YMaxFeedrate = 100;
            m_ZMaxFeedrate = 100;
            m_monitorid = "";
            CalcPixPerMM();
            m_driverconfig = new DeviceDriverConfig();
            m_machinetype = eMachineType.UV_DLP;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(";(****Machine Configuration ******)\r\n");
            sb.Append(";(Projector X Res         = " + m_XDLPRes + ")\r\n");
            sb.Append(";(Projector Y Res         = " + m_YDLPRes + ")\r\n");
            sb.Append(";(Platform X Size         = " + m_PlatXSize + "mm )\r\n");
            sb.Append(";(Platform Y Size         = " + m_PlatYSize + "mm )\r\n");
            sb.Append(";(Platform Z Size         = " + m_PlatZSize + "mm )\r\n");

            sb.Append(";(Max X Feedrate          = " + m_XMaxFeedrate + "mm/s )\r\n");
            sb.Append(";(Max Y Feedrate          = " + m_YMaxFeedrate + "mm/s )\r\n");
            sb.Append(";(Max Z Feedrate          = " + m_ZMaxFeedrate + "mm/s )\r\n");
            sb.Append(";(Monitor ID              = " + m_monitorid + ")\r\n");
            sb.Append(";(Machine Type            = " + m_machinetype.ToString() + ")\r\n");
            return sb.ToString();
        }

        public void CalcPixPerMM()
        {
            m_Xpixpermm = m_XDLPRes / m_PlatXSize;
            m_Ypixpermm = m_YDLPRes / m_PlatYSize;

        }
        public void SetDLPRes(double xres, double yres)
        {
            m_XDLPRes = xres;
            m_YDLPRes = yres;
            CalcPixPerMM();
        }

        public void SetPlatSize(double xsz, double ysz)
        {
            m_PlatXSize = xsz;
            m_PlatYSize = ysz;
            CalcPixPerMM();
        }

        public double PixPerMMX { get { return m_Xpixpermm; } }
        public double PixPerMMY { get { return m_Ypixpermm; } }
        public int XRes { get { return (int)m_XDLPRes; } }
        public int YRes { get { return (int)m_YDLPRes; } }
        public double XMaxFeedrate
        {
            get { return m_XMaxFeedrate; }
            set { m_XMaxFeedrate = value; }
        }
        public double YMaxFeedrate
        {
            get { return m_YMaxFeedrate; }
            set { m_YMaxFeedrate = value; }
        }
        public double ZMaxFeedrate
        {
            get { return m_ZMaxFeedrate; }
            set { m_ZMaxFeedrate = value; }
        }

        public string Monitorid
        {
            get { return m_monitorid; }
            set { m_monitorid = value; }
        }

    }
}
