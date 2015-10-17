using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Playground_v3
{
    public partial class SelectDatabase : Form
    {

        private readonly string _xmlConfigPath;

        public SelectDatabase()
        {
            InitializeComponent();
            _xmlConfigPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            PopulateListBox();
        }

        private void PopulateListBox()
        {
            // open the xml document with temp config path
            XmlDocument document = new XmlDocument();
            document.Load(_xmlConfigPath);

            // select the connectionstrings node
            XmlNode node = document.SelectSingleNode("configuration/connectionStrings");

            lstBoxDatabases.Items.Clear();

            foreach (XmlNode childNode in node)
            {
                if (childNode.Attributes != null) lstBoxDatabases.Items.Add(childNode.Attributes["name"].Value);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            String dbName = lstBoxDatabases.SelectedItem.ToString();
            OpenForm(dbName);

        }

        private void OpenForm(String dbName)
        {
            DatabaseOptions databaseOptions = new DatabaseOptions(_xmlConfigPath, dbName);
            databaseOptions.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenForm(null);
        }
    }
}
