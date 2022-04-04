/*
===============================================================================================
PURPOSE:
Provide examples using SQLiteAPI that can be walked through using Visual Studio.
-----------------------------------------------------------------------------------------------
NOTES:
- Because this leverages the SQLiteAPI, the NuGet package System.Data.SQLite.Core has been
  included.
===============================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//=============
// Aliases
//=============
using Con = System.Console;

namespace SQLiteAPI_Examples
{
	partial class Program
	/*
	===============================================================================================
	PURPOSE:
	Provide a working example of how to interface with the SQLiteAPI namespace.
	===============================================================================================
	*/
	{
		public enum Example 
		{
			Show_Data	// Example 03 => Show data from a database
		}

		static void Main(/*string[] args*/)
		/*
		===============================================================================================
		PURPOSE:
		Starting point of the application.
		-----------------------------------------------------------------------------------------------
		NOTES:
		- This will call each of the different processes; therefore non of the SQLite class is being
		  created here.
		===============================================================================================
		*/
		{
			//=============
			// Variables - Standard
			//=============
			bool ExitMainLoop = false;

			//=============
			// Body
			//=============
			// Loop through the options
			while (!ExitMainLoop)
			{
				// Main Menu
				Con.WriteLine("---------");
				Con.WriteLine("MAIN MENU");
				Con.WriteLine("---------");
				Con.WriteLine();
				Con.WriteLine("01. Create a new database (Press <1>)");
				Con.WriteLine("02. Create and populate tables in the database (Press <2>)");
				Con.WriteLine("03. Show data from a table in the database (Press <3>)");
				Con.WriteLine("04. Show advanced data from a table in the database (Press <4>)");
				Con.WriteLine();
				Con.WriteLine("Q. Quit (Press <q>)");
				Con.WriteLine();
				Con.Write("Desired Action: ");

				switch (Con.ReadKey().Key)
				{
					case ConsoleKey.NumPad1:
					case ConsoleKey.D1:
						Create_New_Database();
						break;
						;

					case ConsoleKey.NumPad2:
					case ConsoleKey.D2:
						Create_And_Populate_Tables();
						break;
						;

					case ConsoleKey.NumPad3:
					case ConsoleKey.D3:
						Show_Data_From_A_Table();
						break;
						;

					case ConsoleKey.NumPad4:
					case ConsoleKey.D4:
						Show_Advanced_Data_From_A_Table();
						break;
						;

					case ConsoleKey.Q:
						ExitMainLoop = true;
						break;
				}

				// We are back to the main, prepare to show the menu items
				if (!ExitMainLoop)
				{
					Con.Clear();
				}
			}
		} // static void Main(/*string[] args*/)
	} // partial class Program
} // namespace SQLiteAPI_Examples
