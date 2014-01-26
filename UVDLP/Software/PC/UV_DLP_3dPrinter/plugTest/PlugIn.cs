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
        private static PluginItem[] manifest =
        {
            new  PluginItem ("VendorName",ePlItemType.eString,0),
            new  PluginItem ("PluginName",ePlItemType.eString,0),
            new  PluginItem("Icon",ePlItemType.eImage,0),
            new  PluginItem("Splash",ePlItemType.eImage,0),
            new PluginItem("VendorID",ePlItemType.eInt,0),
        };
        private IPluginHost m_host;
        private bool inited;
        private static string m_Vendorname =    "TestVendor";
        private static int m_VendorID =         1234;
        private static string m_PluginName =    "TestPlugin";
        private byte []m_hash; // simple SHA1 hash for validating against license keys
        public String Name { get { return m_PluginName; } }
        /// <summary>
        /// This function returns a list of everything in the plugin
        /// </summary>
        public List<PluginItem> GetPluginItems 
        { 
            get 
            {
                List<PluginItem> items = new List<PluginItem>();
                items.AddRange(manifest);
                return items;
            } 
        }
        /// <summary>
        /// public interface funcxtion to return bitmaps based on name from this plugin
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Bitmap GetImage(string name) 
        {
            return null; 
        }
        public String GetString(string name) 
        {
            return "";
        }
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

        public IPluginHost Host 
        {
            get { return m_host; }
            set 
            { 
                m_host = value;  // set the host
                Initialize(); // initialize any local resources
            }
        }
    }
}
