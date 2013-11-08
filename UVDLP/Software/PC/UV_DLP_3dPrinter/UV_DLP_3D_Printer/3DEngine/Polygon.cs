using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Engine3D;
using UV_DLP_3D_Printer;
using System.Collections;

using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using UV_DLP_3D_Printer._3DEngine;

namespace Engine3D
{
    public class Polygon //: IComparer
    {
        public Vector3d m_normal; // the plane normal
        public Plane plane; // the plane for intersection testing
        public Point3d m_center; // the calculated center of the polygon
        public double m_radius; // the radius of the poly for sphere intersection testing

       // public Point3d m_centercamera; // transformed into camera space
        public Color m_color;
        //public Color m_linecolor;
        public Point3d[] m_points; // points in poly, also contained in parent objects points list 
        public bool m_solid; // draw it solid
        //public bool m_wire;// draw wireframe
        public MinMax m_minmax; // cached for slicing
        public bool m_hidden; // for hiding polygons during the manual support genetation step
        //move vars cached for slicing
        //PolyLine3d lineseg1;
       // PolyLine3d lineseg2;
       // PolyLine3d lineseg3;
        public int tag; // special markers for this polygon
        public static int TAG_REGULAR        = 0;
        public static int TAG_MARKDOWN      = 1;
            


        public Polygon() 
        {
            m_normal = new Vector3d();
            m_radius = 0.0;
            m_color = Color.Gray;
            //m_linecolor = Color.Blue;
            m_solid = true;
            m_center = new Point3d();
            m_minmax = null;
            plane = new Plane();
            m_hidden = false;
            tag = TAG_REGULAR;
        }

        void CalculatePlaneEquation()
        {
                double           len;
                int             i;
                Vector3d          ref1, norm, v1, v2;
                Point3d          vert1, vert2;
                ref1 = new Vector3d();
                norm = new Vector3d();
                v1 = new Vector3d();
                v2 = new Vector3d();

                for(i=0; i < m_points.Length; i++) 
                {
				        vert1 = m_points[i];
				        vert2 = m_points[(i+1) % m_points.Length];

				        v1.x = vert1.x;
				        v1.y = vert1.y;
				        v1.z = vert1.z;

				        v2.x = vert2.x;
				        v2.y = vert2.y;
				        v2.z = vert2.z;

                        norm.x += (v1.y - v2.y)*(v1.z + v2.z);
                        norm.y += (v1.z - v2.z)*(v1.x + v2.x);
                        norm.z += (v1.x - v2.x)*(v1.y + v2.y);
                        ref1.x += v1.x;
                        ref1.y += v1.y;
                        ref1.z += v1.z;
                }

		        len = norm.Mag();
                plane.a = norm.x / len;
                plane.b = norm.y / len;
                plane.c = norm.z / len;
                len *= m_points.Length;
	            plane.d = -ref1.Dot(norm) / len;
        }

        public void CalcNormal() 
        {
            double Ax, Ay, Az;
            double Bx, By, Bz;
            Ax = m_points[1].x - m_points[0].x;
            Ay = m_points[1].y - m_points[0].y;
            Az = m_points[1].z - m_points[0].z;
            Bx = m_points[2].x - m_points[0].x;
            By = m_points[2].y - m_points[0].y;
            Bz = m_points[2].z - m_points[0].z;        
   
            double Nx = (Ay * Bz) - (Az * By);
            double Ny = (Az * Bx) - (Ax * Bz);
            double Nz = (Ax * By) - (Ay * Bx);
            m_normal.x = Nx;
            m_normal.y = Ny;
            m_normal.z = Nz;
            double length = Math.Sqrt((m_normal.x * m_normal.x) + (m_normal.y * m_normal.y) + (m_normal.z * m_normal.z));
            m_normal.x /= length;
            m_normal.y /= length;
            m_normal.z /= length;
            CalculatePlaneEquation();
        }
        public PolyLine3d IntersectZPlane(double zcur)
        {
            try
            {
                PolyLine3d segment = new PolyLine3d();
                //Intersect the polygon with the specified Z-Plane 
                // this will return 0,1,2 intersections.
                // using the returns, impose several rules
                    //use a polyline to do the intersections

                Point3d p1, p2, p3; // intersection points for the 3 3d line segments
                int count = 0;
                Point3d[] lst = new Point3d[3];
                PolyLine3d lineseg1 = null;
                PolyLine3d lineseg2 = null;
                PolyLine3d lineseg3 = null;

                lineseg1 = new PolyLine3d();
                lineseg1.AddPoint(m_points[0]); // 0-1
                lineseg1.AddPoint(m_points[1]);
                p1 = lineseg1.IntersectZ(zcur);
                if (p1 != null)
                {
                    count++;
                    segment.AddPoint(p1);
                }


                lineseg2 = new PolyLine3d();
                lineseg2.AddPoint(m_points[1]); // 1-2
                lineseg2.AddPoint(m_points[2]);

                p2 = lineseg2.IntersectZ(zcur);
                if (p2 != null)
                {
                    count++;
                    segment.AddPoint(p2);
                }

                if (count == 0)
                    return null;

                // there is no sense in doing the 3rd intersection if we don't have 
                // at least 1 point at this stage

                lineseg3 = new PolyLine3d();
                lineseg3.AddPoint(m_points[2]); // 2-0
                lineseg3.AddPoint(m_points[0]);
                p3 = lineseg3.IntersectZ(zcur);
                if (p3 != null)
                {
                    count++;
                    segment.AddPoint(p3);
                }
                if (count != 2) // might be 0,1 or 3
                    return null;

                segment.m_color = Color.Red;
                return segment;
            }
            catch (Exception) 
            {
                return null;
            }
        }

        public void CalcMinMax() 
        {
            m_minmax = new MinMax();
            m_minmax.m_min = m_points[0].z;
            m_minmax.m_max = m_points[0].z;

            foreach (Point3d pnt in m_points)
            {
                if (pnt.z > m_minmax.m_max)
                    m_minmax.m_max = pnt.z;

                if (pnt.z < m_minmax.m_min)
                    m_minmax.m_min = pnt.z;

            }
            //return mm;
        }
        public void CalcCenter() 
        {
            try
            {
                m_center.Set(0, 0, 0,0);

                foreach (Point3d pnt in m_points)
                {
                    m_center.x += pnt.x;
                    m_center.y += pnt.y;
                    m_center.z += pnt.z;
                }
                m_center.x /= m_points.Length; // number of points
                m_center.y /= m_points.Length; // number of points
                m_center.z /= m_points.Length; // number of points
            }catch(Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        /*
         The update function should be called after the containing object
         * moves, scales or rotates to update the polygon information
         */
        public void Update() 
        {
            CalcCenter();
            CalcMinMax();
            CalcRadius();
            CalcNormal();
        }
        public void CalcRadius()
        {
	        Vector3d newlen = new Vector3d();
            newlen.Set(0, 0, 0, 0);
            for (int c = 0; c < m_points.Length; c++)
	        {
                newlen.x = m_center.x - m_points[c].x;
                newlen.y = m_center.y - m_points[c].y;
                newlen.z = m_center.z - m_points[c].z;
                if(newlen.Mag() >= m_radius)
                {
                    m_radius = newlen.Mag();
                }
	        }
        }
        /*
        int IComparer.Compare(Object pFirstObject, Object pObjectToCompare)
        {
            Polygon p1 = (Polygon)pFirstObject;
            Polygon p2 = (Polygon)pObjectToCompare;
            if (p1.m_centercamera.z > p2.m_centercamera.z) return 1;
            if (p1.m_centercamera.z < p2.m_centercamera.z) return -1;
            return 0;
        }
        */
        public void RenderGL(bool wireframe,bool alpha, bool selected) 
        {
            // clip test before rendering 
            // use center point and radius to determine visibility (3d test)
            // 
            // test dot product of the transformed normal
            Color clr = m_color;
            if (m_hidden == true)
                return; // not displaying this poly...
            if (wireframe)
            {
                GL.Begin(BeginMode.LineLoop);//.LineStrip);
                GL.LineWidth(1);
            }else
            {
                GL.Begin(BeginMode.Triangles);
            }

            if (tag == TAG_MARKDOWN)
            {
                clr = Color.Red;
            }
            else
            {
                if (selected)
                {
                    clr = Color.Green;
                }
               // else 
               // {
               //     clr = Color.Gray;
               // }
            }

            if (alpha)
            {
                if (tag == TAG_MARKDOWN)
                {
                    GL.Color3(clr);
                }
                else
                {
                    GL.Color4((byte)clr.R, (byte)clr.G, (byte)clr.B, (byte)128);
                }
            }
            else
            {
                GL.Color3(clr);
            }
            
            GL.Normal3(m_normal.x, m_normal.y, m_normal.z);
            foreach (Point3d p in this.m_points)
            {               
                GL.Vertex3(p.x, p.y, p.z);
            }
            GL.End();            
        }

        public void Render(Camera cam, PaintEventArgs ev, int wid, int hei)
        {
            try
            {
                ArrayList m_campnts = new ArrayList();
                //transform this from world to camera coordinates
                //project
                // then draw
                foreach (Point3d pnt in m_points)
                {
                    Point3d p = cam.viewmat.Transform(pnt);
                    m_campnts.Add(p);
                }
                if (m_campnts.Count > 1)
                {
                    Point[] line = new Point[m_campnts.Count];
                    if (cam.m_protyp == eProjectType.eParallel)
                    {
                        int idx = 0;
                        Point first = new Point();
                        foreach (Point3d pnt in m_campnts)
                        {
                            line[idx].X = (int)((cam.m_scalex * pnt.x) + (wid / 2)); // need to add x and y offsets
                            line[idx].Y = (int)((cam.m_scaley * pnt.y) + (hei / 2)); // need to add x and y offsets
                            if (idx == 0)
                            {
                                first.X = line[idx].X;
                                first.Y = line[idx].Y;
                            }
                            idx++;
                        }
                        // line[idx].X  = first.X; // add the first on as the last as well to close it up
                        // line[idx].Y = first.Y;
                    }

                    Brush solidbrush = new SolidBrush(m_color);
                    if (m_solid == true)
                    {
                        ev.Graphics.FillPolygon(solidbrush, line);

                    }
                    /*
                    Pen linepen = new Pen(m_linecolor, 2);
                    if (m_wire == true)
                    {
                        ev.Graphics.DrawPolygon(linepen, line);
                        ev.Graphics.DrawLines(linepen, line);
                    }
                     */ 
                }
            }
            catch (Exception) { }
        }

    }
}
