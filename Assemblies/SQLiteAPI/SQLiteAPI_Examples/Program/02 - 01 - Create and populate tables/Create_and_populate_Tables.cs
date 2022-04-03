using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLiteAPI;    // SQLiteAPI

//=============
// Aliases
//=============
using Con = System.Console;

namespace SQLiteAPI_Examples
{
	partial class Program
	{
		public static void Create_and_populate_Tables()
		{
			//=============
			// Setup Environment
			//=============
			// Clear the screen
			Con.Clear();
			Con.WriteLine();

			//=============
			// Body
			//=============
			// Define the SQLite API Class
			SQLite SQLiteDB = new SQLite
			{
				// Define the specifics for this database
				DB_Name = "Table_Database.db",
				DB_Path = @"D:\Work\Code\SQLIteAPI\Working_Dir\"
			};

			//=============
			// Create a new databse
			//=============
			SQLiteDB.Create_DB(true);

			if (SQLiteDB.DB_Status == SQLite.Status.Error)
			{
				Con.WriteLine("Database Error: " + SQLiteDB.Error_MSG);
			}
			else
			{
				Con.WriteLine("Database " + SQLiteDB.DB_Name + " has been created.");
			}

			//=============
			// Create Table1
			//=============

			//=============
			// Create Table2
			//=============

			//=============
			// Populate Table1
			//=============

			//=============
			// Populate Table2
			//=============

			//=============
			// Cleanup Environment
			//=============
			Con.WriteLine();
			Con.Write("Press any key to continue...");
			Con.ReadKey();
		}
	} // partial class Program
} // namespace SQLiteAPI_Examples
