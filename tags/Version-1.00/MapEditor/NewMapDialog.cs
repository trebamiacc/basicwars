using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class NewMapDialog : Form
    {
        public string MapSize
        {
            get { return tb_MapSize.Text; }
        }
        public string MapName
        {
            get { return tb_MapName.Text; }
        }

        public NewMapDialog()
        {
            InitializeComponent();
        }
    }
}