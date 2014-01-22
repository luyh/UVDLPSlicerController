using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI;
using UV_DLP_3D_Printer.GUI.Controls;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Set3DviewControl(ctl3DView c3d)
        {
            c3d.Event3DViewRedraw += new ctl3DView.On3dViewRedraw(c3d_Event3DViewRedraw);
        }

        void c3d_Event3DViewRedraw()
        {
            Invalidate();
        }

    }
}
