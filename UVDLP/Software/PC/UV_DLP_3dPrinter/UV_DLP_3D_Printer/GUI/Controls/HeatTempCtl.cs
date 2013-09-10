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
    public enum eHTEvent 
    {
        eSet, // set a temperature
        eOff, // turn a temp off
        eMonitor, // monitor on/off
    }

    /// <summary>
    /// This is the event that fires when the controls' set/off buttons are clicked
    /// </summary>
    
    public partial class HeatTempCtl : UserControl
    {
        public delegate void HTEventDel(eHTEvent ev, int val, int temp);

        public HeatTempCtl()
        {
            InitializeComponent();
        }
        public HTEventDel HTEvent;
        //we're going to need historical values of these as well to graph
        private double HBP_Temp;
        private double EXT0_Temp;

        private void RaiseEvent(eHTEvent ev,int val,int temp) 
        {
            if (HTEvent != null) 
            {
                HTEvent(ev,val,temp);
            }
        }
        public void SetHBPTemp(double degC) 
        {
            HBP_Temp = degC;
            UpdateForm();
        }
        public void SetEXT0Temp(double degC)
        {
            EXT0_Temp = degC;
            UpdateForm();
        }
        private void UpdateForm() 
        {
            // update the visual controls
            lblHBP.Text = "" + HBP_Temp + " C";
            lblEXT0.Text = "" + EXT0_Temp + " C";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdOff1_Click(object sender, EventArgs e)
        {
            RaiseEvent(eHTEvent.eOff, 1,0);
        }

        private void cmdOff2_Click(object sender, EventArgs e)
        {
            RaiseEvent(eHTEvent.eOff, 2,0);
        }

        private void cmdSet2_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = int.Parse(txtVal1.Text);
                RaiseEvent(eHTEvent.eSet, 1,temp);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdSet1_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = int.Parse(txtVal2.Text);
                RaiseEvent(eHTEvent.eSet, 2, temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkMonitorTemps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMonitorTemps.Checked)
            {
                RaiseEvent(eHTEvent.eMonitor, 1,0);
            }
            else 
            {
                RaiseEvent(eHTEvent.eMonitor, 0,0);
            }
        }
    }
}
