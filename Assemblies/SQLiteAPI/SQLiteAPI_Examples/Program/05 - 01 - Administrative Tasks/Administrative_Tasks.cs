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
		public static void Administrative_Tasks()
		/*
		===============================================================================================
		PURPOSE:
		Provide an example of administrative tasks
		-----------------------------------------------------------------------------------------------
		NOTES:
		- Because this leverages the SQLiteAPI, the NuGet package System.Data.SQLite.Core has been
		  included.
		===============================================================================================
		*/
		{
			//=============
			// Variables - Standard
			//=============
			bool ExitAdminLoop = false;

			//=============
			// Variables - SQLite
			//=============
			SQLite SQLiteDB = new SQLite();

			//=============
			// Setup Environment
			//=============
			// Clear the screen
			Con.Clear();

			// Create database
			Create_New_Database(ref SQLiteDB, Example.Administion);

			//=============
			// Body
			//=============
			// Loop through the options
			while (!ExitAdminLoop)
			{
				// Main Menu
				Con.WriteLine();
				Con.WriteLine("-------------------------");
				Con.WriteLine("Administrative Tasks MENU");
				Con.WriteLine("-------------------------");
				Con.WriteLine();
				Con.WriteLine("01. Shrink database (Press <1>)");
				//Con.WriteLine("02. Database Size (Press <2>)");
				Con.WriteLine();
				Con.WriteLine("Q. Quit (Press <q>)");
				Con.WriteLine();
				Con.Write("Desired Action: ");

				switch (Con.ReadKey().Key)
				{
					case ConsoleKey.NumPad1:
					case ConsoleKey.D1:
						SQLiteDB.Shrink();
						break;
						;

					//case ConsoleKey.NumPad2:
					//case ConsoleKey.D2:
					//	Check_The_Database(ref SQLiteDB);
					//	break;
					//	;

					case ConsoleKey.Q:
						ExitAdminLoop = true;
						break;
				}

				if (SQLiteDB.DB_Status == SQLite.Status.Error)
				{
					Con.WriteLine();
					Con.WriteLine("Encountered an error: " + SQLiteDB.Error_MSG);

					ExitAdminLoop = true;
				}

				if (!ExitAdminLoop)
				{
					Con.Clear();
				}
			}

			//=============
			// Cleanup Environment
			//=============
			// Wait for the user
			Con.WriteLine();
			Con.Write("Press any key to continue...");
			Con.ReadKey();
		} // public static void Show_Data_From_A_Table()
	} // partial class Program
} // namespace SQLiteAPI_Examples
