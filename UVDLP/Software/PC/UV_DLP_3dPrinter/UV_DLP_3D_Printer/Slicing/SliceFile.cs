using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;//.BinaryFormatter;
using Ionic.Zip;

namespace UV_DLP_3D_Printer.Slicing
{
    /*
     * This class represents an object that has been completely sliced.
     * It contains the initial build and slicing parameters used to create the file
     * This file should be all that is necessary (along with GCode) to display slices
     * or to build the object
     * This class should serve image slices, either generated on the fly, or pre-rendered and loaded
     */
    public class SliceFile
    {
        
        public enum SFMode 
        {
            eLoaded, // this is a fake lice file, there is no config, pull a few parms from the gcode file
            eSliced // this is from a slicing done this session
        }
         
        public SliceBuildConfig m_config; // the slicing parameters used to create the image slices
        public string modelname; // the fully qualified model/scene name, so we can load up the image files
        private int m_numslices;
        private int m_xres, m_yres;
        private SFMode m_mode;

        ZipFile m_zip;
        /*
        public SliceFile() 
        {
            m_config = new SliceBuildConfig(); // going to be loaded         
        }
         */ 
        public int XProjRes 
        {
            get { return m_xres; }
        }

        public int YProjRes
        {
            get { return m_yres; }
        }

        public int NumSlices 
        {
            get { return m_numslices; }
            set { m_numslices = value; }
        }
        
        public SliceFile(int xres, int yres, int numslices) 
        {
            m_xres = xres;
            m_yres = yres;
            m_numslices = numslices;
            m_mode = SFMode.eLoaded;
        }
        /// constructor that the slicer calls to create
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        public SliceFile(SliceBuildConfig config) 
        {
            m_config = new SliceBuildConfig(config); // copy the source
            m_xres = config.xres;
            m_yres = config.yres;
            m_mode = SFMode.eSliced;
        }

        /*
         This function get the slice from the cache/drive 
         */
        public Bitmap GetSlice(int layer) // 0 based index
        {
            try
            {
                string path = "";
                path = Path.GetDirectoryName(modelname);
                path += UVDLPApp.m_pathsep;
                path += Path.GetFileNameWithoutExtension(modelname);// strip off the file extension
                try
                {
                    // try first to load from zip
                    // read the bitmap from the zip
                    path += ".zip";
                    m_zip = ZipFile.Read(path);
                    string fname = Path.GetFileNameWithoutExtension(modelname) + String.Format("{0:0000}", layer) + ".png";
                    ZipEntry ze = m_zip[fname];
                    Stream stream = new MemoryStream();
                    ze.Extract(stream);
                    Bitmap bmp = new Bitmap(stream);
                    return bmp;      
                }catch(Exception )
                {
                
                }
                try
                {
                    //try to read bitmap from disk
                    path = Path.GetDirectoryName(modelname);
                    path += UVDLPApp.m_pathsep;
                    path += Path.GetFileNameWithoutExtension(modelname);// strip off the file extension

                    path += UVDLPApp.m_pathsep;
                    path += Path.GetFileNameWithoutExtension(modelname) + String.Format("{0:0000}", layer) + ".png";

                    Bitmap bmp = new Bitmap(path);
                    return bmp;
                }
                catch (Exception ) { }
                return null;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return null;
            }
        }
    }
}
