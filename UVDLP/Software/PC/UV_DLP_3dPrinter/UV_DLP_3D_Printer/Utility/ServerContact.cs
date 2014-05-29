using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using UV_DLP_3D_Printer.Licensing;
using CreationWorkshop.Licensing;
using UV_DLP_3D_Printer.Plugin;
using System.Collections.Specialized;
using System.Windows.Forms;
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
        private NameValueCollection GenerateInfo() 
        {
            NameValueCollection nvc = new NameValueCollection();
            //nvc["thing1"] = "hello";
            //nvc["thing2"] = "world";
            int lc = 0; // licence counter
            // iterate through all license keys in keyring
            nvc["NumLicenses"] = KeyRing.Instance().m_keys.Count.ToString();
            foreach (LicenseKey lk in KeyRing.Instance().m_keys) 
            {
                string License = lk.m_key;
                string VendorID = lk.VendorID.ToString();
                VIDs.VEntry ve = VIDs.Find(lk.VendorID);
                string LicenseValid = lk.valid.ToString();
                if (ve != null) 
                {
                    string VendorName = ve.m_name;
                    nvc["VendorName_" + lc.ToString()] = VendorName;
                }
                nvc["License_" + lc.ToString()] = License;
                nvc["VendorID_" + lc.ToString()] = VendorID;
                nvc["LicenseValid_" + lc.ToString()] = LicenseValid;                
                lc++;
            }
            // when talking to plugins, be sure to add some error handling when poking them
            nvc["NumPlugins"] = UVDLPApp.Instance().m_plugins.Count.ToString();
            int pc = 0; // plugin count
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
            nvc["CWVersion"] =  Application.ProductVersion; // include the product version
            return nvc;
        }
        /// <summary>
        /// I think I need to change this to make multiple posts
        /// one post for each licensed plug-in
        /// </summary>
        private void ContactServerThread() 
        {
            // try the HTTP Post
            try
            {
                
               WebClient client = new WebClient();
                string postform = UVDLPApp.Instance().m_appconfig.m_contactform;
                string posturl = UVDLPApp.Instance().m_appconfig.m_serveraddress;
                //foreach licensed plugin, generate the info...
                NameValueCollection values = GenerateInfo();
                var response = client.UploadValues(posturl + "//" + postform, values);
                ParseResponse(Encoding.Default.GetString(response));
                //parse the response
            }
            catch (Exception ex) 
            {
               // DebugLogger.Instance().LogError("Couldn't contact server");
                DebugLogger.Instance().LogError(ex);
                // may want to silently fail here
            }
        }

        private void ParseResponse(string response) 
        {
        
        }

        /*using (var client = new WebClient())
{
    var values = new NameValueCollection();
    values["thing1"] = "hello";
    values["thing2"] = "world";

    var response = client.UploadValues("http://www.mydomain.com/recepticle.aspx", values);

    var responseString = Encoding.Default.GetString(response);
}*/

    }
}
