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
        public MoveToNextMapTrigger(Point spawnLocation)
        {
            SpawnLocation = spawnLocation;
            Type = TriggerType.CHANGE_MAP;
        }
        protected override string ParamsToString()
        {
            return String.Format("{0} {1}", SpawnLocation.X, SpawnLocation.Y);
        }
    }
}
