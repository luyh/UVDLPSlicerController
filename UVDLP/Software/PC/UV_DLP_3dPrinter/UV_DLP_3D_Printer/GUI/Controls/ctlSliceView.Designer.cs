namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctlSliceView
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
            this.itemNumLayers = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlInfoItem();
            this.picSlice = new System.Windows.Forms.PictureBox();
            this.numLayer = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlNumber();
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).BeginInit();
            this.SuspendLayout();
            // 
            // itemNumLayers
            // 
            this.itemNumLayers.BackColor = System.Drawing.Color.Navy;
            this.itemNumLayers.BorderWidth = 3;
            this.itemNumLayers.DataBackColor = System.Drawing.Color.RoyalBlue;
            this.itemNumLayers.DataColor = System.Drawing.Color.White;
            this.itemNumLayers.DataText = "";
            this.itemNumLayers.Font = new System.Drawing.Font("Arial", 17.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.itemNumLayers.Location = new System.Drawing.Point(10, 10);
            this.itemNumLayers.Name = "itemNumLayers";
            this.itemNumLayers.Size = new System.Drawing.Size(207, 30);
            this.itemNumLayers.TabIndex = 19;
            this.itemNumLayers.TitleBackColor = System.Drawing.Color.Navy;
            this.itemNumLayers.TitleColor = System.Drawing.Color.White;
            this.itemNumLayers.TitleText = "# Layers:";
            // 
            // picSlice
            // 
            this.picSlice.BackColor = System.Drawing.Color.Black;
            this.picSlice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSlice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSlice.Location = new System.Drawing.Point(0, 0);
            this.picSlice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picSlice.Name = "picSlice";
            this.picSlice.Size = new System.Drawing.Size(711, 452);
            this.picSlice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSlice.TabIndex = 18;
            this.picSlice.TabStop = false;
            // 
            // numLayer
            // 
            this.numLayer.BackColor = System.Drawing.Color.RoyalBlue;
            this.numLayer.ButtonsColor = System.Drawing.Color.Navy;
            this.numLayer.Checked = false;
            this.numLayer.EnableScroll = true;
            this.numLayer.ErrorColor = System.Drawing.Color.Red;
            this.numLayer.FloatVal = 10F;
            this.numLayer.Gapx = 0;
            this.numLayer.Gapy = 10;
            this.numLayer.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Center;
            this.numLayer.Increment = 1F;
            this.numLayer.IntVal = 1000;
            this.numLayer.Location = new System.Drawing.Point(157, 409);
            this.numLayer.MaxFloat = 500F;
            this.numLayer.MaxInt = 1000;
            this.numLayer.MinFloat = -500F;
            this.numLayer.MinimumSize = new System.Drawing.Size(20, 5);
            this.numLayer.MinInt = 1;
            this.numLayer.Name = "numLayer";
            this.numLayer.Size = new System.Drawing.Size(425, 24);
            this.numLayer.TabIndex = 28;
            this.numLayer.TextFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numLayer.ValidColor = System.Drawing.Color.White;
            this.numLayer.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.Bottom;
            this.numLayer.Visible = false;
            this.numLayer.ValueChanged += new System.EventHandler(this.numLayer_ValueChanged);
            // 
            // ctlSliceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numLayer);
            this.Controls.Add(this.itemNumLayers);
            this.Controls.Add(this.picSlice);
            this.Name = "ctlSliceView";
            this.Size = new System.Drawing.Size(711, 452);
            this.SizeChanged += new System.EventHandler(this.ctlSliceView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSlice;
        private CustomGUI.ctlInfoItem itemNumLayers;
        private CustomGUI.ctlNumber numLayer;
    }
}
