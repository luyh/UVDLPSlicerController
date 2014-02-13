using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UV_DLP_3D_Printer
{
    public delegate void CallbackType(Object sender, Object vars);
    class CallbackItem
    {
        public String name;
        public String type;
        public String description;
        public CallbackType Callback;
    }

    public class CallbackHandler
    {
        Dictionary<String, CallbackItem> CallbackDB;

        public CallbackHandler()
        {
            CallbackDB = new Dictionary<string, CallbackItem>();
        }

        public void RegisterCallback(String cmdname, CallbackType func, Type vartype, String desc)
        {
            CallbackItem cb;
            String vartypename = "null";
            String cmd = cmdname;
            if (vartype != null)
            {
                vartypename = vartype.ToString();
                cmd += "|" + vartypename;
            }
            if (CallbackDB.ContainsKey(cmdname))
            {
                cb = CallbackDB[cmd];
            }
            else
            {
                cb = new CallbackItem();
                cb.name = cmdname;
                cb.type = vartypename;
                cb.description = desc;
                CallbackDB[cmdname] = cb;
            }
            cb.Callback += new CallbackType(func);
        }

        public bool Activate(String cmdname, Object sender, Object vars)
        {
            if (cmdname == null)
                return false;
            if ((vars != null) && (vars.GetType() != null))
                cmdname += "|" + vars.GetType().ToString();
            if (!CallbackDB.ContainsKey(cmdname))
                return false;
            CallbackItem cb = CallbackDB[cmdname];
            if (cb.Callback == null)
                return false;
            cb.Callback(sender, vars);
            return true;
        }

        public bool Activate(String cmdname, Object sender)
        {
            return Activate(cmdname, sender, null);
        }

        public bool Activate(String cmdname)
        {
            return Activate(cmdname, null, null);
        }

        public void DumpCommands(String filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (KeyValuePair<String, CallbackItem> pair in CallbackDB)
            {
                CallbackItem ci = pair.Value;
                sw.WriteLine("{0}, \t{1}, \t{2}", ci.name, ci.type, ci.description);
            }
            sw.Close();
            sw.Dispose();
        }
    }
}
