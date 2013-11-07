using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Engine3D;
using UV_DLP_3D_Printer;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace Engine3D
{
    public delegate void ModelAdded(Object3d model);
    public delegate void ModelRemoved(Object3d model);

    public class Engine3d
    {
        public Camera m_camera;
        ArrayList m_lines;
        public ArrayList m_objects;
        public event ModelAdded ModelAddedEvent;
        public event ModelRemoved ModelRemovedEvent;

        public Engine3d() 
        {
            m_camera = new Camera();
            m_lines = new ArrayList();
            m_objects = new ArrayList();
            AddGrid();
        }
        public void UpdateLists() 
        {
            foreach (Object3d obj in m_objects) 
            {
                obj.InvalidateList();
            }
        }
        public void CameraRotate(double x,double y, double z)
        {
            m_camera.viewmat.Rotate(x, y, z);
        }
        public void CameraMove(Point3d pnt)
        {
            m_camera.viewmat.Translate(pnt.x, pnt.y, pnt.z);
        }
        public void CameraMove(double x,double y, double z)
        {
            m_camera.viewmat.Translate(x,y,z);
        }
        public void CameraReset() 
        {
            m_camera.Reset();
        }

        public void AddGridLine(int x1, int y1, int x2, int y2, Color col)
        {
            AddLine(new PolyLine3d(new Point3d(x1, y1, 0, 0), new Point3d(x2, y2, 0, 0), col));
        }

        public void AddGrid() 
        {
            for (int x = -50; x < 51; x += 10)
            {
                AddGridLine(x, -50, x, 50, Color.Blue);
            }
            for (int y = -50; y < 51; y += 10)
            {
                AddGridLine(-50, y, 50, y, Color.Blue);
            }
            AddLine(new PolyLine3d(new Point3d(0, 0, -10, 0), new Point3d(0, 0, 10, 0), Color.Blue));

            // add XY arrows
            AddGridLine(50, 0, 58, 0, Color.Blue);
            AddGridLine(58, 0, 55, 3, Color.Blue);
            AddGridLine(58, 0, 55, -3, Color.Blue);
            AddGridLine(0, 50, 0, 58, Color.Blue);
            AddGridLine(0, 58, 3, 55, Color.Blue);
            AddGridLine(0, 58, -3, 55, Color.Blue);
            AddGridLine(60, 2, 66, -2, Color.Red);
            AddGridLine(60, -2, 66, 2, Color.Red);
            AddGridLine(0, 60, 0, 63, Color.Red);
            AddGridLine(0, 63, 2, 66, Color.Red);
            AddGridLine(0, 63, -2, 66, Color.Red);
        }
        //This function draws a cube the size of the build platform
        // The X/Y is centered along the 0,0 center point. Z extends from 0 to Z

        public void AddPlatCube() 
        {
            double platX, platY, platZ;
            double X, Y, Z;
            Color cubecol = Color.Gray;
            platX = UVDLPApp.Instance().m_printerinfo.m_PlatXSize;
            platY = UVDLPApp.Instance().m_printerinfo.m_PlatYSize;
            platZ = UVDLPApp.Instance().m_printerinfo.m_PlatZSize;
            X = platX / 2;
            Y = platY / 2;
            Z = platZ / 2;

            // bottom
            AddLine(new PolyLine3d(new Point3d(-X, Y, 0, 0), new Point3d(X, Y, 0, 0), cubecol));
            AddLine(new PolyLine3d(new Point3d(-X, -Y, 0, 0), new Point3d(X, -Y, 0, 0), cubecol));

            AddLine(new PolyLine3d(new Point3d(-X, -Y, 0, 0), new Point3d(-X, Y, 0, 0), cubecol));
            AddLine(new PolyLine3d(new Point3d( X, -Y, 0, 0), new Point3d( X, Y, 0, 0), cubecol));

            // Top
            AddLine(new PolyLine3d(new Point3d(-X, Y, Z, 0), new Point3d(X, Y, Z, 0), cubecol));
            AddLine(new PolyLine3d(new Point3d(-X, -Y, Z, 0), new Point3d(X, -Y, Z, 0), cubecol));

            AddLine(new PolyLine3d(new Point3d(-X, -Y, Z, 0), new Point3d(-X, Y, Z, 0), cubecol));
            AddLine(new PolyLine3d(new Point3d(X, -Y, Z, 0), new Point3d(X, Y, Z, 0), cubecol));

            // side edges
            AddLine(new PolyLine3d(new Point3d(X, Y, 0, 0), new Point3d(X, Y, Z, 0), cubecol));
            AddLine(new PolyLine3d(new Point3d(X, -Y, 0, 0), new Point3d(X, -Y, Z, 0), cubecol));

            AddLine(new PolyLine3d(new Point3d(-X, Y, 0, 0), new Point3d(-X, Y, Z, 0), cubecol));
            AddLine(new PolyLine3d(new Point3d(-X, -Y, 0, 0), new Point3d(-X, -Y, Z, 0), cubecol));


        
        }
        public void RemoveAllObjects() 
        {
            m_objects = new ArrayList();

        }
        public void AddObject(Object3d obj) 
        {
            m_objects.Add(obj); 
            if (ModelAddedEvent != null)
            {
                ModelAddedEvent(obj);
            }            
        }
        public void RemoveObject(Object3d obj) 
        {
            m_objects.Remove(obj);
            if (ModelRemovedEvent != null)
            {
                ModelRemovedEvent(obj);
            }                 
        }
        public void AddLine(PolyLine3d ply) { m_lines.Add(ply); }
        public void RemoveAllLines() 
        {
            m_lines = new ArrayList();
        }

        public void RenderGL(bool alpha) 
        {

            try
            {
                foreach (Object3d obj in m_objects)
                {
                    GL.Enable(EnableCap.Lighting);
                    GL.Enable(EnableCap.Light0);
                    GL.Disable(EnableCap.LineSmooth);
                    if (UVDLPApp.Instance().SelectedObject == obj)                    {
                        obj.RenderGL(alpha,true);
                    }
                    else 
                    {
                        obj.RenderGL(alpha, false);
                    }
                }
                foreach (PolyLine3d ply in m_lines)
                {
                    GL.Disable(EnableCap.Lighting);
                    GL.Disable(EnableCap.Light0);
                    GL.Enable(EnableCap.LineSmooth);
                    ply.RenderGL();
                }
            }
            catch (Exception) { }
        }
        public void Render(PaintEventArgs e, int wid, int hei) 
        {

            foreach (Object3d obj in m_objects) 
            {
                obj.Render(m_camera, e, wid, hei);
            }
            foreach (PolyLine3d ply in m_lines)
            {
                ply.Render(m_camera, e, wid, hei);
            }
        }
        /*
         This function takes the specified vector and intersects all objects
         * in the scene, it will return the polygon? or point that intersects first
         * We can expand this to return list of all intersections, for the initial
         * purposes of support generation, this is used to go from z=0 to z=platmaxz
         */
        public void RayCast(Point3d pstart, Point3d pend) 
        {
        
        }
    }
}
