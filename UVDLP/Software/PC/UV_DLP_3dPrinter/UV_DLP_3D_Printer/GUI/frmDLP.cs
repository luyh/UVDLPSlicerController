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
        Screen m_dlpscreen = null;
        Timer m_tmr;

        public frmDLP()
        {
            InitializeComponent();
            m_tmr = new Timer();
            m_tmr.Interval = 1000;
            m_tmr.Tick += new EventHandler(m_tmr_Tick);
            m_tmr.Start();
        }

        void m_tmr_Tick(object sender, EventArgs e)
        {
            if (Visible == false)
                return;
            Screen oldscr = m_dlpscreen;
            m_dlpscreen = GetDLPScreen(false);
            if (m_dlpscreen != oldscr)
                ShowDLPScreen(false);
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
        public Screen GetDLPScreen(bool reportError)
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
            if ((dlpscreen == null) && reportError)
            {
                //dlpscreen = Screen.AllScreens[0]; // default to the first if we can't find it
                DebugLogger.Instance().LogRecord("Can't find screen " + UVDLPApp.Instance().m_printerinfo.m_monitorconfig.Monitorid);
            }
            return dlpscreen;
        }

        public Screen GetDLPScreen()
        {
            return GetDLPScreen(true);
        }

        public bool ShowDLPScreen()
        {
            return ShowDLPScreen(true);
        }

        protected bool ShowDLPScreen(bool rescan)
        {
            try
            {
                if (rescan)
                    m_dlpscreen = GetDLPScreen();
                Show();
                if (m_dlpscreen == null)
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    if (picDLP.Image != null)
                        SetDesktopBounds(0, 0, picDLP.Image.Width / 2, picDLP.Image.Height / 2);
                    else
                        SetDesktopBounds(0, 0, 512, 384);
                }
                else
                {
                    SetDesktopBounds(m_dlpscreen.Bounds.X, m_dlpscreen.Bounds.Y, m_dlpscreen.Bounds.Width, m_dlpscreen.Bounds.Height);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

    }
}
