using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orias_SQLiteAPI
{
    public partial class SQLiteAPI
    {
        public void ExecuteQuery()
        /*
        ===============================================================================================
        PURPOSE:
        Execute the SQL Command against the SQLite database.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - If successful, the command has been executed and the results will be placed in the
          QueryResults property; otherwise, the database state will be updated to Error and the
          Error_MSG will contain the encountered error.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - It is assumed results are being returned by the command being executed.
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
            try  // Try => Execute SQL
            {
                if (Connection_State == ConnectionState.Disconnected)
                {
                    Create_Connection_String();
                }

                // Create the SQL Command to Execute
                SQL_CMD = conn.CreateCommand();
                SQL_CMD.CommandText = SQL;

                // Create the Query Results
                SQLiteDataAdapter da = new SQLiteDataAdapter(SQL_CMD.CommandText, conn);
                QueryResults = null;  // Ensure the dataset is empty before continuing
                QueryResults = new DataSet();

                // Execute the command
                conn.Open();
                da.Fill(QueryResults);

                // Remove the Data Adapter
                da.Dispose();
            }

            catch (Exception ex)  // Catch => Update state to error
            {
                Process_Status = ProcessStatus.Error;

                // Catch the error
                Error_MSG = ex.Message.Replace("\r\n", " ");  // Convert the message to one line
            }

            //=============
            // Cleanup Environment
            //=============
            finally  // Close the database connection
            {
                conn.Close();       // Close the connection the database
                SQL_CMD.Dispose();  // Remove the command from memory
            }
        } // public void ExecuteQuery
    } // public partial class SQLiteAPI
} // namespace SQLiteAPI
