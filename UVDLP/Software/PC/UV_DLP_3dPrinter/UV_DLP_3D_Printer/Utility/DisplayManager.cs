using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public DisplayManager Instance() 
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
        public void ShowDLPScreens() 
        {
        
        }
        public void HideDLPScreens() 
        {
        
        }
    }
}
