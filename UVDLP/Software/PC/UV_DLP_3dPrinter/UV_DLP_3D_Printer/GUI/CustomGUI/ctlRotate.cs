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
    public partial class ctlRotate : ctlUserPanel
    {
        public ctlRotate()
        {
            InitializeComponent();
        }

        protected void RotateObject(ctlTextBox var, float x, float y, float z)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = var.FloatVal * 0.0174532925f;
                x *= val;
                y *= val;
                z *= val;
                UVDLPApp.Instance().SelectedObject.Rotate(x,y,z);
                UVDLPApp.Instance().m_undoer.SaveRotation(UVDLPApp.Instance().SelectedObject, x, y, z);
                UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
                //ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }


        private void buttRotateXMinus_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateX, -1, 0, 0);
        }

        private void buttRotateYMinus_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateY, 0, -1, 0);
        }

        private void buttRotateZMinus_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateZ, 0, 0, -1);
        }

        private void buttRotateXPlus_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateX, 1, 0, 0);
        }

        private void buttRotateYPlus_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateY, 0, 1, 0);
        }

        private void buttRotateZPlus_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateZ, 0, 0, 1);
        }
    }
}
