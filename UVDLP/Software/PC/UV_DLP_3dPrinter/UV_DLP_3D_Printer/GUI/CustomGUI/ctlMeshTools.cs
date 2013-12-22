using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer._3DEngine;
using Engine3D;

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
        private FlowLayoutPanel flowLayoutPanel4;
        private ctlImageButton buttAddCube;
        private ctlImageButton buttAddSphere;
        private ctlImageButton buttAddCone;
        private FlowLayoutPanel flowLayoutPanel5;
        private ctlImageButton ctlImageButton7;
        private ctlImageButton ctlImageButton8;
        private ctlImageButton ctlImageButton9;
        private FlowLayoutPanel flowLayoutPanel3;
        private ctlImageButton buttAddTorus;
        private ctlImageButton buttAddCylinder;
        private ctlToolTip ctlToolTip1;
    
        public ctlMeshTools() 
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressTitle = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlProgress();
            this.buttUnion = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttIntersect = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttSubtract = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttAddCube = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttAddSphere = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttAddCone = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlImageButton7 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlImageButton8 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlImageButton9 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttAddTorus = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttAddCylinder = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlToolTip1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlToolTip();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
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
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.progressTitle);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(170, 214);
            this.flowLayoutPanel2.TabIndex = 26;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel4.Controls.Add(this.buttAddCube);
            this.flowLayoutPanel4.Controls.Add(this.buttAddSphere);
            this.flowLayoutPanel4.Controls.Add(this.buttAddCone);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 100);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(164, 53);
            this.flowLayoutPanel4.TabIndex = 29;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel5.Controls.Add(this.ctlImageButton7);
            this.flowLayoutPanel5.Controls.Add(this.ctlImageButton8);
            this.flowLayoutPanel5.Controls.Add(this.ctlImageButton9);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 56);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(164, 58);
            this.flowLayoutPanel5.TabIndex = 28;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.flowLayoutPanel3.Controls.Add(this.buttAddTorus);
            this.flowLayoutPanel3.Controls.Add(this.buttAddCylinder);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 153);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(164, 58);
            this.flowLayoutPanel3.TabIndex = 28;
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
            // buttAddCube
            // 
            this.buttAddCube.BackColor = System.Drawing.Color.Navy;
            this.buttAddCube.Checked = false;
            this.buttAddCube.CheckImage = null;
            this.buttAddCube.Gapx = 5;
            this.buttAddCube.Gapy = 5;
            this.buttAddCube.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddCube.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPCube;
            this.buttAddCube.Location = new System.Drawing.Point(5, 5);
            this.buttAddCube.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.buttAddCube.Name = "buttAddCube";
            this.buttAddCube.Padding = new System.Windows.Forms.Padding(5);
            this.buttAddCube.Size = new System.Drawing.Size(48, 48);
            this.buttAddCube.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.buttAddCube, "Add Box");
            this.buttAddCube.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // buttAddSphere
            // 
            this.buttAddSphere.BackColor = System.Drawing.Color.Navy;
            this.buttAddSphere.Checked = false;
            this.buttAddSphere.CheckImage = null;
            this.buttAddSphere.Gapx = 5;
            this.buttAddSphere.Gapy = 5;
            this.buttAddSphere.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddSphere.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPSphere;
            this.buttAddSphere.Location = new System.Drawing.Point(58, 5);
            this.buttAddSphere.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.buttAddSphere.Name = "buttAddSphere";
            this.buttAddSphere.Padding = new System.Windows.Forms.Padding(5);
            this.buttAddSphere.Size = new System.Drawing.Size(48, 48);
            this.buttAddSphere.TabIndex = 26;
            this.ctlToolTip1.SetToolTip(this.buttAddSphere, "Add Sphere");
            this.buttAddSphere.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddSphere.Click += new System.EventHandler(this.buttAddSphere_Click);
            // 
            // buttAddCone
            // 
            this.buttAddCone.BackColor = System.Drawing.Color.Navy;
            this.buttAddCone.Checked = false;
            this.buttAddCone.CheckImage = null;
            this.buttAddCone.Gapx = 5;
            this.buttAddCone.Gapy = 5;
            this.buttAddCone.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddCone.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPCone;
            this.buttAddCone.Location = new System.Drawing.Point(111, 5);
            this.buttAddCone.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.buttAddCone.Name = "buttAddCone";
            this.buttAddCone.Padding = new System.Windows.Forms.Padding(5);
            this.buttAddCone.Size = new System.Drawing.Size(48, 48);
            this.buttAddCone.TabIndex = 27;
            this.ctlToolTip1.SetToolTip(this.buttAddCone, "Add Cone");
            this.buttAddCone.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddCone.Click += new System.EventHandler(this.buttAddCone_Click);
            // 
            // ctlImageButton7
            // 
            this.ctlImageButton7.BackColor = System.Drawing.Color.Navy;
            this.ctlImageButton7.Checked = false;
            this.ctlImageButton7.CheckImage = null;
            this.ctlImageButton7.Gapx = 5;
            this.ctlImageButton7.Gapy = 5;
            this.ctlImageButton7.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.ctlImageButton7.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttUnion;
            this.ctlImageButton7.Location = new System.Drawing.Point(5, 5);
            this.ctlImageButton7.Margin = new System.Windows.Forms.Padding(5);
            this.ctlImageButton7.Name = "ctlImageButton7";
            this.ctlImageButton7.Padding = new System.Windows.Forms.Padding(5);
            this.ctlImageButton7.Size = new System.Drawing.Size(48, 48);
            this.ctlImageButton7.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.ctlImageButton7, "Union Selected");
            this.ctlImageButton7.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlImageButton8
            // 
            this.ctlImageButton8.BackColor = System.Drawing.Color.Navy;
            this.ctlImageButton8.Checked = false;
            this.ctlImageButton8.CheckImage = null;
            this.ctlImageButton8.Gapx = 5;
            this.ctlImageButton8.Gapy = 5;
            this.ctlImageButton8.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.ctlImageButton8.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttIntersect;
            this.ctlImageButton8.Location = new System.Drawing.Point(58, 5);
            this.ctlImageButton8.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.ctlImageButton8.Name = "ctlImageButton8";
            this.ctlImageButton8.Padding = new System.Windows.Forms.Padding(5);
            this.ctlImageButton8.Size = new System.Drawing.Size(48, 48);
            this.ctlImageButton8.TabIndex = 26;
            this.ctlToolTip1.SetToolTip(this.ctlImageButton8, "Intersect Selected");
            this.ctlImageButton8.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlImageButton9
            // 
            this.ctlImageButton9.BackColor = System.Drawing.Color.Navy;
            this.ctlImageButton9.Checked = false;
            this.ctlImageButton9.CheckImage = null;
            this.ctlImageButton9.Gapx = 5;
            this.ctlImageButton9.Gapy = 5;
            this.ctlImageButton9.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.ctlImageButton9.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttSubtract;
            this.ctlImageButton9.Location = new System.Drawing.Point(111, 5);
            this.ctlImageButton9.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.ctlImageButton9.Name = "ctlImageButton9";
            this.ctlImageButton9.Padding = new System.Windows.Forms.Padding(5);
            this.ctlImageButton9.Size = new System.Drawing.Size(48, 48);
            this.ctlImageButton9.TabIndex = 27;
            this.ctlToolTip1.SetToolTip(this.ctlImageButton9, "Subtract Selected");
            this.ctlImageButton9.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // buttAddTorus
            // 
            this.buttAddTorus.BackColor = System.Drawing.Color.Navy;
            this.buttAddTorus.Checked = false;
            this.buttAddTorus.CheckImage = null;
            this.buttAddTorus.Gapx = 5;
            this.buttAddTorus.Gapy = 5;
            this.buttAddTorus.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddTorus.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPTorus;
            this.buttAddTorus.Location = new System.Drawing.Point(5, 5);
            this.buttAddTorus.Margin = new System.Windows.Forms.Padding(5);
            this.buttAddTorus.Name = "buttAddTorus";
            this.buttAddTorus.Padding = new System.Windows.Forms.Padding(5);
            this.buttAddTorus.Size = new System.Drawing.Size(48, 48);
            this.buttAddTorus.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.buttAddTorus, "Add Torus");
            this.buttAddTorus.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // buttAddCylinder
            // 
            this.buttAddCylinder.BackColor = System.Drawing.Color.Navy;
            this.buttAddCylinder.Checked = false;
            this.buttAddCylinder.CheckImage = null;
            this.buttAddCylinder.Gapx = 5;
            this.buttAddCylinder.Gapy = 5;
            this.buttAddCylinder.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddCylinder.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttPCylinder;
            this.buttAddCylinder.Location = new System.Drawing.Point(58, 5);
            this.buttAddCylinder.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttAddCylinder.Name = "buttAddCylinder";
            this.buttAddCylinder.Padding = new System.Windows.Forms.Padding(5);
            this.buttAddCylinder.Size = new System.Drawing.Size(48, 48);
            this.buttAddCylinder.TabIndex = 26;
            this.ctlToolTip1.SetToolTip(this.buttAddCylinder, "Add Cylinder");
            this.buttAddCylinder.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddCylinder.Click += new System.EventHandler(this.buttAddCylinder_Click);
            // 
            // ctlToolTip1
            // 
            this.ctlToolTip1.AutoPopDelay = 5000;
            this.ctlToolTip1.BackColor = System.Drawing.Color.Turquoise;
            this.ctlToolTip1.ForeColor = System.Drawing.Color.Navy;
            this.ctlToolTip1.InitialDelay = 100;
            this.ctlToolTip1.ReshowDelay = 100;
            // 
            // ctlMeshTools
            // 
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ctlMeshTools";
            this.Size = new System.Drawing.Size(170, 214);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void buttAddSphere_Click(object sender, EventArgs e)
        {
            Object3d sp =  Primitives.Sphere(10, 17, 15);
            if (sp != null) 
            {
                UVDLPApp.Instance().Engine3D.AddObject(sp);
                UVDLPApp.Instance().SelectedObject = sp;
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eModelAdded, "");
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
            }
        }

        private void buttAddCylinder_Click(object sender, EventArgs e)
        {
            Cylinder3d cy = new Cylinder3d();
            cy.Create(10, 10, 10, 17, 2);
            if (cy != null)
            {
                UVDLPApp.Instance().Engine3D.AddObject(cy);
                UVDLPApp.Instance().SelectedObject = cy;
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eModelAdded, "");
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
            }
        }

        private void buttAddCone_Click(object sender, EventArgs e)
        {
            Cylinder3d cy = new Cylinder3d();
            cy.Create(10, 0, 10, 17, 2);
            if (cy != null)
            {
                UVDLPApp.Instance().Engine3D.AddObject(cy);
                UVDLPApp.Instance().SelectedObject = cy;
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eModelAdded, "");
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
            }
        }
    }
}
