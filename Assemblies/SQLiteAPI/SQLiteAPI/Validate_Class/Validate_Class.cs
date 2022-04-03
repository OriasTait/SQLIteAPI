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
            //=============
            // Variables - Standard
            //=============
            Status Results = Status.Valid;

            //=============
            // Body
            //=============
            switch(Val_Type)
			{
                case Validation_Type.DB_Connection:
                    Results = Validate_Connection_Information();
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
