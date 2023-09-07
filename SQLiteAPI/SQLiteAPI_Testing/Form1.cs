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

//=============
// Orias Packages
//=============
using Orias_SQLiteAPI;

namespace SQLiteAPI_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Display the information used to create the database
            Connection_Status.Text = Env.Database_Status;
            DB_Directory.Text = Env.Database_Directory;
            DB_Name.Text = Env.Database_Name;
            Process_Error.Text = string.Empty;
        }

        private void BTN_Create_EmptyDB_Click(object sender, EventArgs e)
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

            if (Results != SQLiteAPI.ProcessStatus.Valid)
            {
                Process_Error.Text = My_DB.Error_MSG;
            }
            else
            {
                Connection_Status.Text = "Database Created";
            }
        }
    } // public partial class Form1 : Form
} // namespace SQLiteAPI_Testing
