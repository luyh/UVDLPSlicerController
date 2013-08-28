using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmAuto3dSupport : Form
    {
        private SupportConfig m_sc;
        public frmAuto3dSupport(ref SupportConfig sc)
        {
            m_sc = sc;
            InitializeComponent();
            SetData();
        }
        private void SetData() 
        {
            txtBRad.Text = m_sc.brad.ToString();
            txtTRad.Text = m_sc.trad.ToString();
            txtXS.Text = m_sc.xspace.ToString();
            txtYS.Text = m_sc.yspace.ToString();
        }
        private bool GetData() 
        {
            try
            {
                m_sc.brad = double.Parse(txtBRad.Text);
                m_sc.trad = double.Parse(txtTRad.Text);
                m_sc.xspace = double.Parse(txtXS.Text);
                m_sc.yspace = double.Parse(txtYS.Text);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GetData())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else 
            {
                MessageBox.Show("Please check values");
            }
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
