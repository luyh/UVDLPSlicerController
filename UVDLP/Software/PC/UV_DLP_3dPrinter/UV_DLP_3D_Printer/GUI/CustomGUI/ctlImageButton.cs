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
        private int mStateIndex;
        int mGapx, mGapy;
        AnchorTypes mAnchorHoriz;
        AnchorTypes mAnchorVert;
        Control mCtlRefPos;
        bool mAnchorIn;
 
       // public enum AnchorTypes
        Image mImage;

        [Description("Horizontal space from anchored location"), Category("Data")]
        public Image Image
        {
            get { return mImage; }
            set { mImage = value; Invalidate(); }
        }


        public ctlImageButton()
        {
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            OnPaintBackground(pevent);
            Graphics gr = pevent.Graphics;
            int index = (int)mCtlState;
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


        private void InitializeComponent()
        {
        }
    }
}
