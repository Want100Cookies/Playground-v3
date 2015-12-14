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
    public partial class SelectDatabase : Form
    {
        private string _connectionString;
        private OdbcConnection _odbcConnection;

        public SelectDatabase()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            _connectionString = txtConnectionString.Text;

            if (_connectionString == "")
            {
                MessageBox.Show("Please fill in a connection string");
                return;
            }

            _odbcConnection = new OdbcConnection(_connectionString);

            if (await OpenOdbcDatabaseConnection())
            {
                MessageBox.Show("Connection succesfully established.");

                SelectTable selectTableForm = new SelectTable(_odbcConnection);
                selectTableForm.Show(this);
                this.Hide();
            }
        }

        private async Task<bool> OpenOdbcDatabaseConnection()
        {
            try
            {
                await _odbcConnection.OpenAsync();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't open database connection. Error:\n" + e);
                return false;
            }
        }


    }
}
