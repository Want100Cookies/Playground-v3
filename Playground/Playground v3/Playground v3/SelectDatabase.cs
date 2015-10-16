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
using System.Configuration;


namespace Playground_v3
{
    public partial class SelectDatabase : Form
    {


        public SelectDatabase()
        {
            InitializeComponent();
            setConfigFile(ConfigurationManager.AppSettings["settingsFile"]);
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            lstBoxDatabases.Items.Clear();

            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                lstBoxDatabases.Items.Add(connectionString.Name);
            }


            //foreach (XmlNode childNode in node)
            //{
            //    if (childNode.Attributes != null) lstBoxDatabases.Items.Add(childNode.Attributes["name"].Value);
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string dbName = lstBoxDatabases.SelectedItem.ToString();
            OpenForm(dbName);

        }

        private void OpenForm(string dbName)
        {
            //DatabaseOptions databaseOptions = new DatabaseOptions(_xmlConfigPath, dbName);
            //databaseOptions.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenForm(null);
        }

                    

        private static void setConfigFile(string configFilePath)
        {
            if (configFilePath.Length == 0)
            {
                MessageBox.Show("Nope");
                return;
            }

            var runtimeconfigfile = configFilePath;

            ExeConfigurationFileMap configurationFileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = runtimeconfigfile
            };

            // Specify config settings at runtime.
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configurationFileMap, ConfigurationUserLevel.None);

            //Similarly you can apply for other sections like SMTP/System.Net/System.Web etc..
            //But you have to set the File Path for each of these 
            //config.AppSettings.File = runtimeconfigfile;

            //This doesn't actually going to overwrite you Exe App.Config file.
            //Just refreshing the content in the memory.
            config.Save(ConfigurationSaveMode.Modified);

            //Refreshing Config Section
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
