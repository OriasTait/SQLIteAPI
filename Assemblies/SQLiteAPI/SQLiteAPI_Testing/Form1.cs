using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//=============
// Application Packages
//=============
using SQLiteAPI_Testing.Environment;
using SQLiteAPI_Testing.Table_Create_and_Populate;

//=============
// Orias LLC Packages
//=============
using Orias_SQLiteAPI;

namespace SQLiteAPI_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        /*
        ===============================================================================================
        PURPOSE:
        Constructor of the Windows form.
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - The form is created
        ===============================================================================================
        */
        {
            //=============
            // Setup Environment
            //=============
            InitializeComponent();

            //=============
            // Display the information used to create the database
            //=============
            Connection_Status.Text = Env.Database_Status;
            DB_Directory.Text = Env.Database_Directory;
            DB_Name.Text = Env.Database_Name;
            Process_Error.Text = string.Empty;
        } // public Form1

        private void BTN_Create_EmptyDB_Click(object sender, EventArgs e)
        /*
        ===============================================================================================
        PURPOSE:
        Method called when the form button "Create New Database" is pressed.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Sender    => The handle to the form calling method
        - e         => Arguments passed to from the caller
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
            SQLiteAPI.ProcessStatus Results;

            //=============
            // Setup Environment
            //=============
            // Create an instance to connect to the database
            SQLiteAPI My_DB = new SQLiteAPI()
            {
                DB_Name = Env.Database_Name,
                DB_Path = Env.Database_Directory
            };

            //=============
            // Body
            //=============
            Results = My_DB.Create_DB(SQLiteAPI.DatabaseCreateType.Overwrite);

            //=============
            // Cleanup Environment
            //=============
            if (Results != SQLiteAPI.ProcessStatus.Valid)
            {
                Process_Error.Text = My_DB.Error_MSG;
            }
            else
            {
                Connection_Status.Text = "Database Created";
            }
        } // private void BTN_Create_EmptyDB_Click

        private void BTN_Table_Create_and_Populate_Click(object sender, EventArgs e)
        /*
        ===============================================================================================
        PURPOSE:
        Method called when the form button "Table Create and Populate" is pressed.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Sender    => The handle to the form calling method
        - e         => Arguments passed to from the caller
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
            SQLiteAPI.ProcessStatus Results;

            //=============
            // Setup Environment
            //=============
            // Create an instance to connect to the database
            SQLiteAPI My_DB = new SQLiteAPI()
            {
                DB_Name = "Table_Database.db",
                DB_Path = Env.Database_Directory
            };

            //=============
            // Body
            //=============
            // Create the database
            Results = My_DB.Create_DB(SQLiteAPI.DatabaseCreateType.Overwrite);

            if (Results != SQLiteAPI.ProcessStatus.Valid)
            {
                Process_Error.Text = My_DB.Error_MSG;
            }
            else
            {
                Connection_Status.Text = "Database Created";
            }

            // Create and Populate a table
            TC_and_P My_Table = new TC_and_P();

            Results = My_Table.Create_Table_and_Populate(ref My_DB);

            //=============
            // Cleanup Environment
            //=============
            if (Results != SQLiteAPI.ProcessStatus.Valid)
            {
                Process_Error.Text = My_DB.Error_MSG;
            }
            else
            {
                Connection_Status.Text = "Database tables created and populated";
            }
        } // private void BTN_Table_Create_and_Populate_Click

        private void BTN_Show_Data_Click(object sender, EventArgs e)
        /*
        ===============================================================================================
        PURPOSE:
        Method called when the form button "Show data in Table1" is pressed.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Sender    => The handle to the form calling method
        - e         => Arguments passed to from the caller
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - The data in table 1 will be displayed
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            SQLiteAPI.ProcessStatus Results;

            // Create an instance to connect to the database
            SQLiteAPI My_DB = new SQLiteAPI()
            {
                DB_Name = "Table_Database.db",
                DB_Path = Env.Database_Directory
            };

            //=============
            // Create a connection to the database
            //=============
            Results = My_DB.Create_DB(SQLiteAPI.DatabaseCreateType.Retain);

            //=============
            // Query the data
            //=============
            if (Results == SQLiteAPI.ProcessStatus.Valid)
            {
                // Define what data to show
                My_DB.SQL =
                    "SELECT * " +
                    "FROM Table1; ";
                My_DB.ExecuteQuery();

                //=============
                // Bind the data grid view to the results from the query
                // NOTE: Each result set are stored in a table object
                //=============
                // Bind to the first table in the results
                dataGridView1.DataSource = My_DB.QueryResults.Tables[0];
            }
        } // private void BTN_Show_Data_Click

        private void BTN_Show_Data2_Click(object sender, EventArgs e)
        /*
        ===============================================================================================
        PURPOSE:
        Method called when the form button "Show data in Table2" is pressed.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Sender    => The handle to the form calling method
        - e         => Arguments passed to from the caller
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - The data in table 2 will be displayed
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            SQLiteAPI.ProcessStatus Results;

            // Create an instance to connect to the database
            SQLiteAPI My_DB = new SQLiteAPI()
            {
                DB_Name = "Table_Database.db",
                DB_Path = Env.Database_Directory
            };

            //=============
            // Create a connection to the database
            //=============
            Results = My_DB.Create_DB(SQLiteAPI.DatabaseCreateType.Retain);

            //=============
            // Query the data
            //=============
            if (Results == SQLiteAPI.ProcessStatus.Valid)
            {
                // Define what data to show
                My_DB.SQL =
                    "SELECT * " +
                    "FROM Table2; ";
                My_DB.ExecuteQuery();

                //=============
                // Bind the data grid view to the results from the query
                // NOTE: Each result set are stored in a table object
                //=============
                // Bind to the first table in the results
                dataGridView1.DataSource = My_DB.QueryResults.Tables[0];
            }
        } // private void BTN_Show_Data2_Click

        private void BTN_ShrinkDB_Click(object sender, EventArgs e)
        /*
        ===============================================================================================
        PURPOSE:
        Release extra space used by the database back to the OS.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        - Sender    => The handle to the form calling method
        - e         => Arguments passed to from the caller
        -----------------------------------------------------------------------------------------------
        OUTPUT:
        - The database will be re-organized, releasing unused space.
        ===============================================================================================
        */
        {
            // Create an instance to connect to the database
            SQLiteAPI My_DB = new SQLiteAPI()
            {
                DB_Name = "Table_Database.db",
                DB_Path = Env.Database_Directory
            };

            // Release unused space
            My_DB.Shrink();

            // Show the current database size
            My_DB.Current_Size();
            Process_Error.Text = 
                "New Database Size " + 
                My_DB.DB_Current_Size +
                " kb";
        }
    } // public partial class Form1 : Form
} // namespace SQLiteAPI_Testing
