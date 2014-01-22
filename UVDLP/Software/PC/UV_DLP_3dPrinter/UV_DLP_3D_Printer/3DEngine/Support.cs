using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using System.Drawing;
namespace Engine3D
{
    /// <summary>
    /// a support derives from the cylinder class
    /// </summary>
    /// 
    /*  
     // typical support resting on floor
      __
     /__\
     |  |
     |  |
     |__|
    /____\
    
     //typical support acting as a suport between object parts
      __
     /__\   - D3  - The 'Head'
     |  |
     |  |   - D2  - The 'Body'
     |__|
     \__/   - D1  - The 'Foot'
     
     * We'll generate this object from the bottom up
     * it has 4 segments , the top and the bottom face each have an extra point in the center for easier triangulation 
     * the bottom face has numdivpnts +1 
     * the next seg up has numdivpnts
     * the next seg up has numdivpnts
     * the top seg up has numdivpnts + 1
     * 
     * we want to support scaling of this object initially by keeping the distance D1 and D3 the same while scaling D2
     * 
     * We should be able to change the top and bottom radius of any of the head, body,or foot, 
     * as well as the height of any of these segments
     * 
     * In latyer revisions of this, we would want to:
     * translate (x,y) the body, but keep the top and bottom stationary
     * translate the bottom of the foot, and the top of the head
     * match the surface normal of the top of the head, bottom of the foot to meet with the surface we're attaching too
     */
    public class Support : Cylinder3d
    {
        // here, we keep indexes into the point array, so we can scale/move them easier

        private int s1i; // the starting index of the bottom of the foot 
        private int s2i; // the starting index of the top of the foot/ bottom of the body
        private int s3i; // top of the body, bottom of the head
        private int s4i; // top of the head
        private int cdivs;
        public Support() 
        {
            tag = Object3d.OBJ_SUPPORT; // tag for support

        }
        /// <summary>
        /// This function creates a new support structure
        /// you can specify the:
        /// Foot Bottom Radius  - fbrad
        /// Foot Top Radius     - ftrad
        /// Head Bottom Radius  - hbrad
        /// Head Top Radius     - htrad
        /// 
        /// as well as the segment lengths from bottom to top D1,D2,D3
        /// you can also specify the number of divisions in the circle - divs
        /// </summary>
        /// <param name="fbrad"></param>
        /// <param name="ftrad"></param>
        /// <param name="hbrad"></param>
        /// <param name="htrad"></param>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <param name="d3"></param>
        public void Create(float fbrad,float ftrad, float hbrad,float htrad, float d1,float d2,float d3, int divs)
        {
            try
            {
                
                cdivs = divs;
                float zlev = 0.0f; // start at the bottom of the cylinder
                s1i = 0; // set 0 to be the starting index for the bottom of the foot
                GenerateCirclePoints(fbrad, divs, zlev, true); // foot bottom
                zlev += d1;
                //now the top of the foot
                s2i = m_lstpoints.Count;
                GenerateCirclePoints(ftrad, divs, zlev, false); // foot top
                zlev += d2;
                //now the bottom of the head
                s3i = m_lstpoints.Count;
                GenerateCirclePoints(hbrad, divs, zlev, false); // bottom of head
                zlev += d3;
                //now the top of the head
                s4i = m_lstpoints.Count;
                GenerateCirclePoints(htrad, divs, zlev, true); // top of head

                MakeTopBottomFace(s1i, divs, false);// bottom
                MakeTopBottomFace(s4i, divs, true);// top

                makeWalls(s1i, s2i, divs);
                makeWalls(s2i, s3i - divs - 1, divs);
                makeWalls(s3i, s4i - (2*divs) - 1, divs);
                Update();
                SetColor(Color.Yellow);
                ScaleToHeight(d1 + d2 + d3);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);

            }
        }
 
        private void makeWalls(int li, int ui, int numdivs)
        {
            for (int cnt = 0; cnt < numdivs; cnt++)
            {
                int topidx = ui;// +1;// numdivs + 1; // index to the first point in the top circle
                Polygon plyl = new Polygon();
                m_lstpolys.Add(plyl);
                plyl.m_points = new Point3d[3]; // create some point storage
                plyl.m_points[0] = (Point3d)m_lstpoints[cnt + li];
                plyl.m_points[1] = (Point3d)m_lstpoints[((cnt + 1) % numdivs) + li];
                plyl.m_points[2] = (Point3d)m_lstpoints[cnt + topidx + li];
                
                Polygon plyr = new Polygon();
                m_lstpolys.Add(plyr);
                plyr.m_points = new Point3d[3]; // create some point storage
                plyr.m_points[0] = (Point3d)m_lstpoints[(cnt + 1) % numdivs + li];
                plyr.m_points[1] = (Point3d)m_lstpoints[((cnt + 1) % numdivs) + topidx + li]; // 
                plyr.m_points[2] = (Point3d)m_lstpoints[cnt + topidx + li]; // the point directly above it
                 
            }
        }
        // given the top or bottom starting index, make the surface face
        private void MakeTopBottomFace(int idx, int numdivs, bool top) 
        {
            try
            {
                int centeridx = idx + numdivs;
                for (int cnt = 0; cnt < numdivs; cnt++)
                {
                    Polygon plt = new Polygon();
                    m_lstpolys.Add(plt);
                    plt.m_points = new Point3d[3]; // create some point storage
                    plt.m_points[0] = (Point3d)m_lstpoints[centeridx]; // the first point is always the center pointt
                    if (top)
                    {
                        plt.m_points[2] = (Point3d)m_lstpoints[(cnt + 1) % numdivs + idx];
                        plt.m_points[1] = (Point3d)m_lstpoints[idx + cnt];
                    }
                    else
                    {
                        plt.m_points[1] = (Point3d)m_lstpoints[(cnt + 1) % numdivs + idx];
                        plt.m_points[2] = (Point3d)m_lstpoints[idx + cnt];
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        public void ScaleToHeight(double height) 
        {
            if (height == 0.0d) height = 1.0;
            if (height <= 0.0d) height = 1.0;

            FindMinMax();
            double h = m_max.z - m_min.z; // current height
            //assuming the h= 1.5, and I want it to be height = 4
            double sval = h/height;
            sval = 1/sval;
            Scale(1.0f, 1.0f, (float)sval); // scale to the height   
            if (height > 3.0d)
            {
                float bpos = m_lstpoints[0].z;
                for (int c = s2i; c < s3i; c++ )
                {
                    m_lstpoints[c].z = (float)(bpos + 1.0f);
                }

                for (int c = s3i; c < s4i; c++)
                {
                    m_lstpoints[c].z = (float)(height + bpos - 2.0f);
                }

                // the distance from the top of the foot to the bottom should be 1
                // the tip should be 2 mm (or more)
            }
                
        }
        public override void RenderGL(bool showalpha, bool selected, bool renderSelection)
         {
             GL.Begin(BeginMode.Lines);//.LineStrip);
             GL.Color4(Color4.Red);
             for (int c = 0; c < cdivs; c++) 
             {
                 Point3d p = (Point3d)m_lstpoints[s1i  + c];
                 GL.Vertex3(p.x, p.y, p.z);
             }
             GL.End();

             GL.Begin(BeginMode.Lines);//.LineStrip);
             GL.Color4(Color4.Red);
             for (int c = 0; c < cdivs; c++)
             {
                 Point3d p = (Point3d)m_lstpoints[s2i + c];
                 GL.Vertex3(p.x, p.y, p.z);
             }
             GL.End();

             GL.Begin(BeginMode.Lines);//.LineStrip);
             GL.Color4(Color4.Red);
             for (int c = 0; c < cdivs; c++)
             {
                 Point3d p = (Point3d)m_lstpoints[s3i + c];
                 GL.Vertex3(p.x, p.y, p.z);
             }
             GL.End();

             GL.Begin(BeginMode.Lines);//.LineStrip);
             GL.Color4(Color4.Red);
             for (int c = 0; c < cdivs; c++)
             {
                 Point3d p = (Point3d)m_lstpoints[s4i  + c];
                 GL.Vertex3(p.x, p.y, p.z);
             }
             GL.End();
             base.RenderGL(showalpha, selected, renderSelection);
         }
         
        /*
        protected override void GenerateCirclePoints(double radius, int numdivscirc, double zlev, bool addcenter)
        {
            double step = (double)(Math.PI * 2) / numdivscirc;
            double t = 0.0;
            if (addcenter) // make center the 
            {
                // add another point right in the center for the triangulating the face
                Point3d centerpnt = new Point3d(); // bottom points
                centerpnt.x = 0;
                centerpnt.y = 0;
                centerpnt.z = zlev;

                m_lstpoints.Add(centerpnt);
            }
            for (int cnt = 0; cnt < numdivscirc; cnt++)
            {
                Point3d pnt = new Point3d(); // bottom points
                pnt.x = radius * Math.Cos(t);
                pnt.y = radius * Math.Sin(t);
                pnt.z = zlev;
                m_lstpoints.Add(pnt);
                t += step;
            }
            
        }
         * */
    }
}
