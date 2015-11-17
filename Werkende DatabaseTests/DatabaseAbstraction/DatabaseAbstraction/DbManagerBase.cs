using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.SQLite;
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
    abstract class DbManagerBase
    {
        /// <summary>
        /// Some static properties that are needed to specify
        /// some DSN specific strings.
        /// </summary>
        public static readonly int DB_SQLITE = 1;
        public static readonly int DB_ODBC = 2;
        public static readonly int DB_MSSQL = 3;
        
        /// <summary>
        /// Keeps track which type this database is (see static props above).
        /// </summary>
        protected int _type;
        private string __readableType;
        
        /// <summary>
        /// Constructor for instantiating this class.
        /// </summary>
        public DbManagerBase() {}

        /// <summary>
        /// Sets the database type.
        /// </summary>
        /// <param name="type">The database type (self-referencing static int)</param>
        protected void _setType(int type)
        {
            this._type = type;

            if (this._type == DB_SQLITE) this.__readableType = "SQLite";
            if (this._type == DB_ODBC) this.__readableType = "ODBC Generic";
            if (this._type == DB_MSSQL) this.__readableType = "MS SQL";
        }
        
        /// <summary>
        /// Shows a friendly error message when the connection cannot be established.
        /// </summary>
        /// <param name="e">The exception object</param>
        protected void _showConnectErrorMsg(dynamic e)
        {
            MessageBox.Show("Connection could not be initialized. Error: " + e.Message);
        }

        /// <summary>
        /// Shows a friendly error message when the connection cannot be closed
        /// (e.g. still a transaction busy or some other error happening).
        /// </summary>
        /// <param name="e">The exception object</param>
        protected void _showDisconnectErrorMsg(dynamic e)
        {
            MessageBox.Show("There was an error while closing the connection. Error: " + e.getMessage);
        }

        /// <summary>
        /// Shows a friendly error message.
        /// </summary>
        /// <param name="op">The current operation mode of the database.</param>
        /// <param name="e">The exception object</param>
        protected void _showConnectErrorMsg(string op, dynamic e)
        {
            MessageBox.Show(
                   "An unexpected error occurred during a database operation [" + op + "]: " + e.Message,
                   "Fatale fout in database engine: " + this.__readableType,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
            );
        }

        /// <summary>
        /// Binds the parameters to the query.
        /// NOTE: The order of parameters in the dictionary matter for the query!
        /// Example: SELECT * FROM `aTable` WHERE ? = 10
        ///          The Dictionary would contain "@id" => 10 
        ///                                       (@columnName -> value).
        /// </summary>
        /// <param name="query">The query string.</param>
        /// <param name="qParams">The query parameters with named placeholders.</param>
        /// <returns></returns>
        protected dynamic _bindParams(dynamic dbCommand, Dictionary<string, dynamic> qParams = null)
        {
            // Check whether there are any parameters present.
            if (null != qParams)
            {
                // Loop through dictionary and create keyValuePair.
                foreach (KeyValuePair<string, dynamic> entry in qParams)
                {
                    dynamic k = entry.Key; // The named placeholder.
                    dynamic v = entry.Value; // The value to go with the placeholder.

                    // Create the parameter and add it to the command.
                    dynamic param;
                    if (this._type == DbManagerBase.DB_SQLITE)
                    {
                        param = new SQLiteParameter(k);
                        param.Value = v;
                    }
                    else if (this._type == DbManagerBase.DB_MSSQL)
                    {
                        param = new SqlParameter(k, v);
                    }
                    else
                    {
                        param = new OdbcParameter(k, v);
                    }
                    
                    // Add the parameter to the command object.
                    dbCommand.Parameters.Add(param);
                }
            }
            
            // Return command object.
            return dbCommand;
        }
        
        /// <summary>
        /// Checks whether the passed parameters are not null and
        /// throws a custom exception.
        /// </summary>
        /// <param name="qParams">The passed parameters</param>
        protected void _checkParams(Dictionary<string, dynamic> qParams)
        {
            if (null == qParams)
            {
                throw new Exception(
                    this.__readableType + 
                    ": Arguments are needed for this operation, hence they cannot be empty!"
                );
            }
        }
    }
}