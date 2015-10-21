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
        private readonly string _databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOptions"/> class.
        /// </summary>
        /// <param name="DBname">The database name that has to be edited. Null if new connection string has to be added.</param>
        public DatabaseOptions(string DBname = null)
        {
            _databaseName = DBname;

            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the DatabaseOptions control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DatabaseOptions_Load(object sender, EventArgs e)
        {
            // set dropdownlist style for all dropdown elements
            // set the selected index on 0
            foreach (ComboBox control in Controls.OfType<ComboBox>())
            {
                control.SelectedIndex = 0;
                control.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            this.Text = "New database connection";

            if (_databaseName == null) return;

            this.Text = "Edit " + _databaseName + " database connection";
            this.value32.ReadOnly = true;

            string providerName = "", connectionString = "";

            foreach (ConnectionStringStruct connStruct in Settings.GetConnectionstringList().Where(connStruct => connStruct.name == _databaseName))
            {
                providerName = connStruct.providerName;
                connectionString = connStruct.connectionString;
            }

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
                if (!connectionDictionary.ContainsKey(label.Text.TrimEnd(':'))) continue;
                string index = label.Name.Substring(3);
                Control textBoxControl = Controls["value" + index];
                textBoxControl.Text = connectionDictionary[label.Text.TrimEnd(':')];
            }

            foreach (ComboBox comboBox in Controls.OfType<ComboBox>())
            {
                foreach (var item in comboBox.Items.Cast<object>().Where(item => connectionDictionary.ContainsKey(item.ToString())))
                {
                    comboBox.SelectedItem = item;
                    string index = comboBox.Name.Substring(3);
                    Control textBoxControl = this.Controls["value" + index];
                    textBoxControl.Text = connectionDictionary[item.ToString()];
                }
            }

            Controls["value32"].Text = databaseName;
            Controls["value31"].Text = providerName;
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
                if (string.IsNullOrEmpty(tabName) || string.IsNullOrEmpty(providerName))
                {
                    MessageBox.Show("You need to enter a TabName and Providername");
                    return; // don't move on
                }

                // Check keyvalues
                LoopKeyValuePairs(keyValues, tabName, providerName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex);
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

            // loop through all keyvalues
            foreach (KeyValuePair<string, string> keyValuePair in keyValues.Where(keyValuePair => keyValuePair.Key != "Databasename (Tab name)" && keyValuePair.Key != "Provider name"))
            {
                connectionString.Append(keyValuePair.Key + "=" + keyValuePair.Value + ";");
            }

            //encrypt string
            //string encryptedString = Encryption.EncryptStringAES(connectionString.ToString(), Encryption.Secret);
            string encryptedString = connectionString.ToString();

            // edit the current xml file
            EditXmlConfigFile(tabName, providerName, encryptedString);
        }

        /// <summary>
        /// Edits the XML configuration file.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="connectionString">The connection string.</param>
        private void EditXmlConfigFile(string dbName, string providerName, string connectionString)
        {
            ConnectionStringStruct connStruct = Settings.GetConnectionString(dbName);

            if (connStruct.Equals(new ConnectionStringStruct()))
            {
                connStruct.name = dbName;
                connStruct.connectionString = connectionString;
                connStruct.providerName = providerName;

                Settings.AddConnectionString(connStruct);
            }
            else
            {
                connStruct.connectionString = connectionString;
                connStruct.providerName = providerName;

                Settings.RemoveConnectionString(dbName);
                Settings.AddConnectionString(connStruct);
            }

            // Close the configuration form
            Close();
        }

        private void DatabaseOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }
    }
}
