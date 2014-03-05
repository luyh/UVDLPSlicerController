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
            this.tabMachineConfig = new System.Windows.Forms.TabPage();
            this.tabSliceProfile = new System.Windows.Forms.TabPage();
            this.ctlMachineConfig1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineConfig();
            this.ctlToolpathGenConfig1 = new UV_DLP_3D_Printer.GUI.Controls.ctlToolpathGenConfig();
            this.tabMain.SuspendLayout();
            this.tabMachineConfig.SuspendLayout();
            this.tabSliceProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMachineConfig);
            this.tabMain.Controls.Add(this.tabSliceProfile);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.ItemSize = new System.Drawing.Size(160, 40);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(942, 649);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 19;
            // 
            // tabMachineConfig
            // 
            this.tabMachineConfig.Controls.Add(this.ctlMachineConfig1);
            this.tabMachineConfig.Location = new System.Drawing.Point(4, 44);
            this.tabMachineConfig.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabMachineConfig.Name = "tabMachineConfig";
            this.tabMachineConfig.Size = new System.Drawing.Size(934, 601);
            this.tabMachineConfig.TabIndex = 4;
            this.tabMachineConfig.Text = "Machine Config";
            this.tabMachineConfig.UseVisualStyleBackColor = true;
            // 
            // tabSliceProfile
            // 
            this.tabSliceProfile.Controls.Add(this.ctlToolpathGenConfig1);
            this.tabSliceProfile.Location = new System.Drawing.Point(4, 44);
            this.tabSliceProfile.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabSliceProfile.Name = "tabSliceProfile";
            this.tabSliceProfile.Size = new System.Drawing.Size(934, 601);
            this.tabSliceProfile.TabIndex = 5;
            this.tabSliceProfile.Text = "Slice Profile Config";
            this.tabSliceProfile.UseVisualStyleBackColor = true;
            // 
            // ctlMachineConfig1
            // 
            this.ctlMachineConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlMachineConfig1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlMachineConfig1.Location = new System.Drawing.Point(0, 0);
            this.ctlMachineConfig1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ctlMachineConfig1.Name = "ctlMachineConfig1";
            this.ctlMachineConfig1.Size = new System.Drawing.Size(934, 601);
            this.ctlMachineConfig1.TabIndex = 0;
            // 
            // ctlToolpathGenConfig1
            // 
            this.ctlToolpathGenConfig1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlToolpathGenConfig1.Location = new System.Drawing.Point(4, 5);
            this.ctlToolpathGenConfig1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ctlToolpathGenConfig1.Name = "ctlToolpathGenConfig1";
            this.ctlToolpathGenConfig1.Size = new System.Drawing.Size(926, 622);
            this.ctlToolpathGenConfig1.TabIndex = 0;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 649);
            this.Controls.Add(this.tabMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSettings";
            this.Text = "Settings and Profiles";
            this.tabMain.ResumeLayout(false);
            this.tabMachineConfig.ResumeLayout(false);
            this.tabSliceProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabMachineConfig;
        private Controls.ctlMachineConfig ctlMachineConfig1;
        private System.Windows.Forms.TabPage tabSliceProfile;
        private Controls.ctlToolpathGenConfig ctlToolpathGenConfig1;
    }
}