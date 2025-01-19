using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orias_SQLiteAPI
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "<Pending>")]
    public partial class SQLiteAPI
    /*
    ===============================================================================================
    PURPOSE:
    Enumerate class standards for ease of use.
    ===============================================================================================
    */
    {
        //=============
        // Enumerations
        //=============
        public enum ConnectionState
        {
            Connected,      // Connected to a database
            Disconnected,   // Not connected to a database
        }

        public enum ConnectionType
        {
            DS,  // Data Source => uses standard OS path definitions (C:\Directory\SubDirectory\)
            URI  // Uniform Resource Identifier
        }

        public enum DatabaseCreateType
        {
            Overwrite,  // Overwrite the database if it exists
            Retain      // Do not Overwrite the database if it exists
        }

        public enum ProcessStatus
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

    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
