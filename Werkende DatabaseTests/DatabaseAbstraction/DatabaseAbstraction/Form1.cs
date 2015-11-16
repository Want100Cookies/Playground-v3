using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAbstraction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Simple example select statement.
        /// Result: 2 messagebox popups (2 records present).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Specify database type and location.
            DbSQLite db = new DbSQLite(DbManagerBase.DB_SQLITE, @"D:\mydb.db");

            // Fetch all results of the query.
            DataTable dt = db.select("`name` FROM `test`");
            
            // Loop through results.
            foreach (DataRow row in dt.Rows)
            {
                MessageBox.Show(row["name"].ToString());
            }

            Dictionary<string, dynamic> d = new Dictionary<string, dynamic>();
            d.Add("@id", 23);
            d.Add("@name", "haha");
            db.insert("`test` (`id`,`name`) VALUES(?,?)", d);
        }
    }
}
