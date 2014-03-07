using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine3D;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlMirror : UserControl
    {
        public ctlMirror()
        {
            InitializeComponent();
        }
        private void ctlTitle1_Click(object sender, EventArgs e)
        {
            if (ctlTitle1.Checked)
            {
                this.Height = 121 + 5;
            }
            else
            {
                this.Height = ctlTitle1.Height + 5;
            }
        }

        private void lblX_Click(object sender, EventArgs e)
        {
            Object3d o = UVDLPApp.Instance().SelectedObject;
            if (o != null) 
            {
                o.Scale(-1.0f, 1.0f, 1.0f);
                o.FlipWinding(); 
                o.Update();
            }
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }

        private void lblY_Click(object sender, EventArgs e)
        {
            Object3d o = UVDLPApp.Instance().SelectedObject;
            if (o != null)
            {
                o.Scale(1.0f, -1.0f, 1.0f);
                o.FlipWinding();
                o.Update();
            }
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }

        private void lblZ_Click(object sender, EventArgs e)
        {
            Object3d o = UVDLPApp.Instance().SelectedObject;
            if (o != null)
            {
                o.Scale(1.0f, 1.0f, -1.0f);
                o.FlipWinding();
                o.Update();
            }
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }
    }
}
