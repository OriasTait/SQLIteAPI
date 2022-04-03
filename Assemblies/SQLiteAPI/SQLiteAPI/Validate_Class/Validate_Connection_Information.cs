using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;    // file system class

namespace SQLiteAPI
{
    public partial class SQLite
    {
        private Status Validate_Connection_Information()
        /*
        ===============================================================================================
        PURPOSE:
        Validate the connection information for the SQLiteAPI
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - Returns Status.Valid if everything passes; otherwise, it will return Status.Error
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            Status Results = Status.Valid;

            //=============
            // Body
            //=============
            // Validate the DB_Name has a value
            if (DB_Name == null)
            {
                // Add appropriate error message
                Error_MSG = "Database Name is missing";

                // Set the results
                Results = Status.Error;
            }

            // Validate the DB_Path has a value
            if (DB_Path == null)
            {
                // Add appropriate message separator
                if (Results == Status.Error)
                { Error_MSG += "; "; }

                // Add appropriate error message
                Error_MSG += "Database Path is missing";

                // Set the results
                Results = Status.Error;
            }

            // Validate the DB_Path exists
            if (!Directory.Exists(DB_Path))
            {
                // Add appropriate message separator
                if (Results == Status.Error)
                { Error_MSG += "; "; }

                // Add appropriate error message
                Error_MSG += "Database Path does not exist";

                // Set the results
                Results = Status.Error;
            }

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // private Status Validate_Connection_Information()
    } // public partial class SQLite
} // namespace SQLiteAPI
