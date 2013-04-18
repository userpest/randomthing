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
            Application.Idle += new EventHandler(Application_Idle);
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
            EditorEngine.Instance.Run();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = ".map";
            
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EditorEngine.Instance.Map.Save(sfd.FileName);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = ".map";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EditorEngine.Instance.Map = new Map(sfd.FileName);
            }
        }
    }
}
