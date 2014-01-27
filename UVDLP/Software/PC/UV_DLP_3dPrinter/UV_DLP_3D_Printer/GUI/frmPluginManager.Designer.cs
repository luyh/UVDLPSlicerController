namespace UV_DLP_3D_Printer.GUI
{
    partial class frmPluginManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdEnable = new System.Windows.Forms.Button();
            this.lvplugins = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLicensed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Installed Plug-Ins";
            // 
            // cmdEnable
            // 
            this.cmdEnable.Location = new System.Drawing.Point(462, 30);
            this.cmdEnable.Name = "cmdEnable";
            this.cmdEnable.Size = new System.Drawing.Size(130, 30);
            this.cmdEnable.TabIndex = 2;
            this.cmdEnable.Text = "Enable";
            this.cmdEnable.UseVisualStyleBackColor = true;
            // 
            // lvplugins
            // 
            this.lvplugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmEnabled,
            this.clmLicensed,
            this.clmVersion});
            this.lvplugins.FullRowSelect = true;
            this.lvplugins.GridLines = true;
            this.lvplugins.Location = new System.Drawing.Point(12, 30);
            this.lvplugins.MultiSelect = false;
            this.lvplugins.Name = "lvplugins";
            this.lvplugins.Size = new System.Drawing.Size(432, 173);
            this.lvplugins.TabIndex = 3;
            this.lvplugins.UseCompatibleStateImageBehavior = false;
            this.lvplugins.View = System.Windows.Forms.View.Details;
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            // 
            // clmEnabled
            // 
            this.clmEnabled.Text = "Enabled";
            // 
            // clmLicensed
            // 
            this.clmLicensed.Text = "Licensed";
            // 
            // clmVersion
            // 
            this.clmVersion.Text = "Version";
            // 
            // frmPluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 313);
            this.Controls.Add(this.lvplugins);
            this.Controls.Add(this.cmdEnable);
            this.Controls.Add(this.label1);
            this.Name = "frmPluginManager";
            this.Text = "Plugin and Licensing Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdEnable;
        private System.Windows.Forms.ListView lvplugins;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmEnabled;
        private System.Windows.Forms.ColumnHeader clmLicensed;
        private System.Windows.Forms.ColumnHeader clmVersion;
    }
}