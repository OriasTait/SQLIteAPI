using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;   // NuGet Package => System.Data.SQLite


namespace Orias_SQLiteAPI
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
        // SQLite Connection Information
        //=============
        public ConnectionState Connection_State
        { get; set; }

        //=============
        // SQLite Command Information
        //=============
        public ProcessStatus Process_Status // The status of the last process performed
        { get; set; }
        public string Error_MSG             // Current Error message
        { get; set; }
        public DataSet QueryResults         // Results of a query in the database
        { get; set; }
        public string SQL                   // SQLite Standard Query Language command (SQL) to process
        { get; set; }
        private SQLiteCommand SQL_CMD       // SQLite SQL Command to process in the database
        { get; set; }

        //=============
        // Properties - SQLite Connection Information
        //=============
        private SQLiteConnection conn;      // SQLite Connection
        public ConnectionType DB_Conn       // Database Connection Type
        { get; set; }
        private string Connection_String    // Connection String
        { get; set; }

        //=============
        // SQLite Database Information
        //=============
        public string DB_Name   // The name of the database to use
        { get; set; }
        public string DB_Path   // The path associated with the database to use
        { get; set; }

    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
