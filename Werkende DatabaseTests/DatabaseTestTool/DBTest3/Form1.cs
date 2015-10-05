using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTest3
{
    public partial class form1 : Form
    {
        string connectionString = null;
        OdbcConnection cnn;

        public form1()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;
            cnn = new OdbcConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string query = "select * from naw";
                string query = "select * from usr_vw_job_EMM";
                cnn.Open();
                MessageBox.Show("Connection Open ! ");

                OdbcDataAdapter dadapter = new OdbcDataAdapter();
                dadapter.SelectCommand = new OdbcCommand(query, cnn);
                DataTable table = new DataTable();
                dadapter.Fill(table);
                
                MessageBox.Show("Data opgehaald!");
                cnn.Close();

                this.dataGridView1.DataSource = table;
                MessageBox.Show("Data geplaatst in grid!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 settingsForm = new Form2();
            settingsForm.Show();
        } 
    }
}