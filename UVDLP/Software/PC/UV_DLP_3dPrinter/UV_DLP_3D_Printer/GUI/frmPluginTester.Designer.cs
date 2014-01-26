namespace UV_DLP_3D_Printer.GUI
{
    partial class frmPluginTester
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
            this.lvplugins = new System.Windows.Forms.ListView();
            this.lvcontents = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvplugins
            // 
            this.lvplugins.Location = new System.Drawing.Point(27, 33);
            this.lvplugins.MultiSelect = false;
            this.lvplugins.Name = "lvplugins";
            this.lvplugins.Size = new System.Drawing.Size(302, 99);
            this.lvplugins.TabIndex = 0;
            this.lvplugins.UseCompatibleStateImageBehavior = false;
            this.lvplugins.View = System.Windows.Forms.View.List;
            this.lvplugins.SelectedIndexChanged += new System.EventHandler(this.lvplugins_SelectedIndexChanged);
            // 
            // lvcontents
            // 
            this.lvcontents.Location = new System.Drawing.Point(27, 160);
            this.lvcontents.MultiSelect = false;
            this.lvcontents.Name = "lvcontents";
            this.lvcontents.Size = new System.Drawing.Size(302, 183);
            this.lvcontents.TabIndex = 1;
            this.lvcontents.UseCompatibleStateImageBehavior = false;
            this.lvcontents.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plug In";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plugin Contents";
            // 
            // frmPluginTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 371);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvcontents);
            this.Controls.Add(this.lvplugins);
            this.Name = "frmPluginTester";
            this.Text = "Plug-in Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvplugins;
        private System.Windows.Forms.ListView lvcontents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}