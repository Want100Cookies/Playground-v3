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
    }
}
