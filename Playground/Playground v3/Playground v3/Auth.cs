using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Playground_v3
{
    class Auth
    {
        private static Dictionary<int, string> _funcDictionary;
        private static List<KeyValuePair<int, int>> _userGroupDictionary;
        private static List<KeyValuePair<int, int>> _funcGroupDictionary;  
        private static KeyValuePair<int, string> _user;

        private static System.Timers.Timer _timer;


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

                if (openFileDialog.ShowDialog() != DialogResult.OK) Application.Exit();

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
            try
            {
                await sqLiteConnection.OpenAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Exception opening .db: " + ex);
                Application.Exit();
            }
        }

        /// <summary>
        /// Make sure all functions exist in the database and cache some stuff for later use
        /// </summary>
        /// <param name="funcList">All functions used in the program</param>
        public static async void Init(List<string> funcList)
        {
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                Dictionary<int, string> funcFromDb = GetFuncDictionary();

                // For each value in funcList wich is not in the database, add it.
                foreach (string value in funcList.Where(value => !funcFromDb.ContainsValue(value)))
                {
                    OpenSqLiteConnection(conn);

                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO func (name) VALUES (@name)";
                    cmd.Parameters.Add(new SQLiteParameter("@name") { Value = value });

                    await cmd.ExecuteNonQueryAsync();

                    conn.Close();
                }
            }

            // Set the current user
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            Dictionary<int, string> userDictionary = GetUserDictionary();

            _user = userDictionary.FirstOrDefault(x => x.Value == windowsIdentity?.Name);

            MessageBox.Show(_user.ToString());

            // Execute this immediatly, prevent a nullreferenceexception on HassAccessTo
            TimerTick(null, null);

            _timer = new System.Timers.Timer(30000); // 30 seconds
            _timer.Elapsed += TimerTick;
            _timer.Start();
        }

        private static void TimerTick(object sender, ElapsedEventArgs e)
        {
            _funcDictionary = GetFuncDictionary();
            _userGroupDictionary = GetUserGroupList();
            _funcGroupDictionary = GetFuncGroupList();

            if (_user.Key != 0) return;

            // Set the current user
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            Dictionary<int, string> userDictionary = GetUserDictionary();

            _user = userDictionary.FirstOrDefault(x => x.Value == windowsIdentity?.Name);
        }

        /// <summary>
        /// Determine wether the current user has access to the given function
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool HasAccessTo(string func)
        {
            // Get key by value
            int funcId = _funcDictionary.FirstOrDefault(x => x.Value == func).Key;

            // Generate a list with all groups containing the given function id
            List<int> groupList = (
                    from funcGroupKvPair 
                    in _funcGroupDictionary
                    where funcGroupKvPair.Key == funcId
                    select funcGroupKvPair.Value
                ).ToList();

            // Determine if the current user is in any of the given groups
            return _userGroupDictionary.Any(userGroupkvPair => userGroupkvPair.Key == _user.Key && groupList.Contains(userGroupkvPair.Value));
        }

        /// <summary>
        /// Get the currently logged in user
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<int, string> GetUser()
        {
            return _user;
        }

        /// <summary>
        /// Get all functions 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetFuncDictionary()
        {
            // Get the sqlite connection and open it
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                OpenSqLiteConnection(conn);
                // Create the command and insert the query

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM func";

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
        }

        /// <summary>
        /// Get all groups returned in a Dictionary
        /// </summary>
        /// <returns>Key = groupId, Value = Group name</returns>
        public static Dictionary<int, string> GetGroupDictionary()
        {
            // Get the sqlite connection and open it
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
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
        }

        /// <summary>
        /// Get all users returned in a dictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetUserDictionary()
        {
            // Get the sqlite connection and open it
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
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
        }

        /// <summary>
        /// Get all entries in the join table, wich combines users to groups
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<int, int>> GetUserGroupList()
        {
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
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
                
        }

        /// <summary>
        /// Get all entries in the join table, wich combines the functions to groups
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<int, int>> GetFuncGroupList()
        {
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                OpenSqLiteConnection(conn);

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM func_groups";

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
                
        }

        /// <summary>
        /// Add a user with the given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>The userId of the new user or 0 if no user is added</returns>
        public static long AddUser(string username)
        {
            // Get the sqlite connection and open it
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                OpenSqLiteConnection(conn);

                // Create the command, set the command text with a named parameter and add the parameter value
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO users (username) VALUES(@username)";
                cmd.Parameters.Add(new SQLiteParameter("@username") {Value = username});

                // Execute the query, if the no affected rows is not 1, user is not added
                if (cmd.ExecuteNonQuery() != 1) return 0;

                // Get the last inserted row id and return it
                cmd.CommandText = "SELECT last_insert_rowid()";

                long result = (long)cmd.ExecuteScalar();

                conn.Close();

                return result;
            }
            
        }

        /// <summary>
        /// Add a group with the given groupname
        /// </summary>
        /// <param name="groupname"></param>
        /// <returns>The groupId of the newly created group, or 0 if no user is added</returns>
        public static long CreateGroup(string groupname)
        {
            // Get the sqlite connection and open it
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                OpenSqLiteConnection(conn);

                // Create the command, set the command text with a named parameter and add the parameter value
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO groups (groupname) VALUES(@groupname)";
                cmd.Parameters.Add(new SQLiteParameter("@groupname") {Value = groupname});

                // Execute the query, if the no affected rows is not 1, group is not added
                if (cmd.ExecuteNonQuery() != 1) return 0;

                // Get the last inserted row id and return it
                cmd.CommandText = "SELECT last_insert_rowid()";

                long result = (long) cmd.ExecuteScalar();

                conn.Close();

                return result;
            }
            
        }

        /// <summary>
        /// Update the users_groups table according to the given list
        /// </summary>
        /// <param name="userGroupList"></param>
        /// <returns>Is the operation succesful</returns>
        public static async Task<bool> UpdateUserGroup(List<KeyValuePair<int, int>> userGroupList)
        {
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
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

                conn.Close();

                return successful;
            }
                
        }

        /// <summary>
        /// Update the func_groups table according to the funcGroupList
        /// </summary>
        /// <param name="funcGroupList"></param>
        /// <returns></returns>
        public static async Task<bool> UpdateFuncGroup(List<KeyValuePair<int, int>> funcGroupList)
        {
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                OpenSqLiteConnection(conn);

                SQLiteCommand cmd = conn.CreateCommand();
                // Delete all rows from the table
                cmd.CommandText = "DELETE FROM func_groups";
                await cmd.ExecuteNonQueryAsync();

                // Insert one new row per time
                cmd.CommandText = "INSERT INTO func_groups (func_id, groups_id) VALUES (@func_id, @groups_id)";

                // Add parameters
                SQLiteParameter funcIdParameter = new SQLiteParameter("@func_id");
                cmd.Parameters.Add(funcIdParameter);
                SQLiteParameter groupIdParameter = new SQLiteParameter("@groups_id");
                cmd.Parameters.Add(groupIdParameter);

                bool successful = true;

                foreach (KeyValuePair<int, int> kvPair in funcGroupList)
                {
                    // Asign values to the parameters
                    funcIdParameter.Value = kvPair.Key;
                    groupIdParameter.Value = kvPair.Value;

                    // Execute the query async
                    int affectedrows = await cmd.ExecuteNonQueryAsync();

                    // Check if this operation and all previous ones were successful
                    successful = affectedrows == 1 && successful;
                }

                conn.Close();

                return successful;
            }
                
        }

        /// <summary>
        /// Delete the user with the given id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true if user is deleted</returns>
        public static async Task<bool> DeleteUser(int userId)
        {
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                OpenSqLiteConnection(conn);

                SQLiteCommand cmd = conn.CreateCommand();
            
                // Delete row with given user id
                cmd.CommandText = "DELETE FROM users WHERE id = @userId";
                cmd.Parameters.Add(new SQLiteParameter("@userId") {Value = userId});

                int rowsAffected = await cmd.ExecuteNonQueryAsync();

                conn.Close();

                return rowsAffected == 1;
            }
                
        }

        /// <summary>
        /// Delete the group with the givven id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteGroup(int groupId)
        {
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                OpenSqLiteConnection(conn);

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM groups WHERE id = @groupId";
                cmd.Parameters.Add(new SQLiteParameter("@groupId") {Value = groupId});

                int rowsAffected = await cmd.ExecuteNonQueryAsync();

                conn.Close();

                return rowsAffected == 1;
            }
                
        }

    }
}
