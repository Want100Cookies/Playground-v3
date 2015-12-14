using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQL_Data_browser
{
    public partial class ViewTable : Form
    {
        private readonly SqlConnection _sqlConnection;
        private readonly string _selectedTable;

        public ViewTable(SqlConnection sqlConnection, string selectedTable)
        {
            InitializeComponent();

            _sqlConnection = sqlConnection;
            _selectedTable = selectedTable;
        }

        private void ViewTable_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = _sqlConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM " + _selectedTable;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int fieldCount = reader.FieldCount;

                    for (int i = 0; i < fieldCount; i++)
                    {
                        dataGrid.Columns.Add(reader.GetName(i), reader.GetName(i));
                    }

                    MessageBox.Show("Does this column has rows: " + reader.HasRows);

                    while (reader.Read())
                    {
                        DataGridViewRow newRow = new DataGridViewRow();

                        for (int i = 0; i < fieldCount; i++)
                        {
                            DataGridViewCell newCell = new DataGridViewTextBoxCell();
                            newCell.Value = reader.GetValue(i);
                            newCell.ValueType = reader.GetFieldType(i);
                            newRow.Cells.Add(newCell);
                            newCell.ReadOnly = true;
                        }

                        dataGrid.Rows.Add(newRow);
                    }
                }
            }
        }
    }
}
