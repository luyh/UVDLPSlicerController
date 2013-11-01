using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Xml;
using UV_DLP_3D_Printer.Drivers;

namespace UV_DLP_3D_Printer.Configs
{
    public class DeviceDriverConfig
    {
        public eDriverType m_drivertype;
        public ConnectionConfig m_connection; // main serial connection to printer
        public ConnectionConfig m_displayconnection; // to the projector or similar
        public Boolean m_displayconnectionenabled;   // projector comm enabled / disabled -SHS

        public DeviceDriverConfig()
        {
            m_drivertype = eDriverType.eGENERIC; // default to a null driver
            m_displayconnectionenabled = false;  // -SHS
            m_connection = new ConnectionConfig();
            m_displayconnection = new ConnectionConfig();
            m_connection.CreateDefault();
            m_displayconnection.CreateDefault();

        }

        public bool Load(XmlHelper xh, XmlNode parent) // use new xml system -SHS
        {
            bool retval = false;
            XmlNode mdc = xh.FindSection(parent, "MotorsDriverConfig");
            m_drivertype = (eDriverType)xh.GetEnum(mdc, "DriverType", typeof(eDriverType), eDriverType.eGENERIC);
            if (m_connection.Load(xh, mdc))
            {
                retval = true;
            }
            XmlNode pdc = xh.FindSection(parent, "ProjectorDriverConfig");
            m_displayconnectionenabled = xh.GetBool(pdc, "DisplayCommEnabled", false);
            m_displayconnection.Load(xh, pdc);
            return retval;
        }

        public bool Save(XmlHelper xh, XmlNode parent) // use new xml system -SHS
        {
            bool retval = false;
            XmlNode mdc = xh.FindSection(parent, "MotorsDriverConfig");
            xh.SetParameter(mdc, "DriverType", m_drivertype);
            if (m_connection.Save(xh, mdc))
            {
                retval = true;
            }
            XmlNode pdc = xh.FindSection(parent, "ProjectorDriverConfig");
            xh.SetParameter(pdc, "DisplayCommEnabled", m_displayconnectionenabled);
            m_displayconnection.Save(xh, pdc);

            return retval;
        }

    }
}
