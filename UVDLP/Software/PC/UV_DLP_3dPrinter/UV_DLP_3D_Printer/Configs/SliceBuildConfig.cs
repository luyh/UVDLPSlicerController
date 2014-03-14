using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer
{
    /*
     * This class holds some information about the 
     * slicing and building parameters
     */
    [Serializable()]
    public class SliceBuildConfig
    {
        public static int FILE_VERSION = 1;
        public string m_filename; // for housekeeping
        public enum eBuildDirection 
        {
            Top_Down,
            Bottom_Up
        }
        public double dpmmX; // dots per mm x
        public double dpmmY; // dots per mm y

        public int xres, yres; // the resolution of the output image in pixels - set by the machine configuration

        public double ZThick; // thickness of the z layer - slicing height
        public int layertime_ms; // time to project image per layer in milliseconds
        public int firstlayertime_ms; // first layer exposure time 
        public int numfirstlayers;
        public int blanktime_ms; // blanking time between layers
       // public int raise_time_ms; // time delay for the z axis to raise on a per-layer basis
        public int plat_temp; // desired platform temperature in celsius 
       // public bool exportgcode; // export the gcode file when slicing
        public bool exportsvg; // export the svg slices when building
        public bool export; // export image slices when building
        public eBuildDirection direction;
        public double liftdistance; // distance to lift and retract
        public double slidetiltval; // a value used for slide / tilt 
        public bool antialiasing; // should we use anti-aliasing
        public bool usemainliftgcode; // should we use mainliftgcode-tab instead of generating the gcode
        public double aaval; // anti-aliasing scaler value - How much to upsample the image values between 1.0 - 3.0 should be fine
        public double liftfeedrate; // initial lift may cause a lot of suction. To maximize lift power, we slow the steppers down to maximize stepper motor torque.
        public double liftretractrate; // the feedrate that this lowers(for bottom-up) or raises(top-down) the build platform, this is the retraction rate of the lift.
        private String m_headercode; // inserted at beginning of file
        private String m_footercode; // inserted at end of file
        //private String m_preliftcode; // inserted before each slice
        //private String m_postliftcode; // inserted after each slice
        private String m_preslicecode; // inserted before each slice
        //private String m_mainliftcode; // inserted before each slice
        private String m_liftcode; // inserted before each slice
        //private String TiltLiftCode; // inserted before each slice on machines with tilt mechanism
        public int XOffset, YOffset; // the X/Y pixel offset used 
        public String m_exportopt; // export sliced images in ZIP or SUBDIR
        public bool m_flipX; // mirror the x axis
        public bool m_flipY; // mirror the y axis
        public string m_notes;
        public double m_resinprice; // per liter
       // public bool m_sliceimmediate; // slice and render on a per-needed basis
        
        //need some parms here for auto support

        private String[] m_defheader = 
        {
            ";********** Header Start ********\r\n", //
            ";Here you can set any G or M-Code which should be executed BEFORE the build process\r\n",
            "G21 ;Set units to be mm\r\n", 
            "G91 ;Relative Positioning\r\n",
            "M17 ;Enable motors\r\n",
            ";********** Header End **********\r\n", // 
            //";()\r\n"
        };
        private String[] m_deffooter = 
        {
            ";********** Footer Start ********\r\n", //
            ";Here you can set any G or M-Code which should be executed after the last Layer is Printed\r\n",
            "M18 ;Disable Motors\r\n",
            ";<Completed>\r\n", // a marker for completed            
            ";********** Footer End ********\r\n", // 
        };

        
        private String[] m_defpreslice = 
        {
            ";********** Pre-Slice Start ********\r\n", //
            ";Set up any GCode here to be executed before a lift\r\n",
            ";********** Pre-Slice End **********\r\n",
        };
        
        private String[] m_deflift = 
        {
            ";********** Lift Sequence ********\r\n",// 
            "G1{$SlideTiltVal != 0? X$SlideTiltVal:} Z($ZLiftDist * $ZDir) F$ZLiftRate\r\n", 
            "G1{$SlideTiltVal != 0? X($SlideTiltVal * -1):} Z(($LayerThickness-$ZLiftDist) * $ZDir) F$ZRetractRate\r\n",
            ";<Delay> %d$BlankTime\r\n",
            ";********** Lift Sequence **********\r\n", // 
        };

        private string DefGCodeHeader() 
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in m_defheader)
                sb.Append(s);
            return sb.ToString();        
        }

        private string DefGCodeFooter()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in m_deffooter)
                sb.Append(s);
            return sb.ToString();
        }
        private string DefGCodePreslice()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in m_defpreslice)
                sb.Append(s);
            return sb.ToString();
        }
        private string DefGCodeLift()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in m_deflift)
                sb.Append(s);
            return sb.ToString();
        }
        
        public String HeaderCode
        {
            get { return m_headercode; }
            set { m_headercode = value; }
        }
        public String FooterCode
        {
            get { return m_footercode; }
            set { m_footercode = value; }
        }

        public String LiftCode
        {
            get { return m_liftcode; }
            set { m_liftcode = value; }
        }


        public String PreSliceCode
        {
            get { return m_preslicecode; }
            set { m_preslicecode = value; }
        }

        /*
         Copy constructor
         */
        public SliceBuildConfig(SliceBuildConfig source) 
        {
            CopyFrom(source);
        }
        public void CopyFrom(SliceBuildConfig source) 
        {
            dpmmX = source.dpmmX; // dots per mm x
            dpmmY = source.dpmmY; // dots per mm y
            xres = source.xres;
            yres = source.yres; // the resolution of the output image
            ZThick = source.ZThick; // thickness of the z layer - slicing height
            layertime_ms = source.layertime_ms; // time to project image per layer in milliseconds
            firstlayertime_ms = source.firstlayertime_ms;
            blanktime_ms = source.blanktime_ms;
            plat_temp = source.plat_temp; // desired platform temperature in celsius 
            // exportgcode = source.exportgcode; // export the gcode file when slicing
            exportsvg = source.exportsvg; // export the svg slices when building
            export = source.export; // export image slices when building
            m_headercode = source.m_headercode; // inserted at beginning of file
            m_footercode = source.m_footercode; // inserted at end of file
            m_preslicecode = source.m_preslicecode; // inserted before each slice
            m_liftcode = source.m_liftcode; // its the main lift code

            liftdistance = source.liftdistance;
            direction = source.direction;
            numfirstlayers = source.numfirstlayers;
            XOffset = source.XOffset;
            YOffset = source.YOffset;
            slidetiltval = source.slidetiltval;
            antialiasing = source.antialiasing;
            usemainliftgcode = source.usemainliftgcode;
            liftfeedrate = source.liftfeedrate;
            liftretractrate = source.liftretractrate;
            aaval = source.aaval;//
            //m_generateautosupports = source.m_generateautosupports;
            m_exportopt = source.m_exportopt;
            m_flipX = source.m_flipX;
            m_flipY = source.m_flipY;
            m_notes = source.m_notes;
            m_resinprice = source.m_resinprice;        
        }
        public SliceBuildConfig() 
        {           
            // every new config will be set to default settings,
            // if the load fails for some reason (such as a previous version)
            // then whatever information that has already been loaded will stay
            // the rest will have been set up to the default values
            CreateDefault(); 
        }

        public void UpdateFrom(MachineConfig mf)
        {
            //update the slice / build profile here with the 
            // x/y resolution for the current display(s)
            xres = mf.XRenderSize;
            yres = mf.YRenderSize;
            //get the first monitor configuration
            MonitorConfig mc = mf.m_lstMonitorconfigs[0];
            
            dpmmX = (xres) / mf.m_PlatXSize;
            dpmmY = (yres) / mf.m_PlatYSize;        
        }
        public void CreateDefault() 
        {
            numfirstlayers = 3;
            layertime_ms = 1000;// 1 second default
            firstlayertime_ms = 5000;
            blanktime_ms = 2000; // 2 seconds blank
            xres = 1024;
            yres = 768;
            ZThick = .05;
            plat_temp = 75;
            dpmmX = 102.4;
            dpmmY = 76.8;
            XOffset = 0;
            YOffset = 0;
            numfirstlayers = 3;
            //exportgcode = true;
            exportsvg = false;
            export = false;
            direction = eBuildDirection.Bottom_Up;
            liftdistance = 5.0;
            //raise_time_ms = 750;
            slidetiltval = 0.0;
            antialiasing = false;
            usemainliftgcode = false;
            aaval = 1.5;
            liftfeedrate = 50.0;// 50mm/s
            liftretractrate = 100.0;// 100mm/s
            m_exportopt = "SUBDIR"; // default to saving in subdirectory
            m_flipX = false;
            m_flipY = false;
            m_notes = "";
            m_resinprice = 0.0;//
        }

        public bool Load(String filename) 
        {
             m_filename = filename;

            XmlHelper xh = new XmlHelper();
            bool fileExist = xh.Start(filename, "SliceBuildConfig");
            XmlNode sbc = xh.m_toplevel;

            dpmmX = xh.GetDouble(sbc, "DotsPermmX", 102.4);
            dpmmY = xh.GetDouble(sbc, "DotsPermmY", 76.8);
            xres = xh.GetInt(sbc, "XResolution", 1024);
            yres = xh.GetInt(sbc, "YResolution", 768);
            ZThick = xh.GetDouble(sbc, "SliceHeight", 0.05);
            layertime_ms = xh.GetInt(sbc, "LayerTime", 1000); // 1 second default
            firstlayertime_ms = xh.GetInt(sbc, "FirstLayerTime", 5000);
            blanktime_ms = xh.GetInt(sbc, "BlankTime", 2000); // 2 seconds blank
            plat_temp = xh.GetInt(sbc, "PlatformTemp", 75);
            //exportgcode = xh.GetBool(sbc, "ExportGCode"));
            exportsvg = xh.GetBool(sbc, "ExportSVG", false);
            export = xh.GetBool(sbc, "Export", false); ;
            XOffset = xh.GetInt(sbc, "XOffset", 0);
            YOffset = xh.GetInt(sbc, "YOffset", 0);
            numfirstlayers = xh.GetInt(sbc, "NumberofBottomLayers", 3);
            direction = (eBuildDirection)xh.GetEnum(sbc, "Direction", typeof(eBuildDirection), eBuildDirection.Bottom_Up);
            liftdistance = xh.GetDouble(sbc, "LiftDistance", 5.0);
            slidetiltval = xh.GetDouble(sbc, "SlideTiltValue", 0.0);
            antialiasing = xh.GetBool(sbc, "AntiAliasing", false);
            usemainliftgcode = xh.GetBool(sbc, "UseMainLiftGCode", false);
            aaval = xh.GetDouble(sbc, "AntiAliasingValue", 1.5);
            liftfeedrate = xh.GetDouble(sbc, "LiftFeedRate", 50.0); // 50mm/s
            liftretractrate = xh.GetDouble(sbc, "LiftRetractRate", 100.0); // 100mm/s
            m_exportopt = xh.GetString(sbc, "ExportOption", "SUBDIR"); // default to saving in subdirectory
            m_flipX = xh.GetBool(sbc, "FlipX", false);
            m_flipY = xh.GetBool(sbc, "FlipY", false);
            m_notes = xh.GetString(sbc, "Notes", "");
            m_resinprice = xh.GetDouble(sbc, "ResinPriceL", 0.0);

            m_headercode = xh.GetString(sbc, "GCodeHeader", DefGCodeHeader());
            m_footercode = xh.GetString(sbc, "GCodeFooter", DefGCodeFooter()); 
            m_preslicecode = xh.GetString(sbc, "GCodePreslice", DefGCodePreslice()); 
            m_liftcode = xh.GetString(sbc, "GCodeLift", DefGCodeLift()); 

            if (!fileExist)
            {
                return xh.Save(FILE_VERSION);
            }

            return true;
         
        }


        public bool Save(String filename) 
        {
            m_filename = filename;
            XmlHelper xh = new XmlHelper();
            bool fileExist = xh.Start(filename, "SliceBuildConfig");
            XmlNode sbc = xh.m_toplevel;

            xh.SetParameter(sbc, "DotsPermmX", dpmmX);
            xh.SetParameter(sbc, "DotsPermmY", dpmmY);
            xh.SetParameter(sbc, "XResolution", xres);
            xh.SetParameter(sbc, "YResolution", yres);
            xh.SetParameter(sbc, "SliceHeight", ZThick);
            xh.SetParameter(sbc, "LayerTime", layertime_ms);
            xh.SetParameter(sbc, "FirstLayerTime", firstlayertime_ms);
            xh.SetParameter(sbc, "BlankTime", blanktime_ms);
            xh.SetParameter(sbc, "PlatformTemp", plat_temp);
            // xh.SetParameter(sbc, "ExportGCode", exportgcode);
            xh.SetParameter(sbc, "ExportSVG", exportsvg);
            xh.SetParameter(sbc, "Export", export);
            xh.SetParameter(sbc, "XOffset", XOffset);
            xh.SetParameter(sbc, "YOffset", YOffset);
            xh.SetParameter(sbc, "NumberofBottomLayers", numfirstlayers);
            xh.SetParameter(sbc, "Direction", direction);
            xh.SetParameter(sbc, "LiftDistance", liftdistance);
            xh.SetParameter(sbc, "SlideTiltValue", slidetiltval);
            xh.SetParameter(sbc, "AntiAliasing", antialiasing);
            xh.SetParameter(sbc, "UseMainLiftGCode", usemainliftgcode);
            xh.SetParameter(sbc, "AntiAliasingValue", aaval);
            xh.SetParameter(sbc, "LiftFeedRate", liftfeedrate);
            xh.SetParameter(sbc, "LiftRetractRate", liftretractrate);
            xh.SetParameter(sbc, "ExportOption", m_exportopt);

            xh.SetParameter(sbc, "FlipX", m_flipX);
            xh.SetParameter(sbc, "FlipY", m_flipY);
            xh.SetParameter(sbc, "Notes", m_notes);
            xh.SetParameter(sbc, "ResinPriceL", m_resinprice);
            xh.SetParameter(sbc, "GCodeHeader", m_headercode);
            xh.SetParameter(sbc, "GCodeFooter", m_footercode);
            xh.SetParameter(sbc, "GCodePreslice", m_preslicecode);
            xh.SetParameter(sbc, "GCodeLift", m_liftcode);
            // xh.SetParameter(sbc, "Raise_Time_Delay",raise_time_ms);

            try
            {
                xh.Save(FILE_VERSION);
                //SaveGCodes();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
            return true;
        }


        // these get stored to the gcode file as a reference
        public override String ToString() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(";(****Build and Slicing Parameters****)\r\n");
            sb.Append(";(Pix per mm X            = " + String.Format("{0:0.00000}", dpmmX) + " px/mm )\r\n");
            sb.Append(";(Pix per mm Y            = " + String.Format("{0:0.00000}", dpmmY) + " px/mm )\r\n");
            sb.Append(";(X Resolution            = " + xres + " px )\r\n");
            sb.Append(";(Y Resolution            = " + yres + " px )\r\n");
            sb.Append(";(X Pixel Offset          = " + XOffset + " px )\r\n");
            sb.Append(";(Y Pixel Offset          = " + YOffset + " px )\r\n");
            sb.Append(";(Layer Thickness         = " + String.Format("{0:0.00000}", ZThick) + " mm )\r\n");
            sb.Append(";(Layer Time              = " + layertime_ms + " ms )\r\n");
            sb.Append(";(Bottom Layers Time        = " + firstlayertime_ms + " ms )\r\n");
            sb.Append(";(Number of Bottom Layers = " + numfirstlayers + " )\r\n");
            sb.Append(";(Blanking Layer Time     = " + blanktime_ms + " ms )\r\n");
            sb.Append(";(Build Direction         = " + direction.ToString() + ")\r\n");
            sb.Append(";(Lift Distance           = " + liftdistance.ToString() + " mm )\r\n");
            sb.Append(";(Slide/Tilt Value        = " + slidetiltval.ToString() + ")\r\n");
            sb.Append(";(Anti Aliasing           = " + antialiasing.ToString() + ")\r\n");
            sb.Append(";(Use Mainlift GCode Tab  = " + usemainliftgcode.ToString() + ")\r\n");
            sb.Append(";(Anti Aliasing Value     = " + aaval.ToString() + " )\r\n");
            sb.Append(";(Z Lift Feed Rate        = " + String.Format("{0:0.00000}", liftfeedrate) + " mm/s )\r\n");
            sb.Append(";(Z Lift Retract Rate     = " + String.Format("{0:0.00000}", liftretractrate) + " mm/s )\r\n");
            sb.Append(";(Flip X                  = " + m_flipX.ToString() + ")\r\n");
            sb.Append(";(Flip Y                  = " + m_flipY.ToString() + ")\r\n");
            return sb.ToString();
        }

        
        public bool SaveFile(String filename, String contents) 
        {
            try
            {
                File.WriteAllText(filename, contents);
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
        public void SaveGCodes() 
        {
            try
            {
                String profilepath = Path.GetDirectoryName(m_filename);
                profilepath += UVDLPApp.m_pathsep;
                profilepath += Path.GetFileNameWithoutExtension(m_filename);
                //create the directory if it doesn't exist
                if (!Directory.Exists(profilepath))
                {
                    Directory.CreateDirectory(profilepath);
                }

                SaveFile(profilepath + UVDLPApp.m_pathsep + "start.gcode", m_headercode);
                SaveFile(profilepath + UVDLPApp.m_pathsep + "end.gcode", m_footercode);
                //LL SaveFile(profilepath + UVDLPApp.m_pathsep + "prelift.gcode", m_preliftcode);
                //LL SaveFile(profilepath + UVDLPApp.m_pathsep + "postlift.gcode", m_postliftcode);
                SaveFile(profilepath + UVDLPApp.m_pathsep + "preslice.gcode", m_preslicecode);
                //LL SaveFile(profilepath + UVDLPApp.m_pathsep + "mainlift.gcode", m_mainliftcode);
                SaveFile(profilepath + UVDLPApp.m_pathsep + "lift.gcode", m_liftcode);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
    }
}
