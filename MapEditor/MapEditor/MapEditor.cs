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
        private bool loaded = false;
        private int x = 0;
        private ImageList il;
        private int indexImage;

        public MapEditor()
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
        }

        void Instance_InitializedEngine(object sender, EventArgs e)
        {
            EditorEngine.Instance.MouseController.MouseMoved += new MouseEventHandler(MouseController_MouseMoved);
            EditorEngine.Instance.MapChanged += new EventHandler(EditoEngine_MapChanged);
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
        }

        void MouseController_MouseMoved(object sender, MouseEventArgs e)
        {
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
    }
}
