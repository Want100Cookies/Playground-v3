using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Playground_v3
{
    class Settings
    {

        public static bool CheckConfigFileExists()
        {
            string settingsFile = ConfigurationManager.AppSettings["configurationFile"];

            if (File.Exists(settingsFile)) return true;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter              = @"Settings file (settings.config)|settings.config|Config file (*.config)|*.config|All files (*.*)|*.*",
                FilterIndex         = 0,
                RestoreDirectory    = true,
                CheckFileExists     = true,
                InitialDirectory    = AppDomain.CurrentDomain.BaseDirectory
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return false;

            ConfigurationManager.AppSettings.Remove("configurationFile");
            ConfigurationManager.AppSettings.Add("configurationFile", openFileDialog.FileName);

            return true;
        }


        public static string GetSettingValue(string key)
        {
            XmlDocument document = new XmlDocument();
            document.Load(ConfigurationManager.AppSettings["configurationFile"]);

            // select the connectionstrings node
            XmlNode node = document.SelectSingleNode("configuration/appSettings");

            XmlNode currentNode = node?.SelectSingleNode("//add[@key='" + key + "']");

            return currentNode?.Attributes?["value"].Value;
        }

        public static void AddSetting(string key, string value)
        {
            throw new NotImplementedException();
        }

        public static void RemoveSetting(string key)
        {
            throw new NotImplementedException();
        }

        public static string GetConfigFile()
        {
            return ConfigurationManager.AppSettings["configurationFile"];
        }

        public static SQLiteConnection GetSqLiteConnection()
        {
            string databaseFile = GetSettingValue("userDatabaseFile");

            if (!File.Exists(databaseFile))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = @"Database file (*.db)|*.db|All files (*.*)|*.*",
                    FilterIndex = 0,
                    RestoreDirectory = true,
                    CheckFileExists = true,
                    InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK) return null;

                //RemoveSetting("configurationFile");
                //AddSetting("configurationFile", openFileDialog.FileName);
                MessageBox.Show(openFileDialog.FileName);
            }

            return new SQLiteConnection(GetSettingValue("userDatabaseFile"));
        }

    }
}
