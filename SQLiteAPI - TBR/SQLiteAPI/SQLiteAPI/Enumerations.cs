using System;
using System.Collections.Generic;
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

        public enum Connection_Type
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

    } // public partial class SQLiteAPI
} // namespace SQLiteAPI
