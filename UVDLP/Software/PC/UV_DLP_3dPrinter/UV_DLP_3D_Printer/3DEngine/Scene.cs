using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using Engine3D;
using System.IO;
using System.Xml;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer._3DEngine
{
    /// <summary>
    /// This class is a singleton. It's purpose is to load and save an entire scene into a zip file
    /// This allows the user to later load/save the scene that they were previously working on
    /// it will save the scene into a zip file along with an XML file that stores a manifest as well as additional
    /// metadata about each object such as tag info, current selected onject, etc...
    /// this file can also store the png slices (if sliced) or an SVG file
    /// </summary>
    public class Scene
    {
        private static Scene m_instance = null;
        public static Scene Instance() 
        {
            if (m_instance == null) 
            {
                m_instance = new Scene();
            }
            return m_instance;
        }

        /// <summary>
        /// Save the entire scene into a zip file with a manifest
        /// This file will later be re-used to store png slicee, gcode & svg
        /// </summary>
        /// <param name="scenename"></param>
        /// <returns></returns>
        public bool Save(string scenename) 
        {
            try
            {
                // open a zip file with the scenename
                // iterate through all objects in engine
                string xmlname = "manifest.xml";
                XmlHelper manifest = new XmlHelper();
                //start the doc with no filename, becasue we're saving to a memory stream
                manifest.StartNew("", "manifest");
                //start a new stream to store the manifest file
                MemoryStream manifeststream = new MemoryStream();
                //create a new zip file
                ZipFile zip = new ZipFile();
                //get the top-level node in the manifest
                //XmlNode mc = manifest.m_toplevel;
                XmlNode mc = manifest.AddSection(manifest.m_toplevel, "Models");
                //we need to make sure that only unique names are put in the zipentry
                // cloned objects yield the same name
                List<string> m_uniquenames = new List<string>();
                // we can adda 4-5 digit code to the end here to make sure names are unique
                int id = 0;
                string idstr;
                foreach (Object3d obj in UVDLPApp.Instance().m_engine3d.m_objects)
                {
                    //create a unique id to post-fix item names
                    id++;
                    idstr = string.Format("{0:0000}", id);
                    idstr = "_" + idstr;
                    //create a new memory stream
                    MemoryStream ms = new MemoryStream();
                    //save the object to the memory stream
                    obj.SaveSTL_Binary(ref ms);
                    //rewind the stream to the beginning
                    ms.Seek(0, SeekOrigin.Begin);
                    //get the file name with no extension
                    string objname = Path.GetFileNameWithoutExtension(obj.Name);
                    //spaces cause this to blow up too
                    objname = objname.Replace(' ', '_');
                    // add a value to the end of the string to make sure it's a unique name
                    objname = objname + idstr;
                    string objnameNE = objname;
                    objname += ".stl";  // stl file

                    zip.AddEntry(objname, ms);
                    //create an entry for this object, using the object name with no extension
                    //save anything special about it

                    XmlNode objnode = manifest.AddSection(mc, objnameNE);
                    manifest.SetParameter(objnode, "tag", obj.tag);
                    if (obj.tag == Object3d.OBJ_SUPPORT && obj.m_parrent !=null) 
                    {
                        // note it's parent name in the entry
                        manifest.SetParameter(objnode, "parent", Path.GetFileNameWithoutExtension(obj.m_parrent.Name));
                    }
                }
                 
                //save the XML document to memorystream
                manifest.Save(1, ref manifeststream);
                manifeststream.Seek(0, SeekOrigin.Begin);
                //manifeststream.
                //save the memorystream for the xml metadata manifest into the zip file
                zip.AddEntry(xmlname, manifeststream);

                //save the zip file
                zip.Save(scenename);
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
            return false;
        }

        public bool Load(string scenename)
        {
            return false;
        }

    }
}
