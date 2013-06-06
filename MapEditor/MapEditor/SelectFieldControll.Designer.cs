namespace MapEditor
{
    partial class SelectFieldControll
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(116, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "SelectField";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDescription.Location = new System.Drawing.Point(14, 8);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelDescription.Size = new System.Drawing.Size(96, 18);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SelectFieldControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.button1);
            this.Name = "SelectFieldControll";
            this.Size = new System.Drawing.Size(194, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDescription;
    }
}
