using System;
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
        private SQLiteConnection _sqLiteConnection;

        public UserManagement()
        {
            InitializeComponent();

            _sqLiteConnection = Settings.GetSqLiteConnection();

            MessageBox.Show("The SqLite connection is: " + _sqLiteConnection.State);
        }

        private async void OpenSqLiteConnection()
        {
            await _sqLiteConnection.OpenAsync();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnJoinGroup_Click(object sender, EventArgs e)
        {

        }

        private void btnLeaveGroup_Click(object sender, EventArgs e)
        {

        }
    }
}
