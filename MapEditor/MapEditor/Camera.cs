using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace MapEditor
{
    public class Camera
    {
        private double scale = 1.0;
        private double x;
        private double y;
        private double width;
        private double height;
        private double centerX;
        private double centerY;

        public double Scale { get { return scale; } set { scale = value; controlBorder(); } }
        public double Distance { get { return scale; } set { scale = value; controlBorder(); } } //synonim

        public Double X { get { return x; } set { x = value; } }
        public Double Y { get { return Y; } set { y = value; } }
        public double Widht { get { return width; } set { width = value; controlBorder(); } }
        public double Height { get { return height; } set { height = value; controlBorder(); } }
        public double CenterX { get { return x + 0.5 * width; } set { x = value - 0.5 * width; } }
        public double CenterY { get { return y + 0.5 * height; } set { y = value - 0.5 * height; } }
        public PointF Point
        {
            get
            {
                return new PointF(Convert.ToSingle(x), Convert.ToSingle(y));
            }
            set
            {
                x = value.X;
                y = value.Y;
            }
        }
        public PointF PointCenter
        {
            get
            {
                return new PointF(Convert.ToSingle(centerX), Convert.ToSingle(centerY));
            }
            set
            {
                centerX = value.X;
                centerY = value.Y;
            }
        }
        public Camera()
        {
            x = 0;
            y = 0;
        }
        private void controlBorder()
        {
            if (x < 0) x = 0.0;
            if (x + width * scale > EditorEngine.Instance.Map.RealWidth) x = EditorEngine.Instance.Map.RealWidth - width * scale;
            if (y < 0) y = 0.0;
            if (y + height * scale > EditorEngine.Instance.Map.RealHeight) y = EditorEngine.Instance.Map.RealHeight - height * scale;
        }
        public void Move(double x, double y)
        {
            x+=x;
            y+=y;
            controlBorder();
        }
        /// <summary>
        /// To invoke in first faze
        /// </summary>
        public void Set()
        {
            GL.Ortho(0, width, 0, height, -1, 1);
            GL.Viewport(0, 0, Convert.ToInt32(width), Convert.ToInt32(height));           
        }

        /// <summary>
        /// To invoke in second faze
        /// </summary>
        public void Look()
        {
            GL.Scale(scale, scale, 1.0);
            GL.Translate(x, y, 0);
        }
        public RectangleF GetCameraRectangle()
        {
            return new RectangleF(0, 0, (float)width , (float)height);
        }
    }
}
