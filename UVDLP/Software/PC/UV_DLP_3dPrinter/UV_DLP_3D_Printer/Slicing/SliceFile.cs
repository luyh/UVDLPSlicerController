using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;//.BinaryFormatter;

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
        public SliceBuildConfig m_config; // not convinced we need to have all this, just a few parts of it
        public ArrayList m_slices; // list of Slices
        /*
        public bool antialiasing;
        public double aaval;
        public double dpmmX; // dots per mm x
        public double dpmmY; // dots per mm y
        public int xres, yres; // the resolution of the output image in pixels
        public int XOffset,YOffset;
        */
        public SliceFile() 
        {
            m_config = new SliceBuildConfig(); // going to be loaded
            m_slices = new ArrayList();
        }


        // constructor that the slicer calls to create
        /// <summary>
        /// This will copy over some sliceconfig data into class vars for easier saving and loading later
        /// </summary>
        /// <param name="config"></param>
        public SliceFile(SliceBuildConfig config) 
        {
            m_config = new SliceBuildConfig(config); // copy the source
            /*
            antialiasing = config.antialiasing;
            aaval = config.aaval;
            dpmmX = config.dpmmX;
            dpmmY = config.dpmmY;
            xres = config.xres;
            yres = config.yres;
            XOffset = config.XOffset;
            YOffset = config.YOffset;
             * */
            m_slices = new ArrayList();
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
                    m_slices.Add(sl);
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
                sw.WriteLine(m_slices.Count.ToString());
                //now save the slices
                foreach (Slice sl in m_slices) 
                {
                    sl.Save(sw);
                }
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
         This function does the rasterization of the generated slice into
         * a 2d bitmap that can be displayed and sent to the machine's DLP
         */
        public Bitmap RenderSlice(int layer) // 0 based index
        {
            try
            {
                Slice slice = (Slice)m_slices[layer];
                return slice.RenderSlice(m_config);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return null;
            }
        }
    }
}
