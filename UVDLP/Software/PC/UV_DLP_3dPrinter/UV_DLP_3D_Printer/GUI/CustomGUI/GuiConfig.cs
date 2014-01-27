using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using UV_DLP_3D_Printer._3DEngine;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    abstract class DecorItem
    {
        public abstract void Show(C2DGraphics g2d, int w, int h);
    }

    class DecorImage : DecorItem
    {
        public DecorImage(string name, string docking, int x, int y, Color col)
        {
            this.name = name;
            this.docking = docking;
            this.x = x;
            this.y = y;
            this.color = col;
        }
        string name;
        string docking; // tl = top left, rc = right center, nn = no dock, etc
        int x, y;       // gap to edge when docked, absolute if not
        Color color;

        public override void Show(C2DGraphics g2d, int w, int h)
        {
            int iw, ih;
            g2d.GetImageDim(name, out iw, out ih);
            int px = GuiConfig.GetPosition(0, w, iw, x, docking[1]);
            int py = GuiConfig.GetPosition(0, h, ih, y, docking[0]);
            g2d.SetColor(color);
            g2d.Image(name, px, py);
        }
    }

    class DecorBar : DecorItem
    {
        public DecorBar(string docking, int w, Color col) // solid bar
        {
            this.docking = docking;
            this.bw = w;
            coltl = col;
            coltr = col;
            colbl = col;
            colbr = col;
        }

        public DecorBar(string docking, int w, Color coltl, Color coltr, Color colbl, Color colbr) // gradient bar
        {
            this.docking = docking;
            this.bw = w;
            this.coltl = coltl;
            this.coltr = coltr;
            this.colbl = colbl;
            this.colbr = colbr;
        }

        string docking; // t = top, b = bottom, l = left, r = right, n = no dock (fullscreen)
        int bw;         // bar width
        Color coltl, coltr, colbl, colbr;
        public override void Show(C2DGraphics g2d, int w, int h)
        {
            int px, py, pw, ph;
            switch (docking)
            {
                case "t": px = 0; py = 0; pw = w; ph = bw; break;
                case "b": px = 0; py = h - bw; pw = w; ph = bw; break;
                case "l": px = 0; py = 0; pw = bw; ph = h; break;
                case "r": px = w - bw; py = 0; pw = bw; ph = h; break;
                default: px = 0; py = 0; pw = w; ph = h; break;
            }
            g2d.GradientRect(px, py, pw, ph, coltl, coltr, colbl, colbr);
        }
    }

    public class ColorScheme
    {
        public ColorScheme(Color forecol, Color backcol)
        {
            ForeColor = forecol;
            BackColor = backcol;
        }

        public Color ForeColor;
        public Color BackColor;
    }

    public class GuiConfig
    {
        public enum EntityType { Buttons, Panels, Decals }

        Dictionary<String, ctlAnchorable> Controls;
        Dictionary<String, ctlImageButton> Buttons;
        List<DecorItem> BgndDecorList;
        List<DecorItem> FgndDecorList;
        ColorScheme ControlsCS;
        ColorScheme ButtonsCS;
        ResourceManager Res;


        public GuiConfig()
        {
            BgndDecorList = new List<DecorItem>();
            FgndDecorList = new List<DecorItem>();
            Controls = new Dictionary<string, ctlAnchorable>();
            Buttons = new Dictionary<string, ctlImageButton>();
            ControlsCS = new ColorScheme(Color.Black, Color.White);
            ButtonsCS = new ColorScheme(Color.Black, Color.White);
            Res = global::UV_DLP_3D_Printer.Properties.Resources.ResourceManager;
        }

        public void AddControl(string name, ctlAnchorable ctl)
        {
            Controls[name] = ctl;
        }

        public void AddButton(string name, ctlImageButton ctl)
        {
            Buttons[name] = ctl;
        }

        public void SetColorScheme(EntityType entity, ColorScheme colcs)
        {
            switch (entity)
            {
                case EntityType.Buttons:
                    ButtonsCS = colcs;
                    break;

                case EntityType.Panels:
                    ControlsCS = colcs;
                    break;
            }
        }

        public static int GetPosition(int refpos, int refwidth, int width, int gap, Char anchor)
        {
            int retval = 0;
            switch (anchor)
            {
                case 't':
                case 'l':
                    retval = refpos + gap;
                    break;

                case 'c':
                    retval = refpos + (refwidth - width) / 2 + gap;
                    break;

                case 'r':
                case 'b':
                    retval = refpos + refwidth - width - gap;
                    break;
                default:
                    retval = gap;
                    break;
            }
            return retval;
        }

        public void LoadConfiguration(String xmlConf)
        {
            try
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlConf));
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(ms);
                XmlNode rootnode = xdoc.ChildNodes[1];
                if (rootnode.Name != "GuiConfig")
                    return;

                foreach (XmlNode xnode in rootnode.ChildNodes)
                {
                    switch (xnode.Name)
                    {
                        case "decals": HandleDecals(xnode); break;
                        case "buttons": HandleButtons(xnode); break;
                    }
                }

            }
            catch (Exception) { }
        }

        #region Decals

        void HandleDecals(XmlNode decalnode)
        {
            foreach (XmlNode xnode in decalnode.ChildNodes)
            {
                switch (xnode.Name)
                {
                    case "bar": HandleBars(xnode); break;
                    case "image": HandleImages(xnode); break;
                }
            }
        }

        List<DecorItem> GetListFromLevel(XmlNode xnode)
        {
            List<DecorItem> dlist = FgndDecorList;
            if (GetStrParam(xnode, "level", "") == "background")
            {
                dlist = BgndDecorList;
            }
            return dlist;
        }


        void HandleBars(XmlNode barnode)
        {
            string docking = GetStrParam(barnode, "dock", "n").ToLower();
            int w = GetIntParam(barnode, "width", 100);
            List<DecorItem> dlist = GetListFromLevel(barnode);
            if (GetStrParam(barnode, "color", null) == null)
            {
                Color coltl = GetColorParam(barnode, "tlcolor", Color.White);
                Color coltr = GetColorParam(barnode, "trcolor", Color.White);
                Color colbl = GetColorParam(barnode, "blcolor", Color.White);
                Color colbr = GetColorParam(barnode, "brcolor", Color.White);
                dlist.Add(new DecorBar(docking, w, coltl, coltr, colbl, colbr));
            }
            else
            {
                Color col = GetColorParam(barnode, "color", Color.White);
                dlist.Add(new DecorBar(docking, w, col));
            }
        }

        void HandleImages(XmlNode imgnode)
        {
            string name = GetStrParam(imgnode, "name", null);
            if (name == null)
                return;
            string docking = FixDockingVal(GetStrParam(imgnode, "dock", "cc"));
            int x = GetIntParam(imgnode, "x", 0);
            int y = GetIntParam(imgnode, "y", 0);
            Color col = GetColorParam(imgnode, "color", Color.White);
            int opacity = GetIntParam(imgnode, "opacity", -1) * 255 / 100;
            if ((opacity >= 0) && (opacity <= 255))
                col = Color.FromArgb(opacity, col.R, col.G, col.B);
            List<DecorItem> dlist = GetListFromLevel(imgnode);
            dlist.Add(new DecorImage(name, docking, x, y, col));
        }
        #endregion

        #region Buttons
        void HandleButtons(XmlNode buttnode)
        {
            foreach (XmlNode xnode in buttnode.ChildNodes)
            {
                switch (xnode.Name)
                {
                    case "colortheme": HandleButtColorTheme(xnode); break;
                    case "button": HandleButton(xnode); break;
                }
            }
        }

        void HandleButtColorTheme(XmlNode xnode)
        {
            Color fcol = GetColorParam(xnode, "fore", Color.FromArgb(0));
            if (fcol != Color.FromArgb(0))
                ButtonsCS.ForeColor = fcol;
            Color bcol = GetColorParam(xnode, "fore", Color.FromArgb(0));
            if (bcol != Color.FromArgb(0))
                ButtonsCS.BackColor = bcol;
            foreach (KeyValuePair<String, ctlImageButton> pair in Buttons)
            {
                ctlImageButton butt = pair.Value;
                if (fcol != Color.FromArgb(0))
                    butt.ForeColor = fcol;
                if (bcol != Color.FromArgb(0))
                    butt.BackColor = bcol;
            }
        }

        void HandleButton(XmlNode buttnode)
        {
            string name = GetStrParam(buttnode, "name", null);
            if (name == null)
                return;
            if (!Buttons.ContainsKey(name))
                return;
            ctlImageButton butt = Buttons[name];
            butt.GuiAnchor = FixDockingVal(GetStrParam(buttnode, "dock", butt.GuiAnchor));
            butt.Gapx = GetIntParam(buttnode, "x", butt.Gapx);
            butt.Gapy = GetIntParam(buttnode, "y", butt.Gapy);
            butt.Image = GetImageParam(buttnode, "image", butt.Image);
            butt.CheckImage = GetImageParam(buttnode, "check", butt.CheckImage);
        }

        #endregion

        #region Attribute parsing
        string GetStrParam(XmlNode xnode, string paramName, string defVal)
        {
            try
            {
                string res = xnode.Attributes[paramName].Value;
                return res;
            }
            catch (Exception)
            {
                return defVal;
            }
        }

        int GetIntParam(XmlNode xnode, string paramName, int defVal)
        {
            try
            {
                int res = int.Parse(xnode.Attributes[paramName].Value);
                return res;
            }
            catch (Exception)
            {
                return defVal;
            }
        }
 
        Color GetColorParam(XmlNode xnode, string paramName, Color defVal)
        {
            Color res;
            try
            {
                string sres = xnode.Attributes[paramName].Value;
                if (sres[0] == '#')
                {
                    sres = sres.Substring(1);
                    if (sres.Length > 7)
                        res = Color.FromArgb(int.Parse(sres, System.Globalization.NumberStyles.HexNumber));
                    else
                        res = Color.FromArgb((int)(long.Parse(sres, System.Globalization.NumberStyles.HexNumber) | 0xFF000000));
                }
                else
                {
                    res = Color.FromName(sres);
                }
                return res;
            }
            catch (Exception)
            {
                return defVal;
            }

        }

        Image GetImageParam(XmlNode xnode, string paramName, Image defVal)
        {
            string imgname = GetStrParam(xnode, paramName, null);
            if (imgname == null)
                return defVal;
            Image img = (Image)Res.GetObject(imgname);
            if (img == null)
                return defVal;
            return img;
        }

        string FixDockingVal(string origdock)
        {
            if (origdock == null)
                return "cc";
            string dock = origdock.ToLower();
            while (dock.Length < 2)
                dock += "c";
            return dock;
        }
        #endregion

        #region Perform layout

        void Draw(List<DecorItem> dlist, C2DGraphics g2d, int w, int h)
        {
            foreach (DecorItem di in dlist)
            {
                di.Show(g2d, w, h);
            }
        }

        public void DrawForeground(C2DGraphics g2d, int w, int h)
        {
            Draw(FgndDecorList, g2d, w, h);
        }

        public void DrawBackground(C2DGraphics g2d, int w, int h)
        {
            Draw(BgndDecorList, g2d, w, h);
        }

        public void LayoutGui(int w, int h)
        {
            LayoutButtons(w, h);
        }

        void LayoutButtons(int w, int h)
        {
            foreach (KeyValuePair<String, ctlImageButton> pair in Buttons)
            {
                ctlImageButton butt = pair.Value;
                int px = GetPosition(0, w, butt.Width, butt.Gapx, butt.GuiAnchor[1]);
                int py = GetPosition(0, h, butt.Height, butt.Gapy, butt.GuiAnchor[0]);
                butt.Location = new System.Drawing.Point(px, py);
            }
        }

        #endregion
    }
}
