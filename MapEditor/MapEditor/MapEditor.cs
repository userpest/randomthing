using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace MapEditor
{
    public partial class MapEditor : Form
    {
        private bool loaded = false;
        private int x = 0;

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
        }

        void MouseController_MouseMoved(object sender, MouseEventArgs e)
        {
            labelX.Text = String.Format("X:{0}", e.X);
            labelY.Text = String.Format("Y:{0}", e.Y);

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
    }
}
