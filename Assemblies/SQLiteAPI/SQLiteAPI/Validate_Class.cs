using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;   // NuGet Package => System.Data.SQLite
using System.IO;            // file system class

namespace SQLiteAPI
{
    public partial class SQLite
    {
        private Status Validate_Class(Validation_Type Val_Type)
        /*
        ===============================================================================================
        PURPOSE:
        Validate the SQLite class based on the validation type.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Val_Type  => The validation type to perform.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - Returns Status.Valid if everything passes; otherwise, it will return Status.Error
        ===============================================================================================
        */
        {
            Status Results = Status.Valid;

            //=============
            // Body
            //=============
            switch(Val_Type)
			{
                case Validation_Type.DB_Connection:
                    // Validate the DB_Name has a valie
                    if (DB_Name == null)
                    {
                        // Add appropriate error message
                        Error = "Database Name is missing";

                        // Set the results
                        Results = Status.Error;
                    }

                    // Validate the DB_Path has a value
                    if (DB_Path == null)
                    {
                        // Add appropriate message separator
                        if (Results == Status.Error)
                        { Error += "; "; }

                        // Add appropriate error message
                        Error += "Database Path is missing";

                        // Set the results
                        Results = Status.Error;
                    }

                    // Validate the DB_Path exists
                    if (!Directory.Exists(DB_Path))
                    {
                        // Add appropriate message separator
                        if (Results == Status.Error)
                        { Error += "; "; }

                        // Add appropriate error message
                        Error += "Database Path does not exist";

                        // Set the results
                        Results = Status.Error;
                    }
                    break;
			}

            // Update the database status if an error was encountered
            if (Results == Status.Error)
			{
                DB_Status = Status.Error;
            }

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // private Status Validate_Class(Validation_Type Val_Type)
    } // public partial class SQLite
} // namespace SQLiteAPI
