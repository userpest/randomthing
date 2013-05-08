using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public class MapLoadingStateSize:Map.MapLoadingState
    {
        private static MapLoadingStateSize instance;
        public  static MapLoadingStateSize Instance { get { return instance; } }
        private MapLoadingStateSize() { }
        static MapLoadingStateSize() { instance = new MapLoadingStateSize(); }

        public override void Load(string[] line, Map map)
        {
            if (line.Length != 2) ThrowLoadException();
            SetSize(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]), map);
            ChangeState(map, MapLoadingStateStartPoint.Instance);
        }
    }
}
