using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine3D;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer.Slicing
{
    /*
     This is a generic class to hold various bits of data used in the slicing and
     * toolpath generation phase
     */
    public class SliceData
    {
        public Object3d m_obj = null;
        public SliceFile m_slices = null;
        public ParmList m_parms; // copy of applicable parameters
        public SliceData() 
        {

        }
    }
}
