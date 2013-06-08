using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapEditor
{
    public enum TriggerType
    {
        NONE = -1,
        CHANGE_MAP = 0,
        SPAWN_MOB = 1
    }
    public abstract class Trigger
    {
        private static TriggerType type;

        public static TriggerType Type { get { return type; } protected set { if (type == TriggerType.NONE) type = value; } }



        public string ToString(Point point)
        {
            return String.Format("{0} {1} {2} {3}", (int)type, point.X, point.Y, ParamsToString());
        }

        protected abstract string ParamsToString();

        public override string ToString()
        {
            return String.Format("{0} {1}", type, ParamsToString());
        }
        
    }
}
