using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Orias_SQLiteAPI
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "<Pending>")]
    public partial class SQLiteAPI
    /*
    ===============================================================================================
    PURPOSE:
    Standardize the Aplication Programming Interface (API) to a SQLite database.
    -----------------------------------------------------------------------------------------------
    NOTES:
    - This leverages the following NuGet Packages:
      - system.data.sqlite
      - System.Data.SQLite.Core
    - These need to be installed to be able to compile this project
    ===============================================================================================
    */
    {
        public SQLiteAPI()
        /*
        ===============================================================================================
        PURPOSE:
        Constructor for the SQLite API to set default values.
        ===============================================================================================
        */
        {
            // Start with a disonnected state
            Connection_State = ConnectionState.Disconnected;
        } // public SQLiteAPI
        
        ~SQLiteAPI()
        /*
        ===============================================================================================
        PURPOSE:
        Destructor for the SQLite API to cleanup the environment.
        ===============================================================================================
        */
        {
        } // ~SQLiteAPI
    } // public partial class SQLiteAPI
} // namespace SQLiteAPI
