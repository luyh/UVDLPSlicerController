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
    public partial class ctlMCXY : ctlUserPanel
    {
        Image[] mArches;
        Image[] mArchesSel;
        Image[] mArchesUnsel;
        Rectangle[] mOffsets;
        Color mFrameColor;
        int mSelAxis;
        int mSelLevel;
        int mCenter;
        double mInRad;
        double mButtRad;
        double mArchWidth;

        //int mCircsize;
        public ctlMCXY()
        {
            InitializeComponent();
            mArches = new Image[4];
            mArchesSel = new Image[4];
            mArchesUnsel = new Image[4];
            mOffsets = new Rectangle[4];
            mFrameColor = Color.RoyalBlue;
            DoubleBuffered = true;
            UpdateOffsets(238);
            UpdateBitmaps();
            mSelAxis = 0;
            mSelLevel = 0;
            Height = 238;
            Width = 238;
            mInRad = 35;
            mArchWidth = 20;
            mButtRad = Width / 2;
        }

       /* [DefaultValue(Color.RoyalBlue)]
        [Description("Base color of "), Category("Data")]
        public String OnClickCallback
        {
            get { return mOnClickCallback; }
            set { mOnClickCallback = value; }
        }*/


        // d = diameter of big circle in pixels
        void UpdateOffsets(int d)
        {
            mCenter = d / 2;
            int w = global::UV_DLP_3D_Printer.Properties.Resources.mc_px0.Width;
            int h = global::UV_DLP_3D_Printer.Properties.Resources.mc_px0.Height;
            mOffsets[0] = new Rectangle((d - w) / 2, 0, w, h);
            mOffsets[1] = new Rectangle((d - w) / 2, -d, w, h);
            mOffsets[2] = new Rectangle((d - w) / 2 - d, -d, w, h);
            mOffsets[3] = new Rectangle((d - w) / 2 - d, 0, w, h);
        }


        Color GetArchColor(int anum)
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

        void UpdateBitmaps()
        {
            mArches[0] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px3, GetArchColor(0));
            mArches[1] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px2, GetArchColor(1));
            mArches[2] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px1, GetArchColor(2));
            mArches[3] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px0, GetArchColor(3));
            Color invCol = Color.FromArgb(mFrameColor.A, 255 - mFrameColor.R, 255 - mFrameColor.G, 255 - mFrameColor.B);
            mArchesSel[0] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px3, invCol);
            mArchesSel[1] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px2, invCol);
            mArchesSel[2] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px1, invCol);
            mArchesSel[3] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px0, invCol);
        }

        // return correct arched image based on axis and level:
        // axis: 0=X 1=Y
        // level: 1 to 4 and -1 to -4: selected arch level where 1 and -1 are closer to the center
        Image GetArchImage(int axis, int level)
        {
            if ((mSelAxis == axis) && (mSelLevel == level))
                return mArchesSel[4-Math.Abs(level)];
            return mArches[4-Math.Abs(level)];
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics gr = e.Graphics;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            GraphicsState gs = gr.Save();

            gr.DrawImage(GetArchImage(1, 4), mOffsets[0]);
            gr.DrawImage(GetArchImage(1, 3), mOffsets[0]);
            gr.DrawImage(GetArchImage(1, 2), mOffsets[0]);
            gr.DrawImage(GetArchImage(1, 1), mOffsets[0]);

            gr.RotateTransform(90);
            gr.DrawImage(GetArchImage(0, 4), mOffsets[1]);
            gr.DrawImage(GetArchImage(0, 3), mOffsets[1]);
            gr.DrawImage(GetArchImage(0, 2), mOffsets[1]);
            gr.DrawImage(GetArchImage(0, 1), mOffsets[1]);

            gr.RotateTransform(90);
            gr.DrawImage(GetArchImage(1, -4), mOffsets[2]);
            gr.DrawImage(GetArchImage(1, -3), mOffsets[2]);
            gr.DrawImage(GetArchImage(1, -2), mOffsets[2]);
            gr.DrawImage(GetArchImage(1, -1), mOffsets[2]);

            gr.RotateTransform(90);
            gr.DrawImage(GetArchImage(0, -4), mOffsets[3]);
            gr.DrawImage(GetArchImage(0, -3), mOffsets[3]);
            gr.DrawImage(GetArchImage(0, -2), mOffsets[3]);
            gr.DrawImage(GetArchImage(0, -1), mOffsets[3]);

            gr.Restore(gs);
        }

        protected int  GetSelection(int x, int y, out int axis)
        {
            axis = mSelAxis;
            int level;
            double rad = Math.Sqrt(x * x + y * y);
            if (rad > mButtRad)
            {
                // handle corner buttons
                return 0;
            }
            rad = (rad - mInRad) / mArchWidth;
            if (rad < 0)
                return 0;
            level = (int)rad + 1;
            if (level > 4)
                return 0;

            // test angle to find quad
            double angle = Math.Atan2(y, x) * 180.0 / Math.PI + 45.0;
            if (angle < 0)
                angle += 360.0;
            int quad = (int)(angle / 90);
            angle = angle - quad * 90;
            if ((angle < 5) || (angle > 85))
                return 0;
            switch (quad)
            {
                case 0: axis = 0; break;
                case 1: axis = 1; break;
                case 2: axis = 0; level = -level; break;
                case 3: axis = 1; level = -level; break;
            }
            return level;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int x = e.X - mCenter;
            int y = mCenter - e.Y;
            int axis;
            int level = GetSelection(x, y, out axis);
            if ((level != mSelLevel) || (axis != mSelAxis))
            {
                mSelAxis = axis;
                mSelLevel = level;
                Invalidate();
            }
        }
    }
}
