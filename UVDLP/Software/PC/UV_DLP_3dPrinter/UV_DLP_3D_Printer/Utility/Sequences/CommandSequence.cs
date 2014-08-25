using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Util.Sequence
{
    /// <summary>
    /// base class for a generic command sequence
    /// </summary>
    public class CommandSequence
    {
        public const int COMMAND_TYPE_GCODE = 1; // gcode sequence
        public string m_name; // the name of the sequence
        public int m_seqtype; // type of sequence
        public string m_seq; // the raw stringified sequence as read from the xml
    }

    public class GCodeSequence : CommandSequence
    {
        public GCodeSequence(string name, string seq)
        {
            m_seq = seq;
            m_name = name;
            m_seqtype = COMMAND_TYPE_GCODE;
        }
    }

}
