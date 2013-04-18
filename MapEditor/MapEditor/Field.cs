using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    class Field
    {
        public const int SIZE = 32;
        List<Trigger> triggers;
        //Description wtf
        public int R, G, B;

        public Field()
        {
            
        }
        public Field(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
