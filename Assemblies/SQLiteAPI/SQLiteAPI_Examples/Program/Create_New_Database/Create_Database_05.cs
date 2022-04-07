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
		private static void Create_Database_05(ref SQLite SQLiteDB)
		/*
        ===============================================================================================
        PURPOSE:
        Create a database and appropriate database objects for example 05.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
		- SQLiteDB	=> Reference to the SQLite Database to use
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - If successful, the database and appropriate objects will be created; otherwise, the database
		  state has been updated to Error and the error message has been updated.
        ===============================================================================================
        */
		{
			//=============
			// Configure the database
			//=============
			SQLiteDB.DB_Name = "Admin_5_Database.db";
			SQLiteDB.DB_Path = @"D:\Work\Code\SQLIteAPI\Working_Dir\";

			//=============
			// Create the database and appropriate objects
			//=============
			try // Setup the database, table and data to query
			{
				// Create the database
				SQLiteDB.Create_DB(true);

				// Create the table
				SQLiteDB.SQL =
				"CREATE TABLE Table1 " +
				"(" +
				" Col1 VARCHAR(20), " +
				" Col2 INT " +
				")";
				SQLiteDB.ExecuteNonQuery();

				// Populate the table
				SQLiteDB.SQL =
					"INSERT INTO Table1 " +
					"(Col1, Col2) " +
					"VALUES " +
					"('Table1 Row 1 Inserted', 1) " +
					", ('Table1 Row 2 Inserted', 2) " +
					", ('Table1 Row 3 Inserted', 3) " +
					";";
				SQLiteDB.ExecuteNonQuery();

				// Create the table
				SQLiteDB.SQL =
				"CREATE TABLE Table2 " +
				"(" +
				" Col1 VARCHAR(20), " +
				" Col2 INT " +
				")";
				SQLiteDB.ExecuteNonQuery();

				// Populate the table
				SQLiteDB.SQL =
					"INSERT INTO Table2 " +
					"(Col1, Col2) " +
					"VALUES " +
					"('Table2 Row 1 Inserted', 1) " +
					", ('Table2 Row 2 Inserted', 2) " +
					", ('Table2 Row 3 Inserted', 3) " +
					";";
				SQLiteDB.ExecuteNonQuery();

				// Create the table
				SQLiteDB.SQL =
				"CREATE TABLE Table3 " +
				"(" +
				" Col1 VARCHAR(20), " +
				" Col2 INT " +
				")";
				SQLiteDB.ExecuteNonQuery();

				// Populate the table
				SQLiteDB.SQL =
					"INSERT INTO Table3 " +
					"(Col1, Col2) " +
					"VALUES " +
					"('Table3 Row 1 Inserted', 1) " +
					", ('Table3 Row 2 Inserted', 2) " +
					", ('Table3 Row 3 Inserted', 3) " +
					";";
				SQLiteDB.ExecuteNonQuery();
			}

			//=============
			// Catch any errors that have been encountered.
			//=============
			catch (Exception ex)  // Catch => Update state to error
			{
				SQLiteDB.DB_Status = SQLite.Status.Error;

				// Catch the error
				SQLiteDB.Error_MSG = ex.Message.Replace("\r\n", " ");  // Convert the message to one line
			}
		} // public static void Create_Database_05(ref SQLite SQLiteDB)
	} // partial class Program
} // namespace SQLiteAPI_Examples
