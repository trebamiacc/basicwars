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
            SaveFileDialog myDialog = new SaveFileDialog();
			myDialog.InitialDirectory = "";
			myDialog.RestoreDirectory = true;
            myDialog.Filter = "Tile Sets|*.tiledat";
            myDialog.AddExtension = true;
            myDialog.DefaultExt = ".dat";

			if (myDialog.ShowDialog() == DialogResult.OK)
			{
                myTileSet.Save(myDialog.FileName);
			}
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.InitialDirectory = "";
            myDialog.RestoreDirectory = true;
            myDialog.Filter = "Tile Sets|*.tiledat";
            myDialog.Multiselect = false;

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                myTileSet.Load(myDialog.FileName);
                // Clear list box and reset it
                listBox_Tiles.Items.Clear();
                for (int i = 0; i < myTileSet.Tiles.Count; i++)
                {
                    listBox_Tiles.Items.Add(myTileSet.Tiles[i]);
                }
            }
        }

        private void button_AddTile_Click(object sender, EventArgs e)
        {
            TileDialog NewTileForm = new TileDialog(myTileSet, null);
            if (NewTileForm.ShowDialog() == DialogResult.OK)
            {
                // Update the tile list
                listBox_Tiles.Items.Clear();
                for ( int i = 0; i < myTileSet.Tiles.Count; i++)
                {
                    listBox_Tiles.Items.Add(myTileSet.Tiles[i]);
                }
            }
            
            //NewMapDialog NewMapForm = new NewMapDialog();
            //if (NewMapForm.ShowDialog() == DialogResult.OK)
            
        }

        // Make sure a tile is selected and if so remove it from the listbox and tileset
        private void button_RemoveTile_Click(object sender, EventArgs e)
        {
            Tile SelectedTile = (Tile)listBox_Tiles.SelectedItem;
            if (SelectedTile != null)
            {
                listBox_Tiles.Items.Remove(SelectedTile);
                myTileSet.Tiles.Remove(SelectedTile);
            }
        }

        // User wants to start a new list
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear the tileset and listbox
            listBox_Tiles.Items.Clear();
            myTileSet.Tiles.Clear();
        }

        // Make sure we pass the selected tile to the TileDialog
        private void button_EditTile_Click(object sender, EventArgs e)
        {
            Tile SelectedTile = (Tile)listBox_Tiles.SelectedItem;
            if (SelectedTile != null)
            {
                TileDialog AddTileForm = new TileDialog(myTileSet, SelectedTile);
                if (AddTileForm.ShowDialog() == DialogResult.OK)
                {
                    // Update the tile list
                    listBox_Tiles.Items.Clear();
                    for (int i = 0; i < myTileSet.Tiles.Count; i++)
                    {
                        listBox_Tiles.Items.Add(myTileSet.Tiles[i]);
                    }
                }
            }
        }
    }
}