using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
//using System.Drawing.Imaging;
using Engine3D;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;

namespace UV_DLP_3D_Printer._3DEngine
{
    class C2DImage
    {
        public String name;
        public float x1, x2;
        public float y1, y2;
        public int w;
        public int h;
        public float scalex, scaley;
        public int tex;
    }

    public class C2DGraphics
    {
        Dictionary<String, C2DImage> ImgDbase;
        int mWidth, mHeight;
        OpenTK.Matrix4 m_ortho;
        OpenTK.Matrix4 m_2dView;

        public C2DGraphics()
        {
            ImgDbase = new Dictionary<String, C2DImage>();
            m_2dView = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(0, 0, 10), new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector3(0, 1, 0));
         }

        public void SetupViewport(int w, int h)
        {
            mWidth = w;
            mHeight = h;
            m_ortho = OpenTK.Matrix4.CreateOrthographicOffCenter(0, w, h, 0, 1, 2000);
            GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            GL.LoadMatrix(ref m_ortho);
            GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
            GL.LoadMatrix(ref m_2dView);
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.DepthTest);
            GL.CullFace(CullFaceMode.Front); // the 2d view is reverse looking             
        }

        public void SetDrawingRegion(int x, int y, int w, int h)
        {
            GL.Flush();
            m_ortho = OpenTK.Matrix4.CreateOrthographicOffCenter(-x, mWidth - x, mHeight - y, -y, 1, 2000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref m_ortho);
            GL.Scissor(x, mHeight - y - h, w, h);
            GL.Enable(EnableCap.ScissorTest);
        }

        public void ResetDrawingRegion()
        {
            GL.Flush();
            m_ortho = OpenTK.Matrix4.CreateOrthographicOffCenter(0, mWidth, mHeight, 0, 1, 2000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref m_ortho);
            GL.Disable(EnableCap.ScissorTest);
        }


        public void Rectangle(float x, float y, float w, float h, Color col)
        {
            //GL.Begin(BeginMode.Quads);
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(col);
            GL.Vertex3(x, y, 0);
            GL.Vertex3(x + w, y, 0);
            GL.Vertex3(x + w, y + h, 0);
            GL.Vertex3(x, y + h, 0);
            GL.End();
        }

        public void GradientRect(float x, float y, float w, float h, Color coltl, Color coltr, Color colbl, Color colbr)
        {
            //GL.Begin(BeginMode.Quads);
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(coltl);
            GL.Vertex3(x, y, 0);
            GL.Color4(coltr);
            GL.Vertex3(x + w, y, 0);
            GL.Color4(colbr);
            GL.Vertex3(x + w, y + h, 0);
            GL.Color4(colbl);
            GL.Vertex3(x, y + h, 0);
            GL.End();
        }

        public int LoadTextureImage(Bitmap image)
        {
            //Bitmap bitmap = global::UV_DLP_3D_Printer.Properties.Resources.butMinus;

            System.Drawing.Imaging.BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int tex = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            image.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return tex;
        }

        public void LoadTexture(Bitmap image, string index)
        {
            float tw = image.Width;
            float th = image.Height;
            int tex = LoadTextureImage(image);
            //StreamReader sr = new StreamReader(index);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(index));
            StreamReader sr = new StreamReader(ms);
            bool datasection = false;
            C2DImage img = null;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.StartsWith("repeat:"))
                {
                    datasection = true;
                    continue;
                }
                if (!datasection)
                    continue;
                if (line[0] != ' ')
                {
                    // a new image
                    img = new C2DImage();
                    img.name = line.Trim();
                    img.tex = tex;
                    img.scalex = tw;
                    img.scaley = th;
                    ImgDbase[img.name] = img;
                    continue;
                }
                // a parameter
                string[] tokens = line.Trim().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "xy:":
                        img.x1 = float.Parse(tokens[1]) / tw;
                        img.y1 = float.Parse(tokens[2]) / th;
                        break;

                    case "size:":
                        img.w = int.Parse(tokens[1]);
                        img.h = int.Parse(tokens[2]);
                        img.x2 = img.x1 + (float)img.w / tw;
                        img.y2 = img.y1 + (float)img.h / th;
                        break;
                }
            }
        }


        public void Image(int tex, float x1, float x2, float y1, float y2, float dx, float dy, float dw, float dh)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            //GL.Begin(BeginMode.Quads);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(x1, y1);
            GL.Vertex3(dx, dy, 0);
            GL.TexCoord2(x2, y1);
            GL.Vertex3(dx + dw, dy, 0);
            GL.TexCoord2(x2, y2);
            GL.Vertex3(dx + dw, dy + dh, 0);
            GL.TexCoord2(x1, y2);
            GL.Vertex3(dx, dy + dh, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }

        public void Image(String name, float x, float y)
        {
            if (ImgDbase.ContainsKey(name))
            {
                C2DImage img = ImgDbase[name];
                Image(img.tex, img.x1, img.x2, img.y1, img.y2, x, y, img.w, img.h);
            }
        }

        public void GetImageDim(String name, ref int w, ref int h)
        {
            if (name == null)
                return;
            if (ImgDbase.ContainsKey(name))
            {
                C2DImage img = ImgDbase[name];
                w = img.w;
                h = img.h;
            }
            else
            {
                w = 0;
                h = 0;
            }
        }

        public void Panel9(String name, float x, float y, float w, float h)
        {
            if (name == null)
                return;
            if (!ImgDbase.ContainsKey(name))
                return;

            C2DImage img = ImgDbase[name];
            float x3 = img.w / 3;
            float x4 = img.w - x3;
            if ((x4 + x3) > w)
                x3 = x4 = w/2;            
            float y3 = img.h / 3;
            float y4 = img.h - x3;
            if ((y4 + y3) > h)
                y3 = y4 = h/2;
            float sx3 = img.x1 + x3/img.scalex;
            float sx4 = img.x1 + x4/img.scalex;
            float sy3 = img.y1 + y3/img.scaley;
            float sy4 = img.y1 + y4/img.scaley;
            // draw corners
            Image(img.tex, img.x1, sx3, img.y1, sy3, x, y, x3, y3);
            Image(img.tex, sx4, img.x2, img.y1, sy3, x + w - x3, y, x3, y3);
            Image(img.tex, img.x1, sx3, sy4, img.y2, x, y + h - y3, x3, y3);
            Image(img.tex, sx4, img.x2, sy4, img.y2, x + w - x3, y + h - y3, x3, y3);
            // draw top and bottom bar
            if (x3 < x4)
            {
                Image(img.tex, sx3, sx4, img.y1, sy3, x + x3, y, w - 2 * x3, y3);
                Image(img.tex, sx3, sx4, sy4, img.y2, x + x3, y + h - y3, w - 2 * x3, y3);
            }

            // draw center bar
            if (y3 < y4)
            {
                Image(img.tex, img.x1, img.x2, sy3, sy4, x, y + y3, w, h - 2 * y3);
            }
        }

        public void DeleteTexture(int tex)
        {
            GL.DeleteTexture(tex);
        }

        public void SetColor(Color col)
        {
            GL.Color4(col);
        }
    }
}
