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
    public partial class ctlImageButton : ctlAnchorable
    { 
        Image mImage;
        Image mCheckImage;
        Rectangle mDstrc;
        Rectangle mSrcrc;
        Rectangle mCheckrc;
        const int nSubImages = 4;
        int mSubImgWidth, mSubChkImgWidth;

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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics gr = pevent.Graphics;
            int index = (int)mCtlState;
            if (Enabled == false)
                index = 3;
            if (mImage != null)
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                mSrcrc.X = mSubImgWidth * index;
                gr.DrawImage(mImage, mDstrc, mSrcrc, GraphicsUnit.Pixel);
                if (mCheckImage != null)
                {
                    mCheckrc.X = Checked ? mSubChkImgWidth : 0;
                    gr.DrawImage(mCheckImage, mDstrc, mCheckrc, GraphicsUnit.Pixel);
                }
            }
            //base.OnPaint(pevent);
        }

        private void InitializeComponent()
        {
        }
    }
}
