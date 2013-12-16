using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Ionic.Zip;
using UV_DLP_3D_Printer.GUI;

namespace Engine3D
{
    public class ModelLoaderAmf : ModelLoaderType
    {
        class EdgeAmf
        {
            public int v1;
            public int v2;
            public int v12 = -1;
            public Vector3d t1;
            public Vector3d t2;
        }

        class PointAmf
        {
            public Point3d pt;
            public Vector3d normal = null;
            public List<EdgeAmf> edgeList = null;
            public void AddEdge(EdgeAmf edge)
            {
                if (edgeList == null)
                    edgeList = new List<EdgeAmf>();
                edgeList.Add(edge);
            }

            public EdgeAmf FindEdge(int v2)
            {
                if (edgeList == null)
                    return null;
                foreach (EdgeAmf edge in edgeList)
                {
                    if (edge.v2 == v2)
                        return edge;
                }
                return null;
            }
        }

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
        List<PointAmf> m_pointList;
        List<EdgeAmf> m_edgeList;
        String m_filepath;
        int m_nobjects;
        bool m_smoothObj;
        const float Epsilon = 0.0000001f;
        frmAmfSmoothing m_formSmooth;
        int m_smoothLevel;
        
        public XmlNode m_toplevel;
        public int m_version;
        public ModelLoaderAmf()
        {
            m_fileExt = ".amf";
            m_fileDesc = "Additive Manufacturing File Format";
            m_formSmooth = new frmAmfSmoothing();
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
            m_smoothObj = false;
            m_smoothLevel = -1;
            ParseMesh(xObject["mesh"]);
            m_curObject.m_fullname = m_filepath;
            m_curObject.Name = Path.GetFileName(m_filepath);
            m_curObject.Update();
            //m_curObject.m_wireframe = true;
            m_objList.Add(m_curObject);
            m_nobjects++;
        }

        void ParseMesh(XmlNode xMesh)
        {
            ReadVertices(xMesh["vertices"]);
            if (m_smoothObj && (m_smoothLevel == -1))
            {
                if (m_formSmooth.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    m_smoothLevel = m_formSmooth.SmoothLevel;
                }
            }
            ReadVolume(xMesh["volume"]);
        }

        void ReadVertices(XmlNode xVerts)
        {
            m_pointList = new List<PointAmf>();
            m_edgeList = new List<EdgeAmf>();
            foreach (XmlNode xnode in xVerts.ChildNodes)
            {
                if (xnode.Name == "vertex")
                    ParseVertex(xnode);
                if (xnode.Name == "edge")
                    ParseEdge(xnode);
            }
            // link edges to points
            foreach (EdgeAmf edge in m_edgeList)
            {
                m_pointList[edge.v1].AddEdge(edge);
            }
            m_edgeList = null; // we no longer need it
        }

        void ParseVertex(XmlNode xVert)
        {
            XmlNode xcoor = xVert["coordinates"];
            float x = float.Parse(xcoor["x"].InnerText) * m_scaleFactor;
            float y = float.Parse(xcoor["y"].InnerText) * m_scaleFactor;
            float z = float.Parse(xcoor["z"].InnerText) * m_scaleFactor;
            Point3d pt = new Point3d(x, y, z);
            PointAmf pamf= new PointAmf();
            pamf.pt = pt;

            // add normal if exists
            XmlNode xnorm = xVert["normal"];
            if (xnorm != null)
            {
                m_smoothObj = true;
                x = float.Parse(xnorm["nx"].InnerText);
                y = float.Parse(xnorm["ny"].InnerText);
                z = float.Parse(xnorm["nz"].InnerText);
                pamf.normal = new Vector3d(x, y, z);
            }

            m_pointList.Add(pamf);
        }

        void ParseEdge(XmlNode xEdge)
        {
            EdgeAmf edge = new EdgeAmf();
            edge.v1 = int.Parse(xEdge["v1"].InnerText);
            float x = float.Parse(xEdge["dx1"].InnerText) * m_scaleFactor;
            float y = float.Parse(xEdge["dy1"].InnerText) * m_scaleFactor;
            float z = float.Parse(xEdge["dz1"].InnerText) * m_scaleFactor;
            edge.t1 = new Vector3d(x, y, z);
            edge.v2 = int.Parse(xEdge["v2"].InnerText);
            x = float.Parse(xEdge["dx2"].InnerText) * m_scaleFactor;
            y = float.Parse(xEdge["dy2"].InnerText) * m_scaleFactor;
            z = float.Parse(xEdge["dz2"].InnerText) * m_scaleFactor;
            edge.t2 = new Vector3d(x, y, z);
            m_edgeList.Add(edge);
            m_smoothObj = true;
        }

        void ReadVolume(XmlNode xVolume)
        {
            m_curObject = new Object3d();
            m_curObject.m_lstpoints = new List<Point3d>();
            foreach (XmlNode xnode in xVolume.ChildNodes)
            {
                if (xnode.Name == "triangle")
                    ParseTriangle(xnode);
            }
            foreach (PointAmf pamf in m_pointList)
                m_curObject.m_lstpoints.Add(pamf.pt);
        }

        void ParseTriangle(XmlNode xTri)
        {
            int p0 = int.Parse(xTri["v1"].InnerText);
            int p1 = int.Parse(xTri["v2"].InnerText);
            int p2 = int.Parse(xTri["v3"].InnerText);
            int level = m_smoothObj ? m_smoothLevel : 0;
            SmoothTriangle(p0, p1, p2, level);
        }
        
        void SmoothTriangle(int v1, int v2, int v3, int level)
        {
            if (level == 0)
            {
                // end smooth level, return the resulting triangle
                Point3d pt1 = m_pointList[v1].pt;
                Point3d pt2 = m_pointList[v2].pt;
                Point3d pt3 = m_pointList[v3].pt;
                Polygon p = new Polygon();
                p.m_points = new Point3d[] { pt1, pt2, pt3 };
                // calculate normal
                Vector3d edge1 = new Vector3d(pt1.x - pt2.x, pt1.y - pt2.y, pt1.z - pt2.z);
                Vector3d edge2 = new Vector3d(pt3.x - pt2.x, pt3.y - pt2.y, pt3.z - pt2.z);
                p.m_normal = Vector3d.cross(edge1, edge2);
                p.m_normal.Normalize();
                m_curObject.m_lstpolys.Add(p);
                return;
            }

            // do smooth
            level--;
            int v12 = SplitEdge(v1, v2);
            int v23 = SplitEdge(v2, v3);
            int v31 = SplitEdge(v3, v1);
            SmoothTriangle(v1, v12, v31, level);
            SmoothTriangle(v12, v2, v23, level);
            SmoothTriangle(v23, v3, v31, level);
            SmoothTriangle(v12, v23, v31, level);
        }

        int SplitEdge(int v1, int v2)
        {
            Vector3d t1, t2;
            PointAmf pamf1 = m_pointList[v1];
            PointAmf pamf2 = m_pointList[v2];
            Point3d pt1 = pamf1.pt;
            Point3d pt2 = pamf2.pt;
            PointAmf pamf;
            float x, y, z;

            // calculate edge vector
            x = pt2.x - pt1.x;
            y = pt2.y - pt1.y;
            z = pt2.z - pt1.z;
            Vector3d edgeDir = new Vector3d(x, y, z);
            float d = Vector3d.length(edgeDir);

            // first see if we have an edge for this segment
            EdgeAmf edge = FindEdge(v1, v2);
            if (edge != null)
            {
                // if this edge was already split, return result
                if (edge.v12 >= 0)
                    return edge.v12;
                t1 = edge.t1;
                t2 = edge.t2;
            }
            else if ((pamf1.normal == null) && (pamf2.normal == null))
            {
                // its a linear line, return the center
                x = (pamf1.pt.x + pamf2.pt.x) / 2.0f;
                y = (pamf1.pt.y + pamf2.pt.y) / 2.0f;
                z = (pamf1.pt.z + pamf2.pt.z) / 2.0f;
                pamf = new PointAmf();
                pamf.pt = new Point3d(x, y, z);
                m_pointList.Add(pamf);
                return m_pointList.Count - 1;
            }
            else
            {
                // calculate tangets from normals.
                //edgeDir.Normalize();
                t1 = GetTangetFromNormal(pamf1.normal, edgeDir) * d;
                t2 = GetTangetFromNormal(pamf2.normal, edgeDir) * d;
            }

            // calculate mid point using Hermite interpolation
            x = 0.5f * pt1.x + 0.125f * t1.x + 0.5f * pt2.x - 0.125f * t2.x;
            y = 0.5f * pt1.y + 0.125f * t1.y + 0.5f * pt2.y - 0.125f * t2.y;
            z = 0.5f * pt1.z + 0.125f * t1.z + 0.5f * pt2.z - 0.125f * t2.z;

            pamf = new PointAmf();
            pamf.pt = new Point3d(x, y, z);
            int v = m_pointList.Count;
            m_pointList.Add(pamf);

            // calculate new tanget and new normal
            x = -1.5f * pt1.x - 0.25f * t1.x + 1.5f * pt2.x - 0.25f * t2.x;
            y = -1.5f * pt1.y - 0.25f * t1.y + 1.5f * pt2.y - 0.25f * t2.y;
            z = -1.5f * pt1.z - 0.25f * t1.z + 1.5f * pt2.z - 0.25f * t2.z;
            Vector3d tanget = new Vector3d(x, y, z);
            pamf.normal = GetNormalFromTanget(tanget, t2);

            if (edge == null)
            {
                // create a simple edge just to remember center point. saves some computation
                // for the next triangle using that edge
                edge = new EdgeAmf();
                edge.v1 = v1;
                edge.v2 = v2;
                pamf1.AddEdge(edge);
            }
            else
            {
                /*
                //tanget.Normalize();
                // save 2 split edges
                EdgeAmf edge1 = new EdgeAmf();
                edge1.v1 = v1;
                edge1.v2 = v;
                edge1.t1 = t1;
                edge1.t2 = tanget;
                pamf1.AddEdge(edge1);

                EdgeAmf edge2 = new EdgeAmf();
                edge2.v1 = v;
                edge2.v2 = v2;
                edge2.t1 = tanget;
                edge2.t2 = t2;
                pamf.AddEdge(edge2);
                 * */
            }
            edge.v12 = m_pointList.Count - 1; // save double computation

            return v;
        }

        Vector3d GetTangetFromNormal(Vector3d norm, Vector3d dir)
        {
            Vector3d res;
            if (norm == null)
            {
                res = dir.clone();
            }
            else
            {
                Vector3d normxdir = Vector3d.cross(norm, dir);
                res = Vector3d.cross(normxdir, norm);
            }
            if ((Math.Abs(res.x) < Epsilon) && (Math.Abs(res.y) < Epsilon) && (Math.Abs(res.z) < Epsilon))
                return null;

            res.Normalize();
            return res;
        }

        Vector3d GetNormalFromTanget(Vector3d tanget, Vector3d dir)
        {
            Vector3d norm = GetTangetFromNormal(tanget, dir);
            if (norm == null)
                return null;
            norm.x = -norm.x;
            norm.y = -norm.y;
            norm.z = -norm.z;
            return norm;
        }

        EdgeAmf FindEdge(int v1, int v2)
        {
            EdgeAmf edge = m_pointList[v1].FindEdge(v2);
            if (edge != null)
                return edge;
            return m_pointList[v2].FindEdge(v1);
        }
    }
}
