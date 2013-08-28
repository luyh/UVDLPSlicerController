using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Configs
{
    public class SupportConfig
    {
        public double xspace, yspace;
        public double brad;
        public double trad;
        public int vdivs;

        public SupportConfig() 
        {
            xspace = 5.0; // 5 mm spacing
            yspace = 5.0; // 5 mm spacing
            brad = 2;// bottom radius
            trad = .5; // top radius
            vdivs = 1; // divisions vertically
        }
    }
}
