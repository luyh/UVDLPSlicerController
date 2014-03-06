using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;
using UV_DLP_3D_Printer;
using UV_DLP_3D_Printer.Slicing;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlSliceView : UserControl
    {
        frmDLP m_frmdlp = null;

        public ctlSliceView()
        {
            try
            {
                InitializeComponent();
                buttPreviewOnDisplay.Checked = UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay; // set the initial check state
                UVDLPApp.Instance().m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers, SliceFile sf)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { SliceEv(ev, layer, totallayers, sf); }));
                }
                else
                {
                    switch (ev)
                    {
                        case Slicer.eSliceEvent.eSliceStarted:
                           
                            break;
                        case Slicer.eSliceEvent.eLayerSliced:
                            break;
                        case Slicer.eSliceEvent.eSliceCompleted:                            
                            SetNumLayers(totallayers);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        public frmDLP DlpForm
        {
            get { return m_frmdlp; }
            set 
            {
                try
                {
                    m_frmdlp = value;
                    if (m_frmdlp != null)
                    {
                        m_frmdlp.VisibleChanged += new EventHandler(m_frmdlp_VisibleChanged);
                        UpdateChecked();
                    }
                }
                catch (Exception ex) 
                {
                    DebugLogger.Instance().LogError(ex);
                }
            }
        }

        void UpdateChecked()
        {
            if ((m_frmdlp == null) || m_frmdlp.IsDisposed)
            {
                buttPreviewOnDisplay.Checked = false;
                return;
            }
            buttPreviewOnDisplay.Checked = m_frmdlp.Visible && UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay;
        }

        void m_frmdlp_VisibleChanged(object sender, EventArgs e)
        {
            if (m_frmdlp.Visible == false)
            {
                UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay = false;
                UVDLPApp.Instance().m_appconfig.Save(UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + UVDLPApp.m_appconfigname);
            }
            UpdateChecked();
        }

        public void SetNumLayers(int val)
        {
            try
            {
                if (val < 0)
                    val = 0;
                if (val > 0)
                {
                    numLayer.MaxInt = val;
                    numLayer.IntVal = 1;
                    numLayer.Visible = true;
                }
                else
                {
                    numLayer.Visible = false;
                }
                itemNumLayers.DataText = val.ToString();
                ViewLayer(0);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }

        }

        
        public void ViewLayer(int layer)
        {
            try
            {
                //render the 2d slice
                Bitmap bmp = null;
                bmp = UVDLPApp.Instance().m_slicefile.GetSliceImage(layer);

                picSlice.Image = bmp;//now show the 2d slice
                picSlice.Refresh();
                // if we're a UV DLP printer, show on the frmDLP
                if ((UVDLPApp.Instance().m_printerinfo.m_machinetype == MachineConfig.eMachineType.UV_DLP) && (m_frmdlp != null))
                {
                    // only show the image on the dlp if we're previewing
                    //need to make sure we show the layer if building
                    if (UVDLPApp.Instance().m_buildmgr.IsPrinting == true || UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay == true)
                    {
                        //make sure we show the screen
                        if (m_frmdlp.Visible != true)
                        {
                            m_frmdlp.ShowDLPScreen();
                        }
                        m_frmdlp.ShowImage(bmp);
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }

        }
        
        private void numLayer_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int vscrollval = numLayer.IntVal - 1;
                ViewLayer(vscrollval);
                numLayer.Refresh();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
                // probably past the max.
            }
        }

        private void ctlSliceView_SizeChanged(object sender, EventArgs e)
        {
            // update inner control positions
            foreach (Control ctl in Controls)
            {
                if (ctl.GetType().IsSubclassOf(typeof(ctlAnchorable)))
                    ((ctlAnchorable)ctl).UpdatePosition();
            }
        }

        private void buttPreviewOnDisplay_Click(object sender, EventArgs e)
        {
            if (buttPreviewOnDisplay.Checked)
            {
                UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay = true;
                ViewLayer(numLayer.IntVal - 1);
            }
            else
            {
                // if the user unchecks the preview on dlp button, blank the dlp display.
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eShowBlank, "");
                UVDLPApp.Instance().m_appconfig.m_previewslicesbuilddisplay = false;
            }
            //save the check value
            UVDLPApp.Instance().m_appconfig.Save(UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + UVDLPApp.m_appconfigname);
        }
    }
}
