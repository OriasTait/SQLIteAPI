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
		public static void Show_Advanced_Data_From_A_Table()
		/*
		===============================================================================================
		PURPOSE:
		Provide an example of creating a database, 2 tables with data and selecting the data from both
		tables at the same time, obtaining extra information about the results and displaying it.
		-----------------------------------------------------------------------------------------------
		NOTES:
		- Because this leverages the SQLiteAPI, the NuGet package System.Data.SQLite.Core has been
		  included.
		===============================================================================================
		*/
		{
			////=============
			//// Variables - SQLite
			////=============
			//SQLite SQLiteDB = new SQLite();

			//=============
			// Setup Environment
			//=============
			// Clear the screen
			Con.Clear();
			Con.WriteLine();

			//// Create database
			//Create_New_Database(ref SQLiteDB, Example.Show_Data);

			//// Show the results of setting up the environment
			//if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			//{
			//	Con.WriteLine("Database, Table and Data have been created.");
			//}
			//else
			//{
			//	Con.WriteLine("Encountered the following error: " + SQLiteDB.Error_MSG);
			//}

			////=============
			//// Show the data
			////=============
			//// Define what data to show
			//SQLiteDB.SQL =
			//	"SELECT Col1, Col2 FROM Table1; ";
			//SQLiteDB.ExecuteQuery();

			//// Display the data from the QueryResults
			//Con.WriteLine();
			//Con.WriteLine("The data from the table:");

			//foreach (DataRow r in SQLiteDB.QueryResults.Tables[0].Rows)
			//{
			//	Con.Write(" | ");

			//	foreach (DataColumn column in SQLiteDB.QueryResults.Tables[0].Columns)
			//	{
			//		Con.Write(r[column].ToString() + " | ");
			//	}

			//	Con.WriteLine();
			//}

			//=============
			// Cleanup Environment
			//=============
			// Wait for the user
			Con.WriteLine();
			Con.Write("Press any key to continue...");
			Con.ReadKey();
		} // public static void Show_Advanced_Data_From_A_Table()
	} // partial class Program
} // namespace SQLiteAPI_Examples
