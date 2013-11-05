using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Slicing.Modules
{
    public class ImageSliceExporter : SliceModule
    {
        private static Parm[] parms =  
        {
            new Parm("X Resolution",1024,"This is X Resolution of the exported image"),
            new Parm("Y Resolution",768,"This is Y Resolution of the exported image"),
            new Parm("X Offset",0,"This is X offset"),
            new Parm("X YOffset",0,"This is Y offset"),
        };
        public ImageSliceExporter() 
        {
            CreateDefault();
            m_name = "Image Slice Exporter";
            m_description ="This Module will export images for a sliced model.";
        }
        public override void CreateDefault() 
        {
            m_parms.AddParms(parms);
        }
        public override bool Execute() 
        {
           // SliceModule.m_data.m_slices.RenderSlice
            return true;
        }
    }
}
