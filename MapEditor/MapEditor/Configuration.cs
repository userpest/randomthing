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
    }
}
