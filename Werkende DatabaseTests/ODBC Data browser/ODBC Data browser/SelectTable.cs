using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Odbc;

namespace ODBC_Data_browser
{
    public partial class SelectTable : Form
    {
        private readonly OdbcConnection _odbcConnection;

        public SelectTable(OdbcConnection odbcConnection)
        {
            InitializeComponent();

            _odbcConnection = odbcConnection;
        }

        private void SelectTable_Load(object sender, EventArgs e)
        {
            using (DataTable tableschema = _odbcConnection.GetSchema("TABLES"))
            {
                // first column name
                foreach (DataRow row in tableschema.Rows)
                {
                    lstBoxTables.Items.Add(row["TABLE_NAME"].ToString());
                }
            }
        }

        private void SelectTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            _odbcConnection.Close();
            Application.Exit();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ViewTable viewTableForm = new ViewTable(_odbcConnection, lstBoxTables.SelectedItem.ToString());
            viewTableForm.ShowDialog(this);
        }
    }
}
