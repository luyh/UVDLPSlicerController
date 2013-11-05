using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Slicing;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmVolEst : Form
    {
        public frmVolEst()
        {
            InitializeComponent();
            UVDLPApp.Instance().m_estimator.VolEstEventDel += new VolumeEstimator.VolEstEvent(VolEstEventF);
        }
        private void VolEstEventF(VolumeEstimator.eVolEstEvent ev, string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { VolEstEventF(ev, message); }));
            }
            else
            {
                // show final estimate
                switch (ev)
                {
                    case VolumeEstimator.eVolEstEvent.eCompleted:
                        lblmess.Text = "";
                        Close();
                        break;
                    case VolumeEstimator.eVolEstEvent.eTick:
                        string []toks = message.Split(':');
                        int val = int.Parse(toks[0]);
                        lblmess.Text = "Scanning Slice " + val.ToString();
                        progressBar1.Value = val;
                        break;
                    case VolumeEstimator.eVolEstEvent.eCancelled:
                        lblmess.Text = "Estimate Cancelled";
                        progressBar1.Value = 0;;
                        break;
                    case VolumeEstimator.eVolEstEvent.eStarted:
                        int numslice = int.Parse(message);
                        lblmess.Text = "Estimate Started";
                        progressBar1.Maximum = numslice;
                        progressBar1.Value = 0;
                        break;
                }
            }
        }
        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (cmdStart.Text.Contains("Start"))
            {
                UVDLPApp.Instance().m_estimator.StartEstimate();
                cmdStart.Text = "Cancel";
            }
            else 
            {
                UVDLPApp.Instance().m_estimator.Cancel();
                cmdStart.Text = "Start";
                //cancelling

            }
        }
    }
}
