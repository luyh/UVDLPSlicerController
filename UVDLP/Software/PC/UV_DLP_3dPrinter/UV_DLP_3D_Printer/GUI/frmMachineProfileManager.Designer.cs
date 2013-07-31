namespace UV_DLP_3D_Printer.GUI
{
    partial class frmMachineProfileManager
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
            this.lstMachineProfiles = new System.Windows.Forms.ListBox();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMachineProfiles
            // 
            this.lstMachineProfiles.FormattingEnabled = true;
            this.lstMachineProfiles.ItemHeight = 16;
            this.lstMachineProfiles.Location = new System.Drawing.Point(12, 12);
            this.lstMachineProfiles.Name = "lstMachineProfiles";
            this.lstMachineProfiles.Size = new System.Drawing.Size(348, 148);
            this.lstMachineProfiles.TabIndex = 0;
            this.lstMachineProfiles.SelectedIndexChanged += new System.EventHandler(this.lstMachineProfiles_SelectedIndexChanged);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(376, 12);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(101, 33);
            this.cmdNew.TabIndex = 1;
            this.cmdNew.Text = "Create New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdCopy
            // 
            this.cmdCopy.Location = new System.Drawing.Point(376, 51);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(101, 33);
            this.cmdCopy.TabIndex = 2;
            this.cmdCopy.Text = "Copy";
            this.cmdCopy.UseVisualStyleBackColor = true;
            this.cmdCopy.Visible = false;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(376, 129);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(101, 33);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(196, 185);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 33);
            this.button4.TabIndex = 4;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(376, 90);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(101, 33);
            this.cmdEdit.TabIndex = 5;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // frmMachineProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 230);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdCopy);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.lstMachineProfiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMachineProfileManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Machine Profiles Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstMachineProfiles;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdCopy;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button cmdEdit;
    }
}