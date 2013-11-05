using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UV_DLP_3D_Printer.Slicing
{
    /*
     The purpose of this class is to generate supports for un-supported features
     * in the final sliced model
     * 
     * The approach is as follows:
     * start off with a blank image matching the rendered output size
     * 
     * iterate through each layer
     *  for each layer, draw onto the image
     *  look for any islands that appear from layer to layer
     *  The island position is where we need to support
     */
    public class SupportGen : SliceModule
    {
        public SupportGen() 
        {
            m_name = "Support Generator";
            m_description = "This module generates support structures for models";
            m_help = "<info about configuration of this module goes in here>";
        }
    }
}
