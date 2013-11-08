using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Engine3D;

namespace UV_DLP_3D_Printer.Slicing.Modules
{
    /*
     Inputs: An object or object file
     Outputs: a svg file and line of polyline counters for each z slice
     This class cuts / carves the model into the svg slices
     */

    public class Carve : SliceModule
    {
        private static Parm[] parms =  
        {
            new Parm("ZThick",0.025,"This is the thickness of the slice in mm")
        };

        public Carve() 
        {
            CreateDefault();
            m_name = "Carve";
            m_description ="This Module will Slice an Object into a series of Slices along the Z Axis.";
        }
        public override void CreateDefault() 
        {
            m_parms.AddParms(parms);
        }
        public override bool Execute() 
        {
            //determine the number of slices
            m_data.m_obj.FindMinMax();
            int numslices = (int)((m_data.m_obj.m_max.z - m_data.m_obj.m_min.z) / m_parms.GetDouble("ZThick"));

            double curz = (double)m_data.m_obj.m_min.z;
            //RaiseSliceEvent(eSliceEvent.eSliceStarted, 0, numslices);
            DebugLogger.Instance().LogRecord("Slicing started");
            int c = 0;
            m_data.m_obj.CalcMinMaxes();
            for (c = 0; c < numslices; c++)
            {
                if (m_cancel)
                {
                    //isslicing = false;
                    m_cancel = false;
                    //RaiseSliceEvent(eSliceEvent.eSliceCancelled, c, numslices);
                    return false;
                }
                //get a list of polygons at this slice z height that potentially intersect
                ArrayList lstply = GetZPolys(m_data.m_obj, curz);
                //iterate through all the polygons and generate x/y line segments at this 3d z level
                ArrayList lstintersections = GetZIntersections(lstply, curz);
                // move the slice for the next layer
                curz += m_parms.GetDouble("ZThick");
                //create a new slice
                Slice sl = new Slice();
                // Set the list of intersections 
                sl.m_segments = lstintersections;
                // add the slice to slicefile
               // m_data.m_slices.m_slices.Add(sl);
                //raise an event to say we've finished a slice
               // RaiseSliceEvent(eSliceEvent.eLayerSliced, c, numslices);
            }
           // RaiseSliceEvent(eSliceEvent.eSliceCompleted, c, numslices);
            DebugLogger.Instance().LogRecord("Slicing Completed");
            //isslicing = false;
            return true;
        }
        /*
         This function takes in a list of polygons along with a z height.
         * What is returns is an ArrayList of 3d line segments. These line segments correspond
         * to the intersection of a plane through the polygons. Each polygon may return 0 or 1 line intersections 
         * on the 2d XY plane
         */
        public ArrayList GetZIntersections(ArrayList polys, double zcur)
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
            foreach (Polygon p in obj.m_lstpolys)
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
