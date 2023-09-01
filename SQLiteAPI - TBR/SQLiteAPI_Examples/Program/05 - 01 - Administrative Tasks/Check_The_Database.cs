using System;
using System.Collections.Generic;
using System.Data;          // System data objects and routines
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
		public static void Check_The_Database(ref SQLite SQLiteDB)
		/*
		===============================================================================================
		PURPOSE:
		Provide an example of administrative tasks
		-----------------------------------------------------------------------------------------------
		PARAMETERS:
		- SQLiteDB	=> Reference to the SQLite Database to use
		-----------------------------------------------------------------------------------------------
		NOTES:
		- 
		===============================================================================================
		*/
		{
			// Set the database size to 1 KB
			//SQLiteDB.DB_Max_Size = 1024; // 1 KB
			//SQLiteDB.DB_Max_Size = 1024 * 1024; // 1 MB

			SQLiteDB.DB_Max_Size = 16384; // size of file
			SQLiteDB.DB_Max_Size = 20480; // generate a warning
			SQLiteDB.DB_Max_Size = 17547; // generate a critical state

			// Check the database
			SQLiteDB.Check_DB();

			Con.WriteLine();
			switch (SQLiteDB.DB_Status)
			{
				case SQLite.Status.Warning:
					Con.WriteLine("Encountered the warning: " + SQLiteDB.Error_MSG);

					Con.WriteLine();
					Con.Write("Press any key to continue...");
					Con.ReadKey();
					break;

				case SQLite.Status.Critical:
					Con.WriteLine("Encountered the critical state: " + SQLiteDB.Error_MSG);

					Con.WriteLine();
					Con.Write("Press any key to continue...");
					Con.ReadKey();
					break;

				case SQLite.Status.Error:
					Con.WriteLine("Encountered the error: " + SQLiteDB.Error_MSG);
					break;
			}
		} // public static void Check_The_Database()
	} // partial class Program
} // namespace SQLiteAPI_Examples
