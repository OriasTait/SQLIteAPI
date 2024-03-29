﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;   // NuGet Package => System.Data.SQLite
using System.IO;            // file system class
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Orias_SQLiteAPI
{
    public partial class SQLiteAPI
    {
        public ProcessStatus Create_DB(DatabaseCreateType Create_Type)
        /*
        ===============================================================================================
        PURPOSE:
        Create a database based on the information provided in the SQLiteAPI class.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Create_Type => If the database should be overwritten or not.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - An empty database will be created.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - If Create_Type is set to Retain and the the database already exists, an error will be raised.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            ProcessStatus Results;

            //=============
            // Setup Environment
            //=============
            Results = Create_Connection_String();

            if (Results == ProcessStatus.Valid)
            {
                switch (Create_Type)
                {
                    case DatabaseCreateType.Retain:
                        if (File.Exists(Full_DB_Path))
                        {
                            try
                            {
                                // Create a connection to the database
                                conn = new SQLiteConnection(Connection_String);

                                // Open the connection
                                conn.Open();

                                // Close the connection
                                conn.Close();
                            }

                            catch (Exception ex) // Error creating the database
                            {
                                Process_Status = ProcessStatus.Error;
                                Error_MSG =
                                    "Opening the database "
                                    + DB_Name
                                    + " returned the error: "
                                    + ex.Message.Replace("\r\n", " ");  // Convert the message to one line
                            }
                        }
                        else
                        {
                            Create_The_Database();
                        }
                        break;

                    case DatabaseCreateType.Overwrite:
                        if (File.Exists(Full_DB_Path))
                        {
                            // Remove the existing database
                            File.Delete(Full_DB_Path);
                        }

                        try
                        {
                            // Create a new database
                            Create_The_Database();
                        }

                        catch (Exception ex) // Error creating the database
                        {
                            Process_Status = ProcessStatus.Error;
                            Error_MSG =
                                "Creating the database "
                                + DB_Name
                                + " returned the error: "
                                + ex.Message.Replace("\r\n", " ");  // Convert the message to one line
                        }
                        break;
                } // switch Create_Type
            } // if Results == ProcessStatus.Valid

            //=============
            // Cleanup Environment
            //=============
            Results = Process_Status;
            return Results;
        } // public ProcessStatus Create_DB
    } // public partial class SQLiteAPI
} // namespace Orias_SQLiteAPI
