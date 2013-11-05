using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UV_DLP_3D_Printer
{
    [Serializable]
    public class ProjectorCommand
    {
        public string command;
        public bool hex; // hex or ascii
        public string name; // the name of this command
        
        public byte[] GetBytes() 
        {
            try
            {
                string cmd = command.Replace(" ", string.Empty);
                return Utility.HexStringToByteArray(cmd);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                return null;
            }
        }
        public ProjectorCommand() 
        {
            command = "";
            hex = false;
            name = "none";
        }
        /*
        public bool Save(StreamWriter sw) 
        {
            try
            {
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);

            }
            return false;
        }
        public bool Load(StreamReader sr)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);

            }
            return false;
        }
         * */
    }
}
