using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.Controls;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public class ctlUserPanel : UserControl
    {
        public ctl3DView c3d = null;
        public ctlBgnd bgndPanel = new ctlBgnd();
        public int panelWidth = 14;
        String mGuiAnchor;
        protected int mGapx, mGapy;

        public ctlUserPanel()
            : base()
        {
            bgndPanel.col = Color.Navy;
            bgndPanel.imageName = "trimpanel";        
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
    }
}
