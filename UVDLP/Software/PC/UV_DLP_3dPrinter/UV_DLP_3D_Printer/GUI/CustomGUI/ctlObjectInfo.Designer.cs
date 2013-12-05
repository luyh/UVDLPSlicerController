namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlObjectInfo
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
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tTitle = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.Label();
            this.tVolume = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlInfoItem();
            this.tCost = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlInfoItem();
            this.tPoints = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlInfoItem();
            this.tPolys = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlInfoItem();
            this.tMin = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlInfoItem();
            this.tMax = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlInfoItem();
            this.tSize = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlInfoItem();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel
            // 
            this.layoutPanel.BackColor = System.Drawing.Color.Navy;
            this.layoutPanel.Controls.Add(this.tTitle);
            this.layoutPanel.Controls.Add(this.tName);
            this.layoutPanel.Controls.Add(this.tVolume);
            this.layoutPanel.Controls.Add(this.tCost);
            this.layoutPanel.Controls.Add(this.tPoints);
            this.layoutPanel.Controls.Add(this.tPolys);
            this.layoutPanel.Controls.Add(this.tMin);
            this.layoutPanel.Controls.Add(this.tMax);
            this.layoutPanel.Controls.Add(this.tSize);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(206, 179);
            this.layoutPanel.TabIndex = 0;
            this.layoutPanel.Resize += new System.EventHandler(this.layoutPanel_Resize);
            // 
            // tTitle
            // 
            this.tTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tTitle.Font = new System.Drawing.Font("Arial", 17.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tTitle.ForeColor = System.Drawing.Color.White;
            this.tTitle.Location = new System.Drawing.Point(3, 2);
            this.tTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.tTitle.Name = "tTitle";
            this.tTitle.Size = new System.Drawing.Size(144, 23);
            this.tTitle.TabIndex = 0;
            this.tTitle.Text = "Object Info";
            // 
            // tName
            // 
            this.tName.BackColor = System.Drawing.Color.RoyalBlue;
            this.tName.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tName.ForeColor = System.Drawing.Color.White;
            this.tName.Location = new System.Drawing.Point(3, 27);
            this.tName.Margin = new System.Windows.Forms.Padding(3, 2, 4, 3);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(144, 16);
            this.tName.TabIndex = 0;
            this.tName.Text = "Object Info";
            // 
            // tVolume
            // 
            this.tVolume.BackColor = System.Drawing.Color.Navy;
            this.tVolume.DataBackColor = System.Drawing.Color.RoyalBlue;
            this.tVolume.DataColor = System.Drawing.Color.White;
            this.tVolume.DataText = "";
            this.tVolume.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tVolume.Location = new System.Drawing.Point(3, 46);
            this.tVolume.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tVolume.Name = "tVolume";
            this.tVolume.Size = new System.Drawing.Size(184, 17);
            this.tVolume.TabIndex = 1;
            this.tVolume.TitleBackColor = System.Drawing.Color.Navy;
            this.tVolume.TitleColor = System.Drawing.Color.White;
            this.tVolume.TitleText = "Volume:";
            this.tVolume.TitleWidth = 30;
            // 
            // tCost
            // 
            this.tCost.BackColor = System.Drawing.Color.Navy;
            this.tCost.DataBackColor = System.Drawing.Color.RoyalBlue;
            this.tCost.DataColor = System.Drawing.Color.White;
            this.tCost.DataText = "";
            this.tCost.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tCost.Location = new System.Drawing.Point(3, 63);
            this.tCost.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tCost.Name = "tCost";
            this.tCost.Size = new System.Drawing.Size(184, 17);
            this.tCost.TabIndex = 1;
            this.tCost.TitleBackColor = System.Drawing.Color.Navy;
            this.tCost.TitleColor = System.Drawing.Color.White;
            this.tCost.TitleText = "Cost:";
            this.tCost.TitleWidth = 30;
            // 
            // tPoints
            // 
            this.tPoints.BackColor = System.Drawing.Color.Navy;
            this.tPoints.DataBackColor = System.Drawing.Color.RoyalBlue;
            this.tPoints.DataColor = System.Drawing.Color.White;
            this.tPoints.DataText = "";
            this.tPoints.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tPoints.Location = new System.Drawing.Point(3, 80);
            this.tPoints.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tPoints.Name = "tPoints";
            this.tPoints.Size = new System.Drawing.Size(184, 17);
            this.tPoints.TabIndex = 1;
            this.tPoints.TitleBackColor = System.Drawing.Color.Navy;
            this.tPoints.TitleColor = System.Drawing.Color.White;
            this.tPoints.TitleText = "# Points:";
            this.tPoints.TitleWidth = 30;
            // 
            // tPolys
            // 
            this.tPolys.BackColor = System.Drawing.Color.Navy;
            this.tPolys.DataBackColor = System.Drawing.Color.RoyalBlue;
            this.tPolys.DataColor = System.Drawing.Color.White;
            this.tPolys.DataText = "";
            this.tPolys.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tPolys.Location = new System.Drawing.Point(3, 97);
            this.tPolys.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tPolys.Name = "tPolys";
            this.tPolys.Size = new System.Drawing.Size(184, 17);
            this.tPolys.TabIndex = 1;
            this.tPolys.TitleBackColor = System.Drawing.Color.Navy;
            this.tPolys.TitleColor = System.Drawing.Color.White;
            this.tPolys.TitleText = "# Polys:";
            this.tPolys.TitleWidth = 30;
            // 
            // tMin
            // 
            this.tMin.BackColor = System.Drawing.Color.Navy;
            this.tMin.DataBackColor = System.Drawing.Color.RoyalBlue;
            this.tMin.DataColor = System.Drawing.Color.White;
            this.tMin.DataText = "";
            this.tMin.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tMin.Location = new System.Drawing.Point(3, 114);
            this.tMin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tMin.Name = "tMin";
            this.tMin.Size = new System.Drawing.Size(184, 17);
            this.tMin.TabIndex = 1;
            this.tMin.TitleBackColor = System.Drawing.Color.Navy;
            this.tMin.TitleColor = System.Drawing.Color.White;
            this.tMin.TitleText = "Min:";
            this.tMin.TitleWidth = 30;
            // 
            // tMax
            // 
            this.tMax.BackColor = System.Drawing.Color.Navy;
            this.tMax.DataBackColor = System.Drawing.Color.RoyalBlue;
            this.tMax.DataColor = System.Drawing.Color.White;
            this.tMax.DataText = "";
            this.tMax.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tMax.Location = new System.Drawing.Point(3, 131);
            this.tMax.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tMax.Name = "tMax";
            this.tMax.Size = new System.Drawing.Size(184, 17);
            this.tMax.TabIndex = 1;
            this.tMax.TitleBackColor = System.Drawing.Color.Navy;
            this.tMax.TitleColor = System.Drawing.Color.White;
            this.tMax.TitleText = "Max:";
            this.tMax.TitleWidth = 30;
            // 
            // tSize
            // 
            this.tSize.BackColor = System.Drawing.Color.Navy;
            this.tSize.DataBackColor = System.Drawing.Color.RoyalBlue;
            this.tSize.DataColor = System.Drawing.Color.White;
            this.tSize.DataText = "";
            this.tSize.Font = new System.Drawing.Font("Arial", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tSize.Location = new System.Drawing.Point(3, 148);
            this.tSize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tSize.Name = "tSize";
            this.tSize.Size = new System.Drawing.Size(184, 17);
            this.tSize.TabIndex = 1;
            this.tSize.TitleBackColor = System.Drawing.Color.Navy;
            this.tSize.TitleColor = System.Drawing.Color.White;
            this.tSize.TitleText = "Size:";
            this.tSize.TitleWidth = 30;
            // 
            // ctlObjectInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.layoutPanel);
            this.Name = "ctlObjectInfo";
            this.Size = new System.Drawing.Size(206, 179);
            this.layoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel layoutPanel;
        private System.Windows.Forms.Label tTitle;
        private System.Windows.Forms.Label tName;
        private ctlInfoItem tVolume;
        private ctlInfoItem tCost;
        private ctlInfoItem tPoints;
        private ctlInfoItem tPolys;
        private ctlInfoItem tMin;
        private ctlInfoItem tMax;
        private ctlInfoItem tSize;
    }
}
