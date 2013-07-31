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
    public partial class frmSlice : Form
    {
        public frmSlice()
        {
            InitializeComponent();
            //UVDLPApp.Instance().m_slicer.Sliced +=new Slicer.LayerSliced(LayerSliced);
            UVDLPApp.Instance().m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            SetTitle();
        }

        private void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { SliceEv(ev, layer, totallayers); }));
            }
            else
            {
                switch (ev)
                {
                    case Slicer.eSliceEvent.eSliceStarted:
                        cmdSlice.Text = "Cancel";
                        prgSlice.Maximum = totallayers - 1;
                        break;
                    case Slicer.eSliceEvent.eLayerSliced:
                        prgSlice.Maximum = totallayers - 1;
                        prgSlice.Value = layer;
                        lblMessage.Text = "Slicing Layer " + (layer + 1).ToString() + " of " + totallayers.ToString();
                        
                        break;
                    case Slicer.eSliceEvent.eSliceCompleted:
                        lblMessage.Text = "Slicing Completed";
                        cmdSlice.Text = "Slice!";
                        Close();
                        break;
                    case Slicer.eSliceEvent.eSliceCancelled:
                        cmdSlice.Text = "Slice!";
                        lblMessage.Text = "Slicing Cancelled";
                        prgSlice.Value = 0;
                        break;
                }
            }
        }

        private void SetTitle()
        {
            this.Text = "Slice! " + "  ( Slice Profile : ";
            this.Text += Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_buildparms.m_filename);
            this.Text += ", Machine : " + Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_printerinfo.m_filename) + ")";
        }
        private void cmdSliceOptions_Click(object sender, EventArgs e)
        {
            //frmSliceOptions m_frmsliceopt = new frmSliceOptions();
            //m_frmsliceopt.Show();
            frmSliceOptions m_frmsliceopt = new frmSliceOptions(ref UVDLPApp.Instance().m_buildparms);
            m_frmsliceopt.ShowDialog(); // will modal work here?
        }
        private void frmSlice_FormClosed(object sender, FormClosedEventArgs e)
        {
            UVDLPApp.Instance().m_slicer.Slice_Event -=new Slicer.SliceEvent(SliceEv);
        }

        private void cmdSlice_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_slicer.IsSlicing)
                {
                    UVDLPApp.Instance().m_slicer.CancelSlicing();
                }
                else 
                {
                    SliceBuildConfig sp = UVDLPApp.Instance().m_buildparms;
                    sp.UpdateFrom(UVDLPApp.Instance().m_printerinfo);
                    UVDLPApp.Instance().CalcScene();
                    int numslices = UVDLPApp.Instance().m_slicer.GetNumberOfSlices(sp, UVDLPApp.Instance().Scene);
                    UVDLPApp.Instance().m_slicefile = UVDLPApp.Instance().m_slicer.Slice(sp, UVDLPApp.Instance().Scene);                

                    //int numslices = UVDLPApp.Instance().m_slicer.GetNumberOfSlices(sp, UVDLPApp.Instance().m_selectedobject);
                    //UVDLPApp.Instance().m_slicefile = UVDLPApp.Instance().m_slicer.Slice(sp, UVDLPApp.Instance().m_selectedobject, ".");                
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFlexSliceOptions fso = new frmFlexSliceOptions();
            fso.Show();
        }

        private void frmSlice_Activated(object sender, EventArgs e)
        {
            SetTitle();
        }


    }
}
