using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace UV_DLP_3D_Printer
{
    /// <summary>
    /// Projector command list
    /// </summary>
    /// 
    [Serializable]
    public class prjcmdlst
    {
        public List<ProjectorCommand> m_commands;
        public prjcmdlst() 
        {
            m_commands = new List<ProjectorCommand>();
        }       
    }
}
