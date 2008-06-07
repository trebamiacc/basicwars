using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileSetEditor
{
    public partial class NewTileDialog : Form
    {
        private Tile iNewTile = null;
        private TileSet iTileSet = null;
        private Bitmap iTileImage = null;
        private Tile.TileLayer iLayer;
        private Tile.TileType iType;
        
        public NewTileDialog( TileSet myTileSet)
        {
            InitializeComponent();
            iTileSet = myTileSet;
            InitDefaults();
        }

        public void InitDefaults()
        {
            // Set default values for Tile Layers
            comboBox_TileLayer.Items.Add("Terrain");
            comboBox_TileLayer.Items.Add("Structure");
            comboBox_TileLayer.Items.Add("Unit");
            comboBox_TileLayer.Text = "Terrain";

            // Set default values for Tile Types
            comboBox_TileType.Items.Add("Road");
            comboBox_TileType.Items.Add("Plain");
            comboBox_TileType.Items.Add("Mountain");
            comboBox_TileType.Items.Add("Shallow Water");
            comboBox_TileType.Items.Add("Deep Water");
            comboBox_TileType.Text = "Road";

            // Set ID Based on Number of tiles in set
            int NumTiles = iTileSet.Tiles.Count;
            textBox_TileID.Text = NumTiles.ToString();
        }

        // Ask the user for a tile image and load it if valid
        private void button_LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.InitialDirectory = "";
            myDialog.RestoreDirectory = true;
            myDialog.Filter = "PNG|*.png";
            myDialog.Multiselect = false;

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                // Attempt to load the image and check if it's valid
                try
                {
                    iTileImage = new Bitmap(myDialog.FileName);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Error Loading Tile Image!");
                    return;
                }

                // Check dimensions of bitmap
                if (iTileImage.Height != 32 || iTileImage.Width != 32)
                {
                    MessageBox.Show("Error: Tile must be 32x32 pixels!", "Error");
                    iTileImage = null;
                    return;
                }
            }

            // Tile loaded successfully, put it in picture box
            pictureBox_TileImage.Image = iTileImage;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_SaveTile_Click(object sender, EventArgs e)
        {
            if (textBox_TileName.Text == "")
            {
                MessageBox.Show("Error: You must give the tile a name!", "Error!");
                return;
            }

            //public enum TileLayer { Terrain = 1, Structure = 2, Unit = 3 }
            switch (comboBox_TileLayer.Text)
            {
                case "Terrain":
                    iLayer = Tile.TileLayer.Terrain;
                    break;
                case "Structure":
                    iLayer = Tile.TileLayer.Structure;
                    break;
                case "Unit":
                    iLayer = Tile.TileLayer.Unit;
                    break;
                default:
                    MessageBox.Show("Error: Incorrect value for layer!", "Error");
                    break;
            }
            //public enum TileType { Road = 1, Plain = 2, Mountain = 3, ShallowWater = 4, DeepWater = 5 }
            switch (comboBox_TileType.Text)
            {
                case "Road":
                    iType = Tile.TileType.Road;
                    break;
                case "Plain":
                    iType = Tile.TileType.Plain;
                    break;
                case "Mountain":
                    iType = Tile.TileType.Mountain;
                    break;
                case "Shallow Water":
                    iType = Tile.TileType.ShallowWater;
                    break;
                case "Deep Water":
                    iType = Tile.TileType.DeepWater;
                    break;
                default:
                    MessageBox.Show("Error: Incorrect value for type!", "Error");
                    break;
            }

            iNewTile = new Tile(iTileImage, textBox_TileName.Text, Convert.ToInt32(textBox_TileID.Text),
                iLayer, iType, 0, 0);

            iTileSet.Tiles.Add(iNewTile);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}