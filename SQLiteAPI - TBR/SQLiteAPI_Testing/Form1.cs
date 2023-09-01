using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using SQLiteAPI_Testing.Environment;

namespace SQLiteAPI_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Connection_Status.Text = Env.Database_Status;
            DB_Directory.Text = Env.Database_Directory;
            DB_Name.Text = Env.Database_Name;
        }
    }
}
