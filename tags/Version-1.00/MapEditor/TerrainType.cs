using System;
using System.Collections.Generic;
using System.Text;

namespace MapEditor
{
    public class TerrainType
    {
        private string iName = "";
        public string Name
        {
            get { return iName; }
            set { iName = value; }
        }
        private char iSymbol = '0';
        public char Symbol
        {
            get { return iSymbol; }
            set { iSymbol = value; }
        }
        private string iTileName = "";
        public string TileName
        {
            get { return iTileName; }
            set { iTileName = value; }
        }
        private bool iPassable = true;
        public bool Passable
        {
            get { return iPassable; }
            set { iPassable = value; }
        }

        public TerrainType(string name, char symbol, string tilename, bool passable)
        {
            iName = name;
            iSymbol = symbol;
            iTileName = tilename;
            iPassable = passable;
        }
    }
}
