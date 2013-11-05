using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
namespace UV_DLP_3D_Printer.Slicing
{
    /// <summary>
    /// this class can take a slice file and estimate the volume in Liters of a print, 
    /// it will also estimate the cost of the print
    /// </summary>
    public class VolumeEstimator
    {
        public enum eVolEstEvent 
        {
            eStarted,
            eCompleted, //Finished estimating
            eTick, // went through a BM
            eCancelled
        }
        public delegate void VolEstEvent(eVolEstEvent ev,string message);
        public VolEstEvent VolEstEventDel;
        SliceFile m_sf;
        SliceBuildConfig m_sbc;
       
        private Thread m_thread = null;
        private bool m_running = false;
        public VolumeEstimator() 
        {
        
        }
        /// <summary>
        /// this function has to be called before the start
        /// </summary>
        /// <param name="sf"></param>
        /// <param name="sbc"></param>
        public void Setup(SliceFile sf, SliceBuildConfig sbc) 
        {
            m_sf = sf;
            m_sbc = sbc;        
        }
        public void StartEstimate() 
        {            
            m_thread = new Thread(new ThreadStart(runit));
            m_running = true;
            
            m_thread.Start();
        }
        private void RaiseEvent(eVolEstEvent ev, string message) 
        {
            if (VolEstEventDel != null) 
            {
                VolEstEventDel(ev, message);
            }
        }
        public void Cancel() 
        {
            m_running = false;
        }
        private void runit() 
        {
            try
            {
                double pixarea = 0.0; // pixel area is the x * y size in mm
                pixarea = (1.0 / m_sbc.dpmmX) * (1.0 / m_sbc.dpmmY);
                double pixvol = pixarea * m_sbc.ZThick;
                long numlitpix = 0;
                Color fgc = UVDLPApp.Instance().m_appconfig.m_foregroundcolor;// background color 
                RaiseEvent(eVolEstEvent.eStarted, m_sf.NumSlices.ToString());

                for (int c = 0; c < m_sf.NumSlices; c++) 
                {
                    if (m_running)
                    {
                        Bitmap sl = m_sf.GetSlice(c);
                        LockBitmap lb = new LockBitmap(sl);
                        lb.LockBits();
                        for (int x = 0; x < lb.Width; x++)
                        {
                            for (int y = 0; y < lb.Height; y++)
                            {
                                Color col = lb.GetPixel(x, y);
                                if (col.B == fgc.B &&
                                    col.R == fgc.R &&
                                    col.G == fgc.G)
                                {
                                    numlitpix++;
                                }
                            }
                        }
                        lb.UnlockBits();
                        string st = "";
                        st = c.ToString() + ":" + m_sf.NumSlices;
                        RaiseEvent(eVolEstEvent.eTick, st);
                    }
                    else 
                    {
                        RaiseEvent(eVolEstEvent.eCancelled, "Estimate cancelled");
                        return; // break outta this
                    }
                }
                double vol = numlitpix * pixvol;// in liters
                vol /= 1000.00;
                string svol = "Build volume is " + string.Format("{0:0.000}",vol);
                svol += " ml";
                double cost = (m_sbc.m_resinprice / 1000.0) * vol;
                svol += " : Cost is " + string.Format("{0:0.00}", cost);
                RaiseEvent(eVolEstEvent.eCompleted, svol);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
    }
}
