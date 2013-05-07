using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public class ClickHandlerTileCreator:ClickHandler
    {
        public override void Selection(System.Drawing.Rectangle r)
        {
            
        }
        public override void Click(System.Drawing.Point p)
        {
            EditorEngine.Instance.Map.EditFieldTexture(p.X, p.Y, Texture);
        }

        public Texture Texture;
        private static ClickHandlerTileCreator instance;
        public static ClickHandlerTileCreator Instance { get { return instance; } }
        private ClickHandlerTileCreator() { }
        static ClickHandlerTileCreator() { instance = new ClickHandlerTileCreator(); }
    }
}
