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
		/*
        ===============================================================================================
        PURPOSE:
        Create a database based on the given example.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
		- SQLiteDB			=> Reference to the SQLite Database to use
		- Program_Example	=> The example from the program calling this process
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - If successful, the command has been executed; otherwise, the database state has been updated
          to Error and the error message has been updated.
        ===============================================================================================
        */
		{
			//=============
			// Body
			//=============
			switch (Program_Example)
			{
				case Example.Show_Data:
					Create_Database_03(ref SQLiteDB);
					break;

				case Example.Show_Advanced_Data:
					Create_Database_04(ref SQLiteDB);
					break;

				case Example.Administion:
					Create_Database_05(ref SQLiteDB);
					break;
			} // switch Program_Example
		} // public static void Create_New_Database(ref SQLite SQLiteDB, Example Program_Example)
	} // partial class Program
} // namespace SQLiteAPI_Examples
