using Orias_SQLiteAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//=============
// Orias Packages
//=============
using static Orias_SQLiteAPI.SQLiteAPI;

namespace SQLiteAPI_Testing
{
    namespace Table_Create_and_Populate
    {
#pragma warning disable S101 // Types should be named in PascalCase
        internal class TC_and_P
#pragma warning restore S101 // Types should be named in PascalCase
        {
            public ProcessStatus Create_Table_and_Populate(ref SQLiteAPI My_DB)
            /*
            ===============================================================================================
            PURPOSE:
            Provide an example of creating 2 tables and populating them with data.
            -----------------------------------------------------------------------------------------------
            NOTES:
            - Because this leverages the SQLiteAPI, the NuGet package System.Data.SQLite.Core has been
              included.
            ===============================================================================================
            */
            {
                //=============
                // Variables - Standard
                //=============
                ProcessStatus Results;

                //=============
                // If Table1 exeists, drop it
                //=============
                My_DB.SQL = "DROP TABLE IF EXISTS Table1;";
                My_DB.ExecuteNonQuery();

                //=============
                // Create Table1
                //=============
                if(My_DB.Process_Status == SQLiteAPI.ProcessStatus.Valid)
                {
                    My_DB.SQL =
                        "CREATE TABLE Table1 " +
                        "(" +
                        " Col1 VARCHAR(20), " +
                        " Col2 INT " +
                        ")";
                    My_DB.ExecuteNonQuery();
                }

                //=============
                // Populate Table1
                //=============
                if (My_DB.Process_Status == SQLiteAPI.ProcessStatus.Valid)
                {
                    My_DB.SQL =
                        "INSERT INTO Table1 " +
                        "(Col1, Col2) " +
                        "VALUES " +
                        "('Row 1 Inserted', 1) " +
                        ", ('Row 2 Inserted', 2) " +
                        ", ('Row 3 Inserted', 3) " +
                        ";";
                    My_DB.ExecuteNonQuery();
                }

                //=============
                // Create Table2
                //=============
                if (My_DB.Process_Status == SQLiteAPI.ProcessStatus.Valid)
                {
                    My_DB.SQL =
                        "DROP TABLE IF EXISTS Table2; " +
                        "CREATE TABLE Table2 " +
                        "(" +
                        " Col1 VARCHAR(20), " +
                        " Col2 INT " +
                        ")";
                    My_DB.ExecuteNonQuery();
                }

                //=============
                // Populate Table2
                //=============
                if (My_DB.Process_Status == SQLiteAPI.ProcessStatus.Valid)
                {
                    My_DB.SQL =
                        "INSERT INTO Table2 " +
                        "(Col1, Col2) " +
                        "VALUES " +
                        "('Row 01 Inserted', 1) " +
                        ", ('Row 02 Inserted', 2) " +
                        ", ('Row 03 Inserted', 3) " +
                        ";";
                    My_DB.ExecuteNonQuery();
                }

                //=============
                // Cleanup Environment
                //=============
                // Obtain the status of the process
                Results = My_DB.Process_Status;

                // Return the status to the calling process
                return Results;
            } // public void Create_Table_and_Populate
        } // internal class Table_Create_and_Populate
    } // namespace TC_and_P
} // namespace SQLiteAPI_Testing
