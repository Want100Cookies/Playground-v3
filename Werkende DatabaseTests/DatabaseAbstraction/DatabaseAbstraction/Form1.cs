using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
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
            DbSQLite db = new DbSQLite(@"U:\mydb.db");

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

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectionStringSettings aTech = ConfigurationManager.ConnectionStrings["Aspen tech"];

            MessageBox.Show(aTech.ConnectionString);

            DbODBC db = new DbODBC(aTech.ConnectionString);

                                       
            DataTable data1 = db.select(@"SELECT NAME FROM IP_PVDEF ");
            //DataTable data = db.select(@"SET MAX_ROWS 10;");

           // MessageBox.Show(data.Rows.Count.ToString());
            MessageBox.Show(data1.Rows.Count.ToString());



            //foreach (DataRow row in data.Rows)
            //{
            //    MessageBox.Show("Name is: " + row["NAME"].ToString());
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConnectionStringSettings wonderWare = ConfigurationManager.ConnectionStrings["Wonderware"];

            DbSql db = new DbSql(wonderWare.ConnectionString);
            DataTable data = db.select("TABLE_NAME FROM MESDB.INFORMATION_SCHEMA.Tables");

            // Get all tables present in the database.
            foreach (DataRow tableNames in data.Rows)
            {
                // Loop through every table name...
                foreach(Object tableName in tableNames.ItemArray)
                {
                    MessageBox.Show(
                        null, 
                        "BEGIN SHOWING COLUMN HEADS FOR TABLE: " + tableName.ToString(), 
                        "INFO!", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation
                    );

                    //DataTable columns = db.select("COLUMN_NAME FROM MESDB.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=N'" + tableName.ToString() + "'");
                    DataTable tableData = db.select("* FROM " + tableName.ToString());
                    DataColumnCollection cols = tableData.Columns;
                    
                    foreach (DataColumn col in cols)
                    {
                        MessageBox.Show("COLUMN NAME: " + col.ColumnName);
                    } // End foreach
                } // End foreach
            } //End foreach
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectionStringSettings aTech = ConfigurationManager.ConnectionStrings["Aspen tech"];

            MessageBox.Show(aTech.ConnectionString);

            DbODBC db = new DbODBC(aTech.ConnectionString);
            DataTable data = db.select(sqlTxt.Text);

            MessageBox.Show(data.Rows.Count.ToString());

            foreach (DataRow row in data.Rows)
            {
                MessageBox.Show("Name is: " + row["NAME"].ToString());
            }
        }
    }
}