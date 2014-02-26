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
    public partial class ctlConfig : ctlUserPanel
    {
        public ctlConfig()
        {
            InitializeComponent();
        }
        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor != ControlStyle.NullColor)
            {
                lblTitle.ForeColor = ct.ForeColor;
            }
            if (ct.BackColor != ControlStyle.NullColor)
            {
                BackColor = ct.BackColor;
            }
            if (ct.FrameColor != ControlStyle.NullColor)
            {
                flowLayoutPanel5.BackColor = ct.FrameColor;
            }

        }

        private void ctlImageButton1_Load(object sender, EventArgs e)
        {

        }
    }
}
