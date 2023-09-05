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
        private ProcessStatus Validate_Class(Validation_Type Val_Type)
        /*
        ===============================================================================================
        PURPOSE:
        Validate the SQLite class based on the validation type.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Val_Type  => The validation type to perform.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - Returns Valid if everything passes; otherwise, it will return Error and the Error_Msg will be
          populated with the error encountered
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
            switch (Val_Type)
            {
                case Validation_Type.DB_Connection:
                    Results = Validate_Connection_Information();
                    break;
            }

            // Update the database status if an error was encountered
            if (Results == ProcessStatus.Error)
            {
                Process_Status = ProcessStatus.Error;
            }

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // private Status Validate_Class
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
