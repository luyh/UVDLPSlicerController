using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using UV_DLP_3D_Printer.Licensing;
using CreationWorkshop.Licensing;
using UV_DLP_3D_Printer.Plugin;

namespace UV_DLP_3D_Printer
{
    /// <summary>
    /// This class will attempt to phone home to the server to check for updates
    /// and relay licensing information
    /// it will be run once at application startup
    /// </summary>
    public class ServerContact
    {
        private Thread m_thread; // this will be user
        public ServerContact() 
        {
            ContactServer();// this will kick off contacting the server
        }
        public void ContactServer() 
        {
            m_thread = new Thread(new ThreadStart(ContactServerThread));
            m_thread.Start();
            //try an http post            
        }

        // generate the name/value pairs to send to the server
        private void GenerateInfo() 
        {
            int lc = 0; // licence counter
            // iterate through all license keys in keyring
            foreach (LicenseKey lk in KeyRing.Instance().m_keys) 
            {
                string License = lk.m_key;
                string VendorID = lk.VendorID.ToString();
                VIDs.VEntry ve = VIDs.Find(lk.VendorID);
                string LicenseValid = lk.valid.ToString();
                if (ve != null) 
                {
                    string VendorName = ve.m_name;
                }
            }
            // when talking to plugins, be sure to add some error handling when poking them
            foreach (PluginEntry pe in UVDLPApp.Instance().m_plugins) 
            {
                try
                {
                    string PluginName = pe.m_plugin.GetString("PluginName");
                    string VendorName = pe.m_plugin.GetString("VendorName");
                    string Version = pe.m_plugin.GetString("Version");
                    string VendorID = pe.m_plugin.GetString("VendorID");
                }
                catch (Exception) { }
            }
        }

        private void ContactServerThread() 
        {
            // try the HTTP Post
            try
            {
                GenerateInfo();
            }
            catch (Exception) 
            {
                // may want to silently fail here
            }
        }
    }
}
