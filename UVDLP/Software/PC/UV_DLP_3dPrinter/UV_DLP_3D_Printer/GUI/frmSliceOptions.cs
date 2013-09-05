using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UV_DLP_3D_Printer
{
    public partial class frmSliceOptions : Form
    {
        private SliceBuildConfig m_config;
        public frmSliceOptions(ref SliceBuildConfig config)
        {
            m_config = config;
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //save some stuff
            if (GetValues())
            {
                //save
                UVDLPApp.Instance().SaveCurrentSliceBuildConfig();
                Close();
            }
        }

        private void SetValues() 
        {
            txtZThick.Text = "" + String.Format("{0:0.00000}",m_config.ZThick);
            chkgengcode.Checked = m_config.exportgcode;
            chkExportSlices.Checked = m_config.exportimages;
            chkexportsvg.Checked = m_config.exportsvg;
            txtLayerTime.Text = "" + m_config.layertime_ms;
            txtFirstLayerTime.Text = m_config.firstlayertime_ms.ToString();
            txtBlankTime.Text = m_config.blanktime_ms.ToString();
            txtXOffset.Text = m_config.XOffset.ToString();
            txtYOffset.Text = m_config.YOffset.ToString();
            txtLiftDistance.Text = m_config.liftdistance.ToString();
            txtnumbottom.Text = m_config.numfirstlayers.ToString();
            txtSlideTilt.Text = m_config.slidetiltval.ToString();
            chkantialiasing.Checked = m_config.antialiasing;
            chkmainliftgcode.Checked = m_config.usemainliftgcode;
            chkautocalcdelay.Checked = m_config.autocalcdelay;
            txtliftfeed.Text = m_config.liftfeedrate.ToString();
            txtretractfeed.Text = m_config.liftretractrate.ToString();

           // txtRaiseTime.Text = m_config.raise_time_ms.ToString();

            foreach(String name in Enum.GetNames(typeof(SliceBuildConfig.eBuildDirection)))
            {
                cmbBuildDirection.Items.Add(name);
            }
            cmbBuildDirection.SelectedItem = m_config.direction.ToString();

            txtstartgcode.Text = m_config.HeaderCode;
            txtpreslicegcode.Text = m_config.PreSliceCode;
            txtpreliftgcode.Text = m_config.PreLiftCode;
            txtpostliftgcode.Text = m_config.PostLiftCode;
            txtendgcode.Text = m_config.FooterCode;
            txtmainliftgcode.Text = m_config.MainLiftCode;
        }
        private bool GetValues() 
        {
            try
            {              
                m_config.ZThick = Single.Parse(txtZThick.Text);
                m_config.exportgcode = chkgengcode.Checked;
                m_config.exportimages = chkExportSlices.Checked;
                m_config.exportsvg = chkexportsvg.Checked;
                m_config.layertime_ms = int.Parse(txtLayerTime.Text);
                m_config.firstlayertime_ms = int.Parse(txtFirstLayerTime.Text);
                m_config.blanktime_ms = int.Parse(txtBlankTime.Text);
                m_config.XOffset = int.Parse(txtXOffset.Text);
                m_config.YOffset = int.Parse(txtYOffset.Text);
                m_config.liftdistance = double.Parse(txtLiftDistance.Text);
                m_config.numfirstlayers = int.Parse(txtnumbottom.Text);
                m_config.slidetiltval = double.Parse(txtSlideTilt.Text);
                m_config.antialiasing = chkantialiasing.Checked;
                m_config.usemainliftgcode = chkmainliftgcode.Checked;
                m_config.autocalcdelay = chkautocalcdelay.Checked;
                m_config.liftfeedrate = double.Parse(txtliftfeed.Text);
                m_config.liftretractrate = double.Parse(txtretractfeed.Text);
                //  m_config.raise_time_ms = int.Parse(txtRaiseTime.Text);
                grpLift.Enabled = !chkmainliftgcode.Checked;

                m_config.direction = (SliceBuildConfig.eBuildDirection)Enum.Parse(typeof(SliceBuildConfig.eBuildDirection), cmbBuildDirection.SelectedItem.ToString());
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please check input parameters\r\n" + ex.Message,"Input Error");
                return false;
            }
        }

        private void frmSliceOptions_Load(object sender, EventArgs e)
        {
            SetValues();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdreloadstartgcode_Click(object sender, EventArgs e)
        {
            txtstartgcode.Text = m_config.HeaderCode;
        }

        private void cmdreloadpreslicegcode_Click(object sender, EventArgs e)
        {
            txtpreslicegcode.Text = m_config.PreSliceCode;
        }

        private void cmdReloadPrelift_Click(object sender, EventArgs e)
        {
           txtpreliftgcode.Text = m_config.PreLiftCode;
        }

        private void cmdpostliftgcode_Click(object sender, EventArgs e)
        {
            txtpostliftgcode.Text = m_config.PostLiftCode;
        }

        private void cmdendgcode_Click(object sender, EventArgs e)
        {
            txtendgcode.Text = m_config.FooterCode;
        }

        private void cmdreloadmainliftgcode_Click(object sender, EventArgs e)
        {
            txtmainliftgcode.Text = m_config.MainLiftCode;
        }

        
        private void cmdsavestartgcode_Click(object sender, EventArgs e)
        {
            m_config.HeaderCode = txtstartgcode.Text;
            m_config.SaveFile(UVDLPApp.Instance().ProfilePathString() + "start.gcode", txtstartgcode.Text);
        }

        private void cmdsavepreslicegcode_Click(object sender, EventArgs e)
        {
            m_config.PreSliceCode = txtpreslicegcode.Text;
            m_config.SaveFile(UVDLPApp.Instance().ProfilePathString() + "preslice.gcode", txtpreslicegcode.Text);
        }

        private void cmdSavePrelift_Click(object sender, EventArgs e)
        {
            m_config.PreLiftCode = txtpreliftgcode.Text;
            m_config.SaveFile(UVDLPApp.Instance().ProfilePathString() + "prelift.gcode", txtpreliftgcode.Text);
        }

        private void cmdsavepostliftgcode_Click(object sender, EventArgs e)
        {
            m_config.PostLiftCode = txtpostliftgcode.Text;
            m_config.SaveFile(UVDLPApp.Instance().ProfilePathString() + "postlift.gcode", txtpostliftgcode.Text);
        }

        private void txtsaveendgcode_Click(object sender, EventArgs e)
        {
            m_config.FooterCode = txtendgcode.Text;
            m_config.SaveFile(UVDLPApp.Instance().ProfilePathString() + "end.gcode", txtendgcode.Text);
        }

        private void cmdsavemainliftgcode_Click(object sender, EventArgs e)
        {
            m_config.MainLiftCode = txtmainliftgcode.Text;
            m_config.SaveFile(UVDLPApp.Instance().ProfilePathString() + "mainlift.gcode", txtmainliftgcode.Text);
        }

        private void chkautocalcdelay_CheckedChanged(object sender, EventArgs e)
        {
            CalcBlankTime();
        }

        private void txtliftfeed_TextChanged(object sender, EventArgs e)
        {
            CalcBlankTime();
        }

        private void txtretractfeed_TextChanged(object sender, EventArgs e)
        {
            //auto calculate the zlift and zretract times
            CalcBlankTime();
        }
        private void CalcBlankTime() 
        {
            if (chkautocalcdelay.Checked == false)
            {
                return;
            }
            try
            {
                double blanktime = 0.0d;
                //blanktime is the lift time plus the lift retract time
                //distance/distance per sec
                
                // now the retract time
                double liftdist = double.Parse(txtLiftDistance.Text);
                double retractdist = liftdist - double.Parse(txtZThick.Text);
                double liftfeed = double.Parse(txtliftfeed.Text);
                double retractfeed = double.Parse(txtretractfeed.Text);
                blanktime = (60 / liftfeed) * liftdist;
                blanktime += (60 / retractfeed) * retractdist;
                blanktime *= 1000.0;
                //blanktime = liftdist / liftfeed;
                //blanktime += retractdist / retractfeed;
                //blanktime *= 1000.0;
                int iblanktime = (int)blanktime; // cast to int
                txtBlankTime.Text = iblanktime.ToString();// String.Format("{0.00000}", blanktime);

            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void txtLiftDistance_TextChanged(object sender, EventArgs e)
        {
            CalcBlankTime();
        }

        private void chkmainliftgcode_CheckedChanged(object sender, EventArgs e)
        {
            grpLift.Enabled = !chkmainliftgcode.Checked;
        }
    }
}
