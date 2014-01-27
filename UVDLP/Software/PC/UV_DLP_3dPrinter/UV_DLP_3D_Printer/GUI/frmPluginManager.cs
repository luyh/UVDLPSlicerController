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
        public frmPluginManager()
        {
            InitializeComponent();
            SetupPlugins();
        }
        public void SetupPlugins()
        {
            lvplugins.Clear();
            foreach (IPlugin ip in UVDLPApp.Instance().m_plugins)
            {
                ListViewItem lvi = new ListViewItem(ip.Name);
                lvi.SubItems.Add("test");
                lvi.SubItems.Add("test");
                lvi.SubItems.Add("test");
                lvplugins.Items.Add(lvi);
            }
        }
    }
}
