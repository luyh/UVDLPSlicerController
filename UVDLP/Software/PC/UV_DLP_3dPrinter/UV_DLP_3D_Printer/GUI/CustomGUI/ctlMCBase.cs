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
        protected String mTitle;
        protected String mUnit;

        public ctlMCBase()
        {
            mLevelColors = new Color[4];
            mArrowCol = Color.FromArgb(120, 200, 255, 200);
            mTitle = "";
            mUnit = "";
        }

        public delegate void MotorMoveDelegate(Object sender, MachineControlAxis axis, float val);
        public delegate void MotorHomeDelegate(Object sender, MachineControlAxis axis);
        
        [Description("Base color of all graphics"), Category("Data")]
        public Color FrameColor
        {
            get { return mFrameColor; }
            set { mFrameColor = value; UpdateColors();  UpdateBitmaps(); }
        }

        [DefaultValue("")]
        [Description("Title of the control"), Category("Data")]
        public String Title
        {
            get { return mTitle; }
            set { mTitle = value; Invalidate(); }
        }

        [DefaultValue("")]
        [Description("Unit of the control"), Category("Data")]
        public String Unit
        {
            get { return mUnit; }
            set { mUnit = value; Invalidate(); }
        }

        
        protected void DrawImageCentered(Graphics gr, Image img, int x, int y)
        {
            int w = img.Width;
            int h = img.Height;
            gr.DrawImage(img, x - w / 2, y - h / 2, w, h);
        }

        protected void DrawText(Graphics gr, string str, float x, float y, Color col, bool outline = false)
        {
            if (outline)
            {
                Brush bkbr = new SolidBrush(Color.FromArgb(128, Color.Black));
                gr.DrawString(str, Font, bkbr, x + 1, y + 1);
            }
            Brush br = new SolidBrush(col);
            gr.DrawString(str, Font, br, x, y);
        }

        protected void DrawTextCentered(Graphics gr, string str, float x, float y, Color col, bool outline = false)
        {
            SizeF sf = gr.MeasureString(str, Font);
            x -= sf.Width / 2;
            y -= sf.Height / 2;
            DrawText(gr, str, x, y, col, outline);
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

        protected bool HitBitmap(int x, int y, Image img, int imgx, int imgy, int transLevel = 250)
        {
            int tx = x - imgx;
            int ty = y - imgy;
            if ((tx > 0) && (ty>0) && (tx < img.Width) && (ty < img.Height))
            {
                Color pix = ((Bitmap)img).GetPixel(tx, ty);
                if (pix.A > transLevel)
                    return true;
            }
            return false;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEventArgs me = new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, -1, -1, 0);
            OnMouseMove(me);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen = new Pen(mFrameColor,2);
            DrawRoundRectangle(gr, pen, 0, 0, Width-1, Height-1, 5);
        }


        public void DrawRoundRectangle(Graphics gr, Pen pen, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = this.GetRoundedRect(rectangle, radius);
            gr.DrawPath(pen, path);
        }


        private GraphicsPath GetRoundedRect(RectangleF baseRect,
           float radius)
        {
            if (radius <= 0.0F)
            {
                GraphicsPath mPath = new GraphicsPath();
                mPath.AddRectangle(baseRect);
                mPath.CloseFigure();
                return mPath;
            }

            // if the corner radius is greater than or equal to 
            // half the width, or height (whichever is shorter) 
            // then return a capsule instead of a lozenge 
            float minRadius = Math.Min(baseRect.Width, baseRect.Height) / 2.0f;
            if (radius >= minRadius)
                radius = minRadius;

            // create the arc for the rectangle sides and declare 
            // a graphics path object for the drawing 
            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected virtual void UpdateBitmaps()
        {
        }
    }
}
