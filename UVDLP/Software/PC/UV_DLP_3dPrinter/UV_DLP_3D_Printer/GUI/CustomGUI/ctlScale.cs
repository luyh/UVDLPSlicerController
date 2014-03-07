using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlScale : ctlUserPanel
    {
        public ctlScale()
        {
            InitializeComponent();
            UVDLPApp.Instance().m_gui_config.AddButton("scale", ctlTitle1.Button);
        }

        protected void ScaleObject(ctlTextBox var, float x, float y, float z)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = var.FloatVal / 100f;
                x = (x == 0) ? 1 : x * val;
                y = (y == 0) ? 1 : y * val;
                z = (z == 0) ? 1 : z * val; 
                UVDLPApp.Instance().SelectedObject.Scale(x, y, z);
                UVDLPApp.Instance().m_undoer.SaveScale(UVDLPApp.Instance().SelectedObject, x, y, z);
                UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
                //ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, "updateobject");

            }
            catch (Exception)
            {

            }
        }

        private void buttScaleAll_Click(object sender, EventArgs e)
        {
            ScaleObject(textScaleAll, 1, 1, 1);
        }

        private void buttScaleX_Click(object sender, EventArgs e)
        {
            ScaleObject(textScaleX, 1, 0, 0);
        }

        private void buttScaleY_Click(object sender, EventArgs e)
        {
            ScaleObject(textScaleY, 0, 1, 0);
        }

        private void buttScaleZ_Click(object sender, EventArgs e)
        {
            ScaleObject(textScaleZ, 0, 0, 1);
        }

        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor != ControlStyle.NullColor)
            {
                //labelManipType.ForeColor = ct.ForeColor;
                ctlTitle1.ForeColor = ct.ForeColor;
                label5.ForeColor = ct.ForeColor;
                label6.ForeColor = ct.ForeColor;
                label7.ForeColor = ct.ForeColor;
                label12.ForeColor = ct.ForeColor;
                textScaleX.ForeColor = ct.ForeColor;
                textScaleY.ForeColor = ct.ForeColor;
                textScaleZ.ForeColor = ct.ForeColor;
                textScaleAll.ForeColor = ct.ForeColor;
            }
            if (ct.BackColor != ControlStyle.NullColor)
            {
                BackColor = ct.BackColor;
                ctlTitle1.BackColor = ct.BackColor;
                manipObject.BackColor = ct.BackColor;
                textScaleX.BackColor = ct.BackColor;
                textScaleY.BackColor = ct.BackColor;
                textScaleZ.BackColor = ct.BackColor;
                textScaleAll.BackColor = ct.BackColor;
            }
            if (ct.FrameColor != ControlStyle.NullColor)
            {
                flowLayoutPanel1.BackColor = ct.FrameColor;
                flowLayoutPanel4.BackColor = ct.FrameColor;
                flowLayoutPanel3.BackColor = ct.FrameColor;
                flowLayoutPanel5.BackColor = ct.FrameColor;
            }

        }

        private void ctlTitle1_Click(object sender, EventArgs e)
        {
            if (ctlTitle1.Checked)
            {
                this.Height = 225 + 5;
            }
            else
            {
                this.Height = ctlTitle1.Height + 5;
            }
        }

    }
}
