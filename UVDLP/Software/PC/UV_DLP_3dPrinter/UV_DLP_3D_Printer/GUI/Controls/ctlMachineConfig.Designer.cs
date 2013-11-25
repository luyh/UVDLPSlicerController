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
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.lstMachineProfiles = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMachineProfiles = new System.Windows.Forms.ComboBox();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdCfgConMch = new System.Windows.Forms.Button();
            this.lblConMachine = new System.Windows.Forms.Label();
            this.grpPrjSerial = new System.Windows.Forms.GroupBox();
            this.checkConDispEnable = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblConDisp = new System.Windows.Forms.Label();
            this.cmdCfgConDsp = new System.Windows.Forms.Button();
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
            this.label9.Location = new System.Drawing.Point(624, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 17);
            this.label9.TabIndex = 53;
            this.label9.Text = "Machine Type";
            // 
            // cmbMachineType
            // 
            this.cmbMachineType.FormattingEnabled = true;
            this.cmbMachineType.Location = new System.Drawing.Point(627, 81);
            this.cmbMachineType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMachineType.Name = "cmbMachineType";
            this.cmbMachineType.Size = new System.Drawing.Size(171, 24);
            this.cmbMachineType.TabIndex = 52;
            this.cmbMachineType.SelectedIndexChanged += new System.EventHandler(this.cmbMachineType_SelectedIndexChanged);
            // 
            // Monitors
            // 
            this.Monitors.Controls.Add(this.lblMonInfo);
            this.Monitors.Controls.Add(this.cmdRefreshMonitors);
            this.Monitors.Controls.Add(this.lstMonitors);
            this.Monitors.Location = new System.Drawing.Point(265, 194);
            this.Monitors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Monitors.Name = "Monitors";
            this.Monitors.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Monitors.Size = new System.Drawing.Size(220, 139);
            this.Monitors.TabIndex = 49;
            this.Monitors.TabStop = false;
            this.Monitors.Text = "Select Print Display Device";
            // 
            // lblMonInfo
            // 
            this.lblMonInfo.AutoSize = true;
            this.lblMonInfo.Location = new System.Drawing.Point(7, 117);
            this.lblMonInfo.Name = "lblMonInfo";
            this.lblMonInfo.Size = new System.Drawing.Size(0, 17);
            this.lblMonInfo.TabIndex = 2;
            // 
            // cmdRefreshMonitors
            // 
            this.cmdRefreshMonitors.Location = new System.Drawing.Point(5, 106);
            this.cmdRefreshMonitors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdRefreshMonitors.Name = "cmdRefreshMonitors";
            this.cmdRefreshMonitors.Size = new System.Drawing.Size(205, 28);
            this.cmdRefreshMonitors.TabIndex = 1;
            this.cmdRefreshMonitors.Text = "Refresh";
            this.cmdRefreshMonitors.UseVisualStyleBackColor = true;
            this.cmdRefreshMonitors.Click += new System.EventHandler(this.cmdRefreshMonitors_Click);
            // 
            // lstMonitors
            // 
            this.lstMonitors.FormattingEnabled = true;
            this.lstMonitors.ItemHeight = 16;
            this.lstMonitors.Location = new System.Drawing.Point(7, 26);
            this.lstMonitors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstMonitors.Name = "lstMonitors";
            this.lstMonitors.Size = new System.Drawing.Size(203, 68);
            this.lstMonitors.TabIndex = 0;
            this.lstMonitors.SelectedIndexChanged += new System.EventHandler(this.lstMonitors_SelectedIndexChanged);
            // 
            // ProjectorRes
            // 
            this.ProjectorRes.Controls.Add(this.label1);
            this.ProjectorRes.Controls.Add(this.label2);
            this.ProjectorRes.Controls.Add(this.projheight);
            this.ProjectorRes.Controls.Add(this.projwidth);
            this.ProjectorRes.Location = new System.Drawing.Point(491, 194);
            this.ProjectorRes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProjectorRes.Name = "ProjectorRes";
            this.ProjectorRes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProjectorRes.Size = new System.Drawing.Size(160, 139);
            this.ProjectorRes.TabIndex = 48;
            this.ProjectorRes.TabStop = false;
            this.ProjectorRes.Text = "Resolution (pixels)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width";
            // 
            // projheight
            // 
            this.projheight.Location = new System.Drawing.Point(57, 62);
            this.projheight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projheight.Name = "projheight";
            this.projheight.Size = new System.Drawing.Size(55, 22);
            this.projheight.TabIndex = 1;
            this.projheight.Text = "768";
            // 
            // projwidth
            // 
            this.projwidth.Location = new System.Drawing.Point(57, 33);
            this.projwidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projwidth.Name = "projwidth";
            this.projwidth.Size = new System.Drawing.Size(55, 22);
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
            this.groupBox1.Location = new System.Drawing.Point(265, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(145, 128);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis Length (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z";
            // 
            // txtPlatTall
            // 
            this.txtPlatTall.Location = new System.Drawing.Point(29, 86);
            this.txtPlatTall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlatTall.Name = "txtPlatTall";
            this.txtPlatTall.Size = new System.Drawing.Size(49, 22);
            this.txtPlatTall.TabIndex = 4;
            this.txtPlatTall.Text = "200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "X";
            // 
            // txtPlatHeight
            // 
            this.txtPlatHeight.Location = new System.Drawing.Point(29, 62);
            this.txtPlatHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlatHeight.Name = "txtPlatHeight";
            this.txtPlatHeight.Size = new System.Drawing.Size(49, 22);
            this.txtPlatHeight.TabIndex = 1;
            this.txtPlatHeight.Text = "77";
            // 
            // txtPlatWidth
            // 
            this.txtPlatWidth.Location = new System.Drawing.Point(29, 33);
            this.txtPlatWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlatWidth.Name = "txtPlatWidth";
            this.txtPlatWidth.Size = new System.Drawing.Size(49, 22);
            this.txtPlatWidth.TabIndex = 0;
            this.txtPlatWidth.Text = "102";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(271, 338);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(98, 38);
            this.cmdOK.TabIndex = 45;
            this.cmdOK.Text = "Apply";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(112, 201);
            this.cmdDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(101, 33);
            this.cmdDelete.TabIndex = 56;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(5, 201);
            this.cmdNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(101, 33);
            this.cmdNew.TabIndex = 55;
            this.cmdNew.Text = "Create";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // lstMachineProfiles
            // 
            this.lstMachineProfiles.FormattingEnabled = true;
            this.lstMachineProfiles.ItemHeight = 16;
            this.lstMachineProfiles.Location = new System.Drawing.Point(5, 42);
            this.lstMachineProfiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstMachineProfiles.Name = "lstMachineProfiles";
            this.lstMachineProfiles.Size = new System.Drawing.Size(208, 148);
            this.lstMachineProfiles.TabIndex = 54;
            this.lstMachineProfiles.SelectedIndexChanged += new System.EventHandler(this.lstMachineProfiles_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lstMachineProfiles);
            this.groupBox2.Controls.Add(this.cmdDelete);
            this.groupBox2.Controls.Add(this.cmdNew);
            this.groupBox2.Location = new System.Drawing.Point(13, 82);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(227, 246);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configured Machine Profiles";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 17);
            this.label11.TabIndex = 59;
            this.label11.Text = "All Profiles:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 58;
            this.label10.Text = "Profile in Use:";
            // 
            // cmbMachineProfiles
            // 
            this.cmbMachineProfiles.FormattingEnabled = true;
            this.cmbMachineProfiles.Location = new System.Drawing.Point(13, 52);
            this.cmbMachineProfiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMachineProfiles.Name = "cmbMachineProfiles";
            this.cmbMachineProfiles.Size = new System.Drawing.Size(227, 24);
            this.cmbMachineProfiles.TabIndex = 57;
            this.cmbMachineProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbMachineProfiles_SelectedIndexChanged);
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new System.Drawing.Point(265, 28);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(45, 17);
            this.lblMachineName.TabIndex = 58;
            this.lblMachineName.Text = "Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmdCfgConMch);
            this.groupBox4.Controls.Add(this.lblConMachine);
            this.groupBox4.Location = new System.Drawing.Point(416, 62);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(171, 128);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Machine Connection";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "Port:";
            // 
            // cmdCfgConMch
            // 
            this.cmdCfgConMch.Location = new System.Drawing.Point(11, 85);
            this.cmdCfgConMch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdCfgConMch.Name = "cmdCfgConMch";
            this.cmdCfgConMch.Size = new System.Drawing.Size(89, 25);
            this.cmdCfgConMch.TabIndex = 1;
            this.cmdCfgConMch.Text = "Configure";
            this.cmdCfgConMch.UseVisualStyleBackColor = true;
            this.cmdCfgConMch.Click += new System.EventHandler(this.cmdCfgConMch_Click);
            // 
            // lblConMachine
            // 
            this.lblConMachine.AutoSize = true;
            this.lblConMachine.Location = new System.Drawing.Point(51, 59);
            this.lblConMachine.Name = "lblConMachine";
            this.lblConMachine.Size = new System.Drawing.Size(13, 17);
            this.lblConMachine.TabIndex = 0;
            this.lblConMachine.Text = "-";
            // 
            // grpPrjSerial
            // 
            this.grpPrjSerial.Controls.Add(this.checkConDispEnable);
            this.grpPrjSerial.Controls.Add(this.label12);
            this.grpPrjSerial.Controls.Add(this.lblConDisp);
            this.grpPrjSerial.Controls.Add(this.cmdCfgConDsp);
            this.grpPrjSerial.Location = new System.Drawing.Point(657, 194);
            this.grpPrjSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpPrjSerial.Name = "grpPrjSerial";
            this.grpPrjSerial.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpPrjSerial.Size = new System.Drawing.Size(171, 139);
            this.grpPrjSerial.TabIndex = 60;
            this.grpPrjSerial.TabStop = false;
            this.grpPrjSerial.Text = "Projector Serial Control";
            // 
            // checkConDispEnable
            // 
            this.checkConDispEnable.AutoSize = true;
            this.checkConDispEnable.Location = new System.Drawing.Point(13, 32);
            this.checkConDispEnable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkConDispEnable.Name = "checkConDispEnable";
            this.checkConDispEnable.Size = new System.Drawing.Size(74, 21);
            this.checkConDispEnable.TabIndex = 5;
            this.checkConDispEnable.Text = "Enable";
            this.checkConDispEnable.UseVisualStyleBackColor = true;
            this.checkConDispEnable.CheckedChanged += new System.EventHandler(this.checkConDispEnable_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Port:";
            // 
            // lblConDisp
            // 
            this.lblConDisp.AutoSize = true;
            this.lblConDisp.Location = new System.Drawing.Point(51, 62);
            this.lblConDisp.Name = "lblConDisp";
            this.lblConDisp.Size = new System.Drawing.Size(13, 17);
            this.lblConDisp.TabIndex = 3;
            this.lblConDisp.Text = "-";
            // 
            // cmdCfgConDsp
            // 
            this.cmdCfgConDsp.Location = new System.Drawing.Point(11, 92);
            this.cmdCfgConDsp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdCfgConDsp.Name = "cmdCfgConDsp";
            this.cmdCfgConDsp.Size = new System.Drawing.Size(89, 25);
            this.cmdCfgConDsp.TabIndex = 2;
            this.cmdCfgConDsp.Text = "Configure";
            this.cmdCfgConDsp.UseVisualStyleBackColor = true;
            this.cmdCfgConDsp.Click += new System.EventHandler(this.cmdCfgConDsp_Click);
            // 
            // ctlMachineConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPrjSerial);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMachineProfiles);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblMachineName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbMachineType);
            this.Controls.Add(this.Monitors);
            this.Controls.Add(this.ProjectorRes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdOK);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ctlMachineConfig";
            this.Size = new System.Drawing.Size(1055, 514);
            this.Load += new System.EventHandler(this.ctlMachineConfig_Load);
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
