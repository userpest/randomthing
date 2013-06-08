using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class SelectFieldControll : UserControl, IClickListener
    {

        public String Description { get { return labelDescription.Text; } set { labelDescription.Text = value; } }
        public SelectFieldControll()
        {
            InitializeComponent();
        }
        public Point SelectedLocation;
        public bool LocationSet = false;

        private void button1_Click(object sender, EventArgs e)
        {
            MapEditor.Instance.ListenForClick(this);
        }


        public void OnClick(Point location)
        {
            SelectedLocation = location;
            LocationSet = true;
        }
    }
}
