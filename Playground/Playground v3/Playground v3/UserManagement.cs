﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playground_v3
{
    public partial class UserManagement : Form
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public UserManagement()
        {
            InitializeComponent();

            _sqLiteConnection = Settings.GetSqLiteConnection();
        }
    }
}
