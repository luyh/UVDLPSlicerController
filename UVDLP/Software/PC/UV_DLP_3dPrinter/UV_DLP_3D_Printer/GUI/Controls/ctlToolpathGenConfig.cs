using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UV_DLP_3D_Printer.GUI.CustomGUI;
namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlToolpathGenConfig : ctlAnchorable//UserControl
    {
        public ctlToolpathGenConfig()
        {
            try
            {
                InitializeComponent();
                PopulateProfiles();
                lbGCodeSection.SelectedIndex = 0;
            }catch(Exception)
            {
            
            }
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

       private String GetSlicingFilename(string shortname)
       {
           string fname = UVDLPApp.Instance().m_PathProfiles;
           fname += UVDLPApp.m_pathsep + shortname + ".slicing";
           return fname;
       }
        private SliceBuildConfig LoadProfile(string shortname) 
        {
            SliceBuildConfig profile = new SliceBuildConfig();
            try
            {
                string fname = GetSlicingFilename(shortname);
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
            chkExport.Checked = m_config.export;
            groupBox2.Enabled = chkExport.Checked;
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
            txtAAVal.Text = "" + m_config.aaval.ToString();
            txtLayerTime.Text = "" + m_config.layertime_ms;
            txtFirstLayerTime.Text = m_config.firstlayertime_ms.ToString();
            txtBlankTime.Text = m_config.blanktime_ms.ToString();
            txtXOffset.Text = m_config.XOffset.ToString();
            txtYOffset.Text = m_config.YOffset.ToString();
            txtLiftDistance.Text = m_config.liftdistance.ToString();
            txtnumbottom.Text = m_config.numfirstlayers.ToString();
            txtSlideTilt.Text = m_config.slidetiltval.ToString();
            chkantialiasing.Checked = m_config.antialiasing;
            //chkmainliftgcode.Checked = m_config.usemainliftgcode;
            //grpLift.Enabled = !chkmainliftgcode.Checked;
            txtliftfeed.Text = m_config.liftfeedrate.ToString();
            txtretractfeed.Text = m_config.liftretractrate.ToString();
            chkReflectX.Checked = m_config.m_flipX;
            chkReflectY.Checked = m_config.m_flipY;
            txtNotes.Text = m_config.m_notes;
            txtResinPriceL.Text = m_config.m_resinprice.ToString();

           // txtRaiseTime.Text = m_config.raise_time_ms.ToString();

            foreach(String name in Enum.GetNames(typeof(SliceBuildConfig.eBuildDirection)))
            {
                cmbBuildDirection.Items.Add(name);
            }
            cmbBuildDirection.SelectedItem = m_config.direction.ToString();
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
                //m_config.usemainliftgcode = chkmainliftgcode.Checked;
                m_config.liftfeedrate = double.Parse(txtliftfeed.Text);
                m_config.liftretractrate = double.Parse(txtretractfeed.Text);
                //  m_config.raise_time_ms = int.Parse(txtRaiseTime.Text);
                //grpLift.Enabled = !chkmainliftgcode.Checked;
                m_config.m_flipX = chkReflectX.Checked;
                m_config.m_flipY = chkReflectY.Checked;
                m_config.m_notes = txtNotes.Text;
                m_config.aaval = double.Parse(txtAAVal.Text);
                m_config.m_resinprice = double.Parse(txtResinPriceL.Text);
                m_config.direction = (SliceBuildConfig.eBuildDirection)Enum.Parse(typeof(SliceBuildConfig.eBuildDirection), cmbBuildDirection.SelectedItem.ToString());
                m_config.export = chkExport.Checked;
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please check input parameters\r\n" + ex.Message,"Input Error");
                return false;
            }
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
                    string fname = GetSlicingFilename(shortname);
                    m_config.Save(fname);
                    // make sure main build params are updated if needed
                    if (cmbSliceProfiles.SelectedItem.ToString() == shortname)
                    {
                        UVDLPApp.Instance().LoadBuildSliceProfile(fname);
                    }
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
                string fname = GetSlicingFilename(shortname);
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
                string fname = GetSlicingFilename(shortname);
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
            try
            {
                string shortname = lstSliceProfiles.SelectedItem.ToString();
                if (shortname.ToLower().Contains("default"))
                {
                    MessageBox.Show("Cannot delete default profile");
                }
                else
                {

                    string fname = GetSlicingFilename(shortname);
                    File.Delete(fname); // delete the file
                    string pname = UVDLPApp.Instance().m_PathProfiles + UVDLPApp.m_pathsep + shortname;
                    Directory.Delete(pname, true);
                    PopulateProfiles();
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        /// <summary>
        /// this index changes when the user selects an item from the list of GCode file segements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbGCodeSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGCode.Text = GCodeSection2GCode();
        }

        private string GCodeSection2GCode()
        {
            if (lbGCodeSection.SelectedIndex == -1) return "";
            switch (lbGCodeSection.SelectedItem.ToString())
            {
                case "Start":     return m_config.HeaderCode;
                case "Pre-Slice": return m_config.PreSliceCode;
                case "Lift":      return m_config.LiftCode;
                case "End":       return m_config.FooterCode;
            }
            return "";
        }

        private string GCodeSection2FName() 
        {
            if (lbGCodeSection.SelectedIndex == -1) return "";
            switch (lbGCodeSection.SelectedItem.ToString()) 
            {
                case "Start":       return "start.gcode";
                case "Pre-Slice":   return "preslice.gcode";
                case "Lift":        return "lift.gcode";
                case "End":         return "end.gcode";
            }
            return "";
        }

        private void cmdSaveGCode_Click(object sender, EventArgs e)
        {
            try
            {
                // save the gcode to the right section
                string gcode = txtGCode.Text;
                if (lbGCodeSection.SelectedIndex == -1) return;
                switch (lbGCodeSection.SelectedItem.ToString())
                {
                    case "Start": m_config.HeaderCode = gcode; break;
                    case "Pre-Slice": m_config.PreSliceCode = gcode; break;
                    case "Lift": m_config.LiftCode = gcode; break;
                    case "End": m_config.FooterCode = gcode; break;
                }
               // m_config.SaveFile(CurPrefGcodePath() + GCodeSection2FName(), gcode);
                //really just need to save the profile name here.
                // make sure main build params are updated if needed
                string shortname = lstSliceProfiles.SelectedItem.ToString();
                string fname = GetSlicingFilename(shortname);
                m_config.Save(fname);

                shortname = lstSliceProfiles.SelectedItem.ToString();
                if (cmbSliceProfiles.SelectedItem.ToString() == shortname)
                {
                    UVDLPApp.Instance().LoadBuildSliceProfile(GetSlicingFilename(shortname));
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdReloadGCode_Click(object sender, EventArgs e)
        {
            txtGCode.Text = GCodeSection2GCode();
        }

        private void chkExport_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = chkExport.Checked;
        }


        private void chkantialiasing_CheckedChanged(object sender, EventArgs e)
        {
            txtAAVal.Enabled = chkantialiasing.Checked;
        }
        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor != ControlStyle.NullColor)
            {
               // tTitle.ForeColor = ct.ForeColor;
                ForeColor = ct.ForeColor;
                lblTitle.ForeColor = ct.ForeColor;
            }
            if (ct.BackColor != ControlStyle.NullColor)
            {
                BackColor = ct.BackColor;
                lblLayerTime.BackColor = ct.BackColor;
                //layoutPanel.BackColor = ct.BackColor;
                //tTitle.BackColor = ct.BackColor;
                //tName.BackColor = ct.BackColor;
            }

        }
    }
}