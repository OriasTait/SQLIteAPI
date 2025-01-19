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
        public void Current_Size()
        /*
        ===============================================================================================
        PURPOSE:
        Obtain the current size of the database.
        ===============================================================================================
        */
        {
            //=============
            // Obtain the current size
            //=============
            DB_Current_Size = new FileInfo(Full_DB_Path).Length;
        } // public Status Current_Size
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
