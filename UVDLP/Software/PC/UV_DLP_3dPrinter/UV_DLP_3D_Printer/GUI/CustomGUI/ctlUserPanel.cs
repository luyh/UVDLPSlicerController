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

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (c3d != null)
            {
                if (Visible)
                {
                    bgndPanel.x = Location.X - panelWidth;
                    bgndPanel.y = Location.Y - panelWidth;
                    bgndPanel.w = Width + 2 * panelWidth;
                    bgndPanel.h = Height + 2 * panelWidth;
                    bgndPanel.col = Color.Navy;
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
            bgndPanel.x = Location.X - panelWidth;
            bgndPanel.y = Location.Y - panelWidth;
            bgndPanel.w = Width + 2 * panelWidth;
            bgndPanel.h = Height + 2 * panelWidth;
            if (c3d != null)
                c3d.Invalidate();
        }
    }
}
