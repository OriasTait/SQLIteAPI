using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;       // NuGet Package => System.Data.SQLite

namespace SQLiteAPI
{
    public partial class SQLite
    {
        public void Check_DB()
        /*
        ===============================================================================================
        PURPOSE:
        Perform some basic checks on the database.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - 
        ===============================================================================================
        */
        {
            //=============
            // Check the current size
            //=============
            // Obtain the current size
            DB_Current_Size = new FileInfo(DB_Path + DB_Name).Length;

            // No space left, raise error
#pragma warning disable S2589 // Boolean expressions should not be gratuitous
            if (DB_Current_Size >= DB_Error_Min)
			{
                DB_Status = Status.Error;
                Error_MSG = "ERROR: ";
			}

            // Critical threshold met, raise warning
            else if (DB_Current_Size >= DB_Critical_Min && DB_Current_Size < DB_Error_Min)
			{
                DB_Status = Status.Critical;
                Error_MSG = "CRITICAL: ";
			}

            // Warning threshold met, raise warning
            else if (DB_Current_Size >= DB_Warning_Min && DB_Current_Size < DB_Critical_Min)
            {
                DB_Status = Status.Warning;
                Error_MSG = "WARNING: ";
            }
#pragma warning restore S2589 // Boolean expressions should not be gratuitous

            if (DB_Status != Status.Valid)
			{
                Error_MSG = Error_MSG + "Database size is " + (DB_Current_Size / (float)DB_Max_Size) * 100 + "% full.";
            }
        } // public void Check_DB()
    } // public partial class SQLite
} // namespace SQLiteAPI
