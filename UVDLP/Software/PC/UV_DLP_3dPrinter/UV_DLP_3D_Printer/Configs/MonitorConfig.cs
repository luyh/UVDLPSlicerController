using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace UV_DLP_3D_Printer.Configs
{
    public class MonitorConfig
    {
        public double m_XDLPRes; // the X resolution of the DLP projector in pixels
        public double m_YDLPRes; // the Y resolution of the DLP projector in pixels
        private double m_Xpixpermm; // the calculated pixels per mm
        private double m_Ypixpermm; // the calculated pixels per mm
        public Boolean m_displayconnectionenabled;   // projector comm enabled / disabled -SHS
        public ConnectionConfig m_displayconnection; // to the projector or similar
        private string m_monitorid; // which monitor we're using

        public MonitorConfig()
        {
            m_XDLPRes = 1024;
            m_YDLPRes = 768;
            m_Xpixpermm = 1.0;
            m_Ypixpermm = 1.0;
            m_displayconnectionenabled = false;  // -SHS
            m_displayconnection = new ConnectionConfig();
            m_displayconnection.CreateDefault();
            m_monitorid = "";
        }

        public bool Load(XmlHelper xh, XmlNode parent)
        {
            XmlNode mdc = xh.FindSection(parent, "MonitorDriverConfig");
            m_XDLPRes = xh.GetDouble(mdc, "DLP_X_Res", 1024.0);
            m_YDLPRes = xh.GetDouble(mdc, "DLP_Y_Res", 768.0);
            // m_Xpixpermm and m_Ypixpermm are calculated dinamically, no need to save/load
            //m_Xpixpermm = xh.GetDouble(mdc, "PixPermmX", 10.0); 
            //m_Ypixpermm = xh.GetDouble(mdc, "PixPermmY", 10.0);
            m_monitorid = xh.GetString(mdc, "MonitorID", "");
            m_displayconnectionenabled = xh.GetBool(mdc, "DisplayCommEnabled", false);
            m_displayconnection.Load(xh, mdc);
            return true;
        }

        public bool Save(XmlHelper xh, XmlNode parent) // use new xml system -SHS
        {
            XmlNode mdc = xh.FindSection(parent, "MonitorDriverConfig");
            xh.SetParameter(mdc, "DLP_X_Res", m_XDLPRes);
            xh.SetParameter(mdc, "DLP_Y_Res", m_YDLPRes);
            // m_Xpixpermm and m_Ypixpermm are calculated dinamically, no need to save/load
            //xh.SetParameter(mdc, "PixPermmX", m_Xpixpermm);
            //xh.SetParameter(mdc, "PixPermmY", m_Ypixpermm);
            xh.SetParameter(mdc, "MonitorID", m_monitorid);
            xh.SetParameter(mdc, "DisplayCommEnabled", m_displayconnectionenabled);
            m_displayconnection.Save(xh, mdc);
            return true;
        }

        public void CalcPixPerMM(double platX, double platY)
        {
            try
            {
                m_Xpixpermm = m_XDLPRes / platX;
                m_Ypixpermm = m_YDLPRes / platY;
            }
            catch (Exception)
            {
                DebugLogger.Instance().LogError("Invalid machine platform size");
                m_Xpixpermm = 1.0;
                m_Ypixpermm = 1.0;
            }
        }

        public void SetDLPRes(double xres, double yres)
        {
            m_XDLPRes = xres;
            m_YDLPRes = yres;
        }

        public double PixPerMMX { get { return m_Xpixpermm; } }
        public double PixPerMMY { get { return m_Ypixpermm; } }
        public int XRes { get { return (int)m_XDLPRes; } }
        public int YRes { get { return (int)m_YDLPRes; } }

        public string Monitorid
        {
            get { return m_monitorid; }
            set { m_monitorid = value; }
        }

    }
}
