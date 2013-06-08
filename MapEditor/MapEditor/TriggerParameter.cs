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
    public partial class TriggerParameter : UserControl
    {
        public TriggerParameter()
        {
            InitializeComponent();
        }

        public virtual Trigger GetTrigger()
        {
            return null;
        }
        
        
    }
}
