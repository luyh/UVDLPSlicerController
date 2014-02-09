using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using UV_DLP_3D_Printer._3DEngine;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public class ctlText : ctlUserPanel 
    {
        //string mText = "";
        string mGLFont = "";
        C2DFont mGLFontCache;

        /*[DefaultValue("")] */
        [Description("Display text"), Category("Data")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override String Text
        {
            get { return base.Text; }
            set { base.Text = value; Invalidate(); }
        }

        [DefaultValue("")]
        [Description("GL font name"), Category("Data")]
        public String GLFont
        {
            get { return mGLFont; }
            set { mGLFont = value; mGLFontCache = null; }
        }

        public override void OnGLPaint(C2DGraphics gr)
        {
            base.OnGLPaint(gr);
            if ((Text == null) || (Text.Length == 0))
                return;

            if (mGLFontCache == null)
            {
                mGLFontCache = gr.GetFont(mGLFont);
                if (mGLFontCache == null)
                    return;
            }
            gr.SetColor(ForeColor);
            int dlen = mGLFontCache.DispLength(Text);
            int x = (Width - dlen) / 2;
            int y = (Height - mGLFontCache.height) / 2;
            gr.Text(mGLFontCache, x, y, Text);
        }
 
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
    }
}
