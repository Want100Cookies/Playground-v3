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
    public partial class Form1 : Form
    {
        /*
         * variabele waarin de huidige rij is opgeslagen. Dit wordt gebruikt bij het genereren van rijen, en de zoekfunctie.
         */
        public int row;

        public Form1()
        {
            InitializeComponent();
            //formules maken scherm:
            //gui init
            comboBoxOperator1.SelectedIndex = 0;
            comboBoxOperator3.SelectedIndex = 0;

            //hide components:
            textBoxColumnname2.Visible = false;
            pictureBoxSearch2.Visible = false;
            comboBoxOperator3.Visible = false;
            numericUpDownRecords2.Visible = false;
            labelColumnname2.Visible = false;
            labelOperator2.Visible = false;
            labelAmountRecords2.Visible = false;

            row = 1;
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDatabase selectDatabase= new SelectDatabase();
            selectDatabase.Show();
        }

        private void comboBoxOperator1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOperator1.SelectedIndex == 1)
            {
                numericUpDownRecords.Enabled = true;
            }
            else
            {
                numericUpDownRecords.Enabled = false;
            }
        }


        private void pictureBoxSearch2_Click(object sender, EventArgs e)
        {
            pictureBoxSearch_Click_1(sender, e);
        }

        private void radioButtonValue_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonValue.Checked)
            {
                //hide components:
                textBoxColumnname2.Visible = false;
                pictureBoxSearch2.Visible = false;
                comboBoxOperator3.Visible = false;
                numericUpDownRecords2.Visible = false;
                labelColumnname2.Visible = false;
                labelOperator2.Visible = false;
                labelAmountRecords2.Visible = false;
            }
            else
            {
                //show components:
                textBoxColumnname2.Visible = true;
                pictureBoxSearch2.Visible = true;
                comboBoxOperator3.Visible = true;
                numericUpDownRecords2.Visible = true;
                labelColumnname2.Visible = true;
                labelOperator2.Visible = true;
                labelAmountRecords2.Visible = true;
            }
        }

        private void comboBoxOperator3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOperator3.SelectedIndex == 1)
            {
                numericUpDownRecords2.Enabled = true;
            }
            else
            {
                numericUpDownRecords2.Enabled = false;
            }
        }

        private void pictureBoxSearch_Click_1(object sender, EventArgs e)
        {
            searchBox form = new searchBox();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                form.Close();
            }
            else if (form.DialogResult == DialogResult.OK)
            {
                foreach (var str in form.getRusultString())
                {
                    //add formule rij
                    if (true) //links
                    {
                        String name = textBoxColumnname + row.ToString();
                        textBoxColumnname.Text = str;
                    }
                }
            }
        }
    }
}
