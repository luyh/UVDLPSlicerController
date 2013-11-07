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
using UV_DLP_3D_Printer.GUI;
using UV_DLP_3D_Printer.GUI.Controls;
using UV_DLP_3D_Printer._3DEngine;
using UV_DLP_3D_Printer.Slicing;

using UV_DLP_3D_Printer._3DEngine.CSG;

namespace UV_DLP_3D_Printer
{
    public partial class frmMain : Form
    {
        private bool m_movingobjectmode = false; // for moving objects while the shift key is held down
        bool loaded = false;
        bool m_showalpha = false;
         
        frmDLP m_frmdlp = new frmDLP();        
        frm3DLPrinterControl m_frm3DLPControl = new frm3DLPrinterControl();
        frmSlice m_frmSlice = new frmSlice();
        frmBuildProfilesManager m_buildprofilesmanager = new frmBuildProfilesManager();
        ArcBall arcball;// = new ArcBall();
        Quaternion m_quat;
        

        private bool lmdown, rmdown, mmdown;
        private int mdx, mdy;
        float orbitypos = 0;
        float orbitxpos = -80;
        float orbitdist = -200;
        float yoffset = -10.0f;
        float xoffset = 0.0f;

        float ix = 0.0f, iy = 0.0f, iz = 2.0f;
        //float ipx = 0.0f, ipy = 0.0f, ipz = 2.0f;
        public frmMain()
        {
            InitializeComponent();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            UVDLPApp.Instance().Engine3D.AddGrid();
            UVDLPApp.Instance().Engine3D.AddPlatCube();
            UVDLPApp.Instance().Engine3D.CameraReset();
            UVDLPApp.Instance().m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            UVDLPApp.Instance().m_buildmgr.BuildStatus += new delBuildStatus(BuildStatus);
            UVDLPApp.Instance().m_buildmgr.PrintLayer += new delPrinterLayer(PrintLayer);
            DebugLogger.Instance().LoggerStatusEvent += new LoggerStatusHandler(LoggerStatusEvent);
            UVDLPApp.Instance().m_deviceinterface.StatusEvent += new DeviceInterface.DeviceInterfaceStatus(DeviceStatusEvent);
            UVDLPApp.Instance().m_supportgenerator.SupportEvent += new SupportGeneratorEvent(SupEvent);
            
            arcball = new ArcBall();
            m_quat = new Quaternion();

            SetButtonStatuses();                        
            //PopulateBuildProfilesMenu();
            SetupSceneTree();
            
            Refresh();
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
                            SetupSceneTree();
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
        }
        private void SetMainMessage(String message) 
        {
            lblMainMessage.Text = message;
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
                        ShowObjectInfo();
                        UVDLPApp.Instance().m_engine3d.UpdateLists();
                        DisplayFunc();
                        break;
                    case eAppEvent.eSlicedLoaded: // update the gui to view
                        DebugLogger.Instance().LogRecord(Message);
                        int totallayers = UVDLPApp.Instance().m_slicefile.NumSlices;
                        SetVScrollMax(totallayers);
                        //show the slice in the slice view
                        ViewLayer(0, null, BuildManager.SLICE_NORMAL);
                        break;
                    case eAppEvent.eGCodeLoaded:
                        DebugLogger.Instance().LogRecord(Message);
                        txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                        break;
                    case eAppEvent.eGCodeSaved:
                        DebugLogger.Instance().LogRecord(Message);
                        break;
                    case eAppEvent.eModelAdded:
                        ShowObjectInfo();
                        UVDLPApp.Instance().m_engine3d.UpdateLists();
                        DisplayFunc();
                        DebugLogger.Instance().LogRecord(Message);
                        break;
                    case eAppEvent.eMachineTypeChanged:
                        SetupForMachineType();
                        break;
                    case eAppEvent.eShowBlank:
                        showBlankToolStripMenuItem_Click(null, null);                        
                        break;
                    case eAppEvent.eShowCalib:
                        showCalibrationToolStripMenuItem_Click(null, null);
                        break;
                    case eAppEvent.eShowDLP:
                        ShowDLPScreen();
                        break;
                    case eAppEvent.eHideDLP:
                        hideToolStripMenuItem_Click(null, null);
                        break;
                    case eAppEvent.eReDraw: // redraw the 3d display
                        DisplayFunc();
                        break;
                }
            }
            Refresh();
        }
        private void SetupForMachineType() 
        {
            if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
            {
                heatTempCtl1.Enabled = false;
            }
            else if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.FDM)
            {
                heatTempCtl1.Enabled = true;
            }
                    
        }
        private void SetVScrollMax(int val) 
        {
            try
            {
                if (val < 0)
                    val = 0;
                vScrollBar1.Maximum = val + vScrollBar1.LargeChange - 2;
                vScrollBar1.Value = 0;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        private void SetButtonStatuses() 
        {
            if (UVDLPApp.Instance().m_deviceinterface.Connected)
            {
                cmdConnect.Enabled = false;
                cmdDisconnect.Enabled = true;

                if (UVDLPApp.Instance().m_buildmgr.IsPrinting)
                {
                    if (UVDLPApp.Instance().m_buildmgr.IsPaused())
                    {
                        cmdBuild.Enabled = true;
                        cmdStop.Enabled = true;
                        cmdPause.Enabled = false;
                    }
                    else
                    {
                        cmdBuild.Enabled = false;
                        cmdStop.Enabled = true;
                        cmdPause.Enabled = true;
                    }
                }
                else
                {
                    cmdBuild.Enabled = true;
                    cmdStop.Enabled = false;
                    cmdPause.Enabled = false;
                }
            }
            else 
            {
                cmdConnect.Enabled = true;
                cmdDisconnect.Enabled = false;
               // cmdControl.Enabled = false;
                cmdBuild.Enabled = false;
                cmdStop.Enabled = false;
                cmdPause.Enabled = false; // disable

            }
            Refresh();
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
                    case ePIStatus.eReady:
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
                        ctlMachineControl1.BuildStopped();
                        SetMainMessage(message);
                        DebugLogger.Instance().LogRecord(message);

                        break;
                    case eBuildStatus.eLayerCompleted:
                        message = "Layer Completed";
                        break;
                    case eBuildStatus.eBuildCompleted:
                        message = "Print Completed";
                        SetButtonStatuses();
                        ctlMachineControl1.BuildStopped();
                        MessageBox.Show("Build Completed");
                        SetMainMessage(message);
                        DebugLogger.Instance().LogRecord(message);
                        break;
                    case eBuildStatus.eBuildStarted:
                        message = "Print Started";
                        SetButtonStatuses();
                        ctlMachineControl1.BuildStarted();
                        // if the current machine type is a UVDLP printer, make sure we can show the screen
                        if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
                        {
                            if (!ShowDLPScreen())
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
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { PrintLayer(bmp, layer,layertype); }));
            }
            else
            {
                ViewLayer(layer,bmp,layertype);
                // display info only if it's a normal layer
                if (layertype == BuildManager.SLICE_NORMAL)
                {
                    
                    String txt = "Printing layer " + (layer + 1) + " of " + UVDLPApp.Instance().m_slicefile.NumSlices;
                    DebugLogger.Instance().LogRecord(txt);
                }

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
                            txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                            SetVScrollMax(totallayers);
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

        private void ShowObjectInfo() 
        {
            try
            {
                
                //UVDLPApp.Instance().m_selectedobject.FindMinMax();
                SetupSceneTree();
            }
            catch (Exception) { }
        
        }
        /*
         Load Stl
         */
        private void LoadSTLModel_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "3D Model Files(*.stl;*.obj;*3ds)|*.stl;*.obj;*.3ds|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                if (UVDLPApp.Instance().LoadModel(openFileDialog1.FileName) == false)
                {
                   // MessageBox.Show("Error loading file " + openFileDialog1.FileName);
                }
                else 
                {
                    chkWireframe.Checked = false;

                }
            }
        }

        
        private void ViewLayer(int layer, Bitmap image, int layertype) 
        {
            try
            {
                // if this is a normal slice that is specified, move to the correct 3d view of the layer, 
                // otherwise, keep showing the current 3d layer
                if (layertype == BuildManager.SLICE_NORMAL)
                {
                    DisplayFunc();
                    SliceFile sf = UVDLPApp.Instance().m_slicefile;
                    lblSliceNum.Text = "Slice " + (layer) + " of " + (sf.NumSlices-1).ToString();
                }
                //render the 2d slice
                Bitmap bmp = null;
                if (image == null) // we're here because of the scroll bar in the gui
                {
                    bmp = UVDLPApp.Instance().m_slicefile.GetSlice(layer);
                }
                else // the image was specified from the build manager
                {
                    bmp = image;
                }

                //this bmp could be a normal, blank, or calibration image
                picSlice.Image = bmp;//now show the 2d slice
                // if we're a UV DLP printer, show on the frmDLP
                if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
                {
                    m_frmdlp.ShowImage(bmp);
                }
                
                //lblCurSlice.Text = "Layer = " +layer;
            }
            catch (Exception) { }
        
        }
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int vscrollval = vScrollBar1.Value;
                ViewLayer(vscrollval, null, BuildManager.SLICE_NORMAL);
            }
            catch (Exception) 
            {
                // probably past the max.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetTitle();
            SetupForMachineType();
            Refresh();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            SetupViewport();
        }

        private void SetupViewport()
        {
            if (!loaded)
                return;
            float aspect = 1.0f;
            try
            {
                int w = glControl1.Width;
                int h = glControl1.Height;
                arcball.Resize(w, h);

                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(0, w, 0, h, 1, 2000); // Bottom-left corner pixel has coordinate (0, 0)

                GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
                aspect = ((float)glControl1.Width) / ((float)glControl1.Height);

                //GL.Matr
                //GL.Enable(EnableCap.DepthTest); // for z buffer
                SetAlpha(false); // start off with alpha off

                GL.Enable(EnableCap.CullFace); // enable culling of faces
                GL.CullFace(CullFaceMode.Back); // specify culling backfaces               

                OpenTK.Matrix4 projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(0.55f, aspect, 1,2000);
                //OpenTK.Matrix4 projection = OpenTK.Matrix4.CreateOrthographic(w/8,h/8,1,2000);
                OpenTK.Matrix4 modelView = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(5, 0, -5), new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector3(0, 0, 1));

                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.LoadMatrix(ref projection);

                GL.ShadeModel(ShadingModel.Smooth); // tell it to shade smoothly
                // properties of materials
                GL.Enable(EnableCap.ColorMaterial); // allow polys to have color
                float[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
                float []mat_shininess = { 50.0f };
                GL.Material(MaterialFace.Front, MaterialParameter.Specular, mat_specular);
                GL.Material(MaterialFace.Front, MaterialParameter.Shininess, mat_shininess);
                                
                //set a color to clear the background
                GL.ClearColor(Color.LightBlue);

                // antialising lines
                GL.Enable(EnableCap.LineSmooth);
                //GL.Enable(EnableCap.PolygonSmooth);
                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
                //GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest); 

                // lighting
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                float[] lightpos = new float[4];
                lightpos[0] = 5.0f;
                lightpos[1] = 15.0f;
                lightpos[2] = 10.0f;
                lightpos[3] = 1.0f;
                float []light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
                GL.Light(LightName.Light0, LightParameter.Position, light_position);

                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.LoadMatrix(ref modelView);
            }
            catch (Exception ex) 
            {
                String s = ex.Message;
                // the create perspective function blows up on certain ratios
            }
        }
        private void Reset() 
        {
           // OpenTK.
            
        }
        private void SetAlpha(bool val) 
        {
            m_showalpha = val;
            if (val == true)
            {
                GL.Disable(EnableCap.DepthTest); // need to disable z buffering for proper display
                //alpha blending
                GL.Enable(EnableCap.Blend); // alpha blending
                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                GL.Enable(EnableCap.AlphaTest);
            }
            else 
            {
                GL.Disable(EnableCap.AlphaTest);
                GL.Enable(EnableCap.DepthTest); // for z buffer        
                GL.Disable(EnableCap.Blend); // alpha blending
            }
        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            DisplayFunc();
        }
        // draw the intersection of the current mouse point into the scene
        private void DrawISect() 
        {
            // draw some lines
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Red);
            GL.LineWidth(50);
            GL.Vertex3(ix-5, iy, iz);
            GL.Vertex3(ix+5 , iy, iz);
            
            GL.End();
        
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Red);
            GL.LineWidth(50);
            GL.Vertex3(ix, iy-5, iz);
            GL.Vertex3(ix, iy+5, iz);
            GL.End();
         
        }

        private void DisplayFunc() 
        {
            
          /* Clear the buffer, clear the matrix */
          GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            
          GL.LoadIdentity(); // assuming we're in the model matrix still
            
          GL.Translate(xoffset, yoffset, orbitdist); // tmp          
          GL.Rotate(orbitypos, 0, 1, 0); // transform first // tmp
          GL.Rotate(orbitxpos, 1, 0, 0); // tmp
            
          //Matrix4 yax;
          //Matrix4.CreateFromAxisAngle(new Vector3(0, 0, 1), m_quat.Z, out yax);
          //GL.LoadMatrix(ref yax);
            /*
          Matrix4.CreateFromAxisAngle(new Vector3(1, 0, 0), m_quat.X);
            */
            /*
          GL.Translate(xoffset, yoffset, orbitdist); // tmp

          GL.Rotate(m_quat.Z * 100, 0, 0, 1); //  
          GL.Rotate(m_quat.Y * 100, 0, 1, 0); // 
          GL.Rotate(m_quat.X * 100, 1, 0, 0); //  
            */

          UVDLPApp.Instance().Engine3D.RenderGL(m_showalpha);
          DrawISect();          
          GL.Flush();
          glControl1.SwapBuffers();
        }


        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            glControl1.MouseWheel += new MouseEventHandler(glControl1_MouseWheel);
            SetupViewport();
        }

        void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            orbitdist += e.Delta / 10;
            DisplayFunc();
        }
        private void SetTitle() 
        {
            this.Text = "Creation Workshop - UV DLP 3D Printer Control and Slicing" + "  ( Slice Profile : ";
            this.Text += Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_buildparms.m_filename);
            this.Text += ", Machine : " + Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_printerinfo.m_filename) + ")";
        }
        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mdx = e.X;
            mdy = e.Y;
            if (e.Button == MouseButtons.Middle)
            {
                mmdown = true;
                arcball.Click(new Vector2(mdx,mdy));
            }
            
            if (e.Button == MouseButtons.Left)
            {
                lmdown = true;
                Vector2 vec = new Vector2(mdx,mdy);
                arcball.Click(vec);
            }
            if (e.Button == MouseButtons.Right)
            {
                rmdown = true;
            }
        }

        private List<ISectData> TestHitTest(int X, int Y)
        {
            String mess = "";
            mess = "Screen X,Y = (" + X.ToString() + "," + Y.ToString() + ")\r\n";
            
            /*
            (Note that most window systems place the mouse coordinate origin in the upper left of the window instead of the lower left. 
            That's why window_y is calculated the way it is in the above code. When using a glViewport() that doesn't match the window height,
            the viewport height and viewport Y are used to determine the values for window_y and norm_y.)

            The variables norm_x and norm_y are scaled between -1.0 and 1.0. Use them to find the mouse location on your zNear clipping plane like so:

            float y = near_height * norm_y;
            float x = near_height * aspect * norm_x;
            Now your pick ray vector is (x, y, -zNear).             
             */
            int w = glControl1.Width;
            int h = glControl1.Height;
            mess += "Screen Width/Height = " + w.ToString() + "," + h.ToString() + "\r\n";
            float aspect = ((float)glControl1.Width) / ((float)glControl1.Height);
            //mess += "Screen Aspect = " + aspect.ToString() + "\r\n";

            int window_y = (h - Y) - h/2;
            double norm_y = (double)(window_y)/(double)(h/2);
            int window_x = X - w/2;
            double norm_x = (double)(window_x)/(double)(w/2);
            float near_height = .2825f; // no detectable error

            float y = (float)(near_height * norm_y);
            float x = (float)(near_height * aspect * norm_x);

            /*
            To transform this eye coordinate pick ray into object coordinates, multiply it by the inverse of the ModelView matrix in use 
            when the scene was rendered. When performing this multiplication, remember that the pick ray is made up of a vector and a point, 
            and that vectors and points transform differently. You can translate and rotate points, but vectors only rotate. 
            The way to guarantee that this is working correctly is to define your point and vector as four-element arrays, 
            as the following pseudo-code shows:

            float ray_pnt[4] = {0.f, 0.f, 0.f, 1.f};
            float ray_vec[4] = {x, y, -near_distance, 0.f};
            The one and zero in the last element determines whether an array transforms as a point or a vector when multiplied by the 
            inverse of the ModelView matrix.*/
            Vector4 ray_pnt = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
            //Vector4 ray_vec = new Vector4((float)norm_x, (float)norm_y, -1.0f, 0);
            Vector4 ray_vec = new Vector4((float)x, (float)y, -1f, 0);
            ray_vec.Normalize();

            mess += "Eye Pick Vec =  (" + String.Format("{0:0.00}", ray_vec.X) + ", " + String.Format("{0:0.00}", ray_vec.Y) + "," + String.Format("{0:0.00}", ray_vec.Z) + ")\r\n";

            Matrix4 modelViewMatrix;
            GL.GetFloat(GetPName.ModelviewMatrix, out modelViewMatrix);
            Matrix4 viewInv = Matrix4.Invert(modelViewMatrix);

            Vector4 t_ray_pnt = new Vector4();
            Vector4 t_ray_vec = new Vector4();

            Vector4.Transform(ref ray_vec, ref viewInv, out t_ray_vec);
            Vector4.Transform(ref ray_pnt, ref viewInv, out t_ray_pnt);
            mess += "World Pick Vec =  (" + String.Format("{0:0.00}", t_ray_vec.X) + ", " + String.Format("{0:0.00}", t_ray_vec.Y) + "," + String.Format("{0:0.00}", t_ray_vec.Z) + ")\r\n";
            mess += "World Pick Pnt =  (" + String.Format("{0:0.00}", t_ray_pnt.X) + ", " + String.Format("{0:0.00}", t_ray_pnt.Y) + "," + String.Format("{0:0.00}", t_ray_pnt.Z) + ")\r\n";
            
            Point3d origin = new Point3d();
            Point3d intersect = new Point3d();
            Engine3D.Vector3d dir = new Engine3D.Vector3d();

            origin.Set(t_ray_pnt.X, t_ray_pnt.Y, t_ray_pnt.Z, 1.0);
            dir.Set(t_ray_vec.X, t_ray_vec.Y, t_ray_vec.Z, 0); // should this be scaled?

            List<ISectData> isects = RTUtils.IntersectObjects(dir, origin, UVDLPApp.Instance().Engine3D.m_objects, true);
            if (isects.Count > 0) 
            {
                ISectData isect = (ISectData)isects[0]; // get the first
                ix = (float)isect.intersect.x; // show the closest
                iy = (float)isect.intersect.y;
                iz = (float)isect.intersect.z;
            }
            
            return isects;
        }
        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                mmdown = false;
            }
            if (e.Button == MouseButtons.Left)
            {
                lmdown = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                rmdown = false;
            }

        }


        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            List<ISectData> hits = TestHitTest(e.X,e.Y);
            double dx = 0, dy = 0;
            if (lmdown || rmdown || mmdown)
            {
                dx = e.X - mdx;
                dy = e.Y - mdy;
                mdx = e.X;
                mdy = e.Y;

            }
            dx /= 2;
            dy /= 2;

            if (lmdown)
            {
                orbitypos += (float)dx;                
                orbitxpos += (float)dy;
                Vector2 vec = new Vector2(mdx,mdy);
                m_quat += arcball.Drag(vec);
                arcball.Click(vec);
                //arcball.Click(vec);
                //ArcBall.drag(&MousePt, &ThisQuat);                  // Update End Vector And Get Rotation As Quaternion
                /*
                Matrix3fSetRotationFromQuat4f(&ThisRot, &ThisQuat);         // Convert Quaternion Into Matrix3fT
                Matrix3fMulMatrix3f(&ThisRot, &LastRot);                // Accumulate Last Rotation Into This One
                Matrix4fSetRotationFromMatrix3f(&Transform, &ThisRot);          // Set Our Final 
                 * */
                // do the rotation
            }
            else if (mmdown)
            {
                orbitdist += (float)dy;
            }
            else if (rmdown)
            {
                yoffset += (float)dy / 2;
                xoffset += (float)dx / 2;
            }

            if (UVDLPApp.Instance().SelectedObject != null)
            {
                if (m_movingobjectmode) // if we're moving an object
                {
                    // examine the last isect data
                    foreach (ISectData dat in hits)
                    {
                        if (dat.obj.tag == Object3d.OBJ_GROUND) //found the ground plane
                        {

                            UVDLPApp.Instance().SelectedObject.Translate(
                                (float)(dat.intersect.x - UVDLPApp.Instance().SelectedObject.m_center.x),
                                (float)(dat.intersect.y - UVDLPApp.Instance().SelectedObject.m_center.y),
                                0.0f);
                        }
                        
                    }
                    if (UVDLPApp.Instance().SelectedObject.tag == Object3d.OBJ_SUPPORT)  // if the current selected object is a support
                    {
                        Support tmpsup = (Support)UVDLPApp.Instance().SelectedObject;
                        Point3d pnt = new Point3d();
                        pnt.Set(tmpsup.m_center.x, tmpsup.m_center.y, 0, 0);
                        Engine3D.Vector3d vec = new Engine3D.Vector3d();
                        vec.Set(0, 0, 1, 0); // create a vector striaght up
                        // hit test from the selected objects center x/y/0 position straight up
                        //see if it hits any object in the scene,
                        // if it does, scale the object from the ground plane to the closest intersection point
                        List<ISectData> iss = RTUtils.IntersectObjects(vec, pnt, UVDLPApp.Instance().Engine3D.m_objects, false);
                        foreach (ISectData htd in iss) 
                        {
                            if (htd.obj.tag != Object3d.OBJ_SUPPORT )  // if this is not another support or the ground
                            {
                                if (htd.obj.tag != Object3d.OBJ_GROUND)
                                {
                                    // this should be it...
                                    tmpsup.ScaleToHeight(htd.intersect.z);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            DisplayFunc();
        }

        private void glControl1_MouseLeave(object sender, EventArgs e)
        {
            //should cancel any move commands
        }

        private void chkWireframe_CheckedChanged(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null) return;
            UVDLPApp.Instance().SelectedObject.m_wireframe = chkWireframe.Checked;
            DisplayFunc();
            Refresh();
        }

        private void cmdCenter_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null) return;
            Point3d center = UVDLPApp.Instance().SelectedObject.CalcCenter();
            UVDLPApp.Instance().SelectedObject.Translate((float)-center.x, (float)-center.y,(float) -center.z);
            ShowObjectInfo();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
        }

        private void cmdStartPrint_Click(object sender, EventArgs e)
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
        private void cmdPlace_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null) 
                return;
            Point3d center = UVDLPApp.Instance().SelectedObject.CalcCenter();
            UVDLPApp.Instance().SelectedObject.FindMinMax();
            float zlev = (float)UVDLPApp.Instance().SelectedObject.m_min.z;
            float epsilon = .05f; // add in a the level of 1 slice 
            UVDLPApp.Instance().SelectedObject.Translate((float)0, (float)0, (float)-zlev);
            UVDLPApp.Instance().SelectedObject.Translate((float)0, (float)0, (float)-epsilon);
            ShowObjectInfo();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
        }

        private void cmdScale_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null) 
                    return;
                float sf = Single.Parse(txtScale.Text);
                UVDLPApp.Instance().SelectedObject.Scale(sf);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");

            }
            catch (Exception) 
            {
            
            }
        }

        private void cmdSliceOptions_Click(object sender, EventArgs e)
        {
            frmSliceOptions m_frmsliceopt = new frmSliceOptions(ref UVDLPApp.Instance().m_buildparms);
            m_frmsliceopt.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadBinarySTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSTLModel_Click(this, null);
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_buildmgr.CancelPrint();
        }

        

        private void cmdConnect1_Click(object sender, EventArgs e)
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

        private void cmdDisconnect_Click(object sender, EventArgs e)
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

        private void cmdSlice1_Click(object sender, EventArgs e)
        {
            if (m_frmSlice.IsDisposed) 
            {
                m_frmSlice = new frmSlice();
            }
            m_frmSlice.Show();
        }

        #region Save/Load GCode
        private void cmdSaveGCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // get the gcode from the textbox, save it...
                    UVDLPApp.Instance().m_gcode.RawGCode = txtGCode.Text;
                    UVDLPApp.Instance().SaveGCode(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        
        #endregion Save/ Load GCode

        #region Scene Tree Functionality
        private void SetupSceneTree()
        {
            treeScene.Nodes.Clear();//clear the old

            TreeNode scenenode = new TreeNode("Scene");
            treeScene.Nodes.Add(scenenode);
            TreeNode support3d = new TreeNode("3d Supports");
            treeScene.Nodes.Add(support3d);

            foreach (Object3d obj in UVDLPApp.Instance().Engine3D.m_objects)
            {
                if (obj.tag == Object3d.OBJ_SUPPORT)
                {
                    TreeNode objnode = new TreeNode(obj.Name);
                    objnode.Tag = obj;
                    support3d.Nodes.Add(objnode);
                    if (obj == UVDLPApp.Instance().SelectedObject)  // expand this node
                    {
                        objnode.BackColor = Color.LightBlue;
                        treeScene.SelectedNode = objnode;
                    }
                }
                else
                {
                    obj.FindMinMax();
                    TreeNode objnode = new TreeNode(obj.Name);
                    objnode.Tag = obj;
                    scenenode.Nodes.Add(objnode);
                    //String minmax = "Nu
                    String Numpoints = "# Points = " + obj.NumPoints.ToString();
                    objnode.Nodes.Add(Numpoints);
                    String Numpolys  = "# Polys  = " + obj.NumPolys.ToString();
                    objnode.Nodes.Add(Numpolys);
                    objnode.Nodes.Add("Min= (" + String.Format("{0:0.00}", obj.m_min.x) + "," + String.Format("{0:0.00}", obj.m_min.y) + "," + String.Format("{0:0.00}", obj.m_min.z) + ")");
                    objnode.Nodes.Add("Max= (" + String.Format("{0:0.00}", obj.m_max.x) + "," + String.Format("{0:0.00}", obj.m_max.y) + "," + String.Format("{0:0.00}", obj.m_max.z) + ")");
                    double xs, ys, zs;
                    xs = obj.m_max.x - obj.m_min.x;
                    ys = obj.m_max.y - obj.m_min.y;
                    zs = obj.m_max.z - obj.m_min.z;
                    objnode.Nodes.Add("Size= (" + String.Format("{0:0.00}", xs) + "," + String.Format("{0:0.00}", ys) + "," + String.Format("{0:0.00}", zs) + ")");
                    if (obj == UVDLPApp.Instance().SelectedObject)  // expand this node
                    {
                        objnode.Expand();
                        objnode.BackColor = Color.LightBlue;
                        treeScene.SelectedNode = objnode;
                    }
                }

            }
            scenenode.Expand();
        }
        /*
         This function does 2 things,
         * when a node is click that is an object node, it sets
         * the App current object to be the clicked object
         * when an obj in the tree view is right clicked, it shows the context menu
         */
        private void treeScene_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Node.Tag != null)            
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Node.Tag != null)
            {
                UVDLPApp.Instance().SelectedObject = (Object3d)e.Node.Tag;
                SetupSceneTree();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
                
            if (e.Button == System.Windows.Forms.MouseButtons.Right)  // we right clicked a menu item, check and see if it has a tag
            {
                if (e.Node.Text.Equals("3d Supports"))
                {
                    contextMenuStrip2.Show(treeScene, e.Node.Bounds.Left, e.Node.Bounds.Top);
                }
                else
                {
                    if (e.Node.Tag != null)
                    {
                        contextMenuStrip1.Show(treeScene, e.Node.Bounds.Left, e.Node.Bounds.Top);
                    }
                }
            }            
            
        }

        private void cmdRemoveObject_Click(object sender, EventArgs e)
        {
            // delete the current selected object
            if (UVDLPApp.Instance().SelectedObject != null) 
            {
                UVDLPApp.Instance().RemoveCurrentModel();

            }

        }
        #endregion

        #region Move functions
        private void cmdXDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = float.Parse(txtXTrans.Text);
                val *= -1;
                UVDLPApp.Instance().SelectedObject.Translate(val, 0, 0);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdXInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = float.Parse(txtXTrans.Text);
                UVDLPApp.Instance().SelectedObject.Translate(val, 0, 0);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdYDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = float.Parse(txtYTrans.Text);
                val *= -1;
                UVDLPApp.Instance().SelectedObject.Translate(0, val, 0);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdYInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = float.Parse(txtYTrans.Text);
                val *= 1;
                UVDLPApp.Instance().SelectedObject.Translate(0, val, 0);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdZdec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = float.Parse(txtZTrans.Text);
                val *= -1;
                UVDLPApp.Instance().SelectedObject.Translate(0, 0,val);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdZInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = float.Parse(txtZTrans.Text);
                val *= 1;
                UVDLPApp.Instance().SelectedObject.Translate(0, 0,val);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        #endregion Move functions

        #region Rotate functions
        private void cmdXRDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float dx = 90.0f;
                Single.TryParse(txtRx.Text, out dx);                
                UVDLPApp.Instance().SelectedObject.Rotate(-(dx * 0.0174532925f), 0, 0);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdXRInc_Click(object sender, EventArgs e)
        {
            try
            {

                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                //get R-x val
                float dx=90.0f;
                Single.TryParse(txtRx.Text, out dx);
                UVDLPApp.Instance().SelectedObject.Rotate((dx * 0.0174532925f), 0, 0);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdYRDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float dy = 90.0f;
                Single.TryParse(txtRy.Text, out dy);
                UVDLPApp.Instance().SelectedObject.Rotate(0,-(dy*0.0174532925f), 0);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdYRInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float dy = 90.0f;
                Single.TryParse(txtRy.Text, out dy);
                UVDLPApp.Instance().SelectedObject.Rotate(0, dy * 0.0174532925f, 0);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdZRDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float dz = 90.0f;
                Single.TryParse(txtRz.Text, out dz);

                UVDLPApp.Instance().SelectedObject.Rotate(0, 0, -(dz*0.0174532925f));
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdZRInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float dz = 90.0f;
                Single.TryParse(txtRz.Text, out dz);
                UVDLPApp.Instance().SelectedObject.Rotate(0, 0, dz * 0.0174532925f);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        #endregion

        #region Mouse Move/Scale/Rotate/View
        /*
        private void mnuView_Click(object sender, EventArgs e)
        {
            m_mousemode = eMOUSEMODE.eView;
            SetMouseModeChecks();
        }

        private void mnuMove_Click(object sender, EventArgs e)
        {
            m_mousemode = eMOUSEMODE.eModelMove;
            SetMouseModeChecks();
        }

        private void mnuRotate_Click(object sender, EventArgs e)
        {
            m_mousemode = eMOUSEMODE.eModelRotate;
            SetMouseModeChecks();
        }

        private void mnuScale_Click(object sender, EventArgs e)
        {
            m_mousemode = eMOUSEMODE.eModelScale;
            SetMouseModeChecks();
        }
        private void SetMouseModeChecks()
        {
            mnuMove.Checked = false;
            mnuView.Checked = false;
            mnuScale.Checked = false;
            mnuRotate.Checked = false;
            switch (m_mousemode)
            {
                case eMOUSEMODE.eModelMove:
                    mnuMove.Checked = true;
                    break;
                case eMOUSEMODE.eModelRotate:
                    mnuRotate.Checked = true;
                    break;
                case eMOUSEMODE.eModelScale:
                    mnuScale.Checked = true;
                    break;
                case eMOUSEMODE.eView:
                    mnuView.Checked = true;
                    break;
            }

        }
         * */
        #endregion 
        #region DLP Screen Controls
        private void showBlankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDLPScreen();
            Screen dlpscreen = GetDLPScreen();
            UVDLPApp.Instance().m_buildmgr.ShowBlank(dlpscreen.Bounds.Width, dlpscreen.Bounds.Height);
        }

        private void showCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_buildparms.UpdateFrom(UVDLPApp.Instance().m_printerinfo);
            ShowDLPScreen();
            Screen dlpscreen = GetDLPScreen();
            UVDLPApp.Instance().m_buildmgr.ShowCalibration(dlpscreen.Bounds.Width,dlpscreen.Bounds.Height,UVDLPApp.Instance().m_buildparms);
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frmdlp.Hide();    
        }

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
        private bool ShowDLPScreen()
        {
            try
            {
                Screen dlpscreen = GetDLPScreen();
                if (m_frmdlp.IsDisposed)
                {
                    m_frmdlp = new frmDLP();//recreate
                }
                m_frmdlp.Show();
                m_frmdlp.SetDesktopBounds(dlpscreen.Bounds.X, dlpscreen.Bounds.Y, dlpscreen.Bounds.Width, dlpscreen.Bounds.Height);
                m_frmdlp.WindowState = FormWindowState.Maximized;
                m_frmdlp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
        
        #endregion DLP screen controls

        private void cmdPause_Click_1(object sender, EventArgs e)
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // remove all supports
            //iterate through objects, remove all supports
            UVDLPApp.Instance().RemoveAllSupports();
            SetupSceneTree();
        }

        private void chkAlpha_CheckedChanged(object sender, EventArgs e)
        {
            //if (UVDLPApp.Instance().m_selectedobject == null) return;
            //UVDLPApp.Instance().m_selectedobject.m_showalpha = chkAlpha.Checked;
            SetAlpha(chkAlpha.Checked);
            UVDLPApp.Instance().m_engine3d.UpdateLists();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");            
        }

        private void cmdLoadGCode_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "GCode Files(*.gcode)|*.gcode|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UVDLPApp.Instance().LoadGCode(openFileDialog1.FileName);
                   // txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void cmdScaleX_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float sfx = Single.Parse(txtScaleX.Text);
                UVDLPApp.Instance().SelectedObject.Scale(sfx,1,1);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception)
            {

            }
        }

        private void cmdScaleY_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float sfy = Single.Parse(txtScaleY.Text);
                UVDLPApp.Instance().SelectedObject.Scale(1, sfy, 1);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception)
            {

            }
        }

        private void cmdScaleZ_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float sfz = Single.Parse(txtScaleZ.Text);
                UVDLPApp.Instance().SelectedObject.Scale( 1, 1, sfz);
                ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception)
            {

            }
        }
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrefs prefs = new frmPrefs();
            prefs.ShowDialog();

        }

        private void glControl1_DoubleClick(object sender, EventArgs e)
        {
            // the screen was double clicked
            // do object selection
               MouseEventArgs me = e as MouseEventArgs;
               MouseButtons buttonPushed = me.Button;
               int xPos = me.X;
               int yPos = me.Y;
               List<ISectData> isects = TestHitTest(xPos, yPos);
               if (isects.Count > 0) 
               {
                   ISectData i = (ISectData)isects[0];
                   UVDLPApp.Instance().SelectedObject = i.obj;
                   UVDLPApp.Instance().m_engine3d.UpdateLists();
               }
        }

        private void glControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            // if the delete key is pressed, deleted the currently selected object 
            if (e.KeyCode == Keys.Delete)
            {
                UVDLPApp.Instance().RemoveCurrentModel();
            }
            if (e.KeyCode == Keys.ShiftKey) 
            {
                m_movingobjectmode = true;
            }
        }

        private void glControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                m_movingobjectmode = false;
                //redraw the scene graph
                SetupSceneTree();
            }
        }

        private void ctlSupport1_Load(object sender, EventArgs e)
        {

        }
        private void SetVScroll(int val) 
        {
            try
            {
                vScrollBar1.Value = val;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        
        }
        private void cmdViewLayer_Click(object sender, EventArgs e)
        {
            try
            {
                int layer = int.Parse(txtLayerNum.Text);
                //ViewLayer(layer, null, BuildManager.SLICE_NORMAL);
                //vScrollBar1_ValueChanged
                SetVScroll(layer);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void tabMachineControl_Enter(object sender, EventArgs e)
        {
            ctlMachineControl1.UpdateControl(); // update control display -SHS
        }

        private void estimateVolumeCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVolEst frmvol = new frmVolEst();
           // UVDLPApp.Instance().m_estimator.Setup(UVDLPApp.Instance().m_slicefile, UVDLPApp.Instance().m_buildparms);
            frmvol.ShowDialog();
        }
    }
}
