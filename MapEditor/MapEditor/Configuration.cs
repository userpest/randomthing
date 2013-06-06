using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public class Configuration
    {
        

        private static Configuration instance;
        public static Configuration Instance { get { return instance; } }
        static Configuration() { instance = new Configuration(); }


        private Configuration()
        {
            

        }

        public ClickHandler GetStartClickHandler()
        {
            return StartPositionClickHandler.Instance;
        }
        public ClickHandler GetClickHandlerTile(Texture text)
        {
            ClickHandlerTileCreator.Instance.Texture = text;
            return ClickHandlerTileCreator.Instance;
        }

        public ClickHandler GetClickHandlerCreature(Creature cr)
        {
            MobClickHandler.Instance.prototype = cr;
            return MobClickHandler.Instance;
        }
        public ClickHandler GetClickListenerHandler(IClickListener listener)
        {
            ListenerClickHandler.Insance.Listener = listener;
            return ListenerClickHandler.Insance;
        }
    }
}
