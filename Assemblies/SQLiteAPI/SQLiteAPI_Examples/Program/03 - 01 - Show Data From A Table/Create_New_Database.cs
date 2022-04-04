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
		public static void Create_New_Database(ref SQLite SQLiteDB, Example Program_Example)
			// Create a database based on the given example
		{
			switch (Program_Example)
			{
				case Example.Show_Data:
					SQLiteDB.DB_Name = "Select_Data_Database.db";
					SQLiteDB.DB_Path = @"D:\Work\Code\SQLIteAPI\Working_Dir\";

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
							"('Row 1 Inserted', 1) " +
							", ('Row 2 Inserted', 2) " +
							", ('Row 3 Inserted', 3) " +
							";";
						SQLiteDB.ExecuteNonQuery();
					}

					catch (Exception ex)  // Catch => Update state to error
					{
						SQLiteDB.DB_Status = SQLite.Status.Error;

						// Catch the error
						SQLiteDB.Error_MSG = ex.Message.Replace("\r\n", " ");  // Convert the message to one line
					}

					break;
			}
		}
	} // partial class Program
} // namespace SQLiteAPI_Examples
