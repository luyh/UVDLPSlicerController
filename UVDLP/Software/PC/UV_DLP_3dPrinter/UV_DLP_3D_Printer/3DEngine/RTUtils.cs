using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine3D;
using System.Collections;

namespace UV_DLP_3D_Printer._3DEngine
{
    /*
     Ray tracing utilites for the 3d engine
     */
    public class RTUtils
    {
        // 
        public class TestPoint { public double X, Y;};
        static TestPoint[] TstPnt = new TestPoint[4]; //for the crossing test
        static int numTstPnt = 0;//for the crossing test        
        static Object3d m_gp = null; // artificial ground plane


        public static double sign(TestPoint p1, TestPoint p2, TestPoint p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        public static bool PointInTriangle(TestPoint pt, TestPoint v1, TestPoint v2, TestPoint v3)
        {
            bool b1, b2, b3;

            b1 = sign(pt, v1, v2) < 0.0f;
            b2 = sign(pt, v2, v3) < 0.0f;
            b3 = sign(pt, v3, v1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }

        public static int CrossingsTest(double PntX, double PntY) 
        {
            TestPoint pt = new TestPoint();
            pt.X = PntX;
            pt.Y = PntY;
            if (PointInTriangle(pt, TstPnt[0], TstPnt[1], TstPnt[2])) 
            {
                return 1;
            }
            return 0;
        }
        /*
        public static int CrossingsTest(double PntX, double PntY)
        {
            if (TstPnt[0] == null)  // create if not created already
            {
                TstPnt[0] = new TestPoint();
                TstPnt[1] = new TestPoint();
                TstPnt[2] = new TestPoint();
                TstPnt[3] = new TestPoint();
            }
            int j, yflag0, yflag1, inside_flag = 0, xflag0;
            double ty, tx;// *vtx0, *vtx1 ;
            int line_flag;
            short index = 0;
            tx = PntX;//point[X] ;
            ty = PntY;//point[Y] ;
            TestPoint vtx0, vtx1;
            vtx0 = TstPnt[numTstPnt - 1];
            yflag0 = (vtx0.Y >= ty) ? 1 : 0;
            vtx1 = TstPnt[0];
            inside_flag = 0;
            line_flag = 0;
            for (j = numTstPnt + 1; --j > 0; )
            {
                yflag1 = (vtx1.Y >= ty) ? 1 : 0;
                if (yflag0 != yflag1)
                {
                    xflag0 = (vtx0.X >= tx) ? 1 : 0;
                    if (xflag0 == ((vtx1.X >= tx) ? 1 : 0))
                    {
                        if (xflag0 != 0)
                        {
                            if (inside_flag == 1)
                            {
                                inside_flag = 0;
                            }
                            else
                            {
                                inside_flag = 1;
                            }
                            //inside_flag = !inside_flag;
                        }
                    }
                    else
                    {
                        if ((vtx1.X - (vtx1.Y - ty) *
                         (vtx0.X - vtx1.X) / (vtx0.Y - vtx1.Y)) >= tx)
                        {
                            //inside_flag = !inside_flag ;
                            if (inside_flag == 1)
                            {
                                inside_flag = 0;
                            }
                            else
                            {
                                inside_flag = 1;
                            }
                        }
                    }
                    if (line_flag != 0)
                        goto Exit;
                    line_flag = 1;
                }

                // move to next pair of vertices, retaining info as possible 
                yflag0 = yflag1;
                vtx0 = vtx1;
                vtx1 = TstPnt[++index];
            }
        Exit: ;
            return (inside_flag);
        }
        */
        public static bool IntersectPoly(Polygon poly, Point3d start, Point3d end,ref  Point3d intersection)
        {
            //intersect a Polygon with a ray in world space
            // first test to see if we're hitting the right side
            /*
            Vector3d tst = new Vector3d();
            tst.Set(end.x - start.x, end.y - start.x, end.z - start.z, 0);
            tst.Normalize();
            if (poly.m_normal.Dot(tst) > 1)
                return false;
            */

            bool retval = false;
            double deltaX, deltaY, deltaZ, t, T, S;
            double A, B, C, D;//the Polygon plane
            double denom;

            if (TstPnt[0] == null)  // create if not created already
            {
                TstPnt[0] = new TestPoint();
                TstPnt[1] = new TestPoint();
                TstPnt[2] = new TestPoint();
                TstPnt[3] = new TestPoint();
            }

            A = poly.plane.a;
            B = poly.plane.b;
            C = poly.plane.c;
            D = poly.plane.d;
            deltaX = end.x - start.x;
            deltaY = end.y - start.y;
            deltaZ = end.z - start.z;

            denom = (A * deltaX + B * deltaY + C * deltaZ);

            double epsilon = 0.00001;
            //if (denom == 0.0)//ray is parallel, no intersection
            if (denom >= -epsilon && denom <= epsilon)//ray is parallel, no intersection
            //if (denom >= epsilon)//ray is parallel or less, no intersection
            {
                retval = false;
                return retval;
            }

            T = (-1) / denom;
            S = (A * start.x + B * start.y + C * start.z);
            t = (S + D) * T;
            //at this point we have a possible intersection
            //project to a major world axis and test for containment in the poly
            intersection.x = (float)(start.x + (t * deltaX));
            intersection.y = (float)(start.y + (t * deltaY));
            intersection.z = (float)(start.z + (t * deltaZ));

            numTstPnt = poly.m_points.Length;
            // test the X/Y plane
            for (long counter = 0; counter < poly.m_points.Length; counter++)
            {
                TstPnt[counter].X = poly.m_points[counter].x;
                TstPnt[counter].Y = poly.m_points[counter].y;
            }
            if (CrossingsTest(intersection.x, intersection.y) == 1) 
            { 
                retval = true; 
                return retval; 
            }
            // Test the X/Z plane
            for (long counter = 0; counter < poly.m_points.Length; counter++)
            {
                TstPnt[counter].X = poly.m_points[counter].x;
                TstPnt[counter].Y = poly.m_points[counter].z;
            }
            if (CrossingsTest(intersection.x, intersection.y) == 1) 
            { 
                retval = true; 
            }
            return retval;
        }
        /*
        public static bool IntersectPoly(Polygon poly, Point3d start, Point3d end,ref  Point3d intersection)
        {
            return polyisect.findIntersection(poly, start, end, ref intersection);
        }
        */
        public static bool IntersectSphere(Point3d start,Point3d end,ref Point3d intersect, Point3d center,double radius)
        {
	        bool retval = false;
	        double EO;//EO is distance from start of ray to center of sphere
	        double d,disc,v;//v is length of direction ray
	        Vector3d V,temp;//V is unit vector of the ray
	        temp =new Vector3d();
            V = new Vector3d();

	        temp.Set(center.x - start.x,center.y - start.y,	center.z - start.z,0);

	        EO = temp.Mag(); // unnormalized length
	        V.Set(end.x - start.x,end.y - start.y,end.z - start.z,0);
	        v = V.Mag();// magnitude of direction vector
	        V.Normalize();// normalize the direction vector
	        disc = (radius*radius) - ((EO*EO) - (v*v));
	        if(disc < 0.0f)
            {
                retval = false;// no intersection
	        }
            else
            { // compute the intersection point
		        retval = true;
		        d = Math.Sqrt(disc);
		        intersect.x = start.x + ((v-d)*V.x);
		        intersect.y = start.y + ((v-d)*V.y);
		        intersect.z = start.z + ((v-d)*V.z);
	        }
	        return retval;
        }

        private static void CreateGroundPlane()
        {
            m_gp = new Object3d();
            m_gp.Name = "GroundPlane";
            Point3d p0=new Point3d(-500,-500,0,0);
            Point3d p1=new Point3d(500,-500,0,0);
            Point3d p2=new Point3d(500,500,0,0);
            Point3d p3=new Point3d(-500,500,0,0);
            m_gp.m_lstpoints.Add(p0);
            m_gp.m_lstpoints.Add(p1);
            m_gp.m_lstpoints.Add(p2);
            m_gp.m_lstpoints.Add(p3);

            Polygon ply0 = new Polygon();
            ply0.m_points = new Point3d[3];
            ply0.m_points[0] = p0;
            ply0.m_points[1] = p1;
            ply0.m_points[2] = p2;

            Polygon ply1 = new Polygon();
            ply1.m_points = new Point3d[3];
            ply1.m_points[0] = p0;
            ply1.m_points[1] = p2;
            ply1.m_points[2] = p3;
            m_gp.m_lstpolys.Add(ply0);
            m_gp.m_lstpolys.Add(ply1);
            m_gp.tag = Object3d.OBJ_GROUND; // groundplane tag
            m_gp.Update();
           // p1.m

        }

        private static ISectData ISectGroundPlane(Vector3d direction, Point3d origin)
        {
            ISectData isect = null;
            direction.Normalize();
            direction.Scale(10000.0);
            Point3d endp = new Point3d();
            Point3d intersect = new Point3d();

            endp.Set(origin);
            endp.x += direction.x;
            endp.y += direction.y;
            endp.z += direction.z;
            // intersect with the imaginary groundplane object;
            if (m_gp == null) 
            {
                CreateGroundPlane();
            }
            if (IntersectSphere(origin, endp, ref intersect, m_gp.m_center, m_gp.m_radius))
            {
                foreach (Polygon p in m_gp.m_lstpolys)
                {
                    intersect = new Point3d();
                    // try a less- costly sphere intersect here   
                    if (IntersectSphere(origin, endp, ref intersect, p.m_center, p.m_radius))
                    {
                        // if it intersects,
                        if (RTUtils.IntersectPoly(p, origin, endp, ref intersect))
                        {
                           isect = new ISectData(m_gp, p, intersect, origin, direction);
                        }
                    }
                }
            }
            return isect;
        }

        /// <summary>
        /// This function takes a list of objects and a ray and starting point.
        /// It will return an ArrayList of ISectData,
        /// if no intersections occur, the list will be empty,
        /// the suports variable indicates whether to intersect supports
        /// Each Object should be updated before being added to the list here.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="origin"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        /// 
        static object lck = new object();
        public static List<ISectData> IntersectObjects(Vector3d direction, Point3d origin, ArrayList objects, bool supports) 
        {
            List<ISectData> m_isectlst = new List<ISectData>();
            try
            {
                direction.Normalize();
                direction.Scale(10000.0);
                Point3d endp = new Point3d();
                Point3d intersect = new Point3d();

                endp.Set(origin);
                endp.x += direction.x;
                endp.y += direction.y;
                endp.z += direction.z;
                lock (lck)
                {
                    foreach (Object3d obj in objects)
                    {
                        if (obj.tag == Object3d.OBJ_SUPPORT && !supports)
                            continue;
                        // try a less- costly sphere intersect here   
                        if (IntersectSphere(origin, endp, ref intersect, obj.m_center, obj.m_radius))
                        {
                            foreach (Polygon p in obj.m_lstpolys)
                            {
                                intersect = new Point3d();
                                // try a less- costly sphere intersect here   
                                if (IntersectSphere(origin, endp, ref intersect, p.m_center, p.m_radius))
                                {
                                    // if it intersects,
                                    if (RTUtils.IntersectPoly(p, origin, endp, ref intersect))
                                    {
                                        m_isectlst.Add(new ISectData(obj, p, intersect, origin, direction));
                                    }
                                }
                            }
                        }
                    }
                }
                ISectData gp = ISectGroundPlane(direction, origin);
                if (gp != null)
                {
                    m_isectlst.Add(gp);
                }
                m_isectlst.Sort();
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
            return m_isectlst;
        }
    }
}
