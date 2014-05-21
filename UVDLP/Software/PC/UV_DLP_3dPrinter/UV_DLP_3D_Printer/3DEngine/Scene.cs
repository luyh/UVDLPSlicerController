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
        public bool Load(string scenename) 
        {
            try
            {
                ZipFile zip = ZipFile.Read(scenename);
                string xmlname = "manifest.xml";
                ZipEntry manifestentry = zip[xmlname];
                //create new manifest xml doc
                XmlHelper manifest = new XmlHelper();
                //get memory stream
                MemoryStream manistream = new MemoryStream();
                //extract the stream
                manifestentry.Extract(manistream);
                //read from stream
                manistream.Seek(0, SeekOrigin.Begin); // rewind the stream for reading
                manifest.LoadFromStream(manistream, "manifest");
                //examine manifest
                //find the node with models
                XmlNode topnode = manifest.m_toplevel;
                XmlNode models = manifest.FindSection(topnode, "Models");
                List<XmlNode> modelnodes = manifest.FindAllChildElement(models, "model");
                bool supportLoaded = false;
                foreach (XmlNode nd in modelnodes) 
                {
                    string name = manifest.GetString(nd, "name", "noname");
                    string modstlname = name + ".stl";
                    int tag = manifest.GetInt(nd, "tag", 0);
                    ZipEntry modelentry = zip[modstlname]; // the model name will have the _XXXX on the end with the stl extension
                    MemoryStream modstr = new MemoryStream();
                    modelentry.Extract(modstr);
                    //rewind to beginning
                    modstr.Seek(0, SeekOrigin.Begin);
                    //fix the name
                    name = name.Substring(0, name.Length - 5);// get rid of the _XXXX at the end
                    string parentName = manifest.GetString(nd, "parent", "noname");
                    Object3d obj, tmpObj;
                    switch (tag)
                    {
                        case Object3d.OBJ_SUPPORT:
                        case Object3d.OBJ_SUPPORT_BASE:
                            if (tag == Object3d.OBJ_SUPPORT)
                                obj = (Object3d)(new Support());
                            else
                                obj = (Object3d)(new SupportBase());
                            //load the model
                            obj.LoadSTL_Binary(modstr, name);
                            //add to the 3d engine
                            UVDLPApp.Instance().m_engine3d.AddObject(obj);
                            //set the tag
                            obj.tag = tag;
                            obj.SetColor(System.Drawing.Color.Yellow);
                            //find and set the parent
                            tmpObj = UVDLPApp.Instance().m_engine3d.Find(parentName);
                            if (tmpObj != null)
                            {
                                tmpObj.AddSupport(obj);
                            }
                            supportLoaded = true;
                            break;

                        default:
                            //load as normal object
                            obj = new Object3d();
                            //load the model
                            obj.LoadSTL_Binary((MemoryStream)modstr, name);
                            //add to the 3d engine
                            UVDLPApp.Instance().m_engine3d.AddObject(obj);
                            //set the tag
                            obj.tag = tag;
                            break;
                    }
                }
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eModelAdded, "Scene loaded");
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
                return false;
            }
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

                    //XmlNode objnode = manifest.AddSection(mc, objnameNE);
                    XmlNode objnode = manifest.AddSection(mc, "model");
                    manifest.SetParameter(objnode, "name", objnameNE);
                    manifest.SetParameter(objnode, "tag", obj.tag);
                    if (obj.tag != Object3d.OBJ_NORMAL && obj.m_parrent != null) 
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

    }
}
