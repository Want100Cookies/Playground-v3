using System;
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

            // Todo: move this to some sort of loading screen
            Settings.CheckConfigFileExists();

            List<string> funcList = new List<string>
            {
                "Database Configuration",
                "User management",
            };
            Auth.Init(funcList);
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HasAccessTo("Database Configuration")) return;
            SelectDatabase selectDatabase = new SelectDatabase();
            selectDatabase.Show(this);
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!Auth.HasAccessTo("User management")) return;
            UserManagement userManagement = new UserManagement();
            userManagement.Show(this);
        }
    }
}
