using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlManualControl : ctlUserPanel
    {
        NumericUpDown zrate, xyrate;
        public ctlManualControl()
        {
            InitializeComponent();
            ApplyStyle(Style);
            cMCXY.Visible = false;
            cMCZ.Visible = false;
            cMCTempExtruder.Visible = false;
            cMCTempPlatform.Visible = false;
            cOnOffMonitorTemp.Visible = false;
            cGCodeManual.Visible = false;
            cMCTilt.ReturnValues = new float[] { 1, 10, 360 };
            zrate = ctlParamZrate.Parameter;
            xyrate = ctlParamXYrate.Parameter;
        }

        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            flowTop.BackColor = ct.BackColor;
            flowData1.BackColor = ct.BackColor;
        }

        CallbackHandler Callback
        {
            get { return UVDLPApp.Instance().m_callbackhandler; }
        }

        void FitSize()
        {
            PackFlowPanelRecurse(flowMain);

            Size = new Size(flowMain.Width+flowMain.Margin.Left + flowMain.Margin.Right, 
                flowMain.Height + flowMain.Margin.Top + flowMain.Margin.Bottom);
        }

        void PackFlowPanelRecurse(FlowLayoutPanel flp)
        {
            foreach (Control ctl in flp.Controls)
            {
                if (ctl is FlowLayoutPanel)
                    PackFlowPanelRecurse((FlowLayoutPanel)ctl);
            }
            PackFlowPanel(flp);
        }

        void PackFlowPanel(FlowLayoutPanel flp)
        {
            int w = 0;
            int h = 0;
            foreach (Control ctl in flp.Controls)
            {
                int cw = ctl.Width + ctl.Margin.Left + ctl.Margin.Right;
                int ch = ctl.Height + ctl.Margin.Top + ctl.Margin.Bottom;
                if (ctl.Visible)
                {
                    if ((flp.FlowDirection == FlowDirection.LeftToRight) || (flp.FlowDirection == FlowDirection.RightToLeft))
                    {
                        w += cw;
                        if (h < ch) h = ch;
                    }
                    else
                    {
                        if (w < cw) w = cw;
                        h += ch;
                    }
                }
            }
            if ((w == 0) || (h == 0))
            {
                flp.Visible = false;
            }
            else
            {
                flp.Visible = true;
                flp.Width = w + flp.Padding.Left + flp.Padding.Right;
                flp.Height = h + flp.Padding.Top + flp.Padding.Bottom;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if ((Parent != null) && (Parent.BackColor != null))
            {
                foreach (Control ctl in flowLeft.Controls)
                    ctl.BackColor = Parent.BackColor;
                foreach (Control ctl in flowBot.Controls)
                    ctl.BackColor = Parent.BackColor;
                foreach (Control ctl in flowTop.Controls)
                    ctl.BackColor = Parent.BackColor;
            }
            FitSize();
            try
            {
                double res = (double)Callback.Activate("MCCmdGetZRate");
                ctlParamZrate.Value = (decimal)res;
                res = (double)Callback.Activate("MCCmdGetXYRate");
                ctlParamXYrate.Value = (decimal)res;
            }
            catch {}
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if ((Parent == null) || (Parent.BackColor == null))
            {
                base.OnPaintBackground(e);
                return;
            }
            Brush br = new SolidBrush(Parent.BackColor);
            e.Graphics.FillRectangle(br, 0, 0, Width, Height);
        }

        private void ctlOnOffMotors_StateChange(object obj, bool state)
        {
            cMCXY.Visible = state;
            cMCZ.Visible = state;
            FitSize();
        }

        private void ctlOnOffHeater_StateChange(object obj, bool state)
        {
            cMCTempExtruder.Visible = state;
            cOnOffMonitorTemp.Visible = state || ctlOnOffPlatform.IsOn;
            FitSize();
        }

        private void ctlOnOffPlatform_StateChange(object obj, bool state)
        {
            cMCTempPlatform.Visible = state;
            cOnOffMonitorTemp.Visible = state || ctlOnOffHeater.IsOn;
            FitSize();
        }

        private void ctlParamZrate_ValueChanged(object sender, decimal newval)
        {
            Callback.Activate("MCCmdSetZRate", null, (double)newval);
        }                      

        private void ctlParamXYrate_ValueChanged(object sender, decimal newval)
        {
            Callback.Activate("MCCmdSetXYRate", null, (double)newval);
        }

        private void ctlManGcode_StateChange(object obj, bool state)
        {
            cGCodeManual.Visible = state;
            FitSize();
        }
    }
}
