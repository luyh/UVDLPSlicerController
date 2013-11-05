using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Slicing;
using UV_DLP_3D_Printer.Slicing.Modules;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmFlexSliceOptions : Form
    {
        public frmFlexSliceOptions()
        {
            InitializeComponent();
            SetupModules();
            //SetupParms();
            dgModules.CurrentCellChanged += new EventHandler(dgModules_CurrentCellChanged);
        }

        void dgModules_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                //SetupModules();
                SetupParms();
            }
            catch (Exception) { }
            
        }

        public void SetupModules() 
        {
            dgModules.Rows.Clear();
            
            foreach (SliceModule sm in UVDLPApp.Instance().m_flexslice.m_modules) 
            {
                dgModules.Rows.Add(sm.Name);
            }
        }
        public void SetupParms() 
        {
            try
            {
                //get current row index index
               // DataGridViewRow row = this.dgModules.SelectedRows[0];
                int row = dgModules.CurrentCell.OwningRow.Index;
                SliceModule sm = (SliceModule)UVDLPApp.Instance().m_flexslice.m_modules[row];
                dgParms.Rows.Clear();
                foreach (Parm sp in sm.m_parms.Parms)
                {

                    dgParms.Rows.Add(sp.m_name, sp.ToString(), sp.m_help);
                }
            }
            catch (Exception) { }
        }
    }
}
