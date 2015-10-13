using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Playground_v3
{
    public partial class Form1 : Form
    {

        private Thread _databaseOptionsThread;

        private readonly string _xmlConfigPath;

        public Form1()
        {
            InitializeComponent();
            _xmlConfigPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            populateListBox();
        }

        private void populateListBox()
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
            _databaseOptionsThread = new Thread(() => openForm(dbName));
            _databaseOptionsThread.Start();
        }

        private void openForm(String dbName)
        {
            DatabaseOptions databaseOptions = new DatabaseOptions(_xmlConfigPath, dbName);
            Application.Run(databaseOptions);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _databaseOptionsThread = new Thread(() => openForm(null));
            _databaseOptionsThread.Start();
        }
    }
}
