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
using UV_DLP_3D_Printer.Plugin;
using UV_DLP_3D_Printer.Util.Sequence;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{

    public enum GuiParamState
    {
        Unset,
        Default,
        Inherited,
        Explicit
    }

    public class GuiParam<T>
    {
        T var;
        T defVal;
        public GuiParamState state;
        public GuiParam<T> parrent;

        public GuiParam()
        {
            state = GuiParamState.Unset;
            parrent = null;
        }

        public void SetDefault(T defval)
        {
            state = GuiParamState.Default;
            defVal = defval;
            parrent = null;
        }

        public void InheritFrom(GuiParam<T> t)
        {
            parrent = t;
            state = GuiParamState.Inherited;
        }

        public GuiParam(T defval)
        {
            SetDefault(defval);
        }

        public T GetVal()
        {
            if (state == GuiParamState.Inherited && parrent != null)
                return parrent.GetVal();
            if (state == GuiParamState.Default)
                return defVal;
            return var;
        }
        public void Save(XmlDocument xd, XmlNode parent, string name)
        {
            if (state == GuiParamState.Explicit)
                GuiConfigDB.AddParameter(xd, parent, name, var);
        }

        public static implicit operator GuiParam<T>(T t)
        {
            GuiParam<T> temp = new GuiParam<T>();
            temp.var = t;
            temp.state = GuiParamState.Explicit;
            return temp;
        }
        public static implicit operator T(GuiParam<T> t)
        {
            return t.GetVal();
        }

    }

    public abstract class GuiDecorItem
    {
        public abstract void Show(C2DGraphics g2d, int w, int h);
        public GuiParam<bool> visible = new GuiParam<bool>(true);
        public GuiParam<string> name = new GuiParam<string>();
    }

    public class GuiDecorImage : GuiDecorItem
    {
        public GuiDecorImage(string imgname, GuiParam<string> docking, GuiParam<int> x, GuiParam<int> y, GuiParam<Color> col, GuiParam<int> opacity)
        {
            this.imgname = imgname;
            this.docking = docking;
            this.x = x;
            this.y = y;
            this.col = col;
            this.opacity = opacity;
        }
        public string imgname;
        public GuiParam<string> docking; // tl = top left, rc = right center, nn = no dock, etc
        public GuiParam<int> x, y;       // gap to edge when docked, absolute if not
        public GuiParam<int> opacity;
        public GuiParam<Color> col;

        Color color
        {
            get
            {
                Color res = col;
                if (opacity.state == GuiParamState.Explicit)
                    return Color.FromArgb(opacity * 255 / 100, res.R, res.G, res.B);
                return res;
            }
        }

        public override void Show(C2DGraphics g2d, int w, int h)
        {
            if (!visible)
                return;
            int iw = 0, ih = 0;
            g2d.GetImageDim(imgname, ref iw, ref ih);
            int px = GuiConfig.GetPosition(0, w, iw, x, ((string)docking)[1]);
            int py = GuiConfig.GetPosition(0, h, ih, y, ((string)docking)[0]);
            g2d.SetColor(color);
            g2d.Image(imgname, px, py);
        }
    }

    public class GuiDecorBar : GuiDecorItem
    {
        public GuiDecorBar(GuiParam<string> docking, GuiParam<int> w, GuiParam<Color> col) // solid bar
        {
            this.docking = docking;
            this.bw = w;
            coltl = col;
            coltr = col;
            colbl = col;
            colbr = col;
            isgrad = false;
        }

        public GuiDecorBar(GuiParam<string> docking, GuiParam<int> w, GuiParam<Color> coltl, GuiParam<Color> coltr, 
            GuiParam<Color> colbl, GuiParam<Color> colbr) // gradient bar
        {
            this.docking = docking;
            this.bw = w;
            this.coltl = coltl;
            this.coltr = coltr;
            this.colbl = colbl;
            this.colbr = colbr;
            isgrad = true;
        }

        public GuiParam<string> docking; // t = top, b = bottom, l = left, r = right, n = no dock (fullscreen)
        public GuiParam<int> bw;         // bar width
        public GuiParam<Color> coltl, coltr, colbl, colbr;
        public bool isgrad;
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

    public class GuiControlPad
    {
        public GuiParam<int> Left;
        public GuiParam<int> Right;
        public GuiParam<int> Top;
        public GuiParam<int> Bottom;

        public GuiControlPad()
        {
            Left = new GuiParam<int>();
            Right = new GuiParam<int>();
            Top = new GuiParam<int>();
            Bottom = new GuiParam<int>();
        }

        public GuiControlPad(int left, int right, int top, int bottom)
        {
            Left = new GuiParam<int>(left);
            Right = new GuiParam<int>(right);
            Top = new GuiParam<int>(top);
            Bottom = new GuiParam<int>(bottom);
        }

    }

    // NOTE!! any member added to this class should be added to SetDefault(), CopyFrom(), and InheritFrom() member functions.
    public class GuiControlStyle
    {
        public static GuiParam<Color> NullColor = new GuiParam<Color>();
        //public static Color DefaultColor = Color.FromArgb(2);

        public GuiControlStyle(string name, Color forecol, Color backcol)
        {
            Name = name;
            ForeColor = forecol;
            BackColor = backcol;
            FrameColor = NullColor;
            BackImage = null;
        }

        public GuiControlStyle(string name)
        {
            Name = name;
            ForeColor = NullColor;
            BackColor = NullColor;
            FrameColor = NullColor;
            BackImage = null;
        }

        // general purpose control style
        public String Name;
        public GuiParam<Color> ForeColor;
        public GuiParam<Color> BackColor;
        public GuiParam<Color> FrameColor;
        public GuiParam<String> BackImage;
        public GuiParam<bool> glMode;

        // button styles
        public GuiParam<int> SubImgCount;
        public GuiParam<Color> PressedColor;
        public GuiParam<Color> CheckedColor;
        public GuiParam<Color> DisabledColor;
        public GuiParam<Color> HoverColor;
        public GuiParam<int> PressedSize;
        public GuiParam<int> HoverSize;
        //public GuiParam<string> BgndImageName;
        public GuiParam<String> mCheckedImage;
        C2DImage mCheckedImageCach;
        public GuiControlPad PanelPad;

        // misc
        public GuiParam<bool> applySubControls;
        public GuiParam<bool> applyWindowsControls;
        public GuiControlStyle parent; 


        public virtual void SetDefault()
        {
            ForeColor = new GuiParam<Color>(Color.White);
            BackColor = new GuiParam<Color>(Color.RoyalBlue);
            FrameColor = new GuiParam<Color>(Color.Navy);
            CheckedColor = new GuiParam<Color>(Color.Orange);
            PressedColor = new GuiParam<Color>(Color.White);
            HoverColor = new GuiParam<Color>(Color.White);
            PressedSize = new GuiParam<int>(100);
            HoverSize = new GuiParam<int>(100);
            DisabledColor = new GuiParam<Color>(Color.FromArgb(60, 255, 255, 255));
            SubImgCount = new GuiParam<int>(1);
            glMode = new GuiParam<bool>(false);
            BackImage = new GuiParam<string>();
            CheckedImage = new GuiParam<string>();
            PanelPad = new GuiControlPad(10,10,10,10);
            applySubControls = new GuiParam<bool>(true);
            applyWindowsControls = new GuiParam<bool>(false);
            parent = null;
        }

        public void CopyFrom(GuiControlStyle sctl)
        {
            if (sctl == null)
                return;

            ForeColor = sctl.ForeColor;
            BackColor = sctl.BackColor;
            FrameColor = sctl.FrameColor;
            BackImage = sctl.BackImage;
            glMode = sctl.glMode;

            SubImgCount = sctl.SubImgCount;
            PressedColor = sctl.PressedColor;
            CheckedColor = sctl.CheckedColor;
            DisabledColor = sctl.DisabledColor;
            HoverColor = sctl.HoverColor;
            PressedSize = sctl.PressedSize;
            HoverSize = sctl.HoverSize;
            PanelPad = new GuiControlPad();
            PanelPad.Left = sctl.PanelPad.Left;
            PanelPad.Right = sctl.PanelPad.Right;
            PanelPad.Top = sctl.PanelPad.Top;
            PanelPad.Bottom = sctl.PanelPad.Bottom;
            applySubControls = sctl.applySubControls;
            applyWindowsControls = sctl.applyWindowsControls;
            CheckedImage = sctl.CheckedImage;
        }
 
        public void InheritFrom(GuiControlStyle sctl)
        {
            if (sctl == null)
                return;

            parent = sctl;
            ForeColor.InheritFrom(sctl.ForeColor);
            BackColor.InheritFrom(sctl.BackColor);
            FrameColor.InheritFrom(sctl.FrameColor);
            BackImage.InheritFrom(sctl.BackImage);
            glMode.InheritFrom(sctl.glMode);

            SubImgCount.InheritFrom(sctl.SubImgCount);
            PressedColor.InheritFrom(sctl.PressedColor);
            CheckedColor.InheritFrom(sctl.CheckedColor);
            DisabledColor.InheritFrom(sctl.DisabledColor);
            HoverColor.InheritFrom(sctl.HoverColor);
            PressedSize.InheritFrom(sctl.PressedSize);
            HoverSize.InheritFrom(sctl.HoverSize);
            PanelPad = new GuiControlPad();
            PanelPad.Left.InheritFrom(sctl.PanelPad.Left);
            PanelPad.Right.InheritFrom(sctl.PanelPad.Right);
            PanelPad.Top.InheritFrom(sctl.PanelPad.Top);
            PanelPad.Bottom.InheritFrom(sctl.PanelPad.Bottom);
            applySubControls.InheritFrom(sctl.applySubControls);
            applyWindowsControls.InheritFrom(sctl.applyWindowsControls);
            CheckedImage.InheritFrom(sctl.CheckedImage);
        }

        public GuiParam<String> CheckedImage
        {
            get { return mCheckedImage; }
            set
            {
                mCheckedImage = value;
                mCheckedImageCach = null;
            }
        }

        public C2DImage CheckedImageCach
        {
            get
            {
                if (mCheckedImageCach == null)
                    mCheckedImageCach = UVDLPApp.Instance().m_2d_graphics.GetImage(mCheckedImage);
                return mCheckedImageCach;
            }
        }

    }

    public class GuiControl
    {
        public string name;
        public GuiParam<string> style;
        public GuiParam<bool> visible;
        public GuiParam<int> x, y, w, h;
        public GuiParam<int> px, py;
        public GuiParam<string> dock;
        public GuiParam<string> action;
        public GuiParam<string> parent;

        public GuiControl(string name)
        {
            this.name = name;
            parent = new GuiParam<string>();
            style = new GuiParam<string>();
            visible = new GuiParam<bool>(true);
            x = new GuiParam<int>();
            y = new GuiParam<int>();
            w = new GuiParam<int>();
            h = new GuiParam<int>();
            dock = new GuiParam<string>();
            action = new GuiParam<string>();
        }
    }

    public class GuiButton : GuiControl
    {
        public string name;
        public GuiParam<string> image;
        public GuiParam<string> checkImage;
        public GuiParam<string> onClickCmd;

        public GuiButton(string name) : base(name)
        {
            image = new GuiParam<string>();
            checkImage = new GuiParam<string>();
            onClickCmd = new GuiParam<string>();
        }
    }

    public class CommandSequence
    {
        public enum CSType
        {
            gcode,          // G Code
            comstr,         // Serial text command
            comhex          // Serial hex string
        }
        public CSType type;
        public string name;
        public string sequence;
        public CommandSequence(string name, CSType type, string sequence)
        {
            this.name = name;
            this.type = type;
            this.sequence = sequence;
        }
    }

    public class GuiConfigDB
    {
        const int FILE_VERSION = 1;
       // public enum EntityType { Buttons, Panels, Decals } // not used

        //Dictionary<String, ctlUserPanel> Controls;
        /* move to manager
        Dictionary<String, Control> Controls;
        Dictionary<String, ctlImageButton> Buttons;
         */
        Dictionary<String, GuiControlStyle> GuiControlStylesDict;
        Dictionary<String, GuiDecorItem> GuiDecorItemsDict;
        List<GuiControlStyle> GuiControlStyles;
        List<GuiControlStyle> GuiButtonStyles;
        Dictionary<String, GuiControl> GuiControlsDict;
        Dictionary<String, GuiButton> GuiButtonsDict;
        //List<GuiControl> GuiControls;
        //List<GuiButton> GuiButtons;
        List<GuiDecorItem> BgndDecorList;
        List<GuiDecorItem> FgndDecorList;
        List<CommandSequence> CmdSequenceList;
        ResourceManager Res; // the resource manager for the main CW application
        IPlugin Plugin;
        Control mTopLevelControl = null;
        public GuiControlStyle DefaultControlStyle;
        GuiParam<bool> HideAllButtons;
        GuiParam<bool> HideAllControls;
        GuiParam<bool> HideAllDecals;


        public GuiConfigDB()
        {
            //Controls = new Dictionary<string, ctlUserPanel>();
            /* move to manager
            Controls = new Dictionary<string, Control>();
            Buttons = new Dictionary<string, ctlImageButton>();
            */
            GuiControlStylesDict = new Dictionary<string, GuiControlStyle>();
            GuiDecorItemsDict = new Dictionary<string,GuiDecorItem>();

            GuiControlStyles = new List<GuiControlStyle>();
            GuiButtonStyles = new List<GuiControlStyle>();

            GuiControlsDict = new Dictionary<string, GuiControl>();
            GuiButtonsDict = new Dictionary<string, GuiButton>();
            //GuiControls = new List<GuiControl>();
            //GuiButtons = new List<GuiButton>();
            BgndDecorList = new List<GuiDecorItem>();
            FgndDecorList = new List<GuiDecorItem>();
            CmdSequenceList = new List<CommandSequence>();

            Res = global::UV_DLP_3D_Printer.Properties.Resources.ResourceManager;
            Plugin = null;
            DefaultControlStyle = new GuiControlStyle("DefaultControl");
            DefaultControlStyle.SetDefault();
            GuiControlStylesDict[DefaultControlStyle.Name] = DefaultControlStyle;
        }

        public Control TopLevelControl
        {
            get { return mTopLevelControl; }
            set { mTopLevelControl = value; }
        }
        /*
        public void AddControl(string name, ctlUserPanel ctl)
        {
            Controls[name] = ctl;
            if ((ctl.Parent == null) && (mTopLevelControl != null))
                mTopLevelControl.Controls.Add(ctl);
        }
        */

        /* move to manager
        public void AddControl(string name, Control ctl)
        {
            Controls[name] = ctl;
            if ((ctl.Parent == null) && (mTopLevelControl != null))
                mTopLevelControl.Controls.Add(ctl);
        }
        public void AddButton(string name, ctlImageButton ctl)
        {
            Buttons[name] = ctl;
            if ((ctl.Parent == null) && (mTopLevelControl != null))
                mTopLevelControl.Controls.Add(ctl);
        }
        */

        public GuiControlStyle GetControlStyle(string name)
        {
            if ((name == null) || !GuiControlStylesDict.ContainsKey(name))
                return null;
            return GuiControlStylesDict[name];
        }

        /*
        public ctlUserPanel GetControl(string name)
        {
            if (!Controls.ContainsKey(name))
                return null;
            return Controls[name];
        }
        */

        /* move to manager
        public Control GetControl(string name)
        {
            if (!Controls.ContainsKey(name))
                return null;
            return Controls[name];
        }
        public ctlImageButton GetButton(string name)
        {
            if (!Buttons.ContainsKey(name))
                return null;
            return Buttons[name];
        }
        */

        public GuiDecorItem GetDecorItem(string name)
        {
            if (!GuiDecorItemsDict.ContainsKey(name))
                return null;
            return GuiDecorItemsDict[name];
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

        public void LoadConfiguration(String xmlConf, IPlugin plugin)
        {
            Plugin = plugin;
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
                        case "controls": HandleControls(xnode); break;
                        case "sequences": LoadSequences(xnode); break;
                    }
                }

            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        public void LoadConfiguration(String xmlConf)
        {
            LoadConfiguration(xmlConf, null);
        }
        #region Sequences
        // sequences are command sequences that can be used
        // to send gcode (or other) commmands.
        // These sequences can be tied to a button onclick handler
        // this allows for creating a new button in the GUIConfig, and 
        //causing the click to send special sequences to the printer.
        
        void LoadSequences(XmlNode seqnode) 
        {
            foreach (XmlNode xnode in seqnode.ChildNodes)
            {
                switch (xnode.Name.ToLower())
                {
                    case "sequence": LoadSequence(xnode); break;                    
                }
            }

        }
        // sequences should be named with the prefix of where they came from, such as a namespace
        // for example, if a sequence is loaded from the guiconfig of
        // the plugin named plugPro, and the sequence name is goHome,
        // then the name should be: plugPro.goHome
        void LoadSequence(XmlNode seqnode) 
        {
            //get name
            GuiParam<string> name = GetStrParam(seqnode, "name", "");
            if (name.state != GuiParamState.Explicit)
            {
                DebugLogger.Instance().LogWarning("Sequence must have a name in GUIConfig");
                return;
            }
            //get sequence
            string seq = GetStrParam(seqnode, "seqdata", "");
            //get type
            string seqtype = GetStrParam(seqnode, "seqtype", "");
            if (seqtype.ToLower().Equals("gcode"))
            {
                CmdSequenceList.Add(new CommandSequence(name, CommandSequence.CSType.gcode, seq));
                /* move to manager
                GCodeSequence gcseq = new GCodeSequence(name, seq);
                SequenceManager.Instance().Add(gcseq);
                 */
            }
            else
            {
                DebugLogger.Instance().LogWarning("Unknown sequence type " + seqtype + " in GUIConfig");
            }
        }
        #endregion

        #region Decals

        void HandleDecals(XmlNode decalnode)
        {
            HideAllDecals = GetBoolParam(decalnode, "HideAll", false);
            foreach (XmlNode xnode in decalnode.ChildNodes)
            {
                switch (xnode.Name)
                {
                    case "bar": HandleBars(xnode); break;
                    case "image": HandleImages(xnode); break;
                }
            }
        }

        List<GuiDecorItem> GetListFromLevel(XmlNode xnode)
        {
            List<GuiDecorItem> dlist = FgndDecorList;
            if (GetStrParam(xnode, "level", "") == "background")
            {
                dlist = BgndDecorList;
            }
            return dlist;
        }


        void HandleBars(XmlNode barnode)
        {
            GuiParam<string> docking = GetDockingParam(barnode, "dock", "n");
            GuiParam<int> w = GetIntParam(barnode, "width", 100);
            string name = GetStrParam(barnode, "name", null);
            List<GuiDecorItem> dlist = GetListFromLevel(barnode);
            GuiDecorItem dcr = null;
            if (GetStrParam(barnode, "color", null) == null)
            {
                Color coltl = GetColorParam(barnode, "tlcolor", Color.White);
                Color coltr = GetColorParam(barnode, "trcolor", Color.White);
                Color colbl = GetColorParam(barnode, "blcolor", Color.White);
                Color colbr = GetColorParam(barnode, "brcolor", Color.White);
                dcr = new GuiDecorBar(docking, w, coltl, coltr, colbl, colbr);
            }
            else
            {
                Color col = GetColorParam(barnode, "color", Color.White);
                dcr = new GuiDecorBar(docking, w, col);
            }
            dlist.Add(dcr);
            if (name != null)
            {
                dcr.name = name;
                GuiDecorItemsDict[name] = dcr;
            }
        }

        void HandleImages(XmlNode imgnode)
        {
            string imgname = GetStrParam(imgnode, "image", null);
            if (imgname == null)
                return;
            string name = GetStrParam(imgnode, "name", null);
            GuiParam<string> docking = GetDockingParam(imgnode, "dock", "cc");
            GuiParam<int> x = GetIntParam(imgnode, "x", 0);
            GuiParam<int> y = GetIntParam(imgnode, "y", 0);
            GuiParam<Color> col = GetColorParam(imgnode, "color", Color.White);
            GuiParam<int> opacity = GetIntParam(imgnode, "opacity", -1);
            List<GuiDecorItem> dlist = GetListFromLevel(imgnode);
            GuiDecorItem dcr = new GuiDecorImage(imgname, docking, x, y, col, opacity);
            dlist.Add(dcr);
            if (name != null)
            {
                dcr.name = name;
                GuiDecorItemsDict[name] = dcr;
            }
        }
        #endregion

        #region Buttons
        void HandleButtons(XmlNode buttnode)
        {
            /* move to manager
            if (GetBoolParam(buttnode, "HideAll", false))
                HideAllButtons();
             */
            HideAllButtons = GetBoolParam(buttnode, "HideAll", false);
            foreach (XmlNode xnode in buttnode.ChildNodes)
            {
                switch (xnode.Name)
                {
                    case "style": HandleButtonStyle(xnode); break;
                    case "button": HandleButton(xnode); break;
                }
            }
        }

        void HandleButtonStyle(XmlNode xnode)
        {
            string name = GetStrParam(xnode, "name", "DefaultButton");
            GuiControlStyle bt = GetControlStyle(name);
            if (bt == null)
            {
                bt = new GuiControlStyle(name);
                GuiControlStylesDict[name] = bt;
                GuiButtonStyles.Add(bt);
                bt.SetDefault();
            }
            UpdateStyle(xnode, bt);

            /* move to manager
            if (name == "DefaultButton")
            {
                foreach (KeyValuePair<String, ctlImageButton> pair in Buttons)
                {
                    ctlImageButton butt = pair.Value;
                    butt.ApplyStyle(bt);
                }
            }
             */
        }

        void HandleButton(XmlNode buttnode)
        {
            string name = GetStrParam(buttnode, "name", null);
            if (name == null)
                return;
            /* move to manager
            if (!Buttons.ContainsKey(name))
            {
                // create a new empty button
                AddButton(name, new ctlImageButton());
                Buttons[name].BringToFront();
            }
             */
            GuiButton butt = null;
            if (!GuiButtonsDict.ContainsKey(name))
            {
                butt = new GuiButton(name);
                GuiButtonsDict[name] = butt;
            }
            else
                butt = GuiButtonsDict[name];

            //ctlImageButton butt = Buttons[name];
//            butt.Visible = true;
            butt.visible = GetBoolParam(buttnode, "visible", true);
            butt.dock = GetDockingParam(buttnode, "dock", "cc");
            butt.x = GetIntParam(buttnode, "x", 0);
            butt.y = GetIntParam(buttnode, "y", 0);
            butt.w = GetIntParam(buttnode, "w", 0);
            butt.h = GetIntParam(buttnode, "h", 0);
            butt.style = GetStrParam(buttnode, "style", null);
            butt.onClickCmd = GetStrParam(buttnode, "click", null);
            /* move to manager
            GuiControlStyle bstl = GetControlStyle(butt.StyleName);
            if (bstl != null)
            {
                butt.GLVisible = bstl.glMode;
            }
            //butt.GLVisible = GetBoolParam(buttnode, "gl", butt.GLVisible);
             */

            butt.image = GetStrParam(buttnode, "image", null);
            /* move to manager
            if (imgname != null)
            {
                butt.GLImage = imgname;
                butt.Image = GetImageParam(buttnode, "image", null);
            }
             
            butt.CheckImage = GetImageParam(buttnode, "check", butt.CheckImage);
            */
            butt.checkImage = GetStrParam(buttnode, "check", null);
            butt.action = GetStrParam(buttnode, "action", null);
            butt.parent = GetStrParam(buttnode, "parent", null);

            /* move to manager
            // add the ability to add buttons in various named parents
            // this will allow adding buttons to toolbar from plugins
            string action = GetStrParam(buttnode, "action", "none");  // telling something to happen to this control
            if (action.Contains("remove")) // this handles removing a control from it's parent
            {
                // remove this control from it's parent
                if (butt.Parent != null)
                {
                    butt.Parent.Controls.Remove(butt);
                    butt.Parent = null;
                }
            }
            else if (action.Contains("addto")) // this handles adding a new control to a parent control
            {
                // Get the name of the parent
                string parentname = GetStrParam(buttnode, "parent", "");
                if (parentname == null) return;
                if (parentname.Length == 0) return;
                //find the parent
                Control ctlParent = Controls[parentname];
                if (ctlParent == null)
                {
                    DebugLogger.Instance().LogWarning("Button parent now found: " + parentname);
                    return;
                }
                {
                    ctlParent.Controls.Add(butt);
                }
            }
             */
        }

        #endregion

        #region Controls
        void HandleControls(XmlNode ctlnode)
        {
            /* move to manager
            if (GetBoolParam(ctlnode, "HideAll", false))
                HideAllControls();
             **/
            HideAllControls = GetBoolParam(ctlnode, "HideAll", false);
            foreach (XmlNode xnode in ctlnode.ChildNodes)
            {
                switch (xnode.Name)
                {
                    case "style": HandleControlStyle(xnode); break;
                    case "control": HandleControl(xnode); break;
                }
            }
        }
        
        void HandleControlStyle(XmlNode xnode)
        {
            string name = GetStrParam(xnode, "name", "DefaultControl");
            GuiControlStyle ct = GetControlStyle(name);
            if (ct == null)
            {
                ct = new GuiControlStyle(name);
                GuiControlStylesDict[name] = ct;
                GuiControlStyles.Add(ct);
                ct.SetDefault();
            }
            UpdateStyle(xnode, ct);

            /* move to manager
            if (name == "DefaultControl")
            {
                //foreach (KeyValuePair<String, ctlUserPanel> pair in Controls)
                foreach (KeyValuePair<String, Control> pair in Controls)
                {
                    if (pair.Value is ctlUserPanel)
                    {
                        ctlUserPanel ctl = (ctlUserPanel)pair.Value;
                        ctl.ApplyStyle(DefaultControlStyle);
                    }
                    else 
                    {
                        // apply the style by recursing through the object
                        ApplyStyleRecurse(pair.Value, DefaultControlStyle);
                    }
                }
            }
             */
        }
        #region style applying for non-ctlUsercontrol controls
        /* move to manager
        public void ApplyStyleRecurse(Control ctl, GuiControlStyle ct)
        {

            if ((ctl is ctlUserPanel) || ct.applyWindowsControls)
            {
                if (ct.BackColor != GuiControlStyle.NullColor)
                    ctl.BackColor = ct.BackColor;

                if (ct.ForeColor != GuiControlStyle.NullColor)
                    ctl.ForeColor = ct.ForeColor;
            }
            if (!ct.applySubControls)
                return;

            foreach (Control subctl in ctl.Controls)
            {
                if (subctl is ctlUserPanel)
                {
                    ((ctlUserPanel)subctl).ApplyStyle(ct);
                }
                else
                {
                    ApplyStyleRecurse(subctl, ct);
                }
            }
        }
        */

        #endregion

        void HandleControl(XmlNode ctlnode)
        {
            string name = GetStrParam(ctlnode, "name", null);
            if (name == null)
                return;
            GuiControl ct = null;
            if (!GuiControlsDict.ContainsKey(name))
            {
                ct = new GuiControl(name);
                GuiControlsDict[name] = ct;
            }
            else
                ct = GuiControlsDict[name];

            //ctlUserPanel ctl = Controls[name];
            /* move to manager 
             Control ct = Controls[name];
            if (ctlnode.Attributes.GetNamedItem("visible") != null)
                ct.Visible = GetBoolParam(ctlnode, "visible", ct.Visible);
             * */
            ct.visible = GetBoolParam(ctlnode, "visible", true);
            ct.x = GetIntParam(ctlnode, "x", 0);
            ct.y = GetIntParam(ctlnode, "y", 0);
            ct.w = GetIntParam(ctlnode, "w", 0);
            ct.h = GetIntParam(ctlnode, "h", 0);
            //load some control locations as well,            
            ct.px = GetIntParam(ctlnode, "px", 0);
            ct.py = GetIntParam(ctlnode, "py", 0);
            /* move to manager
            Point pt = new Point(px,py);
            ct.Location = pt;
            // load docking style
            */
            ct.action = GetStrParam(ctlnode, "action", null);
            ct.parent = GetStrParam(ctlnode, "parent", null);
            /* move to manager
            string action = GetStrParam(ctlnode, "action", "none");  // telling something to happen to this control
            if (action.Contains("remove")) // this handles removing a control from it's parent
            {
                // remove this control from it's parent
                if (ct.Parent != null)
                {
                    ct.Parent.Controls.Remove(ct);
                    ct.Parent = null;
                }
            }
            else if (action.Contains("hide")) // this handles hiding
            {
                // hide this control, do not remove it from the parent
                ct.Hide();
            }
            else if (action.Contains("show")) // this handles showing
            {
                // show this control
                ct.Show();
            }
            else if (action.Contains("addto")) // this handles adding a new/existing control to a parent control
            {
                // Get the name of the parent
                string parentname = GetStrParam(ctlnode, "parent", "");
                if (parentname == null) return;
                if (parentname.Length == 0) return;
                //find the parent
                Control ctlParent = Controls[parentname];
                if (ctlParent == null) 
                {
                    DebugLogger.Instance().LogWarning("Control parent not found: " + parentname);
                    return;
                }
                {
                    ctlParent.Controls.Add(ct);
                }
            }
             */

            ct.style = GetStrParam(ctlnode, "style", null);
            /* move to manager
            String styleName = GetStrParam(ctlnode, "style", null);
            GuiControlStyle style = GetControlStyle(styleName);
            if (ct is ctlUserPanel)
            {
                ctlUserPanel ctl = (ctlUserPanel)ct;
                ctl.GuiAnchor = FixDockingVal(GetStrParam(ctlnode, "dock", ctl.GuiAnchor));
                ctl.Gapx = GetIntParam(ctlnode, "x", ctl.Gapx);
                ctl.Gapy = GetIntParam(ctlnode, "y", ctl.Gapy);
                if (styleName != null)
                {
                    ctl.StyleName = styleName;
                    if (style != null)
                    {
                        ctl.GLVisible = style.glMode;
                        ctl.ApplyStyle(style);
                    }
                }
                //ctl.GLVisible = GetBoolParam(ctlnode, "gl", false);
                if (ctl.GLVisible)
                    ctl.GLBackgroundImage = GetStrParam(ctlnode, "shape", ctl.GLBackgroundImage);
                else
                    ctl.bgndPanel.imageName = GetStrParam(ctlnode, "shape", ctl.bgndPanel.imageName);
            }
            else
            {
                if (style != null)
                {
                    ApplyStyleRecurse(ct, style);
                }
            }
             * */
        }

        #endregion


        #region Attribute parsing
        GuiParam<string> GetStrParam(XmlNode xnode, string paramName, object defVal)
        {
            GuiParam<string> res;
            if (defVal is GuiParam<string>)
                res = (GuiParam<string>)defVal;
            else
                res = new GuiParam<string>((string)defVal);
            try
            {
                res = xnode.Attributes[paramName].Value;
            }
            catch (Exception) { }
            return res;
        }

        GuiParam<int> GetIntParam(XmlNode xnode, string paramName, object defVal)
        {
            GuiParam<int> res;
            if (defVal is GuiParam<int>)
                res = (GuiParam<int>)defVal;
            else
                res = new GuiParam<int>((int)defVal);
            try
            {
                res = int.Parse(xnode.Attributes[paramName].Value);
            }
            catch (Exception) { }
            return res;
        }

        int [] GetIntArrayParam(XmlNode xnode, string paramName)
        {
            List<int> num = new List<int>();
            string val = GetStrParam(xnode, paramName, null);
            if (val == null)
                return new int[0];
            foreach (string snum in val.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    int tnum = int.Parse(snum);
                    num.Add(tnum);
                }
                catch { }
            }
            int[] res = new int[num.Count];
            for (int i = 0; i < num.Count; i++)
                res[i] = num[i];
            return res;
        }

        GuiParam<bool> GetBoolParam(XmlNode xnode, string paramName, object defVal)
        {
            GuiParam<bool> res;
            if (defVal is GuiParam<bool>)
                res = (GuiParam<bool>)defVal;
            else
                res = new GuiParam<bool>((bool)defVal);
            try
            {
                res = bool.Parse(xnode.Attributes[paramName].Value);
            }
            catch (Exception) { }
            return res;
        }

        GuiParam<Color> GetColorParam(XmlNode xnode, string paramName, object defVal)
        {
            GuiParam<Color> res;
            if (defVal is GuiParam<Color>)
                res = (GuiParam<Color>)defVal;
            else
                res = new GuiParam<Color>((Color)defVal);
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
                else if (sres == "null")
                {
                    res.state = GuiParamState.Unset;
                }
                else if (sres == "default")
                {
                    res.state = GuiParamState.Default;
                }
                else
                {
                    res = Color.FromName(sres);
                }
            }
            catch (Exception) { }
            return res;
        }

        /* move to manager
        Image GetImageParam(XmlNode xnode, string paramName, Image defVal)
        {
            string imgname = GetStrParam(xnode, paramName, null);
            if (imgname == null)
                return defVal;
            Image img = null;
            if (Plugin != null)
                img = Plugin.GetImage(imgname);
            if (img == null) // try to get from the 2d graphics first
                img = UVDLPApp.Instance().m_2d_graphics.GetBitmap(imgname);
            if (img == null)
                img = (Image)Res.GetObject(imgname);
            if (img == null)
                return defVal;
            return img;
        }
         * */

        string FixDockingVal(string origdock)
        {
            if (origdock == null)
                return "cc";
            string dock = origdock.ToLower();
            while (dock.Length < 2)
                dock += "c";
            return dock;
        }

        GuiParam<string> GetDockingParam(XmlNode xnode, string paramName, GuiParam<string> defVal)
        {
            GuiParam<string> res;
            if (defVal is GuiParam<string>)
                res = (GuiParam<string>)defVal;
            else
                res = new GuiParam<string>((string)defVal);
            try
            {
                string dock = xnode.Attributes[paramName].Value;
                res = FixDockingVal(dock);
            }
            catch (Exception) { }
            return res;
        }

        void UpdateStyle(XmlNode xnode, GuiControlStyle ct)
        {
            GuiControlStyle copyFromStyle = GetControlStyle(GetStrParam(xnode, "copyfrom", null));
            if (copyFromStyle != null)
                ct.InheritFrom(copyFromStyle);
            ct.ForeColor = GetColorParam(xnode, "forecolor", ct.ForeColor);
            ct.BackColor = GetColorParam(xnode, "backcolor", ct.BackColor);
            ct.FrameColor = GetColorParam(xnode, "framecolor", ct.BackColor);
            ct.glMode = GetBoolParam(xnode, "gl", ct.glMode);
            ct.CheckedColor = GetColorParam(xnode, "checkcolor", ct.CheckedColor);
            ct.HoverColor = GetColorParam(xnode, "hovercolor", ct.HoverColor);
            ct.PressedColor = GetColorParam(xnode, "presscolor", ct.PressedColor);
            ct.SubImgCount = GetIntParam(xnode, "nimages", ct.SubImgCount);
            ct.BackImage = GetStrParam(xnode, "bgndimage", ct.BackImage);
            ct.CheckedImage = GetStrParam(xnode, "checkimage", ct.CheckedImage);
            ct.DisabledColor = GetColorParam(xnode, "disablecolor", ct.DisabledColor);
            ct.HoverSize = GetIntParam(xnode, "hoverscale", ct.HoverSize);
            ct.PressedSize = GetIntParam(xnode, "pressscale", ct.PressedSize);
            ct.applySubControls = GetBoolParam(xnode, "applysubcontrols", ct.applySubControls);
            ct.applyWindowsControls = GetBoolParam(xnode, "applywincontrols", ct.applyWindowsControls);
            int[] sizes = GetIntArrayParam(xnode, "panelpad");
            if (sizes.Length >= 4)
            {
                ct.PanelPad.Left = sizes[0];
                ct.PanelPad.Right = sizes[1];
                ct.PanelPad.Top = sizes[2];
                ct.PanelPad.Bottom = sizes[3];
            }
            else if (sizes.Length >= 1)
            {
                ct.PanelPad.Left = sizes[0];
                ct.PanelPad.Right = sizes[0];
                ct.PanelPad.Top = sizes[0];
                ct.PanelPad.Bottom = sizes[0];
            }
        }

        #endregion

        #region Perform layout

        /* move to manager 
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
            LayoutControls(w, h);
        }

        void LayoutButtons(int w, int h)
        {
            foreach (KeyValuePair<String, ctlImageButton> pair in Buttons)
            {
                ctlImageButton butt = pair.Value;
                if (butt.GuiAnchor == null)
                    continue;
                int px = GetPosition(0, w, butt.Width, butt.Gapx, butt.GuiAnchor[1]);
                int py = GetPosition(0, h, butt.Height, butt.Gapy, butt.GuiAnchor[0]);
                butt.Location = new System.Drawing.Point(px, py);
            }
        }
        
        void LayoutControls(int w, int h)
        {
            foreach (KeyValuePair<String, Control> pair in Controls)
            {
                if (pair.Value is ctlUserPanel)
                {
                    ctlUserPanel ctl = (ctlUserPanel)pair.Value;
                    if (ctl.GuiAnchor == null)
                        continue;
                    int px = GetPosition(0, w, ctl.Width, ctl.Gapx, ctl.GuiAnchor[1]);
                    int py = GetPosition(0, h, ctl.Height, ctl.Gapy, ctl.GuiAnchor[0]);
                    ctl.Location = new System.Drawing.Point(px, py);
                }
                else 
                {
                    
                }
            }
        }

        public void ClearLayout()
        {
            BgndDecorList = new List<GuiDecorItem>();
            FgndDecorList = new List<GuiDecorItem>();
        }

         move to manager
        public void HideAllButtons()
        {
            foreach (KeyValuePair<String, ctlImageButton> pair in Buttons)
            {
                ctlImageButton butt = pair.Value;
                butt.Visible = false;
            }
        }

        void HideAllControls()
        {
            foreach (KeyValuePair<String, Control> pair in Controls)
            {
                Control ctl = pair.Value;
                ctl.Visible = false;
            }
        }
        */
        #endregion

        #region Save configuration
        public void SaveConfiguration(string fileName)
        {
            XmlDocument xd = new XmlDocument();
            xd.AppendChild(xd.CreateXmlDeclaration("1.0", "utf-8", ""));
            XmlNode toplevel = xd.CreateElement("GuiConfig");
            XmlAttribute verattr = xd.CreateAttribute("FileVersion");
            verattr.Value = FILE_VERSION.ToString();
            toplevel.Attributes.Append(verattr);
            xd.AppendChild(toplevel);
            SaveButtons(xd, toplevel);
            SaveControls(xd, toplevel);
            SaveDecals(xd, toplevel);
            SaveSequences(xd, toplevel);
            if (Plugin != null)
                fileName += "_" + Plugin.Name + ".xml";
            else
                fileName += ".xml";
            try
            {
                xd.Save(fileName);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError("Unable to save GUI configuration: " + ex.Message);
            }

        }

        void SaveStyle(XmlDocument xd, XmlNode xnode, GuiControlStyle stl)
        {
            if (stl.parent != null)
                AddParameter(xd, xnode, "copyfrom", stl.parent.Name);

            stl.ForeColor.Save(xd, xnode, "forecolor");
            stl.BackColor.Save(xd, xnode, "backcolor");
            stl.FrameColor.Save(xd, xnode, "framecolor");
            stl.glMode.Save(xd, xnode, "gl");
            stl.CheckedColor.Save(xd, xnode, "checkcolor");
            stl.HoverColor.Save(xd, xnode, "hovercolor");
            stl.PressedColor.Save(xd, xnode, "presscolor");
            stl.SubImgCount.Save(xd, xnode, "nimages");
            stl.BackImage.Save(xd, xnode, "bgndimage");
            stl.CheckedImage.Save(xd, xnode, "checkimage");
            stl.DisabledColor.Save(xd, xnode, "disablecolor");
            stl.HoverSize.Save(xd, xnode, "hoverscale");
            stl.PressedSize.Save(xd, xnode, "pressscale");
            stl.applySubControls.Save(xd, xnode, "applysubcontrols");
            stl.applyWindowsControls.Save(xd, xnode, "applywincontrols");
            if (stl.PanelPad.Left.state == GuiParamState.Explicit && stl.PanelPad.Right.state == GuiParamState.Explicit
                && stl.PanelPad.Top.state == GuiParamState.Explicit && stl.PanelPad.Bottom.state == GuiParamState.Explicit)
            {
                if ((int)stl.PanelPad.Left == (int)stl.PanelPad.Right && (int)stl.PanelPad.Left == (int)stl.PanelPad.Top
                    && (int)stl.PanelPad.Left == (int)stl.PanelPad.Bottom)
                {
                    AddParameter(xd, xnode, "panelpad", (int)stl.PanelPad.Left);
                }
                else
                {
                    AddParameter(xd, xnode, "panelpad", string.Format("{0},{1},{2},{3}", (int)stl.PanelPad.Left, (int)stl.PanelPad.Right,
                        (int)stl.PanelPad.Top, (int)stl.PanelPad.Bottom));
                }
            }
        }

        void SaveControlStyles(XmlDocument xd, XmlNode parent)
        {
            foreach (GuiControlStyle stl in GuiControlStyles)
            {
                XmlNode cstyle = xd.CreateElement("style");
                parent.AppendChild(cstyle);
                if (stl.Name != "DefaultControl")
                    AddParameter(xd, cstyle, "name", stl.Name);
                SaveStyle(xd, cstyle, stl);
            }
        }

        void SaveControlDefs(XmlDocument xd, XmlNode parent)
        {
            foreach (KeyValuePair<string, GuiControl> pair in GuiControlsDict)
            {
                GuiControl ct = pair.Value;
                XmlNode cnode = xd.CreateElement("control");
                parent.AppendChild(cnode);
                AddParameter(xd, cnode, "name", ct.name);
                ct.visible.Save(xd, cnode, "visible");
                ct.x.Save(xd, cnode, "x");
                ct.y.Save(xd, cnode, "y");
                ct.w.Save(xd, cnode, "w");
                ct.h.Save(xd, cnode, "h");
                ct.px.Save(xd, cnode, "px");
                ct.py.Save(xd, cnode, "py");
                ct.action.Save(xd, cnode, "action");
                ct.parent.Save(xd, cnode, "parent");
                ct.style.Save(xd, cnode, "style");
            }
        }

        void SaveControls(XmlDocument xd, XmlNode parent)
        {
            XmlNode controlssNode = xd.CreateElement("controls");
            parent.AppendChild(controlssNode);
            HideAllControls.Save(xd, controlssNode, "HideAll");
            SaveControlStyles(xd, controlssNode);
            SaveControlDefs(xd, controlssNode);
        }

        void SaveButtonStyles(XmlDocument xd, XmlNode parent)
        {
            foreach (GuiControlStyle stl in GuiButtonStyles)
            {
                XmlNode bstyle = xd.CreateElement("style");
                parent.AppendChild(bstyle);
                if (stl.Name != "DefaultButton")
                    AddParameter(xd, bstyle, "name", stl.Name);
                SaveStyle(xd, bstyle, stl);
            }
        }

        void SaveButtonDefs(XmlDocument xd, XmlNode parent)
        {
            foreach (KeyValuePair<string, GuiButton> pair in GuiButtonsDict)
            {
                GuiButton butt = pair.Value;
                XmlNode bnode = xd.CreateElement("button");
                parent.AppendChild(bnode);
                AddParameter(xd, bnode, "name", butt.name);
                butt.visible.Save(xd, bnode, "visible");
                butt.dock.Save(xd, bnode, "dock");
                butt.x.Save(xd, bnode, "x");
                butt.y.Save(xd, bnode, "y");
                butt.w.Save(xd, bnode, "w");
                butt.h.Save(xd, bnode, "h");
                butt.style.Save(xd, bnode, "style");
                butt.onClickCmd.Save(xd, bnode, "click");
                butt.image.Save(xd, bnode, "image");
                butt.checkImage.Save(xd, bnode, "check");
                butt.action.Save(xd, bnode, "action");
                butt.parent.Save(xd, bnode, "parent");
            }
        }

        void SaveButtons(XmlDocument xd, XmlNode parent)
        {
            XmlNode buttunsNode = xd.CreateElement("buttons");
            parent.AppendChild(buttunsNode);
            HideAllButtons.Save(xd, buttunsNode, "HideAll");
            SaveButtonStyles(xd, buttunsNode);
            SaveButtonDefs(xd, buttunsNode);
        }

        void SaveBar(XmlDocument xd, XmlNode parent, GuiDecorBar db, bool isBgnd)
        {
            XmlNode dbnode = xd.CreateElement("bar");
            parent.AppendChild(dbnode);
            db.docking.Save(xd, dbnode, "dock");
            db.bw.Save(xd, dbnode, "width");
            db.name.Save(xd, dbnode, "name");
            if (db.isgrad)
            {
                db.coltl.Save(xd, dbnode, "tlcolor");
                db.coltr.Save(xd, dbnode, "trcolor");
                db.colbl.Save(xd, dbnode, "blcolor");
                db.colbr.Save(xd, dbnode, "brcolor");
            }
            else
            {
                db.coltl.Save(xd, dbnode, "color");
            }
        }

        void SaveImage(XmlDocument xd, XmlNode parent, GuiDecorImage di, bool isBgnd)
        {
            XmlNode dinode = xd.CreateElement("image");
            parent.AppendChild(dinode);
            AddParameter(xd, dinode, "image", di.imgname);
            di.name.Save(xd, dinode, "name");
            di.docking.Save(xd, dinode, "dock");
            di.x.Save(xd, dinode, "x");
            di.y.Save(xd, dinode, "y");
            di.col.Save(xd, dinode, "color");
            di.opacity.Save(xd, dinode, "opacity");
        }

        void SaveDecals(XmlDocument xd, XmlNode parent)
        {
            XmlNode decNode = xd.CreateElement("decals");
            parent.AppendChild(decNode);
            HideAllDecals.Save(xd, decNode, "HideAll");
            foreach (GuiDecorItem dec in BgndDecorList)
            {
                if (dec is GuiDecorBar)
                    SaveBar(xd, decNode, (GuiDecorBar)dec, true);
                else if (dec is GuiDecorImage)
                    SaveImage(xd, decNode, (GuiDecorImage)dec, true);
            }
            foreach (GuiDecorItem dec in FgndDecorList)
            {
                if (dec is GuiDecorBar)
                    SaveBar(xd, decNode, (GuiDecorBar)dec, false);
                else if (dec is GuiDecorImage)
                    SaveImage(xd, decNode, (GuiDecorImage)dec, false);
            }

        }
        
        void SaveSequences(XmlDocument xd, XmlNode parent)
        {
            XmlNode decNode = xd.CreateElement("sequences");
            parent.AppendChild(decNode);
            foreach (CommandSequence cs in CmdSequenceList)
            {
                XmlNode csnode = xd.CreateElement("sequence");
                parent.AppendChild(csnode);
                AddParameter(xd, csnode, "name", cs.name);
                AddParameter(xd, csnode, "seqdata", cs.sequence);
                AddParameter(xd, csnode, "seqtype", cs.type.ToString());
            }
        }

        public static void AddParameter(XmlDocument xd, XmlNode parent, string name, object data)
        {
            if (data == null)
                return;
            XmlAttribute xa = xd.CreateAttribute(name);
            xa.Value = data.ToString();
            if (data is Color)
            {
                string colval = xa.Value.Substring(7, xa.Value.IndexOf(']') - 7);
                if (colval[1] == '=')
                    xa.Value = "#" + ((Color)data).ToArgb().ToString("x");
                else
                    xa.Value = colval;
            }
            parent.Attributes.Append(xa);
        }
        #endregion
    }
}
