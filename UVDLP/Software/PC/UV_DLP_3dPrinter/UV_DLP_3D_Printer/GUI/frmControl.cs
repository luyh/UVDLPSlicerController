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
    public partial class frmControl : Form
    {
        public frmControl()
        {
            InitializeComponent();
        }

        private void cmdUp_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdist.Text);
                UVDLPApp.Instance().m_deviceinterface.Move(dist, UVDLPApp.Instance().m_printerinfo.ZMaxFeedrate); // (movecommand);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdist.Text);
                dist = dist * -1.0;
                UVDLPApp.Instance().m_deviceinterface.Move(dist, UVDLPApp.Instance().m_printerinfo.ZMaxFeedrate); //
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }
        }

        private void cmdXUp_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdistXY.Text);
                UVDLPApp.Instance().m_deviceinterface.MoveX(dist, UVDLPApp.Instance().m_printerinfo.XMaxFeedrate); //
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }
        }

        private void cmdXDown_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdistXY.Text);
                dist = dist * -1.0;
                UVDLPApp.Instance().m_deviceinterface.MoveX(dist, UVDLPApp.Instance().m_printerinfo.XMaxFeedrate); //
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }
        }

        private void cmdYUp_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdistXY.Text);
                UVDLPApp.Instance().m_deviceinterface.MoveY(dist, UVDLPApp.Instance().m_printerinfo.YMaxFeedrate); //
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }

        }

        private void cmdYDown_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdistXY.Text);
                dist = dist * -1.0;
                UVDLPApp.Instance().m_deviceinterface.MoveY(dist, UVDLPApp.Instance().m_printerinfo.YMaxFeedrate); //
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }

        }
    }
}
