using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace MapEditor
{
    public partial class MapEditor : Form
    {
        private List<Tile> TileSet = new List<Tile>();
        private Bitmap TileSetImage;
        private Size TileSetSize;
        private int SelectedTileIndex = 0;
        private Bitmap MapImage;
        private Tile[,] MapArray;
        private bool MapCreated = false;
        private int mapsize = 0;
        private int BackgroundTileIndex;
        private Point PlayeySpawn = new Point(0, 0);
        private List<TerrainType> MapTerrains = new List<TerrainType>();
        private string MapName = "";

        //BufferedPanel pan_MapWindow = new MapEditor.BufferedPanel();

        enum MapEditorState { Terrain = 1, PlayerSpawn = 2, MonsterSpawns = 3, MapLinks = 3 }
        MapEditorState CurrentState = MapEditorState.Terrain;

        public MapEditor()
        {
            InitializeComponent();

            base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            // Load the initial Tile Set
            LoadTileSet();
            CreateTileSetImage();
            pb_CurTile.Image = TileSet[SelectedTileIndex].TileImage;

            // Set the terrain types for the map
            LoadTerrainTypes();
        }

        // This function will eventually load the terrain types from the tileset file
        private void LoadTerrainTypes()
        {
            //MapTerrains.Add( new TerrainType( "EMPTY", '0', "TERRAIN_EMPTY", false ));
            string NameTileSet = @"Config\Tilesets\Michael-01\Michael-01.tiles";

            XmlDocument doc = new XmlDocument();
            doc.Load(NameTileSet);

            XmlElement terraintypes = (XmlElement)doc.GetElementsByTagName("terrain-types")[0];

            foreach (XmlElement terrain in terraintypes.ChildNodes)
            {
                if (terrain.Name == "item")
                {
                    if (terrain.Attributes["name"] != null)
                    {
                        string terName = terrain.Attributes["name"].Value;
                        char terChar = (char)(terrain.Attributes["char"].Value.ToCharArray()[0]);
                        string terTileName = terrain.Attributes["tile"].Value;
                        bool terPassable = bool.Parse(terrain.Attributes["passable"].Value);
                        TerrainType myTerrain = new TerrainType(terName, terChar, terTileName, terPassable);
                        MapTerrains.Add(myTerrain);
                    }
                }
            }
        }

        // For now I will be loading a specific tileset everytime the user opens the
        // program. This function will load that tileset into the tile panel
        private void LoadTileSet()
        {
            string NameTileSet = @"Config\Tilesets\Michael-01\Michael-01.tiles";

            XmlDocument doc = new XmlDocument();
            doc.Load(NameTileSet);

            XmlElement tiles = (XmlElement)doc.GetElementsByTagName("tiles")[0];
            XmlElement info = (XmlElement)doc.GetElementsByTagName("info")[0];

            XmlElement sizeElement = (XmlElement)info.GetElementsByTagName("size")[0];

            int size = int.Parse(sizeElement.InnerText);

            if (size != 32)
            {
                MessageBox.Show("Tiles are not 32x32 in size", "ERROR");
                return;
            }

            foreach (XmlElement tile in tiles.ChildNodes)
            {
                if (tile.Name == "tile")
                {
                    if (tile.Attributes["img"] != null)
                    {
                        // tile.Attributes["img"].Value
                        // tile.Attributes["name"].Value
                        string imgFileName = tile.Attributes["img"].Value;
                        string imgName = tile.Attributes["name"].Value;
                        Bitmap tileimage = new Bitmap(imgFileName);
                        Tile newtile = new Tile(tileimage, imgName, 0, 0);
                        TileSet.Add(newtile);

                        // Get the index to the TERRAIN_GRASSLAND tile
                        if (newtile.Name == "TERRAIN_GRASSLAND")
                        {
                            BackgroundTileIndex = TileSet.Count - 1;
                        }
                    }

                }
            }
        }

        // Create an image that displays all the tiles in the tileset panel
        private void CreateTileSetImage()
        {
            // Based on the number of tiles loaded we should know how big the image will need to be
            // to hold them. We're going to wrap the tiles at the end of the panel, so we only will
            // have to scroll vertically. Each tile is 32 pixels wide + 3 pixels of space between each
            // of them, starting with a 3 pixel offset. So to figure out how many tiles fit in the width
            // of the panel the formula is: (panel.width - 3) / 35

            int numTilesWide = (pan_Tiles.Width - 3) / 35;
            int numTilesHigh = 1 + (TileSet.Count / numTilesWide);
            int totalWidth = 3 + (35 * numTilesWide);
            int totalHeight = 3 + (35 * numTilesHigh);
            TileSetSize = new Size(totalWidth, totalHeight);
            pan_Tiles.AutoScrollMinSize = TileSetSize;

            // Create a new bitmap to draw the tileset onto
            // was using PixelFormat.Format24bppRgb
            TileSetImage = new Bitmap(TileSetSize.Width, TileSetSize.Height, PixelFormat.Format32bppRgb);

            // Get a graphic context from the image so we can draw to it
            Graphics g_TS = Graphics.FromImage(TileSetImage);

            // Clear out the image to be all white
            Rectangle background = new Rectangle(0, 0, TileSetImage.Width, TileSetImage.Height);
            SolidBrush myBrush = new SolidBrush(Color.White);
            g_TS.FillRectangle(myBrush, background);

            // this keeps track of my offset for each tile I'm drawing onto the bitmap
            int x = 3;
            int y = 3;
            int numCurTile = 1;

            // rectangle to use when drawing the individual tiles
            RectangleF rect;

            // Load the tiles onto the bitmap
            foreach (Tile curTile in TileSet)
            {
                // if we've reached the end of the row increment y and reset x
                if (numCurTile > numTilesWide)
                {
                    numCurTile = 1;
                    y += 35;
                    x = 3;
                }

                if (curTile.Name.StartsWith("TERRAIN"))
                {
                    Bitmap MyBitmap = curTile.TileImage;
                    rect = new RectangleF(x, y, MyBitmap.Width, MyBitmap.Height);
                    g_TS.DrawImage(MyBitmap, rect);

                    // Now store the starting location for this tile into the tile object
                    curTile.X = x;
                    curTile.Y = y;

                    x += 35;
                    numCurTile++;
                }
            }
            g_TS.Dispose();
        }


        // Handle making a new map
        private void NewMap_Click(object sender, EventArgs e)
        {
            //int mapsize;

            NewMapDialog NewMapForm = new NewMapDialog();
            if (NewMapForm.ShowDialog() == DialogResult.OK)
            {
                mapsize = int.Parse(NewMapForm.MapSize);
                MapName = NewMapForm.MapName;
                this.Text = MapName;

                // Make sure the value was between 17-100
                if (mapsize < 17 || mapsize > 60)
                {
                    MessageBox.Show("The map size you entered was incorrect", "ERROR!");
                    return;
                }

                MapArray = new Tile[mapsize, mapsize];

                // Set the image locations for the tiles
                int xpos = 1;
                int ypos = 1;
                for (int i = 0; i < mapsize; i++)
                {
                    for (int j = 0; j < mapsize; j++)
                    {
                        MapArray[i, j] = new Tile(TileSet[BackgroundTileIndex].TileImage, TileSet[BackgroundTileIndex].Name, xpos, ypos);
                        xpos += 33;
                    }
                    xpos = 1;
                    ypos += 33;
                }

                // now we need to create the map
                int MapImageWidth = (mapsize * 32) + ((mapsize - 1) * 1);
                int MapImageHeight = MapImageWidth;

                Size mapPixelSize = new Size(MapImageWidth, MapImageHeight);
                pan_MapWindow.AutoScrollMinSize = mapPixelSize;

                // Create a new bitmap to draw the map onto
                MapImage = new Bitmap(MapImageWidth, MapImageHeight, PixelFormat.Format32bppRgb);

                // Get a graphic context from the image so we can draw to it
                Graphics g_TS = Graphics.FromImage(MapImage);

                // Clear out the image to be all white
                Rectangle background = new Rectangle(0, 0, MapImageWidth, MapImageHeight);
                SolidBrush myBrush = new SolidBrush(Color.White);
                g_TS.FillRectangle(myBrush, background);

                // Now loop through and print vertical and horizontal lines
                xpos = 0;
                ypos = 0;
                Pen myPen = new Pen(Color.Black, 1);

                // vertical lines
                for (int i = 0; i < mapsize; i++)
                {
                    g_TS.DrawLine(myPen, xpos, ypos, xpos, MapImageHeight);
                    xpos += 33;
                }
                xpos = 0;
                // Horizontal lines
                for (int i = 0; i < mapsize; i++)
                {
                    g_TS.DrawLine(myPen, xpos, ypos, MapImageWidth, ypos);
                    ypos += 33;
                }

                // Draw the base map, which is currently defaulted to grass tiles
                // loop through all the tiles and find which one was clicked
                for (int i = 0; i < mapsize; i++)
                    for (int j = 0; j < mapsize; j++)
                        AddTileToMap(i, j);

                g_TS.Dispose();
                MapCreated = true;
                pan_MapWindow.Invalidate();
            }
        }

        // This function paints into the Tiles panel
        private void pan_Tiles_Paint(object sender, PaintEventArgs e)
        {
            Size Offset = new Size(pan_Tiles.AutoScrollPosition);
            Graphics g = e.Graphics;
            g.DrawImage(TileSetImage, 0 + Offset.Width, 0 + Offset.Height);
            g.Dispose();
        }

        // Find out which tile the user clicked on and set it as the active Tile
        private void pan_Tiles_MouseClick(object sender, MouseEventArgs e)
        {
            int index = 0;

            // loop through all the tiles and find which one was clicked
            foreach (Tile myTile in TileSet)
            {
                if (myTile.TileClicked(e.X, e.Y))
                {
                    SelectedTileIndex = index;
                    pb_CurTile.Image = TileSet[SelectedTileIndex].TileImage;
                    return;
                }
                index++;
            }
        }

        private void pan_Map_Paint(object sender, PaintEventArgs e)
        {
            if (MapImage != null)
            {
                Size Offset = new Size(pan_MapWindow.AutoScrollPosition);
                Graphics g = e.Graphics;
                g.DrawImageUnscaled(MapImage, 0 + Offset.Width, 0 + Offset.Height);
                g.Dispose();
            }
            else
            {
                // the image is null so paint a white image as the background
                Graphics g = e.Graphics;
                Rectangle myrect = new Rectangle(0, 0, pan_MapWindow.Width, pan_MapWindow.Height);
                SolidBrush myBrush = new SolidBrush(Color.White);
                g.FillRectangle(myBrush, myrect);
                g.Dispose();
            }
        }

        // The user clicked in the map window
        private void pan_MapWindow_MClick(object sender, MouseEventArgs e)
        {
            // Make sure we have a map open
            if (!MapCreated)
                return;

            // If we're editing terrain add the current tile to the tile clicked on
            if (CurrentState == MapEditorState.Terrain)
            {

                Size Offset = new Size(pan_MapWindow.AutoScrollPosition);

                // loop through all the tiles and find which one was clicked
                for (int i = 0; i < mapsize; i++)
                {
                    for (int j = 0; j < mapsize; j++)
                    {
                        if (MapArray[i, j].TileClicked(e.X - Offset.Width, e.Y - Offset.Height))
                        {
                            MapArray[i, j].TileImage = TileSet[SelectedTileIndex].TileImage;
                            MapArray[i, j].Name = TileSet[SelectedTileIndex].Name;
                            AddTileToMap(i, j);
                            pan_MapWindow.Invalidate();
                            return;
                        }
                    }
                }
            }

            // If we adding the player spawn
            if (CurrentState == MapEditorState.PlayerSpawn)
            {
                Size Offset = new Size(pan_MapWindow.AutoScrollPosition);

                // loop through all the tiles and find which one was clicked
                for (int i = 0; i < mapsize; i++)
                {
                    for (int j = 0; j < mapsize; j++)
                    {
                        if (MapArray[i, j].TileClicked(e.X - Offset.Width, e.Y - Offset.Height))
                        {
                            // Now that we found the clicked tile, add the player spawn
                            int playertileindex = TileSet.FindIndex(TileNamedPlayer);
                            MapArray[i, j].TileImage = TileSet[playertileindex].TileImage;
                            AddTileToMap(i, j);
                            pan_MapWindow.Invalidate();
                            PlayeySpawn.X = i;
                            PlayeySpawn.Y = j;
                            b_PlayerSpawn.Text = "Set Player Spawn Tile";
                            CurrentState = MapEditorState.Terrain;
                            lab_PlayerSpawn.Text = "Player Spawn: (" + PlayeySpawn.X + ", " + PlayeySpawn.Y + ")";
                            return;
                        }
                    }
                }
            }
        }

        private void AddTileToMap(int tileX, int tileY)
        {
            // Get a graphic context from the image so we can draw to it
            Graphics g_Map = Graphics.FromImage(MapImage);

            Bitmap MyBitmap = MapArray[tileX, tileY].TileImage;
            int x = MapArray[tileX, tileY].X;
            int y = MapArray[tileX, tileY].Y;
            RectangleF rect = new RectangleF(x, y, MyBitmap.Width, MyBitmap.Height);
            g_Map.DrawImage(MyBitmap, rect);
            g_Map.Dispose();
        }

        private void b_PlayerSpawn_Click(object sender, EventArgs e)
        {
            if (MapImage != null)
            {
                b_PlayerSpawn.Text = "Click on Tile to Set Spawn";
                CurrentState = MapEditorState.PlayerSpawn;
            }
        }

        // My Buffered Panel Class
        public class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.Opaque, true);
                this.UpdateStyles();
            }
        }

        // Search predicate returns true if a tile name is "Player"
        private static bool TileNamedPlayer(Tile mytile)
        {
            if (mytile.Name == "PLAYER")
                return true;
            else
                return false;
        }

        // The user wants to save the map
        private void Menu_SaveMap(object sender, EventArgs e)
        {
            string filename = MapName + ".map";

            // Instead of writing the file as an xml file, let's try to write a plain
            // text file
            StreamWriter myfile = new StreamWriter(filename, false);
            myfile.WriteLine("<RNMap>");
            myfile.WriteLine("\t<info>");
            myfile.WriteLine("\t\t<terrain-types>");

            // write out the terrain types
            foreach (TerrainType myterrain in MapTerrains)
            {
                string msg = string.Format("\t\t\t<item name=\"{0}\" char=\"{1}\" tile=\"{2}\" passable=\"{3}\"/>", myterrain.Name, myterrain.Symbol.ToString(), myterrain.TileName, myterrain.Passable.ToString());
                myfile.WriteLine(msg);
            }
            myfile.WriteLine("\t\t</terrain-types>");

            // write out the monster spawns
            myfile.WriteLine("\t\t<monster-spawns>");
            myfile.WriteLine("\t\t</monster-spawns>");

            // write out the map links
            myfile.WriteLine("\t\t<map-links>");
            myfile.WriteLine("\t\t</map-links>");

            // map name
            string s1 = "\t\t<name>" + MapName + "</name>";
            myfile.WriteLine(s1);

            // map size
            myfile.WriteLine("\t\t<size>");
            s1 = "\t\t\t<width>" + mapsize.ToString() + "</width>";
            myfile.WriteLine(s1);
            s1 = "\t\t\t<height>" + mapsize.ToString() + "</height>";
            myfile.WriteLine(s1);
            myfile.WriteLine("\t\t</size>");

            // player start position
            s1 = "\t\t\t<xpos>" + PlayeySpawn.X.ToString() + "</xpos>";
            myfile.WriteLine("\t\t<player-start>");
            myfile.WriteLine(s1);
            s1 = "\t\t\t<ypos>" + PlayeySpawn.Y.ToString() + "</ypos>";
            myfile.WriteLine(s1);
            myfile.WriteLine("\t\t</player-start>");

            myfile.WriteLine("\t</info>");

            // Print out the Terrain Data, actual map tile positions
            myfile.WriteLine("\t<terrain>");
            myfile.WriteLine("\t\t<![CDATA[");

            // now loop through the map data
            string tname;
            char mysymbol;
            for (int i = 0; i < mapsize; i++)
            {
                s1 = "\t\t";
                for (int j = 0; j < mapsize; j++)
                {
                    tname = MapArray[i, j].Name;
                    mysymbol = FindTileSymbol(tname);
                    s1 += mysymbol.ToString();
                }
                myfile.WriteLine(s1);
            }
            myfile.WriteLine("\t\t]]>");
            myfile.WriteLine("\t</terrain>");
            myfile.WriteLine("</RNMap>");

            // close the file
            myfile.Flush();
            myfile.Close();

            /*
            XmlTextWriter tw=new XmlTextWriter(filename,null);
            tw.Formatting=Formatting.Indented;
            tw.WriteStartDocument();   
            tw.WriteStartElement("RNMap");			
            tw.WriteStartElement("info");

            tw.WriteStartElement("terrain-types");
            foreach (TerrainType myterrain in MapTerrains)
            {
                tw.WriteStartElement("item");
                tw.WriteAttributeString("name", myterrain.Name);
                tw.WriteAttributeString("char", myterrain.Symbol.ToString());
                tw.WriteAttributeString("tile", myterrain.TileName);
                tw.WriteAttributeString("passable", myterrain.Passable.ToString());
                tw.WriteEndElement();
            }
            tw.WriteEndElement(); // end terrain-types

            tw.WriteStartElement("monster-spawns");
            tw.WriteEndElement(); // end monster-spawns

            tw.WriteStartElement("map-links");
            tw.WriteEndElement(); // end map-links

            tw.WriteStartElement("name");
            tw.WriteString(MapName);
            tw.WriteEndElement(); // end name

            // write out the map size
            tw.WriteStartElement("size");
            tw.WriteStartElement("width");
            tw.WriteString(mapsize.ToString());
            tw.WriteEndElement(); // end width
            tw.WriteStartElement("height");
            tw.WriteString(mapsize.ToString());
            tw.WriteEndElement(); // end height
            tw.WriteEndElement(); // end size

            // write out the player start position
            tw.WriteStartElement("player-start");
            tw.WriteStartElement("xpos");
            tw.WriteString(PlayeySpawn.X.ToString());
            tw.WriteEndElement(); // end xpos
            tw.WriteStartElement("ypos");
            tw.WriteString(PlayeySpawn.Y.ToString());
            tw.WriteEndElement(); // end ypos
            tw.WriteEndElement(); // end player-start
            
            tw.WriteEndElement(); // end info
            
            // Write map data here
            tw.WriteStartElement("terrain");
            tw.WriteCData("test");
            tw.WriteEndElement(); // end terrain

            tw.WriteEndElement(); // end RNMap
            
            tw.WriteEndDocument();			
            tw.Flush();
            tw.Close();
             * */

        }

        // Given a specific tile name this function returns the map symbol for that tile
        private char FindTileSymbol(string TileName)
        {
            foreach (TerrainType myterrain in MapTerrains)
            {
                if (myterrain.TileName == TileName)
                    return myterrain.Symbol;
            }
            return ' ';
        }





    }
}