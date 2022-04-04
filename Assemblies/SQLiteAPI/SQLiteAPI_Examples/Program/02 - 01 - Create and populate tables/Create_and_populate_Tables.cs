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
//using SQLiteState = SQLiteAPI.SQLite.Status;

namespace SQLiteAPI_Examples
{
	partial class Program
	{
		public static void Create_And_Populate_Tables()
		/*
		===============================================================================================
		PURPOSE:
		Provide an example of creating 2 tables and populating them with default data.
		-----------------------------------------------------------------------------------------------
		NOTES:
		- Because this leverages the SQLiteAPI, the NuGet package System.Data.SQLite.Core has been
		  included.
		===============================================================================================
		*/
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
			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				//=============
				// If Table 1 exeists, drop it
				//=============
				SQLiteDB.SQL = "DROP TABLE IF EXISTS Table1; ";
				SQLiteDB.ExecuteNonQuery();

				if(SQLiteDB.DB_Status == SQLite.Status.Error)
				{
					Con.WriteLine("Create Table1 returned the following error: " + Environment.NewLine + SQLiteDB.Error_MSG);
				}
			}

			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				//=============
				// Create Table1
				//=============
				SQLiteDB.SQL =
				"CREATE TABLE Table1 " +
				"(" +
				" Col1 VARCHAR(20), " +
				" Col2 INT " +
				")";
				SQLiteDB.ExecuteNonQuery();

				if (SQLiteDB.DB_Status == SQLite.Status.Error)
				{
					Con.WriteLine("Create Table1 returned the following error: " + Environment.NewLine + SQLiteDB.Error_MSG);
				}
			}

			//=============
			// Populate Table1
			//=============
			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				SQLiteDB.SQL =
					"INSERT INTO Table1 " +
					"(Col1, Col2) " +
					"VALUES " +
					"('Row 1 Inserted', 1) " +
					", ('Row 2 Inserted', 2) " +
					", ('Row 3 Inserted', 3) " +
					";";
				SQLiteDB.ExecuteNonQuery();

				if (SQLiteDB.DB_Status == SQLite.Status.Error)
				{
					Con.WriteLine("Populate Table1 returned the following error: " + Environment.NewLine + SQLiteDB.Error_MSG);
				}
			}

			//=============
			// Create Table2
			//=============
			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				// Combine drop and create into a single statement
				SQLiteDB.SQL =
				"DROP TABLE IF EXISTS Table2; " +
				"CREATE TABLE Table2 " +
				"(" +
				" Col1 VARCHAR(20), " +
				" Col2 INT " +
				")";
				SQLiteDB.ExecuteNonQuery();

				if (SQLiteDB.DB_Status == SQLite.Status.Error)
				{
					Con.WriteLine("Create Table1 returned the following error: " + Environment.NewLine + SQLiteDB.Error_MSG);
				}
			}

			//=============
			// Populate Table2
			//=============
			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				SQLiteDB.SQL =
					"INSERT INTO Table2 " +
					"(Col1, Col2) " +
					"VALUES " +
					"('Row 01 Inserted', 1) " +
					", ('Row 02 Inserted', 2) " +
					", ('Row 03 Inserted', 3) " +
					";";
				SQLiteDB.ExecuteNonQuery();

				if (SQLiteDB.DB_Status == SQLite.Status.Error)
				{
					Con.WriteLine("Populate Table1 returned the following error: " + Environment.NewLine + SQLiteDB.Error_MSG);
				}
			}

			//=============
			// Cleanup Environment
			//=============
			// If all is successful, indicate it to the user
			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				Con.WriteLine("Table1 and Tabl2 have been created and populated.");
			}

			// Wait for the user
			Con.WriteLine();
			Con.Write("Press any key to continue...");
			Con.ReadKey();
		} // public static void Create_And_Populate_Tables()
	} // partial class Program
} // namespace SQLiteAPI_Examples
