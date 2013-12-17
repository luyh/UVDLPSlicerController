using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlMeshTools : UserControl
    {
        private FlowLayoutPanel flowLayoutPanel1;
        private IContainer components;
        private ctlImageButton buttUnion;
        private ctlImageButton buttIntersect;
        private ctlImageButton buttSubtract;
        private FlowLayoutPanel flowLayoutPanel2;
        private ctlProgress progressTitle;
        private ctlToolTip ctlToolTip1;
    
        public ctlMeshTools() 
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttUnion = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttIntersect = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttSubtract = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlToolTip1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlToolTip();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressTitle = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlProgress();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel1.Controls.Add(this.buttUnion);
            this.flowLayoutPanel1.Controls.Add(this.buttIntersect);
            this.flowLayoutPanel1.Controls.Add(this.buttSubtract);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 58);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // buttUnion
            // 
            this.buttUnion.BackColor = System.Drawing.Color.Navy;
            this.buttUnion.Checked = false;
            this.buttUnion.CheckImage = null;
            this.buttUnion.Gapx = 5;
            this.buttUnion.Gapy = 5;
            this.buttUnion.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttUnion.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttUnion;
            this.buttUnion.Location = new System.Drawing.Point(5, 5);
            this.buttUnion.Margin = new System.Windows.Forms.Padding(5);
            this.buttUnion.Name = "buttUnion";
            this.buttUnion.Padding = new System.Windows.Forms.Padding(5);
            this.buttUnion.Size = new System.Drawing.Size(48, 48);
            this.buttUnion.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.buttUnion, "Union Selected");
            this.buttUnion.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // buttIntersect
            // 
            this.buttIntersect.BackColor = System.Drawing.Color.Navy;
            this.buttIntersect.Checked = false;
            this.buttIntersect.CheckImage = null;
            this.buttIntersect.Gapx = 5;
            this.buttIntersect.Gapy = 5;
            this.buttIntersect.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttIntersect.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttIntersect;
            this.buttIntersect.Location = new System.Drawing.Point(58, 5);
            this.buttIntersect.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttIntersect.Name = "buttIntersect";
            this.buttIntersect.Padding = new System.Windows.Forms.Padding(5);
            this.buttIntersect.Size = new System.Drawing.Size(48, 48);
            this.buttIntersect.TabIndex = 26;
            this.ctlToolTip1.SetToolTip(this.buttIntersect, "Intersect Selected");
            this.buttIntersect.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // buttSubtract
            // 
            this.buttSubtract.BackColor = System.Drawing.Color.Navy;
            this.buttSubtract.Checked = false;
            this.buttSubtract.CheckImage = null;
            this.buttSubtract.Gapx = 5;
            this.buttSubtract.Gapy = 5;
            this.buttSubtract.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttSubtract.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttSubtract;
            this.buttSubtract.Location = new System.Drawing.Point(111, 5);
            this.buttSubtract.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttSubtract.Name = "buttSubtract";
            this.buttSubtract.Padding = new System.Windows.Forms.Padding(5);
            this.buttSubtract.Size = new System.Drawing.Size(48, 48);
            this.buttSubtract.TabIndex = 27;
            this.ctlToolTip1.SetToolTip(this.buttSubtract, "Subtract Selected");
            this.buttSubtract.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlToolTip1
            // 
            this.ctlToolTip1.AutoPopDelay = 5000;
            this.ctlToolTip1.BackColor = System.Drawing.Color.Turquoise;
            this.ctlToolTip1.ForeColor = System.Drawing.Color.Navy;
            this.ctlToolTip1.InitialDelay = 100;
            this.ctlToolTip1.ReshowDelay = 100;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.progressTitle);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(172, 98);
            this.flowLayoutPanel2.TabIndex = 26;
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
            this.progressTitle.TabIndex = 1;
            this.progressTitle.Text = "Mesh Tools";
            this.progressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressTitle.Value = 0;
            // 
            // ctlMeshTools
            // 
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ctlMeshTools";
            this.Size = new System.Drawing.Size(172, 98);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
