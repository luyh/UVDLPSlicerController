using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UV_DLP_3D_Printer._3DEngine;
using Engine3D;
using UV_DLP_3D_Printer.Configs;
using System.Drawing;
using System.Threading;
namespace UV_DLP_3D_Printer
{
    /*
     This class generates support structures for the scene.
     * I'm going to start off by doing the following:
     * walk from the min/max x/y in 1mm resolution in 3d
     * generate a ray from the z=0 to the zMax build size and test the scene for intersection,
     * at intersection points, we can generate cylinders
     * 
     * 
     * On thing that I need to fix/add with the support generator is the ability to generate supports for
     * overhangs, one method that I could potentially use to detect overhangs or islands is to examine the generated 
     * 2d slices.
     * I can iterate through the vertical z slices, and identify regions where new material appears. from comparing previous frames,
     * I can determine the slope, and where new supports may be needed.
     * I think I can do this in 2d, I can then generated supports either in 2d or 3d
     * // the model can be treated as volumetric data
     * foreach slice z
     *      foreach pixel y
     *          foreach pixel x
     *              if(pixel color is black)
     *              {
     *                  
     *              }
     * 
     * This first implementation is a simple x/y scan,
     * further implementations can use more than a cylinder object, or 
     * modify the class to generate new sements on demand
     * We could use the concept of a slice to represent a plane of points
     * this plane of points can then be extruded along a path,
     * able to add or remove new segments.
     * We can use this for many porposes
     * for now, it has to be fairly convex, or generating a center point for
     * surface triangulation may not always work.
     * we can use circle/shape funtions to generate segments/slices
     */
    public enum SupportEvent 
    {
        eStarted, // the support generatation just started
        eCompleted, // the support generation completed
        eCancel, // the suport generator is in a cancelled state
        eProgress, // we've move 1 across the x plane 
        eSupportGenerated, // used to add a model
    }
    public delegate void SupportGeneratorEvent(SupportEvent evnt, string message, Object obj);

    public class SupportGenerator
    {
        private SupportConfig m_sc;
        private Object3d m_model;
        private bool m_cancel;
        private bool m_generating; // true while this is running
        public SupportGeneratorEvent SupportEvent;
       // public ArrayList m_lstSupports = null; // the list of generated supports returned after support generation is complete

        public void RaiseSupportEvent(SupportEvent evnt, string message, Object obj) 
        {
            if (SupportEvent != null) 
            {
                SupportEvent(evnt, message, obj);
            }
        }

        public bool Generating 
        {
            get { return m_generating; }
        }

        /// <summary>
        /// This will return an intersection, not necessarily the closest one.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="origin"></param>
        /// <param name="intersect"></param>
        /// <returns></returns>
        public static bool FindIntersection(Vector3d direction, Point3d origin, ref Point3d intersect)
        {
            if (UVDLPApp.Instance().Scene == null) return false;
            if (UVDLPApp.Instance().Scene.m_lstpolys == null) return false;

            direction.Normalize();
            direction.Scale(10000.0);
            Point3d endp = new Point3d();
            endp.Set(origin);
            endp.x += direction.x;
            endp.y += direction.y;
            endp.z += direction.z;
            foreach (Polygon p in UVDLPApp.Instance().Scene.m_lstpolys)
            {
                intersect = new Point3d();
                // try a less- costly sphere intersect here   
                if (RTUtils.IntersectSphere(origin, endp, ref intersect, p.m_center, p.m_radius))
                {
                    // if it intersects,
                    if (RTUtils.IntersectPoly(p, origin, endp, ref intersect))
                    {
                        return true;
                        /*
                        // and it's the lowest one
                        if (intersect.z <= lowest.z)
                        {
                            //save this point
                            intersected = true;
                            lowest.Set(intersect);
                        }
                         * */
                    }
                }
            }


            return false;
        }
        public SupportGenerator() 
        {
            m_cancel = false;
        }
        /// <summary>
        /// Start the support generation
        /// </summary>
        public void Start(SupportConfig sc, Object3d model)
        {
            Thread m_thread = new Thread(new ThreadStart(StartGenerating));
            m_sc = sc;
            m_model = model;
            m_cancel = false;
            m_generating = true;
            m_thread.Start();
        }
        /// <summary>
        /// Cancel the support generation
        /// </summary>
        public void Cancel() 
        {
            m_cancel = true;
            m_generating = false;
        }
        private void StartGenerating() 
        {
           // m_lstSupports = new ArrayList();
            RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eStarted, "Support Generation Started", null);
            GenerateSupportObjects();
        }
        /*
         To start, we're going to intersect the entire scene and generate support objects
         * we can change this to generate support for individual objects if needed.
         */
        public ArrayList GenerateSupportObjects() 
        {
           
            // iterate over the platform size by indicated mm step; // projected resolution in x,y
            // generate a 3d x/y point on z=0, 
            // generate another on the z=zmax
            // use this ray to intersect the scene
            // foreach intersection point, generate a support
            // we gott make sure supports don't collide
            // I also have to take into account the 
            // interface between the support and the model
            ArrayList lstsupports = new ArrayList();

           // double HX =  UVDLPApp.Instance().m_printerinfo.m_PlatXSize / 2; // half X size
          //  double HY =  UVDLPApp.Instance().m_printerinfo.m_PlatYSize / 2; // half Y size
            double ZVal = UVDLPApp.Instance().m_printerinfo.m_PlatZSize;

            
            //UVDLPApp.Instance().CalcScene();
            m_model.Update();
            double MinX = m_model.m_min.x;
            double MaxX = m_model.m_max.x;
            double MinY = m_model.m_min.y;
            double MaxY = m_model.m_max.y;

            bool intersected = false;
            int scnt = 0; // support count
            // iterate from -HX to HX step xtep;
            double dts = (MaxX - MinX) / m_sc.xspace;
            int its = (int)dts;
            int curstep = 0;

            for (double x = (MinX + (m_sc.xspace/2)); x < MaxX; x += m_sc.xspace)
            {
                
                RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eProgress, "" + curstep + "/" + its, null);
                curstep++;
                for (double y = (MinY + (m_sc.yspace / 2)); y < MaxY; y += m_sc.yspace)
                {
                    Point3d bpoint,tpoint;
                    Point3d lowest = new Point3d(); // the lowest point of intersection on the z axis

                    bpoint = new Point3d(); // bottom point
                    tpoint = new Point3d(); // top point
                    bpoint.Set(x, y, 0.0 , 1);
                    tpoint.Set(x, y, ZVal, 1); // set to the max height
                    //intersect the scene with a ray

                    lowest.Set(0, 0, ZVal, 0);
                    intersected = false; // reset the intersected flag to be false
                    foreach (Polygon p in m_model.m_lstpolys)
                    {
                        Point3d intersect = new Point3d();
                        // try a less- costly sphere intersect here   
                        if (RTUtils.IntersectSphere(bpoint, tpoint, ref intersect, p.m_center, p.m_radius)) 
                        {
                            // if it intersects,
                            if(RTUtils.IntersectPoly(p,bpoint,tpoint,ref intersect))
                            {
                                // and it's the lowest one
                                if(intersect.z <= lowest.z)
                                {
                                    //save this point
                                    intersected = true;
                                    lowest.Set(intersect);
                                }
                            }
                        }
                        if (m_cancel) 
                        {
                            RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eCancel, "Support Generation Cancelled", null);
                            return lstsupports;
                        }
                    }
                    // for some reason, we're getting negatively generating cylinders
                    // that extend to the -Z world axis
                    // and we're also unnessary support generate on the y -axis that
                    // do not intersect objects vertically in the x/y plane

                    if ((lowest.z < ZVal) && intersected && (lowest.z >= 0)) 
                    {
                        // now, generate and add a cylinder here

                        Support s = new Support();
                        float lz = (float)lowest.z;
                        s.Create((float)m_sc.fbrad, (float)m_sc.ftrad, (float)m_sc.hbrad, (float)m_sc.htrad, lz * .2f, lz * .6f, lz * .2f, 11);
                        s.Translate((float)x,(float)y,0);
                        s.Name = "Support " + scnt;
                        s.SetColor(Color.Yellow);
                        scnt++;                       
                        lstsupports.Add(s);
                        RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eSupportGenerated, s.Name, s);
                    }      
                }
            }
           // return objects;
            RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eCompleted, "Support Generation Completed", lstsupports);
            m_generating = false;
            return lstsupports;
        }
    }
}
