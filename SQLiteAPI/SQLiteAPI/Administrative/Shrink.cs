using System;
using System.Collections.Generic;
using System.Data.SQLite;   // NuGet Package => System.Data.SQLite
using System.IO;            // file system class
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Orias_SQLiteAPI
{
    public partial class SQLiteAPI
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
            // Variables - Standard
            //=============
            ProcessStatus Results;

            //=============
            // Setup Environment
            //=============
            Results = Create_Connection_String();

            //=============
            // Body
            //=============

            // Shrink the database
            if (Results == ProcessStatus.Valid)
            {
                SQL = "VACUUM;";
                ExecuteNonQuery();
            }
        } // public Status Shrink()
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
