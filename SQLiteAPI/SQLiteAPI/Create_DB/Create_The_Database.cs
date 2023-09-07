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
        private void Create_The_Database()
        /*
        ===============================================================================================
        PURPOSE:
        Create the desired database
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - An empty database will be created.
        ===============================================================================================
        */
        {
            try
            {
                // Create a connection to the database
                conn = new SQLiteConnection(Connection_String);

                // Open the connection
                conn.Open();

                // Close the connection
                conn.Close();
            }
            catch (Exception ex)
            {
                Process_Status = ProcessStatus.Error;
                Error_MSG =
                    "Create the database "
                    + DB_Name
                    + " returned the error: "
                    + ex.Message.Replace("\r\n", " ");  // Convert the message to one line
            }
        } // private void Create_The_Database
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
