using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UV_DLP_3D_Printer.Plugin
{
    /// <summary>
    /// This is the interface that DLL's must conform to in order to be considered a plug-in for our program
    /// </summary>
    public interface IPlugin
    {
        string Name { get;  } // name of the plugin
        string Vendorname { get;  } // name of the Vendor who wrote this
        int VendorID { get; }
        IPluginHost Host { get; set; } // this will set the plugin host
        //void Show();
        Bitmap IconImage { get; }
        Bitmap SplashImage { get; }
    }
}
