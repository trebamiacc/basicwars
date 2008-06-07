namespace TileSetEditor
{
    partial class NewTileDialog
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
            this.label_TileName = new System.Windows.Forms.Label();
            this.textBox_TileName = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_TileID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_TileName
            // 
            this.label_TileName.AutoSize = true;
            this.label_TileName.Location = new System.Drawing.Point(3, 18);
            this.label_TileName.Name = "label_TileName";
            this.label_TileName.Size = new System.Drawing.Size(38, 13);
            this.label_TileName.TabIndex = 0;
            this.label_TileName.Text = "Name:";
            // 
            // textBox_TileName
            // 
            this.textBox_TileName.Location = new System.Drawing.Point(47, 11);
            this.textBox_TileName.Name = "textBox_TileName";
            this.textBox_TileName.Size = new System.Drawing.Size(112, 20);
            this.textBox_TileName.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(47, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(37, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label_TileID
            // 
            this.label_TileID.AutoSize = true;
            this.label_TileID.Location = new System.Drawing.Point(20, 40);
            this.label_TileID.Name = "label_TileID";
            this.label_TileID.Size = new System.Drawing.Size(21, 13);
            this.label_TileID.TabIndex = 2;
            this.label_TileID.Text = "ID:";
            // 
            // NewTileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 256);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_TileID);
            this.Controls.Add(this.textBox_TileName);
            this.Controls.Add(this.label_TileName);
            this.Name = "NewTileDialog";
            this.Text = "New Tile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TileName;
        private System.Windows.Forms.TextBox textBox_TileName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_TileID;
    }
}