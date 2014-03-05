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
            this.cmbMachineProfiles = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdCfgConMch = new System.Windows.Forms.Button();
            this.lblConMachine = new System.Windows.Forms.Label();
            this.grpPrjSerial = new System.Windows.Forms.GroupBox();
            this.checkConDispEnable = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblConDisp = new System.Windows.Forms.Label();
            this.cmdCfgConDsp = new System.Windows.Forms.Button();
            this.grpMachineConfig = new System.Windows.Forms.GroupBox();
            this.cmdCreate = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.cmdRemove = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.Monitors.SuspendLayout();
            this.ProjectorRes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpPrjSerial.SuspendLayout();
            this.grpMachineConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.TabIndex = 53;
            this.label9.Text = "Machine Type";
            // 
            // cmbMachineType
            // 
            this.cmbMachineType.FormattingEnabled = true;
            this.cmbMachineType.Location = new System.Drawing.Point(137, 19);
            this.cmbMachineType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMachineType.Name = "cmbMachineType";
            this.cmbMachineType.Size = new System.Drawing.Size(213, 26);
            this.cmbMachineType.TabIndex = 52;
            this.cmbMachineType.SelectedIndexChanged += new System.EventHandler(this.cmbMachineType_SelectedIndexChanged);
            // 
            // Monitors
            // 
            this.Monitors.Controls.Add(this.lblMonInfo);
            this.Monitors.Controls.Add(this.cmdRefreshMonitors);
            this.Monitors.Controls.Add(this.lstMonitors);
            this.Monitors.Location = new System.Drawing.Point(8, 209);
            this.Monitors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Monitors.Name = "Monitors";
            this.Monitors.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Monitors.Size = new System.Drawing.Size(181, 173);
            this.Monitors.TabIndex = 49;
            this.Monitors.TabStop = false;
            this.Monitors.Text = "Display Device";
            // 
            // lblMonInfo
            // 
            this.lblMonInfo.AutoSize = true;
            this.lblMonInfo.Location = new System.Drawing.Point(9, 147);
            this.lblMonInfo.Name = "lblMonInfo";
            this.lblMonInfo.Size = new System.Drawing.Size(0, 18);
            this.lblMonInfo.TabIndex = 2;
            // 
            // cmdRefreshMonitors
            // 
            this.cmdRefreshMonitors.Location = new System.Drawing.Point(7, 132);
            this.cmdRefreshMonitors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdRefreshMonitors.Name = "cmdRefreshMonitors";
            this.cmdRefreshMonitors.Size = new System.Drawing.Size(168, 36);
            this.cmdRefreshMonitors.TabIndex = 1;
            this.cmdRefreshMonitors.Text = "Refresh";
            this.cmdRefreshMonitors.UseVisualStyleBackColor = true;
            this.cmdRefreshMonitors.Click += new System.EventHandler(this.cmdRefreshMonitors_Click);
            // 
            // lstMonitors
            // 
            this.lstMonitors.FormattingEnabled = true;
            this.lstMonitors.ItemHeight = 18;
            this.lstMonitors.Location = new System.Drawing.Point(9, 32);
            this.lstMonitors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstMonitors.Name = "lstMonitors";
            this.lstMonitors.Size = new System.Drawing.Size(164, 58);
            this.lstMonitors.TabIndex = 0;
            this.lstMonitors.SelectedIndexChanged += new System.EventHandler(this.lstMonitors_SelectedIndexChanged);
            // 
            // ProjectorRes
            // 
            this.ProjectorRes.Controls.Add(this.label1);
            this.ProjectorRes.Controls.Add(this.label2);
            this.ProjectorRes.Controls.Add(this.projheight);
            this.ProjectorRes.Controls.Add(this.projwidth);
            this.ProjectorRes.Location = new System.Drawing.Point(197, 209);
            this.ProjectorRes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProjectorRes.Name = "ProjectorRes";
            this.ProjectorRes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProjectorRes.Size = new System.Drawing.Size(213, 99);
            this.ProjectorRes.TabIndex = 48;
            this.ProjectorRes.TabStop = false;
            this.ProjectorRes.Text = "Resolution (pixels)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width";
            // 
            // projheight
            // 
            this.projheight.Location = new System.Drawing.Point(71, 62);
            this.projheight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projheight.Name = "projheight";
            this.projheight.Size = new System.Drawing.Size(67, 24);
            this.projheight.TabIndex = 1;
            this.projheight.Text = "768";
            // 
            // projwidth
            // 
            this.projwidth.Location = new System.Drawing.Point(71, 27);
            this.projwidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projwidth.Name = "projwidth";
            this.projwidth.Size = new System.Drawing.Size(67, 24);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(181, 141);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Build Size (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z";
            // 
            // txtPlatTall
            // 
            this.txtPlatTall.Location = new System.Drawing.Point(37, 98);
            this.txtPlatTall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlatTall.Name = "txtPlatTall";
            this.txtPlatTall.Size = new System.Drawing.Size(61, 24);
            this.txtPlatTall.TabIndex = 4;
            this.txtPlatTall.Text = "200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "X";
            // 
            // txtPlatHeight
            // 
            this.txtPlatHeight.Location = new System.Drawing.Point(37, 63);
            this.txtPlatHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlatHeight.Name = "txtPlatHeight";
            this.txtPlatHeight.Size = new System.Drawing.Size(61, 24);
            this.txtPlatHeight.TabIndex = 1;
            this.txtPlatHeight.Text = "77";
            // 
            // txtPlatWidth
            // 
            this.txtPlatWidth.Location = new System.Drawing.Point(37, 31);
            this.txtPlatWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlatWidth.Name = "txtPlatWidth";
            this.txtPlatWidth.Size = new System.Drawing.Size(61, 24);
            this.txtPlatWidth.TabIndex = 0;
            this.txtPlatWidth.Text = "102";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(10, 516);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(122, 48);
            this.cmdOK.TabIndex = 45;
            this.cmdOK.Text = "Apply";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmbMachineProfiles
            // 
            this.cmbMachineProfiles.FormattingEnabled = true;
            this.cmbMachineProfiles.Location = new System.Drawing.Point(8, 15);
            this.cmbMachineProfiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMachineProfiles.Name = "cmbMachineProfiles";
            this.cmbMachineProfiles.Size = new System.Drawing.Size(321, 28);
            this.cmbMachineProfiles.TabIndex = 57;
            this.cmbMachineProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbMachineProfiles_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmdCfgConMch);
            this.groupBox4.Controls.Add(this.lblConMachine);
            this.groupBox4.Location = new System.Drawing.Point(197, 61);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(213, 141);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Machine Connection";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 18);
            this.label13.TabIndex = 5;
            this.label13.Text = "Port:";
            // 
            // cmdCfgConMch
            // 
            this.cmdCfgConMch.Location = new System.Drawing.Point(13, 96);
            this.cmdCfgConMch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdCfgConMch.Name = "cmdCfgConMch";
            this.cmdCfgConMch.Size = new System.Drawing.Size(111, 31);
            this.cmdCfgConMch.TabIndex = 1;
            this.cmdCfgConMch.Text = "Configure";
            this.cmdCfgConMch.UseVisualStyleBackColor = true;
            this.cmdCfgConMch.Click += new System.EventHandler(this.cmdCfgConMch_Click);
            // 
            // lblConMachine
            // 
            this.lblConMachine.AutoSize = true;
            this.lblConMachine.Location = new System.Drawing.Point(12, 67);
            this.lblConMachine.Name = "lblConMachine";
            this.lblConMachine.Size = new System.Drawing.Size(13, 18);
            this.lblConMachine.TabIndex = 0;
            this.lblConMachine.Text = "-";
            // 
            // grpPrjSerial
            // 
            this.grpPrjSerial.Controls.Add(this.checkConDispEnable);
            this.grpPrjSerial.Controls.Add(this.label12);
            this.grpPrjSerial.Controls.Add(this.lblConDisp);
            this.grpPrjSerial.Controls.Add(this.cmdCfgConDsp);
            this.grpPrjSerial.Location = new System.Drawing.Point(197, 312);
            this.grpPrjSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpPrjSerial.Name = "grpPrjSerial";
            this.grpPrjSerial.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpPrjSerial.Size = new System.Drawing.Size(213, 133);
            this.grpPrjSerial.TabIndex = 60;
            this.grpPrjSerial.TabStop = false;
            this.grpPrjSerial.Text = "Projector Control";
            // 
            // checkConDispEnable
            // 
            this.checkConDispEnable.AutoSize = true;
            this.checkConDispEnable.Location = new System.Drawing.Point(17, 33);
            this.checkConDispEnable.Margin = new System.Windows.Forms.Padding(4);
            this.checkConDispEnable.Name = "checkConDispEnable";
            this.checkConDispEnable.Size = new System.Drawing.Size(75, 22);
            this.checkConDispEnable.TabIndex = 5;
            this.checkConDispEnable.Text = "Enable";
            this.checkConDispEnable.UseVisualStyleBackColor = true;
            this.checkConDispEnable.CheckedChanged += new System.EventHandler(this.checkConDispEnable_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 18);
            this.label12.TabIndex = 4;
            this.label12.Text = "Port:";
            // 
            // lblConDisp
            // 
            this.lblConDisp.AutoSize = true;
            this.lblConDisp.Location = new System.Drawing.Point(67, 67);
            this.lblConDisp.Name = "lblConDisp";
            this.lblConDisp.Size = new System.Drawing.Size(13, 18);
            this.lblConDisp.TabIndex = 3;
            this.lblConDisp.Text = "-";
            // 
            // cmdCfgConDsp
            // 
            this.cmdCfgConDsp.Location = new System.Drawing.Point(13, 97);
            this.cmdCfgConDsp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdCfgConDsp.Name = "cmdCfgConDsp";
            this.cmdCfgConDsp.Size = new System.Drawing.Size(111, 31);
            this.cmdCfgConDsp.TabIndex = 2;
            this.cmdCfgConDsp.Text = "Configure";
            this.cmdCfgConDsp.UseVisualStyleBackColor = true;
            this.cmdCfgConDsp.Click += new System.EventHandler(this.cmdCfgConDsp_Click);
            // 
            // grpMachineConfig
            // 
            this.grpMachineConfig.Controls.Add(this.groupBox1);
            this.grpMachineConfig.Controls.Add(this.grpPrjSerial);
            this.grpMachineConfig.Controls.Add(this.groupBox4);
            this.grpMachineConfig.Controls.Add(this.Monitors);
            this.grpMachineConfig.Controls.Add(this.label9);
            this.grpMachineConfig.Controls.Add(this.cmbMachineType);
            this.grpMachineConfig.Controls.Add(this.ProjectorRes);
            this.grpMachineConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMachineConfig.Location = new System.Drawing.Point(10, 55);
            this.grpMachineConfig.Name = "grpMachineConfig";
            this.grpMachineConfig.Size = new System.Drawing.Size(423, 453);
            this.grpMachineConfig.TabIndex = 61;
            this.grpMachineConfig.TabStop = false;
            this.grpMachineConfig.Text = "Name";
            // 
            // cmdCreate
            // 
            this.cmdCreate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cmdCreate.Checked = false;
            this.cmdCreate.CheckImage = null;
            this.cmdCreate.Gapx = 5;
            this.cmdCreate.Gapy = 5;
            this.cmdCreate.GLBackgroundImage = null;
            this.cmdCreate.GLImage = null;
            this.cmdCreate.GLVisible = false;
            this.cmdCreate.GuiAnchor = null;
            this.cmdCreate.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.cmdCreate.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPlus;
            this.cmdCreate.Location = new System.Drawing.Point(340, 8);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(40, 40);
            this.cmdCreate.StyleName = null;
            this.cmdCreate.TabIndex = 63;
            this.cmdCreate.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.cmdCreate.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cmdRemove.Checked = false;
            this.cmdRemove.CheckImage = null;
            this.cmdRemove.Gapx = 5;
            this.cmdRemove.Gapy = 5;
            this.cmdRemove.GLBackgroundImage = null;
            this.cmdRemove.GLImage = null;
            this.cmdRemove.GLVisible = false;
            this.cmdRemove.GuiAnchor = null;
            this.cmdRemove.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.cmdRemove.Image = global::UV_DLP_3D_Printer.Properties.Resources.butMinus;
            this.cmdRemove.Location = new System.Drawing.Point(388, 8);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(40, 40);
            this.cmdRemove.StyleName = null;
            this.cmdRemove.TabIndex = 64;
            this.cmdRemove.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.cmdRemove.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // ctlMachineConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdCreate);
            this.Controls.Add(this.grpMachineConfig);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmbMachineProfiles);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ctlMachineConfig";
            this.Size = new System.Drawing.Size(443, 566);
            this.Load += new System.EventHandler(this.ctlMachineConfig_Load);
            this.Monitors.ResumeLayout(false);
            this.Monitors.PerformLayout();
            this.ProjectorRes.ResumeLayout(false);
            this.ProjectorRes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpPrjSerial.ResumeLayout(false);
            this.grpPrjSerial.PerformLayout();
            this.grpMachineConfig.ResumeLayout(false);
            this.grpMachineConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMachineType;
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
        private System.Windows.Forms.ComboBox cmbMachineProfiles;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdCfgConMch;
        private System.Windows.Forms.Label lblConMachine;
        private System.Windows.Forms.GroupBox grpPrjSerial;
        private System.Windows.Forms.Label lblConDisp;
        private System.Windows.Forms.Button cmdCfgConDsp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkConDispEnable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpMachineConfig;
        private CustomGUI.ctlImageButton cmdCreate;
        private CustomGUI.ctlImageButton cmdRemove;
    }
}
