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
    public partial class searchBox : Form
    {
        public TextBox txtBox;
        public bool demoData;

        public searchBox(TextBox txtBox)
        {
            this.txtBox = txtBox;
            InitializeComponent();
            txtBoxSearch.Enabled = false;
            pictureBoxSearch.Enabled = false;
            checkedListBoxResultaten.Enabled = false;
            buttonOk.Enabled = false;

        }

        private void checkedListBoxResultaten_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void lstBoxDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxSearch.Enabled = true;
            txtBoxSearch.Focus();
            txtBoxSearch.SelectAll();
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            checkedListBoxResultaten.Enabled = true;
            if (!demoData)
            {
                checkedListBoxResultaten.Items.AddRange(new object[]
                {
                    "extruder1temp",
                    "extruder2temp",
                    "extruder3temp",
                    "extruder4temp"
                });
                demoData = true;
            }
        }

        public List<String> getRusultString()
        {
            List<String> returnList = new List<string>();
            foreach (object itemChecked in checkedListBoxResultaten.CheckedItems)
            {
                // Use the IndexOf method to get the index of an item.
                returnList.Add(itemChecked.ToString());
            }
            return returnList;
        }

        public TextBox getTextBox()
        {
            return txtBox;
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //als er op enter is gedrukt
            {

                //als er op search wordt geklik:
                //query runnen: SELECT `COLUMN_NAME` From INFORMATION_SCHEMA.COLUMNS Where column_name LIKE '%txtBoxSearch%'
                //AND TABLE_SCHEMA = "lstBoxDatabases.selectedtext ofzo"
                //resultaten loopen en in checkedListBoxResultaten zetten. (via item.add ofzo)
                var query = "SELECT `COLUMN_NAME` as name FROM INFORMATION_SCHEMA.COLUMNS Where column_name LIKE '%" + txtBoxSearch.Text + "%' AND TABLE_SCHEMA = '" + lstBoxDatabases.Text + "' limit 250";
                MessageBox.Show(query);

                /* DbODBC db = new DbODBC(DbManagerBase.DB_ODBC, "tald");
                 DataTable data = db.select("`name` FROM `table`");

                 // Loop through results.
                 foreach (DataRow row in dt.Rows)
                 {
                     checkedListBoxResultaten.Items.Add(row["name"].ToString());
                 } */
            }
        }
    }
}
