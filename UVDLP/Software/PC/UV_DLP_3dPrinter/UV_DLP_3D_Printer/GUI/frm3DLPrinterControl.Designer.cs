namespace UV_DLP_3D_Printer.GUI
{
    partial class frm3DLPrinterControl
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
            this.grpProjector = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numBrightness = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numContrast = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsteps = new System.Windows.Forms.TextBox();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdUp = new System.Windows.Forms.Button();
            this.grpProjector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // grpProjector
            // 
            this.grpProjector.Controls.Add(this.label2);
            this.grpProjector.Controls.Add(this.numBrightness);
            this.grpProjector.Controls.Add(this.label1);
            this.grpProjector.Controls.Add(this.numContrast);
            this.grpProjector.Location = new System.Drawing.Point(13, 12);
            this.grpProjector.Name = "grpProjector";
            this.grpProjector.Size = new System.Drawing.Size(257, 129);
            this.grpProjector.TabIndex = 0;
            this.grpProjector.TabStop = false;
            this.grpProjector.Text = "Projector Adjustment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Brightness";
            // 
            // numBrightness
            // 
            this.numBrightness.Location = new System.Drawing.Point(97, 67);
            this.numBrightness.Name = "numBrightness";
            this.numBrightness.Size = new System.Drawing.Size(120, 22);
            this.numBrightness.TabIndex = 2;
            this.numBrightness.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.numBrightness.ValueChanged += new System.EventHandler(this.numBrightness_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contrast";
            // 
            // numContrast
            // 
            this.numContrast.Location = new System.Drawing.Point(97, 30);
            this.numContrast.Name = "numContrast";
            this.numContrast.Size = new System.Drawing.Size(120, 22);
            this.numContrast.TabIndex = 0;
            this.numContrast.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.numContrast.ValueChanged += new System.EventHandler(this.numContrast_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "mm";
            // 
            // txtsteps
            // 
            this.txtsteps.Location = new System.Drawing.Point(339, 102);
            this.txtsteps.Name = "txtsteps";
            this.txtsteps.Size = new System.Drawing.Size(72, 22);
            this.txtsteps.TabIndex = 6;
            this.txtsteps.Text = "10";
            this.txtsteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdDown
            // 
            this.cmdDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Down1Blue;
            this.cmdDown.Location = new System.Drawing.Point(339, 136);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(72, 72);
            this.cmdDown.TabIndex = 5;
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdUp
            // 
            this.cmdUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Up1Blue;
            this.cmdUp.Location = new System.Drawing.Point(339, 14);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(72, 72);
            this.cmdUp.TabIndex = 4;
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // frm3DLPrinterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 367);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsteps);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpProjector);
            this.MaximizeBox = false;
            this.Name = "frm3DLPrinterControl";
            this.Text = "Robot Factory 3DLPrinter Control";
            this.grpProjector.ResumeLayout(false);
            this.grpProjector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProjector;
        private System.Windows.Forms.NumericUpDown numContrast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBrightness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsteps;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.Button cmdUp;
    }
}