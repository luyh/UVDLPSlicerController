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
            UVDLPApp.Instance().m_supportgenerator.SupportEvent += new SupportGeneratorEvent(SupEvent);
        }
        public void SupEvent(SupportEvent ev, string message, Object obj)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { SupEvent(ev, message,obj); }));
            }
            else
            {
                try
                {
                    switch (ev)
                    {
                        case SupportEvent.eCompleted:
                            //close this dialog
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();
                            break;
                        case SupportEvent.eCancel:
                            break;
                        case SupportEvent.eProgress:
                            // P
                            string[] toks = message.Split('/');
                            int cs = int.Parse(toks[0]);
                            int ts = int.Parse(toks[1]);
                            if (cs == 0) // set up the prog bar on the first step
                            {
                                progressBar1.Maximum = ts;
                            }
                            else
                            {
                                progressBar1.Value = cs;
                            }
                            break;
                        case SupportEvent.eStarted:
                            break;
                        case SupportEvent.eSupportGenerated:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.Instance().LogError(ex.Message);
                }
            }
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
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
           // progressBar1.Value = 0;
            if (GetData())
            {
                cmdOK.Enabled = false;
                //DialogResult = System.Windows.Forms.DialogResult.OK;
               // Close();
                UVDLPApp.Instance().StartAddSupports(); // start the support generation
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
