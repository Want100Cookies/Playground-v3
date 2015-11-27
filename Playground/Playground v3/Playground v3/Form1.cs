using System;
using System.CodeDom;
using System.Collections;
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

        private Dictionary<ComboBox, NumericUpDown> koppelDictionaryComboBox;

        //var die bijhoud hoeveel Radiobuttons er op value staan. Als dit groter is dan 0, moeten bepaalde labels visible zijn.
        private int CountRadioButtonsValue; 

        private Dictionary<RadioButton, IList<Control>> koppelDictionaryControls;

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
            koppelDictionaryControls = new Dictionary<RadioButton, IList<Control>>();
            koppelDictionaryComboBox = new Dictionary<ComboBox, NumericUpDown>();

            CountRadioButtonsValue = 0;

            newLine();

            koppelDictionary.Add(pictureBoxSearch, textBoxColumnname);
            koppelDictionary.Add(pictureBoxSearch2, textBoxColumnname2);
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDatabase selectDatabase = new SelectDatabase();
            selectDatabase.Show();
        }

        private void radioButtonValue_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked) 
            {
                //show components:
                hideOrShowComponents(radioButton, true);
                CountRadioButtonsValue++;
            }
            else
            {
                hideOrShowComponents(radioButton, false);
                if (CountRadioButtonsValue > 0)
                {
                    CountRadioButtonsValue--;
                }
            }

            if (CountRadioButtonsValue == 0)
            {
                labelColumnname2.Visible = false;
                labelData2.Visible = false;
                labelAmountRecords2.Visible = false;
            }
            else
            {
                labelColumnname2.Visible = true;
                labelData2.Visible = true;
                labelAmountRecords2.Visible = true;
            }
        }

        /// <summary>
        /// methode om bepaalde componenten (gedefiniëerd in een IList (parameter van koppelDictionaryControls)) te showen/hiden.
        /// </summary>
        /// <param name="radioButton">desbetreffende radiobuttonValue waarop is geklikt</param>
        /// <param name="toShow">moeten er elementen gehide/gedisabled worden? of anders om.</param>
        private void hideOrShowComponents(RadioButton radioButton, bool toShow)
        {
            //voor elke IList control in Dictionary bla bla lba [radioButton]
            var maxAmountControls = koppelDictionaryControls[radioButton].Count;
            var count = 0;
            foreach (Control ctrl in koppelDictionaryControls[radioButton])
            {
                count++;
                if (count != maxAmountControls)
                {
                    ctrl.Visible = toShow;
                }
                else
                {
                    ctrl.Enabled = !toShow;
                }
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
            //TODO: newline methode maken.

#region notButArea

            //eerst panel maken, anders kan maar 1 radio button checked zijn binnen het hele formulepanel.
            Panel radioPanel=new Panel();
            radioPanel.Location = new Point(417, row * regelAfstand - 30);
            radioPanel.Size = new Size(200, 25);

            //radio button absolute:
            RadioButton radioButtonAbsol = new RadioButton();
            radioButtonAbsol.Checked = true;
            radioButtonAbsol.Location = new Point(0, 0);
            radioButtonAbsol.Name = "radioButtonAbsolute" + row;
            radioButtonAbsol.Size = new Size(100, 21);
            radioButtonAbsol.Text = "Absolute value";
            radioButtonAbsol.UseVisualStyleBackColor = true;
            radioPanel.Controls.Add(radioButtonAbsol);

            //radio button value:
            RadioButton radioButtonVal = new RadioButton();
            radioButtonVal.Location = new Point(100, 0);
            radioButtonVal.Name = "radioButtonValue" + row;
            radioButtonVal.Size = new Size(114, 21);
            radioButtonVal.Text = "Current value";
            radioButtonVal.UseVisualStyleBackColor = true;
            radioButtonVal.CheckedChanged += radioButtonValue_CheckedChanged;
            radioPanel.Controls.Add(radioButtonVal);
            panelFormulaControls.Controls.Add(radioPanel);
                
                

            //column name 1:
            TextBox columnname = new TextBox();
            columnname.Location = new Point(3, row * regelAfstand);
            columnname.Name = "textBoxColumnname" + row;
            columnname.Size = new Size(140, 22);
            columnname.Text = kolomnaam;
            panelFormulaControls.Controls.Add(columnname);

            //picturebox:
            PictureBox picSearch1 = new PictureBox();
            picSearch1.BackColor = Color.White;
          
            picSearch1.Location = new Point(140, row * regelAfstand);
            picSearch1.Name = "pictureBox + " + row;
            picSearch1.Cursor = Cursors.Hand;
            picSearch1.Size = new Size(50, 18);
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
            comboB1.Location = new Point(190, row * regelAfstand);
            comboB1.Name = "comboBoxOperator1";
            comboB1.Size = new Size(90, 22);
            //TODO: een gedeelde event handler maken voor de combobox:
            //note: nu staat het er hardcoded in.
            comboB1.SelectedIndex = 0;
            comboB1.SelectedIndexChanged += comboBoxOperator_SelectedIndexChanged;
            panelFormulaControls.Controls.Add(comboB1);

            //numeric up down records:
            NumericUpDown numUpDown = new NumericUpDown();
            numUpDown.Enabled = false;
            numUpDown.Location = new System.Drawing.Point(284, row * regelAfstand);
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
            numUpDown.Size = new Size(75, 22);
            numUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            panelFormulaControls.Controls.Add(numUpDown);

            //combobox2
            ComboBox comboB2 = new ComboBox();
            comboB2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboB2.FormattingEnabled = true;
            comboB2.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            ">=",
            "<=",
            "≠"});
            comboB2.Location = new Point(365, row * regelAfstand);
            comboB2.Name = "combob2" + row + "2";
            comboB2.Size = new Size(50, 22);
            comboB2.SelectedIndex = 0;
            panelFormulaControls.Controls.Add(comboB2);

            //textBoxValue
            TextBox textBoxVal = new TextBox();
            textBoxVal.Location = new Point(418, row * regelAfstand);
            textBoxVal.Name = "textBoxValue" + row;
            textBoxVal.Size = new Size(75, 22);
            panelFormulaControls.Controls.Add(textBoxVal);

            //textBoxColumnname2:
            TextBox textBoxCol2 = new TextBox();
            textBoxCol2.Location = new Point(500, row * regelAfstand);
            textBoxCol2.Name = "textBoxColumnname" + row + 2;
            textBoxCol2.Size = new Size(140, 22);
            panelFormulaControls.Controls.Add(textBoxCol2);

            //pictureboxSearch2:
            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Playground_v3.Properties.Resources._1426093958_common_search_lookup__128;
            pictureBox2.Location = new Point(636, row * regelAfstand);
            pictureBox2.Name = "pictureBoxSearch2";
            pictureBox2.Size = new Size(50, 18);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBoxSearch_Click;
            panelFormulaControls.Controls.Add(pictureBox2);

            //pictureboxSearch 2 koppelen aan textBoxColumnName2:
            koppelDictionary.Add(pictureBox2, textBoxCol2);

            //comboBoxOperator3: gelijk aan comboBoxOperator1
            ComboBox comboB3 = new ComboBox();
            comboB3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboB3.Items.AddRange(new object[] {
            "Most recent",
            "Average"});
            comboB3.Location = new Point(687, row * regelAfstand);
            comboB3.Name = "comboBoxOperator1";
            comboB3.Size = new Size(90, 22);
            //TODO: een gedeelde event handler maken voor de combobox:
            //note: nu staat het er hardcoded in.
            comboB3.SelectedIndex = 0;
            comboB3.SelectedIndexChanged += comboBoxOperator_SelectedIndexChanged;
            panelFormulaControls.Controls.Add(comboB3);
            
            //numeric up down records2:
            NumericUpDown numUpDown2 = new NumericUpDown();
            numUpDown2.Enabled = false;
            numUpDown2.Location = new System.Drawing.Point(780, row * regelAfstand);
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
            #endregion

            textBoxCol2.Visible = false;
            pictureBox2.Visible = false;
            comboB3.Visible = false;
            numUpDown2.Visible = false;
            textBoxVal.Enabled = true;

            //toevoegen aan lijstje met controls die straks verborgen/getoont zullen worden.
            IList<Control> controls = new List<Control>();
            controls.Add(textBoxCol2);
            controls.Add(pictureBox2);
            controls.Add(comboB3);
            controls.Add(numUpDown2);
            controls.Add(textBoxVal); //deze moet worden enabled

            koppelDictionaryControls.Add(radioButtonVal, controls);
          
            koppelDictionaryComboBox.Add(comboB1, numUpDown);
            koppelDictionaryComboBox.Add(comboB3, numUpDown2);

            row++;
        }

        /// <summary>
        /// Methode om via de koppelDictionaryComboBox te bepalen welke numericUpDownRecords mag geënabled/disabled worden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox sndr = sender as ComboBox;
            NumericUpDown numUpDown = koppelDictionaryComboBox[sndr];
            if (sndr.SelectedIndex == 1)
            {
                numUpDown.Enabled = true;
            }
            else
            {
                numUpDown.Enabled = false;
            }
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

