using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer
{
    /*
     This is the form that is used to display the Image that is sent to the DLP
     * it is sized to match the resolution of the screen that it displays on
     * and it contains 1 image / picture control
     */
    public partial class frmDLP : Form
    {
        public frmDLP()
        {
            InitializeComponent();
        }
        /*
         Shows the specified image on the picture control
         */
        public void ShowImage(Image i) 
        {
            picDLP.Image = i;
        }
 
        private string CleanMonitorString(string str)
        {
            string tmp = str.Replace("\\", string.Empty);
            tmp = tmp.Replace(".", string.Empty);
            tmp = tmp.Trim();
            return tmp;
        }

        /// <summary>
        /// This function will return the Screen specified in the machine configuration file
        /// If the screen cannot be found, it will return null. 
        /// This is a change in behaviour from before
        /// </summary>
        /// <returns></returns>
        public Screen GetDLPScreen()
        {
            Screen dlpscreen = null;
            foreach (Screen s in Screen.AllScreens)
            {
                string mn = CleanMonitorString(s.DeviceName);
                string mid = CleanMonitorString(UVDLPApp.Instance().m_printerinfo.m_monitorconfig.Monitorid);
                if (mn.Contains(mid))
                {
                    dlpscreen = s;
                    break;
                }
            }
            if (dlpscreen == null)
            {
                //dlpscreen = Screen.AllScreens[0]; // default to the first if we can't find it
                DebugLogger.Instance().LogRecord("Can't find screen " + UVDLPApp.Instance().m_printerinfo.m_monitorconfig.Monitorid);
            }
            return dlpscreen;
        }

        public bool ShowDLPScreen()
        {
            try
            {
                Screen dlpscreen = GetDLPScreen();
                Show();
                if (dlpscreen != null)
                {
                    SetDesktopBounds(dlpscreen.Bounds.X, dlpscreen.Bounds.Y, dlpscreen.Bounds.Width, dlpscreen.Bounds.Height);
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }

                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }

        public bool HideDLPScreen()
        {
            Hide();
            return true;
        }

    }
}
