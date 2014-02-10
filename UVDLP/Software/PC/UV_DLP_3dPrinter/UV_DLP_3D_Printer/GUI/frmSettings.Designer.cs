namespace UV_DLP_3D_Printer.GUI
{
    partial class frmSettings
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMachineControl = new System.Windows.Forms.TabPage();
            this.ctlMachineControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineControl();
            this.tabMachineConfig = new System.Windows.Forms.TabPage();
            this.ctlMachineConfig1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineConfig();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctlToolpathGenConfig1 = new UV_DLP_3D_Printer.GUI.Controls.ctlToolpathGenConfig();
            this.tabMain.SuspendLayout();
            this.tabMachineControl.SuspendLayout();
            this.tabMachineConfig.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMachineControl);
            this.tabMain.Controls.Add(this.tabMachineConfig);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(808, 597);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 19;
            // 
            // tabMachineControl
            // 
            this.tabMachineControl.Controls.Add(this.ctlMachineControl1);
            this.tabMachineControl.Location = new System.Drawing.Point(4, 22);
            this.tabMachineControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMachineControl.Name = "tabMachineControl";
            this.tabMachineControl.Size = new System.Drawing.Size(780, 557);
            this.tabMachineControl.TabIndex = 3;
            this.tabMachineControl.Text = "Machine Control";
            this.tabMachineControl.UseVisualStyleBackColor = true;
            // 
            // ctlMachineControl1
            // 
            this.ctlMachineControl1.Location = new System.Drawing.Point(3, 2);
            this.ctlMachineControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctlMachineControl1.Name = "ctlMachineControl1";
            this.ctlMachineControl1.Size = new System.Drawing.Size(774, 558);
            this.ctlMachineControl1.TabIndex = 0;
            // 
            // tabMachineConfig
            // 
            this.tabMachineConfig.Controls.Add(this.ctlMachineConfig1);
            this.tabMachineConfig.Location = new System.Drawing.Point(4, 22);
            this.tabMachineConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMachineConfig.Name = "tabMachineConfig";
            this.tabMachineConfig.Size = new System.Drawing.Size(780, 557);
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
            this.ctlMachineConfig1.Size = new System.Drawing.Size(780, 557);
            this.ctlMachineConfig1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctlToolpathGenConfig1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(800, 571);
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
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(808, 597);
            this.Controls.Add(this.tabMain);
            this.Name = "frmSettings";
            this.Text = "Settings and Profiles";
            this.tabMain.ResumeLayout(false);
            this.tabMachineControl.ResumeLayout(false);
            this.tabMachineConfig.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabMachineControl;
        private Controls.ctlMachineControl ctlMachineControl1;
        private System.Windows.Forms.TabPage tabMachineConfig;
        private Controls.ctlMachineConfig ctlMachineConfig1;
        private System.Windows.Forms.TabPage tabPage3;
        private Controls.ctlToolpathGenConfig ctlToolpathGenConfig1;
    }
}