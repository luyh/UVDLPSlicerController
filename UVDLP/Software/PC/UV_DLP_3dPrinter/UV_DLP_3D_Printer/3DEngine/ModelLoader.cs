using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine3D
{
    public abstract class ModelLoader
    {
        String m_lastError = null;
        protected String m_fileExt;
        public abstract Object3d LoadModel(String filename);

        protected void LogError(String err)
        {
            m_lastError = err;
        }

        String FileExt
        {
            get { return m_fileExt; }
        }

        String LastError
        {
            get { return m_lastError; }
        }
    }
}
