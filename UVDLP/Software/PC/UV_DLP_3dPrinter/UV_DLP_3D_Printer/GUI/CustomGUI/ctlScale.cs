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
    public partial class ctlScale : UserControl
    {
        public ctlScale()
        {
            InitializeComponent();
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
                z = (z == 0) ? 1 : x * val;
                UVDLPApp.Instance().SelectedObject.Scale(x, y, z);
                //ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");

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

    }
}
