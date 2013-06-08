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
    public partial class SpawnCreatureControll : TriggerParameter, IClickListener
    {
        Point spawnPoint;
        bool spawnSet = false;

        public SpawnCreatureControll()
        {
            InitializeComponent();
            loadComboBox();
        }
        private void loadComboBox()
        {
            comboBoxCreature.Items.Clear();
            foreach(string creature in EditorEngine.Instance.CreaturesManager.Prototypes.Keys)
            {
                comboBoxCreature.Items.Add(creature);
            }
        }
        public override Trigger GetTrigger()
        {
            return new SpawnMobTrigger((int)numericUpDown1.Value, (int)numericUpDown2.Value, comboBoxCreature.SelectedItem.ToString(), spawnPoint);
        }

        private void buttonSelectField_Click(object sender, EventArgs e)
        {
            MapEditor.Instance.ListenForClick(this);
        }


        public void OnClick(Point location)
        {
            spawnPoint = location;
            spawnSet = true;
            labelSpawn.Text = String.Format("{0}:{1}", location.X, location.Y);
        }
    }
}
