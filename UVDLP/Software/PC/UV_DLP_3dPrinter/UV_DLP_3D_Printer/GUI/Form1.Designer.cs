using UV_DLP_3D_Printer.GUI;
namespace UV_DLP_3D_Printer.GUI
{
    partial class Form1
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ctlImageButton1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.flowLayoutPanel1 = new UV_DLP_3D_Printer.GUI.ctlExpandPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.ctlExpandPanel1 = new UV_DLP_3D_Printer.GUI.ctlExpandPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.ctlExpandPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.ctlExpandPanel1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(350, 17);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(226, 374);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // ctlImageButton1
            // 
            this.ctlImageButton1.BackColor = System.Drawing.Color.DarkBlue;
            this.ctlImageButton1.Image = global::UV_DLP_3D_Printer.Properties.Resources.homeButt;
            this.ctlImageButton1.Location = new System.Drawing.Point(40, 25);
            this.ctlImageButton1.Name = "ctlImageButton1";
            this.ctlImageButton1.Size = new System.Drawing.Size(64, 64);
            this.ctlImageButton1.TabIndex = 3;
            this.ctlImageButton1.Text = "ctlImageButton1";
            this.ctlImageButton1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.listView1);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel2.SetFlowBreak(this.flowLayoutPanel1, true);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 156);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 64);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(195, 29);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Scale";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ctlExpandPanel1
            // 
            this.ctlExpandPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ctlExpandPanel1.Controls.Add(this.label2);
            this.ctlExpandPanel1.Controls.Add(this.listView2);
            this.ctlExpandPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel2.SetFlowBreak(this.ctlExpandPanel1, true);
            this.ctlExpandPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ctlExpandPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlExpandPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ctlExpandPanel1.Location = new System.Drawing.Point(8, 180);
            this.ctlExpandPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.ctlExpandPanel1.Name = "ctlExpandPanel1";
            this.ctlExpandPanel1.Size = new System.Drawing.Size(205, 156);
            this.ctlExpandPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(3, 64);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(195, 29);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "Move";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 600);
            this.Controls.Add(this.ctlImageButton1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ctlExpandPanel1.ResumeLayout(false);
            this.ctlExpandPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctlExpandPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private ctlExpandPanel ctlExpandPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private CustomGUI.ctlImageButton ctlImageButton1;

    }
}