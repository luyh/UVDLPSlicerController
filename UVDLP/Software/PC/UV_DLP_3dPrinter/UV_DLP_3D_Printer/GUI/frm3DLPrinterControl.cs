using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Device_Interface;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frm3DLPrinterControl : Form
    {
        public frm3DLPrinterControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numContrast_ValueChanged(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_deviceinterface.Driver.DriverType == Drivers.eDriverType.eRF_3DLPRINTER) 
            {
                RobotFactorySRL_3DLPrinter driver = (RobotFactorySRL_3DLPrinter)UVDLPApp.Instance().m_deviceinterface.Driver;
                driver.SetContrast((int)numContrast.Value);
            }
        }

        private void numBrightness_ValueChanged(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_deviceinterface.Driver.DriverType == Drivers.eDriverType.eRF_3DLPRINTER)
            {
                RobotFactorySRL_3DLPrinter driver = (RobotFactorySRL_3DLPrinter)UVDLPApp.Instance().m_deviceinterface.Driver;
                driver.SetBrightness((int)numContrast.Value);
            }
        }

        private void cmdUp_Click(object sender, EventArgs e)
        {
            try
            {
                float mmdist = float.Parse(txtsteps.Text);
                if (UVDLPApp.Instance().m_deviceinterface.Driver.DriverType == Drivers.eDriverType.eRF_3DLPRINTER)
                {
                    RobotFactorySRL_3DLPrinter driver = (RobotFactorySRL_3DLPrinter)UVDLPApp.Instance().m_deviceinterface.Driver;
                    driver.Move(RobotFactorySRL_3DLPrinter.eDirection.eUP, mmdist);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            try
            {
                float mmdist = float.Parse(txtsteps.Text);
                if (UVDLPApp.Instance().m_deviceinterface.Driver.DriverType == Drivers.eDriverType.eRF_3DLPRINTER)
                {
                    RobotFactorySRL_3DLPrinter driver = (RobotFactorySRL_3DLPrinter)UVDLPApp.Instance().m_deviceinterface.Driver;
                    driver.Move(RobotFactorySRL_3DLPrinter.eDirection.eDOWN, mmdist);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
    }
}
