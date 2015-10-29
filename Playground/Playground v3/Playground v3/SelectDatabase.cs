using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Playground_v3
{
    public partial class SelectDatabase : Form
    {

        public SelectDatabase()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            lstBoxDatabases.Items.Clear();

            foreach (ConnectionStringStruct connStruct in Settings.GetConnectionstringList())
            {
                lstBoxDatabases.Items.Add(connStruct.name);
            }
        }

        private static void OpenForm(string dbName)
        {
            DatabaseOptions databaseOptions = new DatabaseOptions(dbName);
            databaseOptions.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string dbName = lstBoxDatabases.SelectedItem.ToString();
            OpenForm(dbName);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenForm(null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Settings.RemoveConnectionString(lstBoxDatabases.SelectedItem.ToString());
            PopulateListBox();
        }
    }
}
