using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteAPI
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "<Pending>")]
    public partial class SQLiteAPI
    /*
    ===============================================================================================
    PURPOSE:
    Centralize the class properties.
    ===============================================================================================
    */
    {
        //=============
        // Properties - SQLite Connection Information
        //=============
        public ConnectionState Connection_State
        { get; set; }

        //=============
        // Properties - SQLite Command Information
        //=============
        public Status DB_Status         // The current status of the database
        { get; set; }
        public string Error_MSG         // Current Error message
        { get; set; }
        public DataSet QueryResults     // Results of a query of the database
        { get; set; }
        private SQLiteCommand SQL_CMD   // SQLite SQL Command
        { get; set; }
        public string SQL               // SQLite Standard Query Language command (SQL) to execute
        { get; set; }
    } // public partial class SQLiteAPI
} // namespace SQLiteAPI
