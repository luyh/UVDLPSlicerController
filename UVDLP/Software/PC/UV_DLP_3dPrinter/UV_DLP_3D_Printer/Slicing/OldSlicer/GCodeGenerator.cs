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

        // here we prepare the gcode preprocessor and fill all nessesary variables 
        protected static PreProcessor PreparePreprocessor(SliceFile sf, MachineConfig pi)
        {
            PreProcessor pp = new PreProcessor();
            pp.SetVar("$LayerThickness", sf.m_config.ZThick);
            pp.SetVar("$ZLiftDist", sf.m_config.liftdistance);
            pp.SetVar("$ZLiftRate", sf.m_config.liftfeedrate);
            pp.SetVar("$ZRetractRate", sf.m_config.liftretractrate);
            pp.SetVar("$SlideTiltVal", sf.m_config.slidetiltval);
            pp.SetVar("$BlankTime", sf.m_config.blanktime_ms);
            pp.SetVar("$LayerTime", sf.m_config.layertime_ms);
            pp.SetVar("$FirstLayerTime", sf.m_config.firstlayertime_ms);
            return pp;
        }

        /*
         This is the main function to generate gcode files for the 
         * already sliced model
         */
        public static GCodeFile Generate(SliceFile sf, MachineConfig pi) 
        {
            String gcode;
            StringBuilder sb = new StringBuilder();
            PreProcessor pp = PreparePreprocessor(sf, pi);
            double zdist = 0.0;
           // double feedrate = pi.ZMaxFeedrate; // 10mm/min
            double liftfeed = sf.m_config.liftfeedrate;
            double retractfeed = sf.m_config.liftretractrate;
            double zdir = 1.0; // assume a bottom up machine
            int numbottom = sf.m_config.numfirstlayers;

            if (sf.m_config.direction == SliceBuildConfig.eBuildDirection.Top_Down) 
            {
                zdir = -1.0;// top down machine, reverse the z direction
            }
            pp.SetVar("$ZDir", zdir);

            // append the build parameters as reference
            sb.Append(sf.m_config.ToString());
            sb.Append(";Number of Slices        =  " + sf.NumSlices.ToString() + "\r\n");

            sb.Append(pi.ToString());//add the machine build parameters string

            // append the header
            sb.Append(pp.Process(sf.m_config.HeaderCode));

            zdist = sf.m_config.ZThick;

            String firstlayerdelay = ";<Delay> " + sf.m_config.firstlayertime_ms + " \r\n";
            String layerdelay = ";<Delay> " + sf.m_config.layertime_ms + " \r\n";
            String blankdelay = ";<Delay> " + sf.m_config.blanktime_ms + " \r\n";

            String preSliceGCode = pp.Process(sf.m_config.PreSliceCode);
            String LiftGCode = pp.Process(sf.m_config.LiftCode);

            for (int c = 0; c < sf.NumSlices; c++)
            {
                sb.Append(preSliceGCode);//add in the pre-slice code
                // this is the marker the BuildManager uses to display the correct slice
                sb.Append(";<Slice> " + c + " \r\n");
                // add a pause for the UV resin to be set using this image
                if (c < numbottom)// check for the bottom layers
                {
                    sb.Append(firstlayerdelay);
                }
                else
                {
                    sb.Append(layerdelay);
                }
                sb.Append(";<Slice> Blank \r\n"); // show the blank layer
                sb.Append(LiftGCode); // append the pre-lift codes
            }
            //append the footer
            sb.Append(pp.Process(sf.m_config.FooterCode));
            gcode = sb.ToString();
            GCodeFile gc = new GCodeFile(gcode);
            return gc;
        }
    }
}
