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
        Color [] mArchColors;
        PointF[] mArchTxtPos;
        Image mCentImg;
        int mSelAxis;
        int mSelLevel;
        int mCenter;
        double mInRad;
        double mButtRad;
        double mArchWidth;
        int mCircWidth;
        float[] mArchVals;

        //int mCircsize;
        public ctlMCXY()
        {
            InitializeComponent();
            mArches = new Image[4];
            mArchesSel = new Image[4];
            mArchesUnsel = new Image[4];
            mOffsets = new Rectangle[4];
            mArchColors = new Color[4];
            mArchTxtPos = new PointF[4];
            mFrameColor = Color.RoyalBlue;
            mArchVals = new float[] { 0.1f, 1, 10, 100 };
            DoubleBuffered = true;
            mSelAxis = 0;
            mSelLevel = 0;
            mCircWidth = 238;
            Height = mCircWidth;
            Width = mCircWidth;
            mInRad = 35;
            mButtRad = mCircWidth / 2;
            mArchWidth = 20;
            Font = new Font("Arial", (float)(mArchWidth * 0.75), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            UpdateOffsets(mCircWidth);
            UpdateBitmaps();
        }

        [Description("Base color of all graphics"), Category("Data")]
        public Color FrameColor
        {
            get { return mFrameColor; }
            set { mFrameColor = value; UpdateBitmaps();  }
        }


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
            float vang = (float)(45.0 * Math.PI / 180.0);
            for (int i = 0; i < 4; i++)
            {
                mArchColors[i] = GetArchColor(i);
                float vlen = (float)(mInRad + mArchWidth / 2 + i * mArchWidth);
                mArchTxtPos[i] = new PointF((float)(mCenter - 16 + Math.Cos(vang) * vlen), (float)(mCenter - 10 - Math.Sin(vang) * vlen)); 
            }
            mArches[0] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px3, mArchColors[0]);
            mArches[1] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px2, mArchColors[1]);
            mArches[2] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px1, mArchColors[2]);
            mArches[3] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px0, mArchColors[3]);
            Color invCol = Color.FromArgb(mFrameColor.A, 255 - mFrameColor.R, 255 - mFrameColor.G, 255 - mFrameColor.B);
            mArchesSel[0] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px3, invCol);
            mArchesSel[1] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px2, invCol);
            mArchesSel[2] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px1, invCol);
            mArchesSel[3] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px0, invCol);
            mCentImg = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_cent, mArchColors[3]);
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

            // text
            for (int i = 0; i < 4; i++)
            {
                DrawText(gr, mArchVals[i].ToString(), mArchTxtPos[i].X, mArchTxtPos[i].Y, mArchColors[i], true);
            }

            // center
            int lvl = Math.Abs(mSelLevel) - 1;
            if ((lvl >= 0) && (lvl <= 3))
            {
                int w = mCentImg.Width;
                int h = mCentImg.Height;
                gr.DrawImage(mCentImg, mCenter - w / 2, mCenter - h / 2, w, h);
                DrawText(gr, mArchVals[lvl].ToString(), mCenter, mCenter, mArchColors[0], true);
            }
        }

        void DrawText(Graphics gr, string str, float x, float y, Color col, bool outline = false)
        {
            SizeF sf = gr.MeasureString(str, Font);
            x -= sf.Width / 2;
            y -= sf.Height / 2;
            if (outline)
            {
                Brush bkbr = new SolidBrush(Color.FromArgb(128, Color.Black));
                gr.DrawString(str, Font, bkbr, x+1, y+1);
            }
            Brush br = new SolidBrush(col);
            gr.DrawString(str, Font, br, x, y);
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

        public override void ApplyStyle(ControlStyle ct)
        {
            base.ApplyStyle(ct);
            BackColor = ct.BackColor;
            ForeColor = ct.ForeColor;
            FrameColor = ct.FrameColor;
        }
    }
}
