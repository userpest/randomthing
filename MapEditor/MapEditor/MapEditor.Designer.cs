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
            this.glControl = new OpenTK.GLControl();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelGameX = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelGameY = new System.Windows.Forms.ToolStripStatusLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.listViewTiles = new System.Windows.Forms.ListView();
            this.labelTiles = new System.Windows.Forms.Label();
            this.buttonAddTile = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(21, 104);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(605, 497);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.MouseLeave += new System.EventHandler(this.glControl_MouseLeave);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
            this.glControl.ImeModeChanged += new System.EventHandler(this.glControl_ImeModeChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(988, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(650, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 24);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.button2.Location = new System.Drawing.Point(650, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 24);
            this.button2.TabIndex = 9;
            this.button2.Text = "Set Start Position";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // listViewTiles
            // 
            this.listViewTiles.Location = new System.Drawing.Point(780, 111);
            this.listViewTiles.MultiSelect = false;
            this.listViewTiles.Name = "listViewTiles";
            this.listViewTiles.ShowGroups = false;
            this.listViewTiles.Size = new System.Drawing.Size(283, 490);
            this.listViewTiles.TabIndex = 10;
            this.listViewTiles.UseCompatibleStateImageBehavior = false;
            this.listViewTiles.SelectedIndexChanged += new System.EventHandler(this.listViewTiles_SelectedIndexChanged);
            // 
            // labelTiles
            // 
            this.labelTiles.AutoSize = true;
            this.labelTiles.Location = new System.Drawing.Point(777, 95);
            this.labelTiles.Name = "labelTiles";
            this.labelTiles.Size = new System.Drawing.Size(29, 13);
            this.labelTiles.TabIndex = 11;
            this.labelTiles.Text = "Tiles";
            // 
            // buttonAddTile
            // 
            this.buttonAddTile.Location = new System.Drawing.Point(651, 201);
            this.buttonAddTile.Name = "buttonAddTile";
            this.buttonAddTile.Size = new System.Drawing.Size(71, 24);
            this.buttonAddTile.TabIndex = 12;
            this.buttonAddTile.Text = "Add Tile";
            this.buttonAddTile.UseVisualStyleBackColor = true;
            this.buttonAddTile.Click += new System.EventHandler(this.buttonAddTile_Click);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 752);
            this.Controls.Add(this.buttonAddTile);
            this.Controls.Add(this.labelTiles);
            this.Controls.Add(this.listViewTiles);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MapEditor";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelX;
        private System.Windows.Forms.ToolStripStatusLabel labelY;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listViewTiles;
        private System.Windows.Forms.Label labelTiles;
        private System.Windows.Forms.ToolStripStatusLabel labelGameX;
        private System.Windows.Forms.ToolStripStatusLabel labelGameY;
        private System.Windows.Forms.Button buttonAddTile;
    }
}

