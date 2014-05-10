using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;
using System.IO;
using UV_DLP_3D_Printer.Slicing;
using UV_DLP_3D_Printer._3DEngine;
using UV_DLP_3D_Printer.Device_Interface;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmMain2 : Form
    {
        private enum eViewTypes
        {
            eV3d,
            eVSlice,
            eVControl,
            eVConfig,
            eNone
        }
        private eViewTypes m_viewtype;
        public event delBuildStatus BuildStatusInvoked; // rund the build delegate in Form thread
        public string m_appname = "Creation Workshop";
        //frmDLP m_frmdlp = new frmDLP();
        frmSlice m_frmSlice = new frmSlice();
        public ManualControl m_manctl;
        int rightToolsWidth = 0;

        public frmMain2()
        {
            InitializeComponent();
            m_viewtype = eViewTypes.eNone;
            UVDLPApp.Instance().m_mainform = this;
            m_manctl = ManualControl.Instance(); // late intialization happens here after the UVDLP app Singleton is initiated.

            ctlTitle3dView.Checked = true; // set it as checked
            ctlTitle3dView_Click(null, null); // and click the button

            RegisterCallbacks();
            RegisterGUI();
            SetButtonStatuses();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            DebugLogger.Instance().LoggerStatusEvent += new LoggerStatusHandler(LoggerStatusEvent);
            UVDLPApp.Instance().m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            UVDLPApp.Instance().m_buildmgr.BuildStatus += new delBuildStatus(BuildStatus);
            UVDLPApp.Instance().m_deviceinterface.StatusEvent += new DeviceInterface.DeviceInterfaceStatus(DeviceStatusEvent);
            UVDLPApp.Instance().m_buildmgr.PrintLayer += new delPrinterLayer(PrintLayer);
            UVDLPApp.Instance().Engine3D.UpdateGrid();
            ctl3DView1.UpdateView(); // initial update
            // set up initial log data in form
            foreach (string lg in DebugLogger.Instance().GetLog())
            {
                txtLog.Text = lg + "\r\n" + txtLog.Text;
            }
            //RearrangeGui
            AddButtons();
            AddControls();
            ctl3DView1.RearrangeGui();
            ctl3DView1.Enable3dView(true);
            UVDLPApp.Instance().m_gui_config.LoadConfiguration(global::UV_DLP_3D_Printer.Properties.Resources.GuiConfig);

            //ctlSliceGCodePanel1.ctlSliceViewctl.DlpForm = m_frmdlp; // set the dlp form for direct control
            SetMainMessage("");
            SetTimeMessage("");
            #if (DEBUG)
                ShowLogPanel(true);
            #else
                ShowLogPanel(false);
                pluginTesterToolStripMenuItem.Visible = false;
                testToolStripMenuItem.Visible = false;
                testMachineControlToolStripMenuItem.Visible = false;
            #endif
            SetTitle();
            UVDLPApp.Instance().PerformPluginCommand("MainFormLoadedCommand", true);
        }
        /// <summary>
        /// This adds buttons to the GUI config for later skinning
        /// </summary>
        private void AddButtons() 
        {
            UVDLPApp.Instance().m_gui_config.AddButton("openfile", buttOpenFile);
            UVDLPApp.Instance().m_gui_config.AddButton("play", buttPlay);
            UVDLPApp.Instance().m_gui_config.AddButton("pause", buttPause);
            UVDLPApp.Instance().m_gui_config.AddButton("stop", buttStop);
            UVDLPApp.Instance().m_gui_config.AddButton("connect", buttConnect);
            UVDLPApp.Instance().m_gui_config.AddButton("disconnect", buttDisconnect);
            UVDLPApp.Instance().m_gui_config.AddButton("buttExpandLeft", buttExpandLeft);
            
        }
        private void AddControls() 
        {
            // the main title buttons
            
            UVDLPApp.Instance().m_gui_config.AddControl("ctlTitle3dView", ctlTitle3dView);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlTitleViewSlice", ctlTitleViewSlice);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlTitleViewControls", ctlTitleViewControls);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlTitleConfigure", ctlTitleConfigure);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlSliceGCodePanel1", ctlSliceGCodePanel1);

            UVDLPApp.Instance().m_gui_config.AddControl("ctlMainConfig1", ctlMainConfig1);
            
            //left side controls
            UVDLPApp.Instance().m_gui_config.AddControl("ctlSupports1", ctlSupports1);
            //right side controls
            UVDLPApp.Instance().m_gui_config.AddControl("ctlScene1", ctlScene1);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlMoveExpand1", ctlMoveExpand1);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlScale1", ctlScale1);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlRotate1", ctlRotate1);
            //UVDLPApp.Instance().m_gui_config.AddControl("ctlMirror1", ctlMirror1);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlView1", ctlView1);
            UVDLPApp.Instance().m_gui_config.AddControl("ctlObjectInfo1", ctlObjectInfo1);

            // panels on the main form
            UVDLPApp.Instance().m_gui_config.AddControl("pnlTopIcons", pnlTopIcons);
            UVDLPApp.Instance().m_gui_config.AddControl("pnlTopTabs", pnlTopTabs);
            UVDLPApp.Instance().m_gui_config.AddControl("pnlTopIconsMain", pnlTopIconsMain);

            UVDLPApp.Instance().m_gui_config.AddControl("pnlRightBar", flowLayoutPanel1);
            UVDLPApp.Instance().m_gui_config.AddControl("pnlLeftBar", flowLayoutPanel2);

            //
            UVDLPApp.Instance().m_gui_config.AddControl("mainmsg", lblMainMessage);
            UVDLPApp.Instance().m_gui_config.AddControl("timemsg", lblTime);


        }
        /// <summary>
        /// Need to implement this at mainform level too
        /// </summary>
        /// <param name="ct"></param>
        public void ApplyStyle(ControlStyle ct)
        {
            /*
            if(ct.BackColor !=null)
            {
                pnlTopIcons.BackColor = ct.BackColor;
                pnlTopTabs.BackColor = ct.BackColor;
            }
            */
            /*
            mStyle = ct;
            mStyleName = ct.Name;
            ApplyStyleRecurse(this, ct);
            if (ct.BackColor != ControlStyle.NullColor)
                bgndPanel.col = ct.BackColor;
            if (ct.BgndImageName != null)
                bgndPanel.imageName = ct.BgndImageName;
             * */
        }


        private void SetTimeMessage(String message)
        {
            lblTime.Text = message;
            //ctl3DView1.TimeMessage = message;
        }
        private void SetMainMessage(String message)
        {
            try
            {
                lblMainMessage.Text = message;
                //ctl3DView1.MainMessage = message;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.StackTrace);
            }
        }

        #region DLP Screen Controls


        private void showCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make sure all the dlp screens are showing
            DisplayManager.Instance().ShowDLPScreens();
            UVDLPApp.Instance().m_buildparms.UpdateFrom(UVDLPApp.Instance().m_printerinfo); // make sure we get the right screen size 

            /*
            //UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay = true;
            m_frmdlp.ShowDLPScreen();
            Screen dlpscreen = m_frmdlp.GetDLPScreen();
            if (dlpscreen != null)
            {
                UVDLPApp.Instance().m_buildmgr.ShowCalibration(dlpscreen.Bounds.Width, dlpscreen.Bounds.Height, UVDLPApp.Instance().m_buildparms);
            }
             * */
            UVDLPApp.Instance().m_buildmgr.ShowCalibration(UVDLPApp.Instance().m_buildparms.xres, UVDLPApp.Instance().m_buildparms.yres, UVDLPApp.Instance().m_buildparms);
        }

        #endregion DLP screen controls

        #region Delegate Event Handlers
        private void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers, SliceFile sf)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { SliceEv(ev, layer, totallayers, sf); }));
                }
                else
                {
                    switch (ev)
                    {
                        case Slicer.eSliceEvent.eSliceStarted:
                            SetMainMessage("Slicing Started");
                            break;
                        case Slicer.eSliceEvent.eLayerSliced:
                            break;
                        case Slicer.eSliceEvent.eSliceCompleted:
                            //ctl3DView1.SetNumLayers(totallayers);
                            SetMainMessage("Slicing Completed");
                            String timeest = BuildManager.EstimateBuildTime(UVDLPApp.Instance().m_gcode);
                            SetTimeMessage("Estimated Build Time: " + timeest);
                            //show the slice in the slice view
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
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
                    ctl3DView1.ViewLayer(layer); // set the 3d layer
                    // display info only if it's a normal layer
                    if (layertype == BuildManager.SLICE_NORMAL)
                    {

                        String txt = "Printing layer " + (layer + 1) + " of " + UVDLPApp.Instance().m_slicefile.NumSlices;
                        DebugLogger.Instance().LogRecord(txt);
                    }

                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                DebugLogger.Instance().LogError(ex.StackTrace);
            }
        }


        /*
         This function is called when the device status changes
         * most of this is for display purposes only,
         * the real business logic should be held in the app class
         */
        void DeviceStatusEvent(ePIStatus status, String Command)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { DeviceStatusEvent(status, Command); }));
            }
            else
            {
                switch (status)
                {
                    case ePIStatus.eConnected:
                        SetButtonStatuses();
                        DebugLogger.Instance().LogRecord("Device Connected");
                        break;
                    case ePIStatus.eDisconnected:
                        SetButtonStatuses();
                        DebugLogger.Instance().LogRecord("Device Disconnected");
                        break;
                    case ePIStatus.eError:
                        break;
                    //case ePIStatus.eReady:
                    //   break;
                }
            }
        }

        void BuildStatus(eBuildStatus printstat, string mess, int data)
        {
            // displays the print status
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { BuildStatus(printstat, mess, data); }));
            }
            else
            {
                if (BuildStatusInvoked != null)
                    BuildStatusInvoked(printstat, mess, data);
                String message = "";
                switch (printstat)
                {
                    case eBuildStatus.eBuildPaused:
                        message = "Print Paused";
                        SetButtonStatuses();
                        SetMainMessage(message);
                        DebugLogger.Instance().LogRecord(message);

                        break;
                    case eBuildStatus.eBuildResumed:
                        message = "Print Resumed";
                        SetButtonStatuses();
                        SetMainMessage(message);
                        DebugLogger.Instance().LogRecord(message);

                        break;
                    case eBuildStatus.eBuildCancelled:
                        message = "Print Cancelled";
                        SetButtonStatuses();
                        SetMainMessage(message);
                        DebugLogger.Instance().LogRecord(message);

                        break;
                    case eBuildStatus.eLayerCompleted:
                        message = "Layer Completed";
                        break;
                    case eBuildStatus.eBuildCompleted:
                        try
                        {
                            message = "Print Completed";
                            SetButtonStatuses();
                            //MessageBox.Show("Build Completed");
                            SetMainMessage(message);
                            DebugLogger.Instance().LogRecord(message);
                        }
                        catch (Exception ex)
                        {
                            DebugLogger.Instance().LogError(ex.Message);
                        }
                        break;
                    case eBuildStatus.eBuildStarted:
                        message = "Print Started";
                        SetButtonStatuses();
                        // if the current machine type is a UVDLP printer, make sure we can show the screen
                        if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
                        {
                            if (!DisplayManager.Instance().ShowDLPScreens())
                            {
                                MessageBox.Show("Monitor not found, cancelling build", "Error");
                                UVDLPApp.Instance().m_buildmgr.CancelPrint();
                            }
                        }
                        SetMainMessage(message);
                        DebugLogger.Instance().LogRecord(message);
                        break;
                    case eBuildStatus.eBuildStatusUpdate:
                        // a message from the build manager has arrived
                        this.SetTimeMessage(mess);
                        break;
                }
            }
        }
        void LoggerStatusEvent(Logger o, eLogStatus status, string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { LoggerStatusEvent(o, status, message); }));
            }
            else
            {
                switch (status)
                {
                    case eLogStatus.eLogWroteRecord:
                        txtLog.Text = message + "\r\n" + txtLog.Text;
                        break;
                }
            }
        }
        /*
          This handles specific events triggered by the app
          */
        private void AppEventDel(eAppEvent ev, String Message)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { AppEventDel(ev, Message); }));
                }
                else
                {
                    switch (ev)
                    {
                        case eAppEvent.eModelNotLoaded:
                            DebugLogger.Instance().LogRecord(Message);
                            break;

                        case eAppEvent.eModelRemoved:
                            //the current model was removed
                            DebugLogger.Instance().LogRecord(Message);
                            //UpdateSceneInfo();
                            UVDLPApp.Instance().m_engine3d.UpdateLists();
                            ctl3DView1.UpdateView();
                            break;
                        case eAppEvent.eModelAdded:
                            //UpdateSceneInfo();
                            UVDLPApp.Instance().m_engine3d.UpdateLists();
                            //DisplayFunc();
                            ctl3DView1.UpdateView();
                            DebugLogger.Instance().LogRecord(Message);
                            break;
                        case eAppEvent.eUpdateSelectedObject:
                            UpdateSceneInfo();
                            //ctl3DView1.UpdateView();
                            break;
                        case eAppEvent.eShowLogWindow:
                            bool vis = bool.Parse(Message);
                            ShowLogPanel(vis);
                            break;
                        case eAppEvent.eReDraw: // redraw the 3d display
                            //DisplayFunc();
                            ctl3DView1.UpdateView();
                            break;
                        case eAppEvent.eReDraw2D: // redraw the 2d layer of the 3d display
                            ctl3DView1.UpdateView(false);
                            break;
                        case eAppEvent.eShowBlank:
                            //showBlankDLP();
                            DisplayManager.Instance().showBlankDLPs();
                            break;
                        case eAppEvent.eShowCalib:
                            showCalibrationToolStripMenuItem_Click(null, null);
                            break;
                        case eAppEvent.eShowDLP:
                            DisplayManager.Instance().ShowDLPScreens();
                            break;
                        case eAppEvent.eHideDLP:
                            DisplayManager.Instance().HideDLPScreens();
                            break;
                        case eAppEvent.eMachineConnected:
                            DisplayManager.Instance().showBlankDLPs();
                            break;
                        case eAppEvent.eMachineDisconnected:
                            break;
                        
                  case eAppEvent.eSlicedLoaded: // update the gui to view
                      DebugLogger.Instance().LogRecord(Message);
                      int totallayers = UVDLPApp.Instance().m_slicefile.NumSlices;
                      ctl3DView1.SetNumLayers(totallayers);                      
                      break;
                  case eAppEvent.eSliceProfileChanged:
                      SetTitle();
                      break;
                  case eAppEvent.eMachineTypeChanged:
                      // FIXFIX : activate SetupForMachineType on 3dview control
                      SetupForMachineType();
                      SetTitle();
                      break;
                        /*
              case eAppEvent.eGCodeLoaded:
                  DebugLogger.Instance().LogRecord(Message);
                  m_frmGCode.GcodeView.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                  break;
              case eAppEvent.eGCodeSaved:
                  DebugLogger.Instance().LogRecord(Message);
                  break;



                   * */
                    }
                    //Refresh();
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }

        }
        #endregion

        private void SetupForMachineType()
        {
            MachineConfig mc = UVDLPApp.Instance().m_printerinfo;            
            ctl3DView1.m_camera.UpdateBuildVolume((float)mc.m_PlatXSize, (float)mc.m_PlatYSize, (float)mc.m_PlatZSize);
        }

        public void SetTitle()
        {
            
            this.Text = m_appname + " - " + "  ( Slice Profile : ";
            this.Text += Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_buildparms.m_filename);
            this.Text += ", Machine : " + Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_printerinfo.m_filename) + ")";
             
        }
        private void UpdateSceneInfo()
        {
            try
            {
                //ctl3DView1.UpdateObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
                ctl3DView1.UpdateView();
            }
            catch (Exception) { }

        }
        private void RegisterGUI() 
        {
            UVDLPApp.Instance().m_gui_config.AddButton("play", buttPlay);
            UVDLPApp.Instance().m_gui_config.AddButton("pause", buttPause);
            UVDLPApp.Instance().m_gui_config.AddButton("stop", buttStop);
            UVDLPApp.Instance().m_gui_config.AddButton("connect", buttConnect);
            UVDLPApp.Instance().m_gui_config.AddButton("disconnect", buttDisconnect);
            UVDLPApp.Instance().m_gui_config.AddButton("openfile", buttOpenFile);
            UVDLPApp.Instance().m_gui_config.AddButton("slice", buttSlice);
//            UVDLPApp.Instance().m_gui_config.AddButton("stop", buttStop);

        }
        private void RegisterCallbacks() 
        {
            // the main tab buttons
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickView3d", ctlTitle3dView_Click, null, "View 3d display");
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickSliceView", ctlTitleViewSlice_Click, null, "View Slice display");
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickManualCtlView", ClickManualCtlView_Click, null, "View Manual Machine Control");
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickMainConfigView", ClickMainConfigView_Click, null, "View Main Configuration");
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickExpandLeft", ClickExpandLeft_Click, null, "Expand / retract left panel");

            
            //load model click
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("LoadSTLModel_Click", LoadSTLModel_Click, null, "Load Model");

            // Connecting / disconnecting printer
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ConnectPrinter", cmdConnect1_Click, null, "Connect to the printer");
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("DisconnectPrinter", cmdDisconnect_Click, null, "Disconnect from the printer");

            //start/stop/pause printing
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("StartPrint", cmdStartPrint_Click, null, "Begin printing scene");
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("PausePrint", cmdPause_Click_1, null, "Pause printing");
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("StopPrint", cmdStop_Click, null, "Stop printing process");

            //Slicing

            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("StartSlice", cmdSlice1_Click, null, "Start Slicing");

            //ctlMainManual1
        }

        private void HideAllViews() 
        {

            pnl3dview.Visible = false;
            pnl3dview.Dock = DockStyle.None;

            pnlSliceView.Visible = false;
            pnlSliceView.Dock = DockStyle.None;

            ctlMainManual1.Visible = false;
            ctlMainManual1.Dock = DockStyle.None;

            ctlMainConfig1.Visible = false;
            ctlMainConfig1.Dock = DockStyle.None;
            
        }

        /// <summary>
        /// This function unchecks all the main tabs (except for the one specified)
        /// </summary>
        private void UncheckTabs(ctlTitle seltitle)         
        {
            if (ctlTitle3dView != seltitle) ctlTitle3dView.Checked = false;
            if (ctlTitleViewSlice != seltitle) ctlTitleViewSlice.Checked = false;
            if (ctlTitleViewControls != seltitle) ctlTitleViewControls.Checked = false;
            if (ctlTitleConfigure != seltitle) ctlTitleConfigure.Checked = false;
            seltitle.Checked = true;
        
        }
        private void ShowView(eViewTypes vt) 
        {
            try
            {
                if (vt == m_viewtype) return; // already there
                m_viewtype = vt;
                HideAllViews();
                switch (m_viewtype)
                {
                    case eViewTypes.eV3d:
                        pnl3dview.Visible = true;
                        pnl3dview.Dock = DockStyle.Fill;
                        
                        break;
                    
                    case eViewTypes.eVConfig:
                        ctlMainConfig1.Visible = true;
                        ctlMainConfig1.Dock = DockStyle.Fill;
                        
                        break;
                    case eViewTypes.eVControl:
                        ctlMainManual1.Visible = true;
                        ctlMainManual1.Dock = DockStyle.Fill;
                        
                        break;
                    case eViewTypes.eVSlice:
                        pnlSliceView.Visible = true;
                        pnlSliceView.Dock = DockStyle.Fill;
                        
                        break;
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
        #region button statuses
        private void SetButtonStatuses()
        {
            try
            {
                if (UVDLPApp.Instance().m_deviceinterface.Connected)
                {
                    buttConnect.Enabled = false;
                    buttDisconnect.Enabled = true;

                    if (UVDLPApp.Instance().m_buildmgr.IsPrinting)
                    {
                        if (UVDLPApp.Instance().m_buildmgr.IsPaused())
                        {
                            buttPlay.Enabled = true;
                            buttStop.Enabled = true;
                            buttPause.Enabled = false;
                        }
                        else
                        {
                            buttPlay.Enabled = false;
                            buttStop.Enabled = true;
                            buttPause.Enabled = true;
                        }
                    }
                    else
                    {
                        buttPlay.Enabled = true;
                        buttStop.Enabled = false;
                        buttPause.Enabled = false;
                    }
                }
                else
                {
                    buttConnect.Enabled = true;
                    buttDisconnect.Enabled = false;
                    buttPlay.Enabled = false;
                    buttStop.Enabled = false;
                    buttPause.Enabled = false;
                }
               // ctl3DView1.SetButtonStatus(buttConnect.Enabled, buttDisconnect.Enabled, buttPlay.Enabled, buttStop.Enabled, buttPause.Enabled);
                Refresh();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.StackTrace);
            }
        }
        #endregion


        #region Machine Connect / Disconnect
        public void cmdConnect1_Click(object sender, object e)
        {
            try
            {
                if (!UVDLPApp.Instance().m_deviceinterface.Connected) // 
                {
                    // configure the main device interface
                    UVDLPApp.Instance().m_deviceinterface.Configure(UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection);
                    //get the name of the main serial interface
                    String com = UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.comname;
                    DebugLogger.Instance().LogRecord("Connecting to Printer on " + com + " using " + UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_drivertype.ToString());
                    if (!UVDLPApp.Instance().m_deviceinterface.Connect())
                    {
                        DebugLogger.Instance().LogRecord("Cannot connect printer driver on " + com);
                    }
                    else
                    {                        
                        UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eMachineConnected, "Printer connected");
                    }
                    // check to see if we're uv dlp
                    // configure the projector
                    if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
                    {
                        DisplayManager.Instance().ConnectMonitorSerials();
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        public void cmdDisconnect_Click(object sender, object e)
        {
            if (UVDLPApp.Instance().m_deviceinterface.Connected) // disconnect
            {
                DebugLogger.Instance().LogRecord("Disconnecting from Printer");
                UVDLPApp.Instance().m_deviceinterface.Disconnect();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eMachineDisconnected, "Printer connection closed");
            }
            //terminate connections to projector Drivers
            DisplayManager.Instance().DisconnectAllMonitorSerial();
        }
        #endregion

        #region click handlers

        
        public void cmdSlice1_Click(object sender, object e)
        {
            if (m_frmSlice.IsDisposed)
            {
                m_frmSlice = new frmSlice();
            }
            m_frmSlice.Show();
        } 
        private void hardwareGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String hardwareGuide = UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + "HardwareGuide.pdf";
                System.Diagnostics.Process.Start(hardwareGuide);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
        private void plugInsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPluginManager pim = new frmPluginManager();
            pim.ShowDialog();

        }
        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String usermanualpath = UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + "UserManual.pdf";
                System.Diagnostics.Process.Start(usermanualpath);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }
        /*
        private void saveSceneSTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //save the scene object
                    UVDLPApp.Instance().CalcScene();
                    UVDLPApp.Instance().Scene.SaveSTL_Binary(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        */
        public void ShowLogPanel(bool visible)
        {
            splitContainer1.Panel2Collapsed = !visible;
        }


        private void pluginTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPluginTester pit = new frmPluginTester();
            pit.Show();

        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_callbackhandler.DumpCommands("CWCommands.txt");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrefs prefs = new frmPrefs();
            prefs.ShowDialog();

        }
        public void cmdStop_Click(object sender, object e)
        {
            UVDLPApp.Instance().m_buildmgr.CancelPrint();
        }

        public void cmdPause_Click_1(object sender, object e)
        {
            UVDLPApp.Instance().m_buildmgr.PausePrint();
        }

        public void cmdStartPrint_Click(object sender, object e)
        {
            if (UVDLPApp.Instance().m_buildmgr.IsPaused())
            {
                UVDLPApp.Instance().m_buildmgr.ResumePrint();
            }
            else
            {
                //check the machine type here
                if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
                {
                    //check to see if there is a slice file
                    if (UVDLPApp.Instance().m_slicefile == null)
                    {
                        MessageBox.Show("No Slicing file, cannot begin build");
                        return;
                    }
                    // check for gcode
                    if (UVDLPApp.Instance().m_gcode == null)
                    {
                        MessageBox.Show("No GCode file, cannot begin build");
                        return;
                    }
                    /* remove non-uvdlp gcode check for now - dean piper special..
                    // not a UV DLP GCode file
                    if (UVDLPApp.Instance().m_gcode.IsUVDLPGCode() == false)
                    {
                        MessageBox.Show("Not a UV DLP GCode file\r\nCannot begin build\r\nPossibly wrong slicer used");
                        return;
                    }
                     */ 
                    UVDLPApp.Instance().m_buildmgr.StartPrint(UVDLPApp.Instance().m_slicefile, UVDLPApp.Instance().m_gcode);

                }
                else  // assume FDM or similar
                {
                    if (UVDLPApp.Instance().m_gcode == null)
                    {
                        MessageBox.Show("No GCode file, cannot begin build");
                        return;
                    }
                    //  a UV DLP GCode file is being used for some reason
                    if (UVDLPApp.Instance().m_gcode.IsUVDLPGCode() == true)
                    {
                        MessageBox.Show("UV DLP GCode file commands detected\r\nCannot begin build\r\nPossibly wrong slicer used");
                        return;
                    }
                    UVDLPApp.Instance().m_buildmgr.StartPrint(null, UVDLPApp.Instance().m_gcode);
                }

            }
        }
        public void LoadSTLModel_Click(object sender, object e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "3D Model Files (*.stl;*.obj;*.3ds;*.amf)|*.stl;*.obj;*.3ds;*.amf|Scene files (*.zip)|*.zip";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in openFileDialog1.FileNames)
                {
                    if (filename.Contains(".zip"))
                    {
                        //scene file
                        if (Scene.Instance().Load(filename))
                        {
                            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
                        }
                        else
                        {
                            DebugLogger.Instance().LogError("Error loading scene file : " + filename);
                        }
                    }
                    else
                    {
                        if (UVDLPApp.Instance().LoadModel(filename) == false)
                        {
                            DebugLogger.Instance().LogError("Error loading object file : " + filename);
                        }
                        else
                        {
                            //chkWireframe.Checked = false;
                            //ctl3DView1.UpdateObjectInfo();
                        }
                    }
                }
            }
        }
        private void ClickExpandLeft_Click(object sender, object vars)
        {
            if (buttExpandLeft.Checked)
            {
                //expand
                flowLayoutPanel2.Width = 381;
                ctlSupports1.Visible = true;
            }
            else 
            {
                //retract
                flowLayoutPanel2.Width = 50;
                ctlSupports1.Visible = false;
            }
        }

        private void ClickMainConfigView_Click(object sender, object e)
        {
            UncheckTabs(ctlTitleConfigure);
            ShowView(eViewTypes.eVConfig);
        }

        private void ClickManualCtlView_Click(object sender, object e)
        {
            
            UncheckTabs(ctlTitleViewControls);

            ShowView(eViewTypes.eVControl);
        }
        private void ctlTitle3dView_Click(object sender, object e)
        {
            
            UncheckTabs(ctlTitle3dView);

            ShowView(eViewTypes.eV3d);
        }
        private void ctlTitleViewSlice_Click(object sender, object e)
        {
            
            UncheckTabs(ctlTitleViewSlice);

            ShowView(eViewTypes.eVSlice);
        }
        #endregion

        private void testMachineControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTest();
            frm.ShowDialog();
        }

        private void testSaveSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                Scene.Instance().Save(saveFileDialog1.FileName);                
            }
        }

        private void testLoadSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Scene.Instance().Load(openFileDialog1.FileName)) 
                {
                    UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
                }
            }
        }

        private void flowLayoutPanel1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (rightToolsWidth == 0)
                rightToolsWidth = flowLayoutPanel1.Width;
            int newwidth = rightToolsWidth;
            if (flowLayoutPanel1.VerticalScroll.Visible)
                newwidth = rightToolsWidth + flowLayoutPanel1.Width - flowLayoutPanel1.ClientSize.Width;
            if (flowLayoutPanel1.Width != newwidth)
                flowLayoutPanel1.Width = newwidth;
        }
    }
}
