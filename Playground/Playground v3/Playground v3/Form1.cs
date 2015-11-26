using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;
using Playground_v3.Properties;

namespace Playground_v3
{
    public partial class Form1 : Form
    {
        /*
         * variabele waarin de huidige rij is opgeslagen. Dit wordt gebruikt bij het genereren van rijen, en de zoekfunctie.
         */
        public int row;
        public int defaultOffset;
        public int regelAfstand; //var die het aantal points (=afstand) tussen twee regels bijhoudt.

        private Dictionary<PictureBox, TextBox> koppelDictionary;
            //veld die helpt bij het koppelen van search icons en tekstvelden.

        private Dictionary<int, TextBox> fieldDictionary;
       //veld die helpt bij het koppelen van de textbox aan een nummer.

        public Form1()
        {
            InitializeComponent();
            //formules maken scherm:
            //gui init
            comboBoxOperator1.SelectedIndex = 0;
            comboBoxOperator2.SelectedIndex = 0;
            comboBoxOperator3.SelectedIndex = 0;

            //hide components:
            textBoxColumnname2.Visible = false;
            pictureBoxSearch2.Visible = false;
            comboBoxOperator3.Visible = false;
            numericUpDownRecords2.Visible = false;
            labelColumnname2.Visible = false;
            labelData2.Visible = false;
            labelAmountRecords2.Visible = false;

            row = 1;
            defaultOffset = 50;
            regelAfstand = 60;
            koppelDictionary = new Dictionary<PictureBox, TextBox>();
            fieldDictionary = new Dictionary<int, TextBox>();

            newLine();

            koppelDictionary.Add(pictureBoxSearch, textBoxColumnname);
            koppelDictionary.Add(pictureBoxSearch2, textBoxColumnname2);
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDatabase selectDatabase = new SelectDatabase();
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
                labelData2.Visible = false;
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
                labelData2.Visible = true;
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
            searchBox form = new searchBox(koppelDictionary[(PictureBox) sender]);
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

        ///<summary>
        /// Methode die een nieuwe formuleregel maakt. Met daarin eventueel waardes die ingevuld kunnen worden.
        ///</summary>
        public void newLine(string kolomnaam = "", string amount="", string operatorSoort = "", string operatorValue = "", string kolomnaam2 = "", string amount2 = "")
        {
            
        
            //methode die nieuwe lijn maakt.
            //de textboxes worden opgeslagen in een dictionary<TextBox, int>
            //de int bestaat uit de lijn: 1 tiental voor de 1e lijn, 2 tientallen voor de 2e lijn enz.
            //de eentallen in de int representeerd de 1e- of 2e textbox van de rij.
            //je krijgt dus iets als 22 (2e rij, 2e textbox)
            //of 11: (1e rij 1e textbox).
            //note: in eerste instantie is in deze de dictionary hardcoded erin gezet.
            //TODO: newline methode maken.

            //column name 1:
            TextBox columnname = new TextBox();
            columnname.Location = new Point(3, row * regelAfstand);
            columnname.Name = "textBoxColumnname" + row;
            columnname.Size = new Size(145, 22);
            columnname.Text = kolomnaam;
            panelFormulaControls.Controls.Add(columnname);

            //picturebox:
            PictureBox picSearch1 = new PictureBox();
            picSearch1.BackColor = Color.White;
          
            picSearch1.Location = new Point(194, row * regelAfstand);
            picSearch1.Name = "pictureBox + " + row;
            picSearch1.Cursor = Cursors.Hand;
            picSearch1.Size = new Size(50, 22);
            picSearch1.SizeMode = PictureBoxSizeMode.Zoom;
            picSearch1.Image = Resources._1426093958_common_search_lookup__128;
            panelFormulaControls.Controls.Add(picSearch1);
            picSearch1.Click += pictureBoxSearch_Click;
            //koppeldictionary columnName1 en picturebox toevoegen:
            koppelDictionary.Add(picSearch1, columnname);

            //combobox operator 1:
            ComboBox comboB1 = new ComboBox();
            comboB1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboB1.Items.AddRange(new object[] {
            "Most recent",
            "Average"});
            comboB1.Location = new Point(250, row * regelAfstand);
            comboB1.Name = "comboBoxOperator1";
            comboB1.Size = new Size(100, 24);
            //TODO: een gedeelde event handler maken voor de combobox:
            //note: nu staat het er hardcoded in.
            comboB1.SelectedIndexChanged += comboBoxOperator1_SelectedIndexChanged;
            comboB1.SelectedIndex = 0;
            panelFormulaControls.Controls.Add(comboB1);

            //numeric up down records:
            NumericUpDown numUpDown = new NumericUpDown();
            numUpDown.Enabled = false;
            numUpDown.Location = new System.Drawing.Point(383, row * regelAfstand);
            numUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            numUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            numUpDown.Name = "numUpDown" + row;
            numUpDown.Size = new Size(101, 22);
            numUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            panelFormulaControls.Controls.Add(numUpDown);

            //combobox2
            ComboBox combob2 = new ComboBox();
            combob2.DropDownStyle = ComboBoxStyle.DropDownList;
            combob2.FormattingEnabled = true;
            combob2.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            ">=",
            "<=",
            "≠"});
            combob2.Location = new Point(490, row * regelAfstand);
            combob2.Name = "combob2" + row + "2";
            combob2.Size = new Size(68, 24);
            combob2.SelectedIndex = 0;
            panelFormulaControls.Controls.Add(combob2);

            //textBoxValue
            TextBox textBoxVal = new TextBox();
            textBoxVal.Location = new Point(564, row * regelAfstand);
            textBoxVal.Name = "textBoxValue" + row;
            textBoxVal.Size = new Size(100, 22);
            panelFormulaControls.Controls.Add(textBoxVal);

            //TODO: meer form controls toevoegen.
            //textBoxColumnname2:
            TextBox textBoxCol2 = new TextBox();
            textBoxCol2.Location = new Point(668, row * regelAfstand);
            textBoxCol2.Name = "textBoxColumnname" + row + 2;
            textBoxCol2.Size = new Size(187, 22);
            panelFormulaControls.Controls.Add(textBoxCol2);

            //pictureboxSearch2:
            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Playground_v3.Properties.Resources._1426093958_common_search_lookup__128;
            pictureBox2.Location = new Point(859, row * regelAfstand);
            pictureBox2.Name = "pictureBoxSearch2";
            pictureBox2.Size = new Size(50, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBoxSearch_Click;
            panelFormulaControls.Controls.Add(pictureBox2);

            //pictureboxSearch 2 koppelen aan textBoxColumnName2:
            koppelDictionary.Add(pictureBox2, textBoxCol2);

            //comboBoxOperator3: gelijk aan comboBoxOperator1
            ComboBox comboB2 = new ComboBox();
            comboB2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboB2.Items.AddRange(new object[] {
            "Most recent",
            "Average"});
            comboB2.Location = new Point(915, row * regelAfstand);
            comboB2.Name = "comboBoxOperator1";
            comboB2.Size = new Size(121, 24);
            //TODO: een gedeelde event handler maken voor de combobox:
            //note: nu staat het er hardcoded in.
            comboB2.SelectedIndexChanged += comboBoxOperator1_SelectedIndexChanged;
            comboB2.SelectedIndex = 0;
            panelFormulaControls.Controls.Add(comboB2);

            //numeric up down records2:
            NumericUpDown numUpDown2 = new NumericUpDown();
            numUpDown2.Enabled = false;
            numUpDown2.Location = new System.Drawing.Point(1042, row * regelAfstand);
            numUpDown2.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            numUpDown2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            numUpDown2.Name = "numUpDown" + row + "2";
            numUpDown2.Size = new Size(101, 22);
            numUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            panelFormulaControls.Controls.Add(numUpDown2);



            row++;
        }

        /**
        * sla de formule op.
        * vraag: hoe wordt ervoor gezorgd dat er meerdere formule nodes komen?
        */
        private void btnSaveFormula_Click(object sender, EventArgs e)
        {
            if (canSave())
            {
                var soort1 = radioButtonAbsolute.Checked;
                XmlDocument doc = new XmlDocument();
                XmlElement formule = doc.CreateElement("formule");

                XmlElement regel = doc.CreateElement("regel");
                //controleren of soort is 1 of soort is 2.
                XmlElement soort = doc.CreateElement("soort");
                soort.InnerText = soort1 ? "1" : "2";

                XmlElement kolomnaam = doc.CreateElement("kolomnaam");
                kolomnaam.InnerText = textBoxColumnname.Text;

                XmlElement type = doc.CreateElement("type");
                //als type is gemiddelde: dan attribuut waarde verandren
                if (comboBoxOperator1.SelectedIndex == 0)
                {
                    type.SetAttribute("amount", "");
                }
                else
                {
                    type.SetAttribute("amount", numericUpDownRecords.Text);
                }
                XmlElement operatorEl = doc.CreateElement("operator");
                operatorEl.SetAttribute("soort", comboBoxOperator2.SelectedIndex.ToString());
                //als soort is 1, dan:
                if (soort1)
                {
                    operatorEl.InnerText = textBoxValue.Text;
                }
                else
                {
                    //anders:
                    XmlElement kolomnaam2 = doc.CreateElement("kolomnaam2");
                    kolomnaam2.InnerText = textBoxColumnname2.Text;
                    formule.AppendChild(kolomnaam2);
                }

                XmlElement type2 = doc.CreateElement("type2");
                //als type is gemiddelde: dan attribuut waarde verandren
                if (comboBoxOperator3.SelectedIndex == 0)
                {
                    type2.SetAttribute("amount", "");
                }
                else
                {
                    type2.SetAttribute("amount", numericUpDownRecords2.Text);
                }

                formule.AppendChild(regel);
                regel.AppendChild(soort);
                regel.AppendChild(kolomnaam);
                regel.AppendChild(type);
                regel.AppendChild(operatorEl);
                if (!soort1)
                {
                    regel.AppendChild(type2);
                }

                doc.AppendChild(formule);

               // doc.Save("formule1test.xml");
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "XML files|*.xml";
                saveFileDialog1.Title = "Save an XML formula file";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    doc.Save(saveFileDialog1.FileName);
                }
            }
        }

        /**
        * functie die controleerd of het formulescherm dusdanig is ingevuld dat deze mag worden opgeslagen.
        * @return boolean. True als de formule mag worden opgeslagen
        * TODO: functie werkt niet, de child is geen textbox...
        */

        private bool canSave()
        {
            var canContinue = true;
            foreach (Control child in this.Controls)
            {
                if (child is TextBox)
                {
                    TextBox textbox = child as TextBox;
                    {
                        if (textbox.Enabled)
                        {
                            if (true)
                            {
                                textbox.BackColor = ColorTranslator.FromHtml("#ff3333");
                                canContinue = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("hij is niet enabled");
                        }
                    }
                }
                else
                {
                 //   MessageBox.Show("geen textbox");
                }
            }

            if (!canContinue)
            {
                    MessageBox.Show("Please fill in all the textfields.");
                    return false;
            }

            return true;
            }

        private void buttonOpenFormula_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files|*.xml";
            openFileDialog.Title = "Open an XML formula file";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (openFileDialog.FileName != "")
            {
                  MessageBox.Show(openFileDialog.FileName);

                var doc = new XmlDocument();
                doc.Load(openFileDialog.FileName);
                MessageBox.Show(doc.SelectSingleNode("formule/type").Attributes[0].Value.GetType().ToString());
            }
        }

        private void buttonNewLine_Click(object sender, EventArgs e)
        {
            newLine();
        }
    }
    }

