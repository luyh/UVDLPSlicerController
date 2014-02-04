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
            this.progressTitle = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlProgress();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttAddSupport = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttAutoSupport = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.buttSetup = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSuppotShape = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numFB1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.numFB = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.numFT = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.numHB = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.numHT = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.pictureSupport = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDownPolys = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.numDownAngle = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbSupType = new System.Windows.Forms.ComboBox();
            this.chkOnlyDownward = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.numY = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.numX = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlToolTip1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlToolTip();
            this.buttManualEdit = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panelSuppotShape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSupport)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Navy;
            this.flowLayoutPanel2.Controls.Add(this.progressTitle);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(396, 412);
            this.flowLayoutPanel2.TabIndex = 23;
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
            // buttAddSupport
            // 
            this.buttAddSupport.BackColor = System.Drawing.Color.Navy;
            this.buttAddSupport.Checked = false;
            this.buttAddSupport.CheckImage = null;
            this.buttAddSupport.Gapx = 5;
            this.buttAddSupport.Gapy = 5;
            this.buttAddSupport.GuiAnchor = null;
            this.buttAddSupport.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAddSupport.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttAddSupport;
            this.buttAddSupport.Location = new System.Drawing.Point(5, 5);
            this.buttAddSupport.Margin = new System.Windows.Forms.Padding(5);
            this.buttAddSupport.Name = "buttAddSupport";
            this.buttAddSupport.Size = new System.Drawing.Size(48, 48);
            this.buttAddSupport.TabIndex = 23;
            this.ctlToolTip1.SetToolTip(this.buttAddSupport, "Add manual\r\nsupport");
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
            this.buttAutoSupport.GuiAnchor = null;
            this.buttAutoSupport.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAutoSupport.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttAutoSupport;
            this.buttAutoSupport.Location = new System.Drawing.Point(58, 5);
            this.buttAutoSupport.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttAutoSupport.Name = "buttAutoSupport";
            this.buttAutoSupport.Size = new System.Drawing.Size(48, 48);
            this.buttAutoSupport.TabIndex = 24;
            this.ctlToolTip1.SetToolTip(this.buttAutoSupport, "Add automatic\r\nsupports");
            this.buttAutoSupport.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttAutoSupport.Click += new System.EventHandler(this.buttAutoSupport_Click);
            // 
            // buttSetup
            // 
            this.buttSetup.BackColor = System.Drawing.Color.Navy;
            this.buttSetup.Checked = false;
            this.buttSetup.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttSetup.Gapx = 5;
            this.buttSetup.Gapy = 5;
            this.buttSetup.GuiAnchor = null;
            this.buttSetup.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttSetup.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttGear;
            this.buttSetup.Location = new System.Drawing.Point(111, 5);
            this.buttSetup.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttSetup.Name = "buttSetup";
            this.buttSetup.Size = new System.Drawing.Size(48, 48);
            this.buttSetup.TabIndex = 25;
            this.ctlToolTip1.SetToolTip(this.buttSetup, "Support configuration");
            this.buttSetup.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttSetup.Click += new System.EventHandler(this.buttSetup_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.panelSuppotShape);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 97);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(370, 281);
            this.flowLayoutPanel3.TabIndex = 26;
            // 
            // panelSuppotShape
            // 
            this.panelSuppotShape.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelSuppotShape.Controls.Add(this.label1);
            this.panelSuppotShape.Controls.Add(this.numFB1);
            this.panelSuppotShape.Controls.Add(this.numFB);
            this.panelSuppotShape.Controls.Add(this.numFT);
            this.panelSuppotShape.Controls.Add(this.numHB);
            this.panelSuppotShape.Controls.Add(this.numHT);
            this.panelSuppotShape.Controls.Add(this.pictureSupport);
            this.panelSuppotShape.ForeColor = System.Drawing.Color.White;
            this.panelSuppotShape.Location = new System.Drawing.Point(0, 0);
            this.panelSuppotShape.Margin = new System.Windows.Forms.Padding(0);
            this.panelSuppotShape.Name = "panelSuppotShape";
            this.panelSuppotShape.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSuppotShape.Size = new System.Drawing.Size(201, 280);
            this.panelSuppotShape.TabIndex = 25;
            this.panelSuppotShape.Text = "Support Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 17.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 28;
            this.label1.Text = "Support shape";
            // 
            // numFB1
            // 
            this.numFB1.BackColor = System.Drawing.Color.RoyalBlue;
            this.numFB1.ButtonsColor = System.Drawing.Color.Navy;
            this.numFB1.Checked = false;
            this.numFB1.ErrorColor = System.Drawing.Color.Red;
            this.numFB1.FloatVal = 1F;
            this.numFB1.Gapx = 5;
            this.numFB1.Gapy = 5;
            this.numFB1.GuiAnchor = null;
            this.numFB1.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numFB1.Increment = 0.1F;
            this.numFB1.IntVal = 1;
            this.numFB1.IsFloat = true;
            this.numFB1.Location = new System.Drawing.Point(114, 160);
            this.numFB1.Margin = new System.Windows.Forms.Padding(4);
            this.numFB1.MaxFloat = 20F;
            this.numFB1.MaxInt = 1000;
            this.numFB1.MinFloat = 0.1F;
            this.numFB1.MinimumSize = new System.Drawing.Size(20, 5);
            this.numFB1.MinInt = 1;
            this.numFB1.Name = "numFB1";
            this.numFB1.Size = new System.Drawing.Size(79, 21);
            this.numFB1.TabIndex = 27;
            this.numFB1.TextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numFB1, "Foot Bottom intra (mm)");
            this.numFB1.ValidColor = System.Drawing.Color.White;
            this.numFB1.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numFB1.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            this.numFB1.Enter += new System.EventHandler(this.numFB1_Enter);
            // 
            // numFB
            // 
            this.numFB.BackColor = System.Drawing.Color.RoyalBlue;
            this.numFB.ButtonsColor = System.Drawing.Color.Navy;
            this.numFB.Checked = false;
            this.numFB.ErrorColor = System.Drawing.Color.Red;
            this.numFB.FloatVal = 1F;
            this.numFB.Gapx = 5;
            this.numFB.Gapy = 5;
            this.numFB.GuiAnchor = null;
            this.numFB.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numFB.Increment = 0.1F;
            this.numFB.IntVal = 1;
            this.numFB.IsFloat = true;
            this.numFB.Location = new System.Drawing.Point(114, 133);
            this.numFB.Margin = new System.Windows.Forms.Padding(4);
            this.numFB.MaxFloat = 20F;
            this.numFB.MaxInt = 1000;
            this.numFB.MinFloat = 0.1F;
            this.numFB.MinimumSize = new System.Drawing.Size(20, 5);
            this.numFB.MinInt = 1;
            this.numFB.Name = "numFB";
            this.numFB.Size = new System.Drawing.Size(79, 21);
            this.numFB.TabIndex = 26;
            this.numFB.TextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numFB, "Foot Bottom (mm)");
            this.numFB.ValidColor = System.Drawing.Color.White;
            this.numFB.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numFB.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            this.numFB.Enter += new System.EventHandler(this.numFB_Enter);
            // 
            // numFT
            // 
            this.numFT.BackColor = System.Drawing.Color.RoyalBlue;
            this.numFT.ButtonsColor = System.Drawing.Color.Navy;
            this.numFT.Checked = false;
            this.numFT.ErrorColor = System.Drawing.Color.Red;
            this.numFT.FloatVal = 1F;
            this.numFT.Gapx = 5;
            this.numFT.Gapy = 5;
            this.numFT.GuiAnchor = null;
            this.numFT.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numFT.Increment = 0.1F;
            this.numFT.IntVal = 1;
            this.numFT.IsFloat = true;
            this.numFT.Location = new System.Drawing.Point(114, 106);
            this.numFT.Margin = new System.Windows.Forms.Padding(4);
            this.numFT.MaxFloat = 20F;
            this.numFT.MaxInt = 1000;
            this.numFT.MinFloat = 0.1F;
            this.numFT.MinimumSize = new System.Drawing.Size(20, 5);
            this.numFT.MinInt = 1;
            this.numFT.Name = "numFT";
            this.numFT.Size = new System.Drawing.Size(79, 21);
            this.numFT.TabIndex = 25;
            this.numFT.TextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numFT, "Foot Top (mm)");
            this.numFT.ValidColor = System.Drawing.Color.White;
            this.numFT.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numFT.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numHB
            // 
            this.numHB.BackColor = System.Drawing.Color.RoyalBlue;
            this.numHB.ButtonsColor = System.Drawing.Color.Navy;
            this.numHB.Checked = false;
            this.numHB.ErrorColor = System.Drawing.Color.Red;
            this.numHB.FloatVal = 1F;
            this.numHB.Gapx = 5;
            this.numHB.Gapy = 5;
            this.numHB.GuiAnchor = null;
            this.numHB.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numHB.Increment = 0.1F;
            this.numHB.IntVal = 1;
            this.numHB.IsFloat = true;
            this.numHB.Location = new System.Drawing.Point(114, 58);
            this.numHB.Margin = new System.Windows.Forms.Padding(4);
            this.numHB.MaxFloat = 20F;
            this.numHB.MaxInt = 1000;
            this.numHB.MinFloat = 0.1F;
            this.numHB.MinimumSize = new System.Drawing.Size(20, 5);
            this.numHB.MinInt = 1;
            this.numHB.Name = "numHB";
            this.numHB.Size = new System.Drawing.Size(79, 21);
            this.numHB.TabIndex = 24;
            this.numHB.TextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numHB, "Head Bottom (mm)");
            this.numHB.ValidColor = System.Drawing.Color.White;
            this.numHB.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numHB.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numHT
            // 
            this.numHT.BackColor = System.Drawing.Color.RoyalBlue;
            this.numHT.ButtonsColor = System.Drawing.Color.Navy;
            this.numHT.Checked = false;
            this.numHT.ErrorColor = System.Drawing.Color.Red;
            this.numHT.FloatVal = 1F;
            this.numHT.Gapx = 5;
            this.numHT.Gapy = 5;
            this.numHT.GuiAnchor = null;
            this.numHT.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numHT.Increment = 0.1F;
            this.numHT.IntVal = 1;
            this.numHT.IsFloat = true;
            this.numHT.Location = new System.Drawing.Point(114, 31);
            this.numHT.Margin = new System.Windows.Forms.Padding(4);
            this.numHT.MaxFloat = 20F;
            this.numHT.MaxInt = 1000;
            this.numHT.MinFloat = 0.1F;
            this.numHT.MinimumSize = new System.Drawing.Size(20, 5);
            this.numHT.MinInt = 1;
            this.numHT.Name = "numHT";
            this.numHT.Size = new System.Drawing.Size(79, 21);
            this.numHT.TabIndex = 23;
            this.numHT.TextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numHT, "Head Top (mm)");
            this.numHT.ValidColor = System.Drawing.Color.White;
            this.numHT.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numHT.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // pictureSupport
            // 
            this.pictureSupport.Location = new System.Drawing.Point(5, 31);
            this.pictureSupport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureSupport.Name = "pictureSupport";
            this.pictureSupport.Size = new System.Drawing.Size(108, 150);
            this.pictureSupport.TabIndex = 12;
            this.pictureSupport.TabStop = false;
            this.pictureSupport.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureSupport_Paint);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.panel1);
            this.flowLayoutPanel4.Controls.Add(this.panel2);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(204, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(162, 281);
            this.flowLayoutPanel4.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.buttManualEdit);
            this.panel1.Controls.Add(this.chkDownPolys);
            this.panel1.Controls.Add(this.numDownAngle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 127);
            this.panel1.TabIndex = 0;
            // 
            // chkDownPolys
            // 
            this.chkDownPolys.BackColor = System.Drawing.Color.Navy;
            this.chkDownPolys.Checked = false;
            this.chkDownPolys.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.chkDownPolys.Gapx = 5;
            this.chkDownPolys.Gapy = 5;
            this.chkDownPolys.GuiAnchor = null;
            this.chkDownPolys.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.chkDownPolys.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewDown;
            this.chkDownPolys.Location = new System.Drawing.Point(7, 32);
            this.chkDownPolys.Margin = new System.Windows.Forms.Padding(5);
            this.chkDownPolys.Name = "chkDownPolys";
            this.chkDownPolys.Size = new System.Drawing.Size(32, 32);
            this.chkDownPolys.TabIndex = 31;
            this.ctlToolTip1.SetToolTip(this.chkDownPolys, "Show downward facing \r\nsurfaces by angle");
            this.chkDownPolys.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.chkDownPolys.Click += new System.EventHandler(this.chkDownPolys_Click);
            // 
            // numDownAngle
            // 
            this.numDownAngle.BackColor = System.Drawing.Color.RoyalBlue;
            this.numDownAngle.ButtonsColor = System.Drawing.Color.Navy;
            this.numDownAngle.Checked = false;
            this.numDownAngle.ErrorColor = System.Drawing.Color.Red;
            this.numDownAngle.FloatVal = 1000F;
            this.numDownAngle.Gapx = 5;
            this.numDownAngle.Gapy = 5;
            this.numDownAngle.GuiAnchor = null;
            this.numDownAngle.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numDownAngle.Increment = 1F;
            this.numDownAngle.IntVal = 1;
            this.numDownAngle.IsFloat = true;
            this.numDownAngle.Location = new System.Drawing.Point(80, 43);
            this.numDownAngle.Margin = new System.Windows.Forms.Padding(4);
            this.numDownAngle.MaxFloat = 90F;
            this.numDownAngle.MaxInt = 1000;
            this.numDownAngle.MinFloat = 0F;
            this.numDownAngle.MinimumSize = new System.Drawing.Size(20, 5);
            this.numDownAngle.MinInt = 1;
            this.numDownAngle.Name = "numDownAngle";
            this.numDownAngle.Size = new System.Drawing.Size(79, 21);
            this.numDownAngle.TabIndex = 30;
            this.numDownAngle.TextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numDownAngle, "Downward facing degree");
            this.numDownAngle.ValidColor = System.Drawing.Color.White;
            this.numDownAngle.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numDownAngle.ValueChanged += new System.EventHandler(this.numDownAngle_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(49, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 14);
            this.label4.TabIndex = 32;
            this.label4.Text = "Deg:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 17.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 22);
            this.label2.TabIndex = 29;
            this.label2.Text = "Manual config";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.cmbSupType);
            this.panel2.Controls.Add(this.chkOnlyDownward);
            this.panel2.Controls.Add(this.numY);
            this.panel2.Controls.Add(this.numX);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 151);
            this.panel2.TabIndex = 1;
            // 
            // cmbSupType
            // 
            this.cmbSupType.BackColor = System.Drawing.Color.RoyalBlue;
            this.cmbSupType.ForeColor = System.Drawing.SystemColors.Info;
            this.cmbSupType.FormattingEnabled = true;
            this.cmbSupType.Items.AddRange(new object[] {
            "Bed of Nails",
            "Adaptive"});
            this.cmbSupType.Location = new System.Drawing.Point(7, 25);
            this.cmbSupType.Name = "cmbSupType";
            this.cmbSupType.Size = new System.Drawing.Size(147, 24);
            this.cmbSupType.TabIndex = 35;
            this.cmbSupType.SelectedIndexChanged += new System.EventHandler(this.cmbSupType_SelectedIndexChanged);
            // 
            // chkOnlyDownward
            // 
            this.chkOnlyDownward.BackColor = System.Drawing.Color.Navy;
            this.chkOnlyDownward.Checked = false;
            this.chkOnlyDownward.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.chkOnlyDownward.Gapx = 5;
            this.chkOnlyDownward.Gapy = 5;
            this.chkOnlyDownward.GuiAnchor = null;
            this.chkOnlyDownward.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.chkOnlyDownward.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttAutoDown;
            this.chkOnlyDownward.Location = new System.Drawing.Point(7, 56);
            this.chkOnlyDownward.Margin = new System.Windows.Forms.Padding(5);
            this.chkOnlyDownward.Name = "chkOnlyDownward";
            this.chkOnlyDownward.Size = new System.Drawing.Size(32, 32);
            this.chkOnlyDownward.TabIndex = 32;
            this.ctlToolTip1.SetToolTip(this.chkOnlyDownward, "Generate support only on\r\ndownward facing surfaces");
            this.chkOnlyDownward.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // numY
            // 
            this.numY.BackColor = System.Drawing.Color.RoyalBlue;
            this.numY.ButtonsColor = System.Drawing.Color.Navy;
            this.numY.Checked = false;
            this.numY.ErrorColor = System.Drawing.Color.Red;
            this.numY.FloatVal = 1F;
            this.numY.Gapx = 5;
            this.numY.Gapy = 5;
            this.numY.GuiAnchor = null;
            this.numY.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numY.Increment = 0.1F;
            this.numY.IntVal = 1;
            this.numY.IsFloat = true;
            this.numY.Location = new System.Drawing.Point(49, 129);
            this.numY.Margin = new System.Windows.Forms.Padding(4);
            this.numY.MaxFloat = 20F;
            this.numY.MaxInt = 1000;
            this.numY.MinFloat = -20F;
            this.numY.MinimumSize = new System.Drawing.Size(20, 5);
            this.numY.MinInt = 1;
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(79, 21);
            this.numY.TabIndex = 34;
            this.numY.TextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numY, "Vertical grid spacing");
            this.numY.ValidColor = System.Drawing.Color.White;
            this.numY.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // numX
            // 
            this.numX.BackColor = System.Drawing.Color.RoyalBlue;
            this.numX.ButtonsColor = System.Drawing.Color.Navy;
            this.numX.Checked = false;
            this.numX.ErrorColor = System.Drawing.Color.Red;
            this.numX.FloatVal = 1F;
            this.numX.Gapx = 5;
            this.numX.Gapy = 5;
            this.numX.GuiAnchor = null;
            this.numX.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.numX.Increment = 0.1F;
            this.numX.IntVal = 1;
            this.numX.IsFloat = true;
            this.numX.Location = new System.Drawing.Point(49, 105);
            this.numX.Margin = new System.Windows.Forms.Padding(4);
            this.numX.MaxFloat = 20F;
            this.numX.MaxInt = 1000;
            this.numX.MinFloat = -20F;
            this.numX.MinimumSize = new System.Drawing.Size(20, 5);
            this.numX.MinInt = 1;
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(79, 21);
            this.numX.TabIndex = 33;
            this.numX.TextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlToolTip1.SetToolTip(this.numX, "Horizontal grid spacing");
            this.numX.ValidColor = System.Drawing.Color.White;
            this.numX.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 14);
            this.label7.TabIndex = 32;
            this.label7.Text = "Y (mm):";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "X (mm):";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "Automatic Support Grid:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 17.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "Automatic config";
            // 
            // ctlToolTip1
            // 
            this.ctlToolTip1.AutoPopDelay = 5000;
            this.ctlToolTip1.BackColor = System.Drawing.Color.Turquoise;
            this.ctlToolTip1.ForeColor = System.Drawing.Color.Navy;
            this.ctlToolTip1.InitialDelay = 1500;
            this.ctlToolTip1.ReshowDelay = 100;
            // 
            // buttManualEdit
            // 
            this.buttManualEdit.BackColor = System.Drawing.Color.Navy;
            this.buttManualEdit.Checked = false;
            this.buttManualEdit.CheckImage = global::UV_DLP_3D_Printer.Properties.Resources.buttChecked;
            this.buttManualEdit.Gapx = 5;
            this.buttManualEdit.Gapy = 5;
            this.buttManualEdit.GuiAnchor = null;
            this.buttManualEdit.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttManualEdit.Image = global::UV_DLP_3D_Printer.Properties.Resources.buttViewDown;
            this.buttManualEdit.Location = new System.Drawing.Point(5, 90);
            this.buttManualEdit.Margin = new System.Windows.Forms.Padding(5);
            this.buttManualEdit.Name = "buttManualEdit";
            this.buttManualEdit.Size = new System.Drawing.Size(72, 32);
            this.buttManualEdit.TabIndex = 33;
            this.ctlToolTip1.SetToolTip(this.buttManualEdit, "Show downward facing \r\nsurfaces by angle");
            this.buttManualEdit.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttManualEdit.Click += new System.EventHandler(this.buttManualEdit_Click);
            // 
            // ctlSupports
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ctlSupports";
            this.Size = new System.Drawing.Size(406, 390);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panelSuppotShape.ResumeLayout(false);
            this.panelSuppotShape.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSupport)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ctlImageButton buttAddSupport;
        private ctlImageButton buttAutoSupport;
        private ctlImageButton buttSetup;
        private ctlProgress progressTitle;
        private ctlToolTip ctlToolTip1;
        private System.Windows.Forms.Panel panelSuppotShape;
        private ctlNumber numHT;
        private System.Windows.Forms.PictureBox pictureSupport;
        private ctlNumber numFB;
        private ctlNumber numFT;
        private ctlNumber numHB;
        private ctlNumber numFB1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private ctlNumber numDownAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private ctlImageButton chkDownPolys;
        private ctlNumber numY;
        private ctlNumber numX;
        private ctlImageButton chkOnlyDownward;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSupType;
        private ctlImageButton buttManualEdit;
    }
}
