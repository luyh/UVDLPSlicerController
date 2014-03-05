
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Engine3D;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;


namespace UV_DLP_3D_Printer
{
    public class Point2d : IComparable
    {
        public int x, y;
        public PolyLine3d m_parent;

        int IComparable.CompareTo(object obj)
        {
            Point2d p = (Point2d)obj;
            if (p.x > x) 
            {
                return -1;
            }
            else if (p.x < x)
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }

    }
    public class Line2d 
    {
        public Point2d p1, p2;
        public PolyLine3d m_parent;
        public Line2d() 
        {
            p1 = new Point2d();
            p2 = new Point2d();
        }
        public void SetParent(PolyLine3d parent) 
        {
            m_parent = parent;
            p1.m_parent = parent;
            p2.m_parent = parent;
        }
        public Point2d IntersectY(int ypos) 
        {
            Point2d pnt = new Point2d();
            double minx, maxx;
            double miny, maxy;
            double yp = ypos;
            minx = (double)Math.Min(p1.x, p2.x);
            maxx = (double)Math.Max(p1.x, p2.x);
            miny = (double)Math.Min(p1.y, p2.y);
            maxy = (double)Math.Max(p1.y, p2.y);
            double yrange = maxy - miny;// the range of the x coord
            double scale = (double)((yp - miny) / yrange);
            //pnt.x = (int)LERP(minx, maxx, scale);
            Point2d pmin, pmax;
            if (p1.y < p2.y) // find the point with the min y
            {
                pmin = p1;
                pmax = p2;
            }
            else
            {
                pmin = p2;
                pmax = p1;

            }
            //pnt.x = (int)LERP(p2.x, p1.x, scale); 
            pnt.x = (int)LERP(pmin.x, pmax.x, scale); 
            pnt.y = ypos;
            return pnt;
     
        }
        private static double LERP(double a, double b, double c) { return (double)(((b) - (a)) * (c) + (a)); }
    }
    public class MinMax_XY 
    {
        public int xmin, xmax, ymin, ymax; 
    }
    /*
     The idea in this class is to provide a single slice of a model
     * This is represented 
     */

    public class Slice 
    {
        public List<PolyLine3d> m_segments; // list of polyline segments
        public List<PolyLine3d> m_opsegs; // list of optimized polyline segments
        
        public Slice()
        {
            m_segments = new List<PolyLine3d>();
            m_opsegs = null;
        }
        public bool Load(StreamReader sr) 
        {
            try
            {
                int numplys = int.Parse(sr.ReadLine());
                for (int c = 0; c < numplys; c++) 
                {
                    PolyLine3d pl = new PolyLine3d();
                    pl.Load(sr);
                    m_segments.Add(pl);
                }
                return true;
            }
            catch (Exception ) 
            {
                return false;
            }

        }
        public bool Save(StreamWriter sw) 
        {
            try
            {
                //save number of points
                sw.WriteLine(m_segments.Count);
                foreach (PolyLine3d pl in m_segments) 
                {
                    pl.Save(sw);
                }
                return true;
            }
            catch (Exception ) 
            {
                return false;
            }
        }
        public void ColorLines() 
        {
            int idx = 0;
            foreach (PolyLine3d pl in m_opsegs) 
            {                
                /*
                switch (idx % 3) 
                {
                    case 0:
                        pl.m_color = Color.Red;
                        break;
                    case 1:
                        pl.m_color = Color.Yellow;
                        break;
                    case 2:
                        pl.m_color = Color.White;
                        break;

                } 
                 * */
                if (pl.tag == PolyLine3d.TAG_EXTERIOR)
                {
                    pl.m_color = Color.Red;
                }
                else 
                {
                    pl.m_color = Color.Yellow;
                }
                idx++;
            }
        }
        /// <summary>
        /// This function will iterate through the optimized loops
        /// and determine if they are interior or exterior and tag them appropriately
        /// </summary>
        public void DetermineInteriorExterior(SliceBuildConfig config) 
        {
            List<PolyLine3d> allsegments = new List<PolyLine3d>();
            foreach (PolyLine3d pln in m_opsegs)
            {
                pln.tag = PolyLine3d.TAG_INTERIOR; // mark it as interior
                List<PolyLine3d> segments = pln.Split(); // split them, retaining the parent
                allsegments.AddRange(segments);                
            }
            List<Line2d> lines2d = Get2dLines(config, allsegments);
            // find the x/y min/max
            MinMax_XY mm = Slice.CalcMinMax_XY(lines2d);
            // iterate from the ymin to the ymax
            for (int y = mm.ymin; y < mm.ymax; y++) // this needs to be in scaled value 
            {
                //      get a line of lines that intersect this 2d line
                List<Line2d> intersecting = Slice.GetIntersecting2dYLines(y, lines2d);
                //      get the list of point intersections
                List<Point2d> points = Slice.GetIntersectingPoints(y, intersecting);
                // sort the points in increasing x order                           
                points.Sort();
                if (points.Count % 2 == 0)  // is even
                {
                    for (int cnt = 0; cnt < points.Count; cnt += 2)  // increment by 2
                    {
                        // the first point is always an exterior - really? why?
                        Point2d p1 = (Point2d)points[cnt];
                        if (p1.m_parent != null)
                        {
                            p1.m_parent.tag = PolyLine3d.TAG_EXTERIOR; // mark as exterior
                        }
                        // the second point could be an exterior or interior
                        Point2d p2 = (Point2d)points[cnt + 1];
                    }
                }
                else  // flag error
                {
                    DebugLogger.Instance().LogRecord("Row y=" + y + " odd # of points = " + points.Count + " - Model may have holes");
                }
            }// for y = startminY to endY            
        }
        /// <summary>
        /// This function trys to join together the short line segments into 
        /// a set of longer 3d polyines
        /// The goal here is to determine the interior and exterior lines
        /// This is going to help us do several things:
        /// 1) import/export SVG/CLI files
        /// 2) determine overlapping boundaries for better self-intersecting models
        /// 3) determine overhangs - by detemining if polylines from other layers intersect vertically or are encapsulated.
        /// 
        /// The first pass of this algorithm may have to be N^2 search, I'll try
        /// to change it to log(N) or N as I go along
        /// </summary>
        /// 

        public void Optimize()
        {
            try
            {
                // copy all the polylines in segments into a list
                List<PolyLine3d> allseg = new List<PolyLine3d>();
                //create the final optimize segment list
                m_opsegs = new List<PolyLine3d>();

                // copy the list and clone the polyline segments 
                foreach (PolyLine3d pl in m_segments)
                {
                    allseg.Add(new PolyLine3d(pl));
                }
                // gotta keep track of lines to remove
                List<PolyLine3d> removelist = new List<PolyLine3d>();
                bool done = false;
                // matchcount is a counter that tracks how many endpoints we've matched this trip around
                int matchcount = 0;
                while (!done)
                {
                    // set the current line to be the first polyline segement
                    PolyLine3d curline = allseg[0];
                    //iterate through all the line segments in allsegs
                    for (int cnt = 0; cnt < allseg.Count; cnt++)
                    {
                        PolyLine3d pl = allseg[cnt];
                        if (cnt != 0) // the first polyline is the one we're always trying to match
                        {
                            // if the last point in the current polyline matches the first point
                            // in the line we're testing, add the second point of the line we're testing 
                            // to the end of the current line
                            if (curline.m_points[curline.m_points.Count - 1].Matches(pl.m_points[0])) // case 2
                            {
                                //if ((curline.m_derived.SharesEdge(pl.m_derived)))
                                {
                                    curline.m_points.AddRange(pl.m_points);
                                    removelist.Add(pl); // add the test line to the list of lines to remove, now that we've used it
                                    matchcount++;
                                }
                            }
                            else if (curline.m_points[curline.m_points.Count - 1].Matches(pl.m_points[pl.m_points.Count - 1])) // case 4 last point matches last
                            {
                                // && (curline.m_derived.SharesEdge(pl.m_derived))
                                pl.m_points.Reverse();
                                curline.m_points.AddRange(pl.m_points);
                                removelist.Add(pl);
                                matchcount++;
                            }
                            else if (curline.m_points[0].Matches(pl.m_points[pl.m_points.Count - 1])) //case 1
                            {
                                curline.m_points.Reverse();
                                pl.m_points.Reverse();
                                curline.m_points.AddRange(pl.m_points);
                                removelist.Add(pl);
                                matchcount++;
                            }
                            else if (curline.m_points[0].Matches(pl.m_points[0])) // case 3
                            {
                                curline.m_points.Reverse();
                                curline.m_points.AddRange(pl.m_points);
                                removelist.Add(pl);
                                matchcount++;
                            }
                        }
                    }
                    // now remove all the matched segments from all segment list
                    foreach (PolyLine3d seg in removelist)
                    {
                        allseg.Remove(seg);
                    }
                    removelist.Clear();

                    if (matchcount > 0)
                    {
                        matchcount = 0; // reset the match counter
                    }
                    else
                    {
                        // the current segment is not longer matching
                        // add it to the final list of optimized segments
                        m_opsegs.Add(curline);
                        //and remove it from the list of all segments
                        allseg.Remove(curline);
                        //check for end condition
                        if (allseg.Count == 0)
                            done = true;
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
            RemoveDoublePoints(); // make really clean
        }
        private void RemoveDoublePoints() 
        {
            try
            {
                List<Point3d> lstRpnts = new List<Point3d>(); // points to remove
                foreach (PolyLine3d pl in m_opsegs)
                {
                    for (int c = 0; c < pl.m_points.Count - 1; c++)
                    {
                        if (pl.m_points[c].Matches(pl.m_points[c + 1]))
                        {
                            lstRpnts.Add(pl.m_points[c + 1]);

                        }
                    }
                    foreach (Point3d pnt in lstRpnts)
                        pl.m_points.Remove(pnt);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        /*
         This function calculates the min and max x/y coordinates of this slice
         */
        public static MinMax_XY CalcMinMax_XY(List<Line2d> lines2d) 
        {
            Line2d l1 = (Line2d)lines2d[0];
            MinMax_XY mm = new MinMax_XY();
            //start the min / max off with some valid values
            mm.xmin = mm.xmax = l1.p1.x;
            mm.ymin = mm.ymax = l1.p1.y;

            foreach (Line2d ln in lines2d) 
            {
                if (ln.p1.x < mm.xmin) mm.xmin = ln.p1.x;
                if (ln.p2.x < mm.xmin) mm.xmin = ln.p2.x;
                if (ln.p1.x > mm.xmax) mm.xmax = ln.p1.x;
                if (ln.p2.x > mm.xmax) mm.xmax = ln.p2.x;

                if (ln.p1.y < mm.ymin) mm.ymin = ln.p1.y;
                if (ln.p2.y < mm.ymin) mm.ymin = ln.p2.y;
                if (ln.p1.y > mm.ymax) mm.ymax = ln.p1.y;
                if (ln.p2.y > mm.ymax) mm.ymax = ln.p2.y;            
            }
            return mm;
        }

        private void Render2dlines(Graphics g, List<Line2d> lines, SliceBuildConfig sp) 
        {
            try
            {
                Point pnt1 = new Point(); // create some points for drawing
                Point pnt2 = new Point();

                Pen pen = new Pen(UVDLPApp.Instance().m_appconfig.m_foregroundcolor, 1);

                int hxres = sp.xres / 2;
                int hyres = sp.yres / 2;

                foreach (Line2d ln in lines)
                {
                    Point2d p1 = (Point2d)ln.p1;
                    Point2d p2 = (Point2d)ln.p2;
                    pnt1.X = (int)(p1.x) + sp.XOffset + hxres;
                    pnt1.Y = (int)(p1.y) + sp.YOffset + hyres;
                    pnt2.X = (int)(p2.x) + sp.XOffset + hxres;
                    pnt2.Y = (int)(p2.y) + sp.YOffset + hyres;
                    //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(pen, pnt1, pnt2);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);

            }
        }
        //alright, it looks like I'm going to have to code up a 2d scanline fill algorithm
        // I suppose the first step is to convert all the 3d-ish polyline points in this slice into
        // 2d polylines, then use those to implement the fill
        /// <summary>
        /// This new slicing function renders into a pre-allocated bitmap
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="bmp"></param>
        public void RenderSlice(SliceBuildConfig sp, ref Bitmap bmp)
        {
            try
            {
                Graphics graph = Graphics.FromImage(bmp);
                Point pnt1 = new Point(); // create some points for drawing
                Point pnt2 = new Point();
                Pen pen = new Pen(UVDLPApp.Instance().m_appconfig.m_foregroundcolor, 1);
                //convert all to 2d lines
                int hxres = sp.xres / 2;
                int hyres = sp.yres / 2;

                List<Line2d> lines2d = Get2dLines(sp, m_segments);
                if (lines2d.Count == 0) 
                    return; 
                Render2dlines(graph, lines2d, sp);

                // find the x/y min/max
                MinMax_XY mm = CalcMinMax_XY(lines2d);
                // iterate from the ymin to the ymax
                for (int y = mm.ymin; y < mm.ymax; y++) // this needs to be in scaled value 
                {
                    //      get a line of lines that intersect this 2d line
                    List<Line2d> intersecting = GetIntersecting2dYLines(y, lines2d);
                    //      get the list of point intersections
                    List<Point2d> points = GetIntersectingPoints(y, intersecting);
                    // sort the points in increasing x order
                    //SortXIncreasing(points);
                    points.Sort();
                    //      draw the X-Spans (should be even number)    
                    //    For a given pair of intersectin points
                    //    (Xi, Y), (Xj, Y)
                    //  −> Fill ceiling(Xi) to floor(Xj)

                    if (points.Count % 2 == 0)  // is even
                    {
                        for (int cnt = 0; cnt < points.Count; cnt += 2)  // increment by 2
                        {
                            Point2d p1 = (Point2d)points[cnt];
                            Point2d p2 = (Point2d)points[cnt + 1];
                            pnt1.X = (int)(p1.x + sp.XOffset + hxres);
                            pnt1.Y = (int)(p1.y + sp.YOffset + hyres);
                            pnt2.X = (int)(p2.x + sp.XOffset + hxres);
                            pnt2.Y = (int)(p2.y + sp.YOffset + hyres);
                            //graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            graph.DrawLine(pen, pnt1.X, pnt1.Y, pnt2.X, pnt2.Y);
                        }
                    }
                    else  // flag error
                    {
                        DebugLogger.Instance().LogRecord("Row y=" + y + " odd # of points = " + points.Count + " - Model may have holes");
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void SortXIncreasing(ArrayList points) 
        {
            points.Sort();            
        }
        // this function will return a list of 2d point intersections on the specified y line
        public static List<Point2d> GetIntersectingPoints(int ypos, List<Line2d> lines) 
        {
            List<Point2d> points = new List<Point2d>();
            //if the ypos intersects with an endpoint, add it twice, because it must be used twice to make an even number
            foreach (Line2d ln in lines) 
            {
                int ymin = Math.Min(ln.p1.y, ln.p2.y);
                int ymax = Math.Max(ln.p1.y, ln.p2.y);

                if (ln.p1.y == ypos && ln.p2.y == ypos)  
                {
                    points.Add(ln.p1);
                    points.Add(ln.p2);
                }                    
                else if (ln.p1.y == ypos) // point 1 endpoint is on the line,
                {
                    //If the intersection is the ymin of the edge’s
                    //endpoint, count it. Otherwise, don’t
                    if (ln.p1.y == ymin) // if the 
                    {
                        points.Add(ln.p1);
                    }
                    
                }
                else if (ln.p2.y == ypos) // point 2 endpoint is on the line,
                {
                    //If the intersection is the ymin of the edge’s
                    //endpoint, count it. Otherwise, don’t

                    if (ln.p2.y == ymin)
                    {
                        points.Add(ln.p2);
                    }
                }                     
                else // intersect  
                { 
                 
                    Point2d isect = ln.IntersectY(ypos); // singled point of intersection
                    isect.m_parent = ln.m_parent;
                    points.Add(isect);
                }
            }
            return points;
        }
        
        /// <summary>
        /// this function converts all the 3d polyines to 2d lines so we can process everything 
        /// This is the equivanlant of a 3d->2d projection function
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        private List<Line2d> Get2dLines(SliceBuildConfig sp, List<PolyLine3d> segments) 
        {
            List<Line2d> lst = new List<Line2d>();
            // this can be changed at some point to assume that the 3d polyline has more than 2 points
            // I'll need to do this when I want to properly generate inside / outside countours
            foreach (PolyLine3d ply in segments)  
            {
                Line2d ln = new Line2d();
                ln.SetParent(ply.m_plyderived);
                //get the 3d points of the line
                Point3d p3d1 = (Point3d)ply.m_points[0];
                Point3d p3d2 = (Point3d)ply.m_points[1];
                //convert them to 2d (probably should add an offset to center them)
                ln.p1.x = (int)(p3d1.x * sp.dpmmX);// +hxres;
                ln.p1.y = (int)(p3d1.y * sp.dpmmY);// +hyres;
                ln.p2.x = (int)(p3d2.x * sp.dpmmX);// +hxres;
                ln.p2.y = (int)(p3d2.y * sp.dpmmY);// +hyres;
                lst.Add(ln);
            }
            return lst; // return the list
        }

        /*
         This function will return a list of lines that intersect with the specified Y scanline
         */
        public static List<Line2d> GetIntersecting2dYLines(int ypos, List<Line2d> all2dlines) 
        {
            List<Line2d> intersecting = new List<Line2d>();
            foreach (Line2d ln in all2dlines) 
            {
                if ((ln.p1.y >= ypos && ln.p2.y <= ypos) || 
                    (ln.p2.y >= ypos && ln.p1.y <= ypos) ||
                    (ln.p2.y == ypos && ln.p1.y == ypos)) 
                {
                    intersecting.Add(ln);
                }
            }
            return intersecting;
        }
    }
}
