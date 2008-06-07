using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace TileSetEditor
{
    public partial class TileSetEditor : Form
    {
        // Define enums for TileLayer and TileType
        //enum TileLayer { Terrain = 1, Structure = 2, Unit = 3 }
        //enum TileType { Road = 1, Plain = 2, Mountain = 3, ShallowWater = 4, DeepWater = 5 }
        TileSet myTileSet = new TileSet();

        public TileSetEditor()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            // Add some values to the tileset to make sure serialization is working
            Bitmap tileimage = new Bitmap("Grass.png");
            Tile myTile = new Tile(tileimage, "Ugly", 0, Tile.TileLayer.Terrain,
                Tile.TileType.Plain, 0, 0);
            myTileSet.Name = "TileSet1";
            myTileSet.Tiles.Add(myTile);

            string myMsg = myTileSet.Name + " - " + myTileSet.Tiles[0].Name;
            MessageBox.Show(myMsg);
            
            myTileSet.Save("TileSet1.dat");
            */
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            myTileSet.Load("TileSet1.dat");

            string myMsg = myTileSet.Name + " - " + myTileSet.Tiles[0].Name;
            MessageBox.Show(myMsg);
             * 
             */
        }

        private void button_AddTile_Click(object sender, EventArgs e)
        {
            NewTileDialog NewTileForm = new NewTileDialog();
            if (NewTileForm.ShowDialog() == DialogResult.OK)
            {

            }
            
            //NewMapDialog NewMapForm = new NewMapDialog();
            //if (NewMapForm.ShowDialog() == DialogResult.OK)
            
        }
    }
}