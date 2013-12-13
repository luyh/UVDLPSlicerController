using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Engine3D
{
    public class ModelLoaderAmf : ModelLoader
    {
        public enum eUnit
        {
            Millimeter = 0,
            Inch
        }
        XmlDocument m_xdoc;
        XmlAttribute m_verattr;
        Object3d m_object;


        public XmlNode m_toplevel;
        public int m_version;
        public ModelLoaderAmf()
        {
            m_fileExt = "amf";
        }

        public override Object3d LoadModel(string filename)
        {
            try
            {
                m_xdoc = new XmlDocument();
                m_xdoc.Load(filename);
                m_toplevel = m_xdoc.ChildNodes[1];
                if (m_toplevel.Name != "amf")
                {
                    LogError(filename + " is not a valid AMF file");
                    return null;
                }
                m_object = new Object3d();

            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
            return null;
        }


        String GetAttr(XmlNode node, String attr, String defval)
        {
            try
            {
                String res = node.Attributes[attr].Value;
                return res;
            }
            catch (Exception) { }
            return defval;
        }

        bool ParseBody(XmlNode xBody)
        {
            return true;
        }
    }
}
