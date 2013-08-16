using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Engine3D;
using UV_DLP_3D_Printer;
using System.IO;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;

namespace Engine3D
{
    public class Object3d
    {
        public ArrayList m_lstpoints; // list of 3d points in object
        public ArrayList m_lstpolys;// list of polygons
        private string m_name; // just the filename
        public string m_fullname; // full path with filename
        private bool m_visible;
        public Point3d m_min, m_max,m_center;
        public bool m_wireframe = false;
        public double m_radius;
        public Object3d() 
        {
            m_lstpolys = new ArrayList();
            m_lstpoints = new ArrayList();
            m_center = new Point3d();
            m_name = "Model";
            m_fullname = "Model";
            m_min = new Point3d();
            m_max = new Point3d();
            m_visible = true;
            m_radius = 0.0;
        }
        public string Name { get { return m_name; } }
        public int NumPolys { get { return m_lstpolys.Count; } }
        public int NumPoints { get { return m_lstpoints.Count; } }
        public bool Visible 
        {
            get { return m_visible; }
            set {  m_visible = value; }
        }
        public void CalcMinMaxes() 
        {
            foreach (Polygon p in m_lstpolys) 
            {
                p.CalcMinMax();
            }
        }
        public void ClearCached() 
        {
            foreach (Polygon p in m_lstpolys)
            {
                p.ClearCached();
            }        
        }
        public void Rotate(float x, float y, float z) 
        {
            Point3d center = CalcCenter();
            Translate((float)-center.x, (float)-center.y, (float)-center.z);

            Matrix3D rotmat = new Matrix3D();
            rotmat.Identity();
            rotmat.Rotate(x, y, z);
            for(int c = 0; c< m_lstpoints.Count;c++)            
            {
                Point3d p = (Point3d)m_lstpoints[c];
                Point3d p1 = rotmat.Transform(p);
                p.x = p1.x;
                p.y = p1.y;
                p.z = p1.z;
            }
            Translate((float)center.x, (float)center.y, (float)center.z);
        }
        public void Scale(float sf) 
        {
            Point3d center = CalcCenter();
            Translate((float)-center.x, (float)-center.y, 0);
            foreach (Point3d p in m_lstpoints) 
            {
                p.x *= sf;
                p.y *= sf;
                p.z *= sf;
            }
            Translate((float)center.x, (float)center.y, 0);
        }
        public void Render() 
        {
            
        }
        
        public void RenderGL() 
        {
            foreach (Polygon poly in m_lstpolys)
            {
                poly.RenderGL(this.m_wireframe);
            }        
        }

        public void Render(Camera cam, PaintEventArgs ev, int wid, int hei)
        {

            foreach (Polygon poly in m_lstpolys) 
            {
                poly.Render(cam, ev, wid, hei);
            }
        }

        private Point3d AddUniqueVert(Point3d pnt) 
        {
            foreach (Point3d p in m_lstpoints) 
            {
                if (pnt.Equals(p)) // if it's already in the list, return it
                    return p;
            }
            m_lstpoints.Add(pnt); // otherwise add it to the list
            return pnt;
        }
        private void LoadDXFPolyPoints(out Point3d[] pnts, StreamReader sr) 
        {
            ArrayList lst = new ArrayList();
            bool done = false;
            Point3d pnt = null;
            while (!done) 
            {
                string line = sr.ReadLine();
                line = line.Trim();
                
                if (line == "10" || line == "11" || line == "12" || line == "13")
                {
                    pnt = new Point3d();
                    lst.Add(pnt);
                    pnt.x = double.Parse(sr.ReadLine());
                }
                if (line == "20" || line == "21" || line == "22" || line == "23") 
                {
                    pnt.y = double.Parse(sr.ReadLine());
                }
                if (line == "30" || line == "31" || line == "32" || line == "33") 
                {
                    pnt.z = double.Parse(sr.ReadLine());
                }
                if (line == "62") done = true;
            }
            pnts = new Point3d[lst.Count];
            int idx = 0;
            foreach (Point3d p in lst) 
            {
                pnts[idx++] = p;
            }
        
        }
        public bool GenerateFromBitmap(string file, ScaleFactor f) 
        {
            try
            {
                m_name = Path.GetFileName(file);
                Bitmap bm = new Bitmap(file);
                // add 3d points
                for (int y = 0; y < bm.Height; y++) 
                {
                    for (int x = 0; x < bm.Width; x++) 
                    {
                        Color clr = bm.GetPixel(x, y);
                        Point3d pnt = new Point3d();
                        pnt.x = f.x * ((double)x);
                        pnt.y = f.y * ((double)y);
                        pnt.z = f.z * ((double)clr.R);
                        m_lstpoints.Add(pnt);
                    }
                }
                // now generate polys
                for (int y = 0; y < bm.Height  ; y++)
                {
                    for (int x = 0; x < bm.Width ; x++)
                    {
                        if (y == (bm.Height - 1)) continue;
                        if (x == (bm.Width - 1)) continue;
                        Polygon ply = new Polygon();
                        ply.m_points = new Point3d[3];
                        int idx1 = (y * bm.Width) + x;
                        int idx2 = (y * bm.Width) + x + 1;
                        int idx3 = (y * bm.Width) + x + bm.Width ;
                        ply.m_points[0] = (Point3d)m_lstpoints[idx1];
                        ply.m_points[1] = (Point3d)m_lstpoints[idx2];
                        ply.m_points[2] = (Point3d)m_lstpoints[idx3];
                        ply.CalcCenter();
                        ply.CalcNormal();
                        m_lstpolys.Add(ply);
                        
                       
                        Polygon ply2 = new Polygon();
                        ply2.m_points = new Point3d[3];
                        idx1 = (y * bm.Width) + x + 1;
                        idx2 = (y * bm.Width) + x + bm.Width + 1;
                        idx3 = (y * bm.Width) + x + bm.Width;
                        ply2.m_points[0] = (Point3d)m_lstpoints[idx1];
                        ply2.m_points[1] = (Point3d)m_lstpoints[idx2];
                        ply2.m_points[2] = (Point3d)m_lstpoints[idx3];

                        ply2.CalcCenter();
                        ply2.CalcNormal();
                        m_lstpolys.Add(ply2);
                         
                    }
                }
                Update();
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
        public void FindMinMax()         
        {
            Point3d first = (Point3d)this.m_lstpoints[0];
            m_min.Set(first.x, first.y, first.z, 0.0);
            m_max.Set(first.x, first.y, first.z, 0.0);
            foreach (Point3d p in this.m_lstpoints)             
            {
                if (p.x < m_min.x)
                    m_min.x = p.x;
                if (p.y < m_min.y)
                    m_min.y = p.y;
                if (p.z < m_min.z)
                    m_min.z = p.z;

                if (p.x > m_max.x)
                    m_max.x = p.x;
                if (p.y > m_max.y)
                    m_max.y = p.y;
                if (p.z > m_max.z)
                    m_max.z = p.z;
            }
        
        }
        /*
         This is called after calccenter
         * it iterates through all points and finds the one that is farthest away from the center point
         */
        public void CalcRadius() 
        {
            double maxdist = 0.0;
            double td = 0.0;
            foreach (Point3d p in m_lstpoints)
            {
                td = (p.x - m_center.x) * (p.x - m_center.x);
                td += (p.y - m_center.y) * (p.y - m_center.y);
                td += (p.z - m_center.z) * (p.z - m_center.z);
                td = Math.Sqrt(td);
                if (td >= maxdist)
                    maxdist = td;
            }
            m_radius = maxdist;
        }

        public Point3d CalcCenter() 
        {
            Point3d center = new Point3d();
            center.Set(0, 0, 0, 0);
            foreach (Point3d p in m_lstpoints) 
            {
                center.x += p.x;
                center.y += p.y;
                center.z += p.z;

            }

            center.x /= m_lstpoints.Count;
            center.y /= m_lstpoints.Count;
            center.z /= m_lstpoints.Count;

            m_center.Set(center.x, center.y, center.z, 1.0);
            return center;
        }
        /*
         This function should be called after a move,scale,rotate
         */
        public void Update() 
        {
            try
            {
                //Update
                CalcCenter();
                CalcRadius();
                FindMinMax();
                foreach (Polygon p in m_lstpolys)
                {
                    p.Update();
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                DebugLogger.Instance().LogError(ex.StackTrace);
            }
        }
        /*This cuntion adds the objects points and polygons to this one*/
        public void Add(Object3d obj) 
        {
            foreach (Point3d p in obj.m_lstpoints)
            {
                m_lstpoints.Add(p);
            }
            foreach (Polygon ply in obj.m_lstpolys) 
            {
                m_lstpolys.Add(ply);
            }
            Update();
        }

        /*Move the model in object space */
        public void Translate(float x, float y, float z) 
        {
            foreach (Point3d p in m_lstpoints) 
            {
                p.x += x;
                p.y += y;
                p.z += z;
            }
            Update();
        }
        public bool LoadSTL(string filename) 
        {
            bool val = LoadSTL_Binary(filename);
            if (!val)
                return LoadSTL_ASCII(filename);
            return val;
        }


        /*
         * LoadSTL_Binary
         * This function loads a binary STL file
         * File Format:
            UINT8[80] – Header
            UINT32 – Number of triangles

            foreach triangle
            REAL32[3] – Normal vector
            REAL32[3] – Vertex 1
            REAL32[3] – Vertex 2
            REAL32[3] – Vertex 3
            UINT16 – Attribute byte count
            end         
             */
        public bool SaveSTL_Binary(string filename) 
        {
            try
            {
                BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Create));
                byte[] header = new byte[80];
                //fill in the header
                bw.Write(header, 0, 80);
                bw.Write((uint)m_lstpolys.Count);
                foreach (Polygon p in m_lstpolys) 
                {
                    //write the normal
                    bw.Write((float)p.m_normal.x);
                    bw.Write((float)p.m_normal.y);
                    bw.Write((float)p.m_normal.z);
                    foreach (Point3d pnt in p.m_points) 
                    {
                        bw.Write((float)pnt.x);
                        bw.Write((float)pnt.y);
                        bw.Write((float)pnt.z);
                    }
                    bw.Write((ushort)0); // 16 bit attribute
                }
                bw.Close();
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
        }
        public bool LoadSTL_Binary(string filename) 
        {
            BinaryReader br = null;
            try
            {
                br = new BinaryReader(File.Open(filename, FileMode.Open));
                m_fullname = filename;
                m_name = Path.GetFileName(filename);
                byte[] data = new byte[80];
                data = br.ReadBytes(80); // read the header
                uint numtri = br.ReadUInt32();
                for (uint c = 0; c < numtri; c++) 
                {
                    Polygon p = new Polygon();
                    m_lstpolys.Add(p); // add this polygon to the object
                    p.m_normal.Load(br); // load the normal
                    p.m_points = new Point3d[3]; // create storage
                    for (int pc = 0; pc < 3; pc++) //iterate through the points
                    {                       
                        p.m_points[pc] = new Point3d();
                        p.m_points[pc].Load(br);
                        m_lstpoints.Add(p.m_points[pc]);                       
                        
                    }
                    uint attr = br.ReadUInt16(); // not used attribute
                    p.CalcNormal();
                }
                
                FindMinMax();
                br.Close();
                return true;
            }
            catch (Exception) 
            {
                if(br!=null)
                    br.Close();
                return false;
            }
            
        }
        /// <summary>
        /// This function loads an ascii STL file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /*Example:
 solid Calibration_Cube
 facet normal 0.000000 0.000000 -1.000000
  outer loop
   vertex 0.000000 20.000000 0.000000
   vertex 3.797659 5.962276 0.000000
   vertex 0.000000 0.000000 0.000000
  endloop
 endfacet
 facet normal 0.000000 0.000000 -1.000000
  outer loop
   vertex 3.797659 5.962276 0.000000
   vertex 0.000000 20.000000 0.000000
   vertex 4.087683 6.240676 0.000000
  endloop
 endfacet
*/
        public bool LoadSTL_ASCII(string filename) 
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                m_fullname = filename;
                m_name = Path.GetFileName(filename);
                //first line should be "solid <name> " 
                string line = sr.ReadLine();
                string []toks = line.Split(' ');
                if (!toks[0].ToLower().StartsWith("solid"))
                    return false; // does not start with "solid"
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine().Trim();//facet
                    if (line.ToLower().StartsWith("facet"))
                    {
                        line = sr.ReadLine().Trim();//outerloop
                        if (!line.ToLower().StartsWith("outer loop")) 
                        {
                            return false;
                        }
                        Polygon poly = new Polygon();//create a new polygon                        
                        poly.m_points = new Point3d[3]; // create the storage
                        m_lstpolys.Add(poly); // add it to the polygon list

                        for (int idx = 0; idx < 3; idx++)//read the point
                        {
                            Point3d pnt = new Point3d();
                            poly.m_points[idx] = pnt;// new Point3d(); // create storage for this point
                            char[] delimiters = new char[] { ' ' };
                            line = sr.ReadLine().Trim(); // vertex
                            toks = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                            if (!toks[0].ToLower().Equals("vertex")) 
                            {
                                return false;
                            }
                           // pnt.x = double.Parse(toks[1].Trim(), System.Globalization.NumberStyles.AllowExponent | System.Globalization.NumberStyles.Float);
                           // pnt.y = double.Parse(toks[2].Trim(), System.Globalization.NumberStyles.AllowExponent | System.Globalization.NumberStyles.Float);
                           // pnt.z = double.Parse(toks[3].Trim(), System.Globalization.NumberStyles.AllowExponent | System.Globalization.NumberStyles.Float);
                            pnt.x = (double) Double.Parse(toks[1].Trim(), System.Globalization.NumberStyles.Any);
                            pnt.y = (double)Double.Parse(toks[2].Trim(), System.Globalization.NumberStyles.Any);
                            pnt.z = (double)Double.Parse(toks[3].Trim(), System.Globalization.NumberStyles.Any);
                            if (pnt.x > 100.0 || pnt.x < -100)
                            {
                                pnt.x = pnt.x;
                            }
                            if (pnt.y > 100.0 || pnt.y < -100)
                            {
                                pnt.y = pnt.y;
                            }
                            if (pnt.x > 100.0 || pnt.z < -100)
                            {
                                pnt.y = pnt.y;
                            }
                            m_lstpoints.Add(pnt);
                        }
                        line = sr.ReadLine().Trim();//endloop
                        if (!line.Equals("endloop")) 
                        {
                            return false;
                        }
                        line = sr.ReadLine().Trim().ToLower(); // endfacet
                        if (!line.Equals("endfacet"))
                        {
                            return false;
                        }

                    } // endfacet
                    else if (line.ToLower().StartsWith("endsolid"))
                    {
                        //end of model defintion
                        foreach (Point3d pnt in this.m_lstpoints) 
                        {
                            String s = String.Format("{0},{1},{2}",pnt.x,pnt.y,pnt.z);
                            DebugLogger.Instance().LogRecord(s);
                        }
                        Update(); // initial positions please...
                    }
                    else 
                    {
                        DebugLogger.Instance().LogError("Error in LoadSTL ASCII, facet expected");
                    }
                } // end of input stream
                
                
                sr.Close();
            }
            catch (Exception ex ) 
            {
                DebugLogger.Instance().LogError(ex.StackTrace);
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
            FindMinMax();
            return true;
        }
        #region 3DSLoader
        public bool Load3ds(string filename) 
        {
            BinaryReader br = null;
            try
            {
                br = new BinaryReader(File.Open(filename, FileMode.Open));
                m_fullname = filename;
                m_name = Path.GetFileName(filename);
                
                int code = br.ReadInt16();
                while (br.PeekChar() != -1)
                {
                    switch (code)
                    {
                        case 0x4D4D: // Main Chunk
                            break;
                        case 0xB000: // Keyframer Chunk - Ignore for now
                            break;
                    }
                }
                return true;
            }   
            catch (Exception e) 
            {
                DebugLogger.Instance().LogError(e.Message);
                return false;
            }
        }
        #endregion

        #region OBJ FILE LOADER
        public bool LoadObjFile(string fileName)
﻿      ﻿  {
          try
          {
        ﻿  ﻿  ﻿  if (string.IsNullOrEmpty(fileName))
        ﻿  ﻿  ﻿  {
                     return false;           
        ﻿  ﻿  ﻿  }
        ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  if (!File.Exists(fileName))
        ﻿  ﻿  ﻿  {
                     DebugLogger.Instance().LogError("3ds file could not be found " + fileName);
                     return false;
                     //﻿  ﻿  ﻿  ﻿  throw new ArgumentException("3ds file could not be found", "fileName");
        ﻿  ﻿  ﻿  }
                 this.m_fullname = fileName;
                 this.m_name = Path.GetFileNameWithoutExtension(fileName);
        ﻿  ﻿  ﻿  using (StreamReader sr = File.OpenText(fileName))
        ﻿  ﻿  ﻿  {
        ﻿  ﻿  ﻿  ﻿  
              ﻿  ﻿  ﻿  int curLineNo = 0;﻿  ﻿  ﻿  ﻿  ﻿  ﻿  
                   ﻿  ﻿  ﻿  ﻿  
              ﻿  ﻿  ﻿  string line = null;
              ﻿  ﻿  ﻿  bool done = false;
                    //ArrayList lclpoints = new ArrayList();
                    ArrayList lclply = new ArrayList();
                    ArrayList lclnrm = new ArrayList();

        ﻿  ﻿  ﻿  ﻿  while ((line = sr.ReadLine()) != null)
        ﻿  ﻿  ﻿  ﻿  {
        ﻿  ﻿  ﻿  ﻿  ﻿  curLineNo++;
        ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  if (done || line.Trim() == string.Empty || line.StartsWith("#"))
        ﻿  ﻿  ﻿  ﻿  ﻿  {
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  continue;
        ﻿  ﻿  ﻿  ﻿  ﻿  }
        ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  switch (parts[0])
        ﻿  ﻿  ﻿  ﻿  ﻿  {
        ﻿  ﻿  ﻿  ﻿  ﻿  case "v": // vertex         ﻿  ﻿  ﻿  ﻿
                        Point3d pnt = new Point3d();
                        double[] v = ParseVector(parts);
                        pnt.x = v[0];
                        pnt.y = v[1];
                        pnt.z = v[2];
              ﻿  ﻿  ﻿  ﻿  ﻿  m_lstpoints.Add(pnt);
                        break;
        ﻿  ﻿  ﻿  ﻿  ﻿  case "vn": // vertex normal
            ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  lclnrm.Add(ParseVector(parts));
            ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  break;
        ﻿  ﻿  ﻿  ﻿  ﻿  //case "g":
        ﻿  ﻿  ﻿  ﻿  //﻿  ﻿  done = true;
        ﻿  ﻿  ﻿  ﻿  //﻿  ﻿  break;
        ﻿  ﻿  ﻿  ﻿  ﻿  case "f":
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  // a face
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿                 
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  if (parts.Length > 5)
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  {
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  throw new NotSupportedException(string.Format("Face found with more than four indices (line {0})", curLineNo));
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  }
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  if (parts.Length < 3)
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  {
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  throw new FormatException(string.Format("Face found with less three indices (line {0})", curLineNo));﻿  ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  }
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿          ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿          ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  Polygon ply;
                    int fp1, fp2, fp3;
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  if (parts.Length == 4) // a triangle
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  {
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  ﻿         // tris.Add(new Triangle(ParseFacePart(parts[1]), ParseFacePart(parts[2]), ParseFacePart(parts[3])));
                              ply = new Polygon();
                              m_lstpolys.Add(ply);
                      
                              try
                              {
                                  ply.m_points = new Point3d[3];
                                  fp1 = ParseFacePart(parts[1]) - 1;
                                  fp2 = ParseFacePart(parts[2]) - 1;
                                  fp3 = ParseFacePart(parts[3]) - 1;
                                  ply.m_points[0] = (Point3d)m_lstpoints[fp1];
                                  ply.m_points[1] = (Point3d)m_lstpoints[fp2];
                                  ply.m_points[2] = (Point3d)m_lstpoints[fp3];
                                  ply.CalcCenter();
                                  ply.CalcMinMax();
                                  ply.CalcNormal();
                                  ply.CalcRadius();
                              }
                              catch (Exception ex) 
                              {
                                  DebugLogger.Instance().LogError(ex.Message);
                                  return false;

                              }
                      
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  }
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  else if ( parts.Length == 5) // a quad
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  {
                              //﻿  ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  quads.Add(new Quad(ParseFacePart(parts[1]), ParseFacePart(parts[2]), ParseFacePart(parts[3]), ParseFacePart(parts[4])));

                              ply = new Polygon();
                              m_lstpolys.Add(ply);
                              ply.m_points = new Point3d[3];
                              fp1 = ParseFacePart(parts[1]) - 1;
                              fp2 = ParseFacePart(parts[2]) - 1;
                              fp3 = ParseFacePart(parts[3]) - 1;
                              ply.m_points[0] = (Point3d)m_lstpoints[fp1];
                              ply.m_points[1] = (Point3d)m_lstpoints[fp2];
                              ply.m_points[2] = (Point3d)m_lstpoints[fp3];  ﻿  ﻿  
                             ply.CalcCenter();
                             ply.CalcMinMax();
                             ply.CalcNormal();
                             ply.CalcRadius();

                             ply = new Polygon();
                             m_lstpolys.Add(ply);
                             ply.m_points = new Point3d[3];
                             fp1 = ParseFacePart(parts[2]) - 1;
                             fp2 = ParseFacePart(parts[3]) - 1;
                             fp3 = ParseFacePart(parts[4]) - 1;
                             ply.m_points[0] = (Point3d)m_lstpoints[fp1];
                             ply.m_points[1] = (Point3d)m_lstpoints[fp2];
                             ply.m_points[2] = (Point3d)m_lstpoints[fp3]; 
                             ply.CalcCenter();
                             ply.CalcMinMax();
                             ply.CalcNormal();
                             ply.CalcRadius();
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  }
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  break;
        ﻿  ﻿  ﻿  ﻿  ﻿  }
        ﻿  ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  ﻿  }
        ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  ﻿  ﻿ // Console.WriteLine("v: {0} n: {1} q:{2}", vectors.Count,normals.Count, quads.Count);
        ﻿  ﻿  ﻿  ﻿  
        ﻿  ﻿  ﻿  }
    ﻿     ﻿  ﻿  ﻿ return true;
          }
          catch (Exception ex) 
          {
              DebugLogger.Instance().LogError(ex.Message);
              return false;
          }
﻿  ﻿  }
﻿  ﻿  
﻿  ﻿  static double[] ParseVector(string[] parts)
﻿  ﻿  {﻿  ﻿  ﻿  
          double []dv = new double[3];
          dv[0] = Double.Parse(parts[1]);
          dv[1] = Double.Parse(parts[2]);
          dv[2] = Double.Parse(parts[3]);

    ﻿  ﻿  ﻿  return dv;
﻿  ﻿  }                     
﻿  ﻿  
﻿  ﻿  ﻿  ﻿  
﻿  ﻿  static int ParseFacePart(string part)
﻿  ﻿  {
          try
          {
        ﻿  ﻿  ﻿  string[] pieces = part.Split('/');
        ﻿  ﻿  ﻿  return int.Parse(pieces[0]); // piece 0 is the vertex index
          }
          catch (Exception ex) 
          {
              return -1;
          }
﻿  ﻿  }
#endregion OBJ FILE LOADER﻿
      #region DXFLoader
      public bool LoadDXF(string filename) 
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                m_fullname = filename;
                m_name = Path.GetFileName(filename);
                while (!sr.EndOfStream) 
                {
                    string line = sr.ReadLine();
                    line = line.Trim();
                    if (line.ToUpper() == "3DFACE") 
                    {
                        Polygon poly = new Polygon();//create a new polygon
                        m_lstpolys.Add(poly); // add it to the polygon list
                        Point3d []pnts;
                        LoadDXFPolyPoints(out pnts, sr);
                        poly.m_points = new Point3d[pnts.Length]; // create the storage
                        int idx = 0;
                        foreach(Point3d p in pnts)
                        {
                            poly.m_points[idx++] = AddUniqueVert(p);
                        }
                        poly.CalcNormal();
                        poly.CalcCenter();
                        FindMinMax();
                    }
                }
                sr.Close();
                if (NumPolys > 0)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
                
            }catch( Exception)
            {
                return false;            
            }
        }
      #endregion dxfloader
    }

}
