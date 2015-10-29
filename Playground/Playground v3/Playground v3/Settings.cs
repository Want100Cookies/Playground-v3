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
using System.Xml.Serialization;

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
                parentNode.RemoveChild(childNode);
            }

            // Save the document
            document.Save(GetConfigFile());
        }

        /// <summary>
        /// Retrieve a list with available connectionstrings
        /// </summary>
        /// <returns>name, providerName and the connectionString in an struct</returns>
        public static List<ConnectionStringStruct> GetConnectionstringList()
        {
            // Get the document
            XmlDocument document = GetXmlDocument(GetConfigFile());

            // Get the node wich contains all the connection strings
            XmlNode parentNode = document.SelectSingleNode("configuration/connectionStrings");

            if (parentNode == null) return null;

            List<ConnectionStringStruct> connectionStrings = new List<ConnectionStringStruct>(parentNode.ChildNodes.Count);

            /*  
                LinQ expression to generate List with ConnectionStringStructs
                This is how it works:
                - For each XmlNode in parenNode.ChildNodes
                - Only get XmlNodeType.Elements
                - Make new ConnectionStringStruct
                - Add the values if they exist (hence the ? operator)            
            */

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
        }

        /// <summary>
        /// Get a single connection string
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns>A struct representing a connection string</returns>
        public static ConnectionStringStruct GetConnectionString(string connectionName)
        {
            // Get the document
            XmlDocument document = GetXmlDocument(GetConfigFile());

            // Get the node wich contains the connection string
            XmlNode connectionNode = document.SelectSingleNode("configuration/connectionStrings/add[@name='" + connectionName + "']");

            if (connectionNode != null)
            {
                return new ConnectionStringStruct()
                {
                    name = connectionName,
                    connectionString = connectionNode.Attributes?["connectionString"].Value,
                    providerName = connectionNode.Attributes?["providerName"].Value
                };
            }

            return new ConnectionStringStruct();
        }

        /// <summary>
        /// Add a connectionstring to the configuration file
        /// </summary>
        /// <param name="connectionString"></param>
        public static void AddConnectionString(ConnectionStringStruct connectionString)
        {
            // Get the document
            XmlDocument document = GetXmlDocument(GetConfigFile());

            // Get the node wich contains all the connection strings
            XmlNode parentNode = document.SelectSingleNode("configuration/connectionStrings");

            // Create a new element
            XmlElement newElement = document.CreateElement("add");

            // Define the new attributes
            XmlAttribute nameAttribute = document.CreateAttribute("name");
            nameAttribute.Value = connectionString.name;
            XmlAttribute connectionStringAttribute = document.CreateAttribute("connectionString");
            connectionStringAttribute.Value = connectionString.connectionString;
            XmlAttribute providerNameAttribute = document.CreateAttribute("providerName");
            providerNameAttribute.Value = connectionString.providerName;

            // Append them to the new element
            newElement.Attributes.Append(nameAttribute);
            newElement.Attributes.Append(connectionStringAttribute);
            newElement.Attributes.Append(providerNameAttribute);

            // Append the new element to the peren node
            parentNode?.AppendChild(newElement);

            // Save the document
            document.Save(GetConfigFile());
        }

        public static void RemoveConnectionString(string connectionName)
        {
            // Get the document
            XmlDocument document = GetXmlDocument(GetConfigFile());

            // Get the node wich contains all the connection strings
            XmlNode parentNode = document.SelectSingleNode("configuration/connectionStrings");

            // Prevent nullReferenceException
            if (parentNode?.ChildNodes == null) return;

            // Using linq loop over all connection strings and search for the specified database name
            foreach (XmlNode childNode in parentNode
                .ChildNodes
                .Cast<XmlNode>()
                .Where(
                    childNode => childNode.Attributes != null 
                    && 
                    childNode.NodeType == XmlNodeType.Element // we don't want any comments
                    && 
                    childNode.Attributes["name"].Value == connectionName
                    ))
            {
                // Remove the node
                parentNode.RemoveChild(childNode);
            }

            // Save the document
            document.Save(GetConfigFile());
        }

    }
}
