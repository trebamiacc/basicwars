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
            this.pan_MapWindow = new MapEditor.BufferedPanel();
            this.pan_Tiles = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_CurTile = new System.Windows.Forms.PictureBox();
            this.b_PlayerSpawn = new System.Windows.Forms.Button();
            this.lab_PlayerSpawn = new System.Windows.Forms.Label();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CurTile)).BeginInit();
            this.SuspendLayout();
            // 
            // pan_MapWindow
            // 
            this.pan_MapWindow.BackColor = System.Drawing.SystemColors.Window;
            this.pan_MapWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_MapWindow.Location = new System.Drawing.Point(11, 38);
            this.pan_MapWindow.Name = "pan_MapWindow";
            this.pan_MapWindow.Size = new System.Drawing.Size(629, 512);
            this.pan_MapWindow.TabIndex = 0;
            this.pan_MapWindow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pan_MapWindow_MClick);
            this.pan_MapWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.pan_Map_Paint);
            // 
            // pan_Tiles
            // 
            this.pan_Tiles.BackColor = System.Drawing.SystemColors.Window;
            this.pan_Tiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_Tiles.Location = new System.Drawing.Point(13, 582);
            this.pan_Tiles.Name = "pan_Tiles";
            this.pan_Tiles.Size = new System.Drawing.Size(627, 113);
            this.pan_Tiles.TabIndex = 1;
            this.pan_Tiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pan_Tiles_MouseClick);
            this.pan_Tiles.Paint += new System.Windows.Forms.PaintEventHandler(this.pan_Tiles_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.saveMapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newMapToolStripMenuItem.Text = "New Map";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.NewMap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tile Set";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(651, 566);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Selected Tile";
            // 
            // pb_CurTile
            // 
            this.pb_CurTile.Location = new System.Drawing.Point(671, 582);
            this.pb_CurTile.Name = "pb_CurTile";
            this.pb_CurTile.Size = new System.Drawing.Size(32, 32);
            this.pb_CurTile.TabIndex = 0;
            this.pb_CurTile.TabStop = false;
            // 
            // b_PlayerSpawn
            // 
            this.b_PlayerSpawn.Location = new System.Drawing.Point(654, 38);
            this.b_PlayerSpawn.Name = "b_PlayerSpawn";
            this.b_PlayerSpawn.Size = new System.Drawing.Size(154, 38);
            this.b_PlayerSpawn.TabIndex = 0;
            this.b_PlayerSpawn.Text = "Set Player Spawn Tile";
            this.b_PlayerSpawn.UseVisualStyleBackColor = true;
            this.b_PlayerSpawn.Click += new System.EventHandler(this.b_PlayerSpawn_Click);
            // 
            // lab_PlayerSpawn
            // 
            this.lab_PlayerSpawn.AutoSize = true;
            this.lab_PlayerSpawn.Location = new System.Drawing.Point(651, 91);
            this.lab_PlayerSpawn.Name = "lab_PlayerSpawn";
            this.lab_PlayerSpawn.Size = new System.Drawing.Size(102, 13);
            this.lab_PlayerSpawn.TabIndex = 7;
            this.lab_PlayerSpawn.Text = "Player Spawn: (0, 0)";
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.Menu_SaveMap);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 711);
            this.Controls.Add(this.lab_PlayerSpawn);
            this.Controls.Add(this.b_PlayerSpawn);
            this.Controls.Add(this.pb_CurTile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pan_Tiles);
            this.Controls.Add(this.pan_MapWindow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditor";
            this.Text = "Trout Map Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CurTile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Panel pan_MapWindow;
        BufferedPanel pan_MapWindow;
        private System.Windows.Forms.Panel pan_Tiles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pb_CurTile;
        private System.Windows.Forms.Button b_PlayerSpawn;
        private System.Windows.Forms.Label lab_PlayerSpawn;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
    }
}

