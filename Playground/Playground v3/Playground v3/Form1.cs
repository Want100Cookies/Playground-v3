﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playground_v3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDatabase selectDatabase= new SelectDatabase();
            selectDatabase.Show();
        }
    }
}