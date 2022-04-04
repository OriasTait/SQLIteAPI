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
        public void ExecuteNonQuery()
        /*
        ===============================================================================================
        PURPOSE:
        Attempt to execute the command in the property SQL against the database identified with the
        ConnectionString.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - If successful, the command has been executed; otherwise, the database state has been updated
          to Error and the error message has been updated.
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
                DB_Status = Status.Error;
                Error_MSG = "No SQL to execute.";
			}

            //=============
            // Body
            //=============
            try  // Try => Execute SQL
            {
                // Create the SQL Command to Execute
                SQL_cmd = conn.CreateCommand();
                SQL_cmd.CommandText = SQL;

                // Execute the command
                conn.Open();
                SQL_cmd.ExecuteNonQuery();
            }

            catch (Exception ex)  // Catch => Update state to error
            {
                DB_Status = Status.Error;

                // Catch the error
                Error_MSG = ex.Message.Replace("\r\n", " ");  // Convert the message to one line
            }

            //=============
            // Cleanup Environment
            //=============
            finally  // Close the database connection
            {
                conn.Close();       // Close the connection the database
                SQL_cmd.Dispose();  // Remove the command from memory
            }
        } // public void ExecuteNonQuery()
    } // public partial class SQLite
} // namespace SQLiteAPI
