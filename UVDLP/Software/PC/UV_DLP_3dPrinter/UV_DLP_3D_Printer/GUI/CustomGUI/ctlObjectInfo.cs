using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine3D;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlObjectInfo : ctlAnchorable
    {
        const float TitleHeight = 23;
        const float NameHeight = 16;
        const float ItemHeihft = 17;

        public ctlObjectInfo()
        {
            InitializeComponent();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
        }

        private void AppEventDel(eAppEvent ev, String Message)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { AppEventDel(ev, Message); }));
                }
                else
                {
                    switch (ev)
                    {
                        case eAppEvent.eModelAdded:
                            FillObjectInfo(UVDLPApp.Instance().SelectedObject);
                            break;
                        case eAppEvent.eUpdateSelectedObject:
                            FillObjectInfo(UVDLPApp.Instance().SelectedObject);
                            break;
                    }
                    //Refresh();
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }

        }

        private void AdjustHeight(Control ctl, float newHeight)
        {
            ctl.Height = (int)newHeight;
            ctl.Font = new Font("Arial", newHeight / 1.5f, GraphicsUnit.Pixel);
        }

        private void layoutPanel_Resize(object sender, EventArgs e)
        {
            float totalHeight = NameHeight + 7 * ItemHeihft;
            float totalMargin = 0;
            foreach (Control ctl in layoutPanel.Controls)
            {
                totalMargin += ctl.Margin.Top + ctl.Margin.Bottom;
                ctl.Width = Width - ctl.Margin.Left - ctl.Margin.Right;
            }
            totalMargin += ctlTitle1.Height;
            if (Height <= totalMargin)
                return;
            float hScale = ((float)Height - totalMargin) / totalHeight;
            //AdjustHeight(tTitle, TitleHeight * hScale);
            AdjustHeight(tName, NameHeight * hScale);
            foreach (Control ctl in layoutPanel.Controls)
            {
                if (ctl.GetType() == typeof(ctlInfoItem))
                    AdjustHeight(ctl, ItemHeihft * hScale);
            }
        }

        public void FillObjectInfo(Object3d obj)
        {
            if (obj == null)
            {
                foreach (Control ctl in layoutPanel.Controls)
                {
                    if (ctl.GetType() == typeof(ctlInfoItem))
                        ((ctlInfoItem)ctl).DataText = "";
                }
                tName.Text = "";
                return;
            }
            obj.FindMinMax();
            tName.Text = obj.Name;
            tPoints.DataText = obj.NumPoints.ToString();
            tPolys.DataText = obj.NumPolys.ToString();
            tMin.DataText = String.Format("{0:0.00}, {1:0.00}, {2:0.00}", obj.m_min.x, obj.m_min.y, obj.m_min.z);
            tMax.DataText = String.Format("{0:0.00}, {1:0.00}, {2:0.00}", obj.m_max.x, obj.m_max.y, obj.m_max.z);
            double xs, ys, zs;
            xs = obj.m_max.x - obj.m_min.x;
            ys = obj.m_max.y - obj.m_min.y;
            zs = obj.m_max.z - obj.m_min.z;
            tSize.DataText = String.Format("{0:0.00}, {1:0.00}, {2:0.00}", xs, ys, zs);
            double vol = obj.Volume;           
            vol /= 1000.0; // convert to cm^3
            tVolume.DataText = string.Format("{0:0.000} cm^3", vol);
            double cost = vol * (UVDLPApp.Instance().m_buildparms.m_resinprice / 1000.0);
            tCost.DataText = string.Format("{0:0.000}", cost);
       }

#if (DEBUG) // DBG_GUICONFIG
        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor.IsValid())
            {
                ctlTitle1.ForeColor = ct.ForeColor;
                tName.ForeColor = ct.ForeColor;
            }
            if (ct.BackColor.IsValid())
            {
                BackColor = ct.BackColor;
                layoutPanel.BackColor = ct.BackColor;
                ctlTitle1.BackColor = ct.BackColor;
                tName.BackColor = ct.BackColor;
            }
        }
#else
        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor != ControlStyle.NullColor)
            {
                ctlTitle1.ForeColor = ct.ForeColor;
                tName.ForeColor = ct.ForeColor;
            }
            if (ct.BackColor != ControlStyle.NullColor)
            {
                BackColor = ct.BackColor;
                layoutPanel.BackColor = ct.BackColor;
                ctlTitle1.BackColor = ct.BackColor;
                tName.BackColor = ct.BackColor;
            }
        }
#endif

        private void ctlTitle1_Click(object sender, EventArgs e)
        {
            if (ctlTitle1.Checked)
            {
                this.Height = 250;
                /*
                int h = 0;
                h += ctlTitle1.Height;
                h += tName.Height;
                h += tVolume.Height;
                h += tCost.Height;
                h += tPoints.Height;
                h += tPolys.Height;
                h += tMin.Height;
                h += tMax.Height;
                h += tSize.Height;
                this.Height = h + 3*4;
                */
            }
            else
            {
                this.Height = ctlTitle1.Height + 5;
            }
        }

        private void ctlObjectInfo_Resize(object sender, EventArgs e)
        {
            /*
            layoutPanel.Width = layoutPanel.Parent.Width;
            ctlTitle1.Width = ctlTitle1.Parent.Width -6;
            tName.Width = tName.Parent.Width - 6;
            tVolume.Width = tVolume.Parent.Width - 6;
            tCost.Width = tCost.Parent.Width - 6;
            tPoints.Width = tPoints.Parent.Width - 6;
            tPolys.Width = tPolys.Parent.Width - 6;
            tMin.Width = tMin.Parent.Width - 6;
            tMax.Width = tMax.Parent.Width - 6;
            tSize.Width = tSize.Parent.Width - 6;
            */
        }
    }
}
