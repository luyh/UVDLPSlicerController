using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.Controls;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmSliceView : Form
    {
        public frmSliceView()
        {
            InitializeComponent();
        }

        public ctlSliceView SliceView
        {
            get { return ctlSliceView1; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
