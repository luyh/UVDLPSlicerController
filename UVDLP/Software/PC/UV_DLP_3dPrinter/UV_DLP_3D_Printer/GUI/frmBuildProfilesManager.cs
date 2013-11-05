using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmBuildProfilesManager : Form
    {
        public frmBuildProfilesManager()
        {
            InitializeComponent();
            UpdateProfiles();
            UpdateButtons();
        }
        private void UpdateButtons()
        {
            int idx = lstSliceBuildProfiles.SelectedIndex;
            if (idx == -1)
            {
                cmdCopy.Enabled = false;
                cmdDelete.Enabled = false;
                cmdEdit.Enabled = false;
            }
            else
            {
                cmdCopy.Enabled = true;
                cmdDelete.Enabled = true;
                cmdEdit.Enabled = true;

            }
        }
        private string FNFromIndex(int idx)
        {
            string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathProfiles, "*.slicing");
            return filePaths[idx];
        }
        private void UpdateProfiles()
        {
            // get a list of profiles in the /machines directory
            string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathProfiles, "*.slicing");
            lstSliceBuildProfiles.Items.Clear();
            foreach (String profile in filePaths)
            {
                String pn = Path.GetFileNameWithoutExtension(profile);
                lstSliceBuildProfiles.Items.Add(pn);
            }
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            // create a new profile, give it a name
            frmProfileName fpn = new frmProfileName();
            fpn.ShowDialog();
            String pf = fpn.ProfileName;
            if (pf.Length > 0)
            {
                //create a new profile with that name
                String fn = UVDLPApp.Instance().m_PathProfiles;
                fn += UVDLPApp.m_pathsep;
                fn += pf;
                fn += ".slicing";
               // MachineConfig mc = new MachineConfig();
                SliceBuildConfig sbc = new SliceBuildConfig();                

                if (!sbc.Save(fn))
                {
                    DebugLogger.Instance().LogRecord("Error Saving new slice and build profile " + fn);
                    return;
                }
                UpdateProfiles();
            }
        }

        private void lstSliceBuildProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSliceBuildProfiles.SelectedIndex != -1)
            {
                UpdateButtons();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lstSliceBuildProfiles.SelectedIndex != -1)
            {
                string fn = FNFromIndex(lstSliceBuildProfiles.SelectedIndex);
                if (fn != null)
                {
                    SliceBuildConfig sbc = null;
                    if (UVDLPApp.Instance().m_buildparms.m_filename.Equals(fn))
                    {
                        sbc = UVDLPApp.Instance().m_buildparms; // current slicing profile
                    }
                    else
                    {
                        sbc = new SliceBuildConfig(); // existing but not current
                        sbc.Load(fn);
                    }
                    frmSliceOptions m_frmsliceopt = new frmSliceOptions(ref sbc);
                    m_frmsliceopt.ShowDialog();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSliceBuildProfiles.SelectedIndex != -1)
                {
                    if (MessageBox.Show(this, "Are you sure you want to delete this Slice & Build Profile?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                    {
                        //delete file    
                        File.Delete(FNFromIndex(lstSliceBuildProfiles.SelectedIndex));
                        //should delete the subdirectory with files too
                        UpdateProfiles();
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

    }
}
