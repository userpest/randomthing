using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{

    public class MapLoadingStateStartPoint : Map.MapLoadingState
    {
        private static MapLoadingStateStartPoint instance;
        public static MapLoadingStateStartPoint Instance { get { return instance; } }
        private MapLoadingStateStartPoint() { }
        static MapLoadingStateStartPoint() { instance = new MapLoadingStateStartPoint(); }

        public override void Load(string[] line, Map map)
        {
            if (line.Length != 2) ThrowLoadException();
            SetStartPoint(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]), map);
            ChangeState(map, MapLoadingStateFields.Instance);
        }
    }
    
}
