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
        public SliceBuildConfig m_config; // the slicing parameters used to create the image slices
        public string modelname; // the fully qualified model/scene name, so we can load up the image files
        private int m_numslices;
        ZipFile m_zip;
        public SliceFile() 
        {
            m_config = new SliceBuildConfig(); // going to be loaded
         
        }

        public int NumSlices 
        {
            get { return m_numslices; }
            set { 
                m_numslices = value; }
        }

        // constructor that the slicer calls to create
        /// <summary>
        /// This will copy over some sliceconfig data into class vars for easier saving and loading later
        /// </summary>
        /// <param name="config"></param>
        public SliceFile(SliceBuildConfig config) 
        {
            m_config = new SliceBuildConfig(config); // copy the source
            //m_slices = new ArrayList();
        }

        public bool Load(string filename) 
        {
            try
            {
                Stream FileStream = File.OpenRead(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                StreamReader sr = new StreamReader(FileStream);
                m_config = (SliceBuildConfig)serializer.Deserialize(FileStream);
                int numslice = int.Parse(sr.ReadLine());
                for (int c = 0; c < numslice; c++) 
                {
                    Slice sl = new Slice();
                    //m_slices.Add(sl);
                    sl.Load(sr);
                }
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
        }
        public bool Save(string filename)
        {
            try
            {
                //save the slice config first
                Stream FileStream = File.Create(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                StreamWriter sw = new StreamWriter(FileStream); // create a filestream so this all works
                serializer.Serialize(FileStream, m_config);
                //save number of slices
                //sw.WriteLine(m_slices.Count.ToString());
                //now save the slices
                /*
                foreach (Slice sl in m_slices) 
                {
                    sl.Save(sw);
                }
                 * */
                FileStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
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

                if (m_config.m_exportopt.ToUpper().Contains("ZIP"))
                {
                    // read the bitmap from the zip
                    path += ".zip";
                    m_zip = ZipFile.Read(path);
                    string fname = Path.GetFileNameWithoutExtension(modelname) + String.Format("{0:0000}", layer) + ".png";
                    ZipEntry ze = m_zip[fname];
                    Stream stream = new MemoryStream();
                    ze.Extract(stream);
                    Bitmap bmp = new Bitmap(stream);
                    return bmp;      
                }
                else
                {
                    //read bitmap from disk
                    path += UVDLPApp.m_pathsep;
                    path += Path.GetFileNameWithoutExtension(modelname) + String.Format("{0:0000}", layer) + ".png";
                   
                    Bitmap bmp = new Bitmap(path);
                    return bmp;
                }
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
