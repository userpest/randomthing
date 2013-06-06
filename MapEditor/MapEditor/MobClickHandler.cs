using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public class MobClickHandler:ClickHandler
    {
        private static MobClickHandler instance;

        public static MobClickHandler Instance { get { return instance; } }
        private MobClickHandler()
        {        }
        static MobClickHandler()
        {
            instance = new MobClickHandler();
        }

        public Creature prototype;

        public override void Selection(System.Drawing.Rectangle r)
        {
            
        }
        public override void Click(System.Drawing.Point p)
        {
            Creature creature = new Creature(p, prototype.Avatar, prototype.Name);
            EditorEngine.Instance.CreaturesManager.AddCreature(creature);
        }

    }
}
