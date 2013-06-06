using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapEditor
{
    class Utils
    {
        private static int calcSize(int dimSize)
        {
            int size = 2;
            while (size < dimSize)
                size = size * 2;
            return (size / 2 + size) / 2 < dimSize ? size : size / 2;
        }

        public static Bitmap InteligentResize(Bitmap bmp)
        {
            int width = calcSize(bmp.Width);
            int height = calcSize(bmp.Height);


            Bitmap result = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(result);
            g.DrawImage(bmp, new Rectangle(0, 0, width, height));
            return result;

        }
        public static Point PointToOpengl(Point p)
        {
            return new Point(p.X, -p.Y + (int)EditorEngine.Instance.Camera.Height - 1);
        }

    }
}
