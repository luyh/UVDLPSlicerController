using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Slicing.Modules
{
    public class UV_Bottom : SliceModule
    {
        private static Parm[] parms =  
        {
            new Parm("NumBottom",5,"This specifies the number of bottom layers."),
            new Parm("ExposureTime",10000,"This specifies the exposure time of the bottom layers."),
        };

        public UV_Bottom() 
        {
            m_name = "UV Bottom";
            m_description = "This Module controls the bottom layers of the print.\r\n Number of bottom layers and layer exposure time can be set";
            CreateDefault();
        }
        public override void CreateDefault()
        {
            m_parms.AddParms(parms);
        }
        public override bool Execute() 
        {
            return false;
        }
    }
}
