using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UV_DLP_3D_Printer._3DEngine;
using Engine3D;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer
{
    /*
     This class generates support structures for the scene.
     * I'm going to start off by doing the following:
     * walk from the min/max x/y in 1mm resolution in 3d
     * generate a ray from the z=0 to the zMax build size and test the scene for intersection,
     * at intersection points, we can generate cylinders
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
    public class SupportGenerator
    {
        /*
        public class Config 
        {
            int xres, yres;
           // double 
        }
         * */

        public static bool FindIntersection(Vector3d direction, Point3d origin, ref Point3d intersect)
        {
            UVDLPApp.Instance().CalcScene();
            //bool intersected = false;

          //  Point3d bpoint, tpoint;
          //  Point3d lowest = new Point3d(); // the lowest point of intersection on the z axis
            direction.Normalize();
            direction.Scale(100.0);
            Point3d endp = new Point3d();
            endp.Set(origin);
            endp.x += direction.x;
            endp.y += direction.y;
            endp.z += direction.z;
            /*
            intersect = new Point3d();
            intersect.x = 0.0d;
            intersect.y = 0.0d;
            intersect.z = 0.0d;
            */
            //intersect the scene with a ray

           // intersected = false;
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
        }

        /*
         To start, we're going to intersect the entire scene and generate support objects
         * we can change this to generate support for individual objects if needed.
         */
        public static void GenerateSupportObjects(SupportConfig sc) 
        {
           // ArrayList objects = new ArrayList();
            // iterate over the platform size by indicated mm step; // projected resolution in x,y
            // generate a 3d x/y point on z=0, 
            // generate another on the z=zmax
            // use this ray to intersect the scene
            // foreach intersection point, generate a support
            // we gott make sure supports don't collide
            // I also have to take into account the 
            // interface between the support and the model
            
            double HX =  UVDLPApp.Instance().m_printerinfo.m_PlatXSize / 2; // half X size
            double HY =  UVDLPApp.Instance().m_printerinfo.m_PlatYSize / 2; // half Y size
            double ZVal = UVDLPApp.Instance().m_printerinfo.m_PlatZSize;
            UVDLPApp.Instance().CalcScene();
            bool intersected = false;
            int scnt = 0; // support count
            // iterate from -HX to HX step xtep;
            for (double x = -HX; x < HX; x += sc.xspace)
            {
                for (double y = -HY; y < HY; y += sc.yspace)
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
                    foreach(Polygon p in UVDLPApp.Instance().Scene.m_lstpolys)
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
                    }
                    // for some reason, we're getting negatively generating cylinders
                    // that extend to the -Z world axis
                    // and we're also unnessary support generate on the y -axis that
                    // do not intersect objects vertically in the x/y plane

                    if ((lowest.z < ZVal) && intersected && (lowest.z >= 0)) 
                    {
                        // now, generate and add a cylinder here
                        Cylinder3d cyl = new Cylinder3d();
                        cyl.Create(sc.brad, sc.trad, lowest.z, 20, sc.vdivs);
                        cyl.Translate((float)x,(float)y,0);
                        cyl.Name = "Support " + scnt;
                        cyl.IsSupport = true;
                        scnt++;
                        UVDLPApp.Instance().Engine3D.AddObject(cyl);
                    }      
                }
            }
           // return objects;
        }
    }
}
