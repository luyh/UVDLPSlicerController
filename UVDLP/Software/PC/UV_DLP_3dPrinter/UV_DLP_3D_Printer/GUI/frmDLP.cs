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
     * It listens to the build manager events to show images on the screen.
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
            UVDLPApp.Instance().m_buildmgr.PrintLayer += new delPrinterLayer(PrintLayer);
        }
        //This delegate is called when the print manager is printing a new layer
        void PrintLayer(Bitmap bmp, int layer, int layertype)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { PrintLayer(bmp, layer, layertype); }));
                }
                else
                {
                    ViewLayer(layer, bmp, layertype);
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                DebugLogger.Instance().LogError(ex.StackTrace);
            }
        }
        private void ViewLayer(int layer, Bitmap image, int layertype)
        {
            try
            {
                Bitmap bmp = null;
                if (image == null) // we're here because of the scroll bar in the gui
                {
                    DebugLogger.Instance().LogError("Null BM in DLP form");
                    return;
                }
                else // the image was specified from the build manager
                {
                    bmp = image;
                }
                // if we're a UV DLP printer, show on the frmDLP
                if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
                {
                    // only show the image on the dlp if we're previewing
                    //need to make sure we show the layer if building
                    if (UVDLPApp.Instance().m_buildmgr.IsPrinting == true || UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay == true
                        || layertype == BuildManager.SLICE_BLANK || layertype == BuildManager.SLICE_CALIBRATION)
                    {
                        ShowImage(bmp);
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.StackTrace);
            }

        }

        void m_tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Visible == false)
                    return;
                Screen oldscr = m_dlpscreen;
                m_dlpscreen = GetDLPScreen(false);
                if (m_dlpscreen != oldscr)
                    ShowDLPScreen(false);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }


        /*
         Shows the specified image on the picture control
         */
        public void ShowImage(Image i) 
        {
            try
            {
                picDLP.Image = i;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
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
                    WindowState = FormWindowState.Normal;
                    SetDesktopBounds(m_dlpscreen.Bounds.X, m_dlpscreen.Bounds.Y, m_dlpscreen.Bounds.Width, m_dlpscreen.Bounds.Height);
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    if (m_dlpscreen == Screen.PrimaryScreen)
                    {
                        BringToFront();
                        Focus();
                    }
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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((e.KeyCode == Keys.Escape) && (m_dlpscreen == Screen.PrimaryScreen) 
                && (WindowState == FormWindowState.Maximized))
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == 0x0112) // WM_SYSCOMMAND
                {
                    if (m.WParam == new IntPtr(0xF030)) // Maximize event - SC_MAXIMIZE from Winuser.h
                    {
                        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    }
                }
                base.WndProc(ref m);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
    }
}
