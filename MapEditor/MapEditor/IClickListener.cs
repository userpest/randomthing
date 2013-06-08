using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public interface IClickListener
    {
        void OnClick(System.Drawing.Point location);
    }
}
