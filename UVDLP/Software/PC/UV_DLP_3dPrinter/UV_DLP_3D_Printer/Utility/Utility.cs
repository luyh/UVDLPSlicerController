using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;
namespace UV_DLP_3D_Printer
{
    public static class Utility
    {
        public static bool CreateDirectory(String path) 
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception ) 
            {
                return false;
            }
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public static Stream ReadFromZip(string zipname, string zipentryname) 
        {
            try
            {
                ZipFile zip = ZipFile.Read(zipname);
                ZipEntry ze = zip[zipentryname];
                Stream stream = new MemoryStream();
                ze.Extract(stream);
                return stream;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
                return null;
            }
        
        }
        public static bool StoreInZip(string zipname, string zipentryname, Stream stream) 
        {            
            try
            {
                ZipFile zip = ZipFile.Read(zipname);                
                zip.AddEntry(zipentryname, stream);
                zip.Save();
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
        }
    }
}
