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
        }


        private void AdjustHeight(Control ctl, float newHeight)
        {
            ctl.Height = (int)newHeight;
            ctl.Font = new Font("Arial", newHeight / 1.5f, GraphicsUnit.Pixel);
        }

        private void layoutPanel_Resize(object sender, EventArgs e)
        {
            float totalHeight = TitleHeight + NameHeight + 7 * ItemHeihft;
            float totalMargin = 0;
            foreach (Control ctl in layoutPanel.Controls)
            {
                totalMargin += ctl.Margin.Top + ctl.Margin.Bottom;
                ctl.Width = Width - ctl.Margin.Left - ctl.Margin.Right;
            }
            float hScale = ((float)Height - totalMargin) / totalHeight;
            AdjustHeight(tTitle, TitleHeight * hScale);
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
            double vol = obj.CalculateVolume();           
            vol /= 1000.0; // convert to cm^3
            tVolume.DataText = string.Format("{0:0.000} cm^3", vol);
            double cost = vol * (UVDLPApp.Instance().m_buildparms.m_resinprice / 1000.0);
            tCost.DataText = string.Format("{0:0.000}", cost);
       }
    }
}
