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

        private static SQLiteConnection GetSqLiteConnection()
        {
            if (!File.Exists(Settings.GetSetting("userDatabaseFile")))
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

                Settings.RemoveSetting("userDatabaseFile");
                Settings.AddSetting("userDatabaseFile", openFileDialog.FileName);
            }

            return new SQLiteConnection("Data Source=" + Settings.GetSetting("userDatabaseFile"));
        }

        private static async void OpenSqLiteConnection(SQLiteConnection sqLiteConnection)
        {
            await sqLiteConnection.OpenAsync();
        }

        public static Dictionary<int, string> GetGroupList()
        {
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM groups";

            SQLiteDataReader reader = cmd.ExecuteReader();

            Dictionary<int, string> list = new Dictionary<int, string>(reader.StepCount);

            while (reader.Read())
            {
                list.Add(reader.GetInt32(0), reader.GetString(1));
            }

            conn.Close();

            return list;
        }

        public static Dictionary<int, string> GetUserList()
        {
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM users";

            SQLiteDataReader reader = cmd.ExecuteReader();

            Dictionary<int, string> list = new Dictionary<int, string>(reader.StepCount);

            while (reader.Read())
            {
                list.Add(reader.GetInt32(0), reader.GetString(1));
            }

            conn.Close();

            return list;
        }

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

        public static long AddUser(string username)
        {
            SQLiteConnection conn = GetSqLiteConnection();
            OpenSqLiteConnection(conn);

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO users (username) VALUES(@username)";
            cmd.Parameters.Add(new SQLiteParameter("@username") {Value = username});

            if (cmd.ExecuteNonQuery() != 1) return 0;

            cmd.CommandText = "SELECT last_insert_rowid()";
            return (long) cmd.ExecuteScalar();
        }

    }
}
