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
    public partial class ctlMove : UserControl
    {
        public ctlMove()
        {
            InitializeComponent();
        }


        protected void MoveObject(ctlTextBox var, float x, float y, float z)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = var.FloatVal;
                x *= val;
                y *= val;
                z *= val;
                UVDLPApp.Instance().SelectedObject.Translate(x, y, z);
                //ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void buttXMinus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveX, -1, 0, 0);
        }

        private void buttYMinus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveY, 0, -1, 0);
        }

        private void buttZMinus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveZ, 0, 0, -1);
        }

        private void buttXPlus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveX, 1, 0, 0);
        }

        private void buttYPlus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveY, 0, 1, 0);
        }

        private void buttZPlus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveZ, 0, 0, 1);
        }

    }
}
