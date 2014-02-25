using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Drivers;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlMachineControl : ctlAnchorable//UserControl
    {
        public delegate void MachineCtlEvent();
        StringBuilder sb;
        public MachineCtlEvent machEvent;

        public ctlMachineControl()
        {
            InitializeComponent();
            // the data received should be dis-abled during prints and re-enabled when not printing
            UVDLPApp.Instance().m_deviceinterface.LineDataEvent += new DeviceInterface.DeviceLineReceived(LineDataReceived);
            sb = new StringBuilder();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            SetupForMachineType();
            UpdateProjConnected();
            UpdateProjectorCommands();
            RegisterCallbacks();
        }

        #region Callbacks
        void RegisterCallbacks()
        {
            CallbackHandler cb = UVDLPApp.Instance().m_callbackhandler;
            cb.RegisterCallback("MCCmdSetZDist", SetZdist, typeof(double), "Set distanse (zdist) in mm for manual up/down movement");
            cb.RegisterCallback("MCCmdMoveUp", cmdUp_Click, null, "Move print head up zdist amount");
            cb.RegisterCallback("MCCmdMoveDown", cmdDown_Click, null, "Move print head down zdist amount");
            //cb.RegisterCallback("", , null, "");
        }

        void SetZdist(object sender, object vars)
        {
            double dist = (double)vars;
            txtdist.Text = vars.ToString();
        }

        #endregion

        private void AppEventDel(eAppEvent ev, String Message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { AppEventDel(ev, Message); }));
            }
            else
            {
                switch (ev)
                {
                    case eAppEvent.eMachineTypeChanged:
                        SetupForMachineType();
                        break;
                    case eAppEvent.eDisplayConnected:
                    case eAppEvent.eDisplayDisconnected:
                        UpdateProjConnected();
                        break;
                }
            }
        }
        private void SetupForMachineType()
        {
            if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP)
            {
                grpExtrudeControls.Enabled = false;
                groupBox2.Enabled = false;
            }
            else if (UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.FDM)
            {
                grpExtrudeControls.Enabled = true;
                groupBox2.Enabled = true;
            }

        }
        #region X/Y/Z Axis Controls
        /// <summary>
        /// Z Axis Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUp_Click(object sender, object e)
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
        /// <summary>
        /// Z Axis Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDown_Click(object sender, object e)
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
        /// <summary>
        /// X Axis Increase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// X Axis Decrease
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Get the Z axis feed rate for movement
        /// </summary>
        /// <returns></returns>
        private double GetZFeed()
        {
            try
            {
                double rate = double.Parse(txtRateZ.Text);
                return rate;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Z Feed Rate");
                DebugLogger.Instance().LogError(ex.Message);
                return 100.0;
            }
        }
        /// <summary>
        /// Get the X/Y axis feed rate for movements
        /// </summary>
        /// <returns></returns>
        private double GetXYFeed()
        {
            try
            {
                double rate = double.Parse(txtRateXY.Text);
                return rate;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                MessageBox.Show("Invalid X/Y Feed Rate");
                return 100.0;
            }
        }

        #endregion

        #region Motors Enable/Disable
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
        #endregion

        #region Homing
        /// <summary>
        /// Home all axises
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdHomeAll_Click(object sender, EventArgs e)
        {
            String command = "G28\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(command);

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

        private void cmdZHome_Click(object sender, EventArgs e)
        {
            String command = "G28 Z0\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(command);

        }
        #endregion // Homing

        /// <summary>
        /// When the build is started, we need to stop listening in on GCode commands,
        /// otherwise this control will be flooded with GCode messages
        /// it's trying to display, and will become un-responsive
        /// </summary>
        public void BuildStarted() 
        {
            UVDLPApp.Instance().m_deviceinterface.LineDataEvent -= new DeviceInterface.DeviceLineReceived(LineDataReceived);
        }
        /// <summary>
        /// This will re-enable the ability to see sent GCode commands
        /// </summary>
        public void BuildStopped() 
        {
            UVDLPApp.Instance().m_deviceinterface.LineDataEvent += new DeviceInterface.DeviceLineReceived(LineDataReceived);
        }

        /// <summary>
        /// Disables/enables items based on up to date configuration) -SHS
        /// </summary>
        public void UpdateControl()
        {
            if (UVDLPApp.Instance().m_printerinfo.m_monitorconfig.m_displayconnectionenabled == false)
            {
                cmdConnect.Enabled = false;
                cmdSendProj.Enabled = false;
            }
            else
            {
                cmdConnect.Enabled = true;
                cmdSendProj.Enabled = true;
            }

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

        #region EXTRUSION
        private double getToolRate(int tool) 
        {
            double rate = 100;
            try
            {
                switch (tool) 
                {
                    case 0:
                        rate = (double)udTool0Rate.Value;
                        break;
                    case 1:
                        rate = (double)udTool1Rate.Value;
                        break;
                }
                return rate;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Check Tool " + tool + " rate; " + ex.Message);
                DebugLogger.Instance().LogError(ex.Message);
                return rate;
            }
        }
        private void cmdExtrude1_Click(object sender, EventArgs e)
        {
            try
            {
                int len = (int)udext0len.Value;///int.Parse(txtExtrudeLen.Text);
                string cmd = "G1 E" + len + " F" + getToolRate(0) +"\r\n"; // should specify a feed rate too
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice("T0\r\n"); // select tool head 0
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice("M83\r\n"); // set to relative extrusion
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
                int len = (int)udext0len.Value;
                len *= -1;
                string cmd = "G1 E" + len +" F" + getToolRate(0) +"\r\n";
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice("T0\r\n"); // select tool head 0
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice("M83\r\n");
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(cmd);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdExtrude2_Click(object sender, EventArgs e)
        {
            try
            {
                int len = (int)udext1len.Value;
                string cmd = "G1 E" + len + " F" + getToolRate(1) +"\r\n"; // should specify a feed rate too
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice("T1\r\n"); // select tool head 1
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice("M83\r\n"); // set to relative extrusion
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(cmd);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdReverse2_Click(object sender, EventArgs e)
        {
            try
            {
                int len = (int)udext1len.Value;
                len *= -1;
                string cmd = "G1 E" + len + " F" + getToolRate(1) + "\r\n";
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice("T1\r\n"); // select tool head 1
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice("M83\r\n");
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(cmd);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        #endregion //extrusion

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtReceived.Text = "";
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cmdShowCalib_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eShowCalib,"Show Calibration");
        }

        private void cmdShowBlank_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eShowBlank, "Show Blank");
        }

        private void cmdEditPC_Click(object sender, EventArgs e)
        {
            frmProjCommand frm = new frmProjCommand();
            frm.ShowDialog();
            frm.Dispose();
            // now update list of commands
            UpdateProjectorCommands();
        }
        private void UpdateProjectorCommands() 
        {
            try
            {
                cmbCommands.Items.Clear();
                foreach (ProjectorCommand cmd in UVDLPApp.Instance().m_proj_cmd_lst.m_commands)
                {
                    cmbCommands.Items.Add(cmd.name);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        private void UpdateProjConnected() 
        {
            try
            {
                if (UVDLPApp.Instance().m_deviceinterface.ConnectedProjector)
                {
                    cmdConnect.Text = "Disconnect Monitor";
                }
                else
                {
                    cmdConnect.Text = "Connect Monitor";
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            //UVDLPApp.Instance().m_deviceinterface.Configure(UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection);
            if (UVDLPApp.Instance().m_deviceinterface.ConnectedProjector == false)
            {
                UVDLPApp.Instance().m_deviceinterface.ConfigureProjector(UVDLPApp.Instance().m_printerinfo.m_monitorconfig.m_displayconnection);
                if (UVDLPApp.Instance().m_deviceinterface.ConnectProjector())
                {
                    UpdateProjConnected();
                }
            }
            else 
            {
                UVDLPApp.Instance().m_deviceinterface.DisconnectProjector();
                UpdateProjConnected();
            }
        }

        private void cmdHide_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eHideDLP, "Hide DLP");
        }

        private void cmdSendProj_Click(object sender, EventArgs e)
        {
            try
            {
                // get the index from the combo box
                int idx = cmbCommands.SelectedIndex;
                if (idx == -1) return;
                ProjectorCommand cmd = UVDLPApp.Instance().m_proj_cmd_lst.m_commands[idx];
                byte[] dat = cmd.GetBytes();
                if (dat != null) 
                {
                    UVDLPApp.Instance().m_deviceinterface.DriverProjector.Write(dat, dat.Length);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdGetPosition_Click(object sender, EventArgs e)
        {
            String command = "M114\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(command);
        }
    }
}
