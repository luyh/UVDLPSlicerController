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
    public partial class ctlSupports : UserControl
    {
        public ctlSupports()
        {
            InitializeComponent();
            UVDLPApp.Instance().m_supportgenerator.SupportEvent += new SupportGeneratorEvent(SupEvent);
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
                            progressTitle.Value = 0;
                            progressTitle.Text = "Supports";
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
                                progressTitle.Maximum = ts;
                                progressTitle.Text = "Generating...";
                            }
                            else
                            {
                                progressTitle.Value = cs;
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

        private void buttAddSupport_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().AddSupport();
            UVDLPApp.Instance().SaveSupportConfig(UVDLPApp.Instance().m_appconfig.SupportConfigName);
        }

        private void buttAutoSupport_Click(object sender, EventArgs e)
        {
            try
            {
                //GetData();
                //UVDLPApp.Instance().m_supportconfig = m_sc; // should copy really
                UVDLPApp.Instance().StartAddSupports(); // start the support generation
                UVDLPApp.Instance().SaveSupportConfig(UVDLPApp.Instance().m_appconfig.SupportConfigName);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.StackTrace);
            }

        }

        private void buttSetup_Click(object sender, EventArgs e)
        {
            if (buttSetup.Checked)
            {
                Width = 372;
                Location = new Point(Location.X, Location.Y - (294 - Height));
                Height = 294;
            }
            else
            {
                Width = 170;
                Location = new Point(Location.X, Location.Y + (Height - 96));
                Height = 96;
            }
        }
    }
}
