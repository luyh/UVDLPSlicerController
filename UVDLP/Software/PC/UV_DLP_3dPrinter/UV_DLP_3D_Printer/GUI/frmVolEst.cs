using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Slicing;
using Engine3D;
namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmVolEst : Form
    {
        public frmVolEst()
        {
            InitializeComponent();
            if (UVDLPApp.Instance().SelectedObject == null)
            {
                lblmess.Text = "No object selected";
                return;
            }
            double vol =0.0;
            foreach (Object3d obj in UVDLPApp.Instance().Engine3D.m_objects) 
            {
                vol += obj.CalculateVolume();
            }            
            vol /= 100; // convert to mm^3
            lblVolume.Text = "Volume = " + string.Format("{0:0.000}", vol) + " mm^3";

            double cost = vol * (UVDLPApp.Instance().m_buildparms.m_resinprice / 1000.0);
            lblCost.Text = "Cost = " + string.Format("{0:0.000}", cost);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
