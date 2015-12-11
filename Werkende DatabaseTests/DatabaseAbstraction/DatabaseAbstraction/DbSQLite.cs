using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DatabaseAbstraction
{
    /// <summary>
    /// This class separates SQLite database operations from
    /// the SQLite it's own objects & methods, which allows separation
    /// of components. This way we can create our own 'DAL' (Database
    /// Abstraction Layer), so we can always use the same code, even
    /// if other lower level components of SQLite will be changed.
    /// 
    /// This class depends on the DbManagerBase class.
    /// </summary>
    class DbSQLite : DbManagerBase
    {
        /// <summary>
        /// Contains the SQLite connection.
        /// </summary>
        private SQLiteConnection __conn;

        /// <summary>
        /// Contains the full (UNC) path to the SQLite database file.
        /// </summary>
        private String __path;

        /// <summary>
        /// Initializes this (and the parent) object and sets up the connection object.
        /// </summary>
        /// <param name="type">The DbManagerBase database type (static int)</param>
        /// <param name="path">The full path to the SQLite database</param>
        public DbSQLite(string path)
        {
            // Sets the database type.
            this._setType(DbManagerBase.DB_SQLITE);

            // Sets the full file path...
            this.__path = path;
            this.__setupConnection();
        }

        /// <summary>
        /// Sets up the connection object.
        /// </summary>
        private void __setupConnection()
        {
            try
            {
                this.__conn = new SQLiteConnection("DataSource=" + this.__path);
                this.__conn.Close(); // Make sure connection is NOT open!
            }
            catch (SQLiteException e)
            {
                this._showConnectErrorMsg(e);
            }
        }

        /// <summary>
        /// Opens the connection to the database engine.
        /// </summary>
        private void __openConn()
        {
            try
            {
                this.__conn.Open();
            }
            catch (SQLiteException e)
            {
                this._showConnectErrorMsg(e);
            }
        }

        /// <summary>
        /// Opens the connection to the database engine.
        /// This happens asynchronously.
        /// </summary>
        private async void __openConnAsync()
        {
            try
            {
                await this.__conn.OpenAsync();
            }
            catch (SQLiteException e)
            {
                this._showConnectErrorMsg(e);
            }
        }

        /// <summary>
        /// Closes the connection to the database engine.
        /// </summary>
        private void __closeConn()
        {
            try
            {
                this.__conn.Close();
            }
            catch (SQLiteException e)
            {
                this._showDisconnectErrorMsg(e);
            }
        }

        /// <summary>
        /// Returns the connection object.
        /// </summary>
        /// <returns>SQLiteConnection</returns>
        public SQLiteConnection getConnection()
        {
            return this.__conn;
        }

        /// <summary>
        /// This method provides a SELECT command.
        /// </summary>
        /// <param name="query">The query string with named placeholders.</param>
        /// <param name="qParams">The query parameters (named placeholders)</param>
        /// <returns>DataTable</returns>
        public DataTable select(string query, Dictionary<string, dynamic> qParams = null)
        {
            // Prepend select statement (saves some typing).
            query = "SELECT " + query;

            // Create datatable.
            DataTable dt = new DataTable();

            // Build command and open connection.
            SQLiteCommand com = base._bindParams(new SQLiteCommand(query), qParams);
            this.__openConn();
            com.Connection = this.__conn;

            // Read result set.
            try
            {
                SQLiteDataReader reader = com.ExecuteReader();

                // Load resulting data into datatable and close reader.
                dt.BeginLoadData(); // For performance. It disables some indexing / monitoring.
                dt.Load(reader);
                dt.EndLoadData(); // Re-enables some indexing / monitoring tools.
                reader.Close();
            }
            catch (InvalidOperationException e)
            {
                this._showConnectErrorMsg("SELECT", e);
            }
            finally
            {
                // Close connections
                this.__closeConn();
                com.Dispose();
            }
            
            // Return datatable with all information.
            return dt;
        }

        /// <summary>
        /// Inserts one or more records into the SQLite database.
        /// Requires a Dictionary<string, dynamic> object to process
        /// query variables.
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <param name="qParams">The Dictionary with query parameters</param>
        public void insert(String query, Dictionary<string, dynamic> qParams)
        {
            query = "INSERT INTO " + query;
            this.__execCommand(query, qParams);
        }
        
        /// <summary>
        /// Updates one or more records into the SQLite database.
        /// Requires a Dictionary<string, dynamic> object to process
        /// query variables.
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <param name="qParams">The Dictionary with query parameters</param>
        public void update(String query, Dictionary<string, dynamic> qParams)
        {
            query = "UPDATE " + query;
            this.__execCommand(query, qParams);
        }

        /// <summary>
        /// Deletes one or more records into the SQLite database.
        /// Requires a Dictionary<string, dynamic> object to process
        /// query variables.
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <param name="qParams">The Dictionary with query parameters</param>
        public void delete(String query, Dictionary<string, dynamic> qParams)
        {
            query = "DELETE " + query;
            this.__execCommand(query, qParams);
        }

        /// <summary>
        /// Is able to execute either an INSERT, UPDATE or DELETE query.
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <param name="qParams">The parameters to bind to the query</param>
        private async void __execCommand(String query, Dictionary<string, dynamic> qParams)
        {
            // Makes sure that the parameters are not empty.
            this._checkParams(qParams);

            // Setup DB command and perform connect.
            SQLiteCommand com = base._bindParams(new SQLiteCommand(query), qParams);
            this.__openConnAsync();
            com.Connection = this.__conn;

            try
            {
                await com.ExecuteNonQueryAsync();
            }
            catch (SQLiteException e)
            {
                this._showConnectErrorMsg(query.Substring(0, 6), e);
            }
            finally
            {
                // Close connections
                this.__closeConn();
                com.Dispose();
            }
        }
    }
}
