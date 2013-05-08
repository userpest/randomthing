namespace MapEditor
{
    partial class AddTile
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.checkBoxReplace = new System.Windows.Forms.CheckBox();
            this.listViewBaseTiles = new System.Windows.Forms.ListView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(35, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(342, 36);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadImage.TabIndex = 1;
            this.buttonLoadImage.Text = "Load Image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // checkBoxReplace
            // 
            this.checkBoxReplace.AutoSize = true;
            this.checkBoxReplace.Location = new System.Drawing.Point(342, 84);
            this.checkBoxReplace.Name = "checkBoxReplace";
            this.checkBoxReplace.Size = new System.Drawing.Size(93, 17);
            this.checkBoxReplace.TabIndex = 2;
            this.checkBoxReplace.Text = "Replace Base";
            this.checkBoxReplace.UseVisualStyleBackColor = true;
            this.checkBoxReplace.CheckedChanged += new System.EventHandler(this.checkBoxReplace_CheckedChanged);
            // 
            // listViewBaseTiles
            // 
            this.listViewBaseTiles.Enabled = false;
            this.listViewBaseTiles.Location = new System.Drawing.Point(342, 107);
            this.listViewBaseTiles.MultiSelect = false;
            this.listViewBaseTiles.Name = "listViewBaseTiles";
            this.listViewBaseTiles.Size = new System.Drawing.Size(179, 185);
            this.listViewBaseTiles.TabIndex = 3;
            this.listViewBaseTiles.UseCompatibleStateImageBehavior = false;
            this.listViewBaseTiles.SelectedIndexChanged += new System.EventHandler(this.listViewBaseTiles_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(360, 358);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(446, 358);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 401);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listViewBaseTiles);
            this.Controls.Add(this.checkBoxReplace);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddTile";
            this.Text = "AddTile";
            this.Load += new System.EventHandler(this.AddTile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.CheckBox checkBoxReplace;
        private System.Windows.Forms.ListView listViewBaseTiles;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}