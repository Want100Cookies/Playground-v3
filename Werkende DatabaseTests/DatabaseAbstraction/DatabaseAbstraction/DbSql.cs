using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAbstraction
{
    class DbSql : DbManagerBase
    {
        /// <summary>
        /// Holds the connection object.
        /// </summary>
        private SqlConnection __conn;

        /// <summary>
        /// Connection string for the database.
        /// </summary>
        private String __dsn;

        /// <summary>
        /// Stores the connection string and sets up the connection object.
        /// </summary>
        /// <param name="dsn">The connection string</param>
        public DbSql(string dsn)
        {
            this._setType(DbManagerBase.DB_MSSQL);

            // Sets the full file path...
            this.__dsn = dsn;
            this.__setupConnection();
        }

        /// <summary>
        /// Sets up the connection object.
        /// </summary>
        private void __setupConnection()
        {
            try
            {
                this.__conn = new SqlConnection(this.__dsn);
                this.__conn.Close(); // Make sure connection is NOT open!
            }
            catch (SqlException e)
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
            catch (SqlException e)
            {
                this._showConnectErrorMsg(e);
            }
        }

        /// <summary>
        /// Opens the connection to the database engine.
        /// This method does it asynchronously.
        /// </summary>
        private async void __openConnAsync()
        {
            try
            {
                await this.__conn.OpenAsync();
            }
            catch (SqlException e)
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
            catch (SqlException e)
            {
                this._showDisconnectErrorMsg(e);
            }
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
            SqlCommand com = base._bindParams(new SqlCommand(query), qParams);
            this.__openConn();
            com.Connection = this.__conn;

            // Read result set.
            try
            {
                SqlDataReader reader = com.ExecuteReader();

                // Load resulting data into datatable.
                dt.BeginLoadData(); // For performance. It disables some indexing / monitoring.
                dt.Load(reader);
                dt.EndLoadData(); // Re-enables some indexing / monitoring tools.

                // Close the reader.
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
            SqlCommand com = base._bindParams(new SqlCommand(query), qParams);
            this.__openConnAsync();
            com.Connection = this.__conn;

            try
            {
                await com.ExecuteNonQueryAsync();
            }
            catch (SqlException e)
            {
                this._showConnectErrorMsg(query.Substring(0, 6), e);
            }

            // Close connections
            this.__closeConn();
            com.Dispose();
        }
    }
}
