using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace DatabaseAbstraction
{
    /// <summary>
    /// This class can connect with every database engine that has implemented the
    /// Open Database Connection protocol (for short: ODBC).
    /// On instantiation there is a full DSN string required (connection string)
    /// with the DRIVER specified (e.g. DRIVER=SQLite3 ODBC Driver.
    /// Connection parameters are separated by semicolons (;).
    /// 
    /// The aim of this class is to provide an easier interface for performing
    /// database operations on ODBC supported platforms.
    /// </summary>
    class OdbcDbManager
    {
        /// <summary>
        /// Some static properties that are needed to specify
        /// some DSN specific strings.
        /// </summary>
        public static readonly int DB_SQLITE = 1;
        public static readonly int DB_MSSQL = 2;
        public static readonly int DB_ODBC = 3;

        /// <summary>
        /// Holds the connection object.
        /// </summary>
        private OdbcConnection __conn;

        /// <summary>
        /// Keeps track which type this database is (see static props above).
        /// </summary>
        private int __type;
        private string __readableType;
        
        /// <summary>
        /// SQLite DSN constructor. Path needs to be replaced to let the App
        /// be somewhat portable inside the business.
        /// Path replacements happens inside __checkDbDsn() method.
        /// 
        /// Resource: https://www.connectionstrings.com/sqlite3-odbc-driver/
        /// </summary>
        private readonly string __sqliteDsn = @"DRIVER=SQLite3 ODBC Driver; Database=:path:; LongNames=0; Timeout=1000; NoTXN=0; SyncPragma=NORMAL; StepAPI = 0;";

        /// <summary>
        /// Constructor for instantiating this class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public OdbcDbManager(int type, string connString = null)
        {
            this.__type = type;
            
            if (this.__type == DB_SQLITE) this.__readableType = "SQLite";
            if (this.__type == DB_ODBC) this.__readableType = "ODBC Generic";
            if (this.__type == DB_MSSQL) this.__readableType = "MS SQL";

            this.setupConnection(connString);
        }

        /// <summary>
        /// Creates the connection object and stores it.
        /// Methods in this class need to call this.__conn.Open() to do
        /// any operations. Subsequently, the connection needs to be closed
        /// when done (like: this.__conn.Close()).
        /// </summary>
        /// <param name="connString">The connection string parameters.</param>
        public void setupConnection(string connString = null)
        {
            // Get the connection string...
            connString = this.__checkDbDsn(connString);

            if (null == connString)
            {
                throw new Exception("Connection string cannot be null!");
            }
            else
            {
                try
                {
                    // Initialize connection.
                    this.__conn = new OdbcConnection(connString);
                } catch (OdbcException e)
                {
                    MessageBox.Show("Connection could not be initialized. Error: " + e.Message);
                }
            }
        }

        /// <summary>
        /// Handles the connecting part.
        /// Also handles possible exceptions when a connection could not be opened.
        /// </summary>
        private void __connect()
        {
            try
            {
                this.__conn.Open();
            } catch (OdbcException e)
            {
                this.__handleError("SELECT", e);
            }
        }

        /// <summary>
        /// Returns the database connection object if there
        /// is a special need to do custom handling.
        /// </summary>
        /// <returns></returns>
        public OdbcConnection getConnection()
        {
            return this.__conn;
        }

        /// <summary>
        /// This method provides a SELECT command.
        /// </summary>
        /// <param name="query">The query string with named placeholders.</param>
        /// <param name="qParams">The query parameters (named placeholders)</param>
        /// <returns>DataTable</returns>
        public DataTable select(string query, Dictionary<string, string> qParams = null)
        {
            // Prepend select statement (saves some typing).
            query = "SELECT " + query;

            // Create datatable.
            DataTable dt = new DataTable();

            // Build command and open connection.
            OdbcCommand com = this.__bindParams(query, qParams);
            this.__connect();

            // Read result set.
            OdbcDataReader reader = com.ExecuteReader();

            // Load resulting data into datatable.
            dt.BeginLoadData(); // For performance. It disables some monitoring.
            dt.Load(reader);
            dt.EndLoadData();

            // Close connections
            reader.Close();
            this.__conn.Close();
            
            // Return datatable with all information.
            return dt;
        }

        /// <summary>
        /// A simple wrapper for the insert command that only accepts
        /// parameterized queries, thus preventing SQL injections.
        /// </summary>
        /// <param name="query">The query string</param>
        /// <param name="qParams">The query parameters</param>
        public void insert(string query, Dictionary<string, string> qParams = null)
        {
            // Makes sure that the parameters are not empty.
            this.__checkParams(qParams);

            query = "INSERT INTO " + query;

            // Setup DB command and perform connect.
            OdbcCommand com = this.__bindParams(query, qParams);
            this.__connect();

            try
            {
                com.ExecuteNonQuery();
            } catch (OdbcException e)
            {
                this.__handleError("INSERT", e);
            }

            this.__conn.Close();
        }

        /// <summary>
        /// Replaces UPDATE ODBC with custom version to minimize code repetition.
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="qParams">The query parameters</param>
        public void update(string query, Dictionary<string, string> qParams = null)
        {
            // Make sure that the parameters are not empty.
            this.__checkParams(qParams);

            query = "UPDATE " + query;

            // Setup DB command and perform connect.
            OdbcCommand com = this.__bindParams(query, qParams);
            this.__connect();

            try
            {
                com.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                this.__handleError("UPDATE", e);
            }

            this.__conn.Close();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="qParams"></param>
        public void delete(string query, Dictionary<string, string> qParams = null)
        {
            // Make sure that the parameters are not empty.
            this.__checkParams(qParams);

            query = "DELETE " + query;

            // Setup DB command and perform connect.
            OdbcCommand com = this.__bindParams(query, qParams);
            this.__connect();

            try
            {
                com.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                this.__handleError("DELETE", e);
            }

            this.__conn.Close();
        }

        /// <summary>
        /// Binds the parameters to the query.
        /// NOTE: The order of parameters in the dictionary matter
        ///       for the query!
        /// Example: SELECT * FROM `aTable` WHERE ? = 10
        ///          The Dictionary would contain "@id" => 10 
        ///                                       (@columnName -> value).
        /// </summary>
        /// <param name="query">The query string.</param>
        /// <param name="qParams">The query parameters with named placeholders.</param>
        /// <returns></returns>
        private OdbcCommand __bindParams(string query, Dictionary<string, string> qParams = null)
        {
            // Build command object.
            OdbcCommand com = new OdbcCommand(query, this.__conn);

            // Check whether there are any parameters present.
            if (null != qParams)
            {
                // Loop through dictionary and create keyValuePair.
                foreach (KeyValuePair<string, string> entry in qParams)
                {
                    var k = entry.Key; // The named placeholder.
                    var v = entry.Value; // The value to go with the placeholder.

                    // Create the parameter and add it to the command.
                    OdbcParameter param = new OdbcParameter(k, v);
                    com.Parameters.Add(param);
                }
            }
            
            // Return command object.
            return com;
        }
        
        /// <summary>
        /// Determines whether there needs to be some customization
        /// on the connection string (adding or removing some properties).
        /// </summary>
        /// <param name="connString">The connection string</param>
        /// <returns>The altered connection string (if necessary).</returns>
        private string __checkDbDsn(string connString)
        {
            // SQLite needs some modifications (besides the path).
            if (this.__type == OdbcDbManager.DB_SQLITE)
            {
                // Replace file path with path placeholder.
                string newConn = this.__sqliteDsn;
                connString = newConn.Replace(":path:", @connString);
            }

            // Return original (or altered) connection string.
            return connString;
        }

        /// <summary>
        /// Takes the OdbcException and makes sure it will be handled correctly.
        /// </summary>
        /// <param name="op">The current operation mode of the database.</param>
        /// <param name="e">The ODBCException object</param>
        private void __handleError(string op, OdbcException e)
        {
            MessageBox.Show(
                   "An unexpected error occurred during database operation [" + op + "]: " + e.Message,
                   "Fatale fout in database engine: " + this.__readableType,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
               );

            // To be implemented: some logging feature.
        }

        /// <summary>
        /// Checks whether the passed parameters are not null and
        /// throws a custom exception.
        /// </summary>
        /// <param name="qParams">The passed parameters</param>
        private void __checkParams(Dictionary<string, string> qParams)
        {
            if (null == qParams)
            {
                throw new Exception(
                    this.__readableType + 
                    ": Arguments are needed for inserts, hence they cannot be empty!"
                );
            }
        }
    }
}