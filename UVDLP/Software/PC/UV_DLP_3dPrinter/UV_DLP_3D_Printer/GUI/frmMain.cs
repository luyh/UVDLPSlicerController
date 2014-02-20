using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine3D;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using System.IO.Ports;
using System.IO;
using System.Collections;
using System.Timers;
using UV_DLP_3D_Printer.GUI;
using UV_DLP_3D_Printer.GUI.Controls;
using UV_DLP_3D_Printer.GUI.CustomGUI;
using UV_DLP_3D_Printer._3DEngine;
using UV_DLP_3D_Printer.Slicing;
using UV_DLP_3D_Printer.Plugin;

using UV_DLP_3D_Printer._3DEngine.CSG;

namespace UV_DLP_3D_Printer
{
    public partial class frmMain : Form
    {
        frmDLP m_frmdlp = new frmDLP();        
        frmSlice m_frmSlice = new frmSlice();
        GLCamera m_camera;
        frmSettings m_frmSettings = new frmSettings();
        frmGCode m_frmGCode = new frmGCode();
        frmSliceView m_frmSliceView = new frmSliceView();

        public frmMain()
        {
            // following 2 lines removed from designer - SHS to eliminate autoscale
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            
            InitializeComponent();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            UVDLPApp.Instance().Engine3D.UpdateGrid();
            //UVDLPApp.Instance().Engine3D.AddPlatCube();
            UVDLPApp.Instance().m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            UVDLPApp.Instance().m_buildmgr.BuildStatus += new delBuildStatus(BuildStatus);
            UVDLPApp.Instance().m_buildmgr.PrintLayer += new delPrinterLayer(PrintLayer);
            DebugLogger.Instance().LoggerStatusEvent += new LoggerStatusHandler(LoggerStatusEvent);
            UVDLPApp.Instance().m_deviceinterface.StatusEvent += new DeviceInterface.DeviceInterfaceStatus(DeviceStatusEvent);
            UVDLPApp.Instance().m_supportgenerator.SupportEvent += new SupportGeneratorEvent(SupEvent);

            ctl3DView1.SetMessagePanelHolder(splitContainerMainWindow);
            ctl3DView1.Enable3dView(true);

            #if (DEBUG)
            ShowLogPanel(true);
            #else
            ShowLogPanel(false);
            findHolesInMeshToolStripMenuItem.Visible = false;
            splashToolStripMenuItem.Visible = false;
            pluginTesterToolStripMenuItem.Visible = false;
            stalactite3DToolStripMenuItem.Visible = false;
            testToolStripMenuItem.Visible = false;
            #endif
            splitContainerTop.Panel1Collapsed = true;

            m_frmdlp.HideDLPScreen();
            m_frmSliceView.SliceView.DlpForm = m_frmdlp;
                        
            //arcball = new ArcBall();
            m_camera = new GLCamera();
            ResetCameraView();

            lblTime.Text = ctl3DView1.TimeMessage = "";
            lblMainMessage.Text = ctl3DView1.MainMessage = "";

            SetButtonStatuses();                        
            //PopulateBuildProfilesMenu();

            RegisterCallbacks();

            UVDLPApp.Instance().PerformPluginCommand("GUILoadedCommand", true);

            Refresh();

        }

        protected void RegisterCallbacks()
        {
            CallbackHandler cb = UVDLPApp.Instance().m_callbackhandler;
            cb.RegisterCallback("ViewSliceWindow", buttViewSlice_Click, null, "Show the slice view window");
            cb.RegisterCallback("LoadModel", LoadSTLModel_Click, null, "Load 3D model from disk");
            cb.RegisterCallback("StartPrint", cmdStartPrint_Click, null, "Begin printing scene");
            cb.RegisterCallback("PausePrint", cmdPause_Click_1, null, "Pause printing");
            cb.RegisterCallback("StopPrint", cmdStop_Click, null, "Stop printing process");
            cb.RegisterCallback("ConnectPrinter", cmdConnect1_Click, null, "Connect to the printer");
            cb.RegisterCallback("DisconnectPrinter", cmdDisconnect_Click, null, "Disconnect from the printer");
            cb.RegisterCallback("SliceDialog", cmdSlice1_Click, null, "Open the slice dialog box");
            cb.RegisterCallback("ConfigDialog", buttConfig_Click, null, "Open the system configuration form");
            cb.RegisterCallback("ViewGCodeWindow", buttViewGcode_Click, null, "Show the GCode window");
            //cb.RegisterCallback("", , null, "");
           
        }

        public void ResetCameraView()
        {
            m_camera.ResetView(0, -200, 0, 20, 20);
        }

        #region Support Event Handler
        /// <summary>
        /// Support Event handler
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="message"></param>
        /// <param name="obj"></param>
        public void SupEvent(SupportEvent ev, string message, Object obj)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { SupEvent(ev, message, obj); }));
            }
            else
            {
                try
                {
                    switch (ev)
                    {
                        case SupportEvent.eCompleted:
                            //ctl3DView1.UpdateSceneTree();
                            break;
                        case SupportEvent.eCancel:
                            break;
                        case SupportEvent.eProgress:
                            break;
                        case SupportEvent.eStarted:
                            break;
                        case SupportEvent.eSupportGenerated:
                            //
                           // SetupSceneTree();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.Instance().LogError(ex.Message);
                }
            }
        }
        #endregion Support event handler

        private void SetTimeMessage(String message) 
        {
            lblTime.Text = message;
            ctl3DView1.TimeMessage = message;
        }
        private void SetMainMessage(String message) 
        {
            try
            {
                lblMainMessage.Text = message;
                ctl3DView1.MainMessage = message;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.StackTrace);
            }
        }
        /*
         This handles specific events triggered by the app
         */
        private void AppEventDel(eAppEvent ev, String Message) 
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
                        UpdateSceneInfo();
                        UVDLPApp.Instance().m_engine3d.UpdateLists();
                        ctl3DView1.UpdateView();
                        //DisplayFunc();
                        break;
                    case eAppEvent.eSlicedLoaded: // update the gui to view
                        DebugLogger.Instance().LogRecord(Message);
                        int totallayers = UVDLPApp.Instance().m_slicefile.NumSlices;
                        ctl3DView1.SetNumLayers(totallayers);
                        m_frmSliceView.SliceView.SetNumLayers(totallayers);
                        //show the slice in the slice view
                        ViewLayer(0, null, BuildManager.SLICE_NORMAL);
                        break;
                    case eAppEvent.eGCodeLoaded:
                        DebugLogger.Instance().LogRecord(Message);
                        m_frmGCode.GcodeView.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                        break;
                    case eAppEvent.eGCodeSaved:
                        DebugLogger.Instance().LogRecord(Message);
                        break;
                    case eAppEvent.eModelAdded:
                        UpdateSceneInfo();
                        UVDLPApp.Instance().m_engine3d.UpdateLists();
                        //DisplayFunc();
                        ctl3DView1.UpdateView();
                        DebugLogger.Instance().LogRecord(Message);
                        break;
                    case eAppEvent.eSliceProfileChanged:
                        SetTitle();
                        break;
                    case eAppEvent.eMachineTypeChanged:
                        // FIXFIX : activate SetupForMachineType on 3dview control
                        SetupForMachineType();
                        SetTitle();
                        break;
                    case eAppEvent.eShowBlank:
                        showBlankDLP();
                        break;
                    case eAppEvent.eShowCalib:
                        showCalibrationToolStripMenuItem_Click(null, null);
                        break;
                    case eAppEvent.eShowDLP:
                        m_frmdlp.ShowDLPScreen();
                        break;
                    case eAppEvent.eHideDLP:
                        m_frmdlp.HideDLPScreen();
                        break;
                    case eAppEvent.eReDraw: // redraw the 3d display
                        //DisplayFunc();
                        ctl3DView1.UpdateView();
                        break;
                    case eAppEvent.eReDraw2D: // redraw the 2d layer of the 3d display
                        ctl3DView1.UpdateView(false);
                        break;
                    case eAppEvent.eUpdateSelectedObject:
                        UpdateSceneInfo();
                        break;
                    case eAppEvent.eMachineConnected:
                        showBlankDLP();
                        break;
                    case eAppEvent.eMachineDisconnected:
                        break;
                }
                Refresh();
            }
            
        }
        private void SetupForMachineType() 
        {
            MachineConfig mc = UVDLPApp.Instance().m_printerinfo;
            m_camera.UpdateBuildVolume((float)mc.m_PlatXSize, (float)mc.m_PlatYSize, (float)mc.m_PlatZSize);
        }


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
                ctl3DView1.SetButtonStatus(buttConnect.Enabled, buttDisconnect.Enabled, buttPlay.Enabled, buttStop.Enabled, buttPause.Enabled);
                Refresh();
            }
            catch (Exception ex) 
            {
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

        void BuildStatus(eBuildStatus printstat, string mess) 
        {
         // displays the print status
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { BuildStatus(printstat,mess); }));
            }
            else
            {
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
                        m_frmSettings.MachineControl.BuildStopped();
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
                            m_frmSettings.MachineControl.BuildStopped();
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
                        m_frmSettings.MachineControl.BuildStarted();
                        // if the current machine type is a UVDLP printer, make sure we can show the screen
                        if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
                        {
                            if (!m_frmdlp.ShowDLPScreen())
                            {
                                MessageBox.Show("Monitor " + UVDLPApp.Instance().m_printerinfo.m_monitorconfig.Monitorid + " not found, cancelling build", "Error");
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

        //This delegate is called when the print manager is printing a new layer
        void PrintLayer(Bitmap bmp, int layer,int layertype) 
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
                    ctl3DView1.ViewLayer(layer);
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

        private void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers,SliceFile sf)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { SliceEv(ev, layer, totallayers,sf); }));
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
                            //show the gcode
                            m_frmGCode.GcodeView.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                            ctl3DView1.SetNumLayers(totallayers);
                            m_frmSliceView.SliceView.SetNumLayers(totallayers);
                            SetMainMessage("Slicing Completed");
                            String timeest = BuildManager.EstimateBuildTime(UVDLPApp.Instance().m_gcode);
                            SetTimeMessage("Estimated Build Time: " + timeest);
                            //show the slice in the slice view
                            ViewLayer(0, null, BuildManager.SLICE_NORMAL);
                            break;
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void UpdateSceneInfo() 
        {
            try
            {
                
                //UVDLPApp.Instance().m_selectedobject.FindMinMax();
                //ctl3DView1.UpdateSceneTree();
                ctl3DView1.UpdateObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception) { }
        
        }
        /*
         Load Stl
         */
        public void LoadSTLModel_Click(object sender, object e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "3D Model Files(*.stl;*.obj;*.3ds;*.amf)|*.stl;*.obj;*.3ds;*.amf|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                if (UVDLPApp.Instance().LoadModel(openFileDialog1.FileName) == false)
                {
                   // MessageBox.Show("Error loading file " + openFileDialog1.FileName);
                }
                else 
                {
                    //chkWireframe.Checked = false;
                    ctl3DView1.UpdateObjectInfo();
                }
            }
        }

        
        private void ViewLayer(int layer, Bitmap image, int layertype) 
        {
            try
            {
                // if this is a normal slice that is specified, move to the correct 3d view of the layer, 
                // otherwise, keep showing the current 3d layer
                //render the 2d slice
                Bitmap bmp = null;
                if (image == null) // we're here because of the scroll bar in the gui
                {
                    bmp = UVDLPApp.Instance().m_slicefile.GetSliceImage(layer);

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
                    if (UVDLPApp.Instance().m_buildmgr.IsPrinting == true || UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay == true)
                    {
                        //make sure we show the screen
                        if (m_frmdlp == null) 
                        {
                            m_frmdlp.ShowDLPScreen(); 
                        }
                        m_frmdlp.ShowImage(bmp);
                    }
                }               
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.StackTrace);
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetTitle();
            SetupForMachineType();
            Refresh();
            foreach (string lg in DebugLogger.Instance().GetLog()) 
            {
                txtLog.Text = lg + "\r\n" + txtLog.Text;
            }
        }

        private void SetTitle() 
        {
            this.Text = "Creation Workshop - UV DLP 3D Printer Control and Slicing" + "  ( Slice Profile : ";
            this.Text += Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_buildparms.m_filename);
            this.Text += ", Machine : " + Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_printerinfo.m_filename) + ")";
        }


        /*private void chkWireframe_CheckedChanged(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null) return;
            UVDLPApp.Instance().SelectedObject.m_wireframe = chkWireframe.Checked;
            DisplayFunc();
            Refresh();
        }*/

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
                    // not a UV DLP GCode file
                    if (UVDLPApp.Instance().m_gcode.IsUVDLPGCode() == false) 
                    {
                        MessageBox.Show("Not a UV DLP GCode file\r\nCannot begin build\r\nPossibly wrong slicer used");
                        return;                    
                    }
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
        /*
        private void cmdPause_Click(object sender, EventArgs e)
        {
            //UVDLPApp.Instance().m_buildmgr.StartPrint(UVDLPApp.Instance().m_slicefile, UVDLPApp.Instance().m_gcode);
        }
         */ 
        /*
        private void cmdSliceOptions_Click(object sender, EventArgs e)
        {
            frmSliceOptions m_frmsliceopt = new frmSliceOptions(ref UVDLPApp.Instance().m_buildparms);
            m_frmsliceopt.ShowDialog();
        }
        */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadBinarySTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSTLModel_Click(this, null);
        }

        public void cmdStop_Click(object sender, object e)
        {
            UVDLPApp.Instance().m_buildmgr.CancelPrint();
        }

        

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
                        UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eMachineConnected,"Printer connected");
                    }
                    // check to see if we're uv dlp
                    // configure the projector
                    if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
                    {
                        // only try to configure and connect to the projector if the connection is enabled
                        if (UVDLPApp.Instance().m_printerinfo.m_monitorconfig.m_displayconnectionenabled == true)
                        {
                            UVDLPApp.Instance().m_deviceinterface.ConfigureProjector(UVDLPApp.Instance().m_printerinfo.m_monitorconfig.m_displayconnection);
                            com = UVDLPApp.Instance().m_printerinfo.m_monitorconfig.m_displayconnection.comname;
                            DebugLogger.Instance().LogRecord("Connecting to Projector on " + com + " using " + UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_drivertype.ToString());
                            if (!UVDLPApp.Instance().m_deviceinterface.ConnectProjector())
                            {
                                DebugLogger.Instance().LogRecord("Cannot connect projector driver on " + com);
                            }
                            else
                            {
                                DebugLogger.Instance().LogRecord("Connected to Display control on " + com);
                                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eDisplayConnected, "Display connected");
                            }
                        }
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
            if (UVDLPApp.Instance().m_deviceinterface.ConnectedProjector) 
            {
                DebugLogger.Instance().LogRecord("Disconnecting from Projector");
                UVDLPApp.Instance().m_deviceinterface.DisconnectProjector();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eDisplayDisconnected, "Projector connection closed");                
            }
        }

        public void cmdSlice1_Click(object sender, object e)
        {
            if (m_frmSlice.IsDisposed) 
            {
                m_frmSlice = new frmSlice();
            }
            m_frmSlice.Show();
        } 

        #region DLP Screen Controls
        private void showBlankDLP()
        {
            UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay = true; 
            m_frmdlp.ShowDLPScreen();
            Screen dlpscreen = m_frmdlp.GetDLPScreen();
            if (dlpscreen != null)
            {
                UVDLPApp.Instance().m_buildmgr.ShowBlank(dlpscreen.Bounds.Width, dlpscreen.Bounds.Height);
            }
        }

        private void showCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_buildparms.UpdateFrom(UVDLPApp.Instance().m_printerinfo);
            UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay = true;
            m_frmdlp.ShowDLPScreen();
            Screen dlpscreen = m_frmdlp.GetDLPScreen();
            if (dlpscreen != null)
            {
                UVDLPApp.Instance().m_buildmgr.ShowCalibration(dlpscreen.Bounds.Width, dlpscreen.Bounds.Height, UVDLPApp.Instance().m_buildparms);
            }
        }

        /*
        private Screen GetDLPScreen() 
        {
            Screen dlpscreen = null;
            foreach (Screen s in Screen.AllScreens)
            {
                if (s.DeviceName.Equals(UVDLPApp.Instance().m_printerinfo.m_monitorconfig.Monitorid))
                {
                    dlpscreen = s;
                    break;
                }
            }
            if (dlpscreen == null)
            {
                dlpscreen = Screen.AllScreens[0]; // default to the first if we can't find it
                DebugLogger.Instance().LogRecord("Can't find screen " + UVDLPApp.Instance().m_printerinfo.m_monitorconfig.Monitorid);
            }
            return dlpscreen;
        }
         * */
        
        #endregion DLP screen controls

        public void cmdPause_Click_1(object sender, object e)
        {
            UVDLPApp.Instance().m_buildmgr.PausePrint();
        }


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

        private void addManualSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().AddSupport();
        }

       
       
        private void frmMain_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            Refresh();
        }


        /*private void chkAlpha_CheckedChanged(object sender, EventArgs e)
        {
            //if (UVDLPApp.Instance().m_selectedobject == null) return;
            //UVDLPApp.Instance().m_selectedobject.m_showalpha = chkAlpha.Checked;
            SetAlpha(chkAlpha.Checked);
            UVDLPApp.Instance().m_engine3d.m_alpha = chkAlpha.Checked;
            UVDLPApp.Instance().m_engine3d.UpdateLists();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");            
        }*/
 
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrefs prefs = new frmPrefs();
            prefs.ShowDialog();

        }
 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void tabMachineControl_Enter(object sender, EventArgs e)
        {
            m_frmSettings.MachineControl.UpdateControl(); // update control display -SHS
        }
        /*
        private void estimateVolumeCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVolEst frmvol = new frmVolEst();
           // UVDLPApp.Instance().m_estimator.Setup(UVDLPApp.Instance().m_slicefile, UVDLPApp.Instance().m_buildparms);
            frmvol.ShowDialog();
        }
        */
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_callbackhandler.DumpCommands("CWCommands.txt");
        }

        /*private void chkPreviewSlice_CheckedChanged(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay = chkPreviewSlice.Checked;
            UVDLPApp.Instance().m_appconfig.Save(UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + UVDLPApp.m_appconfigname);
        }*/


        private void findHolesInMeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMeshHoles mh = new frmMeshHoles();
            mh.ShowDialog();
        }

        public void buttViewSlice_Click(object sender, object e)
        {
            m_frmSliceView.Show();
            m_frmSliceView.BringToFront();
        }

        public void buttViewGcode_Click(object sender, object e)
        {
            m_frmGCode.Show();
            m_frmGCode.BringToFront();
        }

        public void buttConfig_Click(object sender, object e)
        {
            m_frmSettings.Show();
            m_frmSettings.BringToFront();
        }

        private void splashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmBmpSplash();
            ctl3DView1.m_splash = frm;
            frm.ShowDialog();
            ctl3DView1.m_splash = null;
        }

        private void pluginTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPluginTester pit = new frmPluginTester();
            pit.Show();

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

        public void ShowLogPanel(bool visible) 
        {
            splitContainerMainWindow.Panel2Collapsed = !visible;
        }

        private void stalactite3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuiConfig gc = ctl3DView1.GuiConfig;
            C2DGraphics gr2d = ctl3DView1.Graphics2D;
            IPlugin plugin = null;
            foreach (PluginEntry ip in UVDLPApp.Instance().m_plugins)
            {
                if (ip.m_plugin.Name == "Stalactite")
                    plugin = ip.m_plugin;
            }
            if (plugin == null)
                return;

            string guiconf = null;
            foreach (PluginItem pi in plugin.GetPluginItems)
            {
                switch (pi.m_type)
                {
                    case ePlItemType.eTexture:
                        gr2d.LoadTexture(plugin.GetString(pi.m_name + "_index"), plugin);
                        break;

                    case ePlItemType.eGuiConfig:
                        guiconf = plugin.GetString(pi.m_name);
                        break;

                    case ePlItemType.eControl:
                        UserControl ctl = plugin.GetControl(pi.m_name);
                        if ((ctl.GetType() == typeof(ctlImageButton)) || ctl.GetType().IsSubclassOf(typeof(ctlImageButton)))
                        {
                            gc.AddButton(pi.m_name, (ctlImageButton)ctl);
                        }
                        else if (ctl.GetType().IsSubclassOf(typeof(ctlUserPanel)))
                        {
                            gc.AddControl(pi.m_name, (ctlUserPanel)ctl);
                        }
                        break;
                }
            }
            if (guiconf != null)
            {
                //gc.ClearLayout();
                gc.LoadConfiguration(guiconf, plugin);
                ctl3DView1.RearrangeGui();
            }
        }

        private void buttViewSlice_Click(object sender, EventArgs e)
        {

        }

    }
}
