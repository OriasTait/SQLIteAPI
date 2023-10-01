using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteAPI_Testing
{
    namespace Environment
    /*
    ===============================================================================================
    PURPOSE:
    Centralize the information about the running environment
    ===============================================================================================
    */
    {
#pragma warning disable S1118 // Utility classes should not have public constructors
        internal class Env
#pragma warning restore S1118 // Utility classes should not have public constructors
        {
            // These values are hard coded, but could be programatically generated.
            public const string Database_Status = "";
            public const string Database_Directory = @"D:\Work\Code\Orias_OSC\SQLIteAPI\Working_Dir";
            public const string Database_Name = "Empty_Database.db";
        } // internal class Env
    } // namespace Environment
} // namespace SQLiteAPI_Testing
