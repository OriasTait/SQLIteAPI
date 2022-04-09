using System;
using System.Collections.Generic;
using System.Data;          // System data objects and routines
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;       // NuGet Package => System.Data.SQLite

namespace SQLiteAPI
{
    public partial class SQLite
    /*
    ===============================================================================================
    PURPOSE:
    Standardize the Aplication Programming Interface (API) to an SQLite database.
    -----------------------------------------------------------------------------------------------
    NOTES:
    - This library leverages the NuGet Package system.data.sqlite.  It is required to include the
      NuGet package System.Data.SQLite.Core into the project that leverages this class.
    ===============================================================================================
    */
    {
        //=============
        // Enumerations
        //=============
        public enum ConnectionType
        {
            DS,  // Data Source => uses standard OS path definitions (C:\Directory\SubDirectory\)
            URI  // Uniform Resource Identifier
        }

        public enum Status
        {
            Error,  // Encountered an error
            Valid   // No Errors Encountered
        }

        private enum Validation_Type
        {
            DB_Connection   // Database Connection
        }

        //=============
        // Properties - SQLite Connection Information
        //=============
        private SQLiteConnection conn;      // SQLite Connection
        public ConnectionType DB_Conn;      // Database Connection Type
        private string ConnectionString;    // Connection String

        //=============
        // Properties - SQLite SQL Command Information
        //=============
        public Status DB_Status;        // The current status of the database
        public string Error_MSG;        // Current Error message
        public DataSet QueryResults;    // Results of a query of the database
        private SQLiteCommand SQL_cmd;  // SQLite SQL Command
        public string SQL;              // SQLite Standard Query Language command (SQL) to execute

        //=============
        // Properties - SQLite SQL Database Information
        //=============
        public string DB_Name;  // The name of the database to use
        public string DB_Path;  // The path associated with the database to use
    } // public partial class SQLite
} // namespace SQLiteAPI
