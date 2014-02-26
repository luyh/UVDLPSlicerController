using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlProjectorControl : ctlAnchorable
    {
        public ctlProjectorControl()
        {
            InitializeComponent();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            UpdateProjectorCommands();
            UpdateProjConnected();
        }

        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor != ControlStyle.NullColor)
            {
            }
            if (ct.BackColor != ControlStyle.NullColor)
            {
                BackColor = ct.BackColor;
            }
            if (ct.FrameColor != ControlStyle.NullColor)
            {
            }
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
                    case eAppEvent.eDisplayConnected:
                    case eAppEvent.eDisplayDisconnected:
                        UpdateProjConnected();
                        break;
                }
            }
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

        private void cmdShowCalib_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eShowCalib, "Show Calibration");
        }

        private void cmdShowBlank_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eShowBlank, "Show Blank");
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
    }
}
