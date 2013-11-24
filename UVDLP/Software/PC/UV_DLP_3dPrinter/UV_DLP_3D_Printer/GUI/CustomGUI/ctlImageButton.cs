using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlImageButton : Button
    {
        private int mStateIndex;
        int mGapx, mGapy;
        AnchorTypes mAnchorHoriz;
        AnchorTypes mAnchorVert;
        Control mCtlRefPos;
        bool mAnchorIn;

        public enum AnchorTypes
        {
            Top = 0,
            Left,
            Center,
            Right,
            Bottom,
            Over,
            Under,
            LeftOf,
            RightOf
        }

        public ctlImageButton()
        {
            mStateIndex = 0;
            InitializeComponent();
        }

        public void SetPositioning(AnchorTypes horiz, AnchorTypes vert, Control refpos, int gapx, int gapy)
        {
            mAnchorHoriz = horiz;
            mAnchorVert = vert;
            if ((refpos == null) || (refpos == Parent))
            {
                mAnchorIn = true;
                mCtlRefPos = Parent;
            }
            else
            {
                mAnchorIn = false;
                mCtlRefPos = refpos;
            }
            mGapx = gapx;
            mGapy = gapy;
            UpdatePosition();
        }

        protected int GetPosition(int refpos, int refwidth, int width, int gap, AnchorTypes anchor)
        {
            int retval = 0;
            switch (anchor)
            {
                case AnchorTypes.Top:
                case AnchorTypes.Left:
                    retval = refpos + gap;
                    break;

                case AnchorTypes.Center:
                    retval = refpos + (refwidth - width) / 2 + gap;
                    break;

                case AnchorTypes.Right:
                case AnchorTypes.Bottom:
                    retval = refpos + refwidth - width - gap;
                    break;

                case AnchorTypes.Over:
                case AnchorTypes.LeftOf:
                    retval = refpos - width - gap;
                    break;

                case AnchorTypes.Under:
                case AnchorTypes.RightOf:
                    retval = refpos + refwidth + gap;
                    break;
            }
            return retval;
        }


        public void UpdatePosition()
        {
            if (mCtlRefPos == null)
                return;
            int rx = mAnchorIn ? 0 : mCtlRefPos.Location.X;
            int ry = mAnchorIn ? 0 : mCtlRefPos.Location.Y;
            int x = GetPosition(rx, mCtlRefPos.Width, Width, mGapx, mAnchorHoriz);
            int y = GetPosition(ry, mCtlRefPos.Height, Height, mGapy, mAnchorVert);
            Location = new System.Drawing.Point(x,y);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            OnPaintBackground(pevent);
            Graphics gr = pevent.Graphics;
            int index = mStateIndex;
            if (Enabled == false)
                index = 3;
            if (Image != null)
            {
                int w = Image.Height;
                int x = (Width * 96 / 72 - w) / 2;
                int y = (Height * 96 / 72 - w) / 2;
                Rectangle srcrc = new Rectangle(w * index, 0, w, w);
                Rectangle dstrc = new Rectangle(0, 0, Width, Height);
                gr.DrawImage(Image, dstrc, srcrc, GraphicsUnit.Pixel);
            }
            //base.OnPaint(pevent);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mStateIndex = 1;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mStateIndex = 0;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            mStateIndex = 2;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            mStateIndex = 1;
            base.OnMouseUp(mevent);
        }

        protected override void OnResize(EventArgs e)
        {
            UpdatePosition();
            base.OnResize(e);
        }

        private void InitializeComponent()
        {
        }
    }
}
