using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;
using Engine3D;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using UV_DLP_3D_Printer._3DEngine;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctl3DView : UserControl
    {

        bool m_movingobjectmode = false; // for moving objects while the shift key is held down
        ctlImageButton m_pressedButt = null;
        Control m_selectedControl = null;
        System.Timers.Timer m_modelAnimTmr;
        GLCamera m_camera;
        bool loaded = false;
        float m_ix = 0.0f, m_iy = 0.0f, m_iz = 2.0f;
        Slice m_curslice = null; // for previewing only
        private bool lmdown, rmdown, mmdown;
        private int mdx, mdy;
        IGraphicsContext m_context = null;
        OpenTK.Matrix4 m_projection;
        OpenTK.Matrix4 m_modelView;
        OpenTK.Matrix4 m_ortho;
        OpenTK.Matrix4 m_2dView;
        private bool firstTime = true;

        public Form m_splash = null;

        public ctl3DView()
        {
            InitializeComponent();

            SetupSceneTree();
            m_modelAnimTmr = null;
            m_camera = new GLCamera();
            ResetCameraView();

            ctlViewOptions.TreeViewHolder = mainViewSplitContainer;
            ctlViewOptions.LayerNumberScroll = numLayer;
            ctlViewOptions.ObjectInfoPanel = objectInfoPanel;
            mainViewSplitContainer.Panel1Collapsed = true;
        }

        public void SetMessagePanelHolder(SplitContainer holder)
        {
            ctlViewOptions.MessagePanelHolder = holder;
        }

        public void Enable3dView(bool isEnable)
        {
            glControl1.Enabled = isEnable;
            glControl1.Visible = isEnable;
        }

        public void SetNumLayers(int val)
        {
            if (val < 0)
                val = 0;
            if (UVDLPApp.Instance().m_appconfig.m_viewslice3d && (val > 0))
            {
                numLayer.MaxInt = val;
                numLayer.IntVal = 1;
                numLayer.Visible = true;
            }
            else
                numLayer.Visible = false;
            ViewLayer(0);
        }

        public void UpdateObjectInfo()
        {
            objectInfoPanel.FillObjectInfo(UVDLPApp.Instance().SelectedObject);
        }
        
        #region GL Rendering
        // handle 3d view rendering 
        public void ResetCameraView()
        {
            m_camera.ResetView(0, -200, 0, 20, 20);
           // glControl1.Invalidate();            
            UpdateView();
        }

        public void UpdateView()
        {
            //glControl1.Invalidate();
            DisplayFunc();
        }

        private void SetupForMachineType()
        {
            MachineConfig mc = UVDLPApp.Instance().m_printerinfo;
            m_camera.UpdateBuildVolume((float)mc.m_PlatXSize, (float)mc.m_PlatYSize, (float)mc.m_PlatZSize);
        }

        protected void Set2DView()
        {
            GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            GL.LoadMatrix(ref m_ortho);
            GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
            GL.LoadMatrix(ref m_2dView);
        }

        protected void Set3DView()
        {
            GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            GL.LoadMatrix(ref m_projection);
            GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
            GL.LoadMatrix(ref m_modelView);
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

                GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
                aspect = ((float)glControl1.Width) / ((float)glControl1.Height);

                SetAlpha(false); // start off with alpha off

                GL.Enable(EnableCap.CullFace); // enable culling of faces
                GL.CullFace(CullFaceMode.Back); // specify culling backfaces               

                m_projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(0.55f, aspect, 1, 2000);
                m_modelView = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(5, 0, -5), new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector3(0, 0, 1));
                
                m_ortho = OpenTK.Matrix4.CreateOrthographicOffCenter(0, w, 0, h, 1, 2000);
                m_2dView = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(0, 0, 10), new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector3(0, 1, 0));

                GL.ShadeModel(ShadingModel.Smooth); // tell it to shade smoothly

                // properties of materials
                GL.Enable(EnableCap.ColorMaterial); // allow polys to have color
                float[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
                float[] mat_shininess = { 50.0f };
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
                if (firstTime)
                {
                    GL.Enable(EnableCap.Lighting);
                    GL.Enable(EnableCap.Light0);
                    float[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
                    GL.Light(LightName.Light0, LightParameter.Position, light_position);
                    GL.Light(LightName.Light0, LightParameter.Diffuse, Color.LightGray);
                }
                Set3DView();

                firstTime = false;
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
            if (!loaded)
                return;

            if (val == true)
            {
                GL.Disable(EnableCap.DepthTest); // need to disable z buffering for proper display
                GL.Enable(EnableCap.AlphaTest);
                //GL.Disable(EnableCap.CullFace); // enable culling of faces
            }
            else
            {
                //GL.Enable(EnableCap.CullFace); // enable culling of faces
                GL.Disable(EnableCap.AlphaTest);
                GL.Enable(EnableCap.DepthTest); // for z buffer        
            }
        }

        // draw the intersection of the current mouse point into the scene
        private void DrawISect()
        {
            // draw some lines
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Red);
            GL.LineWidth(50);
            GL.Vertex3(m_ix - 5, m_iy, m_iz);
            GL.Vertex3(m_ix + 5, m_iy, m_iz);

            GL.End();

            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Red);
            GL.LineWidth(50);
            GL.Vertex3(m_ix, m_iy - 5, m_iz);
            GL.Vertex3(m_ix, m_iy + 5, m_iz);
            GL.End();
        }

        void DrawBackground()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            Set2DView();
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.DepthTest);
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.LightBlue);
            GL.Vertex3(0, 0, 0);
            GL.Color3(Color.SkyBlue);
            GL.Vertex3(w, 0, 0);
            GL.Color3(Color.AliceBlue);
            GL.Vertex3(w, h, 0);
            GL.Color3(Color.AliceBlue);
            GL.Vertex3(0, h, 0);
            GL.End();
            if (!UVDLPApp.Instance().m_engine3d.m_alpha)
                GL.Enable(EnableCap.DepthTest); 
            GL.Enable(EnableCap.Lighting);

            //SetAlpha(m_showalpha);
            Set3DView();
        }

        private void DisplayFunc()
        {
            if (!loaded)
                return;

            glControl1.MakeCurrent();

            /* Clear the buffer, clear the matrix */
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            //GL.LoadIdentity(); // assuming we're in the model matrix still
            SetAlpha(UVDLPApp.Instance().m_engine3d.m_alpha);
            DrawBackground();
            m_camera.SetViewGL();

            UVDLPApp.Instance().Engine3D.RenderGL();
            DrawISect();
            Render3dSlice();
            GL.Flush();
            glControl1.SwapBuffers();
        }

        private void Render3dSlice()
        {
            if (m_curslice == null)
                return;
            if (UVDLPApp.Instance().m_appconfig.m_viewslice3d == false)
                return;
            if (m_curslice.m_opsegs == null)
            {
                m_curslice.Optimize();
                m_curslice.ColorLines();
            }
            foreach (PolyLine3d ply in m_curslice.m_opsegs)
            {
                ply.RenderGL();
            }
        }

        private List<ISectData> TestHitTest(int X, int Y)
        {
            if (!loaded)
                return null;
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

            int window_y = (h - Y) - h / 2;
            double norm_y = (double)(window_y) / (double)(h / 2);
            int window_x = X - w / 2;
            double norm_x = (double)(window_x) / (double)(w / 2);
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

            //mess += "Eye Pick Vec =  (" + String.Format("{0:0.00}", ray_vec.X) + ", " + String.Format("{0:0.00}", ray_vec.Y) + "," + String.Format("{0:0.00}", ray_vec.Z) + ")\r\n";

            Matrix4 modelViewMatrix;
            GL.GetFloat(GetPName.ModelviewMatrix, out modelViewMatrix);
            Matrix4 viewInv = Matrix4.Invert(modelViewMatrix);

            Vector4 t_ray_pnt = new Vector4();
            Vector4 t_ray_vec = new Vector4();

            Vector4.Transform(ref ray_vec, ref viewInv, out t_ray_vec);
            Vector4.Transform(ref ray_pnt, ref viewInv, out t_ray_pnt);
            //mess += "World Pick Vec =  (" + String.Format("{0:0.00}", t_ray_vec.X) + ", " + String.Format("{0:0.00}", t_ray_vec.Y) + "," + String.Format("{0:0.00}", t_ray_vec.Z) + ")\r\n";
            //mess += "World Pick Pnt =  (" + String.Format("{0:0.00}", t_ray_pnt.X) + ", " + String.Format("{0:0.00}", t_ray_pnt.Y) + "," + String.Format("{0:0.00}", t_ray_pnt.Z) + ")\r\n";

            Point3d origin = new Point3d();
            Point3d intersect = new Point3d();
            Engine3D.Vector3d dir = new Engine3D.Vector3d();

            origin.Set(t_ray_pnt.X, t_ray_pnt.Y, t_ray_pnt.Z);
            dir.Set(t_ray_vec.X, t_ray_vec.Y, t_ray_vec.Z); // should this be scaled?

            List<ISectData> isects = RTUtils.IntersectObjects(dir, origin, UVDLPApp.Instance().Engine3D.m_objects, true);
            if (isects.Count > 0)
            {

                foreach (ISectData isect in isects)
                {
                    if (!float.IsNaN(isect.intersect.x)) // check for NaN
                    {
                        m_ix = (float)isect.intersect.x; // show the closest
                        m_iy = (float)isect.intersect.y;
                        m_iz = (float)isect.intersect.z;
                        break;
                    }
                }

                //ISectData isect = (ISectData)isects[0]; // get the first
                // check for NaN

            }

            return isects;
        }

        #endregion GL Rendering


        #region GL control events
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

        private void glControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

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

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            m_context = glControl1.Context;
            glControl1.MouseWheel += new MouseEventHandler(glControl1_MouseWheel);
            SetupViewport();
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mdx = e.X;
            mdy = e.Y;
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    mmdown = true;
                }

                if (e.Button == MouseButtons.Left)
                {
                    lmdown = true;
                    // I saw m_ix and m_iy were 'NaN'
                    // this means that the intersection failed somehow
                    m_camera.UpdateDirection(m_ix, m_iy);
                }
                if (e.Button == MouseButtons.Right)
                {
                    rmdown = true;
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void glControl1_MouseLeave(object sender, EventArgs e)
        {
            //should cancel any move commands
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            List<ISectData> hits = TestHitTest(e.X, e.Y);
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
                m_camera.RotateRightFlat((float)dx);
                m_camera.RotateUp((float)dy);
            }
            else if (mmdown)
            {
                m_camera.MoveForward((float)dy);
            }
            else if (rmdown)
            {
                m_camera.Move((float)dx, (float)dy);
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
                        pnt.Set(tmpsup.m_center.x, tmpsup.m_center.y, 0);
                        Engine3D.Vector3d vec = new Engine3D.Vector3d();
                        vec.Set(0, 0, 1); // create a vector striaght up
                        // hit test from the selected objects center x/y/0 position straight up
                        //see if it hits any object in the scene,
                        // if it does, scale the object from the ground plane to the closest intersection point
                        List<ISectData> iss = RTUtils.IntersectObjects(vec, pnt, UVDLPApp.Instance().Engine3D.m_objects, false);
                        foreach (ISectData htd in iss)
                        {
                            if (htd.obj.tag != Object3d.OBJ_SUPPORT)  // if this is not another support or the ground
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
            //glControl1.Invalidate();
            UpdateView();
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

        void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            m_camera.MoveForward(e.Delta / 10);
            //glControl1.Invalidate();
            UpdateView();
        }
        
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (m_splash != null)
                return;
            DisplayFunc();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            SetupViewport();
            //glControl1.Invalidate();
            UpdateView();
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
            // find the first object that's not the ground
            // this will allow us to select an object from the bottom.
            foreach (ISectData i in isects)
            {
                if (i.obj.tag != Object3d.OBJ_GROUND)
                {
                    UVDLPApp.Instance().SelectedObject = i.obj;
                    objectInfoPanel.FillObjectInfo(i.obj);
                    UVDLPApp.Instance().m_engine3d.UpdateLists();
                    break;
                }
            }
            /*
               if (isects.Count > 0) 
               {
                   ISectData i = (ISectData)isects[0];
                   UVDLPApp.Instance().SelectedObject = i.obj;
                   UVDLPApp.Instance().m_engine3d.UpdateLists();
               }
             * */
        }

        private void ctl3DView_Load(object sender, EventArgs e)
        {
            SetupForMachineType();
            Invalidate(true);
        }

        private void mainViewSplitContainer_Panel2_SizeChanged(object sender, EventArgs e)
        {
            // update inner control positions
            foreach (Control ctl in mainViewSplitContainer.Panel2.Controls)
            {
                if (ctl.GetType().IsSubclassOf(typeof(ctlAnchorable)))
                    ((ctlAnchorable)ctl).UpdatePosition();
            }

        }

        #endregion GL control events

        #region 3d View buttons
        private void buttGlHome_Click(object sender, EventArgs e)
        {
            if (m_modelAnimTmr != null)
                return;
            m_camera.ResetViewAnim(0, -200, 0, 20, 20);
            m_modelAnimTmr = new System.Timers.Timer(25);
            m_modelAnimTmr.Elapsed += new ElapsedEventHandler(ModelAnimTimerElapsed);
            m_modelAnimTmr.AutoReset = true;
            m_modelAnimTmr.Start();
        }

        void ModelAnimTimerElapsed(Object sender, ElapsedEventArgs args)
        {
            if (m_camera.AnimTick() == false)
            {
                m_modelAnimTmr.Stop();
                m_modelAnimTmr = null;
            }
            glControl1.Invalidate();
        }

        private void ShowPanel(ctlImageButton butt, Control ctl)
        {
            if (ctl == m_selectedControl)
            {
                butt.Gapx -= 5;
                m_pressedButt = null;
                ctl.Visible = false;
                m_selectedControl = null;
            }
            else
            {
                if (m_selectedControl != null)
                {
                    m_pressedButt.Gapx -= 5;
                    m_selectedControl.Visible = false;
                }
                m_pressedButt = butt;
                m_selectedControl = ctl;
                butt.Gapx += 5;
                ctl.Location = new Point(butt.Location.X + butt.Width,
                    butt.Location.Y + butt.Height - ctl.Height);
                ctl.Visible = true;
            }
        }
        
        private void buttView_Click(object sender, EventArgs e)
        {
            ShowPanel(buttView, ctlViewOptions);
        }

        private void buttSupports_Click(object sender, EventArgs e)
        {
            ShowPanel(buttSupports, ctlSupport);
        }

        private void buttMove_Click(object sender, EventArgs e)
        {
            ShowPanel(buttMove, ctlObjMove);
        }

        private void buttRotate_Click(object sender, EventArgs e)
        {
            ShowPanel(buttRotate, ctlObjRotate);
        }

        private void buttScale_Click(object sender, EventArgs e)
        {
            ShowPanel(buttScale, ctlObjScale);
        }
        #endregion 3d View buttons


        #region 3d View controls

        public void ViewLayer(int layer)
        {
            try
            {
                if (UVDLPApp.Instance().m_appconfig.m_viewslice3d == true)
                {
                    m_curslice = UVDLPApp.Instance().m_slicefile.GetSlice(layer);
                    if (m_curslice != null)
                    {
                        //UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");

                        UpdateView();//glControl1.Invalidate();
                    }
                }
                else
                {
                    m_curslice = null;
                }

            }
            catch (Exception) 
            {
                m_curslice = null;
            }

        }
        
        private void numLayer_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int vscrollval = numLayer.IntVal - 1;
                numLayer.Refresh(); // redraw this
                ViewLayer(vscrollval);
            }
            catch (Exception)
            {
                // probably past the max.
            }
        }

        #endregion 3d View controls


        #region Scene tree

        public void UpdateSceneTree()
        {
            SetupSceneTree();
        }

        private void SetupSceneTree()
        {
            treeScene.Nodes.Clear();//clear the old

            TreeNode scenenode = new TreeNode("Scene");
            treeScene.Nodes.Add(scenenode);
            TreeNode support3d = new TreeNode("3d Supports");
            treeScene.Nodes.Add(support3d);
            TreeNode selNode = null;

            foreach (Object3d obj in UVDLPApp.Instance().Engine3D.m_objects)
            {
                if (obj.tag == Object3d.OBJ_SUPPORT)
                {
                    TreeNode objnode = new TreeNode(obj.Name);
                    objnode.Tag = obj;
                    support3d.Nodes.Add(objnode);
                    if (obj == UVDLPApp.Instance().SelectedObject)  // expand this node
                    {
                        //objnode.BackColor = Color.LightBlue;
                        //treeScene.SelectedNode = objnode;
                        selNode = objnode;
                    }
                }
                else
                {
                    TreeNode objnode = new TreeNode(obj.Name);
                    objnode.Tag = obj;
                    scenenode.Nodes.Add(objnode);
                    if (obj == UVDLPApp.Instance().SelectedObject)  // expand this node
                    {
                        //objnode.BackColor = Color.LightBlue;
                        //treeScene.SelectedNode = objnode;
                        selNode = objnode;
                    }
                }
            }
            if (selNode != null)
                selNode.BackColor = Color.Green;
            scenenode.Expand();
            treeScene.SelectedNode = selNode;
        }

        private void cmdRemoveObject_Click(object sender, EventArgs e)
        {
            // delete the current selected object
            if (UVDLPApp.Instance().SelectedObject != null)
            {
                UVDLPApp.Instance().RemoveCurrentModel();
            }
        }

        private void cmdRemoveAllSupports_Click(object sender, EventArgs e)
        {
            // remove all supports
            //iterate through objects, remove all supports
            UVDLPApp.Instance().RemoveAllSupports();
            SetupSceneTree();
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
                objectInfoPanel.FillObjectInfo(UVDLPApp.Instance().SelectedObject);
                SetupSceneTree();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)  // we right clicked a menu item, check and see if it has a tag
            {
                if (e.Node.Text.Equals("3d Supports"))
                {
                    contextMenuSupport.Show(treeScene, e.Node.Bounds.Left, e.Node.Bounds.Top);
                }
                else
                {
                    if (e.Node.Tag != null)
                    {
                        contextMenuObject.Show(treeScene, e.Node.Bounds.Left, e.Node.Bounds.Top);
                    }
                }
            }

            #endregion Scene tree

        }


 
    }
}
