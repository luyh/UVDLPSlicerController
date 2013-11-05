using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Slicing.Modules
{
    public class Raft : SliceModule
    {
        public Raft()
        {
            m_name = "Raft Generator";
            m_description = "This module generates raft for the base layer";
            m_help = "<info about configuration of this module goes in here>";            
        }
    }
}
