using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// This control shows text on the left, and a number control on the right.
namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlParameter : ctlMCBase
    {
        int mTextX, mTextY;
        int mParamWidth;
        public ctlParameter()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Font = new Font("Arial", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            mTextX = 5;
            mParamWidth = 100;
            FrameColor = Color.RoyalBlue;
            ctlParam.ButtonsColor = FrameColor;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            mTextY = (Height - Font.Height) / 2;
            ctlParam.Width = mParamWidth;
            ctlParam.Height = Height - 4;
            ctlParam.Location = new Point(Width - mParamWidth - 4, 2);
            ctlParam.ButtonsColor = FrameColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            if (mTitle != null)
                DrawText(gr, mTitle, mTextX, mTextY, Style.ForeColor, true);
        }

        public ctlNumber Parameter
        {
            get { return ctlParam; }
        }
    }
}
