using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileSetEditor
{
    public partial class TileDialog : Form
    {
        private Tile iNewTile = null;
        private TileSet iTileSet = null;
        private Bitmap iTileImage = null;
        private Tile.TileLayer iLayer;
        private Tile.TileType iType;
        private int iTeam;
        
        // If your adding a new tile just pass null for the tile
        public TileDialog( TileSet myTileSet, Tile myTile)
        {
            InitializeComponent();
            iTileSet = myTileSet;
            iNewTile = myTile;
            InitDefaults();
        }

        public void InitDefaults()
        {
            // Set default values for Tile Layers
            comboBox_TileLayer.Items.Add("Terrain");
            comboBox_TileLayer.Items.Add("Terrain2");
            comboBox_TileLayer.Items.Add("Structure");
            comboBox_TileLayer.Items.Add("Unit");

            // Set default values for Tile Types
            comboBox_TileType.Items.Add("Road");
            comboBox_TileType.Items.Add("Plain");
            comboBox_TileType.Items.Add("Mountain");
            comboBox_TileType.Items.Add("Shallow Water");
            comboBox_TileType.Items.Add("Deep Water");

            // Set default values for Team
            comboBox_Team.Items.Add("0");
            comboBox_Team.Items.Add("1");
            comboBox_Team.Items.Add("2");
            comboBox_Team.Items.Add("3");

            // If we are adding a new tile set default values otherwise load them from
            // the tile we're editing
            if (iNewTile == null)
            {
                // Set ID Based on Number of tiles in set
                int NumTiles = iTileSet.Tiles.Count + 1;
                textBox_TileID.Text = NumTiles.ToString();
                // Set initial tile layer
                comboBox_TileLayer.Text = "Terrain";
                // Set initial tile type
                comboBox_TileType.Text = "Road";
                // Set initial team
                comboBox_Team.Text = "0";
            }
            else
            {
                textBox_TileID.Text = iNewTile.ID.ToString();
                textBox_TileName.Text = iNewTile.Name;
                comboBox_TileLayer.Text = TileLayerToText(iNewTile.Layer);
                comboBox_TileType.Text = TileTypeToText(iNewTile.Type);
                // Set the Tile image
                iTileImage = iNewTile.TileImage;
                pictureBox_TileImage.Image = iTileImage;
                comboBox_Team.Text = iNewTile.Team.ToString();
            }

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
                /*
                if (iTileImage.Height != 32 || iTileImage.Width != 32)
                {
                    MessageBox.Show("Error: Tile must be 32x32 pixels!", "Error");
                    iTileImage = null;
                    return;
                }
                */
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
                case "Terrain2":
                    iLayer = Tile.TileLayer.Terrain2;
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

            iTeam = Convert.ToInt32(comboBox_Team.Text);

            // If this is a new tile create it and add it to the tileset
            if (iNewTile == null)
            {
                iNewTile = new Tile(iTileImage, textBox_TileName.Text, Convert.ToInt32(textBox_TileID.Text),
                    iLayer, iType, 0, 0, iTileImage.Width, iTileImage.Height, iTeam);

                iTileSet.Tiles.Add(iNewTile);
            }
            else
            {
                iNewTile.Name = textBox_TileName.Text;
                iNewTile.Layer = iLayer;
                iNewTile.Type = iType;
                iNewTile.TileImage = iTileImage;
                iNewTile.Team = iTeam;
                //iTileSet.Tiles[iNewTile.ID] = iNewTile;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Return Text Version of a TileLayer
        private string TileLayerToText( Tile.TileLayer layer )
        {
            string LayerText = "";
            //public enum TileLayer { Terrain = 1, Structure = 2, Unit = 3 }
            switch (layer)
            {
                case Tile.TileLayer.Terrain:
                    LayerText = "Terrain";
                    break;
                case Tile.TileLayer.Terrain2:
                    LayerText = "Terrain2";
                    break;
                case Tile.TileLayer.Structure:
                    LayerText = "Structure";
                    break;
                case Tile.TileLayer.Unit:
                    LayerText = "Unit";
                    break;
                default:
                    MessageBox.Show("Error: Incorrect value for layer!", "Error");
                    break;
            }

            return LayerText;
        }

        // Return Text Version of a TileType
        private string TileTypeToText(Tile.TileType type)
        {
            string TypeText = "";
            //public enum TileType { Road = 1, Plain = 2, Mountain = 3, ShallowWater = 4, DeepWater = 5 }
            switch (type)
            {
                case Tile.TileType.Road:
                    TypeText = "Road";
                    break;
                case Tile.TileType.Plain:
                    TypeText = "Plain";
                    break;
                case Tile.TileType.Mountain:
                    TypeText = "Mountain";
                    break;
                case Tile.TileType.ShallowWater:
                    TypeText = "Shallow Water";
                    break;
                case Tile.TileType.DeepWater:
                    TypeText = "Deep Water";
                    break;
                default:
                    MessageBox.Show("Error: Incorrect value for type!", "Error");
                    break;
            }
            return TypeText;
        }

        private void comboBox_TileType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox_TileLayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}