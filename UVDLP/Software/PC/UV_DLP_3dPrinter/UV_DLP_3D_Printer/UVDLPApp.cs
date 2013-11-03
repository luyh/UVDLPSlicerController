using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Engine3D;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using UV_DLP_3D_Printer.Drivers;
using UV_DLP_3D_Printer.Slicing;
using UV_DLP_3D_Printer;
using System.Drawing;
using UV_DLP_3D_Printer.Configs;
using System.Collections;
using Ionic.Zip;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace UV_DLP_3D_Printer
{
    public enum eAppEvent
    {
        eModelAdded,
        eModelNotLoaded,
        eModelRemoved,
        eGCodeLoaded,
        eGCodeSaved,
        eSupportGenerated,
        eSlicedLoaded,
        eMachineTypeChanged,
        eShowDLP,
        eShowCalib,
        eShowBlank,
        eHideDLP,
        eMachineConnected, // the main serial port for the machine was opened - aka - we connected
        eMachineDisconnected, // the machine disconnected
        eDisplayConnected,
        eDisplayDisconnected,
        eReDraw, // this is used when an application action needs to re-draw the 3d display
    }
    public delegate void AppEventDelegate(eAppEvent ev, String Message);
    /*
     This represents the main application object
     */
    public class UVDLPApp
    {
        public AppEventDelegate AppEvent;
        private static UVDLPApp m_instance = null;
        public String m_PathMachines;
        public String m_PathProfiles;
        public String m_apppath;
        // the current application configuration object
        public AppConfig m_appconfig;
        public string appcofnginame; // the full filename
        // the simple 3d graphic engine we're using along with OpenGL
        public Engine3d m_engine3d = new Engine3d();
        // the current model we're working with
        private Object3d m_selectedobject = null;
        // the scene object used for slicing
        private Object3d m_sceneobject = null;
        // the current machine configuration
        public MachineConfig m_printerinfo = new MachineConfig();
        // the current building / slicing profile
        public SliceBuildConfig m_buildparms;

        public SupportConfig m_supportconfig;
        public SupportGenerator m_supportgenerator;
        // the interface to the printer
        public DeviceInterface m_deviceinterface;// = new PrinterInterface();
        // the generated or loaded GCode File;
        public GCodeFile m_gcode;
        // the slicer we're using 
        public Slicer m_slicer;//
        public FlexSlice m_flexslice;
        //current slice file
        public SliceFile m_slicefile;
        public BuildManager m_buildmgr;
        public prjcmdlst m_proj_cmd_lst;
        public GCodeInterpreter gci = null;

        private static String m_appconfigname = "CreationConfig.xml";
        public static String m_pathsep = "\\";

       // public ArrayList m_tempobjs = null;
        public static UVDLPApp Instance() 
        {
            if (m_instance == null) 
            {
                m_instance = new UVDLPApp();
            }
            return m_instance;
        }

        private UVDLPApp() 
        {
            m_appconfig = new AppConfig();
            m_printerinfo = new MachineConfig();
            m_buildparms = new SliceBuildConfig();
            m_deviceinterface = new DeviceInterface();
            m_buildmgr = new BuildManager();
            m_slicer = new Slicer();
            m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            m_flexslice = new FlexSlice();
            m_gcode = new GCodeFile(""); // create a blank gcode to start with
            m_supportconfig = new SupportConfig();
            m_supportgenerator = new SupportGenerator();
            m_supportgenerator.SupportEvent+= new SupportGeneratorEvent(SupEvent);
            m_proj_cmd_lst = new prjcmdlst();
        }
        public enum Platform
        {
            Windows,
            Linux,
            Mac
        }
        public void SupEvent(SupportEvent ev, string message, Object obj) 
        {
            //if()
            
            try
            {
                switch (ev)
                {
                    case SupportEvent.eCompleted:
                        ArrayList lstobjs = (ArrayList)obj;
                        if (lstobjs != null) 
                        {
                            foreach (Object3d o in lstobjs) 
                            {
                                m_engine3d.AddObject((Object3d)o);    
                            }
                            RaiseAppEvent(eAppEvent.eModelAdded, message);
                        }
                        break;
                    case SupportEvent.eCancel:
                        break;
                    case SupportEvent.eProgress:
                        break;
                    case SupportEvent.eStarted:
                        
                        break;
                    case SupportEvent.eSupportGenerated:
                        //m_engine3d.AddObject((Object3d)obj);
                      //  RaiseAppEvent(eAppEvent.eModelAdded, message);
                            //add the model to the scene
                        break;
                }
            }
            catch (Exception ) 
            {
                //DebugLogger.Instance().LogError(ex.Message);       // look more into the error being raised here on slicing completed
            }
        }
        public void RaiseAppEvent(eAppEvent ev, String message) 
        {
            if (AppEvent != null) 
            {
                AppEvent(ev, message);
            }
        }
        public bool SaveProjectorCommands(string filename) 
        {
            try
            {
                Stream TestFileStream = File.Create(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(TestFileStream, m_proj_cmd_lst);
                TestFileStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
                
        }
        public bool LoadProjectorCommands(string filename) 
        {
            try
            {
                if (File.Exists(filename))
                {
                    Stream TestFileStream = File.OpenRead(filename);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    m_proj_cmd_lst = (prjcmdlst)deserializer.Deserialize(TestFileStream);
                    TestFileStream.Close();
                }

                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }

        }

        public bool LoadSupportConfig(string filename)
        {
            /*
            try
            {
                if (File.Exists(filename))
                {
                    Stream TestFileStream = File.OpenRead(filename);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    m_supportconfig = (SupportConfig)deserializer.Deserialize(TestFileStream);
                    TestFileStream.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
             * */
            m_supportconfig.Load(m_apppath + m_pathsep + filename);
            return true;
        }
        public bool SaveSupportConfig(string filename)
        {
            /*try
            {
                Stream TestFileStream = File.Create(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(TestFileStream, m_supportconfig);
                TestFileStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }*/
            m_supportconfig.Save(m_apppath + m_pathsep + filename);
            return true;
        }
        public void CalcScene() 
        {
            m_sceneobject = new Object3d();
            int idx = 0;
            foreach(Object3d obj in m_engine3d.m_objects)
            {
                m_sceneobject.Add(obj);
                if (idx == 0) // if this is the first object
                {
                    if (m_engine3d.m_objects.Count > 1)// if there is more than one object in the scene, generate a unique name                      
                    {
                        string scenename = obj.m_fullname;
                        scenename = Path.GetDirectoryName(obj.m_fullname) + m_pathsep + Path.GetFileNameWithoutExtension(obj.m_fullname) + "_scene.stl";
                        m_sceneobject.m_fullname = scenename;
                    }
                    else 
                    {
                        m_sceneobject.m_fullname = obj.m_fullname;
                    }
                }
                idx++;
            }
        }
        public Object3d Scene 
        {
            get 
            {
                return m_sceneobject;
            }
        }

        public void StartAddSupports()
        {

            CalcScene(); // do it for the scene
            m_supportgenerator.Start(m_supportconfig, m_sceneobject);

        }

        public void RemoveAllSupports() 
        {
            ArrayList lst = new ArrayList();

            foreach (Object3d obj in m_engine3d.m_objects) 
            {
                if (obj.tag == Object3d.OBJ_SUPPORT) 
                {
                    lst.Add(obj);
                }
            }
            foreach (Object3d obj in lst) 
            {
                m_engine3d.RemoveObject(obj);
            }
        }

        /// <summary>
        /// Adds a new dummy support
        /// </summary>
        public void AddSupport() 
        {
           // Cylinder3d cyl = new Cylinder3d();
           // cyl.Create(2.5, 1.5, 10, 15, 2);
            Support s = new Support();
            //s.Create((float)m_supportconfig.fbrad, 1.5f, 1.5f, .75f, 2f, 5f, 2f, 20);
            s.Create((float)m_supportconfig.fbrad, (float)m_supportconfig.ftrad, (float)m_supportconfig.hbrad,
                (float)m_supportconfig.htrad, 2f, 5f, 2f, 11);
            m_engine3d.AddObject(s);
            RaiseAppEvent(eAppEvent.eModelAdded, "Model Created");
        }
        /// <summary>
        /// Removes the currently selected object
        /// </summary>
        public void RemoveCurrentModel() 
        {
            m_engine3d.RemoveObject(SelectedObject);
            SelectedObject = null;
            RaiseAppEvent(eAppEvent.eModelRemoved, "model removed");
        }
        public Object3d SelectedObject
        {
            get 
            {
                return m_selectedobject;
            }
            set 
            {
                m_selectedobject = value;
                m_engine3d.UpdateLists(); // need to re-update the selected object lists
            }
        }

        /// <summary>
        /// Loads a model, adds it to the 3d engine to be shown, and raises an app event
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadModel(String filename) 
        {
            try
            {
                Object3d obj = new Object3d();

                string ext = Path.GetExtension(filename);
                bool ret = false;
                ext = ext.ToLower();
                if (ext.Equals(".dxf")) 
                {
                    ret = obj.LoadDXF(filename);
                }
                if (ext.Equals(".stl"))
                {    
                    ret = obj.LoadSTL(filename);               
                }
                if (ext.Equals(".obj")) 
                {
                    ret = obj.LoadObjFile(filename);
                }
                if (ext.Equals(".3ds")) 
                {
                    ret = obj.Load3ds(filename);
                }
                if (ret == true)
                {
                    m_engine3d.AddObject(obj);
                    SelectedObject = obj;
                    UVDLPApp.Instance().m_engine3d.UpdateLists();
                    m_slicefile = null; // the slice file is not longer current
                    RaiseAppEvent(eAppEvent.eModelAdded, "Model Loaded " + filename);
                    //now try to load the gcode file
                    string gcodefile = "";
                    gcodefile = Path.GetDirectoryName(filename) + m_pathsep + Path.GetFileNameWithoutExtension(filename);// +".gcode";
                    gcodefile += m_pathsep + Path.GetFileNameWithoutExtension(filename) + ".gcode";

                    if (File.Exists(gcodefile))
                    {
                        LoadGCode(gcodefile);
                    }
                    else // read the gcode from the zip file 
                    {
                        string zpath = "";
                        zpath = Path.GetDirectoryName(obj.m_fullname);
                        zpath += UVDLPApp.m_pathsep;
                        zpath += Path.GetFileNameWithoutExtension(obj.m_fullname);// strip off the file extension
                        zpath += ".zip";
                        String entryname = Path.GetFileNameWithoutExtension(obj.m_fullname) + ".gcode";
                        if(File.Exists(zpath)) // make sure the file exists before we try to read it
                        {
                            Stream s = Utility.ReadFromZip(zpath,entryname);
                            if(s  != null)
                            {
                                s.Seek(0, 0); // go to the beginning of the stream
                                byte []array = Utility.ReadFully(s);
                                string gc = System.Text.Encoding.ASCII.GetString(array);
                                m_gcode = new GCodeFile(gc);
                                RaiseAppEvent(eAppEvent.eGCodeLoaded, "GCode Loaded " + entryname);
                            }
                            else 
                            {
                                DebugLogger.Instance().LogError("Could not load GCode from Zip " + zpath);
                            }
                        }
                        
                    }
                    if(m_gcode !=null)
                    {
                        int xres, yres, numslices;
                        xres = m_gcode.GetVar("Projector X Res");
                        yres = m_gcode.GetVar("Projector Y Res");
                        numslices = m_gcode.GetVar("Number of Slices");
                        m_slicefile = new SliceFile(xres,yres,numslices);
                        m_slicefile.modelname = obj.m_fullname;
                        m_slicefile.m_config = null; //this can be null if we're loading it...
                        RaiseAppEvent(eAppEvent.eSlicedLoaded, "SliceFile Created");
                    }
                }
                else 
                {
                    RaiseAppEvent(eAppEvent.eModelNotLoaded, "Model " + filename + " Failed to load");
                }

                return ret;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers,SliceFile sf) 
        {
            String path = "";
            switch (ev) 
            {
                case Slicer.eSliceEvent.eSliceStarted:

                    break;
                case Slicer.eSliceEvent.eLayerSliced:
                  
                    break;
                case Slicer.eSliceEvent.eSliceCompleted:
                    m_slicefile = sf;
                    //generate the GCode
                    m_gcode = GCodeGenerator.Generate(m_slicefile, m_printerinfo);
                    
                    path = Path.GetDirectoryName(m_slicefile.modelname);
                    string fn = Path.GetFileNameWithoutExtension(m_slicefile.modelname);
                    //see if we're exporting this to a zip file 
                    if (sf.m_config.m_exportopt.Contains("ZIP"))
                    {
                        // open the existing zip file
                        //store the gcode
                        Stream stream = new MemoryStream(System.Text.Encoding.ASCII.GetBytes (m_gcode.RawGCode));
                        string zpath = "";
                        zpath = Path.GetDirectoryName(m_slicefile.modelname);
                        zpath += UVDLPApp.m_pathsep;
                        zpath += Path.GetFileNameWithoutExtension(m_slicefile.modelname);// strip off the file extension
                        zpath += ".zip";
                        if (!Utility.StoreInZip(zpath, Path.GetFileNameWithoutExtension(m_slicefile.modelname) + ".gcode", stream)) 
                        {
                            DebugLogger.Instance().LogError("Could not store GCode in Zip " + zpath);
                        }
                    }
                    else  // or just to the disk
                    {
                        string sdn = path + UVDLPApp.m_pathsep + fn + UVDLPApp.m_pathsep + fn + ".gcode";
                        SaveGCode(sdn);
                    }
                    
                    //save the slicer object for later too                    
                    //save the slice file

                   // UVDLPApp.Instance().m_slicefile.Save(path + UVDLPApp.m_pathsep + fn + ".sliced");
                    break;
                case Slicer.eSliceEvent.eSliceCancelled:
                    DebugLogger.Instance().LogRecord("Slicing Cancelled");
                    break;


            }
        }

        private void StartGCodeInterpret() 
        {
            if (gci == null) 
            {
                gci = new GCodeInterpreter();
            }
            gci.GCode = m_gcode.Lines;
            gci.StartInterpret();
        
        }
        public void LoadGCode(String filename)
        {
            try
            {
                if (!m_gcode.Load(filename))
                {
                    DebugLogger.Instance().LogRecord("Cannot load GCode File " + filename);
                }
                //StartGCodeInterpret();
                RaiseAppEvent(eAppEvent.eGCodeLoaded, "GCode Loaded " + filename);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
        public void SaveGCode(String filename) 
        {
            try
            {
                if (!UVDLPApp.Instance().m_gcode.Save(filename))
                {
                    DebugLogger.Instance().LogRecord("Cannot save GCode File " + filename);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        // a public property to get the 3d engine
        public Engine3d Engine3D { get { return m_engine3d; } }

        public static Platform RunningPlatform()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    // Well, there are chances MacOSX is reported as Unix instead of MacOSX.
                    // Instead of platform check, we'll do a feature checks (Mac specific root folders)
                    if (Directory.Exists("/Applications")
                        & Directory.Exists("/System")
                        & Directory.Exists("/Users")
                        & Directory.Exists("/Volumes"))
                        return Platform.Mac;
                    else
                        return Platform.Linux;

                case PlatformID.MacOSX:
                    return Platform.Mac;

                default:
                    return Platform.Windows;
            }
        }

        /*
         This function returns the path to the current profile terminated by pathsep
         */
        public String ProfilePathString()
        {
            String profilepath = Path.GetDirectoryName(m_appconfig.m_cursliceprofilename);
            profilepath += m_pathsep;
            profilepath += Path.GetFileNameWithoutExtension(m_appconfig.m_cursliceprofilename);
            profilepath += m_pathsep;
            return profilepath;
        }
        public bool LoadBuildSliceProfile(string filename) 
        {
            m_buildparms = new SliceBuildConfig();
            bool ret = m_buildparms.Load(filename);
            if (ret) 
            {
                m_appconfig.m_cursliceprofilename = filename;
                m_appconfig.Save(m_apppath + m_pathsep + m_appconfigname);// this name doesn't change
            }
            return ret;
        }


        /*
         This function loads the machine profile and makes it current
         */
        public bool LoadMachineConfig(string filename) 
        {
            bool ret = m_printerinfo.Load(filename);
            if (ret) 
            {
                m_appconfig.m_curmachineeprofilename = filename; // set the app config name
                //save the app config
                m_appconfig.Save(m_apppath + m_pathsep + m_appconfigname);// this name doesn't change
            }
            RaiseAppEvent(eAppEvent.eMachineTypeChanged, "");
            return ret;
        }

        public void SaveCurrentMachineConfig() 
        {
            try
            {
                m_printerinfo.Save(m_appconfig.m_curmachineeprofilename);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
        public void SaveCurrentSliceBuildConfig()
        {
            try
            {
                m_buildparms.Save(m_appconfig.m_cursliceprofilename);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
        public void SetupDriverProjector()
        {
            DebugLogger.Instance().LogRecord("Changing monitor driver type to " + eDriverType.eGENERIC.ToString());
            if (m_deviceinterface.DriverProjector != null)
            {
                if (m_deviceinterface.DriverProjector.Connected == true)
                {
                    // be sure to close the old driver to play nice
                    m_deviceinterface.DriverProjector.Disconnect();
                }
            }
            m_deviceinterface.DriverProjector = DriverFactory.Create(eDriverType.eGENERIC);
        }
        public void SetupDriver() 
        {
            DebugLogger.Instance().LogRecord("Changing driver type to " + m_printerinfo.m_driverconfig.m_drivertype.ToString());
            if (m_deviceinterface.Driver != null) 
            {
                if (m_deviceinterface.Driver.Connected == true) 
                {
                    // be sure to close the old driver to play nice
                    m_deviceinterface.Driver.Disconnect();
                }
            }
            m_deviceinterface.Driver = DriverFactory.Create(m_printerinfo.m_driverconfig.m_drivertype);            
        }
        public void SaveAppConfig() 
        {
            m_appconfig.Save(m_apppath + m_pathsep + m_appconfigname);  // use full path - SHS
        }
        /// <summary>
        /// This function returns a list of Slice/Build Profiles
        /// </summary>
        /// <returns></returns>
        public List<string>  SliceProfiles() 
        {
            List<string> profiles = new List<string>();
            try
            {

                string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathProfiles, "*.slicing");
                string curprof = Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_buildparms.m_filename);
                //create a new menu item for all build/slice profiles
                foreach (String profile in filePaths)
                {
                    String pn = Path.GetFileNameWithoutExtension(profile);
                    profiles.Add(pn);
                }
                
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
            return profiles;
        }
        public void DoAppStartup() 
        {
            m_apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //get the path separater 
            if (RunningPlatform() == Platform.Windows)
            {
                m_pathsep = "\\";
            }
            else
            {
                m_pathsep = "/";
            }
            // define some default paths
            m_PathMachines = m_apppath + m_pathsep + "Machines";  // use full paths - SHS
            m_PathProfiles = m_apppath + m_pathsep + "Profiles";

            // set up directories if they don't exist
            if (!Directory.Exists(m_PathMachines)) 
            {
                Utility.CreateDirectory(m_PathMachines);
            }
            if (!Directory.Exists(m_PathProfiles))
            {
                Utility.CreateDirectory(m_PathProfiles);
            }

            if (!m_appconfig.Load(m_apppath + m_pathsep + m_appconfigname))  // use full path - SHS
            {
                m_appconfig.CreateDefault();
                m_appconfig.Save(m_apppath + m_pathsep + m_appconfigname);  // use full path - SHS
            }

            //load the current machine configuration file
            if (!m_printerinfo.Load(m_appconfig.m_curmachineeprofilename)) 
            {
                m_printerinfo.Save(m_appconfig.m_curmachineeprofilename);
            }
            // machine configuration was just loaded here.
            RaiseAppEvent(eAppEvent.eMachineTypeChanged, ""); // notify the gui to set up correctly
            //load the projector command list

            if (!LoadProjectorCommands(m_apppath + m_pathsep + m_appconfig.ProjectorCommandsFile))  // use full path - SHS
            {
                SaveProjectorCommands(m_apppath + m_pathsep + m_appconfig.ProjectorCommandsFile); // use full path - SHS
            }
            //load the current slicing profile
            if (!m_buildparms.Load(m_appconfig.m_cursliceprofilename)) 
            {
                m_buildparms.CreateDefault();
                m_buildparms.Save(m_appconfig.m_cursliceprofilename);
            }
            // set up the drivers
            SetupDriver();
            SetupDriverProjector();
            // load the support configuration
            if (!LoadSupportConfig(m_appconfig.SupportConfigName))
            {
                SaveSupportConfig(m_appconfig.SupportConfigName);
            }
        }
        /// <summary>
        /// returns the name of the current build / slice profile
        /// </summary>
        /// <returns></returns>
        public string GetCurrentSliceProfileName() 
        {
            return Path.GetFileNameWithoutExtension(m_appconfig.m_cursliceprofilename);            
        }

    }
}
