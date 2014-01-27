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
            this.buttEnableTransparency = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttShowSlice = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttBoundingBox = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttObjectProperties = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttTreeView = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttShowConsole = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttSliceView = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlToolTip1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlToolTip();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Navy;
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(170, 186);
            this.flowLayoutPanel2.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel1.Controls.Add(this.buttEnableTransparency);
            this.flowLayoutPanel1.Controls.Add(this.buttShowSlice);
            this.flowLayoutPanel1.Controls.Add(this.buttBoundingBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 58);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // buttEnableTransparency
            // 
            this.buttEnableTransparency.BackColor = System.Drawing.Color.Navy;
            this.buttEnableTransparency.Checked = false;
            this.buttEnableTransparency.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttEnableTransparency.Gapx = 5;
            this.buttEnableTransparency.Gapy = 5;
            this.buttEnableTransparency.GuiAnchor = null;
            this.buttEnableTransparency.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttEnableTransparency.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttTransparent;
            this.buttEnableTransparency.Location = new System.Drawing.Point(5, 5);
            this.buttEnableTransparency.Margin = new System.Windows.Forms.Padding(5);
            this.buttEnableTransparency.Name = "buttEnableTransparency";
            this.buttEnableTransparency.Size = new System.Drawing.Size(48, 48);
            this.buttEnableTransparency.TabIndex = 23;
            this.ctlToolTip1.SetToolTip(this.buttEnableTransparency, "Make objects 50%\r\ntransparent");
            this.buttEnableTransparency.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttEnableTransparency.Click += new System.EventHandler(this.buttEnableTransparency_Click);
            // 
            // buttShowSlice
            // 
            this.buttShowSlice.BackColor = System.Drawing.Color.Navy;
            this.buttShowSlice.Checked = false;
            this.buttShowSlice.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttShowSlice.Gapx = 5;
            this.buttShowSlice.Gapy = 5;
            this.buttShowSlice.GuiAnchor = null;
            this.buttShowSlice.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttShowSlice.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttShowslice;
            this.buttShowSlice.Location = new System.Drawing.Point(58, 5);
            this.buttShowSlice.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttShowSlice.Name = "buttShowSlice";
            this.buttShowSlice.Size = new System.Drawing.Size(48, 48);
            this.buttShowSlice.TabIndex = 24;
            this.ctlToolTip1.SetToolTip(this.buttShowSlice, "Show slice preview \r\non scene");
            this.buttShowSlice.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttShowSlice.Click += new System.EventHandler(this.buttShowSlice_Click);
            // 
            // buttBoundingBox
            // 
            this.buttBoundingBox.BackColor = System.Drawing.Color.Navy;
            this.buttBoundingBox.Checked = false;
            this.buttBoundingBox.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttBoundingBox.Gapx = 5;
            this.buttBoundingBox.Gapy = 5;
            this.buttBoundingBox.GuiAnchor = null;
            this.buttBoundingBox.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttBoundingBox.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttBoundingBox;
            this.buttBoundingBox.Location = new System.Drawing.Point(111, 5);
            this.buttBoundingBox.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttBoundingBox.Name = "buttBoundingBox";
            this.buttBoundingBox.Size = new System.Drawing.Size(48, 48);
            this.buttBoundingBox.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.buttBoundingBox, "Show bounding box\r\naround selected objects");
            this.buttBoundingBox.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttBoundingBox.Click += new System.EventHandler(this.buttBoundingBox_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel3.Controls.Add(this.buttObjectProperties);
            this.flowLayoutPanel3.Controls.Add(this.buttTreeView);
            this.flowLayoutPanel3.Controls.Add(this.buttShowConsole);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 64);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(164, 58);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // buttObjectProperties
            // 
            this.buttObjectProperties.BackColor = System.Drawing.Color.Navy;
            this.buttObjectProperties.Checked = false;
            this.buttObjectProperties.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttObjectProperties.Gapx = 5;
            this.buttObjectProperties.Gapy = 5;
            this.buttObjectProperties.GuiAnchor = null;
            this.buttObjectProperties.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttObjectProperties.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttOinfo;
            this.buttObjectProperties.Location = new System.Drawing.Point(5, 5);
            this.buttObjectProperties.Margin = new System.Windows.Forms.Padding(5);
            this.buttObjectProperties.Name = "buttObjectProperties";
            this.buttObjectProperties.Size = new System.Drawing.Size(48, 48);
            this.buttObjectProperties.TabIndex = 23;
            this.ctlToolTip1.SetToolTip(this.buttObjectProperties, "Show object \r\nproperties panel");
            this.buttObjectProperties.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttObjectProperties.Click += new System.EventHandler(this.buttObjectProperties_Click);
            // 
            // buttTreeView
            // 
            this.buttTreeView.BackColor = System.Drawing.Color.Navy;
            this.buttTreeView.Checked = false;
            this.buttTreeView.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttTreeView.Gapx = 5;
            this.buttTreeView.Gapy = 5;
            this.buttTreeView.GuiAnchor = null;
            this.buttTreeView.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttTreeView.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttTreeview;
            this.buttTreeView.Location = new System.Drawing.Point(58, 5);
            this.buttTreeView.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttTreeView.Name = "buttTreeView";
            this.buttTreeView.Size = new System.Drawing.Size(48, 48);
            this.buttTreeView.TabIndex = 24;
            this.ctlToolTip1.SetToolTip(this.buttTreeView, "Show list of objects");
            this.buttTreeView.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttTreeView.Click += new System.EventHandler(this.buttTreeView_Click);
            // 
            // buttShowConsole
            // 
            this.buttShowConsole.BackColor = System.Drawing.Color.Navy;
            this.buttShowConsole.Checked = true;
            this.buttShowConsole.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttShowConsole.Gapx = 5;
            this.buttShowConsole.Gapy = 5;
            this.buttShowConsole.GuiAnchor = null;
            this.buttShowConsole.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttShowConsole.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttConsole;
            this.buttShowConsole.Location = new System.Drawing.Point(111, 5);
            this.buttShowConsole.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttShowConsole.Name = "buttShowConsole";
            this.buttShowConsole.Size = new System.Drawing.Size(48, 48);
            this.buttShowConsole.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.buttShowConsole, "Show Console");
            this.buttShowConsole.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttShowConsole.Click += new System.EventHandler(this.buttShowConsole_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel4.Controls.Add(this.buttSliceView);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 125);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(164, 58);
            this.flowLayoutPanel4.TabIndex = 26;
            // 
            // buttSliceView
            // 
            this.buttSliceView.BackColor = System.Drawing.Color.Navy;
            this.buttSliceView.Checked = false;
            this.buttSliceView.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttSliceView.Gapx = 5;
            this.buttSliceView.Gapy = 5;
            this.buttSliceView.GuiAnchor = null;
            this.buttSliceView.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttSliceView.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewSlice;
            this.buttSliceView.Location = new System.Drawing.Point(5, 5);
            this.buttSliceView.Margin = new System.Windows.Forms.Padding(5);
            this.buttSliceView.Name = "buttSliceView";
            this.buttSliceView.Size = new System.Drawing.Size(48, 48);
            this.buttSliceView.TabIndex = 23;
            this.ctlToolTip1.SetToolTip(this.buttSliceView, "Show object \r\nproperties panel");
            this.buttSliceView.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttSliceView.Click += new System.EventHandler(this.buttSliceView_Click);
            // 
            // ctlToolTip1
            // 
            this.ctlToolTip1.AutoPopDelay = 5000;
            this.ctlToolTip1.BackColor = System.Drawing.Color.Turquoise;
            this.ctlToolTip1.ForeColor = System.Drawing.Color.Navy;
            this.ctlToolTip1.InitialDelay = 500;
            this.ctlToolTip1.ReshowDelay = 100;
            // 
            // ctlView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ctlView";
            this.Size = new System.Drawing.Size(170, 186);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ctlImageButton buttEnableTransparency;
        private ctlImageButton buttShowSlice;
        private ctlImageButton buttBoundingBox;
        private ctlToolTip ctlToolTip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ctlImageButton buttObjectProperties;
        private ctlImageButton buttTreeView;
        private ctlImageButton buttShowConsole;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ctlImageButton buttSliceView;
    }
}
