namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlConfig
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
            this.buttShowMachineConfig = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttShowMachineControl = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlImageButton2 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.SuspendLayout();
            // 
            // buttShowMachineConfig
            // 
            this.buttShowMachineConfig.BackColor = System.Drawing.Color.Navy;
            this.buttShowMachineConfig.Checked = false;
            this.buttShowMachineConfig.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttShowMachineConfig.Gapx = 5;
            this.buttShowMachineConfig.Gapy = 5;
            this.buttShowMachineConfig.GLBackgroundImage = null;
            this.buttShowMachineConfig.GLImage = null;
            this.buttShowMachineConfig.GLVisible = false;
            this.buttShowMachineConfig.GuiAnchor = null;
            this.buttShowMachineConfig.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttShowMachineConfig.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewDown;
            this.buttShowMachineConfig.Location = new System.Drawing.Point(5, 5);
            this.buttShowMachineConfig.Margin = new System.Windows.Forms.Padding(5);
            this.buttShowMachineConfig.Name = "buttShowMachineConfig";
            this.buttShowMachineConfig.OnClickCallback = "ShowMachineConfig";
            this.buttShowMachineConfig.Size = new System.Drawing.Size(45, 48);
            this.buttShowMachineConfig.StyleName = null;
            this.buttShowMachineConfig.TabIndex = 32;
            this.buttShowMachineConfig.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // buttShowMachineControl
            // 
            this.buttShowMachineControl.BackColor = System.Drawing.Color.Navy;
            this.buttShowMachineControl.Checked = false;
            this.buttShowMachineControl.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttShowMachineControl.Gapx = 5;
            this.buttShowMachineControl.Gapy = 5;
            this.buttShowMachineControl.GLBackgroundImage = null;
            this.buttShowMachineControl.GLImage = null;
            this.buttShowMachineControl.GLVisible = false;
            this.buttShowMachineControl.GuiAnchor = null;
            this.buttShowMachineControl.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttShowMachineControl.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewDown;
            this.buttShowMachineControl.Location = new System.Drawing.Point(60, 5);
            this.buttShowMachineControl.Margin = new System.Windows.Forms.Padding(5);
            this.buttShowMachineControl.Name = "buttShowMachineControl";
            this.buttShowMachineControl.OnClickCallback = "ShowMachineControl";
            this.buttShowMachineControl.Size = new System.Drawing.Size(45, 48);
            this.buttShowMachineControl.StyleName = null;
            this.buttShowMachineControl.TabIndex = 33;
            this.buttShowMachineControl.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlImageButton2
            // 
            this.ctlImageButton2.BackColor = System.Drawing.Color.Navy;
            this.ctlImageButton2.Checked = false;
            this.ctlImageButton2.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.ctlImageButton2.Gapx = 5;
            this.ctlImageButton2.Gapy = 5;
            this.ctlImageButton2.GLBackgroundImage = null;
            this.ctlImageButton2.GLImage = null;
            this.ctlImageButton2.GLVisible = false;
            this.ctlImageButton2.GuiAnchor = null;
            this.ctlImageButton2.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.ctlImageButton2.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewDown;
            this.ctlImageButton2.Location = new System.Drawing.Point(115, 5);
            this.ctlImageButton2.Margin = new System.Windows.Forms.Padding(5);
            this.ctlImageButton2.Name = "ctlImageButton2";
            this.ctlImageButton2.OnClickCallback = "ShowMachineConfig";
            this.ctlImageButton2.Size = new System.Drawing.Size(45, 48);
            this.ctlImageButton2.StyleName = null;
            this.ctlImageButton2.TabIndex = 34;
            this.ctlImageButton2.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlImageButton2);
            this.Controls.Add(this.buttShowMachineControl);
            this.Controls.Add(this.buttShowMachineConfig);
            this.Name = "ctlConfig";
            this.Size = new System.Drawing.Size(187, 119);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlImageButton buttShowMachineConfig;
        private ctlImageButton buttShowMachineControl;
        private ctlImageButton ctlImageButton2;
    }
}
