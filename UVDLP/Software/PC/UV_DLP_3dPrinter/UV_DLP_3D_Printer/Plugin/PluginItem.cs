using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Plugin
{
    /// <summary>
    /// This class is used to return items available in a plugin to the main app
    /// </summary>
    /// 
    //This is a list of the item types returned
    public enum ePlItemType 
    {
        eImage, // graphical resource
        eControl, // control listed
        eXML, // xml resource
        eBin, // binary resource
        eFunction, // a function this plugin exposes
        eString, // a string resource from the plugin
        eInt,    // a simple integer resource
    }
    public class PluginItem
    {
        public string m_name;
        public ePlItemType m_type;
        public int m_data; // extra tag data
        public PluginItem(string name, ePlItemType ty, int tag) 
        {
            m_name = name;
            m_type = ty;
            m_data = tag;
        }
    }
}
