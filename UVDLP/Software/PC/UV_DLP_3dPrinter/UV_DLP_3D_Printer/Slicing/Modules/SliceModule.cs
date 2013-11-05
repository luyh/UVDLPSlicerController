using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using UV_DLP_3D_Printer.Slicing.Modules;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer.Slicing
{
    /*
     This is the base class for slicing modules
     * each module can perform a specific action on the object model
     * or input / output data used during the slicing process
     * various modules could include:
     * raft generation
     * Bottom layer
     * support generation
     * actual slicer (object model to polylines / lines)
     * image generation (image exporting or run-time generation)
     * first layer alterations (additional time)     
     * svg export
     * etc...
     */
    public class SliceModule
    {
        protected string m_name; // the name of this module
        protected string m_description; // a more verbose description of this module
        protected string m_help; // associated help for this module
        public ParmList m_parms = new ParmList();
        protected bool m_enabled; // is this module enabled
        // this is the main function for this module to execute it's functionality
        public static SliceData m_data; // the data all slices can work on, static because we don't need a pointer for each
        protected bool m_cancel = false; // cancel this operation's thread

        /*
         This method is here so sub-classes can construct thier own
         default slicing parameters needed for operation
         */
        public virtual void CreateDefault() 
        {
        
        }

        //public 
        public bool Enabled 
        {
            get { return m_enabled; }
            set { m_enabled = value; }
        }
        public virtual bool Execute() 
        {
            return false;
        }
        public string Name
        {
            get { return m_name; }
        }
        public string Description
        {
            get { return m_description; }
        }
        public string Help
        {
            get { return m_help; }
        }
        public bool Save(XmlWriter writer)
        {
            //save the array
            //writer.WriteStartElement("SliceModule");
                writer.WriteElementString("Name", Name);
                writer.WriteElementString("Description", Description);
                writer.WriteElementString("Help", Help);
                writer.WriteElementString("Enabled", Enabled.ToString());
                foreach (Parm p in m_parms.Parms) 
                {
                    writer.WriteStartElement("Parm");
                    p.Save(writer);
                    writer.WriteEndElement();
                }
            //writer.WriteEndElement();
            return false;
        }
        public bool Load(XmlReader reader)
        {
            //load the array
            //reader.ReadStartElement(); // slice module
            m_name = reader.ReadElementString("Name");
            m_description = reader.ReadElementString("Description");
            m_help = reader.ReadElementString("Help");
            m_enabled = bool.Parse(reader.ReadElementString("Enabled"));
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Parm"))
                {
                    Parm p = new Parm();
                    p.Load(reader);
                    m_parms.Parms.Add(p);
                    reader.ReadEndElement();
                }
            }
          //  reader.ReadEndElement();
            return false;
        }
    }
}
