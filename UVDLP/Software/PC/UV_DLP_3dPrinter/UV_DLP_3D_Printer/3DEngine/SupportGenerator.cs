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
            GenerateSupportObjects();
        }
        /// <summary>
        /// This is the adaptive support generation, it should automatically 
        /// detect overhangs
        /// </summary>
        public void GenerateAdaptive() 
        {
            //iterate through all the layers starting from z=0            
            // check every polyline in the current layer to make sure it is encased or overlaps polylines in the previous layer
            // generate a list of unsupported polylines
            // 'check' to see if the polyline can be dropped straight down
            // this has to do slicing of the scene
            SliceBuildConfig config =  UVDLPApp.Instance().m_buildparms;
            int numslices = UVDLPApp.Instance().m_slicer.GetNumberOfSlices(config);
            float zlev = 0.0f;
            Slice curslice = null;
            Slice prevslice = null;
            for (int c = 0; c < numslices; c++) 
            {
                Slice sl = UVDLPApp.Instance().m_slicer.GetSliceImmediate(zlev);
                sl.Optimize();// find loops
                zlev += (float)config.ZThick;
                prevslice = curslice;
                curslice = sl;
                if (prevslice != null && curslice != null) 
                {
                    //see if regions in the curslice 
                    //iterate through all closed polylines in the current level
                    foreach (PolyLine3d pl in curslice.m_opsegs) 
                    {
                        if (!pl.cached)
                            pl.CalcBBox();
                        //iterate through all polylines in previous level
                        foreach(PolyLine3d pl1 in prevslice.m_opsegs)
                        {
                            if (!pl1.cached)
                                pl1.CalcBBox();
                            //check the bounding box of pl against pl1
                        }
                    }
                }

            }
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
                                s.Create((float)m_sc.fbrad, (float)m_sc.ftrad, (float)m_sc.hbrad, (float)m_sc.htrad, lz * .2f, lz * .6f, lz * .2f, 11);
                                s.Translate((float)x, (float)y, 0);
                                s.Name = "Support " + scnt;
                                s.SetColor(Color.Yellow);
                                scnt++;
                                lstsupports.Add(s);
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
