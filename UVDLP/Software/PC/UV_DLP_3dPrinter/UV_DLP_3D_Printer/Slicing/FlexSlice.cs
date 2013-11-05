using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using Engine3D;
using UV_DLP_3D_Printer.Slicing.Modules;
namespace UV_DLP_3D_Printer.Slicing
{
    /*FlexSlice - the flexable slicer*/
    public delegate void FlexSliceEvent(SliceModule sm, int layer, int totallayers, string message); // this will tell the rest of the app about slicing events
    public class FlexSlice
    {
        // this is the list of default modules
        private static SliceModule[] defmodules = 
        {
            new Carve(),  
            new UV_Bottom(),
            new ImageSliceExporter(),
            new UV_GCode_Gen(),
        };

        private Thread m_runthread = null;
        private bool m_running;
        public ArrayList m_modules;// the list of modules
        private SliceData m_data = null;

        public FlexSliceEvent SliceEvent;

        public enum eFlexSliceEvent 
        {
            eSlicingStarted,
            eSlicingFinished,
            eSlicingCancelled,
            eModuleStarted,
            eModuleCompleted,
            eLayerCompleted
        }

        protected void RaiseSliceEvent(SliceModule sm, int layer, int totallayers, string message) 
        {
            if (SliceEvent != null) 
            {
                SliceEvent(sm, layer, totallayers, message);
            }
        }

        public void CreateDefaultModules() 
        {
            m_modules = new ArrayList();
            // the order defines which ones run first
            foreach (SliceModule sm in defmodules) 
            {
                m_modules.Add(sm);
            }
        }
        
        public FlexSlice() 
        {
            m_running = false;
            m_runthread = null;
            m_modules = new ArrayList();
            CreateDefaultModules();
        }
        public bool StartSlice(Object3d obj) 
        {
            try
            {
                // make sure we've got new slicedata
                m_data = new SliceData();
                SliceModule.m_data = m_data;
                //set the target object
                SliceModule.m_data.m_obj = obj; 

                //start the thread
                m_running = true;
                m_runthread = new Thread(run);
                m_runthread.Start();
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);        
            }
            return false;
        }

        private void run() 
        {
            while (m_running) 
            {
                //iterate through all modules
                // perform the action on each module
                foreach (SliceModule sm in m_modules) 
                {
                    if (sm.Enabled == true)
                        sm.Execute();
                }
            }
        }
        
    }
}
