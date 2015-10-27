using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playground_v3
{
    class Auth
    {

        /// <summary>
        /// Get a working SQLiteConnection or null if no database file found
        /// </summary>
        /// <returns></returns>
        private static SQLiteConnection GetSqLiteConnection()
        {
            // Check if the file is an actual file
            if (!File.Exists(Settings.GetSetting("userDatabaseFile")))
            {
                // If not, open a openfiledialog to retrieve one and save it to the Settings
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = @"Database file (*.db)|*.db|All files (*.*)|*.*",
                    FilterIndex = 0,
                    RestoreDirectory = true,
                    CheckFileExists = true,
                    InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK) return null;

                Settings.RemoveSetting("userDatabaseFile");
                Settings.AddSetting("userDatabaseFile", openFileDialog.FileName);
            }

            // Generate a SQLiteConnection with the file from the settings
            return new SQLiteConnection("Data Source=" + Settings.GetSetting("userDatabaseFile"));
        }

        /// <summary>
        /// Open the given SQLiteConnection async
        /// </summary>
        /// <param name="sqLiteConnection"></param>
        private static async void OpenSqLiteConnection(SQLiteConnection sqLiteConnection)
        {
            await sqLiteConnection.OpenAsync();
        }

        /// <summary>
        /// Get all groups returned in a Dictionary
        /// </summary>
        /// <returns>Key = groupId, Value = Group name</returns>
        public static Dictionary<int, string> GetGroupDictionary()
        {
            // Get the sqlite connection and open it
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            // Create the command and insert the query
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM groups";

            // Execute the command and put it in a new reader
            SQLiteDataReader reader = cmd.ExecuteReader();

            // Initialise a dictionary
            Dictionary<int, string> list = new Dictionary<int, string>(reader.StepCount);

            while (reader.Read())
            {
                // For each record, get the integer id and the string name, and add it to the dictionary
                list.Add(reader.GetInt32(0), reader.GetString(1));
            }

            // Close the connection to prevent runtime errors
            conn.Close();

            return list;
        }

        /// <summary>
        /// Get all users returned in a dictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetUserList()
        {
            // Get the sqlite connection and open it
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            // Create the command and insert the query
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM users";

            // Execute the command and put it in a new reader
            SQLiteDataReader reader = cmd.ExecuteReader();

            // Initialise a dictionary
            Dictionary<int, string> list = new Dictionary<int, string>(reader.StepCount);

            while (reader.Read())
            {
                // For each record, get the integer id and the string name, and add it to the dictionary
                list.Add(reader.GetInt32(0), reader.GetString(1));
            }

            // Close the connection to prevent runtime errors
            conn.Close();

            return list;
        }

        /// <summary>
        /// Get all entries in the join table, wich combines users to groups
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<int, int>> GetUserGroupList()
        {
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM users_groups";

            SQLiteDataReader reader = cmd.ExecuteReader();

            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>(reader.StepCount);

            while (reader.Read())
            {
                KeyValuePair<int, int> kvPair = new KeyValuePair<int, int>(reader.GetInt32(1), reader.GetInt32(2));
                list.Add(kvPair);
            }

            conn.Close();

            return list;
        }

        /// <summary>
        /// Add the user with the given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>The userId of the new user or 0 if no user is added</returns>
        public static long AddUser(string username)
        {
            // Get the sqlite connection and open it
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            // Create the command, set the command text with a named parameter and add the parameter value
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO users (username) VALUES(@username)";
            cmd.Parameters.Add(new SQLiteParameter("@username") {Value = username});

            // Execute the query, if the no affected rows is not 1 user is not added
            if (cmd.ExecuteNonQuery() != 1) return 0;

            // Get the last inserted row id and return it
            cmd.CommandText = "SELECT last_insert_rowid()";
            return (long) cmd.ExecuteScalar();
        }

    }
}
