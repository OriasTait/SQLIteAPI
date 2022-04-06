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
			Create_New_Database(ref SQLiteDB, Example.Show_Advanced_Data);

			//=============
			// Query the tables
			//=============
			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				SQLiteDB.SQL =
					"SELECT Col1, Col2 FROM Table1; " +
					"SELECT * FROM Table2; ";
				SQLiteDB.ExecuteQuery();
			}
			else 
			{
				Con.WriteLine("Encountered the following error: " + SQLiteDB.Error_MSG);
				Con.WriteLine();
			}

			//=============
			// Show some information about the results
			//=============
			if (SQLiteDB.DB_Status == SQLite.Status.Valid)
			{
				// How many results sets are there?
				Con.WriteLine("There are {0} result sets. {1}", SQLiteDB.QueryResults.Tables.Count, Environment.NewLine);

				// Identify each of the result sets
				DataTableCollection collection = SQLiteDB.QueryResults.Tables;
				for (int i = 0; i < collection.Count; i++)
				{
					//=============
					// Table Information
					//=============
					DataTable table = collection[i];  // Collection ID
					Con.WriteLine("Result Collection {0}: Resultset Name \"{1}\"", i, table.TableName);  // Table name

					//=============
					// Column Information
					//=============
					if (i == 0)
					{
						// We know there are 2 columns, so we can hard-code them
						Con.WriteLine("Column information hard coded:");
						Con.WriteLine("Column Name: {0} => Column Type: {1}"
							, SQLiteDB.QueryResults.Tables[i].Columns[0].ColumnName
							, SQLiteDB.QueryResults.Tables[i].Columns[0].DataType.ToString());
						Con.WriteLine("Column Name: {0} => Column Type: {1}"
							, SQLiteDB.QueryResults.Tables[i].Columns[1].ColumnName
							, SQLiteDB.QueryResults.Tables[i].Columns[1].DataType.ToString());
					}
					else 
					{
						// Or we can find the information programatically
						Con.WriteLine("Column information programatically:");
						foreach (DataColumn column in SQLiteDB.QueryResults.Tables[i].Columns)
						{
							Con.WriteLine("Column Name: {0} => Column Type: {1}", column.ColumnName, column.DataType);
						}
					}

					//=============
					// Row Information
					//=============
					Con.WriteLine("This resultset has {0} rows.", SQLiteDB.QueryResults.Tables[i].Rows.Count);

					//=============
					// Show the data
					//=============
					if (i == 0)
					{
						//=============
						// Using the column names
						//=============
						// Obtain the column information; we know there are 2, so they are hard-coded
						string Col1Name = SQLiteDB.QueryResults.Tables[i].Columns[0].ColumnName;
						string Col2Name = SQLiteDB.QueryResults.Tables[i].Columns[1].ColumnName;

						Con.WriteLine("The resultset:");

						foreach (DataRow r in SQLiteDB.QueryResults.Tables[i].Rows)
						{
							string TableData = string.Empty;

							// Access the column data by name
							TableData = " | " + r[Col1Name].ToString() + " | " + r[Col2Name].ToString() + " | ";

							Con.WriteLine(TableData);
						}
					}
					else
					{
						//=============
						// Programatically
						//=============
						Con.WriteLine("The resultset:");
						foreach (DataRow r in SQLiteDB.QueryResults.Tables[i].Rows)
						{
							Con.Write(" | ");

							foreach (DataColumn column in SQLiteDB.QueryResults.Tables[i].Columns)
							{
								Con.Write(r[column].ToString() + " | ");
							}

							Con.WriteLine();
						}
					}

					Con.WriteLine();
				}
			}

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
