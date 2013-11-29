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
        Rectangle mDstrc;
        Rectangle mSrcrc;
        const int nSubImages = 4;
        int mSubImgWidth;

        [Description("Horizontal space from anchored location"), Category("Data")]
        public Image Image
        {
            get { return mImage; }
            set { 
                mImage = value;
                ScaleImage();
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
            mSubImgWidth = mImage.Width / nSubImages;
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
            mSrcrc = new Rectangle(0, 0, mSubImgWidth, mImage.Height);
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
            if (Image != null)
            {
                mSrcrc.X = mSubImgWidth * index;
                gr.DrawImage(Image, mDstrc, mSrcrc, GraphicsUnit.Pixel);
            }
            //base.OnPaint(pevent);
        }

        private void InitializeComponent()
        {
        }
    }
}
