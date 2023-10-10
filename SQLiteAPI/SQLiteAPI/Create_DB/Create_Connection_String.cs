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
        private ProcessStatus Create_Connection_String()
        /*
        ===============================================================================================
        PURPOSE:
        Create the connection information to the database based on the information provided in the
        SQLiteAPI class.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - If the the DB_Path and DB_Name are validated, a value of Valid will be returned; otherwise a
          value of Error will be returned.
        - When an error is returned, Error_MSG will have the error encountered.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            ProcessStatus Results;

            //=============
            // Setup Environment
            //=============
            Results = Validate_Class(Validation_Type.DB_Connection);

            //=============
            // Body
            //=============
            if (Results == ProcessStatus.Valid)
            {
                //=============
                // Create the connection string
                //=============
                switch (DB_Conn)
                {
                    case ConnectionType.DS:
                        // Define the connection String
                        Connection_String = "Data Source=\"" + Full_DB_Path + "\"; Compress = True; ";
                        break;

                    case ConnectionType.URI:
                        Connection_String = "URI=file:" + Full_DB_Path + "; Compress = True; ";
                        break;

                    default:
                        // Add appropriate message separator
                        if(Error_MSG.Length >  0)
                        { Error_MSG += "; "; }

                        // Add appropriate error message
                        Error_MSG += "Unknown Database Connection";

                        // Set the results
                        Results = ProcessStatus.Error;
                        break;
                }
            } // if Results == ProcessStatus.Valid

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // private ProcessStatus Create_Connection_String
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
