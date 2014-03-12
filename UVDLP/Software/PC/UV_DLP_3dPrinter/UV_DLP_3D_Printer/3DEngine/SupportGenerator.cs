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
using System.IO;
using UV_DLP_3D_Printer.Slicing;
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
            RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eStarted, "Support Generation Started", null);
            switch (m_sc.eSupType) 
            {
                case SupportConfig.eAUTOSUPPORTTYPE.eBON:
                    GenerateSupportObjects();
                    break;
                case SupportConfig.eAUTOSUPPORTTYPE.eADAPTIVE:
                    GenerateAdaptive();
                    break;
            }
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "Support generation ended");
        }
        /// <summary>
        /// This is a helper function that converts 3d polylines to 2d
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

        private class UnsupportedRegions 
        {
            public UnsupportedRegions(PolyLine3d p) { ply = p; }
            public Point3d Center() 
            {
                Point3d center = new Point3d();
                //center.Set(ply.m_points[0]);
                foreach(Point3d p in ply.m_points)
                {
                    center.x += p.x;
                    center.y += p.y;
                    center.z += p.z;
                }
                center.x /= (float)(ply.m_points.Count);
                center.y /= (float)(ply.m_points.Count);
                center.z /= (float)(ply.m_points.Count);
                return center;
            }
            public PolyLine3d ply;
        };
        /// <summary>
        /// This is the adaptive support generation, it should automatically 
        /// detect overhangs,
        /// The way that it does this is by generating a closed polyline loop for each layer
        /// and checking the 2d projection of the current layer with the previous layer
        /// </summary>
        public void GenerateAdaptive() 
        {
            //iterate through all the layers starting from z=0            
            // check every polyline in the current layer to make sure it is encased or overlaps polylines in the previous layer
            // generate a list of unsupported polylines
            // 'check' to see if the polyline can be dropped straight down
            // this has to do slicing of the scene
            try
            {
                
                SliceBuildConfig config = UVDLPApp.Instance().m_buildparms;                
                config.UpdateFrom(UVDLPApp.Instance().m_printerinfo); // make sure we've got the correct display size and PixPerMM values   
                 
                if (UVDLPApp.Instance().m_slicer.SliceFile == null) 
                {
                    SliceFile sf = new SliceFile(config);
                    sf.m_mode = SliceFile.SFMode.eImmediate;
                    UVDLPApp.Instance().m_slicer.SliceFile = sf; // wasn't set
                }
                
                List<UnsupportedRegions> lstunsup = new List<UnsupportedRegions>();
                List<Object3d> lstsupports = new List<Object3d>(); // final list of supports

                int numslices = UVDLPApp.Instance().m_slicer.GetNumberOfSlices(config);
                float zlev = 0.0f;
                Slice curslice = null;
                Slice prevslice = null;
                int hxres = config.xres / 2;
                int hyres = config.yres / 2;
                for (int c = 0; c < numslices; c++)
                {
                    //bool layerneedssupport = false;
                    if (m_cancel)
                    {
                        RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eCancel, "Support Generation Cancelled", null);
                        return;
                    }
                    RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eProgress, "" + c + "/" + numslices, null);

                    Slice sl = UVDLPApp.Instance().m_slicer.GetSliceImmediate(zlev);
                    zlev += (float)config.ZThick;

                    if (sl == null) 
                        continue;
                    if (sl.m_segments == null) 
                        continue;
                    if (sl.m_segments.Count == 0)
                        continue;
                    sl.Optimize();// find loops
                    //sl.DetermineInteriorExterior(config); // mark the interior/exterior loops
                    prevslice = curslice;
                    curslice = sl;
                    Bitmap bm = new Bitmap(config.xres, config.yres);
                    using (Graphics gfx = Graphics.FromImage(bm))
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        gfx.FillRectangle(brush, 0, 0, bm.Width, bm.Height);
                    }

                    if (prevslice != null && curslice != null)
                    {
                        //render current slice
                        curslice.RenderSlice(config, ref bm);
                        //now render the previous slice overtop the current slice in another color
                        Color savecol = UVDLPApp.Instance().m_appconfig.m_foregroundcolor;
                        UVDLPApp.Instance().m_appconfig.m_foregroundcolor = Color.HotPink;
                        //render previous slice over top
                        prevslice.RenderSlice(config, ref bm);
                        UVDLPApp.Instance().m_appconfig.m_foregroundcolor = savecol; // restore the color
                        // create a lock bitmap for faster pixel access
                        LockBitmap lbm = new LockBitmap(bm);
                        lbm.LockBits();
                        // now, iterate through all optimized polylines in current slice
                        // this approach isn't going to work, we need to iterate through all polyline
                        //segments in a slice at once, each individual segment needs to know 1 thing
                        // 1) the optimized segment it came from

                        //iterate through all optimized polygon segments

                        Dictionary<PolyLine3d, bool> supportmap = new Dictionary<PolyLine3d, bool>();
                        foreach (PolyLine3d pln in curslice.m_opsegs)
                        {
                            bool plysupported = false;
                            List<PolyLine3d> allsegments = new List<PolyLine3d>();
                            List<PolyLine3d> segments = pln.Split(); // split them, retaining the parent
                            allsegments.AddRange(segments);
                            //add all optimized polyline segments into the supported map
                            supportmap.Add(pln, true);
                            //split this optimized polyline back into 2-point segments for easier use

                            List<Line2d> lines2d = Get2dLines(config, allsegments);
                            if (lines2d.Count == 0) continue;

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
                                        Point2d p1 = (Point2d)points[cnt];
                                        Point2d p2 = (Point2d)points[cnt + 1];
                                        Point pnt1 = new Point(); // create some points for drawing
                                        Point pnt2 = new Point();
                                        pnt1.X = (int)(p1.x + config.XOffset + hxres);
                                        pnt1.Y = (int)(p1.y + config.YOffset + hyres);
                                        pnt2.X = (int)(p2.x + config.XOffset + hxres);
                                        pnt2.Y = (int)(p2.y + config.YOffset + hyres);
                                        //iterate from pnt1.X to pnt2.x and check colors
                                        for (int xc = pnt1.X; xc < pnt2.X; xc++)
                                        {
                                            if (xc >= lbm.Width || xc <=0 ) continue;
                                            if (pnt1.Y >= lbm.Height || pnt1.Y <= 0) continue;
                                            try
                                            {
                                                Color checkcol = lbm.GetPixel(xc, pnt1.Y);
                                                // need to check the locked BM here for the right color
                                                // if the pixel color is the hot pink, then this region has some support
                                                // we're going to need to beef this up and probably divide this all into regions on a grid
                                                if (checkcol.R == Color.HotPink.R && checkcol.G == Color.HotPink.G && checkcol.B == Color.HotPink.B)
                                                {
                                                    plysupported = true;
                                                }
                                            }
                                            catch (Exception ex) 
                                            {
                                                DebugLogger.Instance().LogError(ex);
                                            }
                                        }
                                    }
                                }
                                else  // flag error
                                {
                                    DebugLogger.Instance().LogRecord("Row y=" + y + " odd # of points = " + points.Count + " - Model may have holes");
                                }
                            }// for y = startminY to endY
                            if (plysupported == false)
                            {

                               // layerneedssupport = true;
                                supportmap[pln] = false;
                                lstunsup.Add(new UnsupportedRegions(pln));
                            }
                        } // for each optimized polyline
                        lbm.UnlockBits(); // unlock the bitmap
                    } // prev and current slice are not null
                    //if (layerneedssupport)
                    //    SaveBM(bm, c); // uncomment this to see the layers that need support
                } // iterating through all slices
                // iterate through all unsupported regions
                // calculate the center
                // add a support from that region going down to the ground (or closest intersected)
                int scnt = 0;
                foreach (UnsupportedRegions region in lstunsup)
                {
                    Support s = new Support();
                    Point3d center = region.Center();
                    float lz = center.z;
                    //region.ply.m_derived.
                    s.Create(null,(float)m_sc.fbrad, (float)m_sc.ftrad, (float)m_sc.hbrad, (float)m_sc.htrad, lz * .2f, lz * .6f, lz * .2f, 11);
                    s.Translate((float)center.x, (float)center.y, 0);
                    s.Name = "Support " + scnt;
                    s.SetColor(Color.Yellow);
                    scnt++;
                    lstsupports.Add(s);
                    RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eSupportGenerated, s.Name, s);

                }
                RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eCompleted, "Support Generation Completed", lstsupports);
                m_generating = false;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
        private void SaveBM(Bitmap bmp, int layer) 
        {
            String fn = UVDLPApp.Instance().SelectedObject.m_fullname;
            string tmp = Path.GetDirectoryName(fn);
            tmp += UVDLPApp.m_pathsep;
            tmp += Path.GetFileNameWithoutExtension(fn);
            tmp += "_" + layer + ".png";
            bmp.Save(tmp);
        }
        public List<Object3d> GenerateSupportObjects()
        {

            // iterate over the platform size by indicated mm step; // projected resolution in x,y
            // generate a 3d x/y point on z=0, 
            // generate another on the z=zmax
            // use this ray to intersect the scene
            // foreach intersection point, generate a support
            // we gott make sure supports don't collide
            // I also have to take into account the 
            // interface between the support and the model
            List<Object3d> lstsupports = new List<Object3d>();

            float ZVal = (float)UVDLPApp.Instance().m_printerinfo.m_PlatZSize;
            m_model.Update();
            float MinX = m_model.m_min.x;
            float MaxX = m_model.m_max.x;
            float MinY = m_model.m_min.y;
            float MaxY = m_model.m_max.y;

           // bool intersected = false;
            int scnt = 0; // support count
            // iterate from -HX to HX step xtep;
            double dts = (MaxX - MinX) / m_sc.xspace;
            int its = (int)dts;
            int curstep = 0;

            for (float x = (float)(MinX + (m_sc.xspace / 2.0f)); x < MaxX; x += (float)m_sc.xspace)
            {
                // say we're doing stuff
                RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eProgress, "" + curstep + "/" + its, null);
                curstep++;
                for (float y = (float)(MinY + (m_sc.yspace / 2)); y < MaxY; y += (float)m_sc.yspace)
                {
                    Point3d origin;                   
                    origin = new Point3d(); // bottom point
                    origin.Set(x, y, 0.0f);
                    //intersected = false; // reset the intersected flag to be false

                    Vector3d up = new Vector3d(); // the up vector
                    up.x = 0.0f;
                    up.y = 0.0f;
                    up.z = 1.0f;

                    List<ISectData> lstISects = RTUtils.IntersectObjects(up, origin, UVDLPApp.Instance().Engine3D.m_objects, false);
                    //check for cancelling
                    if (m_cancel)
                    {
                        RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eCancel, "Support Generation Cancelled", null);
                        return lstsupports;
                    }


                    foreach (ISectData htd in lstISects)
                    {
                        if (htd.obj.tag != Object3d.OBJ_SUPPORT)  // if this is not another support or the ground
                        {
                            if (htd.obj.tag != Object3d.OBJ_GROUND) // if it's not the ground
                            {
                                if (m_sc.m_onlydownward && htd.poly.tag != Polygon.TAG_MARKDOWN)
                                    break; // not a downward facing and we're only doing downward
                                // this should be the closest intersected
                                Support s = new Support();
                                float lz = (float)htd.intersect.z;
                                s.Create(htd.obj,(float)m_sc.fbrad, (float)m_sc.ftrad, (float)m_sc.hbrad, (float)m_sc.htrad, lz * .2f, lz * .6f, lz * .2f, 11);
                                s.Translate((float)x, (float)y, 0);
                                s.Name = "Support " + scnt;
                                s.SetColor(Color.Yellow);
                                scnt++;
                                lstsupports.Add(s);
                                htd.obj.AddSupport(s);
                                RaiseSupportEvent(UV_DLP_3D_Printer.SupportEvent.eSupportGenerated, s.Name, s);
                                break; // only need to make one support
                            }
                        }
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
