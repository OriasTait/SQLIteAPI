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
		public static void Show_Data_From_A_Table()
		{
			//=============
			// Variables - SQLite
			//=============
			SQLite SQLiteDB = new SQLite();

			//=============
			// Setup Environment
			//=============
			// Clear the screen
			Con.Clear();
			Con.WriteLine();

			// Create database
			Create_New_Database(ref SQLiteDB, Example.Show_Data);

			// Show the results of setting up the environment
			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				Con.WriteLine("Database, Table and Data have been created.");
			}
			else
			{
				Con.WriteLine("Encountered the following error: " + SQLiteDB.Error_MSG);
			}

			//=============
			// Show the data
			//=============
			SQLiteDB.SQL =
				"SELECT Col1, Col2 FROM Table1; ";
			SQLiteDB.ExecuteQuery();

			//=============
			// Cleanup Environment
			//=============
			// Wait for the user
			Con.WriteLine();
			Con.Write("Press any key to continue...");
			Con.ReadKey();
		}
	} // partial class Program
} // namespace SQLiteAPI_Examples
