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
    public partial class ctlView : ctlUserPanel
    {
        SplitContainer mTreeViewHolder;
        SplitContainer mMessagePanelHolder;
        ctlNumber mLayerNumberScroll;
        ctlObjectInfo mObjectInfoPanel;
        ctlScene mctlScene;

        public ctlView()
        {
            InitializeComponent();
            mTreeViewHolder = null;
            //set some initial states
            buttBoundingBox.Checked = UVDLPApp.Instance().m_appconfig.m_showBoundingBox;
            buttShowSlice.Checked = UVDLPApp.Instance().m_appconfig.m_viewslice3d;
            mLayerNumberScroll = null;
            mMessagePanelHolder = null;
            mTreeViewHolder = null;
            mObjectInfoPanel = null;
            #if DEBUG
            buttShowConsole.Checked = true;    
            #else
            buttShowConsole.Checked = false;
            #endif
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

        public ctlNumber LayerNumberScroll
        {
            get { return mLayerNumberScroll; }
            set { mLayerNumberScroll = value; }
        }

        public ctlScene SceneControl 
        {
            get { return mctlScene; }
            set { mctlScene = value; }
        }
        public ctlObjectInfo ObjectInfoPanel
        {
            get { return mObjectInfoPanel; }
            set { mObjectInfoPanel = value; }
        }
        public bool SliceVisible
        {
            get { return buttSliceView.Checked; }
        }

        private void buttEnableTransparency_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_engine3d.m_alpha = buttEnableTransparency.Checked;
            UVDLPApp.Instance().m_engine3d.UpdateLists();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");            
        }

        private void buttShowSlice_Click(object sender, EventArgs e)
        {
            //buttSliceHeight.Enabled = buttShowSlice.Checked;
            if (mLayerNumberScroll != null)
                mLayerNumberScroll.Visible = buttShowSlice.Checked;
            UVDLPApp.Instance().m_appconfig.m_viewslice3d = buttShowSlice.Checked;
            // now save it
            UVDLPApp.Instance().m_appconfig.Save(UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + UVDLPApp.m_appconfigname);            
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }

        private void buttTreeView_Click(object sender, EventArgs e)
        {
            SceneControl.Visible = buttTreeView.Checked;
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

        /*private void buttShowSliceHeight_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_appconfig.m_viewslice3dheight = buttSliceHeight.Checked;
            UVDLPApp.Instance().m_appconfig.Save(UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + UVDLPApp.m_appconfigname);
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }*/

        private void buttObjectProperties_Click(object sender, EventArgs e)
        {
            if (mObjectInfoPanel != null)
            {
                mObjectInfoPanel.Visible = buttObjectProperties.Checked;
            }
        }

        private void buttBoundingBox_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_appconfig.m_showBoundingBox = buttBoundingBox.Checked;
            UVDLPApp.Instance().m_appconfig.Save(UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + UVDLPApp.m_appconfigname);
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }

        private void buttSliceView_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "redraw");            
        }

        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.BackColor != ControlStyle.NullColor)
            {
                BackColor = ct.BackColor;
                flowLayoutPanel2.BackColor = ct.BackColor;
            }
            if (ct.FrameColor != ControlStyle.NullColor)
            {
                flowLayoutPanel1.BackColor = ct.FrameColor;
                flowLayoutPanel3.BackColor = ct.FrameColor;
                flowLayoutPanel4.BackColor = ct.FrameColor;
            }

        }
    }
}
