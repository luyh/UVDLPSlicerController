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
    public partial class ctlToolpathGenConfig : UserControl
    {
        public ctlToolpathGenConfig()
        {
            InitializeComponent();
            PopulateProfiles();
        }

       private SliceBuildConfig m_config = null;
        // this populates the profile in use and the combo 
       private void PopulateProfiles() 
       {
           try
           {
               cmbSliceProfiles.Items.Clear();
               lstSliceProfiles.Items.Clear();
               foreach (string prof in UVDLPApp.Instance().SliceProfiles())
               {
                   cmbSliceProfiles.Items.Add(prof);
                   lstSliceProfiles.Items.Add(prof);
               }
               //get the current profile name
               string curprof = UVDLPApp.Instance().GetCurrentSliceProfileName();
               cmbSliceProfiles.SelectedItem = curprof;
               lstSliceProfiles.SelectedItem = curprof;
           }
           catch (Exception ex) 
           {
               DebugLogger.Instance().LogError(ex.Message);
           }
       }
       private string CurPrefGcodePath() 
       {
           try
           {
               string shortname = lstSliceProfiles.SelectedItem.ToString();
               string fname = UVDLPApp.Instance().m_PathProfiles;
               fname += UVDLPApp.m_pathsep + shortname + UVDLPApp.m_pathsep;
               return fname;
           }
           catch (Exception ex) 
           {
               DebugLogger.Instance().LogError(ex.Message);
               return "";
           }
       }
        private SliceBuildConfig LoadProfile(string shortname) 
        {
            SliceBuildConfig profile = new SliceBuildConfig();
            try
            {
                string fname = UVDLPApp.Instance().m_PathProfiles;
                fname += UVDLPApp.m_pathsep + shortname + ".slicing";
                if (!profile.Load(fname))
                {
                    DebugLogger.Instance().LogError("Could not load " + fname);
                    return null;
                }
                else 
                {
                    return profile;
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
            return null;
        }
        private void SetValues() 
        {
            lblProfName.Text = lstSliceProfiles.SelectedItem.ToString();
            txtZThick.Text = "" + String.Format("{0:0.000}",m_config.ZThick);
           // chkgengcode.Checked = m_config.exportgcode;
           // chkExportSlices.Checked = m_config.exportimages;
            //chkexportsvg.Checked = m_config.exportsvg;
            if (m_config.m_exportopt.ToUpper().Contains("ZIP"))
            {
                rbzip.Checked = true;
            }
            else 
            {
                rbsub.Checked = true;
            }
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
            txtliftfeed.Text = m_config.liftfeedrate.ToString();
            txtretractfeed.Text = m_config.liftretractrate.ToString();
            chkReflectX.Checked = m_config.m_flipX;
            chkReflectY.Checked = m_config.m_flipY;
            txtNotes.Text = m_config.m_notes;
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
                if (rbzip.Checked == true)
                {
                    m_config.m_exportopt = "ZIP";
                }
                else 
                {
                   m_config.m_exportopt = "SUBDIR";
                }
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
                m_config.liftfeedrate = double.Parse(txtliftfeed.Text);
                m_config.liftretractrate = double.Parse(txtretractfeed.Text);
                //  m_config.raise_time_ms = int.Parse(txtRaiseTime.Text);
                grpLift.Enabled = !chkmainliftgcode.Checked;
                m_config.m_flipX = chkReflectX.Checked;
                m_config.m_flipY = chkReflectY.Checked;
                m_config.m_notes = txtNotes.Text;
                m_config.direction = (SliceBuildConfig.eBuildDirection)Enum.Parse(typeof(SliceBuildConfig.eBuildDirection), cmbBuildDirection.SelectedItem.ToString());
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please check input parameters\r\n" + ex.Message,"Input Error");
                return false;
            }
        }
        /*
        private void frmSliceOptions_Load(object sender, EventArgs e)
        {
            SetValues();
        }
        */
        private void cmdCancel_Click(object sender, EventArgs e)
        {
          //  Close();
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
            m_config.SaveFile(CurPrefGcodePath() + "start.gcode", txtstartgcode.Text);
        }

        private void cmdsavepreslicegcode_Click(object sender, EventArgs e)
        {
            m_config.PreSliceCode = txtpreslicegcode.Text;
            m_config.SaveFile(CurPrefGcodePath() + "preslice.gcode", txtpreslicegcode.Text);
        }

        private void cmdSavePrelift_Click(object sender, EventArgs e)
        {
            m_config.PreLiftCode = txtpreliftgcode.Text;
            m_config.SaveFile(CurPrefGcodePath() + "prelift.gcode", txtpreliftgcode.Text);
        }

        private void cmdsavepostliftgcode_Click(object sender, EventArgs e)
        {
            m_config.PostLiftCode = txtpostliftgcode.Text;
            m_config.SaveFile(CurPrefGcodePath() + "postlift.gcode", txtpostliftgcode.Text);
        }

        private void txtsaveendgcode_Click(object sender, EventArgs e)
        {
            m_config.FooterCode = txtendgcode.Text;
            m_config.SaveFile(CurPrefGcodePath() + "end.gcode", txtendgcode.Text);
        }

        private void cmdsavemainliftgcode_Click(object sender, EventArgs e)
        {
            m_config.MainLiftCode = txtmainliftgcode.Text;
            m_config.SaveFile(CurPrefGcodePath() + "mainlift.gcode", txtmainliftgcode.Text);
        }

        private void chkmainliftgcode_CheckedChanged(object sender, EventArgs e)
        {
            grpLift.Enabled = !chkmainliftgcode.Checked;
        }
        /*
        private void chkgengcode_CheckedChanged(object sender, EventArgs e)
        {

        }
        */
        private void cmdAutoCalc_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetValues())
                {
                    double zlift = m_config.liftdistance; // in mm
                    double zliftrate = m_config.liftfeedrate; // in mm/m
                    double zliftretract = m_config.liftretractrate; // in mm/m
                    zliftrate /= 60.0d;     // to convert to mm/s
                    zliftretract /= 60.0d;  // to convert to mm/s

                    double tval = 0;
                    double settlingtime = 2500.0d; // 500 ms
                    tval = (zlift / zliftrate);
                    tval += (zlift / zliftretract);
                    tval *= 1000.0d; // convert to ms
                    tval += settlingtime;
                    String stime = ((int)tval).ToString();
                    txtBlankTime.Text = stime;

                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            if(m_config == null) return;
            if (lstSliceProfiles.SelectedIndex == -1) return;
            try
            {
                if (GetValues())
                {
                    string shortname = lstSliceProfiles.SelectedItem.ToString();
                    string fname = UVDLPApp.Instance().m_PathProfiles;
                    fname += UVDLPApp.m_pathsep + shortname + ".slicing";
                    m_config.Save(fname);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmbSliceProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the item
            if (cmbSliceProfiles.SelectedIndex == -1)
            {
                //blank items
                return;
            }
            else 
            {
                //set this profile to be the active one for the program                
                string shortname = cmbSliceProfiles.SelectedItem.ToString();
                string fname = UVDLPApp.Instance().m_PathProfiles;
                fname += UVDLPApp.m_pathsep + shortname + ".slicing";
                UVDLPApp.Instance().LoadBuildSliceProfile(fname);                 
            }
        }

        private void lstSliceProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the item
            if (lstSliceProfiles.SelectedIndex == -1)
            {
                //blank items
                return;
            }
            else
            {
                string shortname = lstSliceProfiles.SelectedItem.ToString();
                m_config = LoadProfile(shortname);
                if (m_config != null)
                {
                    SetValues();
                }
                else 
                {
                    //blank items
                }
                 
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            // prompt for a new name
            frmProfileName frm = new frmProfileName();
            if (frm.ShowDialog() == DialogResult.OK) 
            {
                //create a new profile
                SliceBuildConfig bf = new SliceBuildConfig();
                //save it
                string shortname = frm.ProfileName;
                string fname = UVDLPApp.Instance().m_PathProfiles;
                fname += UVDLPApp.m_pathsep + shortname + ".slicing";
                if (!bf.Save(fname)) 
                {
                    MessageBox.Show("Error saving new profile " + fname);
                }
                //re-display the new list
                PopulateProfiles();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string shortname = lstSliceProfiles.SelectedItem.ToString();
            if (shortname.ToLower().Contains("default")) 
            {
                MessageBox.Show("Cannot delete default profile");
            }
        }
    }
}