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

        /// <summary>
        /// Get the configuration file from the app.config
        /// This file is delivered with the application
        /// </summary>
        /// <returns>Returns the filepath to the configuration file, return null if value does not exist.</returns>
        public static string GetConfigFile()
        {
            return ConfigurationManager.AppSettings["configurationFile"];
        }

        /// <summary>
        /// Sets the filepath of the configuration file to the given value in app.config
        /// </summary>
        /// <param name="filePath">The filepath to settings file</param>
        public static void SetConfigFile(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("Configuration file is not found, or is not accessible.");

            ConfigurationManager.AppSettings.Remove("configurationFile");
            ConfigurationManager.AppSettings.Add("configurationFile", filePath);
        }

        /// <summary>
        /// Sets the config file with a open file dialog, utilizing the SetConfigFile(string filePath) method
        /// </summary>
        public static void SetConfigFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = @"Settings file (settings.config)|settings.config|Config file (*.config)|*.config|All files (*.*)|*.*",
                FilterIndex = 0,
                RestoreDirectory = true,
                CheckFileExists = true,
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) Application.Exit();

            SetConfigFile(openFileDialog.FileName);
        }

        /// <summary>
        /// Check if the configuration file is an actual existing file
        /// </summary>
        /// <returns>File.Exists(GetConfigFile())</returns>
        public static bool CheckConfigFileExists()
        {
            return File.Exists(GetConfigFile());
        }

        /// <summary>
        /// Get the fully loaded xml document for further use
        /// </summary>
        /// <param name="configFile">The file that should be loaded in the xml document</param>
        /// <returns>The fully loaded xml document</returns>
        private static XmlDocument GetXmlDocument(string configFile)
        {
            XmlDocument document = new XmlDocument();

            if (!CheckConfigFileExists())
            {
                throw new FileNotFoundException("Configuration file is not found, or is not accessible.");
            }

            document.Load(configFile);

            return document;
        }


        /// <summary>
        /// Get the value from the configuration file associated with the given key
        /// </summary>
        /// <param name="key">The key of the needed setting</param>
        /// <returns>The value associated with the given key</returns>
        public static string GetSetting(string key)
        {
            XmlDocument document = GetXmlDocument(GetConfigFile());

            XmlNode node = document.SelectSingleNode("configuration/appSettings");

            XmlNode currentNode = node?.SelectSingleNode("//add[@key='" + key + "']");

            return currentNode?.Attributes?["value"].Value;
        }

        /// <summary>
        /// Add a new setting to the configuration file
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddSetting(string key, string value)
        {
            // Get the document
            XmlDocument document = GetXmlDocument(GetConfigFile());

            // Get the node wich should contain the new setting
            XmlNode parentNode = document.SelectSingleNode("configuration/appSettings");

            // Create the new element
            XmlElement newElement = document.CreateElement("add");

            // Create the key and value attributes and fill them
            XmlAttribute keyAttribute = document.CreateAttribute("key");
            keyAttribute.Value = key;
            XmlAttribute valueAttribute = document.CreateAttribute("value");
            valueAttribute.Value = value;

            // Append the attributes to the new element
            newElement.Attributes.Append(keyAttribute);
            newElement.Attributes.Append(valueAttribute);

            // Append the new element to the parent node (but only if it exists)
            parentNode?.AppendChild(newElement);

            // Save the document to storage
            document.Save(GetConfigFile());
        }

        /// <summary>
        /// Remove the specified setting from the configuration file
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveSetting(string key)
        {
            // Get the document
            XmlDocument document = GetXmlDocument(GetConfigFile());

            // Get the node wich contains all the settings
            XmlNode parentNode = document.SelectSingleNode("configuration/appSettings");

            // Prevent nullReferenceException
            if (parentNode?.ChildNodes == null) return;

            // Using linq loop over all settings and search for the specified key
            foreach (XmlNode childNode in parentNode
                .ChildNodes
                .Cast<XmlNode>()
                .Where(childNode => childNode.Attributes != null && childNode.Attributes["key"].Value == key))
            {
                // Remove the node
                childNode.RemoveAll();
            }

            // Save the document
            document.Save(GetConfigFile());
        }

        public static List<ConnectionStringStruct> GetConnectionstringList()
        {
            // Get the document
            XmlDocument document = GetXmlDocument(GetConfigFile());

            // Get the node wich contains all the connection strings
            XmlNode parentNode = document.SelectSingleNode("configuration/connectionStrings");

            /*  
                LinQ expression to generate List with ConnectionStringStructs
                This is how it works:
                - For each XmlNode in parenNode.ChildNodes
                - Only get XmlNodeType.Elements
                - Make new ConnectionStringStruct
                - Add the values if they exist (hence the ? operator)            
            */

            if (parentNode == null) return null;

            List<ConnectionStringStruct> connectionStrings = new List<ConnectionStringStruct>(parentNode.ChildNodes.Count);

            connectionStrings.AddRange(
                from XmlNode childNode in parentNode.ChildNodes
                where childNode.NodeType == XmlNodeType.Element
                select new ConnectionStringStruct()
                {
                    name = childNode.Attributes?["name"].Value,
                    connectionString = childNode.Attributes?["connectionString"].Value,
                    providerName = childNode.Attributes?["providerName"].Value
                });

            return connectionStrings;

            /*
                OLD CODE:
                return parentNode
                    ?.ChildNodes
                    .Cast<XmlNode>()
                    .Where(childNode => childNode.NodeType != XmlNodeType.Comment)
                    .ToDictionary(
                        childNode => childNode.Attributes?["name"].ToString(), 
                        childNode => childNode.Attributes?["connectionString"].ToString()
                        );
            */
        }

        /// <summary>
        /// Get the SqLite connection wich is needed for Auth
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetSqLiteConnection()
        {
            if (!File.Exists(GetSetting("userDatabaseFile")))
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

                RemoveSetting("userDatabaseFile");
                AddSetting("userDatabaseFile", openFileDialog.FileName);
            }

            return new SQLiteConnection("Data Source=" + GetSetting("userDatabaseFile"));
        }

    }
}
