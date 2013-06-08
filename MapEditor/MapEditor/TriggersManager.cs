using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace MapEditor
{
    public class TriggersManager
    {
        private static string triggersFile = "triggers.txt";

        public void SaveTriggers(string name)
        {
            string path = Path.Combine(name, triggersFile);
            Map map = EditorEngine.Instance.Map;
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < map.Width; i++)
                {
                    for (int j = 0; j < map.Height; j++)
                    {
                        Field f = map.GetField(i, j);
                        if (f.triggers != null)
                        {
                            foreach (Trigger tr in f.triggers)
                            {
                                sw.WriteLine(tr.ToString(new Point(i, j)));
                            }
                        }
                    }
                }
            }
        }
        public ManageTrigger GetManageTrigger()
        {
            ManageTrigger mt = new ManageTrigger();
            mt.Field = EditorEngine.Instance.LastRightClickedField;            
            return mt;            
        }

        public void LoadTriggers(string mapfolder,Map map)
        {
            try
            {
                string path = Path.Combine(mapfolder, triggersFile);
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] par = sr.ReadLine().Split(' ');
                        Field f = map.GetField(Convert.ToInt32(par[1]), Convert.ToInt32(par[2]));
                        if (f.triggers == null) f.triggers = new List<Trigger>();
                        switch ((TriggerType)(Convert.ToInt32(par[0])))
                        {
                            case TriggerType.CHANGE_MAP:
                                f.triggers.Add(new MoveToNextMapTrigger(new Point(Convert.ToInt32(par[3]), Convert.ToInt32(par[4]))));
                                break;
                            case TriggerType.SPAWN_MOB:
                                f.triggers.Add(new SpawnMobTrigger(
                                    Convert.ToInt32(par[3]),
                                    Convert.ToInt32(par[4]),
                                    par[5],
                                    new Point(Convert.ToInt32(par[6]), Convert.ToInt32(par[7]))));
                                break;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new MapLoadException("Cannot find triggers file");
            }
            catch (Exception ex)
            {
                throw new MapLoadException("Exception during loading triggers", ex);
            }
        }
    }
}
