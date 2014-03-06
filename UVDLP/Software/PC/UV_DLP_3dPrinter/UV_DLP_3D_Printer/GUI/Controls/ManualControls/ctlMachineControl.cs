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
    public partial class ctlMachineControl : UserControl
    {
        public delegate void MachineCtlEvent();
        StringBuilder sb;
        public MachineCtlEvent machEvent;

        public ctlMachineControl()
        {
            InitializeComponent();
            sb = new StringBuilder();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            //SetupForMachineType();
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
                        //SetupForMachineType();
                        break;
                }
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

        private void label14_Click(object sender, EventArgs e)
        {

        }
             
    }
}
