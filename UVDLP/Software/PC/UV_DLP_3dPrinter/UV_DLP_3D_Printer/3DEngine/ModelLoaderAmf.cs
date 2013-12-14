using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Ionic.Zip;

namespace Engine3D
{
    public class ModelLoaderAmf : ModelLoaderType
    {
        public enum eUnit
        {
            Millimeter = 0,
            Inch,
            Meter,
            Micron,
            Feet
        }
        XmlDocument m_xdoc;
        Object3d m_curObject;
        eUnit m_unit;
        float m_scaleFactor;
        List<Object3d> m_objList;
        List<Point3d> m_pointList;
        String m_filepath;
        int m_nobjects;
        
        public XmlNode m_toplevel;
        public int m_version;
        public ModelLoaderAmf()
        {
            m_fileExt = ".amf";
            m_fileDesc = "Additive Manufacturing File Format";
        }

        public override List<Object3d> LoadModel(string filename)
        {
            m_filepath = filename;
            try
            {
                m_xdoc = new XmlDocument();
                MemoryStream mstream = TryReadZip(filename);
                if (mstream != null) {
                    m_xdoc.Load(mstream);
                }
                else
                {
                    m_xdoc.Load(filename);
                }
                m_toplevel = m_xdoc["amf"];
                m_objList = new List<Object3d>();
                ParseBody(m_toplevel);
                return m_objList;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
            return null;
        }

        private MemoryStream TryReadZip(string filename)
        {
            try
            {
                ZipFile zpf = ZipFile.Read(filename);
                ZipEntry ze = zpf[Path.GetFileName(filename)];
                MemoryStream mstream = new MemoryStream();
                ze.Extract(mstream);
                mstream.Seek(0, SeekOrigin.Begin);
                return mstream;
            }
            catch (Exception ex) 
            {
                m_lastError = ex.Message;
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

        void GetUnit(XmlNode node)
        {
            String unitStr = GetAttr(node, "unit", "millimeter");
            switch (unitStr)
            {
                default:
                case "millimeter":
                    m_unit = eUnit.Millimeter;
                    m_scaleFactor = 1.0f;
                    break;

                case "inch":
                    m_unit = eUnit.Inch;
                    m_scaleFactor = 25.4f;
                    break;

                case "meter":
                    m_unit = eUnit.Meter;
                    m_scaleFactor = 1000.0f;
                    break;

                case "micron":
                    m_unit = eUnit.Micron;
                    m_scaleFactor = 1.0f / 1000.0f;
                    break;

                case "feet":
                    m_unit = eUnit.Feet;
                    m_scaleFactor = 12.0f * 2.54f;
                    break;
            }
        }

        void ParseBody(XmlNode xBody)
        {
            GetUnit(xBody);
            m_nobjects = 0;
            foreach (XmlNode xnode in xBody.ChildNodes)
            {
                switch (xnode.Name)
                {
                    case "object":
                        ParseObject(xnode);
                        break;
                }
            }
            if (m_nobjects > 1)
            {
                for (int i = 1; i <= m_nobjects; i++)
                {
                    m_objList[i].Name += "_" + i.ToString();
                }
            }
        }

        void ParseObject(XmlNode xObject)
        {
            m_curObject = new Object3d();
            ParseMesh(xObject["mesh"]);
            m_curObject.m_fullname = m_filepath;
            m_curObject.Name = Path.GetFileName(m_filepath);
            m_curObject.Update();
            m_objList.Add(m_curObject);
            m_nobjects++;
        }

        void ParseMesh(XmlNode xMesh)
        {
            ReadVertices(xMesh["vertices"]);
            ReadVolume(xMesh["volume"]);
        }

        void ReadVertices(XmlNode xVerts)
        {
            m_pointList = new List<Point3d>();
            foreach (XmlNode xnode in xVerts.ChildNodes)
            {
                if (xnode.Name == "vertex")
                    ParseVertex(xnode);
            }
        }

        void ParseVertex(XmlNode xVert)
        {
            XmlNode xcoor = xVert["coordinates"];
            float x = float.Parse(xcoor["x"].InnerText) * m_scaleFactor;
            float y = float.Parse(xcoor["y"].InnerText) * m_scaleFactor;
            float z = float.Parse(xcoor["z"].InnerText) * m_scaleFactor;
            Point3d pt = new Point3d(x, y, z);
            m_pointList.Add(pt);
        }

        void ReadVolume(XmlNode xVolume)
        {
            m_curObject = new Object3d();
            m_curObject.m_lstpoints = m_pointList;
            foreach (XmlNode xnode in xVolume.ChildNodes)
            {
                if (xnode.Name == "triangle")
                    ParseTriangle(xnode);
            }
        }
 
        void ParseTriangle(XmlNode xTri)
        {
            Point3d pt1 = m_pointList[int.Parse(xTri["v1"].InnerText)];
            Point3d pt2 = m_pointList[int.Parse(xTri["v2"].InnerText)];
            Point3d pt3 = m_pointList[int.Parse(xTri["v3"].InnerText)];
            Polygon p = new Polygon();
            p.m_points = new Point3d[] { pt1, pt2, pt3 };
            // calculate normal
            Vector3d v1 = new Vector3d(pt1.x - pt2.x, pt1.y - pt2.y, pt1.z - pt2.z);
            Vector3d v2 = new Vector3d(pt3.x - pt2.x, pt3.y - pt2.y, pt3.z - pt2.z);
            p.m_normal = Vector3d.cross(v1, v2);
            p.m_normal.Normalize();
            m_curObject.m_lstpolys.Add(p);
        }


    }
}
