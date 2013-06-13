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
            for (int i = 0; i <= r.Width; i++)
            {
                for (int j = 0; j <= r.Height; j++)
                {
                    Click(new System.Drawing.Point(r.X + i, r.Y + j));
                }
            }
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
