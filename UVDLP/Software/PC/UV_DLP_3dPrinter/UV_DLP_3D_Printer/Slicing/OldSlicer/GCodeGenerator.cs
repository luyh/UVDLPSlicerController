using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer.Slicing;
namespace UV_DLP_3D_Printer
{
    public class GCodeGenerator
    {
        private GCodeGenerator() 
        {
        }
        /*
         GCode Process for building 3d DVP UV objects
         
         * <Build Start>
         * <Slicing Comments> comments containing the slicing and building parameters
         * <Header Code> start.gcode - commands from this 
         * file are inserted, they contain whatever intiailization sequences are need to initialize the machine
         * at this point, the build tray is in position to start printing a layer
         * <Layer Start>
         * Display the correct image slice for the current layer
         * Delay for <Layertime> to expose the UV resin
         * <Layer End>
         
         
        */

        /*
         This is the main function to generate gcode files for the 
         * already sliced model
         */
        public static GCodeFile Generate(SliceFile sf, MachineConfig pi) 
        {
            String gcode;
            StringBuilder sb = new StringBuilder();
            double zdist = 0.0;
            double feedrate = pi.ZMaxFeedrate; // 10mm/min
            double zdir = 1.0; // assume a bottom up machine
            int numbottom = sf.m_config.numfirstlayers;

            if (sf.m_config.direction == SliceBuildConfig.eBuildDirection.Top_Down) 
            {
                zdir = -1.0;// top down machine, reverse the z direction
            }

            // append the build parameters as reference
            sb.Append(sf.m_config.ToString());
            
            // append the header
            sb.Append(sf.m_config.HeaderCode);

            String firstlayerdelay = "(<Delay> " + sf.m_config.firstlayertime_ms + " )\r\n";
            String layerdelay = "(<Delay> " + sf.m_config.layertime_ms + " )\r\n";
            String blankdelay = "(<Delay> " + sf.m_config.blanktime_ms + " )\r\n";

            zdist = sf.m_config.ZThick;
            // the first thing that needs to happen is a lift sequence to set up the first layer
            // there is no tilt/slide for the initial layer lift 
            sb.Append(sf.m_config.PreLiftCode); // append the pre-lift codes
            //do the lift
            sb.Append("G1 Z" + String.Format("{0:0.00000}", (sf.m_config.liftdistance * zdir)).Replace(',','.') + " F" + feedrate + " (Lift) \r\n");
            // move back from the lift
            sb.Append("G1 Z" + String.Format("{0:0.00000}", ((sf.m_config.liftdistance - zdist  ) * zdir * -1)).Replace(',', '.') + " F" + feedrate + " (End Lift) \r\n");

            // append the post-lift codes
            sb.Append(sf.m_config.PostLiftCode);

            for (int c = 0; c < sf.m_slices.Count; c++)
            {
                sb.Append(sf.m_config.PreSliceCode);//add in the pre-slice code
                // this is the marker the BuildManager uses to display the correct slice
                sb.Append("(<Slice> " + c + " )\r\n");
                // add a pause for the UV resin to be set using this image
                if (c < numbottom)// check for the bottom layers
                {
                    sb.Append(firstlayerdelay);
                }
                else
                {
                    sb.Append(layerdelay);
                }
                sb.Append("(<Slice> Blank )\r\n"); // show the blank layer
                sb.Append(sf.m_config.PreLiftCode); // append the pre-lift codes
                String tmpZU = String.Format("{0:0.00000}", (sf.m_config.liftdistance * zdir)).Replace(',', '.');
                String tmpZD = String.Format("{0:0.00000}", ((sf.m_config.liftdistance - zdist) * zdir * -1)).Replace(',', '.');

                if (sf.m_config.slidetiltval == 0.0) // tilt/slide is not used here
                {
                    sb.Append("G1 Z" + tmpZU + " F" + feedrate + " (Lift) \r\n");
                    sb.Append("G1 Z" + tmpZD + " F" + feedrate + " (End Lift) \r\n");

                }
                else // tilt/slide has a value, so it is used
                {
                    // format the X slide/tilt value
                    String tmpX1 = String.Format("{0:0.00000}", (sf.m_config.slidetiltval)).Replace(',', '.');
                    String tmpX2 = String.Format("{0:0.00000}", (sf.m_config.slidetiltval * -1)).Replace(',', '.');
                    sb.Append("G1 X" + tmpX1 + " Z" + tmpZU + " F" + feedrate + " (Lift) \r\n");
                    sb.Append("G1 X" + tmpX2 + " Z" + tmpZD + " F" + feedrate + " (End Lift) \r\n");
                }
                // append the post-lift codes
                sb.Append(sf.m_config.PostLiftCode);
                // add a delay for the lift sequence and the pre/post lift codes to execute
                sb.Append(blankdelay);
            }
            //append the footer
            sb.Append(sf.m_config.FooterCode);
            gcode = sb.ToString();
            GCodeFile gc = new GCodeFile(gcode);
            return gc;
        }
    }
}
