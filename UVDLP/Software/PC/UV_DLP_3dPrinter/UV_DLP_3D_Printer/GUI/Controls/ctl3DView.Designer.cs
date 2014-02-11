namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctl3DView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctl3DView));
            this.mainViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.textTime = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlText();
            this.textMainMessage = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlText();
            this.buttViewSlice = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttViewGcode = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttConfig = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttSlice = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttDisconnect = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttConnect = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttStop = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttPause = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttPlay = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttOpenFile = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.textProgress = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlText();
            this.ctlScene1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlScene();
            this.ctlMeshTools1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlMeshTools();
            this.buttMeshTools = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttRedo = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttUndo = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.objectInfoPanel = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlObjectInfo();
            this.numLayer = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.buttGlHome = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttView = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlViewOptions = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlView();
            this.buttScale = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttMove = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlSupport = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlSupports();
            this.buttSupports = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlObjRotate = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlRotate();
            this.buttRotate = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlObjScale = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlScale();
            this.ctlObjMove = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlMove();
            this.glControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlGL();
            this.ctlToolTip1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlToolTip();
            this.mainViewSplitContainer.Panel2.SuspendLayout();
            this.mainViewSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainViewSplitContainer
            // 
            this.mainViewSplitContainer.BackColor = System.Drawing.Color.RoyalBlue;
            this.mainViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainViewSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainViewSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.mainViewSplitContainer.Name = "mainViewSplitContainer";
            // 
            // mainViewSplitContainer.Panel2
            // 
            this.mainViewSplitContainer.Panel2.Controls.Add(this.textTime);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.textMainMessage);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttViewSlice);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttViewGcode);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttConfig);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttSlice);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttDisconnect);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttConnect);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttStop);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttPause);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttPlay);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttOpenFile);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.textProgress);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.ctlScene1);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.ctlMeshTools1);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttMeshTools);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttRedo);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttUndo);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.objectInfoPanel);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.numLayer);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttGlHome);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttView);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.ctlViewOptions);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttScale);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttMove);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.ctlSupport);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttSupports);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.ctlObjRotate);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttRotate);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.ctlObjScale);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.ctlObjMove);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.glControl1);
            this.mainViewSplitContainer.Panel2.SizeChanged += new System.EventHandler(this.mainViewSplitContainer_Panel2_SizeChanged);
            this.mainViewSplitContainer.Size = new System.Drawing.Size(1122, 550);
            this.mainViewSplitContainer.SplitterDistance = 160;
            this.mainViewSplitContainer.TabIndex = 28;
            // 
            // textTime
            // 
            this.textTime.BackColor = System.Drawing.Color.Transparent;
            this.textTime.Gapx = 0;
            this.textTime.Gapy = 0;
            this.textTime.GLBackgroundImage = null;
            this.textTime.GLFont = "Arial18";
            this.textTime.GLVisible = false;
            this.textTime.GuiAnchor = null;
            this.textTime.Location = new System.Drawing.Point(443, 380);
            this.textTime.Name = "textTime";
            this.textTime.Size = new System.Drawing.Size(102, 26);
            this.textTime.StyleName = null;
            this.textTime.TabIndex = 46;
            this.textTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textMainMessage
            // 
            this.textMainMessage.Gapx = 0;
            this.textMainMessage.Gapy = 0;
            this.textMainMessage.GLBackgroundImage = null;
            this.textMainMessage.GLFont = "Arial18";
            this.textMainMessage.GLVisible = false;
            this.textMainMessage.GuiAnchor = null;
            this.textMainMessage.Location = new System.Drawing.Point(443, 336);
            this.textMainMessage.Name = "textMainMessage";
            this.textMainMessage.Size = new System.Drawing.Size(102, 26);
            this.textMainMessage.StyleName = null;
            this.textMainMessage.TabIndex = 45;
            this.textMainMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttViewSlice
            // 
            this.buttViewSlice.BackColor = System.Drawing.Color.Navy;
            this.buttViewSlice.Checked = false;
            this.buttViewSlice.CheckImage = null;
            this.buttViewSlice.Gapx = 10;
            this.buttViewSlice.Gapy = 10;
            this.buttViewSlice.GLBackgroundImage = null;
            this.buttViewSlice.GLImage = null;
            this.buttViewSlice.GLVisible = false;
            this.buttViewSlice.GuiAnchor = null;
            this.buttViewSlice.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttViewSlice.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewSlice;
            this.buttViewSlice.Location = new System.Drawing.Point(842, 15);
            this.buttViewSlice.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttViewSlice.Name = "buttViewSlice";
            this.buttViewSlice.Size = new System.Drawing.Size(48, 48);
            this.buttViewSlice.StyleName = null;
            this.buttViewSlice.TabIndex = 44;
            this.ctlToolTip1.SetToolTip(this.buttViewSlice, "Slice view");
            this.buttViewSlice.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttViewSlice.Visible = false;
            this.buttViewSlice.Click += new System.EventHandler(this.buttViewSlice_Click);
            // 
            // buttViewGcode
            // 
            this.buttViewGcode.BackColor = System.Drawing.Color.Navy;
            this.buttViewGcode.Checked = false;
            this.buttViewGcode.CheckImage = null;
            this.buttViewGcode.Gapx = 10;
            this.buttViewGcode.Gapy = 10;
            this.buttViewGcode.GLBackgroundImage = null;
            this.buttViewGcode.GLImage = null;
            this.buttViewGcode.GLVisible = false;
            this.buttViewGcode.GuiAnchor = null;
            this.buttViewGcode.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttViewGcode.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewGcode;
            this.buttViewGcode.Location = new System.Drawing.Point(900, 490);
            this.buttViewGcode.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttViewGcode.Name = "buttViewGcode";
            this.buttViewGcode.Size = new System.Drawing.Size(48, 48);
            this.buttViewGcode.StyleName = null;
            this.buttViewGcode.TabIndex = 43;
            this.ctlToolTip1.SetToolTip(this.buttViewGcode, "G-code view");
            this.buttViewGcode.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttViewGcode.Visible = false;
            this.buttViewGcode.Click += new System.EventHandler(this.buttViewGcode_Click);
            // 
            // buttConfig
            // 
            this.buttConfig.BackColor = System.Drawing.Color.Navy;
            this.buttConfig.Checked = false;
            this.buttConfig.CheckImage = null;
            this.buttConfig.Gapx = 10;
            this.buttConfig.Gapy = 10;
            this.buttConfig.GLBackgroundImage = null;
            this.buttConfig.GLImage = null;
            this.buttConfig.GLVisible = false;
            this.buttConfig.GuiAnchor = null;
            this.buttConfig.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttConfig.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttGear;
            this.buttConfig.Location = new System.Drawing.Point(900, 432);
            this.buttConfig.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.buttConfig.Name = "buttConfig";
            this.buttConfig.Size = new System.Drawing.Size(48, 48);
            this.buttConfig.StyleName = null;
            this.buttConfig.TabIndex = 42;
            this.ctlToolTip1.SetToolTip(this.buttConfig, "Configuration");
            this.buttConfig.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttConfig.Visible = false;
            this.buttConfig.Click += new System.EventHandler(this.buttConfig_Click);
            // 
            // buttSlice
            // 
            this.buttSlice.BackColor = System.Drawing.Color.Navy;
            this.buttSlice.Checked = false;
            this.buttSlice.CheckImage = null;
            this.buttSlice.Gapx = 10;
            this.buttSlice.Gapy = 10;
            this.buttSlice.GLBackgroundImage = null;
            this.buttSlice.GLImage = null;
            this.buttSlice.GLVisible = false;
            this.buttSlice.GuiAnchor = null;
            this.buttSlice.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttSlice.Image = ((System.Drawing.Image)(resources.GetObject("buttSlice.Image")));
            this.buttSlice.Location = new System.Drawing.Point(900, 376);
            this.buttSlice.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttSlice.Name = "buttSlice";
            this.buttSlice.Size = new System.Drawing.Size(48, 48);
            this.buttSlice.StyleName = null;
            this.buttSlice.TabIndex = 41;
            this.ctlToolTip1.SetToolTip(this.buttSlice, "Slice!");
            this.buttSlice.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttSlice.Visible = false;
            this.buttSlice.Click += new System.EventHandler(this.buttSlice_Click);
            // 
            // buttDisconnect
            // 
            this.buttDisconnect.BackColor = System.Drawing.Color.Navy;
            this.buttDisconnect.Checked = false;
            this.buttDisconnect.CheckImage = null;
            this.buttDisconnect.Gapx = 10;
            this.buttDisconnect.Gapy = 10;
            this.buttDisconnect.GLBackgroundImage = null;
            this.buttDisconnect.GLImage = null;
            this.buttDisconnect.GLVisible = false;
            this.buttDisconnect.GuiAnchor = null;
            this.buttDisconnect.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttDisconnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttDisconnect;
            this.buttDisconnect.Location = new System.Drawing.Point(900, 320);
            this.buttDisconnect.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.buttDisconnect.Name = "buttDisconnect";
            this.buttDisconnect.Size = new System.Drawing.Size(48, 48);
            this.buttDisconnect.StyleName = null;
            this.buttDisconnect.TabIndex = 40;
            this.ctlToolTip1.SetToolTip(this.buttDisconnect, "Disconnect");
            this.buttDisconnect.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttDisconnect.Visible = false;
            this.buttDisconnect.Click += new System.EventHandler(this.buttDisconnect_Click);
            // 
            // buttConnect
            // 
            this.buttConnect.BackColor = System.Drawing.Color.Navy;
            this.buttConnect.Checked = false;
            this.buttConnect.CheckImage = null;
            this.buttConnect.Gapx = 10;
            this.buttConnect.Gapy = 10;
            this.buttConnect.GLBackgroundImage = null;
            this.buttConnect.GLImage = null;
            this.buttConnect.GLVisible = false;
            this.buttConnect.GuiAnchor = null;
            this.buttConnect.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttConnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttConnect;
            this.buttConnect.Location = new System.Drawing.Point(900, 255);
            this.buttConnect.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttConnect.Name = "buttConnect";
            this.buttConnect.Size = new System.Drawing.Size(48, 48);
            this.buttConnect.StyleName = null;
            this.buttConnect.TabIndex = 39;
            this.ctlToolTip1.SetToolTip(this.buttConnect, "Connect");
            this.buttConnect.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttConnect.Visible = false;
            this.buttConnect.Click += new System.EventHandler(this.buttConnect_Click);
            // 
            // buttStop
            // 
            this.buttStop.BackColor = System.Drawing.Color.Navy;
            this.buttStop.Checked = false;
            this.buttStop.CheckImage = null;
            this.buttStop.Gapx = 10;
            this.buttStop.Gapy = 10;
            this.buttStop.GLBackgroundImage = null;
            this.buttStop.GLImage = null;
            this.buttStop.GLVisible = false;
            this.buttStop.GuiAnchor = null;
            this.buttStop.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttStop.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttStop;
            this.buttStop.Location = new System.Drawing.Point(900, 191);
            this.buttStop.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.buttStop.Name = "buttStop";
            this.buttStop.Size = new System.Drawing.Size(48, 48);
            this.buttStop.StyleName = null;
            this.buttStop.TabIndex = 38;
            this.ctlToolTip1.SetToolTip(this.buttStop, "Stop build process");
            this.buttStop.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttStop.Visible = false;
            this.buttStop.Click += new System.EventHandler(this.buttStop_Click);
            // 
            // buttPause
            // 
            this.buttPause.BackColor = System.Drawing.Color.Navy;
            this.buttPause.Checked = false;
            this.buttPause.CheckImage = null;
            this.buttPause.Gapx = 10;
            this.buttPause.Gapy = 10;
            this.buttPause.GLBackgroundImage = null;
            this.buttPause.GLImage = null;
            this.buttPause.GLVisible = false;
            this.buttPause.GuiAnchor = null;
            this.buttPause.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttPause.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPause;
            this.buttPause.Location = new System.Drawing.Point(900, 135);
            this.buttPause.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttPause.Name = "buttPause";
            this.buttPause.Size = new System.Drawing.Size(48, 48);
            this.buttPause.StyleName = null;
            this.buttPause.TabIndex = 37;
            this.ctlToolTip1.SetToolTip(this.buttPause, "Pause build process");
            this.buttPause.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttPause.Visible = false;
            this.buttPause.Click += new System.EventHandler(this.buttPause_Click);
            // 
            // buttPlay
            // 
            this.buttPlay.BackColor = System.Drawing.Color.Navy;
            this.buttPlay.Checked = false;
            this.buttPlay.CheckImage = null;
            this.buttPlay.Gapx = 10;
            this.buttPlay.Gapy = 10;
            this.buttPlay.GLBackgroundImage = null;
            this.buttPlay.GLImage = null;
            this.buttPlay.GLVisible = false;
            this.buttPlay.GuiAnchor = null;
            this.buttPlay.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttPlay.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPlay;
            this.buttPlay.Location = new System.Drawing.Point(900, 79);
            this.buttPlay.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttPlay.Name = "buttPlay";
            this.buttPlay.Size = new System.Drawing.Size(48, 48);
            this.buttPlay.StyleName = null;
            this.buttPlay.TabIndex = 36;
            this.ctlToolTip1.SetToolTip(this.buttPlay, "Build!");
            this.buttPlay.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttPlay.Visible = false;
            this.buttPlay.Click += new System.EventHandler(this.buttPlay_Click);
            // 
            // buttOpenFile
            // 
            this.buttOpenFile.BackColor = System.Drawing.Color.Navy;
            this.buttOpenFile.Checked = false;
            this.buttOpenFile.CheckImage = null;
            this.buttOpenFile.Gapx = 10;
            this.buttOpenFile.Gapy = 10;
            this.buttOpenFile.GLBackgroundImage = null;
            this.buttOpenFile.GLImage = null;
            this.buttOpenFile.GLVisible = false;
            this.buttOpenFile.GuiAnchor = null;
            this.buttOpenFile.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttOpenFile.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenFile;
            this.buttOpenFile.Location = new System.Drawing.Point(900, 15);
            this.buttOpenFile.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.buttOpenFile.Name = "buttOpenFile";
            this.buttOpenFile.Size = new System.Drawing.Size(48, 48);
            this.buttOpenFile.StyleName = null;
            this.buttOpenFile.TabIndex = 35;
            this.ctlToolTip1.SetToolTip(this.buttOpenFile, "Load model");
            this.buttOpenFile.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttOpenFile.Visible = false;
            this.buttOpenFile.Click += new System.EventHandler(this.buttOpenFile_Click);
            // 
            // textProgress
            // 
            this.textProgress.BackColor = System.Drawing.Color.Transparent;
            this.textProgress.Gapx = 0;
            this.textProgress.Gapy = 0;
            this.textProgress.GLBackgroundImage = null;
            this.textProgress.GLFont = "Arial18";
            this.textProgress.GLVisible = false;
            this.textProgress.GuiAnchor = null;
            this.textProgress.Location = new System.Drawing.Point(452, 440);
            this.textProgress.Name = "textProgress";
            this.textProgress.Size = new System.Drawing.Size(76, 30);
            this.textProgress.StyleName = null;
            this.textProgress.TabIndex = 34;
            this.textProgress.Text = "79 %";
            // 
            // ctlScene1
            // 
            this.ctlScene1.Checked = false;
            this.ctlScene1.Gapx = 24;
            this.ctlScene1.Gapy = 100;
            this.ctlScene1.GLBackgroundImage = null;
            this.ctlScene1.GLVisible = false;
            this.ctlScene1.GuiAnchor = null;
            this.ctlScene1.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.ctlScene1.Location = new System.Drawing.Point(507, 47);
            this.ctlScene1.Name = "ctlScene1";
            this.ctlScene1.Size = new System.Drawing.Size(310, 297);
            this.ctlScene1.StyleName = null;
            this.ctlScene1.TabIndex = 33;
            this.ctlScene1.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.ctlScene1.Visible = false;
            // 
            // ctlMeshTools1
            // 
            this.ctlMeshTools1.BackColor = System.Drawing.Color.Navy;
            this.ctlMeshTools1.Gapx = 0;
            this.ctlMeshTools1.Gapy = 0;
            this.ctlMeshTools1.GLBackgroundImage = null;
            this.ctlMeshTools1.GLVisible = false;
            this.ctlMeshTools1.GuiAnchor = null;
            this.ctlMeshTools1.Location = new System.Drawing.Point(94, 282);
            this.ctlMeshTools1.Name = "ctlMeshTools1";
            this.ctlMeshTools1.Size = new System.Drawing.Size(343, 214);
            this.ctlMeshTools1.StyleName = null;
            this.ctlMeshTools1.TabIndex = 32;
            this.ctlMeshTools1.Visible = false;
            // 
            // buttMeshTools
            // 
            this.buttMeshTools.BackColor = System.Drawing.Color.Navy;
            this.buttMeshTools.Checked = false;
            this.buttMeshTools.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenClose;
            this.buttMeshTools.Gapx = 10;
            this.buttMeshTools.Gapy = 288;
            this.buttMeshTools.GLBackgroundImage = null;
            this.buttMeshTools.GLImage = null;
            this.buttMeshTools.GLVisible = false;
            this.buttMeshTools.GuiAnchor = null;
            this.buttMeshTools.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttMeshTools.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttMeshTools;
            this.buttMeshTools.Location = new System.Drawing.Point(10, 214);
            this.buttMeshTools.Name = "buttMeshTools";
            this.buttMeshTools.Size = new System.Drawing.Size(48, 48);
            this.buttMeshTools.StyleName = null;
            this.buttMeshTools.TabIndex = 31;
            this.ctlToolTip1.SetToolTip(this.buttMeshTools, "Mesh Tools");
            this.buttMeshTools.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttMeshTools.Click += new System.EventHandler(this.buttMeshTools_Click);
            // 
            // buttRedo
            // 
            this.buttRedo.BackColor = System.Drawing.Color.Navy;
            this.buttRedo.Checked = false;
            this.buttRedo.CheckImage = null;
            this.buttRedo.Gapx = 60;
            this.buttRedo.Gapy = 10;
            this.buttRedo.GLBackgroundImage = null;
            this.buttRedo.GLImage = null;
            this.buttRedo.GLVisible = false;
            this.buttRedo.GuiAnchor = null;
            this.buttRedo.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttRedo.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttRedo;
            this.buttRedo.Location = new System.Drawing.Point(15, 133);
            this.buttRedo.Name = "buttRedo";
            this.buttRedo.Size = new System.Drawing.Size(48, 48);
            this.buttRedo.StyleName = null;
            this.buttRedo.TabIndex = 30;
            this.ctlToolTip1.SetToolTip(this.buttRedo, "Undo");
            this.buttRedo.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            // 
            // buttUndo
            // 
            this.buttUndo.BackColor = System.Drawing.Color.Navy;
            this.buttUndo.Checked = false;
            this.buttUndo.CheckImage = null;
            this.buttUndo.Gapx = 10;
            this.buttUndo.Gapy = 10;
            this.buttUndo.GLBackgroundImage = null;
            this.buttUndo.GLImage = null;
            this.buttUndo.GLVisible = false;
            this.buttUndo.GuiAnchor = null;
            this.buttUndo.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttUndo.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttUndo;
            this.buttUndo.Location = new System.Drawing.Point(15, 79);
            this.buttUndo.Name = "buttUndo";
            this.buttUndo.Size = new System.Drawing.Size(48, 48);
            this.buttUndo.StyleName = null;
            this.buttUndo.TabIndex = 29;
            this.ctlToolTip1.SetToolTip(this.buttUndo, "Undo");
            this.buttUndo.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            // 
            // objectInfoPanel
            // 
            this.objectInfoPanel.Checked = false;
            this.objectInfoPanel.Gapx = 24;
            this.objectInfoPanel.Gapy = 24;
            this.objectInfoPanel.GLBackgroundImage = null;
            this.objectInfoPanel.GLVisible = false;
            this.objectInfoPanel.GuiAnchor = null;
            this.objectInfoPanel.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.objectInfoPanel.Location = new System.Drawing.Point(534, 286);
            this.objectInfoPanel.Name = "objectInfoPanel";
            this.objectInfoPanel.Size = new System.Drawing.Size(300, 240);
            this.objectInfoPanel.StyleName = null;
            this.objectInfoPanel.TabIndex = 28;
            this.objectInfoPanel.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.objectInfoPanel.Visible = false;
            // 
            // numLayer
            // 
            this.numLayer.BackColor = System.Drawing.Color.RoyalBlue;
            this.numLayer.ButtonsColor = System.Drawing.Color.Navy;
            this.numLayer.Checked = false;
            this.numLayer.EnableScroll = true;
            this.numLayer.ErrorColor = System.Drawing.Color.Red;
            this.numLayer.FloatVal = 10F;
            this.numLayer.Gapx = 0;
            this.numLayer.Gapy = 80;
            this.numLayer.GLBackgroundImage = null;
            this.numLayer.GLVisible = false;
            this.numLayer.GuiAnchor = null;
            this.numLayer.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Center;
            this.numLayer.Increment = 1F;
            this.numLayer.IntVal = 1000;
            this.numLayer.Location = new System.Drawing.Point(103, 514);
            this.numLayer.MaxFloat = 500F;
            this.numLayer.MaxInt = 1000;
            this.numLayer.MinFloat = -500F;
            this.numLayer.MinimumSize = new System.Drawing.Size(20, 5);
            this.numLayer.MinInt = 1;
            this.numLayer.Name = "numLayer";
            this.numLayer.Size = new System.Drawing.Size(425, 24);
            this.numLayer.StyleName = null;
            this.numLayer.TabIndex = 27;
            this.numLayer.TextFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numLayer.ValidColor = System.Drawing.Color.White;
            this.numLayer.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.numLayer.Visible = false;
            this.numLayer.ValueChanged += new System.EventHandler(this.numLayer_ValueChanged);
            // 
            // buttGlHome
            // 
            this.buttGlHome.BackColor = System.Drawing.Color.Transparent;
            this.buttGlHome.Checked = false;
            this.buttGlHome.CheckImage = null;
            this.buttGlHome.Gapx = 10;
            this.buttGlHome.Gapy = 10;
            this.buttGlHome.GLBackgroundImage = null;
            this.buttGlHome.GLImage = "glButtHome";
            this.buttGlHome.GLVisible = false;
            this.buttGlHome.GuiAnchor = null;
            this.buttGlHome.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttGlHome.Image = global::UV_DLP_3D_Printer.Properties.Resources.homeButt;
            this.buttGlHome.Location = new System.Drawing.Point(15, 15);
            this.buttGlHome.Name = "buttGlHome";
            this.buttGlHome.Size = new System.Drawing.Size(48, 48);
            this.buttGlHome.StyleName = null;
            this.buttGlHome.TabIndex = 16;
            this.ctlToolTip1.SetToolTip(this.buttGlHome, "Home");
            this.buttGlHome.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttGlHome.Click += new System.EventHandler(this.buttGlHome_Click);
            // 
            // buttView
            // 
            this.buttView.BackColor = System.Drawing.Color.Navy;
            this.buttView.Checked = false;
            this.buttView.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenClose;
            this.buttView.Gapx = 10;
            this.buttView.Gapy = 230;
            this.buttView.GLBackgroundImage = null;
            this.buttView.GLImage = null;
            this.buttView.GLVisible = false;
            this.buttView.GuiAnchor = null;
            this.buttView.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttView.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttView;
            this.buttView.Location = new System.Drawing.Point(10, 282);
            this.buttView.Name = "buttView";
            this.buttView.Size = new System.Drawing.Size(48, 48);
            this.buttView.StyleName = null;
            this.buttView.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.buttView, "View Options");
            this.buttView.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttView.Click += new System.EventHandler(this.buttView_Click);
            // 
            // ctlViewOptions
            // 
            this.ctlViewOptions.Gapx = 0;
            this.ctlViewOptions.Gapy = 0;
            this.ctlViewOptions.GLBackgroundImage = null;
            this.ctlViewOptions.GLVisible = false;
            this.ctlViewOptions.GuiAnchor = null;
            this.ctlViewOptions.LayerNumberScroll = null;
            this.ctlViewOptions.Location = new System.Drawing.Point(284, 117);
            this.ctlViewOptions.MessagePanelHolder = null;
            this.ctlViewOptions.Name = "ctlViewOptions";
            this.ctlViewOptions.ObjectInfoPanel = null;
            this.ctlViewOptions.SceneControl = null;
            this.ctlViewOptions.Size = new System.Drawing.Size(170, 186);
            this.ctlViewOptions.StyleName = null;
            this.ctlViewOptions.TabIndex = 26;
            this.ctlViewOptions.TreeViewHolder = null;
            this.ctlViewOptions.Visible = false;
            // 
            // buttScale
            // 
            this.buttScale.BackColor = System.Drawing.Color.Navy;
            this.buttScale.Checked = false;
            this.buttScale.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenClose;
            this.buttScale.Gapx = 10;
            this.buttScale.Gapy = 10;
            this.buttScale.GLBackgroundImage = null;
            this.buttScale.GLImage = null;
            this.buttScale.GLVisible = false;
            this.buttScale.GuiAnchor = null;
            this.buttScale.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttScale.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttScale;
            this.buttScale.Location = new System.Drawing.Point(10, 490);
            this.buttScale.Name = "buttScale";
            this.buttScale.Size = new System.Drawing.Size(48, 48);
            this.buttScale.StyleName = null;
            this.buttScale.TabIndex = 17;
            this.ctlToolTip1.SetToolTip(this.buttScale, "Scale object");
            this.buttScale.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttScale.Click += new System.EventHandler(this.buttScale_Click);
            // 
            // buttMove
            // 
            this.buttMove.BackColor = System.Drawing.Color.Navy;
            this.buttMove.Checked = false;
            this.buttMove.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenClose;
            this.buttMove.Gapx = 10;
            this.buttMove.Gapy = 110;
            this.buttMove.GLBackgroundImage = null;
            this.buttMove.GLImage = null;
            this.buttMove.GLVisible = false;
            this.buttMove.GuiAnchor = null;
            this.buttMove.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttMove.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttMove;
            this.buttMove.Location = new System.Drawing.Point(10, 390);
            this.buttMove.Name = "buttMove";
            this.buttMove.Size = new System.Drawing.Size(48, 48);
            this.buttMove.StyleName = null;
            this.buttMove.TabIndex = 19;
            this.ctlToolTip1.SetToolTip(this.buttMove, "Move object");
            this.buttMove.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttMove.Click += new System.EventHandler(this.buttMove_Click);
            // 
            // ctlSupport
            // 
            this.ctlSupport.Gapx = 0;
            this.ctlSupport.Gapy = 0;
            this.ctlSupport.GLBackgroundImage = null;
            this.ctlSupport.GLVisible = false;
            this.ctlSupport.GuiAnchor = null;
            this.ctlSupport.Location = new System.Drawing.Point(284, 15);
            this.ctlSupport.Name = "ctlSupport";
            this.ctlSupport.Size = new System.Drawing.Size(170, 96);
            this.ctlSupport.StyleName = null;
            this.ctlSupport.TabIndex = 24;
            this.ctlSupport.Visible = false;
            // 
            // buttSupports
            // 
            this.buttSupports.BackColor = System.Drawing.Color.Navy;
            this.buttSupports.Checked = false;
            this.buttSupports.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenClose;
            this.buttSupports.Gapx = 10;
            this.buttSupports.Gapy = 170;
            this.buttSupports.GLBackgroundImage = null;
            this.buttSupports.GLImage = null;
            this.buttSupports.GLVisible = false;
            this.buttSupports.GuiAnchor = null;
            this.buttSupports.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttSupports.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttSupport;
            this.buttSupports.Location = new System.Drawing.Point(10, 336);
            this.buttSupports.Name = "buttSupports";
            this.buttSupports.Size = new System.Drawing.Size(48, 48);
            this.buttSupports.StyleName = null;
            this.buttSupports.TabIndex = 23;
            this.ctlToolTip1.SetToolTip(this.buttSupports, "Support operations");
            this.buttSupports.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttSupports.Click += new System.EventHandler(this.buttSupports_Click);
            // 
            // ctlObjRotate
            // 
            this.ctlObjRotate.Gapx = 0;
            this.ctlObjRotate.Gapy = 0;
            this.ctlObjRotate.GLBackgroundImage = null;
            this.ctlObjRotate.GLVisible = false;
            this.ctlObjRotate.GuiAnchor = null;
            this.ctlObjRotate.Location = new System.Drawing.Point(665, 15);
            this.ctlObjRotate.Name = "ctlObjRotate";
            this.ctlObjRotate.Size = new System.Drawing.Size(170, 156);
            this.ctlObjRotate.StyleName = null;
            this.ctlObjRotate.TabIndex = 22;
            this.ctlObjRotate.Visible = false;
            // 
            // buttRotate
            // 
            this.buttRotate.BackColor = System.Drawing.Color.Navy;
            this.buttRotate.Checked = false;
            this.buttRotate.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenClose;
            this.buttRotate.Gapx = 10;
            this.buttRotate.Gapy = 60;
            this.buttRotate.GLBackgroundImage = null;
            this.buttRotate.GLImage = null;
            this.buttRotate.GLVisible = false;
            this.buttRotate.GuiAnchor = null;
            this.buttRotate.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttRotate.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttRotate;
            this.buttRotate.Location = new System.Drawing.Point(10, 440);
            this.buttRotate.Name = "buttRotate";
            this.buttRotate.Size = new System.Drawing.Size(48, 48);
            this.buttRotate.StyleName = null;
            this.buttRotate.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttRotate, "Rotate object");
            this.buttRotate.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttRotate.Click += new System.EventHandler(this.buttRotate_Click);
            // 
            // ctlObjScale
            // 
            this.ctlObjScale.Gapx = 0;
            this.ctlObjScale.Gapy = 0;
            this.ctlObjScale.GLBackgroundImage = null;
            this.ctlObjScale.GLVisible = false;
            this.ctlObjScale.GuiAnchor = null;
            this.ctlObjScale.Location = new System.Drawing.Point(474, 15);
            this.ctlObjScale.Name = "ctlObjScale";
            this.ctlObjScale.Size = new System.Drawing.Size(171, 199);
            this.ctlObjScale.StyleName = null;
            this.ctlObjScale.TabIndex = 21;
            this.ctlObjScale.Visible = false;
            // 
            // ctlObjMove
            // 
            this.ctlObjMove.Gapx = 0;
            this.ctlObjMove.Gapy = 0;
            this.ctlObjMove.GLBackgroundImage = null;
            this.ctlObjMove.GLVisible = false;
            this.ctlObjMove.GuiAnchor = null;
            this.ctlObjMove.Location = new System.Drawing.Point(94, 15);
            this.ctlObjMove.Name = "ctlObjMove";
            this.ctlObjMove.Size = new System.Drawing.Size(170, 219);
            this.ctlObjMove.StyleName = null;
            this.ctlObjMove.TabIndex = 20;
            this.ctlObjMove.Visible = false;
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Enabled = false;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(5);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(958, 550);
            this.glControl1.TabIndex = 15;
            this.glControl1.Visible = false;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Click += new System.EventHandler(this.glControl1_Click);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.DoubleClick += new System.EventHandler(this.glControl1_DoubleClick);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glControl1_KeyPress);
            this.glControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyUp);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseLeave += new System.EventHandler(this.glControl1_MouseLeave);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // ctlToolTip1
            // 
            this.ctlToolTip1.AutoPopDelay = 5000;
            this.ctlToolTip1.BackColor = System.Drawing.Color.Turquoise;
            this.ctlToolTip1.ForeColor = System.Drawing.Color.Navy;
            this.ctlToolTip1.InitialDelay = 1500;
            this.ctlToolTip1.ReshowDelay = 100;
            this.ctlToolTip1.UseAnimation = false;
            this.ctlToolTip1.UseFading = false;
            // 
            // ctl3DView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.mainViewSplitContainer);
            this.Name = "ctl3DView";
            this.Size = new System.Drawing.Size(1122, 550);
            this.Load += new System.EventHandler(this.ctl3DView_Load);
            this.mainViewSplitContainer.Panel2.ResumeLayout(false);
            this.mainViewSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainViewSplitContainer;
        private CustomGUI.ctlObjectInfo objectInfoPanel;
        private CustomGUI.ctlNumber numLayer;
        private CustomGUI.ctlImageButton buttGlHome;
        private CustomGUI.ctlImageButton buttView;
        private CustomGUI.ctlView ctlViewOptions;
        private CustomGUI.ctlImageButton buttScale;
        private CustomGUI.ctlImageButton buttMove;
        private CustomGUI.ctlSupports ctlSupport;
        private CustomGUI.ctlImageButton buttSupports;
        private CustomGUI.ctlRotate ctlObjRotate;
        private CustomGUI.ctlImageButton buttRotate;
        private CustomGUI.ctlScale ctlObjScale;
        private CustomGUI.ctlMove ctlObjMove;
        private CustomGUI.ctlImageButton buttUndo;
        private CustomGUI.ctlToolTip ctlToolTip1;
        private CustomGUI.ctlImageButton buttRedo;
        private CustomGUI.ctlImageButton buttMeshTools;
        private CustomGUI.ctlMeshTools ctlMeshTools1;
        private ctlGL glControl1;
        private CustomGUI.ctlScene ctlScene1;
        private CustomGUI.ctlText textProgress;
        private CustomGUI.ctlImageButton buttOpenFile;
        private CustomGUI.ctlImageButton buttPlay;
        private CustomGUI.ctlImageButton buttPause;
        private CustomGUI.ctlImageButton buttStop;
        private CustomGUI.ctlImageButton buttConnect;
        private CustomGUI.ctlImageButton buttDisconnect;
        private CustomGUI.ctlImageButton buttSlice;
        private CustomGUI.ctlImageButton buttConfig;
        private CustomGUI.ctlImageButton buttViewGcode;
        private CustomGUI.ctlImageButton buttViewSlice;
        private CustomGUI.ctlText textTime;
        private CustomGUI.ctlText textMainMessage;
    }
}
