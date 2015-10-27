using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQL_Data_browser
{
    public partial class SelectTable : Form
    {
        private readonly SqlConnection _sqlConnection;

        public SelectTable(SqlConnection sqlConnection)
        {
            InitializeComponent();

            _sqlConnection = sqlConnection;
        }

        private void SelectTable_Load(object sender, EventArgs e)
        {
            using (DataTable tableschema = _sqlConnection.GetSchema("TABLES"))
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
            _sqlConnection.Close();
            Application.Exit();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ViewTable viewTableForm = new ViewTable(_sqlConnection, lstBoxTables.SelectedItem.ToString());
            viewTableForm.ShowDialog(this);
        }
    }
}
