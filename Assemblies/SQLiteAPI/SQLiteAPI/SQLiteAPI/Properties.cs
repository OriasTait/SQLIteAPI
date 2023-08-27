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
    Centralize the class properties.
    ===============================================================================================
    */
    {
        //=============
        // Properties - SQLite Connection Information
        //=============
        public ConnectionState Connection_State
        { get; set; }
    } // public partial class SQLiteAPI
} // namespace SQLiteAPI
