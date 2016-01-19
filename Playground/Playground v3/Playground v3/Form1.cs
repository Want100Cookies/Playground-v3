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
using System.Threading;
using Playground_v3.Properties;

namespace Playground_v3
{
    public partial class Form1 : Form
    {
        //variabele waarin de huidige rij is opgeslagen. Dit wordt gebruikt bij het genereren van rijen.
        public int row;
        public int regelAfstand; //var die het aantal points (=afstand) tussen twee regels bijhoudt.

        //veld die helpt bij het koppelen van search icons en tekstvelden.
        //reden: als er op een search icon wordt geklikt, moet je natuurlijk wel weten bij welke textbox hij het resultaat moet invullen.
        private Dictionary<PictureBox, TextBox> koppelDictionary;

        private Dictionary<ComboBox, NumericUpDown> koppelDictionaryComboBox;

        //Dictionary met welke rij bij welke controls horen.
        private Dictionary<int, IList<Control>> koppelDictionaryRows;

        //Dictionary die het label met live waarde koppelt met een bepaalde TextBox.
        private Dictionary<TextBox, Label> koppelDictionaryLabels;

        //var die bijhoud hoeveel Radiobuttons er op value staan. Als dit groter is dan 0, moeten bepaalde labels visible zijn.
        private int CountRadioButtonsValue;

        //Als de radiobutton op current value staat, moeten bepaalde controls visible zijn. Deze controls zijn opgeslagen in een IList<Control>.
        private Dictionary<RadioButton, IList<Control>> koppelDictionaryControls;

        public Form1()
        {
            InitializeComponent();

            //gui init
            labelColumnname2.Visible = false;
            labelData2.Visible = false;
            labelAmountRecords2.Visible = false;

            Form1_Resize(null,null);

            row = 1;
            regelAfstand = 80;
            koppelDictionary = new Dictionary<PictureBox, TextBox>();
            koppelDictionaryControls = new Dictionary<RadioButton, IList<Control>>();
            koppelDictionaryComboBox = new Dictionary<ComboBox, NumericUpDown>();
            koppelDictionaryRows = new Dictionary<int, IList<Control>>();
            koppelDictionaryLabels = new Dictionary<TextBox, Label>();

            CountRadioButtonsValue = 0;

            newLine();
        }

        /// <summary>
        /// Er wordt op een menuitem geklikt..66
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDatabase selectDatabase = new SelectDatabase();
            selectDatabase.Show();
        }

        /// <summary>
        /// Methode die wordt aangeroepen wanneer er op een radiobutton (absolute value/current value) wordt geklikt.
        /// Zorgt ervoor dat labels worden geshowd/gehide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Methode die communiceert met een live label.
        /// </summary>
        /// <param name="txtBoxSender"></param>
        public void AppendLiveLable(TextBox txtBoxSender)
        {
            Label lblToWrite = koppelDictionaryLabels[txtBoxSender];

            //get value form database.
            //dit invullen en opslaan in value.
            Random rand = new Random();
           // string value = "NaN";
            string value = rand.Next(500).ToString();
            if (InvokeRequired)
            {
                lblToWrite.BeginInvoke(new Action(() =>
                {
                    lblToWrite.Text = "Live waarde: " + value;
                }));
            }
        }


        /// <summary>
        /// methode om bepaalde componenten (gedefiniëerd in een IList (parameter van koppelDictionaryControls)) te showen/hiden.
        /// </summary>
        /// <param name="radioButton">desbetreffende radiobuttonValue waarop is geklikt</param>
        /// <param name="toShow">moeten er elementen gehide/gedisabled worden? of anders om.</param>
        private void hideOrShowComponents(RadioButton radioButton, bool toShow)
        {
            //voor elke IList control in Dictionary [radioButton]
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

        /// <summary>
        /// Methode waarin een searchBox diolog wordt geopend waarin een zoekfunctie komt. Het zoekresultaat kan worden ingevuld in een invoerveld.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    form.getTextBox().Text = str;
                }
            }
        }

        /// <summary>
        /// Methode die een nieuwe formuleregel maakt. Met daarin eventueel waardes die ingevuld kunnen worden.
        /// </summary>
        /// <param name="kolomnaam">De kolomnaam</param>
        /// <param name="amount">bij gemiddeld aantal values, is deze "2" als default.</param>
        /// <param name="operatorSoort">de index van het dropdown menu beginnende vanaf 0.</param>
        /// <param name="operatorValue">De waarde: dus een getal.</param>
        /// <param name="kolomnaam2">bij current value is er een tweede kolomnaam waarmee je de eerste kolomnaam wilt vergelijken.</param>
        /// <param name="amount2">Het aantal records waarvan het gemiddelde genomen moet worden</param>
        public void newLine(string kolomnaam = "", string amount = "", string operatorSoort = "0",
            string operatorValue = "", string kolomnaam2 = "", string amount2 = "")
        {
            #region components/controls
            bool soort1 = !(kolomnaam2 != "");

            //eerst panel maken voor het paar radiobuttons, anders kan maar 1 radio button checked zijn binnen het hele formulepanel.
            Panel radioPanel = new Panel();
            radioPanel.Location = new Point(417, row*regelAfstand - 30);
            radioPanel.Size = new Size(200, 25);
            radioPanel.Name = "radioPanel" + row;

            //radio button absolute:
            RadioButton radioButtonAbsol = new RadioButton();
            //check one of the radio buttons:
            if (soort1)
            {
                radioButtonAbsol.Checked = true;
            }
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

            //column name 1:
            TextBox columnname = new TextBox();
            columnname.Location = new Point(3, row*regelAfstand);
            columnname.Name = "textBoxColumnname1" + row;
            columnname.Size = new Size(135, 22);
            columnname.Text = kolomnaam;
            columnname.TextChanged += columnnameTextChange;
            panelFormulaControls.Controls.Add(columnname);

            //labelCurrentValue:
            Label labelcurrentValue = new Label();
            labelcurrentValue.Location=new Point(3, row*regelAfstand + 20);
            labelcurrentValue.Name = "LabelCurrentValue1" + row;
            labelcurrentValue.Text = "Live waarde: ";
            labelcurrentValue.BackColor = Color.Transparent;
            panelFormulaControls.Controls.Add(labelcurrentValue);

            //picturebox:
            PictureBox picSearch1 = new PictureBox();
            picSearch1.BackColor = Color.White;
            picSearch1.Location = new Point(140, row*regelAfstand);
            picSearch1.Name = "pictureBox" + row;
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
            comboB1.Items.AddRange(new object[]
            {
                "Most recent",
                "Average"
            });
            comboB1.Location = new Point(190, row*regelAfstand);
            comboB1.Name = "comboBoxOperator1" + row;
            comboB1.Size = new Size(90, 22);
            comboB1.SelectedIndex = 0;
            if (amount != "") //als average
            {
                comboB1.SelectedIndex = 1;
            }
            comboB1.SelectedIndexChanged += comboBoxOperator_SelectedIndexChanged;
            panelFormulaControls.Controls.Add(comboB1);

            //numeric up down records:
            NumericUpDown numUpDown = new NumericUpDown();
            if (amount == "")
            {
                numUpDown.Enabled = false;
            }
            numUpDown.Location = new Point(284, row*regelAfstand);
            numUpDown.Maximum = 250;
            numUpDown.Minimum = 2;
            numUpDown.Name = "numericUpDownRecords1" + row;
            numUpDown.Size = new Size(75, 22);
            numUpDown.Value = 2;
            if (amount != "") //als average
            {
                numUpDown.Value = int.Parse(amount);
            }
            panelFormulaControls.Controls.Add(numUpDown);

            //combobox2
            ComboBox comboB2 = new ComboBox();
            comboB2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboB2.FormattingEnabled = true;
            comboB2.Items.AddRange(new object[]
            {
                ">",
                "<",
                "=",
                ">=",
                "<=",
                "≠"
            });
            comboB2.Location = new Point(365, row*regelAfstand);
            comboB2.Name = "comboBoxOperator2" + row;
            comboB2.Size = new Size(50, 22);
            comboB2.SelectedIndex = int.Parse(operatorSoort);
            panelFormulaControls.Controls.Add(comboB2);

            //textBoxValue
            TextBox textBoxVal = new TextBox();
            textBoxVal.Location = new Point(418, row*regelAfstand);
            textBoxVal.Name = "textBoxValue" + row;
            textBoxVal.Size = new Size(75, 22);
            textBoxVal.Text = operatorValue;
            panelFormulaControls.Controls.Add(textBoxVal);

            //textBoxColumnname2:
            TextBox textBoxCol2 = new TextBox();
            textBoxCol2.Location = new Point(500, row*regelAfstand);
            textBoxCol2.Name = "textBoxColumnname2" + row;
            textBoxCol2.Size = new Size(140, 22);
            textBoxCol2.Text = kolomnaam2;
            textBoxCol2.TextChanged += columnnameTextChange;
            panelFormulaControls.Controls.Add(textBoxCol2);

            //labelCurrentValue2:
            Label labelcurrentValue2 = new Label();
            labelcurrentValue2.Location = new Point(500, row * regelAfstand + 20);
            labelcurrentValue2.Name = "LabelCurrentValue2" + row;
            labelcurrentValue2.Text = "Live waarde: ";
            labelcurrentValue2.BackColor = Color.Transparent;
            labelcurrentValue2.Visible = false;
            panelFormulaControls.Controls.Add(labelcurrentValue2);

            //pictureboxSearch2:
            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Resources._1426093958_common_search_lookup__128;
            pictureBox2.Location = new Point(636, row*regelAfstand);
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
            comboB3.Items.AddRange(new object[]
            {
                "Most recent",
                "Average"
            });
            comboB3.Location = new Point(687, row*regelAfstand);
            comboB3.Name = "comboBoxOperator3" + row;
            comboB3.Size = new Size(90, 22);
            comboB3.SelectedIndex = 0;
            if (amount2 != "")
            {
                comboB3.SelectedIndex = 1;
            }
            comboB3.SelectedIndexChanged += comboBoxOperator_SelectedIndexChanged;
            panelFormulaControls.Controls.Add(comboB3);

            //numeric up down records2:
            NumericUpDown numUpDown2 = new NumericUpDown();
            if (amount2 == "")
            {
                numUpDown2.Enabled = false;
            }
            numUpDown2.Location = new Point(780, row*regelAfstand);
            numUpDown2.Maximum = 250;
            numUpDown2.Minimum = 2;
            numUpDown2.Name = "numericUpDownRecords2" + row;
            numUpDown2.Size = new Size(101, 22);
            if (amount2 != "")
            {
                numUpDown2.Value = int.Parse(amount2);
            }
            panelFormulaControls.Controls.Add(numUpDown2);

            textBoxCol2.Visible = false;
            pictureBox2.Visible = false;
            comboB3.Visible = false;
            numUpDown2.Visible = false;
            textBoxVal.Enabled = true;

            #endregion

            //toevoegen aan lijstje met controls die straks verborgen/getoont zullen worden.
            IList<Control> controls = new List<Control>();
            controls.Add(textBoxCol2);
            controls.Add(pictureBox2);
            controls.Add(comboB3);
            controls.Add(numUpDown2);
            controls.Add(labelcurrentValue2);
            controls.Add(textBoxVal); //deze moet worden enabled

            radioButtonVal.CheckedChanged += radioButtonValue_CheckedChanged;
            radioPanel.Controls.Add(radioButtonVal);
            panelFormulaControls.Controls.Add(radioPanel);
            koppelDictionaryControls.Add(radioButtonVal, controls);

            //check one of the radio buttons:
            if (!soort1)
            {
                radioButtonVal.Checked = true;
            }

            koppelDictionaryComboBox.Add(comboB1, numUpDown);
            koppelDictionaryComboBox.Add(comboB3, numUpDown2);

            //welk collumnName invoerveld hoort bij welke label?
            koppelDictionaryLabels.Add(columnname, labelcurrentValue);
            koppelDictionaryLabels.Add(textBoxCol2, labelcurrentValue2);

            //koppelDictionaryRows
            //note: er moet een nieuwe IList<Control> worden aangemaakt omdat er niet voortgeborduurd kan worden op de IList controls.
            IList<Control> controls2 = new List<Control>();
            controls2.Add(textBoxCol2);
            controls2.Add(pictureBox2);
            controls2.Add(comboB3);
            controls2.Add(numUpDown2);
            controls2.Add(textBoxVal);
            controls2.Add(labelcurrentValue);
            controls2.Add(radioPanel);
            controls2.Add(columnname);
            controls2.Add(picSearch1);
            controls2.Add(comboB1);
            controls2.Add(numUpDown);
            controls2.Add(comboB2);
            controls2.Add(textBoxVal);
            controls2.Add(labelcurrentValue2);

            koppelDictionaryRows.Add(row, controls2);

            row++;
        }

        /// <summary>
        /// Event dat wordt getriggert als de tekst in één van de invoervelden veranderd.
        /// Hierna wordt bepaald welk label voor een live waarde daar gekoppeld aan is.
        /// Ten slotte wordt een thread aangemaakt die de meeste recente (live) waarde uit de database haalt.
        /// Wanneer dit is gelukt, wordt dit ingevuld in de label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void columnnameTextChange(object sender, EventArgs e)
        {
            timerDemo.Enabled = true;
            TextBox sndr = sender as TextBox;
            //Thread updateThread = new Thread(new ParameterizedThreadStart(AppendLiveLable));
            Thread updateThread = new Thread(() => AppendLiveLable(sndr));
            updateThread.Start();
            //nu thread maken (met argument)
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
            numUpDown.Enabled = sndr.SelectedIndex == 1;
        }

        /// <summary>
        /// sla de formule (dus het gehele scherm) op in een xml bestand.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFormula_Click(object sender, EventArgs e)
        {
            if (canSave())
            {
                XmlDocument doc = new XmlDocument();
                XmlElement formule = doc.CreateElement("formule");

                for (int i = 1; i < row; i++)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton = (RadioButton) Controls.Find("radioButtonAbsolute" + i, true)[0];
                    var soort1 = radioButton.Checked;

                    XmlElement regel = doc.CreateElement("regel");
                    formule.AppendChild(regel);
                    XmlElement soort = doc.CreateElement("soort");
                    soort.InnerText = soort1 ? "1" : "2";

                    XmlElement kolomnaam = doc.CreateElement("kolomnaam");
                    kolomnaam.InnerText = ((TextBox) Controls.Find("textBoxColumnname1" + i, true)[0]).Text;

                    XmlElement type = doc.CreateElement("type");
                    //    //TODO: naamgeving controleren: (xxx)Controls.Find("!!!!!!" + xxx).
                    //als type is gemiddelde: dan attribuut waarde verandren
                    if (((ComboBox) Controls.Find("ComboBoxOperator1" + i, true)[0]).SelectedIndex == 0)
                    {
                        type.SetAttribute("amount", "");
                    }
                    else
                    {
                        type.SetAttribute("amount",
                            ((NumericUpDown) Controls.Find("numericUpDownRecords1" + i, true)[0]).Text);
                    }

                    XmlElement operatorEl = doc.CreateElement("operator");
                    operatorEl.SetAttribute("soort",
                        ((ComboBox) Controls.Find("comboBoxOperator2" + i, true)[0]).SelectedIndex.ToString());
                    //als soort is 1, dan:
                    if (soort1)
                    {
                        //  operatorEl.InnerText = textBoxValue.Text;
                        operatorEl.InnerText = ((TextBox) Controls.Find("textBoxValue" + i, true)[0]).Text;
                    }
                    else
                    {
                        //anders:
                        XmlElement kolomnaam2 = doc.CreateElement("kolomnaam2");
                        kolomnaam2.InnerText = ((TextBox) Controls.Find("textBoxColumnname2" + i, true)[0]).Text;
                        regel.AppendChild(kolomnaam2);
                    }

                    XmlElement type2 = doc.CreateElement("type2");
                    //als type is gemiddelde: dan attribuut waarde verandren
                    if (((ComboBox) Controls.Find("comboBoxOperator3" + i, true)[0]).SelectedIndex == 0)
                    {
                        type2.SetAttribute("amount", "");
                    }
                    else
                    {
                        type2.SetAttribute("amount",
                            ((NumericUpDown) Controls.Find("numericUpDownRecords2" + i, true)[0]).Text);
                    }

                    regel.AppendChild(soort);
                    regel.AppendChild(kolomnaam);
                    regel.AppendChild(type);
                    regel.AppendChild(operatorEl);
                    if (!soort1)
                    {
                        regel.AppendChild(type2);
                    }

                    doc.AppendChild(formule);
                }
                //doc.Save("new_formule1test.xml");
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "XML files|*.xml";
                saveFileDialog1.Title = "Save an XML formula file";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    doc.Save(saveFileDialog1.FileName);
                    MessageBox.Show("Formula succesfully saved.");
                }
            }
        }

        /// <summary>
        /// functie die controleerd of het formulescherm dusdanig is ingevuld dat deze mag worden opgeslagen.
        /// </summary>
        /// <returns>true als elk veld voldoende is ingevuld.</returns>
        private bool canSave()
        {
            var canContinue = true;

            for (int i = panelFormulaControls.Controls.Count - 1; i >= 0; i--)
                {
                    Control c = panelFormulaControls.Controls[i];

                    if (c.Visible && c.Enabled)
                    {
                        if (c is TextBox)
                        {
                            if (string.IsNullOrWhiteSpace(c.Text))
                            {
                                c.BackColor = ColorTranslator.FromHtml("#ff3333");
                                canContinue = false;
                            }
                          
                        }
                    }
                    else
                    {
                        c.BackColor = Color.White;
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
                //  MessageBox.Show(openFileDialog.FileName);
                clearFormulaScreen();

                var doc = new XmlDocument();
                doc.Load(openFileDialog.FileName);
                //  MessageBox.Show(doc.SelectSingleNode("formule/type").Attributes[0].Value.GetType().ToString());

                foreach (XmlElement regel in doc.SelectNodes("formule/regel"))
                {
                    //note: door de volgende regel is het niet mogelijk om 2 bestaande formules te combineren.
                    koppelDictionaryRows.Clear();
                    //todo: soort van reset methode.
                    string kolomnaam = regel.SelectSingleNode("kolomnaam").InnerText;
                    string amount = regel.SelectSingleNode("type").Attributes[0].Value;
                    string operatorSoort = regel.SelectSingleNode("operator").Attributes[0].Value;

                    if (regel.SelectSingleNode("soort").InnerText == "1") //soort is 1: absolute value
                    {
                        string operatorValue = regel.SelectSingleNode("operator").InnerText;
                        newLine(kolomnaam, amount, operatorSoort, operatorValue);
                    }
                    else
                    {
                        string kolomnaam2 = regel.SelectSingleNode("kolomnaam").InnerText;
                        string amount2 = regel.SelectSingleNode("type2").Attributes[0].Value;
                        newLine(kolomnaam, amount, operatorSoort, "", kolomnaam2, amount2);
                    }
                }
            }
        }

        private void buttonNewLine_Click(object sender, EventArgs e)
        {
            newLine();
        }

        /// <summary>
        /// Wanneer een formule wordt geladen, worden alle behalve de labels elmenenten binnen panelFormulaControls verwijderd.
        /// Note: code werkt op altanatieve methode
        /// </summary>
        private void clearFormulaScreen()
        {
            for (int i = panelFormulaControls.Controls.Count - 1; i >= 0; i--)
            {
                Control c = panelFormulaControls.Controls[i];
                if (!(c is Label))
                {
                    panelFormulaControls.Controls.RemoveAt(i);
                }
            }
            row = 1;
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (row > 2)
            {
                foreach (Control c in koppelDictionaryRows[row -1])
                {
                    panelFormulaControls.Controls.Remove(c);
                    c.Dispose();
                }
                koppelDictionaryRows.Remove(row - 1);
                row--;
            }
        }

        /// <summary>
        /// stukje responsiveness toegevoegd.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            panelFormulaControls.Width = Width - 20;
            panelFormulaControls.Height = Height - 175;
            panelButtons.Top = Height - 150;
            tabControl1.Height = Height - 10;
            // panelFormulaControls.Height = buttonSaveFormula.Top;
        }

        /// <summary>
        /// Deze timer wordt gebruikt om een demonstratie te geven hoe het programma eruit moet gaan zien:
        /// De opdrachtgever wenste graag 'live' waardes te zien bij elke tag (kolomkop).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDemo_Tick(object sender, EventArgs e)
        {
            //ga elke label bij langs, opgeslagen in de dictionary 'koppelDictionaryLabels'.
            var arrayOfAllKeys = koppelDictionaryLabels.Keys.ToArray();
            foreach (TextBox tBox in arrayOfAllKeys)
            {
                Thread updateThread = new Thread(() => AppendLiveLable(tBox));
                updateThread.Start();
            }
        }
    }
}