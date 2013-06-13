using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace MapEditor
{
    public class CreaturesManager
    {
        Dictionary<string,Creature> prototypes;
        List<Creature> creatures;
        private string creaturesfile = "creatures.txt";
        private string creaturesfolder = "creatures";
        private string avatar = "avatar.png";

        public Dictionary<string, Creature> Prototypes { get { return prototypes; } }

        public CreaturesManager()
        {
            creatures = new List<Creature>();
        }
        public void Load()
        {
            creatures = new List<Creature>();
            if (!File.Exists(Path.Combine(EditorEngine.Instance.Map.mapfolder, creaturesfile)))
                return;
            using (StreamReader sr = new StreamReader(Path.Combine(EditorEngine.Instance.Map.mapfolder,creaturesfile)))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split= line.Split(' ');
                    int x = Convert.ToInt32(split[0])/Field.SIZE;
                    int y = Convert.ToInt32(split[1])/Field.SIZE;
                    string name = split[2];
                    creatures.Add(new Creature(new System.Drawing.Point(x, y), prototypes[name].Avatar,name));
                }
            }
            
        }
        public void LoadPrototypes(string mapfolder)
        {
            string bp = Path.Combine(Application.StartupPath,creaturesfolder);
            prototypes = new Dictionary<string, Creature>();
            foreach(string mob in Directory.GetDirectories(bp))
            {
                AddPrototype(mob,true);
            }
            if (!String.IsNullOrEmpty(mapfolder) && false)
            {
                
                foreach (string dir in Directory.GetDirectories(Path.Combine(mapfolder, creaturesfolder)))
                {
                    AddPrototype(dir, false);
                }
            }
            foreach (KeyValuePair<string, Creature> pair in prototypes)
            {
                pair.Value.LoadAvatar();
            }       
           
        }
        public void AddPrototype(string path,bool isbase)
        {
            string name =Path.GetFileName(path);
            Texture t = new Texture(name.GetHashCode(), 0, Path.Combine(path,avatar), isbase);
            prototypes[name] = new Creature(new System.Drawing.Point(0, 0), t,name);
            prototypes[name].Path = path;
        }

        public void AddCreature(Creature creature)
        {
            creatures.Add(creature);
        }

        public void Update()
        {
            foreach(Creature cr in creatures)
            {
                EditorEngine.Instance.Map.GetField(cr.Location.X, cr.Location.Y).Draw(cr.Location.X, cr.Location.Y, cr.Avatar);
            }
        }

        public void Save(string name)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(name, creaturesfile)))
            {
                foreach (Creature cr in creatures)
                {
                    sw.WriteLine(String.Format("{0} {1} {2}", cr.Location.X*Field.SIZE, cr.Location.Y*Field.SIZE, cr.Name));
                }
            }
            Directory.CreateDirectory(Path.Combine(name, creaturesfolder));
            foreach (Creature cr in prototypes.Values)
            {
                string dest = Path.Combine(name, creaturesfolder, cr.Name);
               
                if (!cr.Basic && !cr.Path.Equals(dest))
                {
                    if (Directory.Exists(dest))
                    {
                        Directory.Delete(dest, true);
                    }
                    Utils.DirectoryCopy(cr.Path, dest, true);
                }
            }
        }

        public void AddPrototypeWithLoad(string path, bool isbase)
        {
            
            string name = Path.GetFileName(path);
            if (prototypes.ContainsKey(name))
            {
                prototypes[name].Remove();
            }
            Texture t = new Texture(name.GetHashCode(), 0, Path.Combine(path, avatar), isbase);
            t.Load();
            prototypes[name] = new Creature(new System.Drawing.Point(0, 0), t, name);
            prototypes[name].Path = path;
            
        }

        public bool ExistCreatureInField(Point p)
        {
            foreach (Creature cr in creatures)
            {
                if (cr.Location.Equals(p)) return true;
            }
            return false;
        }

        public void RemoveCreature(Point p)
        {
            for (int i = 0; i < creatures.Count; i++)
            {
                if (creatures[i].Location.Equals(p))
                {
                    creatures.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
