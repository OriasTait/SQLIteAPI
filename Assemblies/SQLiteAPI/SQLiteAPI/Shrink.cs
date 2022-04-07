using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;       // NuGet Package => System.Data.SQLite

namespace SQLiteAPI
{
    public partial class SQLite
    {
        public void Shrink()
        /*
        ===============================================================================================
        PURPOSE:
        Re-organize the database to use the minimal amount of disk space.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - This leverages the SQLite command "VACUUM".  The VACUUM command rebuilds the database file,
          repacking it into a minimal amount of disk space.
          Reference: https://www.sqlite.org/lang_vacuum.html
        ===============================================================================================
        */
        {
            //=============
            // Body
            //=============
            SQL = "VACUUM;";
            ExecuteNonQuery();
        } // public Status Shrink()
    } // public partial class SQLite
} // namespace SQLiteAPI
