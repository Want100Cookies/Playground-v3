using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Playground_v3
{
    public partial class DatabaseOptions : Form
    {
        // temp config path
        private readonly string _xmlConfigPath;
        private readonly string _databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOptions"/> class.
        /// </summary>
        /// <param name="xmlConfigPath">The XML config path.</param>
        /// <param name="DBname">The database name that has to be edited. Null if new connection string has to be added.</param>
        public DatabaseOptions(string xmlConfigPath, string DBname = null)
        {
            _xmlConfigPath = xmlConfigPath;
            _databaseName = DBname;


            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the NewDatabase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NewDatabase_Load(object sender, EventArgs e)
        {
            // set dropdownlist style for all dropdown elements
            // set the selected index on 0
            foreach (ComboBox control in Controls.OfType<ComboBox>())
            {
                control.SelectedIndex = 0;
                control.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            if (_databaseName == null) return;
            
            String providerName = "", connectionString = "";

            // Load the xml file and set the provider name and connection string
            LoadDataFromXml(ref providerName, ref connectionString);

            // Convert the connectionstring to a Dictionary<string, string> with linq (http://stackoverflow.com/a/8529543)
            var keyValuePairs = connectionString.Split(';')
                .Select(s => s.Split('='))
                .ToDictionary(s => s.First(), s => s.Last());


            // Put all the data in the textboxes
            PopulateTextboxes(_databaseName, providerName, keyValuePairs);
        }

        /// <summary>
        /// Populate the form with the given data.
        /// </summary>
        /// <param name="databaseName">The database name</param>
        /// <param name="providerName">The provider name</param>
        /// <param name="connectionDictionary">The connection information in a Dictionary |string, string| format</param>
        private void PopulateTextboxes(string databaseName, string providerName, Dictionary<string, string> connectionDictionary)
        {
            foreach (Label label in Controls.OfType<Label>())
            {
                if (connectionDictionary.ContainsKey(label.Text.TrimEnd(':')))
                {
                    String index = label.Name.Substring(3);
                    Control textBoxControl = Controls["value" + index];
                    textBoxControl.Text = connectionDictionary[label.Text.TrimEnd(':')];
                }
            }

            foreach (ComboBox comboBox in Controls.OfType<ComboBox>())
            {
                foreach (var item in comboBox.Items)
                {
                    if (connectionDictionary.ContainsKey(item.ToString()))
                    {
                        comboBox.SelectedItem = item;
                        String index = comboBox.Name.Substring(3);
                        Control textBoxControl = this.Controls["value" + index];
                        textBoxControl.Text = connectionDictionary[item.ToString()];
                    }
                }
            }

            Controls["value32"].Text = databaseName;
            Controls["value31"].Text = providerName;
        }


        /// <summary>
        /// Load all data from the XML file.
        /// 
        /// The parameters are pass by reference so they can be returned to the calling funtion.
        /// </summary>
        /// <param name="providerName">Pass by reference provider name</param>
        /// <param name="connectionString">Pass by reference connection string</param>
        private void LoadDataFromXml(ref string providerName, ref string connectionString)
        {
            try
            {
                // open the xml document with temp config path
                XmlDocument document = new XmlDocument();
                document.Load(_xmlConfigPath);

                // select the connectionstrings node
                XmlNode node = document.SelectSingleNode("configuration/connectionStrings");

                XmlNode currentNode = node.SelectSingleNode("//add[@name='" + _databaseName + "']");

                providerName = currentNode.Attributes["providerName"].Value;
                connectionString = currentNode.Attributes["connectionString"].Value;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Configuratie bestand niet gevonde...");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Database niet gevonden in het configuratie bestand.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            // temp storage for key values (label + textbox)
            Dictionary<string, string> keyValues = new Dictionary<string, string>();

            // loop through all controls
            foreach (var control in this.Controls.OfType<TextBox>())
            {
                string key = "";
                string value = "";

                string index = control.Name.Substring(5);
                // get the label
                Control label = this.Controls["key" + index];

                // get the text of the label as the key
                key = label.Text;

                // check if it contains ':', cut it away
                if (key.Contains(':'))
                    key = label.Text.Substring(0, label.Text.Length - 1);

                // get the value text
                value = control.Text;

                // check if length > 0 and than add to keyValues
                if (key != "" && value != "")
                    if (!keyValues.ContainsKey(key))
                        keyValues.Add(key, value);

            }

            try
            {
                // get the value of the tabname and the provider name
                string tabName = keyValues["Databasename (Tab name)"];
                string providerName = keyValues["Provider name"];

                // check if tabname and providername are empty
                if (String.IsNullOrEmpty(tabName) || String.IsNullOrEmpty(providerName))
                {
                    MessageBox.Show("You need to enter a TabName and Providername");
                    return; // don't move on
                }

                // Check keyvalues
                LoopKeyValuePairs(keyValues, tabName, providerName);
            }
            catch
            {
                MessageBox.Show("You need to enter a TabName and Providername");
                return;
            }
        }

        /// <summary>
        /// Loop through all keyvalue pairs and add them to the connectionstring
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="tabName">Name of the tab.</param>
        /// <param name="providerName">Name of the provider.</param>
        private void LoopKeyValuePairs(Dictionary<string, string> keyValues, string tabName, string providerName)
        {
            // the string for connectionString
            StringBuilder connectionString = new StringBuilder();

            foreach (var VARIABLE in keyValues)
            {
                Console.WriteLine(VARIABLE.Key + " -- " + VARIABLE.Value);
            }

            // loop through all keyvalues
            foreach (KeyValuePair<string, string> keyValuePair in keyValues.Where(keyValuePair => keyValuePair.Key != "Databasename (Tab name)" && keyValuePair.Key != "Provider name"))
            {
                connectionString.Append(keyValuePair.Key + "=" + keyValuePair.Value + ";");
            }

            //encrypt string
            //String encryptedString = Encryption.EncryptStringAES(connectionString.ToString(), Encryption.Secret);
            String encryptedString = connectionString.ToString();

            // edit the current xml file
            editXmlConfigFile(tabName, providerName, encryptedString);
        }

        /// <summary>
        /// Edits the XML configuration file.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="connectionString">The connection string.</param>
        private void editXmlConfigFile(string dbName, string providerName, string connectionString)
        {
            // open the xml document with temp config path
            XmlDocument document = new XmlDocument();
            document.Load(_xmlConfigPath);

            // select the connectionstrings node
            XmlNode node = document.SelectSingleNode("configuration/connectionStrings");

            XmlNode connectionNode = document.SelectSingleNode("//add[@name='" + dbName + "']");

            if (connectionNode == null)
            {
                // add a new node
                XmlNode newNode = document.CreateNode(XmlNodeType.Element, "add", "");

                // Create attribute name
                XmlAttribute nameAttr = document.CreateAttribute("name");
                nameAttr.Value = dbName;
                newNode.Attributes.Append(nameAttr);

                // Create attribute connectionString
                XmlAttribute connectionStringAttr = document.CreateAttribute("connectionString");
                connectionStringAttr.Value = connectionString;
                newNode.Attributes.Append(connectionStringAttr);

                // Create attribute providerName
                XmlAttribute providerNameAttr = document.CreateAttribute("providerName");
                providerNameAttr.Value = providerName;
                newNode.Attributes.Append(providerNameAttr);

                // append the new child node to the root node
                node.AppendChild(newNode.Clone());
            }
            else
            {
                if (connectionNode.Attributes != null)
                {
                    connectionNode.Attributes["connectionString"].Value = connectionString;
                    connectionNode.Attributes["providerName"].Value = providerName;
                }
            }

            // save xml config file
            document.Save(_xmlConfigPath);

            // Close the configuration form
            this.Close();
        }

        private void DatabaseOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }
    }
}
