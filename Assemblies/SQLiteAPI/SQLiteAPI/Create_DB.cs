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
        public void Create_DB(bool Overwrite)
		{
            // Create Connection
            Create_Connection_String();

            // - Validate SQLite class information
            // - If valid, create the connection string
            // - If not valid, update SQLite status and error
            if (DB_Status == Status.Valid)
			{
                // If status is valid
                // - If Overwrite is true, delete database if it exists
                // - If Overwrite is false, do not create if it exists
            }
        }
    } // public partial class SQLite
} // namespace SQLiteAPI
