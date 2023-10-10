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
        // SQLite Connection Information
        //=============
        private SQLiteConnection conn;      // SQLite Connection
        public ConnectionState Connection_State  // Current Connection State
        { get; set; }
        public ConnectionType DB_Conn       // Database Connection Type
        { get; set; }
        private string Connection_String    // Connection String
        { get; set; }

        //=============
        // SQLite Database Information
        //=============
        public string DB_Name       // The name of the database to use
        { get; set; }
        public string DB_Path       // The path associated with the database to use
        { get; set; }
        public string Full_DB_Path  // The full path with file name associated with the database to use
        { get; set; }

        //=============
        // SQLite Database Size in Bytes
        //=============
        public long DB_Current_Size    // The current size of the database
        { get; set; }
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
