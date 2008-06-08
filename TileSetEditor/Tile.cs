using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TileSetEditor
{
    /*
    * Information for Tiles:
    *
    * Tile Image
    * Name
    * ID Number
    * Layer (Terrain, Structure, Unit)
    * Type (Shallow Water, Deep Water, Mountain, Plain, Road) - This would be used for 
    *    bonuses for units fighting on certain types, as well as whether a unit can move 
    *    onto that tile.
    */
    [Serializable]
    public class Tile
    {
        // Define enums for TileLayer and TileType
        public enum TileLayer { Terrain = 1, Structure = 2, Unit = 3 }
        public enum TileType { Road = 1, Plain = 2, Mountain = 3, ShallowWater = 4, DeepWater = 5 }

        // Bitmap surface to store tile image on
        private Bitmap iTileImage;
        public Bitmap TileImage
        {
            get { return iTileImage; }
            set { iTileImage = value; }
        }

        // Tile ID Number
        private int iID;
        public int ID
        {
            get { return iID; }
            set { iID = value; }
        }

        // Layer (1 = terrain, 2 = structure, 3 = unit)
        private TileLayer iLayer;
        public TileLayer Layer
        {
            get { return iLayer; }
            set { iLayer = value; }
        }

        // Type (1 = road, 2 = plain, 3 = mountain, 4 = shallowwater, 5 = deepwater)
        private TileType iType;
        public TileType Type
        {
            get { return iType; }
            set { iType = value; }
        }

        // Tile name from file
        private string iName = "";
        public string Name
        {
            get { return iName; }
            set { iName = value; }
        }

        // X and Y locations of the tile
        private int iX = 0;
        public int X
        {
            get { return iX; }
            set { iX = value; }
        }
        private int iY = 0;
        public int Y
        {
            get { return iY; }
            set { iY = value; }
        }

        // Tile Width
        private int iWidth = 0;
        public int Width
        {
            get { return iWidth; }
            set { iWidth = value; }
        }

        // Tile Height
        private int iHeight = 0;
        public int Height
        {
            get { return iHeight; }
            set { iHeight = value; }
        }

        // Tile Team if applicable, 0 = does not apply, 1 = red, 2 = blue, 3 = neutral
        private int iTeam = 0;
        public int Team
        {
            get { return iTeam; }
            set { iTeam = value; }
        }

        public Tile(Bitmap tileimage, string tilename, int tileID, TileLayer tileLayer,
                    TileType tileType, int x, int y, int width, int height, int team)
        {
            iTileImage = tileimage;
            iName = tilename;
            iID = tileID;
            iLayer = tileLayer;
            iType = tileType;
            iX = x;
            iY = y;
            iWidth = width;
            iHeight = height;
            iTeam = team;
        }

        // check if point Mx, My is within the tile image
        public bool TileClicked(int Mx, int My)
        {
            int maxX = iX + 32;
            int maxY = iY + 32;

            if (Mx >= iX && Mx <= maxX && My >= iY && My <= maxY)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return iName;
        }
    }
}
