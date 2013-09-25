using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmPrefs : Form
    {
        public frmPrefs()
        {
            InitializeComponent();
            SetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                lblSlic3rlocation.Text = openFileDialog1.FileName;
            }
        }
        private void SetData() 
        {
            lblSlic3rlocation.Text = UVDLPApp.Instance().m_appconfig.m_slic3rloc;
        }
        private void GetData() 
        {
            UVDLPApp.Instance().m_appconfig.m_slic3rloc = lblSlic3rlocation.Text;
            UVDLPApp.Instance().SaveAppConfig();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            GetData();
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
