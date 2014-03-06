namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctlProjectorControl
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
            this.cmdSendProj = new System.Windows.Forms.Button();
            this.cmbCommands = new System.Windows.Forms.ComboBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdEditPC = new System.Windows.Forms.Button();
            this.cmdHide = new System.Windows.Forms.Button();
            this.cmdShowBlank = new System.Windows.Forms.Button();
            this.cmdShowCalib = new System.Windows.Forms.Button();
            this.labelManipType = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSendProj
            // 
            this.cmdSendProj.Location = new System.Drawing.Point(202, 104);
            this.cmdSendProj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSendProj.Name = "cmdSendProj";
            this.cmdSendProj.Size = new System.Drawing.Size(75, 23);
            this.cmdSendProj.TabIndex = 6;
            this.cmdSendProj.Text = "Send";
            this.cmdSendProj.UseVisualStyleBackColor = true;
            this.cmdSendProj.Click += new System.EventHandler(this.cmdSendProj_Click);
            // 
            // cmbCommands
            // 
            this.cmbCommands.FormattingEnabled = true;
            this.cmbCommands.Location = new System.Drawing.Point(3, 104);
            this.cmbCommands.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCommands.Name = "cmbCommands";
            this.cmbCommands.Size = new System.Drawing.Size(193, 24);
            this.cmbCommands.TabIndex = 5;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(3, 36);
            this.cmdConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(124, 30);
            this.cmdConnect.TabIndex = 4;
            this.cmdConnect.Text = "Connect Display";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdEditPC
            // 
            this.cmdEditPC.Location = new System.Drawing.Point(133, 36);
            this.cmdEditPC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdEditPC.Name = "cmdEditPC";
            this.cmdEditPC.Size = new System.Drawing.Size(124, 30);
            this.cmdEditPC.TabIndex = 3;
            this.cmdEditPC.Text = "Edit Commands";
            this.cmdEditPC.UseVisualStyleBackColor = true;
            this.cmdEditPC.Click += new System.EventHandler(this.cmdEditPC_Click);
            // 
            // cmdHide
            // 
            this.cmdHide.Location = new System.Drawing.Point(3, 70);
            this.cmdHide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdHide.Name = "cmdHide";
            this.cmdHide.Size = new System.Drawing.Size(124, 30);
            this.cmdHide.TabIndex = 2;
            this.cmdHide.Text = "Hide";
            this.cmdHide.UseVisualStyleBackColor = true;
            this.cmdHide.Click += new System.EventHandler(this.cmdHide_Click);
            // 
            // cmdShowBlank
            // 
            this.cmdShowBlank.Location = new System.Drawing.Point(133, 2);
            this.cmdShowBlank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdShowBlank.Name = "cmdShowBlank";
            this.cmdShowBlank.Size = new System.Drawing.Size(125, 30);
            this.cmdShowBlank.TabIndex = 1;
            this.cmdShowBlank.Text = "Show Blank";
            this.cmdShowBlank.UseVisualStyleBackColor = true;
            this.cmdShowBlank.Click += new System.EventHandler(this.cmdShowBlank_Click);
            // 
            // cmdShowCalib
            // 
            this.cmdShowCalib.Location = new System.Drawing.Point(3, 2);
            this.cmdShowCalib.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdShowCalib.Name = "cmdShowCalib";
            this.cmdShowCalib.Size = new System.Drawing.Size(124, 28);
            this.cmdShowCalib.TabIndex = 0;
            this.cmdShowCalib.Text = "Show Calibration";
            this.cmdShowCalib.UseVisualStyleBackColor = true;
            this.cmdShowCalib.Click += new System.EventHandler(this.cmdShowCalib_Click);
            // 
            // labelManipType
            // 
            this.labelManipType.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelManipType.ForeColor = System.Drawing.Color.Black;
            this.labelManipType.Location = new System.Drawing.Point(3, 0);
            this.labelManipType.Name = "labelManipType";
            this.labelManipType.Size = new System.Drawing.Size(293, 31);
            this.labelManipType.TabIndex = 62;
            this.labelManipType.Text = "Projector Control";
            this.labelManipType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cmdShowCalib);
            this.flowLayoutPanel1.Controls.Add(this.cmdShowBlank);
            this.flowLayoutPanel1.Controls.Add(this.cmdConnect);
            this.flowLayoutPanel1.Controls.Add(this.cmdEditPC);
            this.flowLayoutPanel1.Controls.Add(this.cmdHide);
            this.flowLayoutPanel1.Controls.Add(this.cmbCommands);
            this.flowLayoutPanel1.Controls.Add(this.cmdSendProj);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 34);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(293, 141);
            this.flowLayoutPanel1.TabIndex = 63;
            // 
            // ctlProjectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelManipType);
            this.Name = "ctlProjectorControl";
            this.Size = new System.Drawing.Size(301, 178);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSendProj;
        private System.Windows.Forms.ComboBox cmbCommands;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Button cmdEditPC;
        private System.Windows.Forms.Button cmdHide;
        private System.Windows.Forms.Button cmdShowBlank;
        private System.Windows.Forms.Button cmdShowCalib;
        private System.Windows.Forms.Label labelManipType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
