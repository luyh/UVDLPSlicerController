using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.Controls;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using UV_DLP_3D_Printer._3DEngine;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public class ctlUserPanel : UserControl
    {
        public ctl3DView c3d = null;
        public ctlBgnd bgndPanel = new ctlBgnd();
        public int panelWidth = 14;
        String mGuiAnchor;
        protected int mGapx, mGapy;
        protected bool mGLVisible;

        public ctlUserPanel()
            : base()
        {
            bgndPanel.col = Color.Navy;
            bgndPanel.imageName = "trimpanel";
            mGLVisible = false;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (mGLVisible)
                    cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        // will apear in properties panel
        [Description("Horizontal space from anchored location"), Category("Anchoring")]
        public int Gapx
        {
            get { return mGapx; }
            set { mGapx = value; }
        }
        [Description("Vertical space from anchored location"), Category("Data")]
        public int Gapy
        {
            get { return mGapy; }
            set { mGapy = value; }
        }

        [Description("GUI anchor type, 2 letter combination of t,c,b and l,c,r"), Category("Data")]
        public String GuiAnchor
        {
            get { return mGuiAnchor; }
            set { mGuiAnchor = value; }
        }

        [Description("Determine if control is visible in GL view"), Category("Data")]
        public bool GLVisible
        {
            get { return mGLVisible; }
            set { 
                mGLVisible = value;
                DoubleBuffered = !mGLVisible;
            }
        }

        void UpdatePanelLocation()
        {
            bgndPanel.x = Location.X - panelWidth;
            bgndPanel.y = Location.Y - panelWidth;
            bgndPanel.w = Width + 2 * panelWidth;
            bgndPanel.h = Height + 2 * panelWidth;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (c3d != null)
            {
                if (Visible)
                {
                    UpdatePanelLocation();
                    c3d.ctlBgndList.Add(bgndPanel);
                }
                else
                {
                    c3d.ctlBgndList.Remove(bgndPanel);
                }
                c3d.Refresh();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!Visible)
                return;
            UpdatePanelLocation();
            if (c3d != null)
                c3d.Refresh();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (!Visible)
                return;
            UpdatePanelLocation();
            if (c3d != null)
                c3d.Refresh();
        }


        public void ApplyThemeRecurse(Control ctl, ControlTheme ct)
        {
            foreach (Control subctl in ctl.Controls)
            {
                if (subctl.GetType().IsSubclassOf(typeof(ctlUserPanel)))
                {
                    ((ctlUserPanel)subctl).ApplyTheme(ct);
                }
                else
                {
                    ApplyThemeRecurse(subctl, ct);
                }
            }
        }


        public virtual void ApplyTheme(ControlTheme ct)
        {
            ApplyThemeRecurse(this, ct);
            if (ct.BackColor != ControlTheme.NullColor)
                bgndPanel.col = ct.BackColor;
        }

        public virtual void GLRedraw(C2DGraphics gr, int x, int y)
        {
            if (!GLVisible)
                return;
            gr.SetDrawingRegion(x, y, Width, Height);
            OnGLBackgroundPaint(gr);
            OnGLPaint(gr);
            foreach (Control subctl in Controls)
            {
                if (subctl.GetType().IsSubclassOf(typeof(ctlUserPanel)))
                {
                    ((ctlUserPanel)subctl).GLRedraw(gr, x + subctl.Location.X, y + subctl.Location.Y);
                }
            }
        }

        public virtual void GLRedraw(C2DGraphics gr)
        {
            GLRedraw(gr, Location.X, Location.Y);
        }


        public virtual void OnGLPaint(C2DGraphics gr)
        {
        }

        public virtual void OnGLBackgroundPaint(C2DGraphics gr)
        {
            gr.Rectangle(0, 0, Width, Height, BackColor);
        }

    }
}
