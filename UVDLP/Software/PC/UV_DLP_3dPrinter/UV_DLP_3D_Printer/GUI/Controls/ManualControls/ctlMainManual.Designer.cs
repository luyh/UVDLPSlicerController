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
            this.ctlMachineControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlMachineControl();
            this.ctlProjectorControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlProjectorControl();
            this.ctlGCodeManual1 = new UV_DLP_3D_Printer.GUI.Controls.ManualControls.ctlGCodeManual();
            this.SuspendLayout();
            // 
            // ctlMachineControl1
            // 
            this.ctlMachineControl1.Location = new System.Drawing.Point(2, 2);
            this.ctlMachineControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctlMachineControl1.Name = "ctlMachineControl1";
            this.ctlMachineControl1.Size = new System.Drawing.Size(368, 213);
            this.ctlMachineControl1.TabIndex = 2;
            // 
            // ctlProjectorControl1
            // 
            this.ctlProjectorControl1.Location = new System.Drawing.Point(2, 219);
            this.ctlProjectorControl1.Margin = new System.Windows.Forms.Padding(2);
            this.ctlProjectorControl1.Name = "ctlProjectorControl1";
            this.ctlProjectorControl1.Size = new System.Drawing.Size(295, 195);
            this.ctlProjectorControl1.TabIndex = 1;
            // 
            // ctlGCodeManual1
            // 
            this.ctlGCodeManual1.Location = new System.Drawing.Point(374, 16);
            this.ctlGCodeManual1.Margin = new System.Windows.Forms.Padding(2);
            this.ctlGCodeManual1.Name = "ctlGCodeManual1";
            this.ctlGCodeManual1.Padding = new System.Windows.Forms.Padding(4);
            this.ctlGCodeManual1.Size = new System.Drawing.Size(276, 358);
            this.ctlGCodeManual1.TabIndex = 0;
            // 
            // ctlMainManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlMachineControl1);
            this.Controls.Add(this.ctlProjectorControl1);
            this.Controls.Add(this.ctlGCodeManual1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctlMainManual";
            this.Size = new System.Drawing.Size(661, 424);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlGCodeManual ctlGCodeManual1;
        private ctlProjectorControl ctlProjectorControl1;
        private ctlMachineControl ctlMachineControl1;
    }
}
