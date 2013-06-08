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
    public partial class ManageTrigger : Form
    {
        private Field field;
        public Field Field { get { return field; } set { field = value; loadTriggers(); } }
        private AddTrigger at;

        public ManageTrigger()
        {
            InitializeComponent();
        }

        private void loadTriggers()
        {
            listBoxTriggers.Items.Clear();
            if (Field != null && Field.triggers!=null)
            {
                foreach (Trigger tr in Field.triggers)
                {
                    listBoxTriggers.Items.Add(tr);
                }
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            at = new AddTrigger();
            at.Result += new EventHandler(at_Result);
            at.Show();
            
        }

        void at_Result(object sender, EventArgs e)
        {
            this.BringToFront();
            if (at.OK)
            {
                if (Field.triggers == null) Field.triggers = new List<Trigger>();
                Field.triggers.Add(at.Trigger);
            }
            at.Result -= at_Result;
            loadTriggers();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int i = listBoxTriggers.SelectedIndex;
            if (Field != null)
            {
                Field.triggers.RemoveAt(i);
                if (Field.triggers.Count == 0) Field.triggers = null;
            }
            loadTriggers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MapEditor.Instance.BringToFront();
            Close();
        }
    }
}
