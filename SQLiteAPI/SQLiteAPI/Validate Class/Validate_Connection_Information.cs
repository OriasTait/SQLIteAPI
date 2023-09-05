using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Orias_SQLiteAPI
{
    public partial class SQLiteAPI
    {
        private ProcessStatus Validate_Connection_Information()
        /*
        ===============================================================================================
        PURPOSE:
        Validate the connection information for the SQLiteAPI
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - Returns Valid if everything passes; otherwise, it will return Error and the Error_MSG will be
          populated with the appropriate error.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            ProcessStatus Results = ProcessStatus.Valid;

            //=============
            // Body
            //=============
            // Validate the DB_Name has a value
            if ((DB_Name == null) || (DB_Name == string.Empty))
            {
                // Add appropriate error message
                Error_MSG = "Database Name was not provided";

                // Set the results
                Results = ProcessStatus.Error;
            }

            // Validate the DB_Path has a value
            if ((DB_Path == null) || (DB_Path == string.Empty))
            {
                // Add appropriate message separator
                if ((Results == ProcessStatus.Error) && (Error_MSG.Length > 0))
                { Error_MSG += "; "; }

                // Add appropriate error message
                Error_MSG += "Database Path was not provided";

                // Set the results
                Results = ProcessStatus.Error;
            }
            else
            {
                // Validate the DB_Path exists
                if (!Directory.Exists(DB_Path))
                {
                    // Add appropriate message separator
                    if ((Results == ProcessStatus.Error) && (Error_MSG.Length > 0))
                    { Error_MSG += "; "; }

                    // Add appropriate error message
                    Error_MSG += "Database Path does not exist";

                    // Set the results
                    Results = ProcessStatus.Error;
                }
                else
                {
                    // Ensure the DB_Path ends with \
                    if (DB_Path.Substring(DB_Path.Length - 1) != @"\")
                    {
                        DB_Path += @"\";
                    }
                }
            }

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // private Status Validate_Connection_Information
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
