using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlMainConfig : UserControl
    {
        private enum eConfView 
        {
            eSlice,
            eMachine
        }
        private eConfView m_eView;

        public ctlMainConfig()
        {
            InitializeComponent();            
            RegisterCallbacks();
            HideControls();
            SetupView(eConfView.eSlice);
        }
        private void HideControls() 
        {
            ctlMachineConfig1.Dock = DockStyle.None;
            ctlMachineConfig1.Visible = false;
            ctlToolpathGenConfig1.Dock = DockStyle.None;
            ctlToolpathGenConfig1.Visible = false;

        }
        private void SetupView(eConfView view) 
        {
            HideControls();
            m_eView = view;
            switch (m_eView)
            {
                case eConfView.eSlice:
                    ctlToolpathGenConfig1.Dock = DockStyle.Fill;
                    ctlToolpathGenConfig1.Visible = true;
                    break;
                case eConfView.eMachine:
                    ctlMachineConfig1.Dock = DockStyle.Fill;
                    ctlMachineConfig1.Visible = true;
                    break;
            }
        }
        private void RegisterCallbacks() 
        {
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickViewConfMachine", ClickViewConfMachine, null, "View Machine Configuration");
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickViewSliceConfig", ClickViewSliceConfig, null, "View Slicing Configuration");
        
        }
        private void ClickViewConfMachine(object sender, object vars) 
        {
            SetupView(eConfView.eMachine);
        }
        private void ClickViewSliceConfig(object sender, object vars)
        {
            SetupView(eConfView.eSlice);
        }
    }
}
