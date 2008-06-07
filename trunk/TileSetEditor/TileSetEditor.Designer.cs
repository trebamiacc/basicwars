namespace TileSetEditor
{
    partial class TileSetEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox_Tiles = new System.Windows.Forms.ListBox();
            this.label_Tiles = new System.Windows.Forms.Label();
            this.button_AddTile = new System.Windows.Forms.Button();
            this.button_EditTile = new System.Windows.Forms.Button();
            this.button_RemoveTile = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(345, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // listBox_Tiles
            // 
            this.listBox_Tiles.FormattingEnabled = true;
            this.listBox_Tiles.Location = new System.Drawing.Point(12, 45);
            this.listBox_Tiles.Name = "listBox_Tiles";
            this.listBox_Tiles.Size = new System.Drawing.Size(134, 186);
            this.listBox_Tiles.TabIndex = 1;
            // 
            // label_Tiles
            // 
            this.label_Tiles.AutoSize = true;
            this.label_Tiles.Location = new System.Drawing.Point(12, 29);
            this.label_Tiles.Name = "label_Tiles";
            this.label_Tiles.Size = new System.Drawing.Size(32, 13);
            this.label_Tiles.TabIndex = 2;
            this.label_Tiles.Text = "Tiles:";
            // 
            // button_AddTile
            // 
            this.button_AddTile.Location = new System.Drawing.Point(170, 59);
            this.button_AddTile.Name = "button_AddTile";
            this.button_AddTile.Size = new System.Drawing.Size(112, 37);
            this.button_AddTile.TabIndex = 3;
            this.button_AddTile.Text = "Add Tile";
            this.button_AddTile.UseVisualStyleBackColor = true;
            this.button_AddTile.Click += new System.EventHandler(this.button_AddTile_Click);
            // 
            // button_EditTile
            // 
            this.button_EditTile.Location = new System.Drawing.Point(170, 113);
            this.button_EditTile.Name = "button_EditTile";
            this.button_EditTile.Size = new System.Drawing.Size(112, 37);
            this.button_EditTile.TabIndex = 4;
            this.button_EditTile.Text = "Edit Tile";
            this.button_EditTile.UseVisualStyleBackColor = true;
            // 
            // button_RemoveTile
            // 
            this.button_RemoveTile.Location = new System.Drawing.Point(170, 168);
            this.button_RemoveTile.Name = "button_RemoveTile";
            this.button_RemoveTile.Size = new System.Drawing.Size(112, 37);
            this.button_RemoveTile.TabIndex = 5;
            this.button_RemoveTile.Text = "Remove Tile";
            this.button_RemoveTile.UseVisualStyleBackColor = true;
            // 
            // TileSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 290);
            this.Controls.Add(this.button_RemoveTile);
            this.Controls.Add(this.button_EditTile);
            this.Controls.Add(this.button_AddTile);
            this.Controls.Add(this.label_Tiles);
            this.Controls.Add(this.listBox_Tiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TileSetEditor";
            this.Text = "TileSet Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox_Tiles;
        private System.Windows.Forms.Label label_Tiles;
        private System.Windows.Forms.Button button_AddTile;
        private System.Windows.Forms.Button button_EditTile;
        private System.Windows.Forms.Button button_RemoveTile;

    }
}

