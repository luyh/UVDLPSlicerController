using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine3D;
using System.Collections;
using System.Drawing;
using System.Threading;
using UV_DLP_3D_Printer.Slicing;
namespace UV_DLP_3D_Printer
{
    public class Slicer
    {
        public enum eSliceEvent 
        {
            eSliceStarted,
            eLayerSliced,
            eSliceCompleted,
            eSliceCancelled
        }
        public delegate void SliceEvent(eSliceEvent ev, int layer, int totallayers);

        private SliceFile m_sf; // the current file being sliced
        public SliceEvent Slice_Event;
        private Thread m_slicethread;
        private Object3d m_obj = null;
        private bool m_cancel = false;
        private bool isslicing = false;

        public Slicer() 
        {
        
        }
        public bool IsSlicing { get { return isslicing; } }
        public void CancelSlicing() 
        {
            m_cancel = true;
            isslicing = false;
        }
        public void RaiseSliceEvent(eSliceEvent ev, int curlayer, int totallayers)
        {
            if (Slice_Event != null) 
            {
                Slice_Event(ev, curlayer, totallayers);
            }
        }
        public int GetNumberOfSlices(SliceBuildConfig sp, Object3d obj) 
        {
            try
            {
                obj.FindMinMax();
                int numslices = (int)((obj.m_max.z - obj.m_min.z) / sp.ZThick);
                return numslices;
            }
            catch (Exception) 
            {
                m_cancel = true;
                return 0;
            }
        }

        // this function takes the object, the slicing parameters,
        // and the output directory. it generates the object slices
        // and saves them in the directory
        public SliceFile Slice(SliceBuildConfig sp, Object3d obj) 
        {
                m_obj = obj;
                m_cancel = false;
                // create new slice file
                m_sf = new SliceFile(sp);
                m_slicethread = new Thread(new ThreadStart(slicefunc));
                m_slicethread.Start();
                isslicing = true;
                return m_sf;
        }

        private void slicefunc() 
        {
            try
            {

                //determine the number of slices
                m_obj.FindMinMax();
                // I think I should calculate the number of slices from the world 0 position, not just the bottom of the object
                int numslices = (int)((m_obj.m_max.z - m_obj.m_min.z) / m_sf.m_config.ZThick);
                // I should start slicing at Wz 0, not Oz 0
                double curz = (double)m_obj.m_min.z;
                RaiseSliceEvent(eSliceEvent.eSliceStarted, 0, numslices);
                DebugLogger.Instance().LogRecord("Slicing started");
                int c = 0;
                m_obj.CalcMinMaxes();
                m_obj.ClearCached();
                for (c = 0; c < numslices; c++)
                {
                    // check for cancelation
                    if (m_cancel) 
                    {
                        isslicing = false;
                        m_cancel = false;
                        RaiseSliceEvent(eSliceEvent.eSliceCancelled, c, numslices);
                        return;
                    }
                    //get a list of polygons at this slice z height that potentially intersect
                    ArrayList lstply = GetZPolys(m_obj, curz);
                    //iterate through all the polygons and generate x/y line segments at this 3d z level
                    ArrayList lstintersections = GetZIntersections(lstply, curz);
                    // move the slice for the next layer
                    curz += m_sf.m_config.ZThick;
                    //create a new slice
                    Slice sl = new Slice();
                   // Set the list of intersections 
                    sl.m_segments = lstintersections;
                    // add the slice to slicefile
                    m_sf.m_slices.Add(sl);
                    //raise an event to say we've finished a slice
                    RaiseSliceEvent(eSliceEvent.eLayerSliced, c, numslices);
                }
                RaiseSliceEvent(eSliceEvent.eSliceCompleted, c, numslices);
                DebugLogger.Instance().LogRecord("Slicing Completed");
                isslicing = false;

            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                //RaiseSliceEvent(eSliceEvent.eSliceCancelled,0,0);
                m_cancel = true;
            }        
        }

        /*
         This function takes in a list of polygons along with a z height.
         * What is returns is an ArrayList of 3d line segments. These line segments correspond
         * to the intersection of a plane through the polygons. Each polygon may return 0 or 1 line intersections 
         * on the 2d XY plane
         */
        public ArrayList GetZIntersections(ArrayList polys,double zcur) 
        {
            try
            {
                ArrayList lstlines = new ArrayList();
                foreach (Polygon poly in polys) 
                {
                    PolyLine3d s3d = poly.IntersectZPlane(zcur);
                    if (s3d != null) 
                    {
                        lstlines.Add(s3d);
                    }
                }
                return lstlines;
            }
            catch (Exception) 
            {
                return null;
            }
        }

        /*
         Return a list of polygons that intersect at this zlevel
         */
        public ArrayList GetZPolys(Object3d obj, double zlev) 
        {
            ArrayList lst = new ArrayList();
            foreach(Polygon p in obj.m_lstpolys)
            {
                //check and see if current z level is between any of the polygons z coords
                //MinMax mm = p.CalcMinMax();
                if (p.m_minmax.InRange(zlev)) 
                {
                    lst.Add(p);
                }
            }
            return lst;
        }
    }
}
