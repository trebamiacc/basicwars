using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MapEditor
{
    public class Tile
    {
        // Bitmap surface to store tile image on
        private Bitmap iTileImage;
        public Bitmap TileImage
        {
            get { return iTileImage; }
            set { iTileImage = value; }
        }

        // Abbreviated Tile name from file
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

        public Tile(Bitmap tileimage, string tilename, int x, int y)
        {
            iTileImage = tileimage;
            Name = tilename;
            iX = x;
            iY = y;
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
    }
}
