using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapEditor
{
    public class SpawnMobTrigger:Trigger
    {
        public int ActivactionCount;
        public int Cooldown;
        public string Enemy;
        public Point SpawnLocation;


        public SpawnMobTrigger(int activactionCount, int cooldown, string enemy, Point spawnLocation)
        {
            ActivactionCount = activactionCount;
            Cooldown = cooldown;
            Enemy = enemy;
            SpawnLocation = spawnLocation;
            Type = TriggerType.SPAWN_MOB;
        }

        protected override string ParamsToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", ActivactionCount, Cooldown, Enemy, SpawnLocation.X*Field.SIZE, SpawnLocation.Y*Field.SIZE);
        }
    }
}
