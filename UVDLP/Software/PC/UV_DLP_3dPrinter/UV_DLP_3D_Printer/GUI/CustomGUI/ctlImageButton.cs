using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer._3DEngine;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlImageButton : ctlAnchorable
    { 
        Image mImage;
        Image mCheckImage;
        Rectangle mDstrc;
        Rectangle mSrcrc;
        Rectangle mCheckrc;
        const int nSubImages = 4;
        int mSubImgWidth, mSubChkImgWidth;
        String mGLImage;
        C2DImage mGLImageCach;

        [Description("Image composesed of all 4 button states"), Category("Data")]
        public Image Image
        {
            get { return mImage; }
            set
            {
                mImage = value;
                if (mImage != null)
                {
                    mSubImgWidth = mImage.Width / nSubImages;
                    mSrcrc = new Rectangle(0, 0, mSubImgWidth, mImage.Height);
                    ScaleImage();
                }
            }
        }

        [Description("Image of check/uncheck mark"), Category("Data")]
        public Image CheckImage
        {
            get { return mCheckImage; }
            set
            {
                mCheckImage = value;
                if (mCheckImage != null)
                {
                    mSubChkImgWidth = mCheckImage.Width / 2;
                    mCheckrc = new Rectangle(0, 0, mSubChkImgWidth, mCheckImage.Height);
                }
            }
        }

        [Description("GL image name"), Category("Data")]
        public String GLImage
        {
            get { return mGLImage; }
            set
            {
                mGLImage = value;
                mGLImageCach = null;
            }
        }


        public ctlImageButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            InitializeComponent();
        }

        void ScaleImage()
        {
            if (mImage == null)
                return;
            if ((Height == 0) || (Width == 0))
                return;
            float iratio = (float)mSubImgWidth / (float)Image.Height;
            float cratio = (float)Width / (float)Height;
            if (iratio > cratio)
            {
                int h = (int)((float)Width / iratio);
                mDstrc = new Rectangle(0, (Height - h) / 2, Width, h);
            }
            else
            {
                int w = (int)((float)Height * iratio);
                mDstrc = new Rectangle((Width - w) / 2, 0, w, Height);
            }
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ScaleImage();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (mGLVisible)
                return;
            base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (mGLVisible)
            {
                base.OnPaint(pevent);
                return;
            }
            Graphics gr = pevent.Graphics;
            int index = (int)mCtlState;
            if (Enabled == false)
                index = 3;
            if (mImage != null)
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                mSrcrc.X = mSubImgWidth * index;
                gr.DrawImage(mImage, mDstrc, mSrcrc, GraphicsUnit.Pixel);
                if (Enabled && (mCheckImage != null))
                {
                    mCheckrc.X = Checked ? mSubChkImgWidth : 0;
                    gr.DrawImage(mCheckImage, mDstrc, mCheckrc, GraphicsUnit.Pixel);
                }
            }
            //base.OnPaint(pevent);
        }

        public override void ApplyTheme(ControlTheme ct)
        {
            base.ApplyTheme(ct);
            if (ct.ForeColor != ControlTheme.NullColor)
                ForeColor = ct.ForeColor;
            if (ct.BackColor != ControlTheme.NullColor)
                BackColor = ct.BackColor;
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnClick(e);
        }

        private void InitializeComponent()
        {
        }

        public override void OnGLPaint(_3DEngine.C2DGraphics gr)
        {
            base.OnGLPaint(gr);
            if (mGLImageCach == null)
            {
                mGLImageCach = gr.GetImage(mGLImage);
                if (mGLImageCach == null)
                    return;
                mSubImgWidth = mGLImageCach.w / nSubImages;
            }
            int index = (int)mCtlState;
            if (Enabled == false)
                index = 3;
            if (mImage != null)
            {
                gr.SetColor(Color.White);
                mSrcrc.X = mSubImgWidth * index;
                gr.Image(mGLImageCach, mSubImgWidth * index, 0, mSubImgWidth, mGLImageCach.h, 0, 0, Width, Height);
                /*if (Enabled && (mCheckImage != null))
                {
                    mCheckrc.X = Checked ? mSubChkImgWidth : 0;
                    gr.DrawImage(mCheckImage, mDstrc, mCheckrc, GraphicsUnit.Pixel);
                }*/
            }
        }
    }
}
