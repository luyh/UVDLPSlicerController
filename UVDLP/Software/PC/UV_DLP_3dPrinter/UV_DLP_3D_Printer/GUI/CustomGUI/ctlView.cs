using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlView : UserControl
    {
        SplitContainer mTreeViewHolder;
        SplitContainer mMessagePanelHolder;

        public ctlView()
        {
            InitializeComponent();
            mTreeViewHolder = null;
        }

        public SplitContainer MessagePanelHolder
        {
            get { return mMessagePanelHolder; }
            set { mMessagePanelHolder = value; }
        }

        public SplitContainer TreeViewHolder
        {
            get { return mTreeViewHolder; }
            set { mTreeViewHolder = value; }
        }

        private void SetAlpha(bool val)
        {
            if (val == true)
            {
                GL.Disable(EnableCap.DepthTest); // need to disable z buffering for proper display
                //alpha blending
                //GL.Enable(EnableCap.Blend); // alpha blending
                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                GL.Enable(EnableCap.AlphaTest);
            }
            else
            {
                GL.Disable(EnableCap.AlphaTest);
                GL.Enable(EnableCap.DepthTest); // for z buffer        
                //GL.Disable(EnableCap.Blend); // alpha blending
            }
        }
        
        private void buttAddSupport_Click(object sender, EventArgs e)
        {
            SetAlpha(buttAddSupport.Checked);
            UVDLPApp.Instance().m_engine3d.m_alpha = buttAddSupport.Checked;
            UVDLPApp.Instance().m_engine3d.UpdateLists();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");            
        }

        private void buttShowSlice_Click(object sender, EventArgs e)
        {
            buttShowSliceHeight.Enabled = buttShowSlice.Checked;
        }

        private void buttTreeView_Click(object sender, EventArgs e)
        {
            if (mTreeViewHolder != null)
            {
                mTreeViewHolder.Panel1Collapsed = !buttTreeView.Checked;
            }
        }

        private void ctlImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void buttShowConsole_Click(object sender, EventArgs e)
        {
            if (mMessagePanelHolder != null)
            {
                mMessagePanelHolder.Panel2Collapsed = !buttShowConsole.Checked;
            }
        }

    }
}
