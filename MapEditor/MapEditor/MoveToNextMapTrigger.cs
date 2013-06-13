using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapEditor
{
    public class MoveToNextMapTrigger:Trigger
    {
        public Point SpawnLocation;
        public string mapName;
        public MoveToNextMapTrigger(Point spawnLocation, String MapName)
        {
            SpawnLocation = spawnLocation;
            mapName = MapName;
            Type = TriggerType.CHANGE_MAP;
        }
        protected override string ParamsToString()
        {
            return String.Format("{0} {1} {2}", SpawnLocation.X*Field.SIZE, SpawnLocation.Y*Field.SIZE, mapName);
        }
    }
}
