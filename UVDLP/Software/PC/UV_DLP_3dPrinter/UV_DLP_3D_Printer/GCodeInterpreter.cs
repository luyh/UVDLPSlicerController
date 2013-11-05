using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Engine3D;
using System.Drawing;
using System.Collections;

namespace UV_DLP_3D_Printer
{
    /// <summary>
    /// This class interprets loaded or generated GCode
    /// it's primary purpose is to generate polylines that can be viewed
    /// in either the 3d or 2d viewer
    /// </summary>
    public class GCodeInterpreter
    {
        private class colormapitem
        {
            public colormapitem(int gc, Color color) 
            {
                m_gc = gc;
                m_color = color;
            }
            public int m_gc; // the gcode to map
            public Color m_color;
        }
        private static colormapitem[] colormap = 
        {
            new colormapitem(0,Color.Green),
            new colormapitem(1,Color.Blue)
        };

        private int m_curline; // what line we're on
        private string[] gcode; // the gcode lines we're interpreting
        //keep track of current and previous values
        private double CX, CY, CZ, CE1, CE2; // current values 
        private double PX, PY, PZ, PE1, PE2; // previous value 
        private double F; // Feed rate
        //private bool m_mmunits; // units are in mm
        //private bool m_abs; // movement is absolute
        //private bool m_extabs; // extrusion units are absolute
        private Thread m_thread = null;
        private bool m_done;
        private double FAST_FEED = 3000; // defines what a fast feed rate is
        private PolyLine3d m_curpolyline;
        public ArrayList m_listply;
        

        public GCodeInterpreter() 
        {
            Reset();
        }

        private Color GetColor(int gc) 
        {
            Color col = Color.Red;
            foreach (colormapitem ci in colormap) 
            {
                if (ci.m_gc == gc) 
                {
                    col = ci.m_color;
            
                }
            }
            if (F > FAST_FEED) 
            {
                col = Color.Red;
            }
            return col; 
        }
        /// <summary>
        /// resets all values
        /// </summary>
        private void Reset() 
        {
            //m_mmunits = true;
            //m_abs = true;
            //m_extabs = true;
            CX = CY = CZ = CE1 = CE2 = 0.0;
            PX = PY = PZ = PE1 = PE2 = 0.0;
            m_done = false;
            m_curline = 0;
            m_curpolyline = new PolyLine3d();
            m_listply = new ArrayList();
            m_listply.Add(m_curpolyline);
        }
        public void AddLinesToEngine(double zlev) 
        {
            double epsilon = .25;
            foreach (PolyLine3d ln in m_listply) 
            {
                try
                {
                    Point3d p = (Point3d)ln.m_points[0];
                    if (zlev != -9999)
                    {
                        if (p.z >= (zlev - epsilon) && p.z <= (zlev + epsilon)) // show only the specified height level
                        {
                            UVDLPApp.Instance().Engine3D.AddLine(ln);
                        }
                    }
                    else // show all 
                    {
                        UVDLPApp.Instance().Engine3D.AddLine(ln);
                    }
                }catch(Exception)
                {
                
                }
            }
        }
        /// <summary>
        /// this sets the gcode being interpreted
        /// </summary>
        public string[] GCode 
        {
            set 
            { 
                gcode = value;
                Reset(); // reset all values
            }
        }
        public void StartInterpret() 
        {
            m_thread = new Thread(new ThreadStart(Interpret));
            m_thread.Start();
        }

        #region String Helpers
        private bool HasMoreLines() 
        {
            if (m_curline >= gcode.Length) 
            {
                return false;
            }
            return true;
        }
        private string RemoveComment(string line) 
        {
            string retstr = "";
            String[] Lines = line.Split(';');
            if (Lines.Length > 0)
            {
                retstr = Lines[0];
                retstr += "\r\n"; // make sure to capp it off                               
            }
            return retstr;
        }
        private bool HasComment(string line) 
        {
            if (line.Contains(";") || line.Contains("("))  // line with comment
            {
                return true;
            }
            return false;            
        }
        private bool IsBlank(string line) 
        {
            if (line.Length == 0) // blank line
            {
                return true;
            }
            if (line.StartsWith(";") || line.StartsWith("("))  // line with comment
            {
                return true;
            }
            return false;
        }

        private string GetNextLine() 
        {
            try
            {
                return gcode[m_curline++];
            }
            catch (Exception) 
            {
                return "";        
            }
        }
        #endregion
        #region variable Getters and Setters
        private double X 
        {
            set 
            {
                PX = CX;
                CX = value;
            }
            get { return CX;}
        }
        private double Y
        {
            set
            {
                PY = CY;
                CY = value;
            }
            get { return CY; }
        }
        private double Z
        {
            set
            {
                PZ = CZ;
                CZ = value;
                // the z level changed, create a new poly line and add it
//                if (PZ != CZ)
                {
                    m_curpolyline = new PolyLine3d(new Point3d(PX, PY, PZ, 1), new Point3d(CX, CY, CZ, 1),Color.Yellow);
                    m_listply.Add(m_curpolyline);

                    m_curpolyline = new PolyLine3d();
                    m_listply.Add(m_curpolyline);
                }
            }
            get { return CZ; }
        }
        private double E1
        {
            set
            {
                PE1 = CE1;
                CE1 = value;
            }
            get { return CE1; }
        }
        private double E2
        {
            set
            {
                PE2 = CE2;
                CE2 = value;
            }
            get { return CE2; }
        }
        #endregion

        /// <summary>
        /// Get G or M code
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private int GetGMCode(string line) 
        {
            try
            {
                string[] lines = line.Split(' ');
                if (lines.Length > 0)
                {
                    return int.Parse(lines[0].Substring(1));
                }
            }
            catch (Exception) 
            { }
            return -1; // error
        }
        private double GetVar(string line, string var) 
        {
            try
            {
                string[] lines = line.Split(' ');
                foreach (string l in lines) 
                {
                    if (l.StartsWith(var)) 
                    {
                        return double.Parse(l.Substring(1));
                    }
                }                
            }
            catch (Exception)
            { }
            return -9999; // error
        }
        private void InterpretGCode(string line) 
        {
            int gc = GetGMCode(line);
            switch (gc) 
            {
                case 0:
                    GetVarsXYZ(line);
                    m_curpolyline.m_color = GetColor(gc);
                    break;
                case 1:
                    GetVarsXYZ(line);
                    m_curpolyline.m_color = GetColor(gc);
                    break;
            }
        }
        private void GetVarsXYZ(string line) 
        {
            double x, y, z;
            bool hasxy = false;
            x = GetVar(line, "X");
            if (x != -9999)
            {
                X = x;
                hasxy = true;
            }
            y = GetVar(line, "Y");
            if (y != -9999)
            {
                Y = y;
                hasxy = true;
            }
            z = GetVar(line, "Z");
            if (z != -9999)
            {
                Z = z;
            }

            double f = GetVar(line, "F");
            if (f != -9999) 
            {
                F = f;
            }

            if (hasxy) 
            {
                m_curpolyline.AddPoint(new Point3d(X, Y, Z, 1));
            }
        }

        private void InterpretMCode(string line) 
        {
        
        }
        private void Interpret() 
        {
            while (!m_done) 
            {
                try
                {
                    string line = "";
                    // check to see if we're done
                    if (!HasMoreLines())
                    {
                        m_done = true;
                        break; // break out of this while loop
                    }
                    else // get a line
                    {
                        line = GetNextLine();
                        line = line.ToUpper().Trim();
                    }
                    if (IsBlank(line)) // empty line
                        continue;
                    if (HasComment(line)) // remove comments from the end of lines
                    {
                        line = RemoveComment(line);
                    }                    
                    // set some state variables,
                    //determine what needs to be done
                    //check if the line contains (starts with G or M)
                    if (line.StartsWith("G"))
                    {
                        InterpretGCode(line);
                    }
                    else if (line.StartsWith("M"))
                    {
                        InterpretMCode(line);
                    }
                    else 
                    {
                        // line did not start with G or M
                    }
                }
                catch (Exception ex) 
                {
                    DebugLogger.Instance().LogError(ex.Message);
                }
            }
        }
    }
}
