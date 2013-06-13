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
    public partial class SpawnPointControll : TriggerParameter
    {
        public SpawnPointControll()
        {
            InitializeComponent();
        }
        public override Trigger GetTrigger()
        {
            Trigger tr = new MoveToNextMapTrigger(new Point((int)numericUpDown1.Value, (int)numericUpDown2.Value),textBox1.Text);
            return tr;
        }
    }
}
