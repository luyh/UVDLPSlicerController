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
using UV_DLP_3D_Printer.Device_Interface;

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
            sb = new StringBuilder();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            SetupForMachineType();
           // RegisterCallbacks();
            SetData();
        }
        /// <summary>
        /// This Sets the data from the manual control singleton
        /// </summary>
        private void SetData() 
        {
            txtdist.Text = ManualControl.Instance().ZDist.ToString();
            txtRateZ.Text = ManualControl.Instance().ZRate.ToString();
            txtRateXY.Text = ManualControl.Instance().XYRate.ToString();
            txtdistXY.Text = ManualControl.Instance().XYDist.ToString();
        }
        /// <summary>
        /// This gets the data from the form and sets the manual control singleton
        /// </summary>
        private void GetData() 
        {
            try
            {
                ManualControl.Instance().ZDist = double.Parse(txtdist.Text);
                ManualControl.Instance().ZRate = double.Parse(txtRateZ.Text);
                ManualControl.Instance().XYDist = double.Parse(txtdistXY.Text);
                ManualControl.Instance().XYRate = double.Parse(txtRateXY.Text);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }

        }
        
        
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
                GetData();
                UVDLPApp.Instance().m_deviceinterface.Move(ManualControl.Instance().ZDist,ManualControl.Instance().ZRate); 
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
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
                UVDLPApp.Instance().m_deviceinterface.Move(-ManualControl.Instance().ZDist, ManualControl.Instance().ZRate);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
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
                UVDLPApp.Instance().m_deviceinterface.MoveX(ManualControl.Instance().XYDist, ManualControl.Instance().XYRate); 
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
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
                UVDLPApp.Instance().m_deviceinterface.MoveX(-ManualControl.Instance().XYDist, ManualControl.Instance().XYRate);

            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }


        private void cmdYUp_Click(object sender, EventArgs e)
        {
            try
            {
                UVDLPApp.Instance().m_deviceinterface.MoveY(ManualControl.Instance().XYDist, ManualControl.Instance().XYRate);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }

        }

        private void cmdYDown_Click(object sender, EventArgs e)
        {
            try
            {
                UVDLPApp.Instance().m_deviceinterface.MoveY(-ManualControl.Instance().XYDist, ManualControl.Instance().XYRate);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
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

      

        private void label14_Click(object sender, EventArgs e)
        {

        }
             
        private void cmdGetPosition_Click(object sender, EventArgs e)
        {
            String command = "M114\r\n";
            UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(command);
        }
    }
}
