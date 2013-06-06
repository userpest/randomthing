using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class AddTile : Form
    {
        ImageList il;
        public Bitmap picture;
        public Texture TextureReplaced;
        public bool IsReplaced { get { return checkBoxReplace.Checked; } }
        public AddTile()
        {
            InitializeComponent();
            listViewBaseTiles.View = View.LargeIcon;
            
        }

        private void AddTile_Load(object sender, EventArgs e)
        {
            il = new ImageList();
            listViewBaseTiles.Items.Clear();
            int i = 0;

            foreach (KeyValuePair<int, Texture> texture in EditorEngine.Instance.Map.textures)
            {
                if (texture.Value.Basic)
                {
                    il.Images.Add(texture.Value.Bmp);
                    string text = (texture.Value.Basic ? "Basic" : "Own");
                    ListViewItem item = new ListViewItem(text, i++);
                    item.Tag = texture.Value;
                    listViewBaseTiles.Items.Add(item);
                }
            }
            listViewBaseTiles.LargeImageList = il;
        }

        private void checkBoxReplace_CheckedChanged(object sender, EventArgs e)
        {
            listViewBaseTiles.Enabled = checkBoxReplace.Checked;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            Bitmap bmp;
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bmp = new Bitmap(opf.FileName); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot read a picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    picture = Utils.InteligentResize(bmp);
                    pictureBox1.BackgroundImage = picture;
                    buttonOK.Enabled = true;
                    
                }
            }
            
        }

        

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void listViewBaseTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection coll;
            coll = listViewBaseTiles.SelectedItems;
            if (coll.Count > 0)
            {
                TextureReplaced = coll[0].Tag as Texture;
            }
        }
    }
}
