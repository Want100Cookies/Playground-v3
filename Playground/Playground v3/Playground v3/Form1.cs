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
        private Dictionary<PictureBox, TextBox> koppelDictionary;

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
            koppelDictionary=new Dictionary<PictureBox, TextBox>();

            koppelDictionary.Add(pictureBoxSearch, textBoxColumnname);
            koppelDictionary.Add(pictureBoxSearch2, textBoxColumnname2);
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
                textBoxValue.Enabled = true;
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
                textBoxValue.Enabled = false;
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

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            searchBox form = new searchBox(koppelDictionary[(PictureBox)sender]);
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
                    form.getTextBox().Text = str;
                }
            }
        }

        public void newLine()
        {
            //methode die nieuwe lijn maakt.
            //de textboxes worden opgeslagen in een dictionary<TextBox, int>
            //de int bestaat uit de lijn: 1 tiental voor de 1e lijn, 2 tientallen voor de 2e lijn enz.
            //de eentallen in de int representeerd de 1e- of 2e textbox van de rij.
            //je krijgt dus iets als 22 (2e rij, 2e textbox)
            //of 11: (1e rij 1e textbox).
            //note: in eerste instantie is in deze de dictionary hardcoded erin gezet.
        }
    }
}
