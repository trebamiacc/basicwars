using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileSetEditor
{
    public partial class TileSetEditor : Form
    {
        // Define enums for TileLayer and TileType
        enum TileLayer { Terrain = 1, Structure = 2, Unit = 3 }
        enum TileType { Road = 1, Plain = 2, Mountain = 3, ShallowWater = 4, DeepWater = 5 }

        public TileSetEditor()
        {
            InitializeComponent();
        }
    }
}