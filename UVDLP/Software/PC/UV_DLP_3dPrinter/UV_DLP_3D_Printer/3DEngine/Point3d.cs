using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Engine3D;
namespace UV_DLP_3D_Printer
{
    public class Point3d
    {
        public double x, y, z;
        public Point3d() 
        {
            x = y = z = 0.0;
        }

        public Point3d(Point3d pnt)
        {
            x = pnt.x;
            y = pnt.y;
            z = pnt.z;
            
        }
        public static Vector3d operator -(Point3d c1, Point3d c2) 
        {
            Vector3d ret = new Vector3d();
            ret.Set(c1.x - c2.x, c1.y - c2.y, c1.z - c2.z,0);
            return ret;
        }
        public bool IsEqual(Point3d pnt) 
        {
            if (x == pnt.x && y == pnt.y && z == pnt.z)
                return true;
            return false;
        }
        public Point3d(double xp, double yp, double zp, double ap)
        {
            Set(xp, yp, zp, ap);
        }
        public void Set(double xp, double yp, double zp,double ap)
        {
            x = xp;
            y = yp;
            z = zp;     
        }

        public void Set(Point3d pnt) 
        {
            Set(pnt.x, pnt.y, pnt.z,0.0);
        }

        public void Load(BinaryReader br) 
        {
            x = br.ReadSingle();
            y = br.ReadSingle();
            z = br.ReadSingle();
        }

        public void Load(StreamReader sr) 
        {
            x = double.Parse(sr.ReadLine());
            y = double.Parse(sr.ReadLine());
            z = double.Parse(sr.ReadLine());
        }
        public void Save(StreamWriter sw) 
        {
            sw.WriteLine(x);
            sw.WriteLine(y);
            sw.WriteLine(z);
        }
    }    
}
