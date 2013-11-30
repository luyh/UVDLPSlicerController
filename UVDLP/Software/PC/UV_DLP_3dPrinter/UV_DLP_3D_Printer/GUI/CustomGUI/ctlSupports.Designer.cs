namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlSupports
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
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressTitle = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlProgress();
            this.buttAddSupport = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttAutoSupport = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttSetup = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Navy;
            this.flowLayoutPanel2.Controls.Add(this.progressTitle);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel8);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel10);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(170, 219);
            this.flowLayoutPanel2.TabIndex = 23;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel1.Controls.Add(this.buttAddSupport);
            this.flowLayoutPanel1.Controls.Add(this.buttAutoSupport);
            this.flowLayoutPanel1.Controls.Add(this.buttSetup);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 58);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 97);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(164, 38);
            this.flowLayoutPanel7.TabIndex = 1;
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 138);
            this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(164, 38);
            this.flowLayoutPanel8.TabIndex = 4;
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel10.Location = new System.Drawing.Point(3, 179);
            this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(164, 38);
            this.flowLayoutPanel10.TabIndex = 5;
            // 
            // progressTitle
            // 
            this.progressTitle.BarColor = System.Drawing.Color.RoyalBlue;
            this.progressTitle.BorderThickness = 2;
            this.progressTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.progressTitle.ForeColor = System.Drawing.Color.White;
            this.progressTitle.Location = new System.Drawing.Point(5, 4);
            this.progressTitle.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.progressTitle.Maximum = 100;
            this.progressTitle.Minimum = 0;
            this.progressTitle.Name = "progressTitle";
            this.progressTitle.Size = new System.Drawing.Size(160, 25);
            this.progressTitle.TabIndex = 0;
            this.progressTitle.Text = "Supports";
            this.progressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressTitle.Value = 0;
            // 
            // buttAddSupport
            // 
            this.buttAddSupport.BackColor = System.Drawing.Color.Navy;
            this.buttAddSupport.Checked = false;
            this.buttAddSupport.CheckImage = null;
            this.buttAddSupport.Gapx = 5;
            this.buttAddSupport.Gapy = 5;
            this.buttAddSupport.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddSupport.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttAddSupport;
            this.buttAddSupport.Location = new System.Drawing.Point(5, 5);
            this.buttAddSupport.Margin = new System.Windows.Forms.Padding(5);
            this.buttAddSupport.Name = "buttAddSupport";
            this.buttAddSupport.Size = new System.Drawing.Size(48, 48);
            this.buttAddSupport.TabIndex = 23;
            this.buttAddSupport.Text = "ctlImageButton1";
            this.buttAddSupport.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddSupport.Click += new System.EventHandler(this.buttAddSupport_Click);
            // 
            // buttAutoSupport
            // 
            this.buttAutoSupport.BackColor = System.Drawing.Color.Navy;
            this.buttAutoSupport.Checked = false;
            this.buttAutoSupport.CheckImage = null;
            this.buttAutoSupport.Gapx = 5;
            this.buttAutoSupport.Gapy = 5;
            this.buttAutoSupport.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAutoSupport.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttAutoSupport;
            this.buttAutoSupport.Location = new System.Drawing.Point(58, 5);
            this.buttAutoSupport.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttAutoSupport.Name = "buttAutoSupport";
            this.buttAutoSupport.Size = new System.Drawing.Size(48, 48);
            this.buttAutoSupport.TabIndex = 24;
            this.buttAutoSupport.Text = "ctlImageButton3";
            this.buttAutoSupport.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAutoSupport.Click += new System.EventHandler(this.buttAutoSupport_Click);
            // 
            // buttSetup
            // 
            this.buttSetup.BackColor = System.Drawing.Color.Navy;
            this.buttSetup.Checked = false;
            this.buttSetup.CheckImage = null;
            this.buttSetup.Gapx = 5;
            this.buttSetup.Gapy = 5;
            this.buttSetup.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttSetup.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttGear;
            this.buttSetup.Location = new System.Drawing.Point(111, 5);
            this.buttSetup.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttSetup.Name = "buttSetup";
            this.buttSetup.Size = new System.Drawing.Size(48, 48);
            this.buttSetup.TabIndex = 25;
            this.buttSetup.Text = "ctlImageButton3";
            this.buttSetup.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlSupports
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ctlSupports";
            this.Size = new System.Drawing.Size(170, 144);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ctlImageButton buttAddSupport;
        private ctlImageButton buttAutoSupport;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private ctlImageButton buttSetup;
        private ctlProgress progressTitle;
    }
}
