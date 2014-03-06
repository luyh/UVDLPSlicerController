namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctl3DView
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
            this.mainViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.textTime = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlText();
            this.textMainMessage = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlText();
            this.textProgress = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlText();
            this.buttRedo = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttUndo = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.objectInfoPanel = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlObjectInfo();
            this.numLayer = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.buttGlHome = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.ctlSupport = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlSupports();
            this.buttSupports = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.glControl1 = new UV_DLP_3D_Printer.GUI.Controls.ctlGL();
            this.ctlToolTip1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlToolTip();
            this.mainViewSplitContainer.Panel2.SuspendLayout();
            this.mainViewSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainViewSplitContainer
            // 
            this.mainViewSplitContainer.BackColor = System.Drawing.Color.RoyalBlue;
            this.mainViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainViewSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainViewSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.mainViewSplitContainer.Name = "mainViewSplitContainer";
            // 
            // mainViewSplitContainer.Panel2
            // 
            this.mainViewSplitContainer.Panel2.Controls.Add(this.textTime);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.textMainMessage);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.textProgress);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttRedo);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttUndo);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.objectInfoPanel);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.numLayer);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttGlHome);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.ctlSupport);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.buttSupports);
            this.mainViewSplitContainer.Panel2.Controls.Add(this.glControl1);
            this.mainViewSplitContainer.Panel2.SizeChanged += new System.EventHandler(this.mainViewSplitContainer_Panel2_SizeChanged);
            this.mainViewSplitContainer.Size = new System.Drawing.Size(1200, 700);
            this.mainViewSplitContainer.SplitterDistance = 77;
            this.mainViewSplitContainer.TabIndex = 28;
            // 
            // textTime
            // 
            this.textTime.BackColor = System.Drawing.Color.Transparent;
            this.textTime.Gapx = 0;
            this.textTime.Gapy = 0;
            this.textTime.GLBackgroundImage = null;
            this.textTime.GLFont = "Arial18";
            this.textTime.GLVisible = false;
            this.textTime.GuiAnchor = null;
            this.textTime.Location = new System.Drawing.Point(443, 380);
            this.textTime.Name = "textTime";
            this.textTime.Size = new System.Drawing.Size(102, 26);
            this.textTime.StyleName = null;
            this.textTime.TabIndex = 46;
            this.textTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textMainMessage
            // 
            this.textMainMessage.Gapx = 0;
            this.textMainMessage.Gapy = 0;
            this.textMainMessage.GLBackgroundImage = null;
            this.textMainMessage.GLFont = "Arial18";
            this.textMainMessage.GLVisible = false;
            this.textMainMessage.GuiAnchor = null;
            this.textMainMessage.Location = new System.Drawing.Point(443, 336);
            this.textMainMessage.Name = "textMainMessage";
            this.textMainMessage.Size = new System.Drawing.Size(102, 26);
            this.textMainMessage.StyleName = null;
            this.textMainMessage.TabIndex = 45;
            this.textMainMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textProgress
            // 
            this.textProgress.BackColor = System.Drawing.Color.Transparent;
            this.textProgress.Gapx = 0;
            this.textProgress.Gapy = 0;
            this.textProgress.GLBackgroundImage = null;
            this.textProgress.GLFont = "Arial18";
            this.textProgress.GLVisible = false;
            this.textProgress.GuiAnchor = null;
            this.textProgress.Location = new System.Drawing.Point(452, 440);
            this.textProgress.Name = "textProgress";
            this.textProgress.Size = new System.Drawing.Size(76, 30);
            this.textProgress.StyleName = null;
            this.textProgress.TabIndex = 34;
            this.textProgress.Text = "79 %";
            // 
            // buttRedo
            // 
            this.buttRedo.BackColor = System.Drawing.Color.Navy;
            this.buttRedo.Checked = false;
            this.buttRedo.CheckImage = null;
            this.buttRedo.Gapx = 60;
            this.buttRedo.Gapy = 10;
            this.buttRedo.GLBackgroundImage = null;
            this.buttRedo.GLImage = null;
            this.buttRedo.GLVisible = false;
            this.buttRedo.GuiAnchor = null;
            this.buttRedo.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttRedo.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttRedo;
            this.buttRedo.Location = new System.Drawing.Point(15, 133);
            this.buttRedo.Name = "buttRedo";
            this.buttRedo.Size = new System.Drawing.Size(48, 48);
            this.buttRedo.StyleName = null;
            this.buttRedo.TabIndex = 30;
            this.ctlToolTip1.SetToolTip(this.buttRedo, "Undo");
            this.buttRedo.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            // 
            // buttUndo
            // 
            this.buttUndo.BackColor = System.Drawing.Color.Navy;
            this.buttUndo.Checked = false;
            this.buttUndo.CheckImage = null;
            this.buttUndo.Gapx = 10;
            this.buttUndo.Gapy = 10;
            this.buttUndo.GLBackgroundImage = null;
            this.buttUndo.GLImage = null;
            this.buttUndo.GLVisible = false;
            this.buttUndo.GuiAnchor = null;
            this.buttUndo.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttUndo.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttUndo;
            this.buttUndo.Location = new System.Drawing.Point(15, 79);
            this.buttUndo.Name = "buttUndo";
            this.buttUndo.Size = new System.Drawing.Size(48, 48);
            this.buttUndo.StyleName = null;
            this.buttUndo.TabIndex = 29;
            this.ctlToolTip1.SetToolTip(this.buttUndo, "Undo");
            this.buttUndo.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            // 
            // objectInfoPanel
            // 
            this.objectInfoPanel.Checked = false;
            this.objectInfoPanel.Gapx = 24;
            this.objectInfoPanel.Gapy = 24;
            this.objectInfoPanel.GLBackgroundImage = null;
            this.objectInfoPanel.GLVisible = false;
            this.objectInfoPanel.GuiAnchor = null;
            this.objectInfoPanel.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.objectInfoPanel.Location = new System.Drawing.Point(584, 59);
            this.objectInfoPanel.Name = "objectInfoPanel";
            this.objectInfoPanel.Size = new System.Drawing.Size(300, 240);
            this.objectInfoPanel.StyleName = null;
            this.objectInfoPanel.TabIndex = 28;
            this.objectInfoPanel.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.objectInfoPanel.Visible = false;
            // 
            // numLayer
            // 
            this.numLayer.BackColor = System.Drawing.Color.RoyalBlue;
            this.numLayer.ButtonsColor = System.Drawing.Color.Navy;
            this.numLayer.Checked = false;
            this.numLayer.EnableScroll = true;
            this.numLayer.ErrorColor = System.Drawing.Color.Red;
            this.numLayer.FloatVal = 10F;
            this.numLayer.Gapx = 0;
            this.numLayer.Gapy = 80;
            this.numLayer.GLBackgroundImage = null;
            this.numLayer.GLVisible = false;
            this.numLayer.GuiAnchor = null;
            this.numLayer.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Center;
            this.numLayer.Increment = 1F;
            this.numLayer.IntVal = 1000;
            this.numLayer.Location = new System.Drawing.Point(103, 514);
            this.numLayer.MaxFloat = 500F;
            this.numLayer.MaxInt = 1000;
            this.numLayer.MinFloat = -500F;
            this.numLayer.MinimumSize = new System.Drawing.Size(20, 5);
            this.numLayer.MinInt = 1;
            this.numLayer.Name = "numLayer";
            this.numLayer.Size = new System.Drawing.Size(425, 24);
            this.numLayer.StyleName = null;
            this.numLayer.TabIndex = 27;
            this.numLayer.TextFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numLayer.ValidColor = System.Drawing.Color.White;
            this.numLayer.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.numLayer.Visible = false;
            this.numLayer.ValueChanged += new System.EventHandler(this.numLayer_ValueChanged);
            // 
            // buttGlHome
            // 
            this.buttGlHome.BackColor = System.Drawing.Color.Transparent;
            this.buttGlHome.Checked = false;
            this.buttGlHome.CheckImage = null;
            this.buttGlHome.Gapx = 10;
            this.buttGlHome.Gapy = 10;
            this.buttGlHome.GLBackgroundImage = null;
            this.buttGlHome.GLImage = "glButtHome";
            this.buttGlHome.GLVisible = false;
            this.buttGlHome.GuiAnchor = null;
            this.buttGlHome.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Right;
            this.buttGlHome.Image = global::UV_DLP_3D_Printer.Properties.Resources.homeButt;
            this.buttGlHome.Location = new System.Drawing.Point(15, 15);
            this.buttGlHome.Name = "buttGlHome";
            this.buttGlHome.Size = new System.Drawing.Size(48, 48);
            this.buttGlHome.StyleName = null;
            this.buttGlHome.TabIndex = 16;
            this.ctlToolTip1.SetToolTip(this.buttGlHome, "Home");
            this.buttGlHome.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Top;
            this.buttGlHome.Click += new System.EventHandler(this.buttGlHome_Click);
            // 
            // ctlSupport
            // 
            this.ctlSupport.Gapx = 0;
            this.ctlSupport.Gapy = 0;
            this.ctlSupport.GLBackgroundImage = null;
            this.ctlSupport.GLVisible = false;
            this.ctlSupport.GuiAnchor = null;
            this.ctlSupport.Location = new System.Drawing.Point(284, 15);
            this.ctlSupport.Name = "ctlSupport";
            this.ctlSupport.Size = new System.Drawing.Size(170, 96);
            this.ctlSupport.StyleName = null;
            this.ctlSupport.TabIndex = 24;
            this.ctlSupport.Visible = false;
            // 
            // buttSupports
            // 
            this.buttSupports.BackColor = System.Drawing.Color.Navy;
            this.buttSupports.Checked = false;
            this.buttSupports.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttOpenClose;
            this.buttSupports.Gapx = 10;
            this.buttSupports.Gapy = 170;
            this.buttSupports.GLBackgroundImage = null;
            this.buttSupports.GLImage = null;
            this.buttSupports.GLVisible = false;
            this.buttSupports.GuiAnchor = null;
            this.buttSupports.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Left;
            this.buttSupports.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttSupport;
            this.buttSupports.Location = new System.Drawing.Point(10, 336);
            this.buttSupports.Name = "buttSupports";
            this.buttSupports.Size = new System.Drawing.Size(48, 48);
            this.buttSupports.StyleName = null;
            this.buttSupports.TabIndex = 23;
            this.ctlToolTip1.SetToolTip(this.buttSupports, "Support operations");
            this.buttSupports.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.buttSupports.Click += new System.EventHandler(this.buttSupports_Click);
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Enabled = false;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(5);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1119, 700);
            this.glControl1.TabIndex = 15;
            this.glControl1.Visible = false;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Click += new System.EventHandler(this.glControl1_Click);
            this.glControl1.DoubleClick += new System.EventHandler(this.glControl1_DoubleClick);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glControl1_KeyPress);
            this.glControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyUp);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseLeave += new System.EventHandler(this.glControl1_MouseLeave);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // ctlToolTip1
            // 
            this.ctlToolTip1.AutoPopDelay = 5000;
            this.ctlToolTip1.BackColor = System.Drawing.Color.Turquoise;
            this.ctlToolTip1.ForeColor = System.Drawing.Color.Navy;
            this.ctlToolTip1.InitialDelay = 1500;
            this.ctlToolTip1.ReshowDelay = 100;
            this.ctlToolTip1.UseAnimation = false;
            this.ctlToolTip1.UseFading = false;
            // 
            // ctl3DView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.mainViewSplitContainer);
            this.Name = "ctl3DView";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.ctl3DView_Load);
            this.mainViewSplitContainer.Panel2.ResumeLayout(false);
            this.mainViewSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainViewSplitContainer;
        private CustomGUI.ctlObjectInfo objectInfoPanel;
        private CustomGUI.ctlNumber numLayer;
        private CustomGUI.ctlImageButton buttGlHome;
        private CustomGUI.ctlSupports ctlSupport;
        private CustomGUI.ctlImageButton buttSupports;
        private CustomGUI.ctlImageButton buttUndo;
        private CustomGUI.ctlToolTip ctlToolTip1;
        private CustomGUI.ctlImageButton buttRedo;
        private ctlGL glControl1;
        private CustomGUI.ctlText textProgress;
        private CustomGUI.ctlText textTime;
        private CustomGUI.ctlText textMainMessage;
    }
}
