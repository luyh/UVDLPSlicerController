using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine3D;
using System.Collections;
using System.Drawing;
using System.Threading;
using UV_DLP_3D_Printer.Slicing;
//using UV_DLP_3D_Printer.Utility;
using Ionic.Zip;
using System.Drawing.Imaging;
using System.IO;

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
        public delegate void SliceEvent(eSliceEvent ev, int layer, int totallayers,SliceFile sf);

        private SliceFile m_sf; // the current file being sliced
        public SliceEvent Slice_Event;
        private Thread m_slicethread;
        private bool m_cancel = false;
        private bool isslicing = false;
        private ZipFile m_zip; // for storing image slices

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
                Slice_Event(ev, curlayer, totallayers, m_sf);
            }
        }
        /// <summary>
        /// This will get the number of slices in the scene from the specified slice config
        /// This uses the Scene object from the app, we slice with individual objects though
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public int GetNumberOfSlices(SliceBuildConfig sp)
        {
            try
            {
                UVDLPApp.Instance().CalcScene();
                int numslices = (int)((UVDLPApp.Instance().Scene.m_max.z - UVDLPApp.Instance().Scene.m_min.z) / sp.ZThick);
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
        public SliceFile Slice(SliceBuildConfig sp)//, Object3d obj) 
        {
                //m_obj = obj;
                m_cancel = false;
                // create new slice file
                m_sf = new SliceFile(sp);
                m_slicethread = new Thread(new ThreadStart(slicefunc));
                m_slicethread.Start();
                isslicing = true;
                return m_sf;
        }

        private static Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {
            try
            {
                Bitmap b = new Bitmap(size.Width, size.Height);
                using (Graphics g = Graphics.FromImage((Image)b))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
                }
                return b;
            }
            catch { return null; }
        }

    

        private void slicefunc() 
        {
            try
            {
                //first take care of scaling up the output bitmap paramters size, so we can re-sample later

                int ox, oy;
                double sdpmmx; // save the original dots per mm
                double sdpmmy; 
                double scaler = 1.5; // specify the scale factor
                if (m_sf.m_config.antialiasing == true)
                {
                    scaler = m_sf.m_config.aaval;
                }
                else
                {
                    scaler = 1.0; // no scaling
                }
                sdpmmx = m_sf.m_config.dpmmX; // save the original dots per mm
                sdpmmy = m_sf.m_config.dpmmY;

                m_sf.m_config.dpmmX *= scaler;//  scale them up.
                m_sf.m_config.dpmmY *= scaler;
                //Re-sample to a higher resolution so we can smooth later
                ox = m_sf.m_config.xres; // save the original resolution
                oy = m_sf.m_config.yres;
                double xs, ys;
                xs = ((double)m_sf.m_config.xres) * scaler;  // scale them up
                ys = ((double)m_sf.m_config.yres) * scaler;
                m_sf.m_config.xres = (int)xs;
                m_sf.m_config.yres = (int)ys;


                //determine the number of slices
                UVDLPApp.Instance().Scene.FindMinMax();
                // I think I should calculate the number of slices from the world 0 position, not just the bottom of the object
                //int numslices = (int)((UVDLPApp.Instance().Scene.m_max.z - UVDLPApp.Instance().Scene.m_min.z) / m_sf.m_config.ZThick);
                
                int numslices = (int)((UVDLPApp.Instance().Scene.m_max.z - UVDLPApp.Instance().Scene.m_min.z) / m_sf.m_config.ZThick);
                // I should start slicing at Wz 0, not Oz 0
                double curz = (double)UVDLPApp.Instance().Scene.m_min.z; // start at the bottom of all objects in the scene
                
                /*
                int numslices = (int)((UVDLPApp.Instance().Scene.m_max.z) / m_sf.m_config.ZThick);
                // I should start slicing at Wz 0, not Oz 0
                double curz = 0; // start at Wz0
                */
                // an alternative here is to slice the scene from wZ 0, therefore, all object geometry beneath the ground plane won't be slice;
                //double curz = (double)0.0;// start at the ground   
            
                
                int c = 0;
                string scenename = "";
                // a little housework here...
                foreach (Object3d obj in UVDLPApp.Instance().Engine3D.m_objects) 
                {
                    obj.CalcMinMaxes();
                    obj.ClearCached();
                    if (c == 0) 
                    {
                        //get the first objects' name
                        scenename = obj.m_fullname;
                        m_sf.modelname = obj.m_fullname;
                    }
                    c++;
                }
                m_sf.NumSlices = numslices;
                SliceStarted(scenename, numslices);
                DebugLogger.Instance().LogRecord("Slicing started");

                for (c = 0; c < numslices; c++)
                {
                    Bitmap bmp = new Bitmap(m_sf.m_config.xres,m_sf.m_config.yres); // create a new bitmap on a per-slice basis
                    //clear the image for rendering
                    Graphics graph = Graphics.FromImage(bmp);
                    graph.Clear(UVDLPApp.Instance().m_appconfig.m_backgroundcolor);

                    //convert all to 2d lines
                    Bitmap savebm = null;
                    // check for cancelation
                    if (m_cancel) 
                    {
                        isslicing = false;
                        m_cancel = false;
                        //restore the original sizes 
                        m_sf.m_config.dpmmX = sdpmmx;
                        m_sf.m_config.dpmmY = sdpmmy;
                        m_sf.m_config.xres = ox;
                        m_sf.m_config.yres = oy;
                        RaiseSliceEvent(eSliceEvent.eSliceCancelled, c, numslices);
                        return;
                    }
                    
                    foreach (Object3d obj in UVDLPApp.Instance().Engine3D.m_objects)
                    {
                        savebm = bmp; // need to set this here in case it's not rendered
                        if (curz >=obj.m_min.z &&  curz <= obj.m_max.z) // only slice from the bottom to the top of the objects
                        {
                            //obj.ClearCached();
                            ArrayList lstply = GetZPolys(obj, curz);//get a list of polygons at this slice z height that potentially intersect
                            ArrayList lstintersections = GetZIntersections(lstply, curz);//iterate through all the polygons and generate x/y line segments at this 3d z level
                          
                            Slice sl = new Slice();//create a new slice
                            sl.m_segments = lstintersections;// Set the list of intersections 
                           // m_sf.m_slices.Add(sl);// add the slice to slicefile        
                            // now render the slice into the scaled, pre-allocated bitmap
                            sl.RenderSlice(m_sf.m_config, ref bmp);
                            //now re-sample it if needed and save it
                            savebm = bmp;
/*
                            if (m_sf.m_config.antialiasing == true) // we're using anti-aliasing here, so resize the image
                            {
                                savebm = ResizeImage(bmp, new Size(ox, oy));
                            }           

 */
                        }
                    }

                    if (m_sf.m_config.antialiasing == true) // we're using anti-aliasing here, so resize the image
                    {
                        savebm = ResizeImage(bmp, new Size(ox, oy));
                    }           

                    curz += m_sf.m_config.ZThick;// move the slice for the next layer
                    //raise an event to say we've finished a slice
                    if (savebm == null) 
                    {
                        string s = "shouldn't be here";
                    }
                    LayerSliced(scenename, c,numslices,savebm);
                }
                SliceCompleted(scenename, c, numslices);
                
                DebugLogger.Instance().LogRecord("Slicing Completed");
                isslicing = false;

            }
            catch (Exception ex)
            {
                string s = ex.StackTrace;
                DebugLogger.Instance().LogRecord(ex.Message);
                //RaiseSliceEvent(eSliceEvent.eSliceCancelled,0,0);
                m_cancel = true;
            }        
        }
        private void SliceStarted(string scenename, int numslices) 
        {
           // if (m_buildparms.exportimages)
            {
                string path = "";
                // get the model name, could be scene....
                String modelname = scenename;
                // strip off the file extension
                path = Path.GetDirectoryName(modelname);
                path += UVDLPApp.m_pathsep;
                path += Path.GetFileNameWithoutExtension(modelname);// strip off the file extension

                if (m_sf.m_config.m_exportopt.ToUpper().Contains("ZIP"))
                {
                    m_zip = new ZipFile();
                }
                else 
                {
                    if (!Directory.Exists(path)) // check and see if a directory of that name exists,
                    {
                        Directory.CreateDirectory(path);// if not, create it
                    }                
                }
            }
            RaiseSliceEvent(eSliceEvent.eSliceStarted, 0, numslices);
        }

        // currently, this will save both into a zip file and into a subdirectory
        private void LayerSliced(string scenename, int layer, int numslices, Bitmap bmp) 
        {
            string path;
            try
            {
                // if (m_buildparms.exportimages)
                {
                    // get the model name
                    String modelname = scenename;
                    // strip off the file extension
                    path = Path.GetDirectoryName(modelname);
                    path += UVDLPApp.m_pathsep;
                    path += Path.GetFileNameWithoutExtension(modelname);// strip off the file extension
                    // = null;
                    String imname = Path.GetFileNameWithoutExtension(modelname) + String.Format("{0:0000}", layer) + ".png";
                    String imagename = path + UVDLPApp.m_pathsep + imname;
                    if (m_sf.m_config.m_exportopt.ToUpper().Contains("ZIP"))
                    {
                        // create a memory stream for this to save into
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, ImageFormat.Png);
                        ms.Seek(0, SeekOrigin.Begin); // seek back to beginning
                        m_zip.AddEntry(imname, ms);
                    }
                    else
                    {
                        bmp.Save(imagename);
                    }
                    
                    RaiseSliceEvent(eSliceEvent.eLayerSliced, layer, numslices);
                }
            }
            catch (Exception ex) 
            {
                string s = ex.StackTrace;
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        private void SliceCompleted(string scenename, int layer, int numslices) 
        {
            if (m_sf.m_config.m_exportopt.ToUpper().Contains("ZIP"))
            {
                String path = "";
                String modelname = scenename;
                // strip off the file extension
                path = Path.GetDirectoryName(modelname);
                path += UVDLPApp.m_pathsep;
                path += Path.GetFileNameWithoutExtension(modelname);// strip off the file extension
                path += ".zip";
                m_zip.Save(path);
            }
            RaiseSliceEvent(eSliceEvent.eSliceCompleted, layer, numslices);
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
            try
            {
                if (zlev >= obj.m_min.z && zlev <= obj.m_max.z)
                {
                    foreach (Polygon p in obj.m_lstpolys)
                    {
                        //check and see if current z level is between any of the polygons z coords
                        //MinMax mm = p.CalcMinMax();
                        if (p.m_minmax.InRange(zlev))
                        {
                            lst.Add(p);
                        }
                    }
                }                
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
            return lst;
        }
    }
}
