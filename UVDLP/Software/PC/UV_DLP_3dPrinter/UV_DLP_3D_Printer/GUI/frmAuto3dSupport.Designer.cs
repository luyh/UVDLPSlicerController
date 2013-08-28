namespace UV_DLP_3D_Printer.GUI
{
    partial class frmAuto3dSupport
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXS = new System.Windows.Forms.TextBox();
            this.txtYS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBRad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTRad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(157, 327);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(101, 35);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(264, 327);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(101, 35);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "X Spacing (mm)";
            // 
            // txtXS
            // 
            this.txtXS.Location = new System.Drawing.Point(36, 49);
            this.txtXS.Name = "txtXS";
            this.txtXS.Size = new System.Drawing.Size(100, 22);
            this.txtXS.TabIndex = 3;
            // 
            // txtYS
            // 
            this.txtYS.Location = new System.Drawing.Point(169, 49);
            this.txtYS.Name = "txtYS";
            this.txtYS.Size = new System.Drawing.Size(100, 22);
            this.txtYS.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y Spacing (mm)";
            // 
            // txtBRad
            // 
            this.txtBRad.Location = new System.Drawing.Point(36, 114);
            this.txtBRad.Name = "txtBRad";
            this.txtBRad.Size = new System.Drawing.Size(100, 22);
            this.txtBRad.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bottom Radius (mm)";
            // 
            // txtTRad
            // 
            this.txtTRad.Location = new System.Drawing.Point(169, 114);
            this.txtTRad.Name = "txtTRad";
            this.txtTRad.Size = new System.Drawing.Size(100, 22);
            this.txtTRad.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Top Radius (mm)";
            // 
            // frmAuto3dSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 374);
            this.Controls.Add(this.txtTRad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBRad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtXS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmAuto3dSupport";
            this.Text = "Auto 3d Support Generation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXS;
        private System.Windows.Forms.TextBox txtYS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBRad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTRad;
        private System.Windows.Forms.Label label4;
    }
}