using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;       // NuGet Package => System.Data.SQLite

namespace SQLiteAPI
{
    public partial class SQLite
    {
        private Status Create_Connection_String()
		{
            //=============
            // Variables - Standard
            //=============
            Status Results = Status.Valid;

            //=============
            // Setup Environment
            //=============
            Error = string.Empty;       // Ensure the API Error message is empty
            DB_Status = Status.Valid;   // Assume a valid state

            // Set the appropriate Connection Type
            DB_Conn = ConnectionType.DS;

            // Validate the required fields
            Results = Validate_Class(Validation_Type.DB_Connection);

            //=============
            // Cleanup Environment
            //=============
            return Results;
		}

    } // public partial class SQLite
} // namespace SQLiteAPI
