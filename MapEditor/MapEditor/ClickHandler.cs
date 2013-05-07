using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapEditor
{
    public abstract class ClickHandler
    {
        public abstract void Click(Point p);
        public abstract void Selection(Rectangle r);
    }
}
