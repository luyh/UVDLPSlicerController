namespace UV_DLP_3D_Printer.GUI
{
    partial class frmSliceView
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
            this.ctlSliceView1 = new UV_DLP_3D_Printer.GUI.Controls.ctlSliceView();
            this.SuspendLayout();
            // 
            // ctlSliceView1
            // 
            this.ctlSliceView1.DlpForm = null;
            this.ctlSliceView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSliceView1.Location = new System.Drawing.Point(0, 0);
            this.ctlSliceView1.Name = "ctlSliceView1";
            this.ctlSliceView1.Size = new System.Drawing.Size(779, 607);
            this.ctlSliceView1.TabIndex = 23;
            // 
            // frmSliceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 607);
            this.Controls.Add(this.ctlSliceView1);
            this.Name = "frmSliceView";
            this.Text = "Slice View";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctlSliceView ctlSliceView1;
    }
}