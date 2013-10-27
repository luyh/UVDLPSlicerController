using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace UV_DLP_3D_Printer.Configs
{
    /// <summary>
    /// This is a class for holding configuartion to generate
    /// Automatic or manual support structures.
    /// </summary>
[Serializable]
    public class SupportConfig
    {
        public double xspace, yspace;
        public double htrad; // head top radius 
        public double hbrad; // head bottom radius
        public double ftrad; // foot top radius
        public double fbrad; // foot bottom radius
        public double fbrad2; // foot bottom radius 2
        public int vdivs;

        public SupportConfig() 
        {
            xspace = 5.0; // 5 mm spacing
            yspace = 5.0; // 5 mm spacing
            htrad = .2;//
            hbrad = .5; //
            ftrad = .5;
            fbrad = 2; // for support on the platform
            fbrad2 = .2; // for intra-object support
            //vdivs = 1; // divisions vertically
        }
        

    }
}
