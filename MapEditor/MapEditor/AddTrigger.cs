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
    public partial class AddTrigger : Form
    {
        public event EventHandler Result;
        private Dictionary<TriggerType, TriggerParameter> list;
        TriggerParameter triggerParameter;
        public bool OK;

        public Trigger Trigger;

        public AddTrigger()
        {
            InitializeComponent();
        }

        private void AddTrigger_Load(object sender, EventArgs e)
        {
            loadComboBox();
        }

        private void loadComboBox()
        {
            comboBox1.Items.Clear();

            list = new Dictionary<TriggerType, TriggerParameter>();

            list[TriggerType.NONE] = null;
            list[TriggerType.CHANGE_MAP] = new SpawnPointControll();
            list[TriggerType.SPAWN_MOB] = new SpawnCreatureControll();
            foreach (TriggerType tt in list.Keys)
            {
                comboBox1.Items.Add(tt);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerParameter tp = list[(TriggerType)comboBox1.SelectedItem];
            if (tp == null)
            {
                groupBox.Controls.Clear();
                buttonOK.Enabled = false;
                return;
            }
            buttonOK.Enabled = true;
            triggerParameter = tp;
            setTriggerParameter();

        }
        private void setTriggerParameter()
        {
            triggerParameter.Dock = DockStyle.Fill;
            groupBox.Controls.Clear();
            groupBox.Controls.Add(triggerParameter);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Trigger = triggerParameter.GetTrigger();
            OK = true;
            if (Result != null) Result(this, null);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OK = false;
            Close();
        }
            
                
    }
}
