using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Drivers;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class MachineControl : UserControl
    {
        StringBuilder sb;
        public MachineControl()
        {
            InitializeComponent();
            //UVDLPApp.Instance().m_deviceinterface.DataEvent += new DeviceInterface.DeviceDataReceived(DataReceived);
            UVDLPApp.Instance().m_deviceinterface.LineDataEvent += new DeviceInterface.DeviceLineReceived(LineDataReceived);
            sb = new StringBuilder();
        }
        private void cmdUp_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdist.Text);
                UVDLPApp.Instance().m_deviceinterface.Move(dist, GetZFeed()); // (movecommand);
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
                dist *= -1.0;
                UVDLPApp.Instance().m_deviceinterface.Move(dist, GetZFeed()); // (movecommand);
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
                UVDLPApp.Instance().m_deviceinterface.MoveX(dist, GetXYFeed()); //
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
                UVDLPApp.Instance().m_deviceinterface.MoveX(dist, GetXYFeed()); //
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }
        }

        private double GetZFeed()
        {
            try
            {
                double rate = double.Parse(txtRateZ.Text);
                return rate;
            }
            catch (Exception ex)
            {
                return 100.0;
            }
        }

        private double GetXYFeed()
        {
            try
            {
                double rate = double.Parse(txtRateXY.Text);
                return rate;
            }
            catch (Exception ex)
            {
                return 100.0;
            }
        }
        private void cmdYUp_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdistXY.Text);
                UVDLPApp.Instance().m_deviceinterface.MoveY(dist, GetXYFeed()); //
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
                UVDLPApp.Instance().m_deviceinterface.MoveY(dist, GetXYFeed()); //
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }

        }


        private void cmdZHome_Click(object sender, EventArgs e)
        {
            String command = "G28 Z0\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(command);

        }

        private void cmdMotorsOn_Click(object sender, EventArgs e)
        {
            string gcode = "M17\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(gcode);
        }

        private void cmdMotorsOff_Click(object sender, EventArgs e)
        {
            string gcode = "M18\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(gcode);
        }

        private void cmdExtrude1_Click(object sender, EventArgs e)
        {
            try
            {
                int len = int.Parse(txtExtrudeLen.Text);
                string cmd = "G1 E" + len + "\r\n";
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(cmd);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdReverse_Click(object sender, EventArgs e)
        {
            try
            {
                int len = int.Parse(txtExtrudeLen.Text);
                len *= -1;
                string cmd = "G1 E" + len + "\r\n"; 
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(cmd);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdXHome_Click(object sender, EventArgs e)
        {
            //UVDLPApp.Instance().m_deviceinterface.HomeAxis(DeviceInterface.eHomeAxis.eX);
            String command = "G28 X0\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(command);
        }

        private void cmdYHome_Click(object sender, EventArgs e)
        {
            //UVDLPApp.Instance().m_deviceinterface.HomeAxis(DeviceInterface.eHomeAxis.eY);
            String command = "G28 Y0\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(command);
        }
        void LineDataReceived(DeviceDriver driver, string line)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { LineDataReceived(driver, line); }));
            }
            else
            {
                line = line.Trim();
                //sb.Insert(0, line);
                txtReceived.Text += line + "\r\n";
                //txtReceived.Refresh();
            }

        }
        void DataReceived(DeviceDriver driver, byte[] data, int len)
        {
            /*
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { DataReceived(driver, data, len); }));
            }
            else
            {
                String s = ASCIIEncoding.ASCII.GetString(data);
                String rec = txtReceived.Text;
                txtReceived.Text = s + "\r\n" + rec;
            }
             * */
        }
        private void cmdSendGCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(txtGCode.Text + "\r\n"))
                {
                    txtSent.Text = txtGCode.Text + "\r\n" + txtSent.Text;
                }
                else
                {
                    DebugLogger.Instance().LogRecord("Could Not Send Raw GCode Command");
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
    }
}
