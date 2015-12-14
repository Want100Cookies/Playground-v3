using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Data_browser
{
    public partial class SelectDatabase : Form
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;

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

            _sqlConnection = new SqlConnection(_connectionString);

            if (await OpenSqlDatabaseConnection())
            {
                MessageBox.Show("Connection succesfully established.");

                SelectTable selectTableForm = new SelectTable(_sqlConnection);
                selectTableForm.Show(this);
                this.Hide();
            }
        }

        private async Task<bool> OpenSqlDatabaseConnection()
        {
            try
            {
                await _sqlConnection.OpenAsync();
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
