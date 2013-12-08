using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlSliceView : UserControl
    {
        public ctlSliceView()
        {
            InitializeComponent();
        }

        public void SetNumLayers(int val)
        {
            if (val < 0)
                val = 0;
            if (UVDLPApp.Instance().m_appconfig.m_viewslice3d && (val > 0))
            {
                numLayer.MaxInt = val;
                numLayer.IntVal = 1;
                numLayer.Visible = true;
            }
            else
                numLayer.Visible = false;
            itemNumLayers.DataText = val.ToString();
            ViewLayer(0, null, BuildManager.SLICE_NORMAL);
        }

        private void ViewLayer(int layer, Bitmap image, int layertype)
        {
            try
            {
                //render the 2d slice
                Bitmap bmp = null;
                if (image == null) // we're here because of the scroll bar in the gui
                {
                    bmp = UVDLPApp.Instance().m_slicefile.GetSliceImage(layer);
                }
                else // the image was specified from the build manager
                {
                    bmp = image;
                }

                //this bmp could be a normal, blank, or calibration image
                picSlice.Image = bmp;//now show the 2d slice
                picSlice.Invalidate();
                // if we're a UV DLP printer, show on the frmDLP
            }
            catch (Exception) { }

        }
        
        private void numLayer_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int vscrollval = numLayer.IntVal - 1;
                ViewLayer(vscrollval, null, BuildManager.SLICE_NORMAL);
            }
            catch (Exception)
            {
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
    }
}
