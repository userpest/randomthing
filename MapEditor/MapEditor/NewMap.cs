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
    public partial class NewMap : Form
    {
        public string MapName { get { return textBox1.Text; } }
        public int MapWidth { get { return (int)numericUpDown1.Value; } }
        public int MapHeight { get { return (int)numericUpDown2.Value; } }
        public NewMap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NewMap_Load(object sender, EventArgs e)
        {

        }
    }
}
