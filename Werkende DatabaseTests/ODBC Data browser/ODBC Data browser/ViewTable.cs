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
    public partial class ViewTable : Form
    {
        private readonly OdbcConnection _odbcConnection;
        private readonly string _selectedTable;

        public ViewTable(OdbcConnection odbcConnection, string selectedTable)
        {
            InitializeComponent();

            _odbcConnection = odbcConnection;
            _selectedTable = selectedTable;
        }

        private void ViewTable_Load(object sender, EventArgs e)
        {
            using (OdbcCommand cmd = _odbcConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM " + _selectedTable;

                using (OdbcDataReader reader = cmd.ExecuteReader())
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
