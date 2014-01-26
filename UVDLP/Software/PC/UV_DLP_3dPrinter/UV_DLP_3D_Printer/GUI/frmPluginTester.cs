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
    public partial class frmPluginTester : Form
    {
        IPlugin m_ip;
        public frmPluginTester()
        {
            InitializeComponent();
            SetupPlugins();
        }
        public void SetupPlugins() 
        {
            lvplugins.Clear();
            foreach (IPlugin ip in UVDLPApp.Instance().m_plugins)
            {
                lvplugins.Items.Add(ip.Name);
            }
        }
        private void ListContents() 
        {
            if (m_ip == null) return;
            lvcontents.Items.Clear();
            foreach (PluginItem pi in m_ip.GetPluginItems) 
            {
                lvcontents.Items.Add(pi.m_name + " / " + pi.m_type.ToString());
            }
        }
        private void lvplugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = lvplugins.SelectedIndices[0];
                m_ip = UVDLPApp.Instance().m_plugins[idx];
                ListContents();
            }
            catch (Exception ex) 
            {
            
            }
        }

    }
}
