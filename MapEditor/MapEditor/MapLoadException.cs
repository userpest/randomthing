using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public class MapLoadException:Exception
    {

        public MapLoadException() : base() { }
        public MapLoadException(string message) : base(message) { }
        public MapLoadException(string message, Exception inner) : base(message, inner) { }
    }
}
