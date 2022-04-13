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
            Valid,      // No Errors Encountered
            Error,      // Encountered an error
            Warning,    // Encountered a warning state
            Critical    // Encountered a critical state
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

        //=============
        // Properties - Database Size in Bytes
        //=============
        private long DB_Max_Bytes;      // Max size in bytes
        private float DB_Warning_Min;   // Min size for warning
        private float DB_Critical_Min;  // Min size for critical warning
        private float DB_Error_Min;     // Min size for error
        public long DB_Max_Size 
        {
            get { return DB_Max_Bytes; }
            set
			{
                DB_Max_Bytes = value;
                DB_Warning_Min = value * .75f;
                DB_Critical_Min = value * .90f;
                DB_Error_Min = value * .99f;
            }
        }

        private long DB_Current_Size;   // The current size of the database
    } // public partial class SQLite
} // namespace SQLiteAPI
