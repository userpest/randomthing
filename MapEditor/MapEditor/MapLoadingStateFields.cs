using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public class MapLoadingStateFields:Map.MapLoadingState
    {
        private static MapLoadingStateFields instance;
        public  static MapLoadingStateFields Instance { get { return instance; } }
        private MapLoadingStateFields() { }
        static MapLoadingStateFields() { instance = new MapLoadingStateFields(); }


        public override void Load(string[] line, Map map)
        {
            if (line.Length < 2) ThrowLoadException();
            for (int i = 0; i < line.Length; i++ )
            {
                int textid = Convert.ToInt32(line[i]);

                CreateField(textid,i,map);                
            }
            
        }
    }
}
