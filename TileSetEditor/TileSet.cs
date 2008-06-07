using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace TileSetEditor
{
    [Serializable]
    public class TileSet
    {
        private string iName;
        public string Name
        {
            get { return iName; }
            set { iName = value; }
        }

        private List<Tile> iTiles = new List<Tile>();
        public List<Tile> Tiles
        {
            get { return iTiles; }
            set { iTiles = value; }
        }

        // Function to serialize Tileset to a file
        public void Save( string FileName )
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        // Function to de-serialize Tileset from a file
        public void Load(string FileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            TileSet mySet = (TileSet)formatter.Deserialize(stream);
            iName = mySet.Name;
            iTiles = mySet.Tiles;
            stream.Close();
        }
    }
}
