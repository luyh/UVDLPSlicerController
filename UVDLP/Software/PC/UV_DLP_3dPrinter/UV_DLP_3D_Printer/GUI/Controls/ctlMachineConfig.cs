using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UV_DLP_3D_Printer.Drivers;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlMachineConfig : ctlAnchorable//ctlUserPanel //UserControl
    {
        private eDriverType m_saved;
        private MachineConfig m_config = new MachineConfig(); // just so it's not blank

        public ctlMachineConfig()
        {
            InitializeComponent();            
        }

        private void SetData() 
        {
            try
            {
                //lblMachineName.Text = m_config.m_name;
                grpMachineConfig.Text = m_config.m_name;
                cmbMachineType.Items.Clear();
                foreach(String s in Enum.GetNames(typeof(MachineConfig.eMachineType)))
                {
                    cmbMachineType.Items.Add(s);
                }
                cmbMachineType.SelectedItem = m_config.m_machinetype.ToString();
                m_saved = m_config.m_driverconfig.m_drivertype;

                //list the drivers
                txtPlatWidth.Text = "" + m_config.m_PlatXSize;
                txtPlatHeight.Text = "" + m_config.m_PlatYSize;
                txtPlatTall.Text = m_config.m_PlatZSize.ToString();
                projwidth.Text = "" + m_config.m_monitorconfig.XRes;
                projheight.Text = "" + m_config.m_monitorconfig.YRes;
                //txtXFeed.Text = m_config.XMaxFeedrate.ToString();
                //txtYFeed.Text = m_config.YMaxFeedrate.ToString();
                //txtZFeed.Text = m_config.ZMaxFeedrate.ToString();
                //select the current monitor
                int idx = 0;
                foreach (String s in lstMonitors.Items) 
                {
                    if (s.Equals(m_config.m_monitorconfig.Monitorid)) 
                    {
                        lstMonitors.SelectedIndex = idx;
                    }
                    idx++;
                }
            }
            catch (Exception) 
            {
            
            }
        }
        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            //ct.
            /*if (ct.FrameColor != ControlStyle.NullColor)
                ForeColor = ct.FrameColor;
            if (ct.BackColor != ControlStyle.NullColor)
                BackColor = ct.BackColor;*/
        }

        // clean bad characters from device name -SHS
        private string CleanScreenName(String name)
        {
            int zero_place = name.IndexOf((char)0);
            if (zero_place >= 0)
                name = name.Substring(0,zero_place);
            return name;
        }

        private bool GetData() 
        {
            try
            {
                if (cmbMachineType.SelectedIndex != -1) 
                {
                    m_config.m_machinetype = (MachineConfig.eMachineType)Enum.Parse(typeof(MachineConfig.eMachineType), cmbMachineType.SelectedItem.ToString());
                }
                /*
                if (lstDrivers.SelectedIndex != -1) 
                {
                    m_config.m_driverconfig.m_drivertype = (eDriverType)Enum.Parse(typeof(eDriverType), lstDrivers.SelectedItem.ToString());
                }
                 */ 
                if (m_saved != m_config.m_driverconfig.m_drivertype) 
                {
                    UVDLPApp.Instance().SetupDriver();
                }

                m_config.m_PlatXSize = double.Parse(txtPlatWidth.Text);
                m_config.m_PlatYSize = double.Parse(txtPlatHeight.Text);
                m_config.m_PlatZSize = double.Parse(txtPlatTall.Text);
                m_config.m_monitorconfig.m_XDLPRes = double.Parse(projwidth.Text);
                m_config.m_monitorconfig.m_YDLPRes = double.Parse(projheight.Text);
                //m_config.XMaxFeedrate = double.Parse(txtXFeed.Text);
                //m_config.YMaxFeedrate = double.Parse(txtYFeed.Text);
                //m_config.ZMaxFeedrate = double.Parse(txtZFeed.Text);
                m_config.CalcPixPerMM();
                if (lstMonitors.SelectedIndex != -1)
                {
                    // need to clean device name as it holds some bad characters -SHS
                    m_config.m_monitorconfig.Monitorid = CleanScreenName((Screen.AllScreens[lstMonitors.SelectedIndex].DeviceName));// lstMonitors.Items[lstMonitors.SelectedIndex].ToString();
                }
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
                return false;
            }
        }
        /// <summary>
        /// On apply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GetData())
            {
                //UVDLPApp.Instance().SaveCurrentMachineConfig();
                m_config.Save(m_config.m_filename);
                // if its the current used config, update the system
                if (Path.GetFileNameWithoutExtension(m_config.m_filename) == cmbMachineProfiles.SelectedItem.ToString())
                {
                    ConfigUpdated(m_config.m_filename);
                }
               // Close();
            }
        }

        /*
        private void frmMachineConfig_Load(object sender, EventArgs e)
        {
            SetData();
        }
         * */
        private void FillMonitors()
        {
            try
            {
                lstMonitors.Items.Clear();
                foreach (Screen s in Screen.AllScreens)
                {
                    lstMonitors.Items.Add(CleanScreenName(s.DeviceName));  // -SHS
                }
                if (lstMonitors.Items.Count > 0)
                    lstMonitors.SelectedIndex = 0;
            }
            catch (Exception)
            {

            }

        }

        private void cmdRefreshMonitors_Click(object sender, EventArgs e)
        {
            FillMonitors();
        }

        private void lstMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the projector width and fill in the projwidth and projheight
            if (lstMonitors.SelectedIndex == -1) return;
            try
            {
                projwidth.Text = "" + Screen.AllScreens[lstMonitors.SelectedIndex].Bounds.Width;
                projheight.Text = "" + Screen.AllScreens[lstMonitors.SelectedIndex].Bounds.Height;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }

        }

        private void cmbMachineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // enable/disable the group boxes based on this
                MachineConfig.eMachineType t = (MachineConfig.eMachineType)Enum.Parse(typeof(MachineConfig.eMachineType), cmbMachineType.SelectedItem.ToString());
                switch (t)
                {
                    case MachineConfig.eMachineType.FDM:
                        Monitors.Enabled = false;
                        ProjectorRes.Enabled = false;
                        grpPrjSerial.Enabled = false;
                        break;
                    case MachineConfig.eMachineType.UV_DLP:
                        Monitors.Enabled = true;
                        ProjectorRes.Enabled = true;
                        grpPrjSerial.Enabled = true;
                        break;
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }


        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMachineProfiles.SelectedIndex != -1)
                {
                    if (MessageBox.Show(this, "Are you sure you want to delete this Machine Profile?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                    {
                        //delete file    
                        File.Delete(FNFromIndex(lstMachineProfiles.SelectedIndex));
                        UpdateProfiles();
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
        private void lstMachineProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMachineProfiles.SelectedIndex != -1)
            {
                UpdateButtons();
                // the profile may have changed, 
                if (cmbMachineProfiles.SelectedItem.ToString().Equals(lstMachineProfiles.SelectedItem.ToString()))
                {
                    //we clicked on the current profile
                    m_config = null;
                    m_config = UVDLPApp.Instance().m_printerinfo;
                    SetData(); // show the data
                    UpdateMainConnection();
                    UpdateDisplayConnection();
                }
                else 
                {
                    //load this profile
                    string filename = UVDLPApp.Instance().m_PathMachines + UVDLPApp.m_pathsep + lstMachineProfiles.SelectedItem.ToString() + ".machine";
                    m_config = new MachineConfig();
                    m_config.Load(filename);
                    SetData(); // show the data
                    UpdateMainConnection();
                    UpdateDisplayConnection();
                }
            }
        }
        private void UpdateButtons()
        {
            int idx = lstMachineProfiles.SelectedIndex;
            if (idx == -1)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
            }
        }
        private string FNFromIndex(int idx)
        {
            string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathMachines, "*.machine");
            return filePaths[idx];
        }
        private void UpdateProfiles()
        {
            try
            {
                // get a list of profiles in the /machines directory
                string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathMachines, "*.machine");
                lstMachineProfiles.Items.Clear();
                cmbMachineProfiles.Items.Clear();
                foreach (String profile in filePaths)
                {
                    String pn = Path.GetFileNameWithoutExtension(profile);
                    lstMachineProfiles.Items.Add(pn);
                    cmbMachineProfiles.Items.Add(pn);
                }
                MachineConfig cfg = UVDLPApp.Instance().m_printerinfo;
                cmbMachineProfiles.SelectedItem = cfg.m_name; // show the current profile in the combo box
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                            
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            // create a new profile, give it a name
            frmProfileName fpn = new frmProfileName();
            fpn.ShowDialog();
            String pf = fpn.ProfileName;
            if (pf.Length > 0)
            {
                //create a new profile with that name
                String fn = UVDLPApp.Instance().m_PathMachines;
                fn += UVDLPApp.m_pathsep;
                fn += pf;
                fn += ".machine";
                MachineConfig mc = new MachineConfig();
                mc.m_name = pf;
                if (!mc.Save(fn))
                {
                    DebugLogger.Instance().LogRecord("Error Saving new machine profile " + fn);
                    return;
                }
                UpdateProfiles();
            }
        }

        private void ConfigUpdated(String filename)
        {
            //load and make active
            if (UVDLPApp.Instance().LoadMachineConfig(filename) != true)
            {
                MessageBox.Show("Error loading machine configuration");
                //should try to load/create a valid one
                return;
            }
            UVDLPApp.Instance().SetupDriver();
        }

        /// <summary>
        /// The user is selecting a new machine for the current profile here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMachineProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if(cmbMachineProfiles.SelectedIndex == -1)
                return;

            string filename = UVDLPApp.Instance().m_PathMachines + UVDLPApp.m_pathsep + cmbMachineProfiles.SelectedItem.ToString() + ".machine";
            ConfigUpdated(filename);
        }

        private void ctlMachineConfig_Load(object sender, EventArgs e)
        {
            
            FillMonitors(); // list out the system monitors
            UpdateButtons();
            UpdateProfiles();
            SetData();
            lstMachineProfiles.SelectedItem = cmbMachineProfiles.SelectedItem;
            UpdateMainConnection();
            UpdateDisplayConnection();
        }
        private void UpdateMainConnection() 
        {
            lblConMachine.Text = m_config.m_driverconfig.m_connection.comname;
        }
        private void UpdateDisplayConnection()
        {
            checkConDispEnable.Checked = m_config.m_monitorconfig.m_displayconnectionenabled;
            lblConDisp.Text = m_config.m_monitorconfig.m_displayconnection.comname;
        }
        private void cmdCfgConMch_Click(object sender, EventArgs e)
        {
            frmConnection frmconnect = new frmConnection(ref m_config.m_driverconfig.m_connection);
            frmconnect.ShowDialog();
            UpdateMainConnection();
        }

        private void cmdCfgConDsp_Click(object sender, EventArgs e)
        {
            frmConnection frmconnect = new frmConnection(ref m_config.m_monitorconfig.m_displayconnection);
            frmconnect.ShowDialog();
            UpdateDisplayConnection();
       
        }

        private void checkConDispEnable_CheckedChanged(object sender, EventArgs e)
        {
            m_config.m_monitorconfig.m_displayconnectionenabled = checkConDispEnable.Checked;
        }
    }
}
