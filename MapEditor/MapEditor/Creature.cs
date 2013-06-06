using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapEditor
{
    public class Creature
    {
        public Texture Avatar;
        public Point Location;
        public string Name;

        public Creature(Point Location, Texture Avatar, string name)
        {
            this.Avatar = Avatar;
            this.Location = Location;
            this.Name = name;
        }

        public void LoadAvatar()
        {
            try
            {
                Avatar.Load();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
