using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor
{
    public class MouseController
    {
        public event MouseEventHandler MouseMoved;
        Point rightDown;
        Point rightUp;
        Point rightTarget;
        Point rightActual;
        Point rightLast;
        Point leftDown;
        Point leftUp;
        bool isLeftDown;
        public bool isRightDown;
        public bool rightMoveHandled;
        Point position;
        private int tollerancy = 3;

        public Point Position { get { return position; } }


        private Point PointToOpengl(Point p)
        {
            return new Point(p.X, -p.Y+(int)EditorEngine.Instance.Camera.Height-1);
        }

        public void Update()
        {
            if (isRightDown && !rightMoveHandled)
                handleMoveRight();

        }

        private void handleMoveRight()
        {
            int x = rightLast.X - position.X;
            int y = rightLast.Y - position.Y;
            //EditorEngine.Instance.Camera.SlowMove(x, y);
            EditorEngine.Instance.Camera.Move(-x, -y);
            rightLast = position;
            rightMoveHandled = true;
        }

        public void MouseMove(MouseEventArgs e)
        {
            position = PointToOpengl(e.Location);
            if (MouseMoved != null){
                e = new MouseEventArgs(e.Button, e.Clicks, position.X, position.Y, e.Delta);
                MouseMoved(this,e) ;
            }
            if (isRightDown)
                rightMoveHandled = false;
        }

        
        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isLeftDown)
                {
                    if (EditorEngine.Instance.ClickHandler != null)
                    {
                        Point click = PointToOpengl(e.Location);
                        if (Math.Abs(click.X - leftDown.X) < tollerancy && Math.Abs(click.Y - leftDown.Y) < tollerancy)
                        {
                            EditorEngine.Instance.ClickHandler.Click(EditorEngine.Instance.Map.FieldPoint((click.X + leftDown.X) / 2, (click.Y + leftDown.Y) / 2));
                        }
                        else
                        {
                            EditorEngine.Instance.ClickHandler.Selection(EditorEngine.Instance.Map.Rectangle(leftDown, click));
                        }
                    }
                    isLeftDown = false;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                rightUp = PointToOpengl(e.Location);
                isRightDown = false;
            }
        }
        public void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftDown = PointToOpengl(e.Location);
                isLeftDown = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                rightDown = PointToOpengl(e.Location);
                isRightDown = true;
                rightMoveHandled = false;
                rightLast = rightDown;
            }
        }
        public void MouseLeave(EventArgs e)
        {
            isRightDown = false;
            isLeftDown = false;
        }
       
    }
}
