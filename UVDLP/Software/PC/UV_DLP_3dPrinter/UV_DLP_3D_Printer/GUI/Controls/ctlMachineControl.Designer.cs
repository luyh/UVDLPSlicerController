namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctlMachineControl
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtRateZ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRateXY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpHoming = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmdHomeAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.cmdYHome = new System.Windows.Forms.Button();
            this.cmdXHome = new System.Windows.Forms.Button();
            this.cmdZHome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdMotorsOn = new System.Windows.Forms.Button();
            this.cmdMotorsOff = new System.Windows.Forms.Button();
            this.grpExtrudeControls = new System.Windows.Forms.GroupBox();
            this.udTool0Rate = new System.Windows.Forms.NumericUpDown();
            this.udext0len = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.cmdExtrude1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdReverse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdistXY = new System.Windows.Forms.TextBox();
            this.cmdYDown = new System.Windows.Forms.Button();
            this.cmdYUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdXDown = new System.Windows.Forms.Button();
            this.cmdXUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdist = new System.Windows.Forms.TextBox();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdUp = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.txtSent = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdSendGCode = new System.Windows.Forms.Button();
            this.txtGCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.udTool1Rate = new System.Windows.Forms.NumericUpDown();
            this.udext1len = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.cmdExtrude2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdReverse2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.grpHoming.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpExtrudeControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTool0Rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udext0len)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTool1Rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udext1len)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 49;
            this.label9.Text = "mm/min";
            // 
            // txtRateZ
            // 
            this.txtRateZ.Location = new System.Drawing.Point(8, 97);
            this.txtRateZ.Name = "txtRateZ";
            this.txtRateZ.Size = new System.Drawing.Size(66, 22);
            this.txtRateZ.TabIndex = 48;
            this.txtRateZ.Text = "100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 17);
            this.label10.TabIndex = 47;
            this.label10.Text = "Z Rate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 46;
            this.label8.Text = "mm/min";
            // 
            // txtRateXY
            // 
            this.txtRateXY.Location = new System.Drawing.Point(8, 39);
            this.txtRateXY.Name = "txtRateXY";
            this.txtRateXY.Size = new System.Drawing.Size(66, 22);
            this.txtRateXY.TabIndex = 45;
            this.txtRateXY.Text = "3000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 44;
            this.label7.Text = "X/Y Rate";
            // 
            // grpHoming
            // 
            this.grpHoming.Controls.Add(this.label15);
            this.grpHoming.Controls.Add(this.cmdHomeAll);
            this.grpHoming.Controls.Add(this.label5);
            this.grpHoming.Controls.Add(this.label4);
            this.grpHoming.Controls.Add(this.lblX);
            this.grpHoming.Controls.Add(this.cmdYHome);
            this.grpHoming.Controls.Add(this.cmdXHome);
            this.grpHoming.Controls.Add(this.cmdZHome);
            this.grpHoming.Location = new System.Drawing.Point(249, 249);
            this.grpHoming.Name = "grpHoming";
            this.grpHoming.Size = new System.Drawing.Size(258, 127);
            this.grpHoming.TabIndex = 43;
            this.grpHoming.TabStop = false;
            this.grpHoming.Text = "Homing";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(196, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 23);
            this.label15.TabIndex = 23;
            this.label15.Text = "All";
            // 
            // cmdHomeAll
            // 
            this.cmdHomeAll.Image = global::UV_DLP_3D_Printer.Properties.Resources.rounded_blue_home_button_4805;
            this.cmdHomeAll.Location = new System.Drawing.Point(194, 32);
            this.cmdHomeAll.Name = "cmdHomeAll";
            this.cmdHomeAll.Size = new System.Drawing.Size(48, 52);
            this.cmdHomeAll.TabIndex = 22;
            this.cmdHomeAll.UseVisualStyleBackColor = true;
            this.cmdHomeAll.Click += new System.EventHandler(this.cmdHomeAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(151, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(24, 91);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(22, 23);
            this.lblX.TabIndex = 19;
            this.lblX.Text = "X";
            // 
            // cmdYHome
            // 
            this.cmdYHome.Image = global::UV_DLP_3D_Printer.Properties.Resources.rounded_blue_home_button_4805;
            this.cmdYHome.Location = new System.Drawing.Point(73, 32);
            this.cmdYHome.Name = "cmdYHome";
            this.cmdYHome.Size = new System.Drawing.Size(48, 52);
            this.cmdYHome.TabIndex = 18;
            this.cmdYHome.UseVisualStyleBackColor = true;
            this.cmdYHome.Click += new System.EventHandler(this.cmdYHome_Click);
            // 
            // cmdXHome
            // 
            this.cmdXHome.Image = global::UV_DLP_3D_Printer.Properties.Resources.rounded_blue_home_button_4805;
            this.cmdXHome.Location = new System.Drawing.Point(11, 32);
            this.cmdXHome.Name = "cmdXHome";
            this.cmdXHome.Size = new System.Drawing.Size(48, 52);
            this.cmdXHome.TabIndex = 17;
            this.cmdXHome.UseVisualStyleBackColor = true;
            this.cmdXHome.Click += new System.EventHandler(this.cmdXHome_Click);
            // 
            // cmdZHome
            // 
            this.cmdZHome.Image = global::UV_DLP_3D_Printer.Properties.Resources.rounded_blue_home_button_4805;
            this.cmdZHome.Location = new System.Drawing.Point(134, 32);
            this.cmdZHome.Name = "cmdZHome";
            this.cmdZHome.Size = new System.Drawing.Size(48, 52);
            this.cmdZHome.TabIndex = 16;
            this.cmdZHome.UseVisualStyleBackColor = true;
            this.cmdZHome.Click += new System.EventHandler(this.cmdZHome_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdMotorsOn);
            this.groupBox1.Controls.Add(this.cmdMotorsOff);
            this.groupBox1.Location = new System.Drawing.Point(369, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 78);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motor Control";
            // 
            // cmdMotorsOn
            // 
            this.cmdMotorsOn.Location = new System.Drawing.Point(6, 21);
            this.cmdMotorsOn.Name = "cmdMotorsOn";
            this.cmdMotorsOn.Size = new System.Drawing.Size(75, 44);
            this.cmdMotorsOn.TabIndex = 17;
            this.cmdMotorsOn.Text = "Enable Motors ";
            this.cmdMotorsOn.UseVisualStyleBackColor = true;
            this.cmdMotorsOn.Click += new System.EventHandler(this.cmdMotorsOn_Click);
            // 
            // cmdMotorsOff
            // 
            this.cmdMotorsOff.Location = new System.Drawing.Point(87, 21);
            this.cmdMotorsOff.Name = "cmdMotorsOff";
            this.cmdMotorsOff.Size = new System.Drawing.Size(75, 44);
            this.cmdMotorsOff.TabIndex = 18;
            this.cmdMotorsOff.Text = "Disable Motors";
            this.cmdMotorsOff.UseVisualStyleBackColor = true;
            this.cmdMotorsOff.Click += new System.EventHandler(this.cmdMotorsOff_Click);
            // 
            // grpExtrudeControls
            // 
            this.grpExtrudeControls.Controls.Add(this.udTool0Rate);
            this.grpExtrudeControls.Controls.Add(this.udext0len);
            this.grpExtrudeControls.Controls.Add(this.label16);
            this.grpExtrudeControls.Controls.Add(this.cmdExtrude1);
            this.grpExtrudeControls.Controls.Add(this.label2);
            this.grpExtrudeControls.Controls.Add(this.cmdReverse);
            this.grpExtrudeControls.Location = new System.Drawing.Point(14, 249);
            this.grpExtrudeControls.Name = "grpExtrudeControls";
            this.grpExtrudeControls.Size = new System.Drawing.Size(229, 127);
            this.grpExtrudeControls.TabIndex = 41;
            this.grpExtrudeControls.TabStop = false;
            this.grpExtrudeControls.Text = "Toolhead 0 (Extruder)";
            // 
            // udTool0Rate
            // 
            this.udTool0Rate.Location = new System.Drawing.Point(87, 80);
            this.udTool0Rate.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.udTool0Rate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTool0Rate.Name = "udTool0Rate";
            this.udTool0Rate.Size = new System.Drawing.Size(71, 22);
            this.udTool0Rate.TabIndex = 24;
            this.udTool0Rate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // udext0len
            // 
            this.udext0len.Location = new System.Drawing.Point(87, 33);
            this.udext0len.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udext0len.Name = "udext0len";
            this.udext0len.Size = new System.Drawing.Size(71, 22);
            this.udext0len.TabIndex = 23;
            this.udext0len.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(167, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 17);
            this.label16.TabIndex = 22;
            this.label16.Text = "mm/min";
            // 
            // cmdExtrude1
            // 
            this.cmdExtrude1.Location = new System.Drawing.Point(6, 21);
            this.cmdExtrude1.Name = "cmdExtrude1";
            this.cmdExtrude1.Size = new System.Drawing.Size(75, 44);
            this.cmdExtrude1.TabIndex = 14;
            this.cmdExtrude1.Text = "Extrude";
            this.cmdExtrude1.UseVisualStyleBackColor = true;
            this.cmdExtrude1.Click += new System.EventHandler(this.cmdExtrude1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "mm";
            // 
            // cmdReverse
            // 
            this.cmdReverse.Location = new System.Drawing.Point(6, 71);
            this.cmdReverse.Name = "cmdReverse";
            this.cmdReverse.Size = new System.Drawing.Size(75, 44);
            this.cmdReverse.TabIndex = 15;
            this.cmdReverse.Text = "Reverse";
            this.cmdReverse.UseVisualStyleBackColor = true;
            this.cmdReverse.Click += new System.EventHandler(this.cmdReverse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 40;
            this.label6.Text = "mm";
            // 
            // txtdistXY
            // 
            this.txtdistXY.Location = new System.Drawing.Point(85, 123);
            this.txtdistXY.Name = "txtdistXY";
            this.txtdistXY.Size = new System.Drawing.Size(39, 22);
            this.txtdistXY.TabIndex = 39;
            this.txtdistXY.Text = "10";
            this.txtdistXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdYDown
            // 
            this.cmdYDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Down1Blue;
            this.cmdYDown.Location = new System.Drawing.Point(81, 170);
            this.cmdYDown.Name = "cmdYDown";
            this.cmdYDown.Size = new System.Drawing.Size(72, 72);
            this.cmdYDown.TabIndex = 38;
            this.cmdYDown.UseVisualStyleBackColor = true;
            this.cmdYDown.Click += new System.EventHandler(this.cmdYDown_Click);
            // 
            // cmdYUp
            // 
            this.cmdYUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Up1Blue;
            this.cmdYUp.Location = new System.Drawing.Point(81, 28);
            this.cmdYUp.Name = "cmdYUp";
            this.cmdYUp.Size = new System.Drawing.Size(72, 72);
            this.cmdYUp.TabIndex = 37;
            this.cmdYUp.UseVisualStyleBackColor = true;
            this.cmdYUp.Click += new System.EventHandler(this.cmdYUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "ZAxis";
            // 
            // cmdXDown
            // 
            this.cmdXDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Left1Blue;
            this.cmdXDown.Location = new System.Drawing.Point(9, 99);
            this.cmdXDown.Name = "cmdXDown";
            this.cmdXDown.Size = new System.Drawing.Size(72, 72);
            this.cmdXDown.TabIndex = 35;
            this.cmdXDown.UseVisualStyleBackColor = true;
            this.cmdXDown.Click += new System.EventHandler(this.cmdXDown_Click);
            // 
            // cmdXUp
            // 
            this.cmdXUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Right1Blue;
            this.cmdXUp.Location = new System.Drawing.Point(153, 99);
            this.cmdXUp.Name = "cmdXUp";
            this.cmdXUp.Size = new System.Drawing.Size(72, 72);
            this.cmdXUp.TabIndex = 34;
            this.cmdXUp.UseVisualStyleBackColor = true;
            this.cmdXUp.Click += new System.EventHandler(this.cmdXUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "mm";
            // 
            // txtdist
            // 
            this.txtdist.Location = new System.Drawing.Point(249, 125);
            this.txtdist.Name = "txtdist";
            this.txtdist.Size = new System.Drawing.Size(72, 22);
            this.txtdist.TabIndex = 32;
            this.txtdist.Text = "10";
            this.txtdist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdDown
            // 
            this.cmdDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Down1Blue;
            this.cmdDown.Location = new System.Drawing.Point(249, 172);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(72, 72);
            this.cmdDown.TabIndex = 31;
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdUp
            // 
            this.cmdUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Up1Blue;
            this.cmdUp.Location = new System.Drawing.Point(249, 28);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(72, 72);
            this.cmdUp.TabIndex = 30;
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(696, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 17);
            this.label11.TabIndex = 56;
            this.label11.Text = "Received:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(696, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 17);
            this.label12.TabIndex = 55;
            this.label12.Text = "Sent:";
            // 
            // txtReceived
            // 
            this.txtReceived.BackColor = System.Drawing.Color.White;
            this.txtReceived.Location = new System.Drawing.Point(699, 222);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ReadOnly = true;
            this.txtReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceived.Size = new System.Drawing.Size(331, 225);
            this.txtReceived.TabIndex = 54;
            // 
            // txtSent
            // 
            this.txtSent.BackColor = System.Drawing.Color.White;
            this.txtSent.Location = new System.Drawing.Point(699, 86);
            this.txtSent.Multiline = true;
            this.txtSent.Name = "txtSent";
            this.txtSent.ReadOnly = true;
            this.txtSent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSent.Size = new System.Drawing.Size(319, 96);
            this.txtSent.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(696, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 17);
            this.label13.TabIndex = 52;
            this.label13.Text = "GCode to send";
            // 
            // cmdSendGCode
            // 
            this.cmdSendGCode.Location = new System.Drawing.Point(946, 38);
            this.cmdSendGCode.Name = "cmdSendGCode";
            this.cmdSendGCode.Size = new System.Drawing.Size(75, 23);
            this.cmdSendGCode.TabIndex = 51;
            this.cmdSendGCode.Text = "Send!";
            this.cmdSendGCode.UseVisualStyleBackColor = true;
            this.cmdSendGCode.Click += new System.EventHandler(this.cmdSendGCode_Click);
            // 
            // txtGCode
            // 
            this.txtGCode.Location = new System.Drawing.Point(699, 38);
            this.txtGCode.Name = "txtGCode";
            this.txtGCode.Size = new System.Drawing.Size(229, 22);
            this.txtGCode.TabIndex = 50;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.udTool1Rate);
            this.groupBox2.Controls.Add(this.udext1len);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.cmdExtrude2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cmdReverse2);
            this.groupBox2.Location = new System.Drawing.Point(14, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 127);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Toolhead 1 (Extruder)";
            // 
            // udTool1Rate
            // 
            this.udTool1Rate.Location = new System.Drawing.Point(87, 81);
            this.udTool1Rate.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.udTool1Rate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTool1Rate.Name = "udTool1Rate";
            this.udTool1Rate.Size = new System.Drawing.Size(71, 22);
            this.udTool1Rate.TabIndex = 25;
            this.udTool1Rate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // udext1len
            // 
            this.udext1len.Location = new System.Drawing.Point(87, 33);
            this.udext1len.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udext1len.Name = "udext1len";
            this.udext1len.Size = new System.Drawing.Size(71, 22);
            this.udext1len.TabIndex = 24;
            this.udext1len.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(167, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 17);
            this.label17.TabIndex = 22;
            this.label17.Text = "mm/min";
            // 
            // cmdExtrude2
            // 
            this.cmdExtrude2.Location = new System.Drawing.Point(6, 21);
            this.cmdExtrude2.Name = "cmdExtrude2";
            this.cmdExtrude2.Size = new System.Drawing.Size(75, 44);
            this.cmdExtrude2.TabIndex = 14;
            this.cmdExtrude2.Text = "Extrude";
            this.cmdExtrude2.UseVisualStyleBackColor = true;
            this.cmdExtrude2.Click += new System.EventHandler(this.cmdExtrude2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(176, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "mm";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // cmdReverse2
            // 
            this.cmdReverse2.Location = new System.Drawing.Point(6, 71);
            this.cmdReverse2.Name = "cmdReverse2";
            this.cmdReverse2.Size = new System.Drawing.Size(75, 44);
            this.cmdReverse2.TabIndex = 15;
            this.cmdReverse2.Text = "Reverse";
            this.cmdReverse2.UseVisualStyleBackColor = true;
            this.cmdReverse2.Click += new System.EventHandler(this.cmdReverse2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtRateXY);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtRateZ);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(369, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 143);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Axis Rates";
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(699, 464);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(75, 33);
            this.cmdClear.TabIndex = 59;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // ctlMachineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.txtSent);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmdSendGCode);
            this.Controls.Add(this.txtGCode);
            this.Controls.Add(this.grpHoming);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpExtrudeControls);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtdistXY);
            this.Controls.Add(this.cmdYDown);
            this.Controls.Add(this.cmdYUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdXDown);
            this.Controls.Add(this.cmdXUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdist);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.Name = "ctlMachineControl";
            this.Size = new System.Drawing.Size(1184, 557);
            this.grpHoming.ResumeLayout(false);
            this.grpHoming.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grpExtrudeControls.ResumeLayout(false);
            this.grpExtrudeControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTool0Rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udext0len)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udTool1Rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udext1len)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRateZ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRateXY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpHoming;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button cmdYHome;
        private System.Windows.Forms.Button cmdXHome;
        private System.Windows.Forms.Button cmdZHome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdMotorsOn;
        private System.Windows.Forms.Button cmdMotorsOff;
        private System.Windows.Forms.GroupBox grpExtrudeControls;
        private System.Windows.Forms.Button cmdExtrude1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdReverse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtdistXY;
        private System.Windows.Forms.Button cmdYDown;
        private System.Windows.Forms.Button cmdYUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdXDown;
        private System.Windows.Forms.Button cmdXUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdist;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.TextBox txtSent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button cmdSendGCode;
        private System.Windows.Forms.TextBox txtGCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdExtrude2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdReverse2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button cmdHomeAll;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.NumericUpDown udext0len;
        private System.Windows.Forms.NumericUpDown udext1len;
        private System.Windows.Forms.NumericUpDown udTool0Rate;
        private System.Windows.Forms.NumericUpDown udTool1Rate;
    }
}
