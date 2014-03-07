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
    }
}
