using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;       // NuGet Package => System.Data.SQLite

namespace SQLiteAPI
{
    public partial class SQLiteAPI
    {
        private Status Create_Connection_String()
        /*
        ===============================================================================================
        PURPOSE:
        Create a connection to the SQLite database based on the information provided to the API class.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - The DB_Name and DB_Path are validated to having a value.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - At this time, there is only one type of connection used; however the class is designed to
          have multiple types if it is required moving forward.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            Status Results;

            //=============
            // Setup Environment
            //=============
            Error_MSG = string.Empty;   // Ensure the API Error message is empty
            DB_Status = Status.Valid;   // Assume a valid state

            // Validate the required fields
            Results = Validate_Class(Validation_Type.DB_Connection);

            //=============
            // Body
            //=============
            if (Results == Status.Valid)
            {
                //=============
                // Create the connection string
                //=============
                switch (DB_Conn)
                {
                    case ConnectionType.DS:
                        // Define the connection String
                        ConnectionString = "Data Source=\"" + DB_Path + DB_Name + "\"; Compress = True; ";
                        break;

                    case ConnectionType.URI:
                        ConnectionString = "URI=file:" + DB_Path + DB_Name + "; Compress = True; ";
                        break;

                    default:
                        // Add appropriate message separator
                        if (Results == Status.Error)
                        { Error_MSG += "; "; }

                        // Add appropriate error message
                        Error_MSG += "Unknown Database Connection";

                        // Set the results
                        Results = Status.Error;
                        break;
                }
            }

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // private Status Create_Connection_String()
    } // public partial class SQLite
} // namespace SQLiteAPI
