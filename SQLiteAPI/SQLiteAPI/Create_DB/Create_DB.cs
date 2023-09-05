using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orias_SQLiteAPI
{
    public partial class SQLiteAPI
    {
        private bool Database_Exists()
        /*
        ===============================================================================================
        PURPOSE:
        Check if the database provided to the SQLiteAPI exists.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - Returns true if it does; othewise it returns false.
        ===============================================================================================
        */
        {

        } // private bool Database_Exists

        public ProcessStatus Create_DB(DatabaseCreateType Create_Type)
        /*
        ===============================================================================================
        PURPOSE:
        Create a database based on the information provided in the SQLiteAPI class.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Create_Type => If the database should be overwritten or not.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - An empty database will be created.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - If Create_Type is set to Retain and the the database already exists, an error will be raised.
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
            Results = Create_Connection_String();

            if (Results == ProcessStatus.Valid)
            {
                switch (Create_Type)
                {
                    case DatabaseCreateType.Retain:
                        // If Retain
                        // - Check if database exists
                        // - Raise error if exists
                        // - Else Create the database
                        break;

                    case DatabaseCreateType.Overwrite:
                        // If Overwrite
                        // - Check if database exists
                        // - Remove database if exists
                        // - Create the database
                        break;
                }
            } // if Results == ProcessStatus.Valid

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // public ProcessStatus Create_DB
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
