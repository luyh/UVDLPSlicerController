using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer
{
    /// <summary>
    /// This class keeps track of the multiple frmDLP's used in a multi-monitor setup and display
    /// </summary>
    public class DisplayManager
    {
        private static DisplayManager m_instance = null;
        private List<frmDLP> m_displays;
        // this should listen for a machine configuration change event
        // so it can automatically set up for the correct screens
        public static DisplayManager Instance() 
        {
            if (m_instance == null) 
            {
                m_instance = new DisplayManager();
            }
            return m_instance;
        }

        private DisplayManager() 
        {            
            m_displays = new List<frmDLP>();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEv);
        }

        private void GenerateForms() 
        {
            if (m_displays != null) 
            {
                //close all previous forms and get rid of them
                foreach (frmDLP frm in m_displays) 
                {
                    frm.Hide();
                    frm.Dispose();
                    //frm = null;
                }
                m_displays.Clear();
            }
            foreach (MonitorConfig mc in UVDLPApp.Instance().m_printerinfo.m_lstMonitorconfigs) 
            {
                frmDLP frm = new frmDLP();
                frm.Setup(mc.Monitorid, mc.m_monitorrect);
                m_displays.Add(frm);
            }

        }
        public void AppEv(eAppEvent ev, string s) 
        {
            switch (ev)
            {
                case eAppEvent.eMachineConfigChanged:
                    //regenerate all frmDLP's from the configuration monitor settings
                    GenerateForms();
                    break;
            }
        }
        /// <summary>
        /// Based on the current machine configuration profile,
        /// return the number of configured screens
        /// </summary>
        /// <returns></returns>
        public int GetNumberofActiveScreens() 
        {
            try
            {
                return UVDLPApp.Instance().m_printerinfo.m_lstMonitorconfigs.Count;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
            return 0;
        }
        /// <summary>
        /// shows all dlp as blank
        /// </summary>
        public void showBlankDLPs() 
        {
            ShowDLPScreens();
            UVDLPApp.Instance().m_buildmgr.ShowBlank(UVDLPApp.Instance().m_buildparms.xres, UVDLPApp.Instance().m_buildparms.yres);

        }
        public bool ShowDLPScreens() 
        {
            bool ret = true;
            foreach (frmDLP frm in m_displays) 
            {
                if (!frm.ShowDLPScreen()) 
                {
                    ret = false;
                }
            }
            return ret;
        }
        public void HideDLPScreens() 
        {
            foreach (frmDLP frm in m_displays)
            {
                frm.HideDLPScreen();
            }        
        }
        /// <summary>
        /// This function will iterate through all monitor configurations,
        /// and attempt to open the serial control ports for each monitor.
        /// This function can be called multiple times to keep trying to open ports
        /// </summary>
        public void ConnectMonitorSerials() 
        {
        
        }
        /// <summary>
        /// This closes the serial control ports for all monitors.
        /// </summary>
        public void DisconnectAllMonitorSerial() 
        {
        
        }
    }
}
