using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public class StartPositionClickHandler:ClickHandler
    {
        private  static StartPositionClickHandler instance;
        public  static StartPositionClickHandler Instance { get { return instance; } }
        private StartPositionClickHandler() { }
        static StartPositionClickHandler() { instance = new StartPositionClickHandler(); }

        public override void Selection(System.Drawing.Rectangle r)
        {
            
        }
        public override void Click(System.Drawing.Point p)
        {
            if (EditorEngine.Instance.Initialized)
            {
                EditorEngine.Instance.Map.StartPosition = p;
            }
        }
    }
}
