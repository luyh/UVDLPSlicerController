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
    public class GuiConfigManager
    {
       // public enum EntityType { Buttons, Panels, Decals } // not used

        //Dictionary<String, ctlUserPanel> Controls;
        Dictionary<String, Control> Controls;
        Dictionary<String, ctlImageButton> Buttons;
        Dictionary<String, GuiControlStyle> GuiControlStylesDict;
        List<GuiDecorItem> BgndDecorList;
        List<GuiDecorItem> FgndDecorList;
        ResourceManager Res; // the resource manager for the main CW application
        IPlugin Plugin;
        Control mTopLevelControl = null;
        public GuiControlStyle DefaultControlStyle;
        public GuiControlStyle DefaultButtonStyle;
        


        public GuiConfigManager()
        {
            Controls = new Dictionary<string, Control>();
            Buttons = new Dictionary<string, ctlImageButton>();
            GuiControlStylesDict = new Dictionary<string, GuiControlStyle>();
            BgndDecorList = new List<GuiDecorItem>();
            FgndDecorList = new List<GuiDecorItem>();
            Res = global::UV_DLP_3D_Printer.Properties.Resources.ResourceManager;
            Plugin = null;
            DefaultControlStyle = new GuiControlStyle("DefaultControl");
            DefaultControlStyle.SetDefault();
            DefaultButtonStyle = new GuiControlStyle("DefaultButton");
            DefaultButtonStyle.SetDefault();
        }

        public Control TopLevelControl
        {
            get { return mTopLevelControl; }
            set { mTopLevelControl = value; }
        }

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

        public GuiControlStyle GetControlStyle(string name)
        {
            if ((name == null) || !GuiControlStylesDict.ContainsKey(name))
                return null;
            return GuiControlStylesDict[name];
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

        public void ApplyConfiguration(GuiConfigDB conf)
        {
            try
            {
                // read and store all styles
                foreach (KeyValuePair<string, GuiControlStyle> pair in conf.GuiControlStylesDict)
                    GuiControlStylesDict[pair.Key] = pair.Value;

                HandleDecals(conf);
                HandleButtons(conf);
                HandleControls(conf);
                HandleSequences(conf);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }


        #region Sequences
        
        void HandleSequences(GuiConfigDB conf) 
        {
            foreach (CommandSequence cmdseq in conf.CmdSequenceList)
            {
                if (cmdseq.type == CommandSequence.CSType.gcode)
                {
                    GCodeSequence gcseq = new GCodeSequence(cmdseq.name, cmdseq.sequence);
                    SequenceManager.Instance().Add(gcseq);
                }
            }

        }
        #endregion

        #region Decals

        void HandleDecals(GuiConfigDB conf)
        {
            if (conf.HideAllDecals)
            {
                BgndDecorList = conf.BgndDecorList;
                FgndDecorList = conf.FgndDecorList;
            }
            BgndDecorList.AddRange(conf.BgndDecorList);
            FgndDecorList.AddRange(conf.FgndDecorList);
        }

        #endregion

        #region Buttons
        void HandleButtons(GuiConfigDB conf)
        {
            if (conf.HideAllButtons.IsExplicit() && conf.HideAllButtons)
                HideAllButtons();

            // apply default style if exists
            GuiControlStyle defstl = conf.GetControlStyle("DefaultButton");
            if (defstl != null)
            {
                DefaultButtonStyle = defstl;
                foreach (KeyValuePair<String, ctlImageButton> pair in Buttons)
                {
                    ctlImageButton butt = pair.Value;
                    butt.ApplyStyle(defstl);
                }
            }
            foreach (KeyValuePair<string, GuiButton> pair in conf.GuiButtonsDict)
                HandleButton(conf, pair.Value);
        }

        void HandleButton(GuiConfigDB conf, GuiButton gbtn)
        {
            if (!Buttons.ContainsKey(gbtn.name))
            {
                // create a new empty button
                AddButton(gbtn.name, new ctlImageButton());
                Buttons[gbtn.name].BringToFront();
            }
            ctlImageButton butt = Buttons[gbtn.name];
//            butt.Visible = true;
            butt.Visible = gbtn.visible.GetIfExplicit(true);
            butt.GuiAnchor = gbtn.dock.GetIfExplicit(butt.GuiAnchor);
            butt.Gapx = gbtn.x.GetIfExplicit(butt.Gapx);
            butt.Gapy = gbtn.y.GetIfExplicit(butt.Gapy);
            butt.Width = gbtn.w.GetIfExplicit(butt.Width);
            butt.Height = gbtn.h.GetIfExplicit(butt.Height);
            butt.StyleName = gbtn.style.GetIfExplicit(butt.StyleName);
            butt.OnClickCallback = gbtn.onClickCmd.GetIfExplicit(butt.OnClickCallback);
            GuiControlStyle bstl = conf.GetControlStyle(butt.StyleName);
            if (bstl != null)
            {
                butt.GLVisible = bstl.glMode;
            }
            if (gbtn.image.IsExplicit())
            {
                butt.GLImage = gbtn.image;
                butt.Image = conf.GetImage(gbtn.image, null);
            }
            butt.CheckImage = conf.GetImage(gbtn.checkImage, butt.CheckImage);


            // add the ability to add buttons in various named parents
            // this will allow adding buttons to toolbar from plugins
            if (gbtn.action.IsExplicit())
            {
                string action = gbtn.action;
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
                    string parentname = gbtn.parent;
                    if (gbtn.parent.IsExplicit() && (parentname != null) && (parentname.Length != 0))
                    {
                        //find the parent
                        if (Controls.ContainsKey(parentname))
                        {
                            Control ctlParent = Controls[parentname];
                            ctlParent.Controls.Add(butt);
                        }
                        else
                        {
                            DebugLogger.Instance().LogWarning("Button parent not found: " + parentname);
                        }
                    }
                }
            }
        }

        #endregion

        #region Controls
        void HandleControls(GuiConfigDB conf)
        {
            if (conf.HideAllControls.IsExplicit() && conf.HideAllControls)
                HideAllControls();
            // apply default style if exists
            GuiControlStyle stl = conf.GetControlStyle("DefaultControl");
            
            if (stl != null)
            {
                DefaultControlStyle = stl;
                foreach (KeyValuePair<String, Control> pair in Controls)
                {
                    if (pair.Value is ctlUserPanel)
                    {
                        ctlUserPanel ctl = (ctlUserPanel)pair.Value;
                        ctl.ApplyStyle(stl);
                    }
                    else
                    {
                        // apply the style by recursing through the object
                        ApplyStyleRecurse(pair.Value, stl);
                    }
                }
            }
            
            foreach (KeyValuePair<string, GuiControl> pair in conf.GuiControlsDict)
                HandleControl(conf, pair.Value);
        }

        #region style applying for non-ctlUsercontrol controls
        public void ApplyStyleRecurse(Control ctl, GuiControlStyle ct)
        {

            if ((ctl is ctlUserPanel) || ct.applyWindowsControls)
            {
                if (ct.BackColor != ControlStyle.NullColor)
                    ctl.BackColor = ct.BackColor;

                if (ct.ForeColor != ControlStyle.NullColor)
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

        #endregion

        void HandleControl(GuiConfigDB conf, GuiControl gctl)
        {
            if (!Controls.ContainsKey(gctl.name))
                return;

            Control ct = Controls[gctl.name]; // find the existing control
            if (gctl.visible.IsExplicit())
                ct.Visible = gctl.visible.GetVal();
            ct.Width = gctl.w.GetIfExplicit(ct.Width);
            ct.Height = gctl.h.GetIfExplicit(ct.Height);
            //load some control locations as well,

            if (gctl.px.IsExplicit() || gctl.py.IsExplicit())
            {
                int px, py;
                px = gctl.px.GetIfExplicit(ct.Location.X);
                py = gctl.py.GetIfExplicit(ct.Location.Y);
                Point pt = new Point(px, py);
                ct.Location = pt;
            }

            // load docking style
            if (gctl.action.IsExplicit())
            {
                string action = gctl.action;  // telling something to happen to this control
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
                    // Get the name of the parent
                    string parentname = gctl.parent;
                    if (gctl.parent.IsExplicit() && (parentname != null) && (parentname.Length != 0))
                    {
                        //find the parent
                        //find the parent
                        if (Controls.ContainsKey(parentname))
                        {
                            Control ctlParent = Controls[parentname];
                            ctlParent.Controls.Add(ct);
                        }
                        else
                        {
                            DebugLogger.Instance().LogWarning("Control parent not found: " + parentname);
                        }
                    }
                }
            }

            String styleName = gctl.style.GetIfValid(null);
            GuiControlStyle style = conf.GetControlStyle(styleName);
            if (ct is ctlUserPanel)
            {
                ctlUserPanel ctl = (ctlUserPanel)ct;
                ctl.GuiAnchor = gctl.dock.GetIfExplicit(ctl.GuiAnchor);
                ctl.Gapx = gctl.x.GetIfExplicit(ctl.Gapx);
                ctl.Gapy = gctl.y.GetIfExplicit(ctl.Gapy);
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
                    ctl.GLBackgroundImage = gctl.BorderShape.GetIfExplicit(ctl.GLBackgroundImage);
                else
                    ctl.bgndPanel.imageName = gctl.BorderShape.GetIfExplicit(ctl.bgndPanel.imageName);
            }
            else
            {
                if (style != null)
                {
                    ApplyStyleRecurse(ct, style);
                }
            }
        }

        #endregion

        #region Perform layout

        void Draw(List<GuiDecorItem> dlist, C2DGraphics g2d, int w, int h)
        {
            foreach (GuiDecorItem di in dlist)
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

        #endregion
    }
}
