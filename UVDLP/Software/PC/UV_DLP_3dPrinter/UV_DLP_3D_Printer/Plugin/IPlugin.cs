using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Plugin
{
    /// <summary>
    /// This is the interface that DLL's must conform to in order to be considered a plug-in for our program
    /// </summary>
    public interface IPlugin
    {
        string Name { get; set; } // name of the plugin
        //string Vendorname { get; set; } // name of the Vendor who wrote this
        IPluginHost Host { get; set; }
        //void Show();
    }
}
