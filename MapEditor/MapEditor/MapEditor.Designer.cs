namespace MapEditor
{
    partial class MapEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.glControl = new OpenTK.GLControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.triggersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelGameX = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelGameY = new System.Windows.Forms.ToolStripStatusLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.listViewTiles = new System.Windows.Forms.ListView();
            this.labelTiles = new System.Windows.Forms.Label();
            this.buttonAddTile = new System.Windows.Forms.Button();
            this.buttonbackgrnd = new System.Windows.Forms.Button();
            this.listViewCreatures = new System.Windows.Forms.ListView();
            this.checkBoxShowTriggers = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.ContextMenuStrip = this.contextMenuStrip;
            this.glControl.Location = new System.Drawing.Point(0, 27);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(1003, 700);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.SizeChanged += new System.EventHandler(this.glControl_SizeChanged);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.MouseLeave += new System.EventHandler(this.glControl_MouseLeave);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
            this.glControl.ImeModeChanged += new System.EventHandler(this.glControl_ImeModeChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.triggersToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(118, 26);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // triggersToolStripMenuItem
            // 
            this.triggersToolStripMenuItem.Name = "triggersToolStripMenuItem";
            this.triggersToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.triggersToolStripMenuItem.Text = "Triggers";
            this.triggersToolStripMenuItem.Click += new System.EventHandler(this.triggersToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1281, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // MapToolStripMenuItem
            // 
            this.MapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.MapToolStripMenuItem.Name = "MapToolStripMenuItem";
            this.MapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.MapToolStripMenuItem.Text = "Map";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelX,
            this.labelY,
            this.labelGameX,
            this.labelGameY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 730);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1281, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelX
            // 
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 17);
            this.labelX.Text = "--";
            // 
            // labelY
            // 
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 17);
            this.labelY.Text = "--";
            // 
            // labelGameX
            // 
            this.labelGameX.Name = "labelGameX";
            this.labelGameX.Size = new System.Drawing.Size(17, 17);
            this.labelGameX.Text = "--";
            // 
            // labelGameY
            // 
            this.labelGameY.Name = "labelGameY";
            this.labelGameY.Size = new System.Drawing.Size(17, 17);
            this.labelGameY.Text = "--";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1012, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 24);
            this.button2.TabIndex = 9;
            this.button2.Text = "Set Start Position";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // listViewTiles
            // 
            this.listViewTiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTiles.Location = new System.Drawing.Point(1012, 142);
            this.listViewTiles.MultiSelect = false;
            this.listViewTiles.Name = "listViewTiles";
            this.listViewTiles.ShowGroups = false;
            this.listViewTiles.Size = new System.Drawing.Size(257, 269);
            this.listViewTiles.TabIndex = 10;
            this.listViewTiles.UseCompatibleStateImageBehavior = false;
            this.listViewTiles.SelectedIndexChanged += new System.EventHandler(this.listViewTiles_SelectedIndexChanged);
            this.listViewTiles.Enter += new System.EventHandler(this.listViewTiles_Enter);
            // 
            // labelTiles
            // 
            this.labelTiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTiles.AutoSize = true;
            this.labelTiles.Location = new System.Drawing.Point(1009, 126);
            this.labelTiles.Name = "labelTiles";
            this.labelTiles.Size = new System.Drawing.Size(29, 13);
            this.labelTiles.TabIndex = 11;
            this.labelTiles.Text = "Tiles";
            // 
            // buttonAddTile
            // 
            this.buttonAddTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddTile.Location = new System.Drawing.Point(1012, 58);
            this.buttonAddTile.Name = "buttonAddTile";
            this.buttonAddTile.Size = new System.Drawing.Size(112, 24);
            this.buttonAddTile.TabIndex = 12;
            this.buttonAddTile.Text = "Add Tile";
            this.buttonAddTile.UseVisualStyleBackColor = true;
            this.buttonAddTile.Click += new System.EventHandler(this.buttonAddTile_Click);
            // 
            // buttonbackgrnd
            // 
            this.buttonbackgrnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonbackgrnd.Location = new System.Drawing.Point(1012, 88);
            this.buttonbackgrnd.Name = "buttonbackgrnd";
            this.buttonbackgrnd.Size = new System.Drawing.Size(112, 23);
            this.buttonbackgrnd.TabIndex = 13;
            this.buttonbackgrnd.Text = "Set Background";
            this.buttonbackgrnd.UseVisualStyleBackColor = true;
            this.buttonbackgrnd.Click += new System.EventHandler(this.buttonbackgrnd_Click);
            // 
            // listViewCreatures
            // 
            this.listViewCreatures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCreatures.Location = new System.Drawing.Point(1012, 417);
            this.listViewCreatures.Name = "listViewCreatures";
            this.listViewCreatures.Size = new System.Drawing.Size(140, 196);
            this.listViewCreatures.TabIndex = 14;
            this.listViewCreatures.UseCompatibleStateImageBehavior = false;
            this.listViewCreatures.SelectedIndexChanged += new System.EventHandler(this.listViewCreatures_SelectedIndexChanged);
            this.listViewCreatures.Enter += new System.EventHandler(this.listViewCreatures_Enter);
            // 
            // checkBoxShowTriggers
            // 
            this.checkBoxShowTriggers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowTriggers.AutoSize = true;
            this.checkBoxShowTriggers.Location = new System.Drawing.Point(1158, 417);
            this.checkBoxShowTriggers.Name = "checkBoxShowTriggers";
            this.checkBoxShowTriggers.Size = new System.Drawing.Size(94, 17);
            this.checkBoxShowTriggers.TabIndex = 16;
            this.checkBoxShowTriggers.Text = "Show Triggers";
            this.checkBoxShowTriggers.UseVisualStyleBackColor = true;
            this.checkBoxShowTriggers.CheckedChanged += new System.EventHandler(this.checkBoxShowTriggers_CheckedChanged);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 752);
            this.Controls.Add(this.listViewTiles);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBoxShowTriggers);
            this.Controls.Add(this.buttonbackgrnd);
            this.Controls.Add(this.listViewCreatures);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.buttonAddTile);
            this.Controls.Add(this.labelTiles);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.button2);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MapEditor";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelX;
        private System.Windows.Forms.ToolStripStatusLabel labelY;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listViewTiles;
        private System.Windows.Forms.Label labelTiles;
        private System.Windows.Forms.ToolStripStatusLabel labelGameX;
        private System.Windows.Forms.ToolStripStatusLabel labelGameY;
        private System.Windows.Forms.Button buttonAddTile;
        private System.Windows.Forms.Button buttonbackgrnd;
        private System.Windows.Forms.ListView listViewCreatures;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem triggersToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxShowTriggers;
    }
}

