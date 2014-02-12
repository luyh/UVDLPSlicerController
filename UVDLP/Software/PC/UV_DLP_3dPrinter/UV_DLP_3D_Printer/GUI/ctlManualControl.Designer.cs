namespace UV_DLP_3D_Printer.GUI
{
    partial class ctlManualControl
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
            this.buttZUp = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttZDown = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.progressTitle = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlProgress();
            this.buttZHome = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nbrZDist = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.nbrZSpeed = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttZUp
            // 
            this.buttZUp.BackColor = System.Drawing.Color.Navy;
            this.buttZUp.Checked = false;
            this.buttZUp.CheckImage = null;
            this.buttZUp.Enabled = false;
            this.buttZUp.Gapx = 5;
            this.buttZUp.Gapy = 5;
            this.buttZUp.GLBackgroundImage = null;
            this.buttZUp.GLImage = null;
            this.buttZUp.GLVisible = false;
            this.buttZUp.GuiAnchor = null;
            this.buttZUp.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttZUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Up1;
            this.buttZUp.Location = new System.Drawing.Point(6, 37);
            this.buttZUp.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttZUp.Name = "buttZUp";
            this.buttZUp.Padding = new System.Windows.Forms.Padding(5);
            this.buttZUp.Size = new System.Drawing.Size(48, 53);
            this.buttZUp.StyleName = null;
            this.buttZUp.TabIndex = 27;
            this.buttZUp.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nbrZSpeed);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nbrZDist);
            this.panel1.Controls.Add(this.buttZHome);
            this.panel1.Controls.Add(this.progressTitle);
            this.panel1.Controls.Add(this.buttZDown);
            this.panel1.Controls.Add(this.buttZUp);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 258);
            this.panel1.TabIndex = 28;
            // 
            // buttZDown
            // 
            this.buttZDown.BackColor = System.Drawing.Color.Navy;
            this.buttZDown.Checked = false;
            this.buttZDown.CheckImage = null;
            this.buttZDown.Enabled = false;
            this.buttZDown.Gapx = 5;
            this.buttZDown.Gapy = 5;
            this.buttZDown.GLBackgroundImage = null;
            this.buttZDown.GLImage = null;
            this.buttZDown.GLVisible = false;
            this.buttZDown.GuiAnchor = null;
            this.buttZDown.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttZDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Down1;
            this.buttZDown.Location = new System.Drawing.Point(5, 195);
            this.buttZDown.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttZDown.Name = "buttZDown";
            this.buttZDown.Padding = new System.Windows.Forms.Padding(5);
            this.buttZDown.Size = new System.Drawing.Size(48, 48);
            this.buttZDown.StyleName = null;
            this.buttZDown.TabIndex = 28;
            this.buttZDown.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // progressTitle
            // 
            this.progressTitle.BarColor = System.Drawing.Color.RoyalBlue;
            this.progressTitle.BorderThickness = 2;
            this.progressTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.progressTitle.ForeColor = System.Drawing.Color.White;
            this.progressTitle.Location = new System.Drawing.Point(2, 4);
            this.progressTitle.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.progressTitle.Maximum = 100;
            this.progressTitle.Minimum = 0;
            this.progressTitle.Name = "progressTitle";
            this.progressTitle.Size = new System.Drawing.Size(114, 25);
            this.progressTitle.TabIndex = 29;
            this.progressTitle.Text = "Z-Axis";
            this.progressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressTitle.Value = 0;
            // 
            // buttZHome
            // 
            this.buttZHome.BackColor = System.Drawing.Color.Navy;
            this.buttZHome.Checked = false;
            this.buttZHome.CheckImage = null;
            this.buttZHome.Enabled = false;
            this.buttZHome.Gapx = 5;
            this.buttZHome.Gapy = 5;
            this.buttZHome.GLBackgroundImage = null;
            this.buttZHome.GLImage = null;
            this.buttZHome.GLVisible = false;
            this.buttZHome.GuiAnchor = null;
            this.buttZHome.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttZHome.Image = global::UV_DLP_3D_Printer.Properties.Resources.homeButt;
            this.buttZHome.Location = new System.Drawing.Point(61, 195);
            this.buttZHome.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttZHome.Name = "buttZHome";
            this.buttZHome.Padding = new System.Windows.Forms.Padding(5);
            this.buttZHome.Size = new System.Drawing.Size(48, 48);
            this.buttZHome.StyleName = null;
            this.buttZHome.TabIndex = 30;
            this.buttZHome.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Distance(mm)";
            // 
            // nbrZDist
            // 
            this.nbrZDist.BackColor = System.Drawing.Color.RoyalBlue;
            this.nbrZDist.ButtonsColor = System.Drawing.Color.Navy;
            this.nbrZDist.Checked = false;
            this.nbrZDist.ErrorColor = System.Drawing.Color.Red;
            this.nbrZDist.FloatVal = 17F;
            this.nbrZDist.Gapx = 5;
            this.nbrZDist.Gapy = 5;
            this.nbrZDist.GLBackgroundImage = null;
            this.nbrZDist.GLVisible = false;
            this.nbrZDist.GuiAnchor = null;
            this.nbrZDist.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.nbrZDist.Increment = 1F;
            this.nbrZDist.IntVal = 100;
            this.nbrZDist.IsFloat = true;
            this.nbrZDist.Location = new System.Drawing.Point(4, 109);
            this.nbrZDist.MaxFloat = 100F;
            this.nbrZDist.MaxInt = 1000;
            this.nbrZDist.MinFloat = 0F;
            this.nbrZDist.MinimumSize = new System.Drawing.Size(20, 5);
            this.nbrZDist.MinInt = 0;
            this.nbrZDist.Name = "nbrZDist";
            this.nbrZDist.Size = new System.Drawing.Size(112, 26);
            this.nbrZDist.StyleName = null;
            this.nbrZDist.TabIndex = 31;
            this.nbrZDist.TextFont = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nbrZDist.ValidColor = System.Drawing.Color.White;
            this.nbrZDist.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "Speed(mm/min)";
            // 
            // nbrZSpeed
            // 
            this.nbrZSpeed.BackColor = System.Drawing.Color.RoyalBlue;
            this.nbrZSpeed.ButtonsColor = System.Drawing.Color.Navy;
            this.nbrZSpeed.Checked = false;
            this.nbrZSpeed.ErrorColor = System.Drawing.Color.Red;
            this.nbrZSpeed.FloatVal = 170F;
            this.nbrZSpeed.Gapx = 5;
            this.nbrZSpeed.Gapy = 5;
            this.nbrZSpeed.GLBackgroundImage = null;
            this.nbrZSpeed.GLVisible = false;
            this.nbrZSpeed.GuiAnchor = null;
            this.nbrZSpeed.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.nbrZSpeed.Increment = 1F;
            this.nbrZSpeed.IntVal = 103;
            this.nbrZSpeed.Location = new System.Drawing.Point(3, 158);
            this.nbrZSpeed.MaxFloat = 1000F;
            this.nbrZSpeed.MaxInt = 1000;
            this.nbrZSpeed.MinFloat = 1F;
            this.nbrZSpeed.MinimumSize = new System.Drawing.Size(20, 5);
            this.nbrZSpeed.MinInt = 1;
            this.nbrZSpeed.Name = "nbrZSpeed";
            this.nbrZSpeed.Size = new System.Drawing.Size(112, 26);
            this.nbrZSpeed.StyleName = null;
            this.nbrZSpeed.TabIndex = 33;
            this.nbrZSpeed.TextFont = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nbrZSpeed.ValidColor = System.Drawing.Color.White;
            this.nbrZSpeed.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.panel1);
            this.Name = "ctlManualControl";
            this.Size = new System.Drawing.Size(131, 264);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomGUI.ctlImageButton buttZUp;
        private System.Windows.Forms.Panel panel1;
        private CustomGUI.ctlImageButton buttZDown;
        private CustomGUI.ctlImageButton buttZHome;
        private CustomGUI.ctlProgress progressTitle;
        private System.Windows.Forms.Label label1;
        private CustomGUI.ctlNumber nbrZSpeed;
        private System.Windows.Forms.Label label2;
        private CustomGUI.ctlNumber nbrZDist;
    }
}
