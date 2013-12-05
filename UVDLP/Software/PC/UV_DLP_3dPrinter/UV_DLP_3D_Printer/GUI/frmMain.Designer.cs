namespace UV_DLP_3D_Printer
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBinarySTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estimateVolumeCostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSceneSTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findHolesInMeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMainWindow = new System.Windows.Forms.SplitContainer();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabModel1 = new System.Windows.Forms.TabPage();
            this.mainViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.treeScene = new System.Windows.Forms.TreeView();
            this.glControl1 = new OpenTK.GLControl();
            this.tabGCode = new System.Windows.Forms.TabPage();
            this.txtGCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdLoadGCode = new System.Windows.Forms.Button();
            this.cmdSaveGCode = new System.Windows.Forms.Button();
            this.tabSliceView = new System.Windows.Forms.TabPage();
            this.picSlice = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdViewLayer = new System.Windows.Forms.Button();
            this.txtLayerNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSliceNum = new System.Windows.Forms.Label();
            this.tabMachineControl = new System.Windows.Forms.TabPage();
            this.tabMachineConfig = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdBuild = new System.Windows.Forms.ToolStripButton();
            this.cmdPause = new System.Windows.Forms.ToolStripButton();
            this.cmdStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdConnect = new System.Windows.Forms.ToolStripButton();
            this.cmdDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdSlice1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblMainMessage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTime = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdRemoveObject = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttOpenFile = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttPlay = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttPause = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttStop = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttConnect = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttDisconnect = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttSlice = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
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
            this.ctlMachineControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineControl();
            this.ctlMachineConfig1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineConfig();
            this.ctlToolpathGenConfig1 = new UV_DLP_3D_Printer.GUI.Controls.ctlToolpathGenConfig();
            this.heatTempCtl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlHeatTemp();
            this.ctlToolTip1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlToolTip();
            this.buttConfig = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.menuStrip1.SuspendLayout();
            this.splitContainerMainWindow.Panel1.SuspendLayout();
            this.splitContainerMainWindow.Panel2.SuspendLayout();
            this.splitContainerMainWindow.SuspendLayout();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabModel1.SuspendLayout();
            this.mainViewSplitContainer.Panel1.SuspendLayout();
            this.mainViewSplitContainer.Panel2.SuspendLayout();
            this.mainViewSplitContainer.SuspendLayout();
            this.tabGCode.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabSliceView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabMachineControl.SuspendLayout();
            this.tabMachineConfig.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.ReadOnlyChecked = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1457, 26);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBinarySTLToolStripMenuItem,
            this.estimateVolumeCostToolStripMenuItem,
            this.saveSceneSTLToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.testToolStripMenuItem,
            this.findHolesInMeshToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadBinarySTLToolStripMenuItem
            // 
            this.loadBinarySTLToolStripMenuItem.Name = "loadBinarySTLToolStripMenuItem";
            this.loadBinarySTLToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.loadBinarySTLToolStripMenuItem.Text = "Load Model";
            this.loadBinarySTLToolStripMenuItem.Click += new System.EventHandler(this.loadBinarySTLToolStripMenuItem_Click);
            // 
            // estimateVolumeCostToolStripMenuItem
            // 
            this.estimateVolumeCostToolStripMenuItem.Name = "estimateVolumeCostToolStripMenuItem";
            this.estimateVolumeCostToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.estimateVolumeCostToolStripMenuItem.Text = "Estimate Volume && Cost";
            this.estimateVolumeCostToolStripMenuItem.Click += new System.EventHandler(this.estimateVolumeCostToolStripMenuItem_Click);
            // 
            // saveSceneSTLToolStripMenuItem
            // 
            this.saveSceneSTLToolStripMenuItem.Name = "saveSceneSTLToolStripMenuItem";
            this.saveSceneSTLToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.saveSceneSTLToolStripMenuItem.Text = "Save Scene STL";
            this.saveSceneSTLToolStripMenuItem.Click += new System.EventHandler(this.saveSceneSTLToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // findHolesInMeshToolStripMenuItem
            // 
            this.findHolesInMeshToolStripMenuItem.Name = "findHolesInMeshToolStripMenuItem";
            this.findHolesInMeshToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.findHolesInMeshToolStripMenuItem.Text = "Find Holes In Mesh";
            this.findHolesInMeshToolStripMenuItem.Click += new System.EventHandler(this.findHolesInMeshToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainerMainWindow
            // 
            this.splitContainerMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainWindow.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainWindow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerMainWindow.Name = "splitContainerMainWindow";
            this.splitContainerMainWindow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainWindow.Panel1
            // 
            this.splitContainerMainWindow.Panel1.Controls.Add(this.splitContainerTop);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainerMainWindow.Panel2
            // 
            this.splitContainerMainWindow.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainerMainWindow.Size = new System.Drawing.Size(1457, 793);
            this.splitContainerMainWindow.SplitterDistance = 666;
            this.splitContainerMainWindow.TabIndex = 21;
            // 
            // splitContainerTop
            // 
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerTop.Location = new System.Drawing.Point(0, 26);
            this.splitContainerTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerTop.Name = "splitContainerTop";
            this.splitContainerTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTop.Panel1
            // 
            this.splitContainerTop.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainerTop.Panel2
            // 
            this.splitContainerTop.Panel2.Controls.Add(this.tabMain);
            this.splitContainerTop.Panel2.Controls.Add(this.vScrollBar1);
            this.splitContainerTop.Size = new System.Drawing.Size(1457, 640);
            this.splitContainerTop.SplitterDistance = 56;
            this.splitContainerTop.SplitterWidth = 5;
            this.splitContainerTop.TabIndex = 20;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel1.Controls.Add(this.buttOpenFile);
            this.flowLayoutPanel1.Controls.Add(this.buttPlay);
            this.flowLayoutPanel1.Controls.Add(this.buttPause);
            this.flowLayoutPanel1.Controls.Add(this.buttStop);
            this.flowLayoutPanel1.Controls.Add(this.buttConnect);
            this.flowLayoutPanel1.Controls.Add(this.buttDisconnect);
            this.flowLayoutPanel1.Controls.Add(this.buttSlice);
            this.flowLayoutPanel1.Controls.Add(this.buttConfig);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1457, 56);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabModel1);
            this.tabMain.Controls.Add(this.tabGCode);
            this.tabMain.Controls.Add(this.tabSliceView);
            this.tabMain.Controls.Add(this.tabMachineControl);
            this.tabMain.Controls.Add(this.tabMachineConfig);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(30, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1427, 579);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 18;
            // 
            // tabModel1
            // 
            this.tabModel1.Controls.Add(this.mainViewSplitContainer);
            this.tabModel1.Location = new System.Drawing.Point(4, 25);
            this.tabModel1.Margin = new System.Windows.Forms.Padding(0);
            this.tabModel1.Name = "tabModel1";
            this.tabModel1.Size = new System.Drawing.Size(1419, 550);
            this.tabModel1.TabIndex = 0;
            this.tabModel1.Text = "Model View";
            this.tabModel1.UseVisualStyleBackColor = true;
            // 
            // mainViewSplitContainer
            // 
            this.mainViewSplitContainer.BackColor = System.Drawing.Color.RoyalBlue;
            this.mainViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainViewSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainViewSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.mainViewSplitContainer.Name = "mainViewSplitContainer";
            // 
            // mainViewSplitContainer.Panel1
            // 
            this.mainViewSplitContainer.Panel1.Controls.Add(this.treeScene);
            // 
            // mainViewSplitContainer.Panel2
            // 
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
            this.mainViewSplitContainer.Panel2.SizeChanged += new System.EventHandler(this.splitContainer5_Panel2_SizeChanged);
            this.mainViewSplitContainer.Size = new System.Drawing.Size(1419, 550);
            this.mainViewSplitContainer.SplitterDistance = 204;
            this.mainViewSplitContainer.TabIndex = 27;
            // 
            // treeScene
            // 
            this.treeScene.BackColor = System.Drawing.Color.Navy;
            this.treeScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeScene.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeScene.ForeColor = System.Drawing.Color.White;
            this.treeScene.Location = new System.Drawing.Point(0, 0);
            this.treeScene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeScene.Name = "treeScene";
            this.treeScene.Size = new System.Drawing.Size(204, 550);
            this.treeScene.TabIndex = 6;
            this.treeScene.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeScene_NodeMouseClick);
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(5);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1211, 550);
            this.glControl1.TabIndex = 15;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
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
            // tabGCode
            // 
            this.tabGCode.Controls.Add(this.txtGCode);
            this.tabGCode.Controls.Add(this.panel1);
            this.tabGCode.Location = new System.Drawing.Point(4, 25);
            this.tabGCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGCode.Name = "tabGCode";
            this.tabGCode.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGCode.Size = new System.Drawing.Size(1419, 550);
            this.tabGCode.TabIndex = 1;
            this.tabGCode.Text = "GCode";
            this.tabGCode.UseVisualStyleBackColor = true;
            // 
            // txtGCode
            // 
            this.txtGCode.AcceptsReturn = true;
            this.txtGCode.BackColor = System.Drawing.Color.White;
            this.txtGCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGCode.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGCode.Location = new System.Drawing.Point(3, 2);
            this.txtGCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGCode.Multiline = true;
            this.txtGCode.Name = "txtGCode";
            this.txtGCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGCode.Size = new System.Drawing.Size(1413, 468);
            this.txtGCode.TabIndex = 0;
            this.txtGCode.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdLoadGCode);
            this.panel1.Controls.Add(this.cmdSaveGCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 470);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1413, 78);
            this.panel1.TabIndex = 1;
            // 
            // cmdLoadGCode
            // 
            this.cmdLoadGCode.Location = new System.Drawing.Point(164, 17);
            this.cmdLoadGCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdLoadGCode.Name = "cmdLoadGCode";
            this.cmdLoadGCode.Size = new System.Drawing.Size(128, 50);
            this.cmdLoadGCode.TabIndex = 2;
            this.cmdLoadGCode.Text = " Load GCode";
            this.cmdLoadGCode.UseVisualStyleBackColor = true;
            this.cmdLoadGCode.Click += new System.EventHandler(this.cmdLoadGCode_Click);
            // 
            // cmdSaveGCode
            // 
            this.cmdSaveGCode.Location = new System.Drawing.Point(17, 17);
            this.cmdSaveGCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSaveGCode.Name = "cmdSaveGCode";
            this.cmdSaveGCode.Size = new System.Drawing.Size(128, 50);
            this.cmdSaveGCode.TabIndex = 0;
            this.cmdSaveGCode.Text = "Save GCode";
            this.cmdSaveGCode.UseVisualStyleBackColor = true;
            this.cmdSaveGCode.Click += new System.EventHandler(this.cmdSaveGCode_Click);
            // 
            // tabSliceView
            // 
            this.tabSliceView.Controls.Add(this.picSlice);
            this.tabSliceView.Controls.Add(this.panel2);
            this.tabSliceView.Location = new System.Drawing.Point(4, 25);
            this.tabSliceView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSliceView.Name = "tabSliceView";
            this.tabSliceView.Size = new System.Drawing.Size(1419, 550);
            this.tabSliceView.TabIndex = 2;
            this.tabSliceView.Text = "Slice Viewer";
            this.tabSliceView.UseVisualStyleBackColor = true;
            // 
            // picSlice
            // 
            this.picSlice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSlice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSlice.Location = new System.Drawing.Point(0, 47);
            this.picSlice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picSlice.Name = "picSlice";
            this.picSlice.Size = new System.Drawing.Size(1419, 503);
            this.picSlice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSlice.TabIndex = 17;
            this.picSlice.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdViewLayer);
            this.panel2.Controls.Add(this.txtLayerNum);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblSliceNum);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1419, 47);
            this.panel2.TabIndex = 18;
            // 
            // cmdViewLayer
            // 
            this.cmdViewLayer.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdViewLayer.Location = new System.Drawing.Point(268, 7);
            this.cmdViewLayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdViewLayer.Name = "cmdViewLayer";
            this.cmdViewLayer.Size = new System.Drawing.Size(75, 30);
            this.cmdViewLayer.TabIndex = 3;
            this.cmdViewLayer.Text = "View";
            this.cmdViewLayer.UseVisualStyleBackColor = true;
            this.cmdViewLayer.Click += new System.EventHandler(this.cmdViewLayer_Click);
            // 
            // txtLayerNum
            // 
            this.txtLayerNum.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLayerNum.Location = new System.Drawing.Point(176, 7);
            this.txtLayerNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLayerNum.Name = "txtLayerNum";
            this.txtLayerNum.Size = new System.Drawing.Size(87, 30);
            this.txtLayerNum.TabIndex = 2;
            this.txtLayerNum.Text = "0";
            this.txtLayerNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 27);
            this.label4.TabIndex = 1;
            this.label4.Text = "View Layer:";
            // 
            // lblSliceNum
            // 
            this.lblSliceNum.AutoSize = true;
            this.lblSliceNum.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSliceNum.Location = new System.Drawing.Point(427, 9);
            this.lblSliceNum.Name = "lblSliceNum";
            this.lblSliceNum.Size = new System.Drawing.Size(180, 27);
            this.lblSliceNum.TabIndex = 0;
            this.lblSliceNum.Text = "Slice 0 of 0";
            // 
            // tabMachineControl
            // 
            this.tabMachineControl.Controls.Add(this.ctlMachineControl1);
            this.tabMachineControl.Location = new System.Drawing.Point(4, 25);
            this.tabMachineControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMachineControl.Name = "tabMachineControl";
            this.tabMachineControl.Size = new System.Drawing.Size(1419, 550);
            this.tabMachineControl.TabIndex = 3;
            this.tabMachineControl.Text = "Machine Control";
            this.tabMachineControl.UseVisualStyleBackColor = true;
            this.tabMachineControl.Enter += new System.EventHandler(this.tabMachineControl_Enter);
            // 
            // tabMachineConfig
            // 
            this.tabMachineConfig.Controls.Add(this.ctlMachineConfig1);
            this.tabMachineConfig.Location = new System.Drawing.Point(4, 25);
            this.tabMachineConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMachineConfig.Name = "tabMachineConfig";
            this.tabMachineConfig.Size = new System.Drawing.Size(1419, 550);
            this.tabMachineConfig.TabIndex = 4;
            this.tabMachineConfig.Text = "Machine Config";
            this.tabMachineConfig.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctlToolpathGenConfig1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1419, 550);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Slice Profile Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar1.Maximum = 1000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(30, 579);
            this.vScrollBar1.TabIndex = 20;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLoad,
            this.toolStripSeparator3,
            this.cmdBuild,
            this.cmdPause,
            this.cmdStop,
            this.toolStripSeparator1,
            this.cmdConnect,
            this.cmdDisconnect,
            this.toolStripSeparator2,
            this.cmdSlice1,
            this.toolStripSeparator4,
            this.lblMainMessage,
            this.toolStripSeparator5,
            this.lblTime});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1457, 55);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // cmdLoad
            // 
            this.cmdLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdLoad.Image = global::UV_DLP_3D_Printer.Properties.Resources.Load;
            this.cmdLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(52, 52);
            this.cmdLoad.Text = "Load Model";
            this.cmdLoad.Click += new System.EventHandler(this.LoadSTLModel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // cmdBuild
            // 
            this.cmdBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdBuild.Image = global::UV_DLP_3D_Printer.Properties.Resources.bfzn_004;
            this.cmdBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdBuild.Name = "cmdBuild";
            this.cmdBuild.Size = new System.Drawing.Size(52, 52);
            this.cmdBuild.Text = "Start Build";
            this.cmdBuild.Click += new System.EventHandler(this.cmdStartPrint_Click);
            // 
            // cmdPause
            // 
            this.cmdPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdPause.Image = global::UV_DLP_3D_Printer.Properties.Resources.bfzn_003;
            this.cmdPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(52, 52);
            this.cmdPause.Text = "Pause";
            this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click_1);
            // 
            // cmdStop
            // 
            this.cmdStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdStop.Image = global::UV_DLP_3D_Printer.Properties.Resources.bfzn_006;
            this.cmdStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(52, 52);
            this.cmdStop.Text = "Stop Build";
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // cmdConnect
            // 
            this.cmdConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdConnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.Connect;
            this.cmdConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(52, 52);
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect1_Click);
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdDisconnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.Disconnect;
            this.cmdDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(52, 52);
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // cmdSlice1
            // 
            this.cmdSlice1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSlice1.Image = global::UV_DLP_3D_Printer.Properties.Resources.slice;
            this.cmdSlice1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSlice1.Name = "cmdSlice1";
            this.cmdSlice1.Size = new System.Drawing.Size(52, 52);
            this.cmdSlice1.Text = "Slice!";
            this.cmdSlice1.Click += new System.EventHandler(this.cmdSlice1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // lblMainMessage
            // 
            this.lblMainMessage.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainMessage.Name = "lblMainMessage";
            this.lblMainMessage.Size = new System.Drawing.Size(0, 52);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 52);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.txtLog);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.heatTempCtl1);
            this.splitContainer3.Size = new System.Drawing.Size(1457, 123);
            this.splitContainer3.SplitterDistance = 990;
            this.splitContainer3.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(990, 123);
            this.txtLog.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRemoveObject});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 26);
            // 
            // cmdRemoveObject
            // 
            this.cmdRemoveObject.Name = "cmdRemoveObject";
            this.cmdRemoveObject.Size = new System.Drawing.Size(178, 22);
            this.cmdRemoveObject.Text = "Remove Object";
            this.cmdRemoveObject.Click += new System.EventHandler(this.cmdRemoveObject_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(211, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItem1.Text = "Remove All Supports";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // buttOpenFile
            // 
            this.buttOpenFile.BackColor = System.Drawing.Color.Navy;
            this.buttOpenFile.Checked = false;
            this.buttOpenFile.CheckImage = null;
            this.buttOpenFile.Gapx = 10;
            this.buttOpenFile.Gapy = 10;
            this.buttOpenFile.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttOpenFile.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenFile;
            this.buttOpenFile.Location = new System.Drawing.Point(4, 4);
            this.buttOpenFile.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.buttOpenFile.Name = "buttOpenFile";
            this.buttOpenFile.Size = new System.Drawing.Size(48, 48);
            this.buttOpenFile.TabIndex = 17;
            this.ctlToolTip1.SetToolTip(this.buttOpenFile, "Load model");
            this.buttOpenFile.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttOpenFile.Click += new System.EventHandler(this.LoadSTLModel_Click);
            // 
            // buttPlay
            // 
            this.buttPlay.BackColor = System.Drawing.Color.Navy;
            this.buttPlay.Checked = false;
            this.buttPlay.CheckImage = null;
            this.buttPlay.Gapx = 10;
            this.buttPlay.Gapy = 10;
            this.buttPlay.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttPlay.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPlay;
            this.buttPlay.Location = new System.Drawing.Point(66, 4);
            this.buttPlay.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttPlay.Name = "buttPlay";
            this.buttPlay.Size = new System.Drawing.Size(48, 48);
            this.buttPlay.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttPlay, "Build!");
            this.buttPlay.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttPlay.Click += new System.EventHandler(this.cmdStartPrint_Click);
            // 
            // buttPause
            // 
            this.buttPause.BackColor = System.Drawing.Color.Navy;
            this.buttPause.Checked = false;
            this.buttPause.CheckImage = null;
            this.buttPause.Gapx = 10;
            this.buttPause.Gapy = 10;
            this.buttPause.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttPause.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPause;
            this.buttPause.Location = new System.Drawing.Point(118, 4);
            this.buttPause.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttPause.Name = "buttPause";
            this.buttPause.Size = new System.Drawing.Size(48, 48);
            this.buttPause.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttPause, "Pause build process");
            this.buttPause.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttPause.Click += new System.EventHandler(this.cmdPause_Click_1);
            // 
            // buttStop
            // 
            this.buttStop.BackColor = System.Drawing.Color.Navy;
            this.buttStop.Checked = false;
            this.buttStop.CheckImage = null;
            this.buttStop.Gapx = 10;
            this.buttStop.Gapy = 10;
            this.buttStop.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttStop.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttStop;
            this.buttStop.Location = new System.Drawing.Point(170, 4);
            this.buttStop.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.buttStop.Name = "buttStop";
            this.buttStop.Size = new System.Drawing.Size(48, 48);
            this.buttStop.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttStop, "Stop build process");
            this.buttStop.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // buttConnect
            // 
            this.buttConnect.BackColor = System.Drawing.Color.Navy;
            this.buttConnect.Checked = false;
            this.buttConnect.CheckImage = null;
            this.buttConnect.Gapx = 10;
            this.buttConnect.Gapy = 10;
            this.buttConnect.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttConnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttConnect;
            this.buttConnect.Location = new System.Drawing.Point(232, 4);
            this.buttConnect.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttConnect.Name = "buttConnect";
            this.buttConnect.Size = new System.Drawing.Size(48, 48);
            this.buttConnect.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttConnect, "Connect");
            this.buttConnect.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttConnect.Click += new System.EventHandler(this.cmdConnect1_Click);
            // 
            // buttDisconnect
            // 
            this.buttDisconnect.BackColor = System.Drawing.Color.Navy;
            this.buttDisconnect.Checked = false;
            this.buttDisconnect.CheckImage = null;
            this.buttDisconnect.Gapx = 10;
            this.buttDisconnect.Gapy = 10;
            this.buttDisconnect.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttDisconnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttDisconnect;
            this.buttDisconnect.Location = new System.Drawing.Point(284, 4);
            this.buttDisconnect.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.buttDisconnect.Name = "buttDisconnect";
            this.buttDisconnect.Size = new System.Drawing.Size(48, 48);
            this.buttDisconnect.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttDisconnect, "Disconnect");
            this.buttDisconnect.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // buttSlice
            // 
            this.buttSlice.BackColor = System.Drawing.Color.Navy;
            this.buttSlice.Checked = false;
            this.buttSlice.CheckImage = null;
            this.buttSlice.Gapx = 10;
            this.buttSlice.Gapy = 10;
            this.buttSlice.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttSlice.Image = ((System.Drawing.Image)(resources.GetObject("buttSlice.Image")));
            this.buttSlice.Location = new System.Drawing.Point(346, 4);
            this.buttSlice.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttSlice.Name = "buttSlice";
            this.buttSlice.Size = new System.Drawing.Size(48, 48);
            this.buttSlice.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttSlice, "Slice!");
            this.buttSlice.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttSlice.Click += new System.EventHandler(this.cmdSlice1_Click);
            // 
            // objectInfoPanel
            // 
            this.objectInfoPanel.Checked = false;
            this.objectInfoPanel.Gapx = 10;
            this.objectInfoPanel.Gapy = 10;
            this.objectInfoPanel.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.objectInfoPanel.Location = new System.Drawing.Point(628, 238);
            this.objectInfoPanel.Name = "objectInfoPanel";
            this.objectInfoPanel.Size = new System.Drawing.Size(300, 240);
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
            this.numLayer.Gapy = 10;
            this.numLayer.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Center;
            this.numLayer.Increment = 1F;
            this.numLayer.IntVal = 1000;
            this.numLayer.Location = new System.Drawing.Point(253, 519);
            this.numLayer.MaxFloat = 500F;
            this.numLayer.MaxInt = 1000;
            this.numLayer.MinFloat = -500F;
            this.numLayer.MinimumSize = new System.Drawing.Size(20, 5);
            this.numLayer.MinInt = 1;
            this.numLayer.Name = "numLayer";
            this.numLayer.Size = new System.Drawing.Size(425, 24);
            this.numLayer.TabIndex = 27;
            this.numLayer.TextFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numLayer, "Layer view slider");
            this.numLayer.ValidColor = System.Drawing.Color.White;
            this.numLayer.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.numLayer.Visible = false;
            this.numLayer.ValueChanged += new System.EventHandler(this.numLayer_ValueChanged);
            // 
            // buttGlHome
            // 
            this.buttGlHome.BackColor = System.Drawing.Color.Navy;
            this.buttGlHome.Checked = false;
            this.buttGlHome.CheckImage = null;
            this.buttGlHome.Gapx = 10;
            this.buttGlHome.Gapy = 10;
            this.buttGlHome.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttGlHome.Image = global::UV_DLP_3D_Printer.Properties.Resources.homeButt;
            this.buttGlHome.Location = new System.Drawing.Point(15, 15);
            this.buttGlHome.Name = "buttGlHome";
            this.buttGlHome.Size = new System.Drawing.Size(48, 48);
            this.buttGlHome.TabIndex = 16;
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
            this.buttView.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttView.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttView;
            this.buttView.Location = new System.Drawing.Point(10, 270);
            this.buttView.Name = "buttView";
            this.buttView.Size = new System.Drawing.Size(48, 48);
            this.buttView.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.buttView, "View options");
            this.buttView.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttView.Click += new System.EventHandler(this.buttView_Click);
            // 
            // ctlViewOptions
            // 
            this.ctlViewOptions.LayerNumberScroll = null;
            this.ctlViewOptions.Location = new System.Drawing.Point(284, 117);
            this.ctlViewOptions.MessagePanelHolder = null;
            this.ctlViewOptions.Name = "ctlViewOptions";
            this.ctlViewOptions.ObjectInfoPanel = null;
            this.ctlViewOptions.Size = new System.Drawing.Size(170, 125);
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
            this.buttScale.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttScale.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttScale;
            this.buttScale.Location = new System.Drawing.Point(10, 490);
            this.buttScale.Name = "buttScale";
            this.buttScale.Size = new System.Drawing.Size(48, 48);
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
            this.buttMove.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttMove.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttMove;
            this.buttMove.Location = new System.Drawing.Point(10, 390);
            this.buttMove.Name = "buttMove";
            this.buttMove.Size = new System.Drawing.Size(48, 48);
            this.buttMove.TabIndex = 19;
            this.ctlToolTip1.SetToolTip(this.buttMove, "Move object");
            this.buttMove.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttMove.Click += new System.EventHandler(this.buttMove_Click);
            // 
            // ctlSupport
            // 
            this.ctlSupport.Location = new System.Drawing.Point(284, 15);
            this.ctlSupport.Name = "ctlSupport";
            this.ctlSupport.Size = new System.Drawing.Size(170, 96);
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
            this.buttSupports.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttSupports.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttSupport;
            this.buttSupports.Location = new System.Drawing.Point(10, 330);
            this.buttSupports.Name = "buttSupports";
            this.buttSupports.Size = new System.Drawing.Size(48, 48);
            this.buttSupports.TabIndex = 23;
            this.ctlToolTip1.SetToolTip(this.buttSupports, "Supports");
            this.buttSupports.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttSupports.Click += new System.EventHandler(this.buttSupports_Click);
            // 
            // ctlObjRotate
            // 
            this.ctlObjRotate.Location = new System.Drawing.Point(665, 15);
            this.ctlObjRotate.Name = "ctlObjRotate";
            this.ctlObjRotate.Size = new System.Drawing.Size(170, 156);
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
            this.buttRotate.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttRotate.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttRotate;
            this.buttRotate.Location = new System.Drawing.Point(10, 440);
            this.buttRotate.Name = "buttRotate";
            this.buttRotate.Size = new System.Drawing.Size(48, 48);
            this.buttRotate.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttRotate, "Rotate object");
            this.buttRotate.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttRotate.Click += new System.EventHandler(this.buttRotate_Click);
            // 
            // ctlObjScale
            // 
            this.ctlObjScale.Location = new System.Drawing.Point(474, 15);
            this.ctlObjScale.Name = "ctlObjScale";
            this.ctlObjScale.Size = new System.Drawing.Size(171, 199);
            this.ctlObjScale.TabIndex = 21;
            this.ctlObjScale.Visible = false;
            // 
            // ctlObjMove
            // 
            this.ctlObjMove.Location = new System.Drawing.Point(94, 15);
            this.ctlObjMove.Name = "ctlObjMove";
            this.ctlObjMove.Size = new System.Drawing.Size(170, 219);
            this.ctlObjMove.TabIndex = 20;
            this.ctlObjMove.Visible = false;
            // 
            // ctlMachineControl1
            // 
            this.ctlMachineControl1.Location = new System.Drawing.Point(3, 2);
            this.ctlMachineControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctlMachineControl1.Name = "ctlMachineControl1";
            this.ctlMachineControl1.Size = new System.Drawing.Size(949, 558);
            this.ctlMachineControl1.TabIndex = 0;
            // 
            // ctlMachineConfig1
            // 
            this.ctlMachineConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlMachineConfig1.Location = new System.Drawing.Point(0, 0);
            this.ctlMachineConfig1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctlMachineConfig1.Name = "ctlMachineConfig1";
            this.ctlMachineConfig1.Size = new System.Drawing.Size(1419, 550);
            this.ctlMachineConfig1.TabIndex = 0;
            // 
            // ctlToolpathGenConfig1
            // 
            this.ctlToolpathGenConfig1.Location = new System.Drawing.Point(3, 4);
            this.ctlToolpathGenConfig1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctlToolpathGenConfig1.Name = "ctlToolpathGenConfig1";
            this.ctlToolpathGenConfig1.Size = new System.Drawing.Size(1036, 505);
            this.ctlToolpathGenConfig1.TabIndex = 0;
            // 
            // heatTempCtl1
            // 
            this.heatTempCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heatTempCtl1.Location = new System.Drawing.Point(0, 0);
            this.heatTempCtl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.heatTempCtl1.MonitorTemps = false;
            this.heatTempCtl1.Name = "heatTempCtl1";
            this.heatTempCtl1.Size = new System.Drawing.Size(463, 123);
            this.heatTempCtl1.TabIndex = 0;
            // 
            // ctlToolTip1
            // 
            this.ctlToolTip1.AutoPopDelay = 5000;
            this.ctlToolTip1.BackColor = System.Drawing.Color.Turquoise;
            this.ctlToolTip1.ForeColor = System.Drawing.Color.Navy;
            this.ctlToolTip1.InitialDelay = 1500;
            this.ctlToolTip1.ReshowDelay = 100;
            this.ctlToolTip1.ShowAlways = true;
            // 
            // buttConfig
            // 
            this.buttConfig.BackColor = System.Drawing.Color.Navy;
            this.buttConfig.Checked = false;
            this.buttConfig.CheckImage = null;
            this.buttConfig.Gapx = 10;
            this.buttConfig.Gapy = 10;
            this.buttConfig.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttConfig.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttGear;
            this.buttConfig.Location = new System.Drawing.Point(398, 4);
            this.buttConfig.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttConfig.Name = "buttConfig";
            this.buttConfig.Size = new System.Drawing.Size(48, 48);
            this.buttConfig.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttConfig, "Configuration");
            this.buttConfig.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttConfig.Click += new System.EventHandler(this.cmdSlice1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1457, 793);
            this.Controls.Add(this.splitContainerMainWindow);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Creation Workshop - 3D Printer Control and Slicing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainerMainWindow.Panel1.ResumeLayout(false);
            this.splitContainerMainWindow.Panel1.PerformLayout();
            this.splitContainerMainWindow.Panel2.ResumeLayout(false);
            this.splitContainerMainWindow.ResumeLayout(false);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            this.splitContainerTop.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabModel1.ResumeLayout(false);
            this.mainViewSplitContainer.Panel1.ResumeLayout(false);
            this.mainViewSplitContainer.Panel2.ResumeLayout(false);
            this.mainViewSplitContainer.ResumeLayout(false);
            this.tabGCode.ResumeLayout(false);
            this.tabGCode.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabSliceView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabMachineControl.ResumeLayout(false);
            this.tabMachineConfig.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.SplitContainer splitContainerMainWindow;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.PictureBox picSlice;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtGCode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBinarySTLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdBuild;
        private System.Windows.Forms.ToolStripButton cmdStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdConnect;
        private System.Windows.Forms.ToolStripButton cmdDisconnect;
        private System.Windows.Forms.ToolStripButton cmdSlice1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabModel1;
        private System.Windows.Forms.TabPage tabGCode;
        private System.Windows.Forms.TabPage tabSliceView;
        private System.Windows.Forms.ToolStripButton cmdLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdSaveGCode;
        private System.Windows.Forms.TreeView treeScene;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmdRemoveObject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblMainMessage;
        private System.Windows.Forms.ToolStripLabel lblTime;
        private System.Windows.Forms.ToolStripButton cmdPause;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem saveSceneSTLToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSliceNum;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button cmdLoadGCode;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private GUI.Controls.ctlHeatTemp heatTempCtl1;
        private System.Windows.Forms.TabPage tabMachineControl;
        //private GUI.Controls.ctlMachineControl machineControl1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.TabPage tabMachineConfig;
        private GUI.Controls.ctlMachineConfig ctlMachineConfig1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdViewLayer;
        private System.Windows.Forms.TextBox txtLayerNum;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private GUI.Controls.ctlToolpathGenConfig ctlToolpathGenConfig1;
        private GUI.Controls.ctlMachineControl ctlMachineControl1;
        private System.Windows.Forms.ToolStripMenuItem estimateVolumeCostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private GUI.CustomGUI.ctlImageButton buttGlHome;
        private GUI.CustomGUI.ctlImageButton buttScale;
        private GUI.CustomGUI.ctlImageButton buttMove;
        private GUI.CustomGUI.ctlImageButton buttRotate;
        private System.Windows.Forms.ToolStripMenuItem findHolesInMeshToolStripMenuItem;
        private GUI.CustomGUI.ctlMove ctlObjMove;
        private GUI.CustomGUI.ctlRotate ctlObjRotate;
        private GUI.CustomGUI.ctlScale ctlObjScale;
        private GUI.CustomGUI.ctlImageButton buttSupports;
        private GUI.CustomGUI.ctlSupports ctlSupport;
        private GUI.CustomGUI.ctlView ctlViewOptions;
        private GUI.CustomGUI.ctlImageButton buttView;
        private GUI.CustomGUI.ctlToolTip ctlToolTip1;
        private System.Windows.Forms.SplitContainer mainViewSplitContainer;
        private GUI.CustomGUI.ctlNumber numLayer;
        private GUI.CustomGUI.ctlObjectInfo objectInfoPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private GUI.CustomGUI.ctlImageButton buttOpenFile;
        private GUI.CustomGUI.ctlImageButton buttPlay;
        private GUI.CustomGUI.ctlImageButton buttPause;
        private GUI.CustomGUI.ctlImageButton buttStop;
        private GUI.CustomGUI.ctlImageButton buttConnect;
        private GUI.CustomGUI.ctlImageButton buttDisconnect;
        private GUI.CustomGUI.ctlImageButton buttSlice;
        private GUI.CustomGUI.ctlImageButton buttConfig;
    }
}

