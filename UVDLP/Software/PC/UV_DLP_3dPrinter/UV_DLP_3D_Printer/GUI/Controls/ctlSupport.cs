using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlSupport : UserControl
    {
        private SupportConfig m_sc;
        public ctlSupport()
        {
            InitializeComponent();
            UVDLPApp.Instance().m_supportgenerator.SupportEvent += new SupportGeneratorEvent(SupEvent);
            //m_sc = new SupportConfig();
            m_sc = UVDLPApp.Instance().m_supportconfig; // should copy really
            SetData();
        }
        private void SetData()
        {
            try
            {
                numFB.Value = (decimal)m_sc.fbrad;
                numFT.Value = (decimal)m_sc.ftrad;
                numHB.Value = (decimal)m_sc.hbrad;
                numHT.Value = (decimal)m_sc.htrad;
                numFB1.Value = (decimal)m_sc.fbrad2;
                numX.Value = (decimal)m_sc.xspace;
                numY.Value = (decimal)m_sc.yspace;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        private bool GetData()
        {
            try
            {
                m_sc.fbrad = (double)numFB.Value;
                m_sc.ftrad = (double)numFT.Value;
                m_sc.hbrad = (double)numHB.Value;
                m_sc.htrad = (double)numHT.Value;
                m_sc.fbrad2 = (double)numFB1.Value;
                m_sc.xspace = (double)numX.Value;
                m_sc.yspace = (double)numY.Value;
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
        }
        public void SupEvent(SupportEvent ev, string message, Object obj)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { SupEvent(ev, message, obj); }));
            }
            else
            {
                try
                {
                    switch (ev)
                    {
                        case SupportEvent.eCompleted:
                            //close this dialog
                            progressBar1.Value = 0;
                            //DialogResult = System.Windows.Forms.DialogResult.OK;
                            //Close();
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

        private void cmdAutoSupport_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
                UVDLPApp.Instance().m_supportconfig = m_sc; // should copy really
                UVDLPApp.Instance().StartAddSupports(); // start the support generation
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
            UVDLPApp.Instance().AddSupport();
        }

        private void chkDownPolys_CheckedChanged(object sender, EventArgs e)
        {
            // tell the 3d engine to only show polygons from objects that are facing downward at the specified angle
        }
    }
}
