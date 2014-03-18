using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using UV_DLP_3D_Printer._3DEngine;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public enum MachineControlAxis
    {
        X = 0,
        Y = 1,
        Z = 2,
        Tilt = 3,
        Extruder = 4,
        All
    }

    public class ctlMCBase : ctlUserPanel
    {
        protected Color mFrameColor;
        protected Color[] mLevelColors;
        protected Color mSelColor;
        protected Color mArrowCol;

        public ctlMCBase()
        {
            mLevelColors = new Color[4];
            mArrowCol = Color.FromArgb(120, 200, 255, 200);
        }

        public delegate void MotorMoveDelegate(Object sender, MachineControlAxis axis, float val);
        public delegate void MotorHomeDelegate(Object sender, MachineControlAxis axis);
        
        [Description("Base color of all graphics"), Category("Data")]
        public Color FrameColor
        {
            get { return mFrameColor; }
            set { mFrameColor = value; UpdateColors();  UpdateBitmaps(); }
        }
        
        protected void DrawImageCentered(Graphics gr, Image img, int x, int y)
        {
            int w = img.Width;
            int h = img.Height;
            gr.DrawImage(img, x - w / 2, y - h / 2, w, h);
        }

        protected void DrawText(Graphics gr, string str, float x, float y, Color col, bool outline = false)
        {
            SizeF sf = gr.MeasureString(str, Font);
            x -= sf.Width / 2;
            y -= sf.Height / 2;
            if (outline)
            {
                Brush bkbr = new SolidBrush(Color.FromArgb(128, Color.Black));
                gr.DrawString(str, Font, bkbr, x + 1, y + 1);
            }
            Brush br = new SolidBrush(col);
            gr.DrawString(str, Font, br, x, y);
        }

        protected virtual Color GetLevelColor(int anum)
        {
            if (anum == 0)
                return mFrameColor;
            return Color.FromArgb(
                mFrameColor.A,
                mFrameColor.R + (anum * (255 - mFrameColor.R)) / 4,
                mFrameColor.G + (anum * (255 - mFrameColor.G)) / 4,
                mFrameColor.B + (anum * (255 - mFrameColor.B)) / 4
            );
        }

        protected void UpdateColors()
        {
            for (int i = 0; i < 4; i++)
            {
                mLevelColors[i] = GetLevelColor(i);
            }
            mSelColor = Color.FromArgb(mFrameColor.A, 255 - mFrameColor.R, 255 - mFrameColor.G, 255 - mFrameColor.B);

        }

        protected virtual void UpdateBitmaps()
        {
        }
    }
}
