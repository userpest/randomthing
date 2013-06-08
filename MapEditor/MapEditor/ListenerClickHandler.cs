using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public class ListenerClickHandler: ClickHandler
    {
        private static ListenerClickHandler instance;
        public static ListenerClickHandler Insance { get { return instance; } }
        private ListenerClickHandler() { }
        static ListenerClickHandler() { instance = new ListenerClickHandler(); }
        public IClickListener Listener;

        public override void Selection(System.Drawing.Rectangle r)
        {
            
        }
        public override void Click(System.Drawing.Point p)
        {
            Listener.OnClick(p);
            MapEditor.Instance.SendToBack();
        }
    }
}
