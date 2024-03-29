﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;   // NuGet Package => System.Data.SQLite
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orias_SQLiteAPI
{
    public partial class SQLiteAPI
    {
        public void ExecuteNonQuery()
        /*
        ===============================================================================================
        PURPOSE:
        Execute the SQL command against the SQLite database.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - If successful, the command has been executed; otherwise, the database state will be updated
          to Error and the Error_MSG will contain the encountered error.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - It is assumed no results are being returned by the command being executed.
        ===============================================================================================
        */
        {
            //=============
            // Setup Environment
            //=============
            // Verify SQL is not empty
            if ((SQL == string.Empty) || (SQL == null))
            {
                Process_Status = ProcessStatus.Error;
                Error_MSG = "No SQL to execute.";
            }

            //=============
            // Body
            //=============
            if (Process_Status == ProcessStatus.Valid)
            {
                try  // Try => Execute SQL
                {
                    // Create a connection to the database
                    conn = new SQLiteConnection(Connection_String);

                    // Create the SQL Command to Execute
                    SQL_CMD = conn.CreateCommand();
                    SQL_CMD.CommandText = SQL;

                    // Execute the command
                    conn.Open();
                    SQL_CMD.ExecuteNonQuery();
                }

                catch (Exception ex)  // Catch => Update state to error
                {
                    Process_Status = ProcessStatus.Error;

                    // Catch the error
                    Error_MSG = ex.Message.Replace("\r\n", " ");  // Convert the message to one line
                }

                finally  // Always do this, even if there is an error
                {
                    conn.Close();       // Close the connection the database
                    SQL_CMD.Dispose();  // Remove the command from memory
                }
            }
        } // public void ExecuteNonQuery
    } // public partial class SQLiteAPI
} // namespace SQLiteAPI
