namespace UV_DLP_3D_Printer.GUI
{
    partial class frmFlexSliceOptions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgModules = new System.Windows.Forms.DataGridView();
            this.Modules = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgParms = new System.Windows.Forms.DataGridView();
            this.ParmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgParms)).BeginInit();
            this.SuspendLayout();
            // 
            // dgModules
            // 
            this.dgModules.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgModules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgModules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Modules});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgModules.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgModules.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgModules.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgModules.Location = new System.Drawing.Point(0, 0);
            this.dgModules.Name = "dgModules";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgModules.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgModules.RowHeadersVisible = false;
            this.dgModules.RowTemplate.Height = 24;
            this.dgModules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgModules.Size = new System.Drawing.Size(199, 563);
            this.dgModules.TabIndex = 3;
            // 
            // Modules
            // 
            this.Modules.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Modules.HeaderText = "Modules";
            this.Modules.Name = "Modules";
            this.Modules.ReadOnly = true;
            this.Modules.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgParms
            // 
            this.dgParms.AllowUserToResizeRows = false;
            this.dgParms.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgParms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgParms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParmName,
            this.ParmValue,
            this.ParmDescription});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgParms.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgParms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgParms.Location = new System.Drawing.Point(199, 0);
            this.dgParms.MultiSelect = false;
            this.dgParms.Name = "dgParms";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgParms.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgParms.RowHeadersVisible = false;
            this.dgParms.RowTemplate.Height = 24;
            this.dgParms.Size = new System.Drawing.Size(981, 563);
            this.dgParms.TabIndex = 4;
            // 
            // ParmName
            // 
            this.ParmName.HeaderText = "Name";
            this.ParmName.MinimumWidth = 100;
            this.ParmName.Name = "ParmName";
            this.ParmName.ReadOnly = true;
            this.ParmName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ParmName.Width = 150;
            // 
            // ParmValue
            // 
            this.ParmValue.HeaderText = "Value";
            this.ParmValue.MinimumWidth = 100;
            this.ParmValue.Name = "ParmValue";
            this.ParmValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ParmValue.Width = 150;
            // 
            // ParmDescription
            // 
            this.ParmDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParmDescription.DefaultCellStyle = dataGridViewCellStyle5;
            this.ParmDescription.HeaderText = "Description";
            this.ParmDescription.Name = "ParmDescription";
            this.ParmDescription.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(199, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 100);
            this.panel1.TabIndex = 5;
            // 
            // frmFlexSliceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 563);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgParms);
            this.Controls.Add(this.dgModules);
            this.Name = "frmFlexSliceOptions";
            this.Text = "Slice Options";
            ((System.ComponentModel.ISupportInitialize)(this.dgModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgParms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgModules;
        private System.Windows.Forms.DataGridView dgParms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modules;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParmValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParmDescription;

    }
}