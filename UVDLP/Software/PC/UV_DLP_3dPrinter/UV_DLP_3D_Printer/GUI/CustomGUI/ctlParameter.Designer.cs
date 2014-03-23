namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlParameter
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
            this.ctlParam = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            this.SuspendLayout();
            // 
            // ctlParam
            // 
            this.ctlParam.BackColor = System.Drawing.Color.RoyalBlue;
            this.ctlParam.ButtonsColor = System.Drawing.Color.RoyalBlue;
            this.ctlParam.Checked = false;
            this.ctlParam.ErrorColor = System.Drawing.Color.Red;
            this.ctlParam.FloatVal = 10F;
            this.ctlParam.Gapx = 5;
            this.ctlParam.Gapy = 5;
            this.ctlParam.GLBackgroundImage = null;
            this.ctlParam.GLVisible = false;
            this.ctlParam.GuiAnchor = null;
            this.ctlParam.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.ctlParam.Increment = 1F;
            this.ctlParam.IntVal = 1;
            this.ctlParam.Location = new System.Drawing.Point(55, 3);
            this.ctlParam.MaxFloat = 500F;
            this.ctlParam.MaxInt = 1000;
            this.ctlParam.MinFloat = -500F;
            this.ctlParam.MinimumSize = new System.Drawing.Size(20, 5);
            this.ctlParam.MinInt = 1;
            this.ctlParam.Name = "ctlParam";
            this.ctlParam.Size = new System.Drawing.Size(95, 27);
            this.ctlParam.StyleName = null;
            this.ctlParam.TabIndex = 0;
            this.ctlParam.TextFont = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ctlParam.ValidColor = System.Drawing.Color.White;
            this.ctlParam.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            // 
            // ctlParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlParam);
            this.FrameColor = System.Drawing.Color.RoyalBlue;
            this.Name = "ctlParameter";
            this.Size = new System.Drawing.Size(150, 47);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlNumber ctlParam;

    }
}
