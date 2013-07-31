namespace UV_DLP_3D_Printer
{
    partial class frmSliceOptions
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
            this.chkExportSlices = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkgengcode = new System.Windows.Forms.CheckBox();
            this.lblLayerTime = new System.Windows.Forms.Label();
            this.txtLayerTime = new System.Windows.Forms.TextBox();
            this.txtZThick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkexportsvg = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstLayerTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtYOffset = new System.Windows.Forms.TextBox();
            this.txtXOffset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBlankTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLiftDistance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBuildDirection = new System.Windows.Forms.ComboBox();
            this.txtnumbottom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tbOptions = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSlideTilt = new System.Windows.Forms.TextBox();
            this.tbStart = new System.Windows.Forms.TabPage();
            this.cmdreloadstartgcode = new System.Windows.Forms.Button();
            this.cmdsavestartgcode = new System.Windows.Forms.Button();
            this.txtstartgcode = new System.Windows.Forms.TextBox();
            this.tbPreSlice = new System.Windows.Forms.TabPage();
            this.cmdreloadpreslicegcode = new System.Windows.Forms.Button();
            this.cmdsavepreslicegcode = new System.Windows.Forms.Button();
            this.txtpreslicegcode = new System.Windows.Forms.TextBox();
            this.tbPreLift = new System.Windows.Forms.TabPage();
            this.cmdReloadPrelift = new System.Windows.Forms.Button();
            this.cmdSavePrelift = new System.Windows.Forms.Button();
            this.txtpreliftgcode = new System.Windows.Forms.TextBox();
            this.tbPostLift = new System.Windows.Forms.TabPage();
            this.cmdpostliftgcode = new System.Windows.Forms.Button();
            this.cmdsavepostliftgcode = new System.Windows.Forms.Button();
            this.txtpostliftgcode = new System.Windows.Forms.TextBox();
            this.tbEnd = new System.Windows.Forms.TabPage();
            this.cmdendgcode = new System.Windows.Forms.Button();
            this.txtsaveendgcode = new System.Windows.Forms.Button();
            this.txtendgcode = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.tbOptions.SuspendLayout();
            this.tbStart.SuspendLayout();
            this.tbPreSlice.SuspendLayout();
            this.tbPreLift.SuspendLayout();
            this.tbPostLift.SuspendLayout();
            this.tbEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkExportSlices
            // 
            this.chkExportSlices.AutoSize = true;
            this.chkExportSlices.Location = new System.Drawing.Point(28, 297);
            this.chkExportSlices.Name = "chkExportSlices";
            this.chkExportSlices.Size = new System.Drawing.Size(153, 21);
            this.chkExportSlices.TabIndex = 21;
            this.chkExportSlices.Text = "Export Image Slices";
            this.chkExportSlices.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(43, 358);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(129, 41);
            this.cmdOK.TabIndex = 24;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkgengcode
            // 
            this.chkgengcode.AutoSize = true;
            this.chkgengcode.Location = new System.Drawing.Point(28, 270);
            this.chkgengcode.Name = "chkgengcode";
            this.chkgengcode.Size = new System.Drawing.Size(138, 21);
            this.chkgengcode.TabIndex = 25;
            this.chkgengcode.Text = "Generate GCode";
            this.chkgengcode.UseVisualStyleBackColor = true;
            // 
            // lblLayerTime
            // 
            this.lblLayerTime.AutoSize = true;
            this.lblLayerTime.Location = new System.Drawing.Point(25, 66);
            this.lblLayerTime.Name = "lblLayerTime";
            this.lblLayerTime.Size = new System.Drawing.Size(200, 17);
            this.lblLayerTime.TabIndex = 27;
            this.lblLayerTime.Text = "Exposure Time Per Layer (ms)";
            // 
            // txtLayerTime
            // 
            this.txtLayerTime.Location = new System.Drawing.Point(28, 86);
            this.txtLayerTime.Name = "txtLayerTime";
            this.txtLayerTime.Size = new System.Drawing.Size(56, 22);
            this.txtLayerTime.TabIndex = 26;
            this.txtLayerTime.Text = "5000";
            // 
            // txtZThick
            // 
            this.txtZThick.Location = new System.Drawing.Point(28, 41);
            this.txtZThick.Name = "txtZThick";
            this.txtZThick.Size = new System.Drawing.Size(56, 22);
            this.txtZThick.TabIndex = 29;
            this.txtZThick.Text = ".05";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Slice Thickness (mm)";
            // 
            // chkexportsvg
            // 
            this.chkexportsvg.AutoSize = true;
            this.chkexportsvg.Enabled = false;
            this.chkexportsvg.Location = new System.Drawing.Point(28, 324);
            this.chkexportsvg.Name = "chkexportsvg";
            this.chkexportsvg.Size = new System.Drawing.Size(144, 21);
            this.chkexportsvg.TabIndex = 30;
            this.chkexportsvg.Text = "Export SVG Slices";
            this.chkexportsvg.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(178, 358);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(129, 41);
            this.cmdCancel.TabIndex = 31;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Bottom Layers Exposure Time (ms)";
            // 
            // txtFirstLayerTime
            // 
            this.txtFirstLayerTime.Location = new System.Drawing.Point(28, 133);
            this.txtFirstLayerTime.Name = "txtFirstLayerTime";
            this.txtFirstLayerTime.Size = new System.Drawing.Size(56, 22);
            this.txtFirstLayerTime.TabIndex = 32;
            this.txtFirstLayerTime.Text = "5000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtYOffset);
            this.groupBox1.Controls.Add(this.txtXOffset);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(306, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 109);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generated Image Pixel Offsets";
            // 
            // txtYOffset
            // 
            this.txtYOffset.Location = new System.Drawing.Point(72, 65);
            this.txtYOffset.Name = "txtYOffset";
            this.txtYOffset.Size = new System.Drawing.Size(68, 22);
            this.txtYOffset.TabIndex = 3;
            this.txtYOffset.Text = "0";
            // 
            // txtXOffset
            // 
            this.txtXOffset.Location = new System.Drawing.Point(72, 24);
            this.txtXOffset.Name = "txtXOffset";
            this.txtXOffset.Size = new System.Drawing.Size(68, 22);
            this.txtXOffset.TabIndex = 2;
            this.txtXOffset.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "X Offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Blanking Time Between Layers (ms)";
            // 
            // txtBlankTime
            // 
            this.txtBlankTime.Location = new System.Drawing.Point(28, 180);
            this.txtBlankTime.Name = "txtBlankTime";
            this.txtBlankTime.Size = new System.Drawing.Size(56, 22);
            this.txtBlankTime.TabIndex = 35;
            this.txtBlankTime.Text = "5000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Lift Distance (mm)";
            // 
            // txtLiftDistance
            // 
            this.txtLiftDistance.Location = new System.Drawing.Point(304, 178);
            this.txtLiftDistance.Name = "txtLiftDistance";
            this.txtLiftDistance.Size = new System.Drawing.Size(100, 22);
            this.txtLiftDistance.TabIndex = 37;
            this.txtLiftDistance.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(436, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "Build Direction";
            // 
            // cmbBuildDirection
            // 
            this.cmbBuildDirection.FormattingEnabled = true;
            this.cmbBuildDirection.Location = new System.Drawing.Point(439, 178);
            this.cmbBuildDirection.Name = "cmbBuildDirection";
            this.cmbBuildDirection.Size = new System.Drawing.Size(121, 24);
            this.cmbBuildDirection.TabIndex = 40;
            // 
            // txtnumbottom
            // 
            this.txtnumbottom.Location = new System.Drawing.Point(169, 133);
            this.txtnumbottom.Name = "txtnumbottom";
            this.txtnumbottom.Size = new System.Drawing.Size(56, 22);
            this.txtnumbottom.TabIndex = 41;
            this.txtnumbottom.Text = "3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 42;
            this.label8.Text = "# Layers";
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tbOptions);
            this.tabOptions.Controls.Add(this.tbStart);
            this.tabOptions.Controls.Add(this.tbPreSlice);
            this.tabOptions.Controls.Add(this.tbPreLift);
            this.tabOptions.Controls.Add(this.tbPostLift);
            this.tabOptions.Controls.Add(this.tbEnd);
            this.tabOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOptions.Location = new System.Drawing.Point(0, 0);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(740, 474);
            this.tabOptions.TabIndex = 45;
            // 
            // tbOptions
            // 
            this.tbOptions.Controls.Add(this.label9);
            this.tbOptions.Controls.Add(this.txtSlideTilt);
            this.tbOptions.Controls.Add(this.label1);
            this.tbOptions.Controls.Add(this.chkExportSlices);
            this.tbOptions.Controls.Add(this.cmdOK);
            this.tbOptions.Controls.Add(this.label8);
            this.tbOptions.Controls.Add(this.chkgengcode);
            this.tbOptions.Controls.Add(this.txtnumbottom);
            this.tbOptions.Controls.Add(this.txtLayerTime);
            this.tbOptions.Controls.Add(this.cmbBuildDirection);
            this.tbOptions.Controls.Add(this.lblLayerTime);
            this.tbOptions.Controls.Add(this.label7);
            this.tbOptions.Controls.Add(this.txtZThick);
            this.tbOptions.Controls.Add(this.label6);
            this.tbOptions.Controls.Add(this.chkexportsvg);
            this.tbOptions.Controls.Add(this.txtLiftDistance);
            this.tbOptions.Controls.Add(this.cmdCancel);
            this.tbOptions.Controls.Add(this.label5);
            this.tbOptions.Controls.Add(this.txtFirstLayerTime);
            this.tbOptions.Controls.Add(this.txtBlankTime);
            this.tbOptions.Controls.Add(this.label2);
            this.tbOptions.Controls.Add(this.groupBox1);
            this.tbOptions.Location = new System.Drawing.Point(4, 25);
            this.tbOptions.Name = "tbOptions";
            this.tbOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tbOptions.Size = new System.Drawing.Size(732, 445);
            this.tbOptions.TabIndex = 0;
            this.tbOptions.Text = "Options";
            this.tbOptions.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 44;
            this.label9.Text = "Slide / Tilt Value";
            // 
            // txtSlideTilt
            // 
            this.txtSlideTilt.Location = new System.Drawing.Point(305, 221);
            this.txtSlideTilt.Name = "txtSlideTilt";
            this.txtSlideTilt.Size = new System.Drawing.Size(100, 22);
            this.txtSlideTilt.TabIndex = 43;
            this.txtSlideTilt.Text = "0";
            // 
            // tbStart
            // 
            this.tbStart.Controls.Add(this.cmdreloadstartgcode);
            this.tbStart.Controls.Add(this.cmdsavestartgcode);
            this.tbStart.Controls.Add(this.txtstartgcode);
            this.tbStart.Location = new System.Drawing.Point(4, 25);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(732, 445);
            this.tbStart.TabIndex = 3;
            this.tbStart.Text = "Start GCode";
            this.tbStart.UseVisualStyleBackColor = true;
            // 
            // cmdreloadstartgcode
            // 
            this.cmdreloadstartgcode.Location = new System.Drawing.Point(191, 308);
            this.cmdreloadstartgcode.Name = "cmdreloadstartgcode";
            this.cmdreloadstartgcode.Size = new System.Drawing.Size(188, 43);
            this.cmdreloadstartgcode.TabIndex = 5;
            this.cmdreloadstartgcode.Text = "Reload";
            this.cmdreloadstartgcode.UseVisualStyleBackColor = true;
            this.cmdreloadstartgcode.Click += new System.EventHandler(this.cmdreloadstartgcode_Click);
            // 
            // cmdsavestartgcode
            // 
            this.cmdsavestartgcode.Location = new System.Drawing.Point(3, 308);
            this.cmdsavestartgcode.Name = "cmdsavestartgcode";
            this.cmdsavestartgcode.Size = new System.Drawing.Size(181, 43);
            this.cmdsavestartgcode.TabIndex = 4;
            this.cmdsavestartgcode.Text = "Save";
            this.cmdsavestartgcode.UseVisualStyleBackColor = true;
            this.cmdsavestartgcode.Click += new System.EventHandler(this.cmdsavestartgcode_Click);
            // 
            // txtstartgcode
            // 
            this.txtstartgcode.Location = new System.Drawing.Point(3, 3);
            this.txtstartgcode.Multiline = true;
            this.txtstartgcode.Name = "txtstartgcode";
            this.txtstartgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtstartgcode.Size = new System.Drawing.Size(722, 298);
            this.txtstartgcode.TabIndex = 3;
            // 
            // tbPreSlice
            // 
            this.tbPreSlice.Controls.Add(this.cmdreloadpreslicegcode);
            this.tbPreSlice.Controls.Add(this.cmdsavepreslicegcode);
            this.tbPreSlice.Controls.Add(this.txtpreslicegcode);
            this.tbPreSlice.Location = new System.Drawing.Point(4, 25);
            this.tbPreSlice.Name = "tbPreSlice";
            this.tbPreSlice.Size = new System.Drawing.Size(732, 445);
            this.tbPreSlice.TabIndex = 5;
            this.tbPreSlice.Text = "Pre-Slice GCode";
            this.tbPreSlice.UseVisualStyleBackColor = true;
            // 
            // cmdreloadpreslicegcode
            // 
            this.cmdreloadpreslicegcode.Location = new System.Drawing.Point(191, 308);
            this.cmdreloadpreslicegcode.Name = "cmdreloadpreslicegcode";
            this.cmdreloadpreslicegcode.Size = new System.Drawing.Size(188, 43);
            this.cmdreloadpreslicegcode.TabIndex = 5;
            this.cmdreloadpreslicegcode.Text = "Reload";
            this.cmdreloadpreslicegcode.UseVisualStyleBackColor = true;
            this.cmdreloadpreslicegcode.Click += new System.EventHandler(this.cmdreloadpreslicegcode_Click);
            // 
            // cmdsavepreslicegcode
            // 
            this.cmdsavepreslicegcode.Location = new System.Drawing.Point(3, 308);
            this.cmdsavepreslicegcode.Name = "cmdsavepreslicegcode";
            this.cmdsavepreslicegcode.Size = new System.Drawing.Size(181, 43);
            this.cmdsavepreslicegcode.TabIndex = 4;
            this.cmdsavepreslicegcode.Text = "Save";
            this.cmdsavepreslicegcode.UseVisualStyleBackColor = true;
            this.cmdsavepreslicegcode.Click += new System.EventHandler(this.cmdsavepreslicegcode_Click);
            // 
            // txtpreslicegcode
            // 
            this.txtpreslicegcode.Location = new System.Drawing.Point(3, 3);
            this.txtpreslicegcode.Multiline = true;
            this.txtpreslicegcode.Name = "txtpreslicegcode";
            this.txtpreslicegcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtpreslicegcode.Size = new System.Drawing.Size(722, 298);
            this.txtpreslicegcode.TabIndex = 3;
            // 
            // tbPreLift
            // 
            this.tbPreLift.Controls.Add(this.cmdReloadPrelift);
            this.tbPreLift.Controls.Add(this.cmdSavePrelift);
            this.tbPreLift.Controls.Add(this.txtpreliftgcode);
            this.tbPreLift.Location = new System.Drawing.Point(4, 25);
            this.tbPreLift.Name = "tbPreLift";
            this.tbPreLift.Padding = new System.Windows.Forms.Padding(3);
            this.tbPreLift.Size = new System.Drawing.Size(732, 445);
            this.tbPreLift.TabIndex = 1;
            this.tbPreLift.Text = "Pre-Lift GCode";
            this.tbPreLift.UseVisualStyleBackColor = true;
            // 
            // cmdReloadPrelift
            // 
            this.cmdReloadPrelift.Location = new System.Drawing.Point(191, 308);
            this.cmdReloadPrelift.Name = "cmdReloadPrelift";
            this.cmdReloadPrelift.Size = new System.Drawing.Size(188, 43);
            this.cmdReloadPrelift.TabIndex = 2;
            this.cmdReloadPrelift.Text = "Reload";
            this.cmdReloadPrelift.UseVisualStyleBackColor = true;
            this.cmdReloadPrelift.Click += new System.EventHandler(this.cmdReloadPrelift_Click);
            // 
            // cmdSavePrelift
            // 
            this.cmdSavePrelift.Location = new System.Drawing.Point(3, 308);
            this.cmdSavePrelift.Name = "cmdSavePrelift";
            this.cmdSavePrelift.Size = new System.Drawing.Size(181, 43);
            this.cmdSavePrelift.TabIndex = 1;
            this.cmdSavePrelift.Text = "Save";
            this.cmdSavePrelift.UseVisualStyleBackColor = true;
            this.cmdSavePrelift.Click += new System.EventHandler(this.cmdSavePrelift_Click);
            // 
            // txtpreliftgcode
            // 
            this.txtpreliftgcode.Location = new System.Drawing.Point(3, 3);
            this.txtpreliftgcode.Multiline = true;
            this.txtpreliftgcode.Name = "txtpreliftgcode";
            this.txtpreliftgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtpreliftgcode.Size = new System.Drawing.Size(722, 298);
            this.txtpreliftgcode.TabIndex = 0;
            // 
            // tbPostLift
            // 
            this.tbPostLift.Controls.Add(this.cmdpostliftgcode);
            this.tbPostLift.Controls.Add(this.cmdsavepostliftgcode);
            this.tbPostLift.Controls.Add(this.txtpostliftgcode);
            this.tbPostLift.Location = new System.Drawing.Point(4, 25);
            this.tbPostLift.Name = "tbPostLift";
            this.tbPostLift.Size = new System.Drawing.Size(732, 445);
            this.tbPostLift.TabIndex = 2;
            this.tbPostLift.Text = "Post-Lift GCode";
            this.tbPostLift.UseVisualStyleBackColor = true;
            // 
            // cmdpostliftgcode
            // 
            this.cmdpostliftgcode.Location = new System.Drawing.Point(191, 308);
            this.cmdpostliftgcode.Name = "cmdpostliftgcode";
            this.cmdpostliftgcode.Size = new System.Drawing.Size(188, 43);
            this.cmdpostliftgcode.TabIndex = 5;
            this.cmdpostliftgcode.Text = "Reload";
            this.cmdpostliftgcode.UseVisualStyleBackColor = true;
            this.cmdpostliftgcode.Click += new System.EventHandler(this.cmdpostliftgcode_Click);
            // 
            // cmdsavepostliftgcode
            // 
            this.cmdsavepostliftgcode.Location = new System.Drawing.Point(3, 308);
            this.cmdsavepostliftgcode.Name = "cmdsavepostliftgcode";
            this.cmdsavepostliftgcode.Size = new System.Drawing.Size(181, 43);
            this.cmdsavepostliftgcode.TabIndex = 4;
            this.cmdsavepostliftgcode.Text = "Save";
            this.cmdsavepostliftgcode.UseVisualStyleBackColor = true;
            this.cmdsavepostliftgcode.Click += new System.EventHandler(this.cmdsavepostliftgcode_Click);
            // 
            // txtpostliftgcode
            // 
            this.txtpostliftgcode.Location = new System.Drawing.Point(3, 3);
            this.txtpostliftgcode.Multiline = true;
            this.txtpostliftgcode.Name = "txtpostliftgcode";
            this.txtpostliftgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtpostliftgcode.Size = new System.Drawing.Size(722, 298);
            this.txtpostliftgcode.TabIndex = 3;
            // 
            // tbEnd
            // 
            this.tbEnd.Controls.Add(this.cmdendgcode);
            this.tbEnd.Controls.Add(this.txtsaveendgcode);
            this.tbEnd.Controls.Add(this.txtendgcode);
            this.tbEnd.Location = new System.Drawing.Point(4, 25);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(732, 445);
            this.tbEnd.TabIndex = 4;
            this.tbEnd.Text = "End GCode";
            this.tbEnd.UseVisualStyleBackColor = true;
            // 
            // cmdendgcode
            // 
            this.cmdendgcode.Location = new System.Drawing.Point(191, 308);
            this.cmdendgcode.Name = "cmdendgcode";
            this.cmdendgcode.Size = new System.Drawing.Size(188, 43);
            this.cmdendgcode.TabIndex = 5;
            this.cmdendgcode.Text = "Reload";
            this.cmdendgcode.UseVisualStyleBackColor = true;
            this.cmdendgcode.Click += new System.EventHandler(this.cmdendgcode_Click);
            // 
            // txtsaveendgcode
            // 
            this.txtsaveendgcode.Location = new System.Drawing.Point(3, 308);
            this.txtsaveendgcode.Name = "txtsaveendgcode";
            this.txtsaveendgcode.Size = new System.Drawing.Size(181, 43);
            this.txtsaveendgcode.TabIndex = 4;
            this.txtsaveendgcode.Text = "Save";
            this.txtsaveendgcode.UseVisualStyleBackColor = true;
            this.txtsaveendgcode.Click += new System.EventHandler(this.txtsaveendgcode_Click);
            // 
            // txtendgcode
            // 
            this.txtendgcode.Location = new System.Drawing.Point(3, 3);
            this.txtendgcode.Multiline = true;
            this.txtendgcode.Name = "txtendgcode";
            this.txtendgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtendgcode.Size = new System.Drawing.Size(722, 298);
            this.txtendgcode.TabIndex = 3;
            // 
            // frmSliceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 474);
            this.Controls.Add(this.tabOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSliceOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Slicing and Building Profile Options";
            this.Load += new System.EventHandler(this.frmSliceOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.tbOptions.ResumeLayout(false);
            this.tbOptions.PerformLayout();
            this.tbStart.ResumeLayout(false);
            this.tbStart.PerformLayout();
            this.tbPreSlice.ResumeLayout(false);
            this.tbPreSlice.PerformLayout();
            this.tbPreLift.ResumeLayout(false);
            this.tbPreLift.PerformLayout();
            this.tbPostLift.ResumeLayout(false);
            this.tbPostLift.PerformLayout();
            this.tbEnd.ResumeLayout(false);
            this.tbEnd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkExportSlices;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkgengcode;
        private System.Windows.Forms.Label lblLayerTime;
        private System.Windows.Forms.TextBox txtLayerTime;
        private System.Windows.Forms.TextBox txtZThick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkexportsvg;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstLayerTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtYOffset;
        private System.Windows.Forms.TextBox txtXOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBlankTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLiftDistance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBuildDirection;
        private System.Windows.Forms.TextBox txtnumbottom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tbOptions;
        private System.Windows.Forms.TabPage tbPreLift;
        private System.Windows.Forms.Button cmdReloadPrelift;
        private System.Windows.Forms.Button cmdSavePrelift;
        private System.Windows.Forms.TextBox txtpreliftgcode;
        private System.Windows.Forms.TabPage tbStart;
        private System.Windows.Forms.TabPage tbPreSlice;
        private System.Windows.Forms.TabPage tbPostLift;
        private System.Windows.Forms.TabPage tbEnd;
        private System.Windows.Forms.Button cmdreloadstartgcode;
        private System.Windows.Forms.Button cmdsavestartgcode;
        private System.Windows.Forms.TextBox txtstartgcode;
        private System.Windows.Forms.Button cmdreloadpreslicegcode;
        private System.Windows.Forms.Button cmdsavepreslicegcode;
        private System.Windows.Forms.TextBox txtpreslicegcode;
        private System.Windows.Forms.Button cmdpostliftgcode;
        private System.Windows.Forms.Button cmdsavepostliftgcode;
        private System.Windows.Forms.TextBox txtpostliftgcode;
        private System.Windows.Forms.Button cmdendgcode;
        private System.Windows.Forms.Button txtsaveendgcode;
        private System.Windows.Forms.TextBox txtendgcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSlideTilt;
    }
}