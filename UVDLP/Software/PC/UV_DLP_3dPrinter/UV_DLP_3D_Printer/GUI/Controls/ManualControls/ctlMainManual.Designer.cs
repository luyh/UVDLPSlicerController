namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    partial class ctlMainManual
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
            this.ctlGCodeManual1 = new UV_DLP_3D_Printer.GUI.Controls.ManualControls.ctlGCodeManual();
            this.ctlProjectorControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlProjectorControl();
            this.ctlMachineControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineControl();
            this.SuspendLayout();
            // 
            // ctlGCodeManual1
            // 
            this.ctlGCodeManual1.Location = new System.Drawing.Point(499, 2);
            this.ctlGCodeManual1.Name = "ctlGCodeManual1";
            this.ctlGCodeManual1.Padding = new System.Windows.Forms.Padding(5);
            this.ctlGCodeManual1.Size = new System.Drawing.Size(353, 440);
            this.ctlGCodeManual1.TabIndex = 0;
            // 
            // ctlProjectorControl1
            // 
            this.ctlProjectorControl1.Checked = false;
            this.ctlProjectorControl1.Gapx = 5;
            this.ctlProjectorControl1.Gapy = 5;
            this.ctlProjectorControl1.GLBackgroundImage = null;
            this.ctlProjectorControl1.GLVisible = false;
            this.ctlProjectorControl1.GuiAnchor = null;
            this.ctlProjectorControl1.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.ctlProjectorControl1.Location = new System.Drawing.Point(3, 269);
            this.ctlProjectorControl1.Name = "ctlProjectorControl1";
            this.ctlProjectorControl1.Size = new System.Drawing.Size(302, 178);
            this.ctlProjectorControl1.StyleName = null;
            this.ctlProjectorControl1.TabIndex = 1;
            this.ctlProjectorControl1.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlMachineControl1
            // 
            this.ctlMachineControl1.Location = new System.Drawing.Point(3, 2);
            this.ctlMachineControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctlMachineControl1.Name = "ctlMachineControl1";
            this.ctlMachineControl1.Size = new System.Drawing.Size(490, 262);
            this.ctlMachineControl1.TabIndex = 2;
            // 
            // ctlMainManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlMachineControl1);
            this.Controls.Add(this.ctlProjectorControl1);
            this.Controls.Add(this.ctlGCodeManual1);
            this.Name = "ctlMainManual";
            this.Size = new System.Drawing.Size(858, 452);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlGCodeManual ctlGCodeManual1;
        private ctlProjectorControl ctlProjectorControl1;
        private ctlMachineControl ctlMachineControl1;
    }
}
