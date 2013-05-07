using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace MapEditor
{
    public class Field
    {
        public const int SIZE = 32;
        List<Trigger> triggers;
        Texture texture;
        bool colisable;
        //Description wtf
        public Texture Texture { get { return texture; } set { texture = value; } }
        static float[] textCoord = {
			0.0f,0.0f,
			1.0f,0.0f,
			1.0f,1.0f,
			1.0f,0.0f
		};

        public Field(Texture texture, bool colisable)
        {
            this.texture = texture;
            this.colisable = colisable;
        }

        public void Draw(float x, float y)
        {
            this.Draw(x, y, texture);       
        }
        public void Draw(float x, float y, Texture t)
        {
            GL.BindTexture(TextureTarget.Texture2D, t.TextureName);
            x *= SIZE;
            y *= SIZE;
            GL.Begin(BeginMode.Quads);
            GL.PushMatrix();

            int i = 0;
            GL.TexCoord2(0, 0);
            GL.Vertex2(x, y);
            GL.TexCoord2(0, 1);
            GL.Vertex2(x, y + SIZE);
            GL.TexCoord2(1, 1);
            GL.Vertex2(x + SIZE, y + SIZE);
            GL.TexCoord2(1, 0);
            GL.Vertex2(x + SIZE, y);
            GL.End();
            GL.PopMatrix();

        }

        public static int LoadTexture(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(filename);
            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);

            bmp.UnlockBits(bmp_data);

            // We haven't uploaded mipmaps, so disable mipmapping (otherwise the texture will not appear).
            // On newer video cards, we can use GL.GenerateMipmaps() or GL.Ext.GenerateMipmaps() to create
            // mipmaps automatically. In that case, use TextureMinFilter.LinearMipmapLinear to enable them.
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return id;
        }
    }
}
