namespace TileSetEditor
{
    partial class TileDialog
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
            this.textBox_TileID = new System.Windows.Forms.TextBox();
            this.label_TileID = new System.Windows.Forms.Label();
            this.label_TileLayer = new System.Windows.Forms.Label();
            this.comboBox_TileLayer = new System.Windows.Forms.ComboBox();
            this.comboBox_TileType = new System.Windows.Forms.ComboBox();
            this.label_TileType = new System.Windows.Forms.Label();
            this.button_LoadImage = new System.Windows.Forms.Button();
            this.pictureBox_TileImage = new System.Windows.Forms.PictureBox();
            this.button_SaveTile = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.comboBox_Team = new System.Windows.Forms.ComboBox();
            this.label_Team = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TileImage)).BeginInit();
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
            this.textBox_TileName.Size = new System.Drawing.Size(129, 20);
            this.textBox_TileName.TabIndex = 1;
            // 
            // textBox_TileID
            // 
            this.textBox_TileID.Enabled = false;
            this.textBox_TileID.Location = new System.Drawing.Point(47, 37);
            this.textBox_TileID.Name = "textBox_TileID";
            this.textBox_TileID.Size = new System.Drawing.Size(37, 20);
            this.textBox_TileID.TabIndex = 3;
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
            // label_TileLayer
            // 
            this.label_TileLayer.AutoSize = true;
            this.label_TileLayer.Location = new System.Drawing.Point(5, 65);
            this.label_TileLayer.Name = "label_TileLayer";
            this.label_TileLayer.Size = new System.Drawing.Size(36, 13);
            this.label_TileLayer.TabIndex = 4;
            this.label_TileLayer.Text = "Layer:";
            // 
            // comboBox_TileLayer
            // 
            this.comboBox_TileLayer.FormattingEnabled = true;
            this.comboBox_TileLayer.Location = new System.Drawing.Point(47, 63);
            this.comboBox_TileLayer.Name = "comboBox_TileLayer";
            this.comboBox_TileLayer.Size = new System.Drawing.Size(129, 21);
            this.comboBox_TileLayer.TabIndex = 5;
            this.comboBox_TileLayer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_TileLayer_KeyPress);
            // 
            // comboBox_TileType
            // 
            this.comboBox_TileType.FormattingEnabled = true;
            this.comboBox_TileType.Location = new System.Drawing.Point(47, 90);
            this.comboBox_TileType.Name = "comboBox_TileType";
            this.comboBox_TileType.Size = new System.Drawing.Size(129, 21);
            this.comboBox_TileType.TabIndex = 7;
            this.comboBox_TileType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_TileType_KeyPress);
            // 
            // label_TileType
            // 
            this.label_TileType.AutoSize = true;
            this.label_TileType.Location = new System.Drawing.Point(5, 92);
            this.label_TileType.Name = "label_TileType";
            this.label_TileType.Size = new System.Drawing.Size(34, 13);
            this.label_TileType.TabIndex = 6;
            this.label_TileType.Text = "Type:";
            // 
            // button_LoadImage
            // 
            this.button_LoadImage.Location = new System.Drawing.Point(8, 150);
            this.button_LoadImage.Name = "button_LoadImage";
            this.button_LoadImage.Size = new System.Drawing.Size(76, 37);
            this.button_LoadImage.TabIndex = 8;
            this.button_LoadImage.Text = "Load Image";
            this.button_LoadImage.UseVisualStyleBackColor = true;
            this.button_LoadImage.Click += new System.EventHandler(this.button_LoadImage_Click);
            // 
            // pictureBox_TileImage
            // 
            this.pictureBox_TileImage.Location = new System.Drawing.Point(120, 155);
            this.pictureBox_TileImage.Name = "pictureBox_TileImage";
            this.pictureBox_TileImage.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_TileImage.TabIndex = 9;
            this.pictureBox_TileImage.TabStop = false;
            // 
            // button_SaveTile
            // 
            this.button_SaveTile.Location = new System.Drawing.Point(8, 214);
            this.button_SaveTile.Name = "button_SaveTile";
            this.button_SaveTile.Size = new System.Drawing.Size(76, 40);
            this.button_SaveTile.TabIndex = 10;
            this.button_SaveTile.Text = "Save Tile";
            this.button_SaveTile.UseVisualStyleBackColor = true;
            this.button_SaveTile.Click += new System.EventHandler(this.button_SaveTile_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(100, 214);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(76, 40);
            this.button_Cancel.TabIndex = 11;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // comboBox_Team
            // 
            this.comboBox_Team.FormattingEnabled = true;
            this.comboBox_Team.Location = new System.Drawing.Point(47, 117);
            this.comboBox_Team.Name = "comboBox_Team";
            this.comboBox_Team.Size = new System.Drawing.Size(129, 21);
            this.comboBox_Team.TabIndex = 13;
            // 
            // label_Team
            // 
            this.label_Team.AutoSize = true;
            this.label_Team.Location = new System.Drawing.Point(5, 119);
            this.label_Team.Name = "label_Team";
            this.label_Team.Size = new System.Drawing.Size(37, 13);
            this.label_Team.TabIndex = 12;
            this.label_Team.Text = "Team:";
            // 
            // TileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 290);
            this.Controls.Add(this.comboBox_Team);
            this.Controls.Add(this.label_Team);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_SaveTile);
            this.Controls.Add(this.pictureBox_TileImage);
            this.Controls.Add(this.button_LoadImage);
            this.Controls.Add(this.comboBox_TileType);
            this.Controls.Add(this.label_TileType);
            this.Controls.Add(this.comboBox_TileLayer);
            this.Controls.Add(this.label_TileLayer);
            this.Controls.Add(this.textBox_TileID);
            this.Controls.Add(this.label_TileID);
            this.Controls.Add(this.textBox_TileName);
            this.Controls.Add(this.label_TileName);
            this.Name = "TileDialog";
            this.Text = "New Tile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TileImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TileName;
        private System.Windows.Forms.TextBox textBox_TileName;
        private System.Windows.Forms.TextBox textBox_TileID;
        private System.Windows.Forms.Label label_TileID;
        private System.Windows.Forms.Label label_TileLayer;
        private System.Windows.Forms.ComboBox comboBox_TileLayer;
        private System.Windows.Forms.ComboBox comboBox_TileType;
        private System.Windows.Forms.Label label_TileType;
        private System.Windows.Forms.Button button_LoadImage;
        private System.Windows.Forms.PictureBox pictureBox_TileImage;
        private System.Windows.Forms.Button button_SaveTile;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ComboBox comboBox_Team;
        private System.Windows.Forms.Label label_Team;
    }
}