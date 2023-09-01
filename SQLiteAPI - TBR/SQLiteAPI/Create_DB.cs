using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;   // NuGet Package => System.Data.SQLite
using System.IO;            // file system class

namespace SQLiteAPI
{
    public partial class SQLite
    {
        private const string Path_Divider = @"\";

        public void Create_DB(bool Overwrite)
        /*
        ===============================================================================================
        PURPOSE:
        Create a database based on the API and if it should overwrite it or not.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Overwrite => If the database should be overwritten or not.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - An empty database will be created.  If Overwrite is set to false and the database already
          exists, an error will be raised.
        ===============================================================================================
        */
        {
            //=============
            // Body
            //=============
            Create_Connection_String();

            if (DB_Status == Status.Valid)
			{
                //=============
                // Overwrite the database if it exists
                //=============
                if (Overwrite)
                {
                    string Full_DB_Path = DB_Path + Path_Divider + DB_Name;
                    try
                    {
                        if (File.Exists(Full_DB_Path)) 
                        {
                            File.Delete(Full_DB_Path);
                        }
                        
                        conn = new SQLiteConnection(ConnectionString);  // Create a connection to the database
                        conn.Open();  // Open the connection
                        conn.Close(); // Close the connection
                    }
                    catch (Exception ex) // Error creating the database
                    {
                        DB_Status = Status.Error;
                        Error_MSG = 
                            "Create the database " 
                            + DB_Name 
                            + " returned the error: " 
                            + ex.Message.Replace("\r\n", " ");  // Convert the message to one line
                    }
                }

                //=============
                // Do not overwrite the database if it exists
                //=============
                else
				{
                    // Check if file exists
                    if (File.Exists(DB_Path + Path_Divider + DB_Name))
                    {
						try
                        {
                            conn = new SQLiteConnection(ConnectionString);  // Create a connection to the database
                            conn.Open();  // Open the connection
                            conn.Close(); // Close the connection
                        }
                        catch (Exception ex) // Error creating the database
                        {
                            DB_Status = Status.Error;
                            Error_MSG =
                                "Create the database "
                                + DB_Name
                                + " returned the error: "
                                + ex.Message.Replace("\r\n", " ");  // Convert the message to one line
                        }
                    }
                    else
					{
                        DB_Status = Status.Error;
                        Error_MSG = "Cannot create the database: a database with that name already exists.";
					}
                } // if (!Overwrite)
            } // if DB_Status == Status.Valid
        } // public void Create_DB
    } // public partial class SQLite
} // namespace SQLiteAPI
