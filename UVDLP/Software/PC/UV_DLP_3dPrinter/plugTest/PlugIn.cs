using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer.Plugin;

namespace plugTest
{
    public class PlugIn : IPlugin
    {
        private IPluginHost m_host;
        public PlugIn() 
        {
        
        }
        public string Name 
        {
            get { return "Test"; }
            set { }
        }
        public IPluginHost Host 
        {
            get { return m_host; }
            set { m_host = value; }
        }
    }
}
