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
            // Variables - Standard
            //=============
            //Status Results = Status.Valid;

            //=============
            // Setup Environment
            //=============
            //Error = string.Empty;  // Ensure the database error message is empty

            //=============
            // Body
            //=============
            SQL = "VACUUM;";
            ExecuteNonQuery();

            //try
            //{
            //    // Create the SQL Command to Execute
            //    //SQL_cmd = conn.CreateCommand();
            //    SQL = "VACUUM;";

            //    // Execute the command
            //    //conn.Open();
            //    ExecuteNonQuery();
            //}
            //catch (SQLiteException ex)
            //{
            //    // Save the error message
            //    //Error = ex.Message;
            //    //Results = Status.Error;
            //}

            ////=============
            //// Cleanup Environment
            ////=============
            //finally
            //{
            //    conn.Close();       // Close the connection the database
            //    SQL_cmd.Dispose();  // Remove the command from memory
            //    SQL = string.Empty; // Ensure the SQL is empty
            //}

            // Return the results
            //return Results;
        } // public Status Shrink()
    } // public partial class SQLite
} // namespace SQLiteAPI
