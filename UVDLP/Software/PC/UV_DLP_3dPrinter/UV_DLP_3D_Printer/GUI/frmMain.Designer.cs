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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBinarySTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.buttOpenFile = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttPlay = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttPause = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttStop = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttConnect = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttDisconnect = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttSlice = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttConfig = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttView3D = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttViewSlice = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttViewGcode = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMainMessage = new System.Windows.Forms.Label();
            this.ctlGcodeView1 = new UV_DLP_3D_Printer.GUI.Controls.ctlGcodeView();
            this.ctlSliceView1 = new UV_DLP_3D_Printer.GUI.Controls.ctlSliceView();
            this.ctl3DView1 = new UV_DLP_3D_Printer.GUI.Controls.ctl3DView();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMachineControl = new System.Windows.Forms.TabPage();
            this.ctlMachineControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineControl();
            this.tabMachineConfig = new System.Windows.Forms.TabPage();
            this.ctlMachineConfig1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineConfig();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctlToolpathGenConfig1 = new UV_DLP_3D_Printer.GUI.Controls.ctlToolpathGenConfig();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ctlToolTip1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlToolTip();
            this.splashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.splitContainerMainWindow.Panel1.SuspendLayout();
            this.splitContainerMainWindow.Panel2.SuspendLayout();
            this.splitContainerMainWindow.SuspendLayout();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabMachineControl.SuspendLayout();
            this.tabMachineConfig.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.saveSceneSTLToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.testToolStripMenuItem,
            this.findHolesInMeshToolStripMenuItem,
            this.splashToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadBinarySTLToolStripMenuItem
            // 
            this.loadBinarySTLToolStripMenuItem.Name = "loadBinarySTLToolStripMenuItem";
            this.loadBinarySTLToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.loadBinarySTLToolStripMenuItem.Text = "Load Model";
            this.loadBinarySTLToolStripMenuItem.Click += new System.EventHandler(this.loadBinarySTLToolStripMenuItem_Click);
            // 
            // saveSceneSTLToolStripMenuItem
            // 
            this.saveSceneSTLToolStripMenuItem.Name = "saveSceneSTLToolStripMenuItem";
            this.saveSceneSTLToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveSceneSTLToolStripMenuItem.Text = "Save Scene STL";
            this.saveSceneSTLToolStripMenuItem.Click += new System.EventHandler(this.saveSceneSTLToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // findHolesInMeshToolStripMenuItem
            // 
            this.findHolesInMeshToolStripMenuItem.Name = "findHolesInMeshToolStripMenuItem";
            this.findHolesInMeshToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
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
            this.splitContainerMainWindow.BackColor = System.Drawing.Color.Navy;
            this.splitContainerMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainWindow.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainWindow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerMainWindow.Name = "splitContainerMainWindow";
            this.splitContainerMainWindow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainWindow.Panel1
            // 
            this.splitContainerMainWindow.Panel1.Controls.Add(this.splitContainerTop);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainerMainWindow.Panel2
            // 
            this.splitContainerMainWindow.Panel2.Controls.Add(this.txtLog);
            this.splitContainerMainWindow.Size = new System.Drawing.Size(1457, 793);
            this.splitContainerMainWindow.SplitterDistance = 666;
            this.splitContainerMainWindow.TabIndex = 21;
            // 
            // splitContainerTop
            // 
            this.splitContainerTop.BackColor = System.Drawing.Color.Navy;
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
            this.splitContainerTop.Panel2.Controls.Add(this.ctlGcodeView1);
            this.splitContainerTop.Panel2.Controls.Add(this.ctlSliceView1);
            this.splitContainerTop.Panel2.Controls.Add(this.ctl3DView1);
            this.splitContainerTop.Panel2.Controls.Add(this.tabMain);
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
            this.flowLayoutPanel1.Controls.Add(this.buttView3D);
            this.flowLayoutPanel1.Controls.Add(this.buttViewSlice);
            this.flowLayoutPanel1.Controls.Add(this.buttViewGcode);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1457, 56);
            this.flowLayoutPanel1.TabIndex = 0;
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
            this.buttConfig.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.buttConfig.Name = "buttConfig";
            this.buttConfig.Size = new System.Drawing.Size(48, 48);
            this.buttConfig.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttConfig, "Configuration");
            this.buttConfig.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttConfig.Click += new System.EventHandler(this.buttConfig_Click);
            // 
            // buttView3D
            // 
            this.buttView3D.BackColor = System.Drawing.Color.Navy;
            this.buttView3D.Checked = false;
            this.buttView3D.CheckImage = null;
            this.buttView3D.Gapx = 10;
            this.buttView3D.Gapy = 10;
            this.buttView3D.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttView3D.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewModel;
            this.buttView3D.Location = new System.Drawing.Point(460, 4);
            this.buttView3D.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttView3D.Name = "buttView3D";
            this.buttView3D.Size = new System.Drawing.Size(48, 48);
            this.buttView3D.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttView3D, "3D model view");
            this.buttView3D.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttView3D.Click += new System.EventHandler(this.buttView3D_Click);
            // 
            // buttViewSlice
            // 
            this.buttViewSlice.BackColor = System.Drawing.Color.Navy;
            this.buttViewSlice.Checked = false;
            this.buttViewSlice.CheckImage = null;
            this.buttViewSlice.Gapx = 10;
            this.buttViewSlice.Gapy = 10;
            this.buttViewSlice.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttViewSlice.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewSlice;
            this.buttViewSlice.Location = new System.Drawing.Point(512, 4);
            this.buttViewSlice.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttViewSlice.Name = "buttViewSlice";
            this.buttViewSlice.Size = new System.Drawing.Size(48, 48);
            this.buttViewSlice.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttViewSlice, "Slice view");
            this.buttViewSlice.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttViewSlice.Click += new System.EventHandler(this.buttViewSlice_Click);
            // 
            // buttViewGcode
            // 
            this.buttViewGcode.BackColor = System.Drawing.Color.Navy;
            this.buttViewGcode.Checked = false;
            this.buttViewGcode.CheckImage = null;
            this.buttViewGcode.Gapx = 10;
            this.buttViewGcode.Gapy = 10;
            this.buttViewGcode.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttViewGcode.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewGcode;
            this.buttViewGcode.Location = new System.Drawing.Point(564, 4);
            this.buttViewGcode.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.buttViewGcode.Name = "buttViewGcode";
            this.buttViewGcode.Size = new System.Drawing.Size(48, 48);
            this.buttViewGcode.TabIndex = 18;
            this.ctlToolTip1.SetToolTip(this.buttViewGcode, "G-code view");
            this.buttViewGcode.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttViewGcode.Click += new System.EventHandler(this.buttViewGcode_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblTime);
            this.flowLayoutPanel2.Controls.Add(this.lblMainMessage);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(615, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(377, 49);
            this.flowLayoutPanel2.TabIndex = 19;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Arial", 17.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(3, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(50, 21);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time";
            // 
            // lblMainMessage
            // 
            this.lblMainMessage.AutoSize = true;
            this.lblMainMessage.Font = new System.Drawing.Font("Arial", 17.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMainMessage.ForeColor = System.Drawing.Color.White;
            this.lblMainMessage.Location = new System.Drawing.Point(3, 21);
            this.lblMainMessage.Name = "lblMainMessage";
            this.lblMainMessage.Size = new System.Drawing.Size(83, 21);
            this.lblMainMessage.TabIndex = 0;
            this.lblMainMessage.Text = "Message";
            // 
            // ctlGcodeView1
            // 
            this.ctlGcodeView1.Location = new System.Drawing.Point(52, 369);
            this.ctlGcodeView1.Name = "ctlGcodeView1";
            this.ctlGcodeView1.Size = new System.Drawing.Size(314, 153);
            this.ctlGcodeView1.TabIndex = 23;
            // 
            // ctlSliceView1
            // 
            this.ctlSliceView1.Location = new System.Drawing.Point(52, 261);
            this.ctlSliceView1.Name = "ctlSliceView1";
            this.ctlSliceView1.Size = new System.Drawing.Size(314, 86);
            this.ctlSliceView1.TabIndex = 22;
            // 
            // ctl3DView1
            // 
            this.ctl3DView1.Location = new System.Drawing.Point(52, 17);
            this.ctl3DView1.Name = "ctl3DView1";
            this.ctl3DView1.Size = new System.Drawing.Size(314, 216);
            this.ctl3DView1.TabIndex = 21;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMachineControl);
            this.tabMain.Controls.Add(this.tabMachineConfig);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Location = new System.Drawing.Point(398, 17);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1047, 567);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 18;
            // 
            // tabMachineControl
            // 
            this.tabMachineControl.Controls.Add(this.ctlMachineControl1);
            this.tabMachineControl.Location = new System.Drawing.Point(4, 25);
            this.tabMachineControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMachineControl.Name = "tabMachineControl";
            this.tabMachineControl.Size = new System.Drawing.Size(1039, 538);
            this.tabMachineControl.TabIndex = 3;
            this.tabMachineControl.Text = "Machine Control";
            this.tabMachineControl.UseVisualStyleBackColor = true;
            this.tabMachineControl.Enter += new System.EventHandler(this.tabMachineControl_Enter);
            // 
            // ctlMachineControl1
            // 
            this.ctlMachineControl1.Location = new System.Drawing.Point(3, 2);
            this.ctlMachineControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctlMachineControl1.Name = "ctlMachineControl1";
            this.ctlMachineControl1.Size = new System.Drawing.Size(949, 558);
            this.ctlMachineControl1.TabIndex = 0;
            // 
            // tabMachineConfig
            // 
            this.tabMachineConfig.Controls.Add(this.ctlMachineConfig1);
            this.tabMachineConfig.Location = new System.Drawing.Point(4, 25);
            this.tabMachineConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMachineConfig.Name = "tabMachineConfig";
            this.tabMachineConfig.Size = new System.Drawing.Size(1039, 538);
            this.tabMachineConfig.TabIndex = 4;
            this.tabMachineConfig.Text = "Machine Config";
            this.tabMachineConfig.UseVisualStyleBackColor = true;
            // 
            // ctlMachineConfig1
            // 
            this.ctlMachineConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlMachineConfig1.Location = new System.Drawing.Point(0, 0);
            this.ctlMachineConfig1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctlMachineConfig1.Name = "ctlMachineConfig1";
            this.ctlMachineConfig1.Size = new System.Drawing.Size(1039, 538);
            this.ctlMachineConfig1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctlToolpathGenConfig1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1039, 538);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Slice Profile Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctlToolpathGenConfig1
            // 
            this.ctlToolpathGenConfig1.Location = new System.Drawing.Point(3, 4);
            this.ctlToolpathGenConfig1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctlToolpathGenConfig1.Name = "ctlToolpathGenConfig1";
            this.ctlToolpathGenConfig1.Size = new System.Drawing.Size(1036, 505);
            this.ctlToolpathGenConfig1.TabIndex = 0;
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
            this.txtLog.Size = new System.Drawing.Size(1457, 123);
            this.txtLog.TabIndex = 0;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.RestoreDirectory = true;
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
            // splashToolStripMenuItem
            // 
            this.splashToolStripMenuItem.Name = "splashToolStripMenuItem";
            this.splashToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.splashToolStripMenuItem.Text = "Splash";
            this.splashToolStripMenuItem.Click += new System.EventHandler(this.splashToolStripMenuItem_Click);
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
            this.splitContainerMainWindow.Panel2.PerformLayout();
            this.splitContainerMainWindow.ResumeLayout(false);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            this.splitContainerTop.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabMachineControl.ResumeLayout(false);
            this.tabMachineConfig.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.SplitContainer splitContainerMainWindow;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBinarySTLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem saveSceneSTLToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabMachineControl;
        //private GUI.Controls.ctlMachineControl machineControl1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.TabPage tabMachineConfig;
        private GUI.Controls.ctlMachineConfig ctlMachineConfig1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private GUI.Controls.ctlToolpathGenConfig ctlToolpathGenConfig1;
        private GUI.Controls.ctlMachineControl ctlMachineControl1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findHolesInMeshToolStripMenuItem;
        private GUI.CustomGUI.ctlToolTip ctlToolTip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private GUI.CustomGUI.ctlImageButton buttOpenFile;
        private GUI.CustomGUI.ctlImageButton buttPlay;
        private GUI.CustomGUI.ctlImageButton buttPause;
        private GUI.CustomGUI.ctlImageButton buttStop;
        private GUI.CustomGUI.ctlImageButton buttConnect;
        private GUI.CustomGUI.ctlImageButton buttDisconnect;
        private GUI.CustomGUI.ctlImageButton buttSlice;
        private GUI.CustomGUI.ctlImageButton buttConfig;
        private GUI.CustomGUI.ctlImageButton buttView3D;
        private GUI.CustomGUI.ctlImageButton buttViewSlice;
        private GUI.CustomGUI.ctlImageButton buttViewGcode;
        private GUI.Controls.ctl3DView ctl3DView1;
        private GUI.Controls.ctlSliceView ctlSliceView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblMainMessage;
        private GUI.Controls.ctlGcodeView ctlGcodeView1;
        private System.Windows.Forms.ToolStripMenuItem splashToolStripMenuItem;
    }
}

