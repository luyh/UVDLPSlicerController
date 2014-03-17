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
        All = 3
    }

    public partial class ctlMCXY : ctlUserPanel
    {
        Image[] mArches;
        Image[] mArchesSel;
        Image[] mArchesUnsel;
        Rectangle[] mOffsets;
        Color mFrameColor;
        Color [] mArchColors;
        Color mSelColor;
        Color mArrowCol;
        PointF[] mArchTxtPos;
        Image mCentImg, mCentImgSel;
        Image mTRCornerImg, mTRCornerImgSel;
        Image mTLCornerImg, mTLCornerImgSel;
        Image mHomeImg, mhomeImgCent;
        Image mArrowU, mArrowD, mArrowL, mArrowR;
        int mSelAxis, mLastSelAxis;
        int mSelLevel, mLastSelLevel;
        int mCenter;
        int mButMin, mButMax;
        int mButHomePos;
        int mArrowPos;
        double mInRad;
        double mButtRad;
        double mArchWidth;
        int mCircWidth;
        float[] mArchVals;

        public delegate void MotorMoveDelegate(Object sender, MachineControlAxis axis, float val);
        public event MotorMoveDelegate MotorMove;
        public delegate void MotorHomeDelegate(Object sender, MachineControlAxis axis);
        public event MotorHomeDelegate MotorHome;

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
            mCircWidth = 256;
            Height = mCircWidth;
            Width = mCircWidth;
            mInRad = 35;
            mButtRad = mCircWidth / 2;
            mArchWidth = 20;
            mCenter = mCircWidth / 2;
            mButMin = mCenter - 60;
            mButMax = mCenter - 10;
            mButHomePos = 25;
            mArrowPos = (int)(mCenter + mInRad) / 2;

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
            mArrowCol = Color.FromArgb(120, 200, 255, 200);
            mArches[0] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px3, mArchColors[0]);
            mArches[1] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px2, mArchColors[1]);
            mArches[2] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px1, mArchColors[2]);
            mArches[3] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px0, mArchColors[3]);
            mSelColor = Color.FromArgb(mFrameColor.A, 255 - mFrameColor.R, 255 - mFrameColor.G, 255 - mFrameColor.B);
            mArchesSel[0] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px3, mSelColor);
            mArchesSel[1] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px2, mSelColor);
            mArchesSel[2] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px1, mSelColor);
            mArchesSel[3] = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_px0, mSelColor);
            // center
            mCentImg = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_cent, mArchColors[3]);
            mCentImgSel = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_cent, mSelColor);
            // corners
            mTRCornerImg = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_trcorner, mFrameColor);
            mTRCornerImgSel = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_trcorner, mSelColor);
            mTLCornerImg = C2DGraphics.RotateBmp90deg(mTRCornerImg, 3);
            mTLCornerImgSel = C2DGraphics.RotateBmp90deg(mTRCornerImgSel, 3);
            mHomeImg = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_home, mArchColors[3]);
            mhomeImgCent = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_home, mFrameColor);
            // arrows
            mArrowU = C2DGraphics.ColorizeBitmapHQ(global::UV_DLP_3D_Printer.Properties.Resources.mc_uparrow, mArrowCol);
            mArrowR = C2DGraphics.RotateBmp90deg(mArrowU, 1);
            mArrowD = C2DGraphics.RotateBmp90deg(mArrowU, 2);
            mArrowL = C2DGraphics.RotateBmp90deg(mArrowU, 3);
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
            if (lvl >= 0)
            {
                bool isPressed = (mSelAxis == mLastSelAxis) && (mSelLevel == mLastSelLevel);
                DrawImageCentered(gr, isPressed ? mCentImgSel : mCentImg, mCenter, mCenter);
                if ((lvl >= 0) && (lvl <= 3))
                {
                    DrawText(gr, (mSelAxis == 0) ? "X" : "Y", mCenter, mCenter - Font.Height / 2, mFrameColor, true);
                    String txt = (mSelLevel < 0) ? "-" : "";
                    txt += mArchVals[lvl].ToString();
                    DrawText(gr, txt, mCenter, mCenter + Font.Height / 2, mFrameColor, true);
                }
                if (lvl == 4)
                {
                    DrawImageCentered(gr, mhomeImgCent, mCenter, mCenter);
                    DrawText(gr, (mSelAxis == 0) ? "X" : "Y", mCenter, mCenter + 4, mArchColors[3]);
                }
            }

            // corners
            bool issel = ((mSelAxis == 1) && (mSelLevel == 5));
            Image cornImg = issel ? mTRCornerImgSel : mTRCornerImg;
            gr.DrawImage(cornImg, mCircWidth - mTRCornerImg.Width, 0, mTRCornerImg.Width, mTRCornerImg.Height);
            DrawImageCentered(gr, mHomeImg, mCircWidth - mButHomePos, mButHomePos);
            DrawText(gr, "Y", mCircWidth - mButHomePos, mButHomePos + 4, issel ? mSelColor : mFrameColor);

            issel = ((mSelAxis == 0) && (mSelLevel == 5));
            cornImg = issel ? mTLCornerImgSel : mTLCornerImg;
            gr.DrawImage(cornImg, 0, 0, mTRCornerImg.Width, mTRCornerImg.Height);
            DrawImageCentered(gr, mHomeImg, mButHomePos, mButHomePos);
            DrawText(gr, "X", mButHomePos, mButHomePos + 4, issel ? mSelColor : mFrameColor);

            // arrows
            Color atcol = Color.FromArgb(120, 0, 0, 0);
            DrawImageCentered(gr, mArrowU, mCenter, mCenter - mArrowPos);
            DrawText(gr, "+Y", mCenter, mCenter - mArrowPos, atcol);
            DrawImageCentered(gr, mArrowR, mCenter + mArrowPos, mCenter);
            DrawText(gr, "+X", mCenter + mArrowPos, mCenter, atcol);
            DrawImageCentered(gr, mArrowD, mCenter, mCenter + mArrowPos);
            DrawText(gr, "-Y", mCenter, mCenter + mArrowPos, atcol);
            DrawImageCentered(gr, mArrowL, mCenter - mArrowPos, mCenter);
            DrawText(gr, "-X", mCenter - mArrowPos, mCenter, atcol);
        }

        void DrawImageCentered(Graphics gr, Image img, int x, int y)
        {
            int w = img.Width;
            int h = img.Height;
            gr.DrawImage(img, x - w / 2, y - h / 2, w, h);
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
                if ((y < mButMin) || (y > mButMax) || (x < -mButMax) || (x > mButMax))
                    return 0;
                if (x < -mButMin)
                    axis = 0;
                else if (x > mButMin)
                    axis = 1;
                else
                    return 0;
                return 5;
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            mLastSelAxis = mSelAxis;
            mLastSelLevel = mSelLevel;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            int lvl = Math.Abs(mSelLevel) - 1;
            if (lvl < 0)
                return;
            if ((mLastSelLevel == mSelLevel) && (mLastSelAxis == mSelAxis))
            {
                if ((lvl >=0) && (lvl <= 3) && (MotorMove != null))
                {
                    float res = mArchVals[lvl];
                    if (mSelLevel < 0)
                        res = -res;
                    MotorMove(this, (mSelAxis == 0) ? MachineControlAxis.X : MachineControlAxis.Y, res);
                }
                if ((lvl == 4) && (MotorHome != null))
                {
                    MotorHome(this, (mSelAxis == 0) ? MachineControlAxis.X : MachineControlAxis.Y);
                }
            }
            mLastSelLevel = 0;
            Invalidate();
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
