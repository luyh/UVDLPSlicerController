namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlView
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttAddSupport = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.butt1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.butt2 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Navy;
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(170, 64);
            this.flowLayoutPanel2.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel1.Controls.Add(this.buttAddSupport);
            this.flowLayoutPanel1.Controls.Add(this.butt1);
            this.flowLayoutPanel1.Controls.Add(this.butt2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 58);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // buttAddSupport
            // 
            this.buttAddSupport.BackColor = System.Drawing.Color.Navy;
            this.buttAddSupport.Checked = false;
            this.buttAddSupport.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttAddSupport.Gapx = 5;
            this.buttAddSupport.Gapy = 5;
            this.buttAddSupport.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddSupport.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttTransparent;
            this.buttAddSupport.Location = new System.Drawing.Point(5, 5);
            this.buttAddSupport.Margin = new System.Windows.Forms.Padding(5);
            this.buttAddSupport.Name = "buttAddSupport";
            this.buttAddSupport.Size = new System.Drawing.Size(48, 48);
            this.buttAddSupport.TabIndex = 23;
            this.buttAddSupport.Text = "ctlImageButton1";
            this.buttAddSupport.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddSupport.Click += new System.EventHandler(this.buttAddSupport_Click);
            // 
            // butt1
            // 
            this.butt1.BackColor = System.Drawing.Color.Navy;
            this.butt1.Checked = false;
            this.butt1.CheckImage = null;
            this.butt1.Gapx = 5;
            this.butt1.Gapy = 5;
            this.butt1.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.butt1.Image = null;
            this.butt1.Location = new System.Drawing.Point(58, 5);
            this.butt1.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.butt1.Name = "butt1";
            this.butt1.Size = new System.Drawing.Size(48, 48);
            this.butt1.TabIndex = 24;
            this.butt1.Text = "ctlImageButton3";
            this.butt1.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // butt2
            // 
            this.butt2.BackColor = System.Drawing.Color.Navy;
            this.butt2.Checked = false;
            this.butt2.CheckImage = null;
            this.butt2.Gapx = 5;
            this.butt2.Gapy = 5;
            this.butt2.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.butt2.Image = null;
            this.butt2.Location = new System.Drawing.Point(111, 5);
            this.butt2.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.butt2.Name = "butt2";
            this.butt2.Size = new System.Drawing.Size(48, 48);
            this.butt2.TabIndex = 25;
            this.butt2.Text = "ctlImageButton3";
            this.butt2.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ctlView";
            this.Size = new System.Drawing.Size(170, 64);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ctlImageButton buttAddSupport;
        private ctlImageButton butt1;
        private ctlImageButton butt2;
    }
}
