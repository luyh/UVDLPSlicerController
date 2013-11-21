using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer.Plugin;
using System.Drawing;

namespace plugTest
{
    // this class must be named 'Plugin'
    // it serves as the main entry point  
    public class PlugIn : IPlugin
    {
        private IPluginHost m_host;
        private bool inited;
        private static string m_Vendorname =    "TestVendor";
        private static int m_VendorID =         1234;
        private static string m_PluginName =    "TestPlugin";
        private byte []m_hash; // simple SHA1 hash for validating against license keys

        public PlugIn() 
        {
            inited = false;
        }

        private void Initialize() 
        {
            if (inited) // no re-initialization
                return;
            inited = true;
            //copy the hash 
            m_hash = new byte[20];
        }

        public string Name {get { return m_PluginName; }}
        public IPluginHost Host 
        {
            get { return m_host; }
            set 
            { 
                m_host = value;  // set the host
                Initialize(); // initialize any local resources
            }
        }
        public string Vendorname{ get { return m_Vendorname; }} // name of the Vendor who wrote this
        public int VendorID {get { return m_VendorID; }} // identifier of the vendor
        
        public Bitmap IconImage 
        {
            get { return null; }
        }
        public Bitmap SplashImage 
        {
            get { return null; }
        }
    }
}
