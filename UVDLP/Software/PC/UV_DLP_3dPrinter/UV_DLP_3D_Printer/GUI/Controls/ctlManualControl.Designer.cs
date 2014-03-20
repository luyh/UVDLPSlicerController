namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctlManualControl
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
            this.flowTop = new System.Windows.Forms.FlowLayoutPanel();
            this.cMCXY = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlMCXY();
            this.cMCZ = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlMCZ();
            this.cMCExtruder = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlMCZ();
            this.cMCTilt = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlMCZ();
            this.cMCTempExtruder = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlMCTemp();
            this.cMCTempPlatform = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlMCTemp();
            this.flowData1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ctlOnOffMotors = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlOnOff();
            this.ctlOnOffHeater = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlOnOff();
            this.ctlOnOffPlatform = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlOnOff();
            this.cOnOffMonitorTemp = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlOnOff();
            this.flowTop.SuspendLayout();
            this.flowData1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowTop
            // 
            this.flowTop.Controls.Add(this.cMCXY);
            this.flowTop.Controls.Add(this.cMCZ);
            this.flowTop.Controls.Add(this.cMCExtruder);
            this.flowTop.Controls.Add(this.cMCTilt);
            this.flowTop.Controls.Add(this.cMCTempExtruder);
            this.flowTop.Controls.Add(this.cMCTempPlatform);
            this.flowTop.Location = new System.Drawing.Point(3, 3);
            this.flowTop.Margin = new System.Windows.Forms.Padding(2);
            this.flowTop.Name = "flowTop";
            this.flowTop.Size = new System.Drawing.Size(646, 260);
            this.flowTop.TabIndex = 0;
            // 
            // cMCXY
            // 
            this.cMCXY.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cMCXY.FrameColor = System.Drawing.Color.RoyalBlue;
            this.cMCXY.Gapx = 0;
            this.cMCXY.Gapy = 0;
            this.cMCXY.GLBackgroundImage = null;
            this.cMCXY.GLVisible = false;
            this.cMCXY.GuiAnchor = null;
            this.cMCXY.Location = new System.Drawing.Point(3, 3);
            this.cMCXY.Name = "cMCXY";
            this.cMCXY.Size = new System.Drawing.Size(256, 256);
            this.cMCXY.StyleName = null;
            this.cMCXY.TabIndex = 0;
            this.cMCXY.Title = "XY Axis";
            this.cMCXY.Unit = "mm";
            // 
            // cMCZ
            // 
            this.cMCZ.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cMCZ.FrameColor = System.Drawing.Color.RoyalBlue;
            this.cMCZ.Gapx = 0;
            this.cMCZ.Gapy = 0;
            this.cMCZ.GLBackgroundImage = null;
            this.cMCZ.GLVisible = false;
            this.cMCZ.GuiAnchor = null;
            this.cMCZ.Location = new System.Drawing.Point(265, 3);
            this.cMCZ.Name = "cMCZ";
            this.cMCZ.Size = new System.Drawing.Size(70, 256);
            this.cMCZ.StyleName = null;
            this.cMCZ.TabIndex = 1;
            this.cMCZ.Title = "Z Axis";
            this.cMCZ.Unit = "mm";
            // 
            // cMCExtruder
            // 
            this.cMCExtruder.AxisSign = "E";
            this.cMCExtruder.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cMCExtruder.FrameColor = System.Drawing.Color.RoyalBlue;
            this.cMCExtruder.Gapx = 0;
            this.cMCExtruder.Gapy = 0;
            this.cMCExtruder.GLBackgroundImage = null;
            this.cMCExtruder.GLVisible = false;
            this.cMCExtruder.GuiAnchor = null;
            this.cMCExtruder.HasHome = false;
            this.cMCExtruder.Location = new System.Drawing.Point(341, 3);
            this.cMCExtruder.Name = "cMCExtruder";
            this.cMCExtruder.Size = new System.Drawing.Size(70, 256);
            this.cMCExtruder.StyleName = null;
            this.cMCExtruder.TabIndex = 2;
            this.cMCExtruder.Title = "Extrude";
            this.cMCExtruder.Unit = "mm";
            // 
            // cMCTilt
            // 
            this.cMCTilt.AxisSign = "T";
            this.cMCTilt.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cMCTilt.FrameColor = System.Drawing.Color.RoyalBlue;
            this.cMCTilt.Gapx = 0;
            this.cMCTilt.Gapy = 0;
            this.cMCTilt.GLBackgroundImage = null;
            this.cMCTilt.GLVisible = false;
            this.cMCTilt.GuiAnchor = null;
            this.cMCTilt.Location = new System.Drawing.Point(417, 3);
            this.cMCTilt.Name = "cMCTilt";
            this.cMCTilt.Size = new System.Drawing.Size(70, 256);
            this.cMCTilt.StyleName = null;
            this.cMCTilt.TabIndex = 3;
            this.cMCTilt.Title = "Tilt";
            this.cMCTilt.Unit = "Deg";
            // 
            // cMCTempExtruder
            // 
            this.cMCTempExtruder.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cMCTempExtruder.FrameColor = System.Drawing.Color.RoyalBlue;
            this.cMCTempExtruder.Gapx = 0;
            this.cMCTempExtruder.Gapy = 0;
            this.cMCTempExtruder.GLBackgroundImage = null;
            this.cMCTempExtruder.GLVisible = false;
            this.cMCTempExtruder.GuiAnchor = null;
            this.cMCTempExtruder.Location = new System.Drawing.Point(493, 3);
            this.cMCTempExtruder.Name = "cMCTempExtruder";
            this.cMCTempExtruder.Size = new System.Drawing.Size(70, 256);
            this.cMCTempExtruder.StyleName = null;
            this.cMCTempExtruder.TabIndex = 4;
            this.cMCTempExtruder.Title = "Heater";
            this.cMCTempExtruder.Unit = "C";
            // 
            // cMCTempPlatform
            // 
            this.cMCTempPlatform.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cMCTempPlatform.FrameColor = System.Drawing.Color.RoyalBlue;
            this.cMCTempPlatform.Gapx = 0;
            this.cMCTempPlatform.Gapy = 0;
            this.cMCTempPlatform.GLBackgroundImage = null;
            this.cMCTempPlatform.GLVisible = false;
            this.cMCTempPlatform.GuiAnchor = null;
            this.cMCTempPlatform.Location = new System.Drawing.Point(569, 3);
            this.cMCTempPlatform.Name = "cMCTempPlatform";
            this.cMCTempPlatform.Size = new System.Drawing.Size(70, 256);
            this.cMCTempPlatform.StyleName = null;
            this.cMCTempPlatform.TabIndex = 5;
            this.cMCTempPlatform.Title = "Platform";
            this.cMCTempPlatform.Unit = "C";
            // 
            // flowData1
            // 
            this.flowData1.Controls.Add(this.ctlOnOffMotors);
            this.flowData1.Controls.Add(this.ctlOnOffHeater);
            this.flowData1.Controls.Add(this.ctlOnOffPlatform);
            this.flowData1.Controls.Add(this.cOnOffMonitorTemp);
            this.flowData1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowData1.Location = new System.Drawing.Point(5, 267);
            this.flowData1.Name = "flowData1";
            this.flowData1.Size = new System.Drawing.Size(209, 230);
            this.flowData1.TabIndex = 1;
            // 
            // ctlOnOffMotors
            // 
            this.ctlOnOffMotors.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ctlOnOffMotors.FrameColor = System.Drawing.Color.RoyalBlue;
            this.ctlOnOffMotors.Gapx = 0;
            this.ctlOnOffMotors.Gapy = 0;
            this.ctlOnOffMotors.GLBackgroundImage = null;
            this.ctlOnOffMotors.GLVisible = false;
            this.ctlOnOffMotors.GuiAnchor = null;
            this.ctlOnOffMotors.Location = new System.Drawing.Point(3, 3);
            this.ctlOnOffMotors.Name = "ctlOnOffMotors";
            this.ctlOnOffMotors.Size = new System.Drawing.Size(202, 30);
            this.ctlOnOffMotors.StyleName = null;
            this.ctlOnOffMotors.TabIndex = 0;
            this.ctlOnOffMotors.Title = "Motors:";
            this.ctlOnOffMotors.StateChange += new UV_DLP_3D_Printer.GUI.CustomGUI.ctlOnOff.StateChangeDelegate(this.ctlOnOffMotors_StateChange);
            // 
            // ctlOnOffHeater
            // 
            this.ctlOnOffHeater.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ctlOnOffHeater.FrameColor = System.Drawing.Color.RoyalBlue;
            this.ctlOnOffHeater.Gapx = 0;
            this.ctlOnOffHeater.Gapy = 0;
            this.ctlOnOffHeater.GLBackgroundImage = null;
            this.ctlOnOffHeater.GLVisible = false;
            this.ctlOnOffHeater.GuiAnchor = null;
            this.ctlOnOffHeater.Location = new System.Drawing.Point(3, 39);
            this.ctlOnOffHeater.Name = "ctlOnOffHeater";
            this.ctlOnOffHeater.Size = new System.Drawing.Size(202, 30);
            this.ctlOnOffHeater.StyleName = null;
            this.ctlOnOffHeater.TabIndex = 1;
            this.ctlOnOffHeater.Title = "Heater:";
            this.ctlOnOffHeater.StateChange += new UV_DLP_3D_Printer.GUI.CustomGUI.ctlOnOff.StateChangeDelegate(this.ctlOnOffHeater_StateChange);
            // 
            // ctlOnOffPlatform
            // 
            this.ctlOnOffPlatform.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ctlOnOffPlatform.FrameColor = System.Drawing.Color.RoyalBlue;
            this.ctlOnOffPlatform.Gapx = 0;
            this.ctlOnOffPlatform.Gapy = 0;
            this.ctlOnOffPlatform.GLBackgroundImage = null;
            this.ctlOnOffPlatform.GLVisible = false;
            this.ctlOnOffPlatform.GuiAnchor = null;
            this.ctlOnOffPlatform.Location = new System.Drawing.Point(3, 75);
            this.ctlOnOffPlatform.Name = "ctlOnOffPlatform";
            this.ctlOnOffPlatform.Size = new System.Drawing.Size(202, 30);
            this.ctlOnOffPlatform.StyleName = null;
            this.ctlOnOffPlatform.TabIndex = 2;
            this.ctlOnOffPlatform.Title = "Platform:";
            this.ctlOnOffPlatform.StateChange += new UV_DLP_3D_Printer.GUI.CustomGUI.ctlOnOff.StateChangeDelegate(this.ctlOnOffPlatform_StateChange);
            // 
            // cOnOffMonitorTemp
            // 
            this.cOnOffMonitorTemp.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cOnOffMonitorTemp.FrameColor = System.Drawing.Color.RoyalBlue;
            this.cOnOffMonitorTemp.Gapx = 0;
            this.cOnOffMonitorTemp.Gapy = 0;
            this.cOnOffMonitorTemp.GLBackgroundImage = null;
            this.cOnOffMonitorTemp.GLVisible = false;
            this.cOnOffMonitorTemp.GuiAnchor = null;
            this.cOnOffMonitorTemp.Location = new System.Drawing.Point(3, 111);
            this.cOnOffMonitorTemp.Name = "cOnOffMonitorTemp";
            this.cOnOffMonitorTemp.Size = new System.Drawing.Size(202, 30);
            this.cOnOffMonitorTemp.StyleName = null;
            this.cOnOffMonitorTemp.TabIndex = 3;
            this.cOnOffMonitorTemp.Title = "Monitor Temp:";
            // 
            // ctlManualControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.flowData1);
            this.Controls.Add(this.flowTop);
            this.Name = "ctlManualControl";
            this.Size = new System.Drawing.Size(652, 502);
            this.flowTop.ResumeLayout(false);
            this.flowData1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowTop;
        private CustomGUI.ctlMCXY cMCXY;
        private CustomGUI.ctlMCZ cMCZ;
        private CustomGUI.ctlMCZ cMCExtruder;
        private CustomGUI.ctlMCZ cMCTilt;
        private CustomGUI.ctlMCTemp cMCTempExtruder;
        private CustomGUI.ctlMCTemp cMCTempPlatform;
        private System.Windows.Forms.FlowLayoutPanel flowData1;
        private CustomGUI.ctlOnOff ctlOnOffMotors;
        private CustomGUI.ctlOnOff ctlOnOffHeater;
        private CustomGUI.ctlOnOff ctlOnOffPlatform;
        private CustomGUI.ctlOnOff cOnOffMonitorTemp;
    }
}
