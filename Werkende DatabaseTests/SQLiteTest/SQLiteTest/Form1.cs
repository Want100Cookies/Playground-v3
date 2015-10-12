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

namespace SQLiteTest
{
    public partial class Form1 : Form
    {
        // Holds the SQLite DB connection that will open every once in a while to retr. data.
        private SQLiteConnection sqliteConn;

        public Form1()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Sets up the SQLite DB connection from the opened file.
        /// </summary>
        /// <param name="path"></param>
        private void createSqLiteConn(string path)
        {
            this.sqliteConn = new SQLiteConnection("data source=" + path);
        }


        /// <summary>
        /// Shows an open file dialog with the only option to open the SQLite file.
        /// To-do: Copying the file to a local spot on the PC (cache).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenSQLiteFile_Click(object sender, EventArgs e)
        {
            // Show open file dialog.
            if (openSQLiteFile.ShowDialog() == DialogResult.OK)
            {
                // Get full file path.
                string dbPath = openSQLiteFile.FileName;

                // Set up the DB connection...
                this.createSqLiteConn(dbPath);
            }
            else // Show error if cancel was clicked and exit (it's worthless without a DB anyway).
            {
                MessageBox.Show("This program cannot function without this database. Exiting...");
                Application.Exit();
            }
        }

        
        /// <summary>
        /// An example application that shows how to open the database and read off of it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrGroups_Click(object sender, EventArgs e)
        {
            // Setup a commander and open connection.
            SQLiteCommand cmd = new SQLiteCommand(this.sqliteConn);
            this.sqliteConn.Open();

            // Setup query.
            cmd.CommandText = "SELECT * FROM groups";

            // Fetch queried data and loop over it.
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // SQLite rows must be read by static column IDs (no strings).
                // e.g.: Table layout is id | name | is_admin
                // The order is 0 for id, 1 for name etc. etc.
                int groupId = reader.GetInt32(0);
                string groupName = reader.GetString(1);

                // Show a fancy box ;)
                MessageBox.Show(groupId.ToString() + " - " + groupName);
            }

            // Close DB connection to preserve I/O bandwidth.
            this.sqliteConn.Close();
        }
    }
}
