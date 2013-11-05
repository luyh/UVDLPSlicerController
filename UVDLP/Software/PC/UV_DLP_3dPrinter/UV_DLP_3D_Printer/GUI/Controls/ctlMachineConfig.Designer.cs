namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctlMachineConfig
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
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMachineType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtXFeed = new System.Windows.Forms.TextBox();
            this.txtZFeed = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYFeed = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpDriver = new System.Windows.Forms.GroupBox();
            this.lstDrivers = new System.Windows.Forms.ListBox();
            this.Monitors = new System.Windows.Forms.GroupBox();
            this.lblMonInfo = new System.Windows.Forms.Label();
            this.cmdRefreshMonitors = new System.Windows.Forms.Button();
            this.lstMonitors = new System.Windows.Forms.ListBox();
            this.ProjectorRes = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.projheight = new System.Windows.Forms.TextBox();
            this.projwidth = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlatTall = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlatHeight = new System.Windows.Forms.TextBox();
            this.txtPlatWidth = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.lstMachineProfiles = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMachineProfiles = new System.Windows.Forms.ComboBox();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdCfgConMch = new System.Windows.Forms.Button();
            this.lblConMachine = new System.Windows.Forms.Label();
            this.grpPrjSerial = new System.Windows.Forms.GroupBox();
            this.lblConDisp = new System.Windows.Forms.Label();
            this.cmdCfgConDsp = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkConDispEnable = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.grpDriver.SuspendLayout();
            this.Monitors.SuspendLayout();
            this.ProjectorRes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpPrjSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(352, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Machine Type";
            // 
            // cmbMachineType
            // 
            this.cmbMachineType.FormattingEnabled = true;
            this.cmbMachineType.Location = new System.Drawing.Point(446, 18);
            this.cmbMachineType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbMachineType.Name = "cmbMachineType";
            this.cmbMachineType.Size = new System.Drawing.Size(152, 21);
            this.cmbMachineType.TabIndex = 52;
            this.cmbMachineType.SelectedIndexChanged += new System.EventHandler(this.cmbMachineType_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtXFeed);
            this.groupBox3.Controls.Add(this.txtZFeed);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtYFeed);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(312, 50);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(109, 104);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Max Feed Rate (mm/m)";
            // 
            // txtXFeed
            // 
            this.txtXFeed.Location = new System.Drawing.Point(22, 27);
            this.txtXFeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtXFeed.Name = "txtXFeed";
            this.txtXFeed.Size = new System.Drawing.Size(44, 20);
            this.txtXFeed.TabIndex = 36;
            this.txtXFeed.Text = "3000";
            // 
            // txtZFeed
            // 
            this.txtZFeed.Location = new System.Drawing.Point(22, 68);
            this.txtZFeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtZFeed.Name = "txtZFeed";
            this.txtZFeed.Size = new System.Drawing.Size(44, 20);
            this.txtZFeed.TabIndex = 38;
            this.txtZFeed.Text = "1500";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Z";
            // 
            // txtYFeed
            // 
            this.txtYFeed.Location = new System.Drawing.Point(22, 48);
            this.txtYFeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtYFeed.Name = "txtYFeed";
            this.txtYFeed.Size = new System.Drawing.Size(44, 20);
            this.txtYFeed.TabIndex = 40;
            this.txtYFeed.Text = "3000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "X";
            // 
            // grpDriver
            // 
            this.grpDriver.Controls.Add(this.lstDrivers);
            this.grpDriver.Location = new System.Drawing.Point(427, 50);
            this.grpDriver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDriver.Name = "grpDriver";
            this.grpDriver.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDriver.Size = new System.Drawing.Size(150, 104);
            this.grpDriver.TabIndex = 50;
            this.grpDriver.TabStop = false;
            this.grpDriver.Text = "Driver";
            // 
            // lstDrivers
            // 
            this.lstDrivers.FormattingEnabled = true;
            this.lstDrivers.Location = new System.Drawing.Point(5, 18);
            this.lstDrivers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstDrivers.Name = "lstDrivers";
            this.lstDrivers.Size = new System.Drawing.Size(141, 69);
            this.lstDrivers.TabIndex = 0;
            // 
            // Monitors
            // 
            this.Monitors.Controls.Add(this.lblMonInfo);
            this.Monitors.Controls.Add(this.cmdRefreshMonitors);
            this.Monitors.Controls.Add(this.lstMonitors);
            this.Monitors.Location = new System.Drawing.Point(199, 158);
            this.Monitors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Monitors.Name = "Monitors";
            this.Monitors.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Monitors.Size = new System.Drawing.Size(223, 113);
            this.Monitors.TabIndex = 49;
            this.Monitors.TabStop = false;
            this.Monitors.Text = "Select Print Display Device";
            // 
            // lblMonInfo
            // 
            this.lblMonInfo.AutoSize = true;
            this.lblMonInfo.Location = new System.Drawing.Point(5, 95);
            this.lblMonInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonInfo.Name = "lblMonInfo";
            this.lblMonInfo.Size = new System.Drawing.Size(0, 13);
            this.lblMonInfo.TabIndex = 2;
            // 
            // cmdRefreshMonitors
            // 
            this.cmdRefreshMonitors.Location = new System.Drawing.Point(4, 86);
            this.cmdRefreshMonitors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdRefreshMonitors.Name = "cmdRefreshMonitors";
            this.cmdRefreshMonitors.Size = new System.Drawing.Size(214, 23);
            this.cmdRefreshMonitors.TabIndex = 1;
            this.cmdRefreshMonitors.Text = "Refresh";
            this.cmdRefreshMonitors.UseVisualStyleBackColor = true;
            this.cmdRefreshMonitors.Click += new System.EventHandler(this.cmdRefreshMonitors_Click);
            // 
            // lstMonitors
            // 
            this.lstMonitors.FormattingEnabled = true;
            this.lstMonitors.Location = new System.Drawing.Point(5, 21);
            this.lstMonitors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstMonitors.Name = "lstMonitors";
            this.lstMonitors.Size = new System.Drawing.Size(214, 56);
            this.lstMonitors.TabIndex = 0;
            this.lstMonitors.SelectedIndexChanged += new System.EventHandler(this.lstMonitors_SelectedIndexChanged);
            // 
            // ProjectorRes
            // 
            this.ProjectorRes.Controls.Add(this.label1);
            this.ProjectorRes.Controls.Add(this.label2);
            this.ProjectorRes.Controls.Add(this.projheight);
            this.ProjectorRes.Controls.Add(this.projwidth);
            this.ProjectorRes.Location = new System.Drawing.Point(426, 158);
            this.ProjectorRes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProjectorRes.Name = "ProjectorRes";
            this.ProjectorRes.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProjectorRes.Size = new System.Drawing.Size(151, 109);
            this.ProjectorRes.TabIndex = 48;
            this.ProjectorRes.TabStop = false;
            this.ProjectorRes.Text = "Display Resolution (pixels)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width";
            // 
            // projheight
            // 
            this.projheight.Location = new System.Drawing.Point(43, 50);
            this.projheight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.projheight.Name = "projheight";
            this.projheight.Size = new System.Drawing.Size(42, 20);
            this.projheight.TabIndex = 1;
            this.projheight.Text = "768";
            // 
            // projwidth
            // 
            this.projwidth.Location = new System.Drawing.Point(43, 27);
            this.projwidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.projwidth.Name = "projwidth";
            this.projwidth.Size = new System.Drawing.Size(42, 20);
            this.projwidth.TabIndex = 0;
            this.projwidth.Text = "1024";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPlatTall);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPlatHeight);
            this.groupBox1.Controls.Add(this.txtPlatWidth);
            this.groupBox1.Location = new System.Drawing.Point(199, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(109, 104);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis Length (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z";
            // 
            // txtPlatTall
            // 
            this.txtPlatTall.Location = new System.Drawing.Point(22, 70);
            this.txtPlatTall.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPlatTall.Name = "txtPlatTall";
            this.txtPlatTall.Size = new System.Drawing.Size(38, 20);
            this.txtPlatTall.TabIndex = 4;
            this.txtPlatTall.Text = "200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "X";
            // 
            // txtPlatHeight
            // 
            this.txtPlatHeight.Location = new System.Drawing.Point(22, 50);
            this.txtPlatHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPlatHeight.Name = "txtPlatHeight";
            this.txtPlatHeight.Size = new System.Drawing.Size(38, 20);
            this.txtPlatHeight.TabIndex = 1;
            this.txtPlatHeight.Text = "77";
            // 
            // txtPlatWidth
            // 
            this.txtPlatWidth.Location = new System.Drawing.Point(22, 27);
            this.txtPlatWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPlatWidth.Name = "txtPlatWidth";
            this.txtPlatWidth.Size = new System.Drawing.Size(38, 20);
            this.txtPlatWidth.TabIndex = 0;
            this.txtPlatWidth.Text = "102";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(203, 275);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(104, 31);
            this.cmdOK.TabIndex = 45;
            this.cmdOK.Text = "Save Changes";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(84, 163);
            this.cmdDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(76, 27);
            this.cmdDelete.TabIndex = 56;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(4, 163);
            this.cmdNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(76, 27);
            this.cmdNew.TabIndex = 55;
            this.cmdNew.Text = "Create";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // lstMachineProfiles
            // 
            this.lstMachineProfiles.FormattingEnabled = true;
            this.lstMachineProfiles.Location = new System.Drawing.Point(4, 34);
            this.lstMachineProfiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstMachineProfiles.Name = "lstMachineProfiles";
            this.lstMachineProfiles.Size = new System.Drawing.Size(157, 121);
            this.lstMachineProfiles.TabIndex = 54;
            this.lstMachineProfiles.SelectedIndexChanged += new System.EventHandler(this.lstMachineProfiles_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lstMachineProfiles);
            this.groupBox2.Controls.Add(this.cmdDelete);
            this.groupBox2.Controls.Add(this.cmdNew);
            this.groupBox2.Location = new System.Drawing.Point(10, 67);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(170, 200);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configured Machine Profiles";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "All Profiles:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Profile in Use:";
            // 
            // cmbMachineProfiles
            // 
            this.cmbMachineProfiles.FormattingEnabled = true;
            this.cmbMachineProfiles.Location = new System.Drawing.Point(10, 42);
            this.cmbMachineProfiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbMachineProfiles.Name = "cmbMachineProfiles";
            this.cmbMachineProfiles.Size = new System.Drawing.Size(156, 21);
            this.cmbMachineProfiles.TabIndex = 57;
            this.cmbMachineProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbMachineProfiles_SelectedIndexChanged);
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new System.Drawing.Point(199, 23);
            this.lblMachineName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(35, 13);
            this.lblMachineName.TabIndex = 58;
            this.lblMachineName.Text = "Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmdCfgConMch);
            this.groupBox4.Controls.Add(this.lblConMachine);
            this.groupBox4.Location = new System.Drawing.Point(581, 50);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(128, 104);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Machine Connection";
            // 
            // cmdCfgConMch
            // 
            this.cmdCfgConMch.Location = new System.Drawing.Point(8, 69);
            this.cmdCfgConMch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdCfgConMch.Name = "cmdCfgConMch";
            this.cmdCfgConMch.Size = new System.Drawing.Size(67, 20);
            this.cmdCfgConMch.TabIndex = 1;
            this.cmdCfgConMch.Text = "Configure";
            this.cmdCfgConMch.UseVisualStyleBackColor = true;
            this.cmdCfgConMch.Click += new System.EventHandler(this.cmdCfgConMch_Click);
            // 
            // lblConMachine
            // 
            this.lblConMachine.AutoSize = true;
            this.lblConMachine.Location = new System.Drawing.Point(38, 48);
            this.lblConMachine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConMachine.Name = "lblConMachine";
            this.lblConMachine.Size = new System.Drawing.Size(10, 13);
            this.lblConMachine.TabIndex = 0;
            this.lblConMachine.Text = "-";
            // 
            // grpPrjSerial
            // 
            this.grpPrjSerial.Controls.Add(this.checkConDispEnable);
            this.grpPrjSerial.Controls.Add(this.label12);
            this.grpPrjSerial.Controls.Add(this.lblConDisp);
            this.grpPrjSerial.Controls.Add(this.cmdCfgConDsp);
            this.grpPrjSerial.Location = new System.Drawing.Point(581, 158);
            this.grpPrjSerial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpPrjSerial.Name = "grpPrjSerial";
            this.grpPrjSerial.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpPrjSerial.Size = new System.Drawing.Size(128, 109);
            this.grpPrjSerial.TabIndex = 60;
            this.grpPrjSerial.TabStop = false;
            this.grpPrjSerial.Text = "Projector Serial Control";
            // 
            // lblConDisp
            // 
            this.lblConDisp.AutoSize = true;
            this.lblConDisp.Location = new System.Drawing.Point(38, 50);
            this.lblConDisp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConDisp.Name = "lblConDisp";
            this.lblConDisp.Size = new System.Drawing.Size(10, 13);
            this.lblConDisp.TabIndex = 3;
            this.lblConDisp.Text = "-";
            // 
            // cmdCfgConDsp
            // 
            this.cmdCfgConDsp.Location = new System.Drawing.Point(8, 75);
            this.cmdCfgConDsp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdCfgConDsp.Name = "cmdCfgConDsp";
            this.cmdCfgConDsp.Size = new System.Drawing.Size(67, 20);
            this.cmdCfgConDsp.TabIndex = 2;
            this.cmdCfgConDsp.Text = "Configure";
            this.cmdCfgConDsp.UseVisualStyleBackColor = true;
            this.cmdCfgConDsp.Click += new System.EventHandler(this.cmdCfgConDsp_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 50);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Port:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 48);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Port:";
            // 
            // checkConDispEnable
            // 
            this.checkConDispEnable.AutoSize = true;
            this.checkConDispEnable.Location = new System.Drawing.Point(10, 26);
            this.checkConDispEnable.Name = "checkConDispEnable";
            this.checkConDispEnable.Size = new System.Drawing.Size(59, 17);
            this.checkConDispEnable.TabIndex = 5;
            this.checkConDispEnable.Text = "Enable";
            this.checkConDispEnable.UseVisualStyleBackColor = true;
            this.checkConDispEnable.CheckedChanged += new System.EventHandler(this.checkConDispEnable_CheckedChanged);
            // 
            // ctlMachineConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPrjSerial);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMachineProfiles);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblMachineName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbMachineType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpDriver);
            this.Controls.Add(this.Monitors);
            this.Controls.Add(this.ProjectorRes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdOK);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ctlMachineConfig";
            this.Size = new System.Drawing.Size(791, 418);
            this.Load += new System.EventHandler(this.ctlMachineConfig_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpDriver.ResumeLayout(false);
            this.Monitors.ResumeLayout(false);
            this.Monitors.PerformLayout();
            this.ProjectorRes.ResumeLayout(false);
            this.ProjectorRes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpPrjSerial.ResumeLayout(false);
            this.grpPrjSerial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMachineType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtXFeed;
        private System.Windows.Forms.TextBox txtZFeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtYFeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpDriver;
        private System.Windows.Forms.ListBox lstDrivers;
        private System.Windows.Forms.GroupBox Monitors;
        private System.Windows.Forms.Label lblMonInfo;
        private System.Windows.Forms.Button cmdRefreshMonitors;
        private System.Windows.Forms.ListBox lstMonitors;
        private System.Windows.Forms.GroupBox ProjectorRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox projheight;
        private System.Windows.Forms.TextBox projwidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlatTall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlatHeight;
        private System.Windows.Forms.TextBox txtPlatWidth;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.ListBox lstMachineProfiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbMachineProfiles;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdCfgConMch;
        private System.Windows.Forms.Label lblConMachine;
        private System.Windows.Forms.GroupBox grpPrjSerial;
        private System.Windows.Forms.Label lblConDisp;
        private System.Windows.Forms.Button cmdCfgConDsp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkConDispEnable;
        private System.Windows.Forms.Label label12;
    }
}
