using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.IO;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer
{
    /*
     * The current application configuration
     */
    public class AppConfig
    {
        public const int FILE_VERSION = 1; // this should change every time the format changes
        private String m_LastModelFilename; // the last model loaded
        public string m_cursliceprofilename; // slicing / building profile
        public string m_curmachineeprofilename; // machine profile
        bool m_autoconnect; // autoconnect to the machine
        bool m_loadlastmodel; // load and display the last model
        public string m_slic3rloc; // location of slicer exetutable- shouldn't be here?
        public Color m_foregroundcolor;
        public Color m_backgroundcolor;
        public string SupportConfigName = "supportconfig.xml";
        public string ProjectorCommandsFile = "projectorcommands.xml";

        public void CreateDefault() 
        {
            m_cursliceprofilename = UVDLPApp.Instance().m_PathProfiles + UVDLPApp.m_pathsep + "default.slicing";
            m_curmachineeprofilename = UVDLPApp.Instance().m_PathMachines + UVDLPApp.m_pathsep + "NullMachine.machine";
            SupportConfigName = "supportconfig.xml";
            m_LastModelFilename = "";
            m_loadlastmodel = true;
            m_autoconnect = false;
            m_foregroundcolor = Color.White;
            m_backgroundcolor = Color.Black;
           // m_drivertype = eDriverType.eNULL_DRIVER;
        }

        public bool Load(String filename) 
        {
            try
            {
                XmlHelper xh = new XmlHelper();
                bool fileExist = xh.Start(filename, "ApplicationConfig");
                XmlNode ac = xh.m_toplevel;
                m_LastModelFilename = xh.GetString(ac, "LastModelName","");
                m_cursliceprofilename = UVDLPApp.Instance().m_PathProfiles + UVDLPApp.m_pathsep + xh.GetString(ac, "SliceProfileName", "default.slicing");
                m_curmachineeprofilename = UVDLPApp.Instance().m_PathMachines + UVDLPApp.m_pathsep + xh.GetString(ac, "MachineProfileName", "NullMachine.machine");
                m_autoconnect = xh.GetBool(ac, "AutoConnect", false);
                m_loadlastmodel = xh.GetBool(ac, "LoadLastModel", true);
                m_slic3rloc = xh.GetString(ac, "Slic3rLocation", "");
                m_foregroundcolor =  xh.GetColor(ac, "ForegroundColor", Color.White);
                m_backgroundcolor = xh.GetColor(ac, "BackgroundColor", Color.Black);
                if (!fileExist)
                {
                    xh.Save(FILE_VERSION);
                }
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
        public bool Save(String filename) 
        {
            try
            {
                XmlHelper xh = new XmlHelper();
                bool fileExist = xh.Start(filename, "ApplicationConfig");
                XmlNode ac = xh.m_toplevel;
                xh.SetParameter(ac, "LastModelName", m_LastModelFilename);
                xh.SetParameter(ac, "SliceProfileName", Path.GetFileName(m_cursliceprofilename));
                xh.SetParameter(ac, "MachineProfileName", Path.GetFileName(m_curmachineeprofilename));
                xh.SetParameter(ac, "AutoConnect", m_autoconnect ? "True" : "False");
                xh.SetParameter(ac, "LoadLastModel", m_loadlastmodel ? "True" : "False");
                xh.SetParameter(ac, "Slic3rLocation", m_slic3rloc);
                xh.SetParameter(ac, "ForegroundColor", m_foregroundcolor);
                xh.SetParameter(ac, "BackgroundColor", m_backgroundcolor);
                xh.Save(FILE_VERSION);
                return true;
            }catch(Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false; 
            }
            
        }
        public String LastModelFilename 
        {
            get { return m_LastModelFilename; }
            set { m_LastModelFilename = value; }
        }

        public AppConfig() 
        {
            //CreateDefault();
        }
    }
}
