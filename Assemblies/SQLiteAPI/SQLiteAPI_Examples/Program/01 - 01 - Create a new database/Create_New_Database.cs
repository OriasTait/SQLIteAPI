using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//=============
// SQLiteAPI
//=============
using SQLiteAPI;

//=============
// Aliases
//=============
using Con = System.Console;

namespace SQLiteAPI_Examples
{
	partial class Program
	{
		private static void Create_New_Database()
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
				DB_Name = "EmptyDatabase.db",
				DB_Path = @"D:\Work\Code\SQLIteAPI\Working_Dir\"
			};

			// Create a new databse if it does not exist
			SQLiteDB.Create_DB(false);

			if (SQLiteDB.DB_Status == SQLite.Status.Error)
			{
				Con.WriteLine("Database Error: " + SQLiteDB.Error_MSG);
			}
			else
			{
				Con.WriteLine("Database " + SQLiteDB.DB_Name + " has been created.");
			}

			// Create a databse regardless if it exists or not
			SQLiteDB.Create_DB(true);

			if (SQLiteDB.DB_Status == SQLite.Status.Error)
			{
				Con.WriteLine("Database Error: " + SQLiteDB.Error_MSG);
			}
			else
			{
				Con.WriteLine("Database " + SQLiteDB.DB_Name + " has been created.");
			}

			Con.WriteLine();
			Con.Write("Press any key to continue...");
			Con.ReadKey();
		} // private void Create_New_Database()
	} // partial class Program
} // namespace SQLiteAPI_Examples
