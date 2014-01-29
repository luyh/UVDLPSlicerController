using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Plugin;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmPluginManager : Form
    {
        PluginEntry ipsel;
        public frmPluginManager()
        {
            InitializeComponent();
            SetupPlugins();
            ipsel = null;
            UpdateButtons();
        }
        public void SetupPlugins()
        {
            lvplugins.Items.Clear();
            foreach (PluginEntry ip in UVDLPApp.Instance().m_plugins)
            {
                ListViewItem lvi = new ListViewItem(ip.m_plugin.Name);
                lvi.SubItems.Add(ip.m_enabled.ToString());
                lvi.SubItems.Add(ip.m_licensed.ToString());
                lvi.SubItems.Add(ip.m_plugin.GetString("Version"));
                lvi.SubItems.Add(ip.m_plugin.GetString("Description"));
                lvplugins.Items.Add(lvi);
            }
        }

        private void UpdateButtons() 
        {
            if (ipsel == null)
            {
                cmdEnable.Enabled = false;
                return;
            }
            else 
            {
                cmdEnable.Enabled = true;            
            }

            if (ipsel.m_enabled)
            {
                cmdEnable.Text = "Disable";
            }
            else 
            {
                cmdEnable.Text = "Enable";
            }
            if (ipsel.m_licensed)
            {
                cmdLicense.Enabled = false;
            }
            else 
            {
                cmdLicense.Enabled = true;
            }
        }

        private void lvplugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvplugins.SelectedIndices.Count >0 )
            {
                int idx = lvplugins.SelectedIndices[0];
                ipsel = UVDLPApp.Instance().m_plugins[idx];
                UpdateButtons();
            }
        }

        private void cmdEnable_Click(object sender, EventArgs e)
        {
            if (cmdEnable.Text == "Disable")
            {
                ipsel.m_enabled = false;
            }
            else 
            {
                ipsel.m_enabled = true;
            }
            UpdateButtons();
            SetupPlugins();
            ipsel = null;
            UpdateButtons();
        }

        private void cmdLicense_Click(object sender, EventArgs e)
        {

        }
    }
}
