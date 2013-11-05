using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Slicing.Modules
{
    public class UV_GCode_Gen : SliceModule
    {
        private static Parm[] parms =  
        {
            new Parm("ZThick",0.025,"This is the thickness of the slice in mm")
        };

        public UV_GCode_Gen() 
        {
            this.m_name = "UV DLP GCode Generator";
            this.m_description = "This is the module that generates and exports GCode files for UV DLP sliced models";
            this.m_help = "This is the module that generates and exports GCode files for UV DLP sliced models";
            m_parms.AddParms(parms);
        }
        public override bool Execute()
        {
            return base.Execute();
        }
    }
}
