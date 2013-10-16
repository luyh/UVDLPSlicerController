using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Configs
{
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
            htrad = .5;//
            hbrad = 1; //
            ftrad = 1;
            fbrad = 2; // for support on the platform
            fbrad2 = .5; // for intra-object support
            //vdivs = 1; // divisions vertically
        }
        public bool Load(string filename) 
        {
            try
            {
                return false;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
        }
        public bool Save(string filename)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
        }

    }
}
