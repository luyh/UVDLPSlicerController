using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Device_Interface
{
    /// <summary>
    /// This class is the go-between for sending gcode commands to the Device interface
    /// This is here so delegate functions can be bound not to a GUI control for control of the printer
    /// </summary>
    public class ManualControl
    {
        private static ManualControl m_instance = null;

        // define some rates 
        private double m_rateXY;
        private double m_rateZ;
        private double m_rateE;
        private double m_distZ; // how far in Z to move
        private double m_distXY; // the X/Y distance to move

        private ManualControl() 
        {
            m_rateXY = 3000;
            m_rateZ = 200;
            m_rateE = 10;
            Load(); // load the current values
        }

        public double XYRate 
        {
            get { return m_rateXY; }
            set { m_rateXY = value; Save(); }
        }
        public double XYDist
        {
            get { return m_distXY; }
            set { m_distXY = value; Save(); }
        }
        public double ZRate 
        {
            get { return m_rateZ; }
            set { m_rateZ = value; Save(); }
        }
        public double ZDist
        {
            get { return m_distZ; }
            set { m_distZ = value; Save(); }
        }
        public static ManualControl Instance() 
        {
            if (m_instance == null)
            {
                m_instance = new ManualControl();
            }
            return m_instance;
        
        }
        public bool Load() 
        {
            return false;
        }
        public bool Save() 
        {
            return false;
        }
        void RegisterCallbacks()
        {
            CallbackHandler cb = UVDLPApp.Instance().m_callbackhandler;
            cb.RegisterCallback("MCCmdSetZDist", SetZdist, typeof(double), "Set distanse (zdist) in mm for manual up/down movement");
            cb.RegisterCallback("MCCmdMoveUp", cmdUp_Click, null, "Move print head up zdist amount");
            cb.RegisterCallback("MCCmdMoveDown", cmdDown_Click, null, "Move print head down zdist amount");
            //cb.RegisterCallback("", , null, "");
        }
        void SetZdist(object sender, object vars)
        {
            try
            {
                double dist = (double)vars;
                m_distZ = dist;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
        private void cmdUp_Click(object sender, object e)
        {
            try
            {
                //double dist = double.Parse(txtdist.Text);
                UVDLPApp.Instance().m_deviceinterface.Move(m_distZ, m_rateZ); // (movecommand);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);                
            }
        }
        /// <summary>
        /// Z Axis Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDown_Click(object sender, object e)
        {
            try
            {
                m_distZ *= -1.0;
                UVDLPApp.Instance().m_deviceinterface.Move(m_distZ, m_rateZ); // (movecommand);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

    }
}
