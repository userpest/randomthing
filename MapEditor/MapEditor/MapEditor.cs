using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace MapEditor
{
   
    public partial class MapEditor : Form
    {

        private static MapEditor instance;
        public static MapEditor Instance { get { return instance; } }

        private bool loaded = false;
        private int x = 0;
        private ImageList il;
        private ImageList creat;
        private int indexImage;
        private int idnexImageCreat;
        
        
        
        public void ListenForClick(IClickListener listener)
        {
            this.BringToFront();
            EditorEngine.Instance.ClickHandler = Configuration.Instance.GetClickListenerHandler(listener);
        }

        static MapEditor()
        {
            instance = new MapEditor();
        }
        private MapEditor()
        {
            
            InitializeComponent();
        }

        private void glControl_ImeModeChanged(object sender, EventArgs e)
        {
            
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            loaded = true;
            EditorEngine.Instance.Associate(glControl);
            EditorEngine.Instance.InitializedEngine += new EventHandler(Instance_InitializedEngine);
            Application.Idle += new EventHandler(Application_Idle);
            EditorEngine.Instance.Initialize();
        }

        void Instance_InitializedEngine(object sender, EventArgs e)
        {
            EditorEngine.Instance.MouseController.MouseMoved += new MouseEventHandler(MouseController_MouseMoved);
            EditorEngine.Instance.MapChanged += new EventHandler(EditoEngine_MapChanged);

        }
        void LoadCreaturesList()
        {
            creat = new ImageList();
            listViewCreatures.Items.Clear();
            int i = 0;
            foreach (KeyValuePair<string, Creature> prot in EditorEngine.Instance.CreaturesManager.Prototypes)
            {
                creat.Images.Add(prot.Value.Avatar.Bmp);
                ListViewItem item = new ListViewItem(prot.Value.Name, i++);
                item.Tag = prot.Value;
                listViewCreatures.Items.Add(item);
            }
            listViewCreatures.LargeImageList = creat;

            idnexImageCreat = i;
        }
        void EditoEngine_MapChanged(object sender, EventArgs e)
        {
            il = new ImageList();
            listViewTiles.Items.Clear();
            int i=0;

            foreach (KeyValuePair<int, Texture> texture in EditorEngine.Instance.Map.textures)
            {
                
                il.Images.Add(texture.Value.Bmp);
                string text = (texture.Value.Basic? "Basic" : "Own");
                ListViewItem item = new ListViewItem(text,i++);
                item.Tag = texture.Value;
                listViewTiles.Items.Add(item);
            }
            listViewTiles.LargeImageList = il;
            indexImage = i;

            LoadCreaturesList();
            EditorEngine.Instance.Map.ShowTriggers = checkBoxShowTriggers.Checked;
        }

        void MouseController_MouseMoved(object sender, MouseEventArgs e)
        {
            if (EditorEngine.Instance.Map == null) return;
            labelX.Text = String.Format("X: {0}", e.X);
            labelY.Text = String.Format("Y: {0}", e.Y);
            Point gamePoint = EditorEngine.Instance.Map.FieldPoint(e.X,e.Y);
            labelGameX.Text = String.Format("Game X: {0}", gamePoint.X);
            labelGameY.Text = String.Format("Game Y: {0}", gamePoint.Y);

        }

        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl.IsIdle)
            {

                EditorEngine.Instance.Update();
            }
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
            EditorEngine.Instance.Initialize();            
            //EditorEngine.Instance.Run();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EditorEngine.Instance.Map.Save(sfd.FileName);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog sfd = new FolderBrowserDialog();

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EditorEngine.Instance.Map = new Map(sfd.SelectedPath);
               
                EditorEngine.Instance.Run();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditorEngine.Instance.Camera.SlowMove(-50.0, -50.0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditorEngine.Instance.Camera.SlowMove(5.0, 10.0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditorEngine.Instance.Initialize();
            EditorEngine.Instance.Map = new Map(@"C:\Users\Kota Morgue\Desktop\anna4");
            EditorEngine.Instance.Run();

        }

       

        private void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (EditorEngine.Instance.Initialized)
                EditorEngine.Instance.MouseController.MouseDown(e);
        }

       

        private void glControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (EditorEngine.Instance.Initialized)
                EditorEngine.Instance.MouseController.MouseUp(e);
        }

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (EditorEngine.Instance.Initialized)
                EditorEngine.Instance.MouseController.MouseMove(e);
        }

        private void glControl_MouseLeave(object sender, EventArgs e)
        {
            if (EditorEngine.Instance.Initialized)
                EditorEngine.Instance.MouseController.MouseLeave(e);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            EditorEngine.Instance.ClickHandler = Configuration.Instance.GetStartClickHandler();
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            listViewTiles.View = View.LargeIcon;
            listViewCreatures.View = View.LargeIcon;
        }

        private void listViewTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Texture text = listViewTiles.SelectedItems[0].Tag as Texture;
            EditorEngine.Instance.ClickHandler = Configuration.Instance.GetClickHandlerTile(text);
        }

        private int getNewId()
        {
            int i = 0;
            foreach (int id in EditorEngine.Instance.Map.textures.Keys)
            {
                if (id > i)
                    i = id;
            }
            return i;
        }

        private void buttonAddTile_Click(object sender, EventArgs e)
        {
            using (AddTile at = new AddTile())
            {
                if (at.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Texture t = new Texture(getNewId()+1, 0, null, false);
                    EditorEngine.Instance.Map.textures[t.IdTexture] = t;
                    t.Bmp = at.picture;
                    t.Load();
                    il.Images.Add(t.Bmp);
                    ListViewItem item = new ListViewItem("Own", indexImage++);
                    item.Tag = t;
                    listViewTiles.Items.Add(item);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewMap nm = new NewMap())
            {
                if (nm.ShowDialog() == DialogResult.OK)
                {
                    Map map = new Map(nm.MapWidth, nm.MapHeight, nm.MapName);
                    EditorEngine.Instance.Map = map;

                    EditorEngine.Instance.Run();
                }
            }
        }

        private void buttonbackgrnd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    EditorEngine.Instance.Map.SetBackground(ofd.FileName);
                }
            }
        }

        private void listViewCreatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            Creature cr = listViewCreatures.SelectedItems[0].Tag as Creature;
            EditorEngine.Instance.ClickHandler = Configuration.Instance.GetClickHandlerCreature(cr);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            triggersToolStripMenuItem.Enabled = EditorEngine.Instance.IsOn;
            
        }

        private void triggersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorEngine.Instance.TriggetManager.GetManageTrigger().Show();
        }

        private void checkBoxShowTriggers_CheckedChanged(object sender, EventArgs e)
        {
            if (EditorEngine.Instance.IsOn)
                EditorEngine.Instance.Map.ShowTriggers = checkBoxShowTriggers.Checked;
        }

        private void buttonAddCreature_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if(fbd.ShowDialog()==DialogResult.OK)
                {
                    EditorEngine.Instance.CreaturesManager.AddPrototypeWithLoad(fbd.SelectedPath,false);
                    LoadCreaturesList();
                }
            }
            
        }
    }
}
