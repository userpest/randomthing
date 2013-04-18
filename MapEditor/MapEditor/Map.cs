using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace MapEditor
{
    public class Map
    {

        private const int DEFAULT_WIDTH = 100;
        private const int DEFAULT_HEIGHT = 100;

        Field[][] fields;

        public int Width;
        public int Height;
        public double RealWidth;
        public double RealHeight;

        public Map()
            :this(DEFAULT_WIDTH,DEFAULT_HEIGHT)
        {
            
        }
        public Map(int width, int height)
        {
            fields = new Field[width][];
            for (int i = 0; i < width; i++)
            {
                fields[i] = new Field[height];
                //
                for (int j = 0; j < height; j++)
                {
                    fields[i][j] = new Field(
                        i < 2 || i > 4 ? 1 : 0, 0, 0);
                }
                //
            }
        }
        public Map(string name)
        {

        }

        public void Save(string name)
        {
        }
        public void Update()
        {
            RectangleF r = EditorEngine.Instance.Camera.GetCameraRectangle();
            Rectangle scaled = new Rectangle(
                (int)r.X / Field.SIZE,
                (int)r.Y / Field.SIZE,
                (int)r.Width / Field.SIZE + 1,
                (int)r.Height / Field.SIZE + 1);
            //if (scaled.X + scaled.Width >= Width) scaled.Width--;
            //if (scaled.Y + scaled.Height >= Height) scaled.Height--;

            for (int i = scaled.X; i < scaled.X + scaled.Width; i++)
            {
                for (int j = scaled.Y; j < scaled.Y + scaled.Height; j++)
                {
                    
                    GL.Begin(BeginMode.Polygon);
                    Field f = fields[i][j];
                    GL.Color3(Color.Yellow);
                    GL.Vertex2(i*Field.SIZE, j*Field.SIZE);
                    GL.Vertex2(i * Field.SIZE + Field.SIZE, j * Field.SIZE);
                    GL.Vertex2(i * Field.SIZE + Field.SIZE, j * Field.SIZE + Field.SIZE);
                    GL.Vertex2(i * Field.SIZE, j * Field.SIZE + Field.SIZE);
                    GL.End();
                     /*
                    GL.Begin(BeginMode.Triangles);
                    GL.Color3(Color.Yellow);
                    GL.Vertex2(i*Field.SIZE, j*Field.SIZE);
                    GL.Vertex2(i * Field.SIZE+Field.SIZE, j * Field.SIZE);
                    GL.Vertex2(i * Field.SIZE + Field.SIZE, j * Field.SIZE + Field.SIZE);
                    GL.End();
                      */
                }
            }
        }

    }
}
