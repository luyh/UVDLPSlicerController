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
            this.lblLayerTime = new System.Windows.Forms.Label();
            this.txtLayerTime = new System.Windows.Forms.TextBox();
            this.txtZThick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.txtnumbottom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tbOptions = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkReflectY = new System.Windows.Forms.CheckBox();
            this.chkReflectX = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbsub = new System.Windows.Forms.RadioButton();
            this.rbzip = new System.Windows.Forms.RadioButton();
            this.chkmainliftgcode = new System.Windows.Forms.CheckBox();
            this.grpLift = new System.Windows.Forms.GroupBox();
            this.cmdAutoCalc = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtliftfeed = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtretractfeed = new System.Windows.Forms.TextBox();
            this.txtLiftDistance = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSlideTilt = new System.Windows.Forms.TextBox();
            this.cmbBuildDirection = new System.Windows.Forms.ComboBox();
            this.chkantialiasing = new System.Windows.Forms.CheckBox();
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
            this.tbMainlift = new System.Windows.Forms.TabPage();
            this.cmdreloadmainliftgcode = new System.Windows.Forms.Button();
            this.cmdsavemainliftgcode = new System.Windows.Forms.Button();
            this.txtmainliftgcode = new System.Windows.Forms.TextBox();
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
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpLift.SuspendLayout();
            this.tbStart.SuspendLayout();
            this.tbPreSlice.SuspendLayout();
            this.tbPreLift.SuspendLayout();
            this.tbMainlift.SuspendLayout();
            this.tbPostLift.SuspendLayout();
            this.tbEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkExportSlices
            // 
            this.chkExportSlices.AutoSize = true;
            this.chkExportSlices.Location = new System.Drawing.Point(28, 283);
            this.chkExportSlices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkExportSlices.Name = "chkExportSlices";
            this.chkExportSlices.Size = new System.Drawing.Size(153, 21);
            this.chkExportSlices.TabIndex = 21;
            this.chkExportSlices.Text = "Export Image Slices";
            this.chkExportSlices.UseVisualStyleBackColor = true;
            this.chkExportSlices.Visible = false;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(28, 406);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(129, 41);
            this.cmdOK.TabIndex = 24;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
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
            this.txtLayerTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLayerTime.Name = "txtLayerTime";
            this.txtLayerTime.Size = new System.Drawing.Size(56, 22);
            this.txtLayerTime.TabIndex = 26;
            this.txtLayerTime.Text = "5000";
            // 
            // txtZThick
            // 
            this.txtZThick.Location = new System.Drawing.Point(28, 41);
            this.txtZThick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtZThick.Name = "txtZThick";
            this.txtZThick.Size = new System.Drawing.Size(56, 22);
            this.txtZThick.TabIndex = 29;
            this.txtZThick.Text = ".05";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Slice Thickness (mm)";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(163, 406);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.txtFirstLayerTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.groupBox1.Location = new System.Drawing.Point(307, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(199, 110);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Pixel Offsets";
            // 
            // txtYOffset
            // 
            this.txtYOffset.Location = new System.Drawing.Point(72, 65);
            this.txtYOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtYOffset.Name = "txtYOffset";
            this.txtYOffset.Size = new System.Drawing.Size(68, 22);
            this.txtYOffset.TabIndex = 3;
            this.txtYOffset.Text = "0";
            // 
            // txtXOffset
            // 
            this.txtXOffset.Location = new System.Drawing.Point(72, 25);
            this.txtXOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "X Offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Lift and Sequence Time (ms)";
            // 
            // txtBlankTime
            // 
            this.txtBlankTime.Location = new System.Drawing.Point(9, 44);
            this.txtBlankTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBlankTime.Name = "txtBlankTime";
            this.txtBlankTime.Size = new System.Drawing.Size(56, 22);
            this.txtBlankTime.TabIndex = 35;
            this.txtBlankTime.Text = "5000";
            // 
            // txtnumbottom
            // 
            this.txtnumbottom.Location = new System.Drawing.Point(169, 133);
            this.txtnumbottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnumbottom.Name = "txtnumbottom";
            this.txtnumbottom.Size = new System.Drawing.Size(56, 22);
            this.txtnumbottom.TabIndex = 41;
            this.txtnumbottom.Text = "3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 135);
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
            this.tabOptions.Controls.Add(this.tbMainlift);
            this.tabOptions.Controls.Add(this.tbPostLift);
            this.tabOptions.Controls.Add(this.tbEnd);
            this.tabOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOptions.Location = new System.Drawing.Point(0, 0);
            this.tabOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(745, 484);
            this.tabOptions.TabIndex = 45;
            // 
            // tbOptions
            // 
            this.tbOptions.Controls.Add(this.groupBox3);
            this.tbOptions.Controls.Add(this.groupBox2);
            this.tbOptions.Controls.Add(this.chkmainliftgcode);
            this.tbOptions.Controls.Add(this.grpLift);
            this.tbOptions.Controls.Add(this.chkantialiasing);
            this.tbOptions.Controls.Add(this.label1);
            this.tbOptions.Controls.Add(this.chkExportSlices);
            this.tbOptions.Controls.Add(this.cmdOK);
            this.tbOptions.Controls.Add(this.label8);
            this.tbOptions.Controls.Add(this.txtnumbottom);
            this.tbOptions.Controls.Add(this.txtLayerTime);
            this.tbOptions.Controls.Add(this.lblLayerTime);
            this.tbOptions.Controls.Add(this.txtZThick);
            this.tbOptions.Controls.Add(this.cmdCancel);
            this.tbOptions.Controls.Add(this.txtFirstLayerTime);
            this.tbOptions.Controls.Add(this.label2);
            this.tbOptions.Controls.Add(this.groupBox1);
            this.tbOptions.Location = new System.Drawing.Point(4, 25);
            this.tbOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbOptions.Name = "tbOptions";
            this.tbOptions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbOptions.Size = new System.Drawing.Size(737, 455);
            this.tbOptions.TabIndex = 0;
            this.tbOptions.Text = "Options";
            this.tbOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkReflectY);
            this.groupBox3.Controls.Add(this.chkReflectX);
            this.groupBox3.Location = new System.Drawing.Point(512, 21);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(190, 110);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Image Reflection";
            // 
            // chkReflectY
            // 
            this.chkReflectY.AutoSize = true;
            this.chkReflectY.Location = new System.Drawing.Point(6, 64);
            this.chkReflectY.Name = "chkReflectY";
            this.chkReflectY.Size = new System.Drawing.Size(87, 21);
            this.chkReflectY.TabIndex = 1;
            this.chkReflectY.Text = "Reflect Y";
            this.chkReflectY.UseVisualStyleBackColor = true;
            // 
            // chkReflectX
            // 
            this.chkReflectX.AutoSize = true;
            this.chkReflectX.Location = new System.Drawing.Point(6, 22);
            this.chkReflectX.Name = "chkReflectX";
            this.chkReflectX.Size = new System.Drawing.Size(87, 21);
            this.chkReflectX.TabIndex = 0;
            this.chkReflectX.Text = "Reflect X";
            this.chkReflectX.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbsub);
            this.groupBox2.Controls.Add(this.rbzip);
            this.groupBox2.Location = new System.Drawing.Point(28, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 81);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Slice Export Options";
            // 
            // rbsub
            // 
            this.rbsub.AutoSize = true;
            this.rbsub.Location = new System.Drawing.Point(7, 49);
            this.rbsub.Name = "rbsub";
            this.rbsub.Size = new System.Drawing.Size(109, 21);
            this.rbsub.TabIndex = 1;
            this.rbsub.TabStop = true;
            this.rbsub.Text = "Subdirectory";
            this.rbsub.UseVisualStyleBackColor = true;
            // 
            // rbzip
            // 
            this.rbzip.AutoSize = true;
            this.rbzip.Location = new System.Drawing.Point(7, 22);
            this.rbzip.Name = "rbzip";
            this.rbzip.Size = new System.Drawing.Size(75, 21);
            this.rbzip.TabIndex = 0;
            this.rbzip.TabStop = true;
            this.rbzip.Text = "Zip File";
            this.rbzip.UseVisualStyleBackColor = true;
            // 
            // chkmainliftgcode
            // 
            this.chkmainliftgcode.AutoSize = true;
            this.chkmainliftgcode.Location = new System.Drawing.Point(307, 152);
            this.chkmainliftgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkmainliftgcode.Name = "chkmainliftgcode";
            this.chkmainliftgcode.Size = new System.Drawing.Size(346, 21);
            this.chkmainliftgcode.TabIndex = 49;
            this.chkmainliftgcode.Text = "Use Main-Lift GCode instead of Lift and Sequence";
            this.chkmainliftgcode.UseVisualStyleBackColor = true;
            this.chkmainliftgcode.CheckedChanged += new System.EventHandler(this.chkmainliftgcode_CheckedChanged);
            // 
            // grpLift
            // 
            this.grpLift.Controls.Add(this.cmdAutoCalc);
            this.grpLift.Controls.Add(this.label14);
            this.grpLift.Controls.Add(this.txtliftfeed);
            this.grpLift.Controls.Add(this.label13);
            this.grpLift.Controls.Add(this.txtretractfeed);
            this.grpLift.Controls.Add(this.txtLiftDistance);
            this.grpLift.Controls.Add(this.label10);
            this.grpLift.Controls.Add(this.label11);
            this.grpLift.Controls.Add(this.label12);
            this.grpLift.Controls.Add(this.txtSlideTilt);
            this.grpLift.Controls.Add(this.cmbBuildDirection);
            this.grpLift.Controls.Add(this.label5);
            this.grpLift.Controls.Add(this.txtBlankTime);
            this.grpLift.Location = new System.Drawing.Point(307, 177);
            this.grpLift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpLift.Name = "grpLift";
            this.grpLift.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpLift.Size = new System.Drawing.Size(395, 226);
            this.grpLift.TabIndex = 46;
            this.grpLift.TabStop = false;
            this.grpLift.Text = "Lift and Sequence";
            // 
            // cmdAutoCalc
            // 
            this.cmdAutoCalc.Location = new System.Drawing.Point(71, 43);
            this.cmdAutoCalc.Name = "cmdAutoCalc";
            this.cmdAutoCalc.Size = new System.Drawing.Size(104, 23);
            this.cmdAutoCalc.TabIndex = 49;
            this.cmdAutoCalc.Text = "Auto Calc";
            this.cmdAutoCalc.UseVisualStyleBackColor = true;
            this.cmdAutoCalc.Click += new System.EventHandler(this.cmdAutoCalc_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 17);
            this.label14.TabIndex = 48;
            this.label14.Text = "Z Lift Speed (mm/m)";
            // 
            // txtliftfeed
            // 
            this.txtliftfeed.Location = new System.Drawing.Point(9, 143);
            this.txtliftfeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtliftfeed.Name = "txtliftfeed";
            this.txtliftfeed.Size = new System.Drawing.Size(100, 22);
            this.txtliftfeed.TabIndex = 47;
            this.txtliftfeed.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(143, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(186, 17);
            this.label13.TabIndex = 46;
            this.label13.Text = "Z Lift Retract Speed (mm/m)";
            // 
            // txtretractfeed
            // 
            this.txtretractfeed.Location = new System.Drawing.Point(144, 143);
            this.txtretractfeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtretractfeed.Name = "txtretractfeed";
            this.txtretractfeed.Size = new System.Drawing.Size(100, 22);
            this.txtretractfeed.TabIndex = 45;
            this.txtretractfeed.Text = "0";
            // 
            // txtLiftDistance
            // 
            this.txtLiftDistance.Location = new System.Drawing.Point(9, 93);
            this.txtLiftDistance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLiftDistance.Name = "txtLiftDistance";
            this.txtLiftDistance.Size = new System.Drawing.Size(100, 22);
            this.txtLiftDistance.TabIndex = 37;
            this.txtLiftDistance.Text = "5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "Z Lift Distance (mm)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 17);
            this.label11.TabIndex = 44;
            this.label11.Text = "Slide / Tilt Value";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(141, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 17);
            this.label12.TabIndex = 39;
            this.label12.Text = "Build Direction";
            // 
            // txtSlideTilt
            // 
            this.txtSlideTilt.Location = new System.Drawing.Point(9, 191);
            this.txtSlideTilt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSlideTilt.Name = "txtSlideTilt";
            this.txtSlideTilt.Size = new System.Drawing.Size(100, 22);
            this.txtSlideTilt.TabIndex = 43;
            this.txtSlideTilt.Text = "0";
            // 
            // cmbBuildDirection
            // 
            this.cmbBuildDirection.FormattingEnabled = true;
            this.cmbBuildDirection.Location = new System.Drawing.Point(144, 93);
            this.cmbBuildDirection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBuildDirection.Name = "cmbBuildDirection";
            this.cmbBuildDirection.Size = new System.Drawing.Size(121, 24);
            this.cmbBuildDirection.TabIndex = 40;
            // 
            // chkantialiasing
            // 
            this.chkantialiasing.AutoSize = true;
            this.chkantialiasing.Location = new System.Drawing.Point(28, 250);
            this.chkantialiasing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkantialiasing.Name = "chkantialiasing";
            this.chkantialiasing.Size = new System.Drawing.Size(156, 21);
            this.chkantialiasing.TabIndex = 45;
            this.chkantialiasing.Text = "Enable Anti-Aliasing";
            this.chkantialiasing.UseVisualStyleBackColor = true;
            // 
            // tbStart
            // 
            this.tbStart.Controls.Add(this.cmdreloadstartgcode);
            this.tbStart.Controls.Add(this.cmdsavestartgcode);
            this.tbStart.Controls.Add(this.txtstartgcode);
            this.tbStart.Location = new System.Drawing.Point(4, 25);
            this.tbStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(737, 455);
            this.tbStart.TabIndex = 3;
            this.tbStart.Text = "Start GCode";
            this.tbStart.UseVisualStyleBackColor = true;
            // 
            // cmdreloadstartgcode
            // 
            this.cmdreloadstartgcode.Location = new System.Drawing.Point(191, 308);
            this.cmdreloadstartgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.cmdsavestartgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdsavestartgcode.Name = "cmdsavestartgcode";
            this.cmdsavestartgcode.Size = new System.Drawing.Size(181, 43);
            this.cmdsavestartgcode.TabIndex = 4;
            this.cmdsavestartgcode.Text = "Save";
            this.cmdsavestartgcode.UseVisualStyleBackColor = true;
            this.cmdsavestartgcode.Click += new System.EventHandler(this.cmdsavestartgcode_Click);
            // 
            // txtstartgcode
            // 
            this.txtstartgcode.Location = new System.Drawing.Point(3, 2);
            this.txtstartgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtstartgcode.Multiline = true;
            this.txtstartgcode.Name = "txtstartgcode";
            this.txtstartgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtstartgcode.Size = new System.Drawing.Size(721, 298);
            this.txtstartgcode.TabIndex = 3;
            // 
            // tbPreSlice
            // 
            this.tbPreSlice.Controls.Add(this.cmdreloadpreslicegcode);
            this.tbPreSlice.Controls.Add(this.cmdsavepreslicegcode);
            this.tbPreSlice.Controls.Add(this.txtpreslicegcode);
            this.tbPreSlice.Location = new System.Drawing.Point(4, 25);
            this.tbPreSlice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPreSlice.Name = "tbPreSlice";
            this.tbPreSlice.Size = new System.Drawing.Size(737, 455);
            this.tbPreSlice.TabIndex = 5;
            this.tbPreSlice.Text = "Pre-Slice GCode";
            this.tbPreSlice.UseVisualStyleBackColor = true;
            // 
            // cmdreloadpreslicegcode
            // 
            this.cmdreloadpreslicegcode.Location = new System.Drawing.Point(191, 308);
            this.cmdreloadpreslicegcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.cmdsavepreslicegcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdsavepreslicegcode.Name = "cmdsavepreslicegcode";
            this.cmdsavepreslicegcode.Size = new System.Drawing.Size(181, 43);
            this.cmdsavepreslicegcode.TabIndex = 4;
            this.cmdsavepreslicegcode.Text = "Save";
            this.cmdsavepreslicegcode.UseVisualStyleBackColor = true;
            this.cmdsavepreslicegcode.Click += new System.EventHandler(this.cmdsavepreslicegcode_Click);
            // 
            // txtpreslicegcode
            // 
            this.txtpreslicegcode.Location = new System.Drawing.Point(3, 2);
            this.txtpreslicegcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpreslicegcode.Multiline = true;
            this.txtpreslicegcode.Name = "txtpreslicegcode";
            this.txtpreslicegcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtpreslicegcode.Size = new System.Drawing.Size(721, 298);
            this.txtpreslicegcode.TabIndex = 3;
            // 
            // tbPreLift
            // 
            this.tbPreLift.Controls.Add(this.cmdReloadPrelift);
            this.tbPreLift.Controls.Add(this.cmdSavePrelift);
            this.tbPreLift.Controls.Add(this.txtpreliftgcode);
            this.tbPreLift.Location = new System.Drawing.Point(4, 25);
            this.tbPreLift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPreLift.Name = "tbPreLift";
            this.tbPreLift.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPreLift.Size = new System.Drawing.Size(737, 455);
            this.tbPreLift.TabIndex = 1;
            this.tbPreLift.Text = "Pre-Lift GCode";
            this.tbPreLift.UseVisualStyleBackColor = true;
            // 
            // cmdReloadPrelift
            // 
            this.cmdReloadPrelift.Location = new System.Drawing.Point(191, 308);
            this.cmdReloadPrelift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.cmdSavePrelift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSavePrelift.Name = "cmdSavePrelift";
            this.cmdSavePrelift.Size = new System.Drawing.Size(181, 43);
            this.cmdSavePrelift.TabIndex = 1;
            this.cmdSavePrelift.Text = "Save";
            this.cmdSavePrelift.UseVisualStyleBackColor = true;
            this.cmdSavePrelift.Click += new System.EventHandler(this.cmdSavePrelift_Click);
            // 
            // txtpreliftgcode
            // 
            this.txtpreliftgcode.Location = new System.Drawing.Point(3, 2);
            this.txtpreliftgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpreliftgcode.Multiline = true;
            this.txtpreliftgcode.Name = "txtpreliftgcode";
            this.txtpreliftgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtpreliftgcode.Size = new System.Drawing.Size(721, 298);
            this.txtpreliftgcode.TabIndex = 0;
            // 
            // tbMainlift
            // 
            this.tbMainlift.Controls.Add(this.cmdreloadmainliftgcode);
            this.tbMainlift.Controls.Add(this.cmdsavemainliftgcode);
            this.tbMainlift.Controls.Add(this.txtmainliftgcode);
            this.tbMainlift.Location = new System.Drawing.Point(4, 25);
            this.tbMainlift.Margin = new System.Windows.Forms.Padding(4);
            this.tbMainlift.Name = "tbMainlift";
            this.tbMainlift.Padding = new System.Windows.Forms.Padding(4);
            this.tbMainlift.Size = new System.Drawing.Size(737, 455);
            this.tbMainlift.TabIndex = 6;
            this.tbMainlift.Text = "Main-Lift GCode";
            this.tbMainlift.UseVisualStyleBackColor = true;
            // 
            // cmdreloadmainliftgcode
            // 
            this.cmdreloadmainliftgcode.Location = new System.Drawing.Point(191, 308);
            this.cmdreloadmainliftgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdreloadmainliftgcode.Name = "cmdreloadmainliftgcode";
            this.cmdreloadmainliftgcode.Size = new System.Drawing.Size(188, 43);
            this.cmdreloadmainliftgcode.TabIndex = 7;
            this.cmdreloadmainliftgcode.Text = "Reload";
            this.cmdreloadmainliftgcode.UseVisualStyleBackColor = true;
            this.cmdreloadmainliftgcode.Click += new System.EventHandler(this.cmdreloadmainliftgcode_Click);
            // 
            // cmdsavemainliftgcode
            // 
            this.cmdsavemainliftgcode.Location = new System.Drawing.Point(3, 308);
            this.cmdsavemainliftgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdsavemainliftgcode.Name = "cmdsavemainliftgcode";
            this.cmdsavemainliftgcode.Size = new System.Drawing.Size(181, 43);
            this.cmdsavemainliftgcode.TabIndex = 6;
            this.cmdsavemainliftgcode.Text = "Save";
            this.cmdsavemainliftgcode.UseVisualStyleBackColor = true;
            this.cmdsavemainliftgcode.Click += new System.EventHandler(this.cmdsavemainliftgcode_Click);
            // 
            // txtmainliftgcode
            // 
            this.txtmainliftgcode.Location = new System.Drawing.Point(3, 2);
            this.txtmainliftgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtmainliftgcode.Multiline = true;
            this.txtmainliftgcode.Name = "txtmainliftgcode";
            this.txtmainliftgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtmainliftgcode.Size = new System.Drawing.Size(721, 298);
            this.txtmainliftgcode.TabIndex = 4;
            // 
            // tbPostLift
            // 
            this.tbPostLift.Controls.Add(this.cmdpostliftgcode);
            this.tbPostLift.Controls.Add(this.cmdsavepostliftgcode);
            this.tbPostLift.Controls.Add(this.txtpostliftgcode);
            this.tbPostLift.Location = new System.Drawing.Point(4, 25);
            this.tbPostLift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPostLift.Name = "tbPostLift";
            this.tbPostLift.Size = new System.Drawing.Size(737, 455);
            this.tbPostLift.TabIndex = 2;
            this.tbPostLift.Text = "Post-Lift GCode";
            this.tbPostLift.UseVisualStyleBackColor = true;
            // 
            // cmdpostliftgcode
            // 
            this.cmdpostliftgcode.Location = new System.Drawing.Point(191, 308);
            this.cmdpostliftgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.cmdsavepostliftgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdsavepostliftgcode.Name = "cmdsavepostliftgcode";
            this.cmdsavepostliftgcode.Size = new System.Drawing.Size(181, 43);
            this.cmdsavepostliftgcode.TabIndex = 4;
            this.cmdsavepostliftgcode.Text = "Save";
            this.cmdsavepostliftgcode.UseVisualStyleBackColor = true;
            this.cmdsavepostliftgcode.Click += new System.EventHandler(this.cmdsavepostliftgcode_Click);
            // 
            // txtpostliftgcode
            // 
            this.txtpostliftgcode.Location = new System.Drawing.Point(3, 2);
            this.txtpostliftgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpostliftgcode.Multiline = true;
            this.txtpostliftgcode.Name = "txtpostliftgcode";
            this.txtpostliftgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtpostliftgcode.Size = new System.Drawing.Size(721, 298);
            this.txtpostliftgcode.TabIndex = 3;
            // 
            // tbEnd
            // 
            this.tbEnd.Controls.Add(this.cmdendgcode);
            this.tbEnd.Controls.Add(this.txtsaveendgcode);
            this.tbEnd.Controls.Add(this.txtendgcode);
            this.tbEnd.Location = new System.Drawing.Point(4, 25);
            this.tbEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(737, 455);
            this.tbEnd.TabIndex = 4;
            this.tbEnd.Text = "End GCode";
            this.tbEnd.UseVisualStyleBackColor = true;
            // 
            // cmdendgcode
            // 
            this.cmdendgcode.Location = new System.Drawing.Point(191, 308);
            this.cmdendgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.txtsaveendgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsaveendgcode.Name = "txtsaveendgcode";
            this.txtsaveendgcode.Size = new System.Drawing.Size(181, 43);
            this.txtsaveendgcode.TabIndex = 4;
            this.txtsaveendgcode.Text = "Save";
            this.txtsaveendgcode.UseVisualStyleBackColor = true;
            this.txtsaveendgcode.Click += new System.EventHandler(this.txtsaveendgcode_Click);
            // 
            // txtendgcode
            // 
            this.txtendgcode.Location = new System.Drawing.Point(3, 2);
            this.txtendgcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtendgcode.Multiline = true;
            this.txtendgcode.Name = "txtendgcode";
            this.txtendgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtendgcode.Size = new System.Drawing.Size(721, 298);
            this.txtendgcode.TabIndex = 3;
            // 
            // frmSliceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 484);
            this.Controls.Add(this.tabOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSliceOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UV DLP Slicing and Building Profile Options";
            this.Load += new System.EventHandler(this.frmSliceOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.tbOptions.ResumeLayout(false);
            this.tbOptions.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpLift.ResumeLayout(false);
            this.grpLift.PerformLayout();
            this.tbStart.ResumeLayout(false);
            this.tbStart.PerformLayout();
            this.tbPreSlice.ResumeLayout(false);
            this.tbPreSlice.PerformLayout();
            this.tbPreLift.ResumeLayout(false);
            this.tbPreLift.PerformLayout();
            this.tbMainlift.ResumeLayout(false);
            this.tbMainlift.PerformLayout();
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
        private System.Windows.Forms.Label lblLayerTime;
        private System.Windows.Forms.TextBox txtLayerTime;
        private System.Windows.Forms.TextBox txtZThick;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.CheckBox chkantialiasing;
        private System.Windows.Forms.GroupBox grpLift;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtliftfeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtretractfeed;
        private System.Windows.Forms.TextBox txtLiftDistance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSlideTilt;
        private System.Windows.Forms.ComboBox cmbBuildDirection;
        private System.Windows.Forms.TabPage tbMainlift;
        private System.Windows.Forms.TextBox txtmainliftgcode;
        private System.Windows.Forms.Button cmdreloadmainliftgcode;
        private System.Windows.Forms.Button cmdsavemainliftgcode;
        private System.Windows.Forms.CheckBox chkmainliftgcode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbsub;
        private System.Windows.Forms.RadioButton rbzip;
        private System.Windows.Forms.Button cmdAutoCalc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkReflectY;
        private System.Windows.Forms.CheckBox chkReflectX;
    }
}