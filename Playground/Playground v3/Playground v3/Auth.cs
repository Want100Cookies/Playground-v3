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
        public static SQLiteConnection GetSqLiteConnection()
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
        public static async void OpenSqLiteConnection(SQLiteConnection sqLiteConnection)
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
                KeyValuePair<int, int> kvPair = new KeyValuePair<int, int>(reader.GetInt32(0), reader.GetInt32(1));
                list.Add(kvPair);
            }

            conn.Close();

            return list;
        }

        /// <summary>
        /// Add a user with the given username
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

            // Execute the query, if the no affected rows is not 1, user is not added
            if (cmd.ExecuteNonQuery() != 1) return 0;

            // Get the last inserted row id and return it
            cmd.CommandText = "SELECT last_insert_rowid()";
            return (long) cmd.ExecuteScalar();
        }

        /// <summary>
        /// Add a group with the given groupname
        /// </summary>
        /// <param name="groupname"></param>
        /// <returns>The groupId of the newly created group, or 0 if no user is added</returns>
        public static long CreateGroup(string groupname)
        {
            // Get the sqlite connection and open it
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            // Create the command, set the command text with a named parameter and add the parameter value
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO groups (groupname) VALUES(@groupname)";
            cmd.Parameters.Add(new SQLiteParameter("@groupname") {Value = groupname});

            // Execute the query, if the no affected rows is not 1, group is not added
            if (cmd.ExecuteNonQuery() != 1) return 0;

            // Get the last inserted row id and return it
            cmd.CommandText = "SELECT last_insert_rowid()";
            return (long) cmd.ExecuteScalar();
        }

        /// <summary>
        /// Update the users_groups table according to the given list
        /// </summary>
        /// <param name="userGroupList"></param>
        /// <returns>Is the operation succesful</returns>
        public static async Task<bool> UpdateUserGroup(List<KeyValuePair<int, int>> userGroupList)
        {
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            SQLiteCommand cmd = conn.CreateCommand();
            // Delete all rows from the table
            cmd.CommandText = "DELETE FROM users_groups";
            await cmd.ExecuteNonQueryAsync();
            
            // Insert one new row per time
            cmd.CommandText = "INSERT INTO users_groups (users_id, groups_id) VALUES (@users_id, @groups_id)";

            // Add parameters
            SQLiteParameter userIdParameter = new SQLiteParameter("@users_id");
            cmd.Parameters.Add(userIdParameter);
            SQLiteParameter groupIdParameter = new SQLiteParameter("@groups_id");
            cmd.Parameters.Add(groupIdParameter);

            bool successful = true;

            foreach (KeyValuePair<int, int> kvPair in userGroupList)
            {
                // Asign values to the parameters
                userIdParameter.Value = kvPair.Key;
                groupIdParameter.Value = kvPair.Value;

                // Execute the query async
                int affectedrows = await cmd.ExecuteNonQueryAsync();

                // Check if this operation and all previous ones were successful
                successful = affectedrows == 1 && successful;
            }

            return successful;
        }

    }
}
