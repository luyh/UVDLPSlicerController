namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctlSupport
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
            this.cmdAutoSupport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numHT = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numHB = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numFB = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numFT = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numFB1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkDownPolys = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFB1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAutoSupport
            // 
            this.cmdAutoSupport.Location = new System.Drawing.Point(9, 67);
            this.cmdAutoSupport.Name = "cmdAutoSupport";
            this.cmdAutoSupport.Size = new System.Drawing.Size(127, 32);
            this.cmdAutoSupport.TabIndex = 0;
            this.cmdAutoSupport.Text = "Generate Auto";
            this.cmdAutoSupport.UseVisualStyleBackColor = true;
            this.cmdAutoSupport.Click += new System.EventHandler(this.cmdAutoSupport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y (mm)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "X (mm)";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 105);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(265, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 166);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // numHT
            // 
            this.numHT.DecimalPlaces = 1;
            this.numHT.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numHT.Location = new System.Drawing.Point(115, 29);
            this.numHT.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numHT.Name = "numHT";
            this.numHT.Size = new System.Drawing.Size(71, 22);
            this.numHT.TabIndex = 13;
            this.numHT.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Head Top";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Head Bottom";
            // 
            // numHB
            // 
            this.numHB.DecimalPlaces = 1;
            this.numHB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numHB.Location = new System.Drawing.Point(115, 57);
            this.numHB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numHB.Name = "numHB";
            this.numHB.Size = new System.Drawing.Size(71, 22);
            this.numHB.TabIndex = 15;
            this.numHB.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Foot Bottom";
            // 
            // numFB
            // 
            this.numFB.DecimalPlaces = 1;
            this.numFB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFB.Location = new System.Drawing.Point(115, 132);
            this.numFB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numFB.Name = "numFB";
            this.numFB.Size = new System.Drawing.Size(71, 22);
            this.numFB.TabIndex = 19;
            this.numFB.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Foot Top";
            // 
            // numFT
            // 
            this.numFT.DecimalPlaces = 1;
            this.numFT.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFT.Location = new System.Drawing.Point(115, 104);
            this.numFT.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numFT.Name = "numFT";
            this.numFT.Size = new System.Drawing.Size(71, 22);
            this.numFT.TabIndex = 17;
            this.numFT.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Foot Bt Intra";
            // 
            // numFB1
            // 
            this.numFB1.DecimalPlaces = 1;
            this.numFB1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFB1.Location = new System.Drawing.Point(115, 160);
            this.numFB1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFB1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numFB1.Name = "numFB1";
            this.numFB1.Size = new System.Drawing.Size(71, 22);
            this.numFB1.TabIndex = 21;
            this.numFB1.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numY);
            this.groupBox1.Controls.Add(this.numX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdAutoSupport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(3, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 146);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Support on Grid";
            // 
            // numY
            // 
            this.numY.DecimalPlaces = 1;
            this.numY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numY.Location = new System.Drawing.Point(89, 38);
            this.numY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(71, 22);
            this.numY.TabIndex = 15;
            this.numY.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // numX
            // 
            this.numX.DecimalPlaces = 1;
            this.numX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numX.Location = new System.Drawing.Point(9, 39);
            this.numX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(71, 22);
            this.numX.TabIndex = 14;
            this.numX.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.numHT);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numFB1);
            this.groupBox2.Controls.Add(this.numHB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numFB);
            this.groupBox2.Controls.Add(this.numFT);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 199);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Support Parameters";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 32);
            this.button1.TabIndex = 25;
            this.button1.Text = "Create Support";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chkDownPolys);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(9, 360);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 121);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual Support";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(84, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "degrees";
            // 
            // chkDownPolys
            // 
            this.chkDownPolys.AutoSize = true;
            this.chkDownPolys.Enabled = false;
            this.chkDownPolys.Location = new System.Drawing.Point(7, 21);
            this.chkDownPolys.Name = "chkDownPolys";
            this.chkDownPolys.Size = new System.Drawing.Size(218, 21);
            this.chkDownPolys.TabIndex = 27;
            this.chkDownPolys.Text = "Shown downward facing polys";
            this.chkDownPolys.UseVisualStyleBackColor = true;
            this.chkDownPolys.CheckedChanged += new System.EventHandler(this.chkDownPolys_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(7, 48);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(71, 22);
            this.numericUpDown1.TabIndex = 26;
            this.numericUpDown1.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // ctlSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctlSupport";
            this.Size = new System.Drawing.Size(296, 484);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFB1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAutoSupport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numHT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numHB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numFB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numFT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numFB1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkDownPolys;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
