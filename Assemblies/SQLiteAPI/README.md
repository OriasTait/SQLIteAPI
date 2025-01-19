# SQLiteAPI
Standardized processes, methods and routines for interfacing with a SQLite database.

## Notes for C# in Visual Studio
In order to use the SQLiteAPI, the following NuGet package must be installed for the project that uses this library:
* system.data.sqlite
* System.Data.SQLite.Core

## Notes for Unity
Include the following dlls in your unity project.
- SQLiteAPI.dll
- System.Data.SQLite.dll
- SQLite.Interop.dll

The database will need to reside in the StreamingAssets folder under the Assets folder or it will not be included in
the build.  Appropriate directory structures can used and will be retained under this folder.
- The folder StreamingAssets is not created by default, it will need to be created.

## Pros
### SQL-like database without the overhead
The database behaves like a large Relational Database without the additional services or applications to be installed.

## Cons
### SQLite is a designed for single user on the same machine
* The database used by an application is expected to be on the same machine as the calling application.  It is known to cause corruption with
  the database if it is accessed by multiple connections, different operating systems or resting on a network drive.

* The connection string includes the full path to the database.  A Universal Naming Convention (UNC) path will not work.

### SQLite is not encrypted
* The SQLite drivers used are the ones directly from the developers.  This version does not include encryption or password capability.
  In order to minimize the complexity of this solution, the 3rd party tools that can be encorporated for this functionality are not
  being used.

# The API

## SQLite Enumerations
* ConnectionState
  * Connected    => Connected to a database
  * Disconnected => Not connected to a database

* ConnectionType
  * DS	=> Data Source => Uses standard OS path definitions (C:\Directory\SubDirectory\ )
  * URI	=> Uniform Resource Identifier (Application.dataPath + "/Plugins/SQLite_DBs/")

* DatabaseCreateType
  * Overwrite => Overwrite the database if it exists
  * Retain	  => Do not Overwrite the database if it exists

* Status
  * Critical    => Encountered a critical state
  * Error		=> Encountered an error
  * Valid		=> No Errors Encountered
  * Warning		=> Encountered a warning state

* Validation_Type
  * DB_Connection => Database Connection

## SQLite Properties - SQLite Command Information
* Error_MSG      => Current Error message
* Process_Status => The status of the last process performed
* QueryResults   => Results of a query in the database stored in a Dataset object.
* SQL            => SQLite Standard Query Language command (SQL) to process
* SQL_CMD        => SQLite SQL Command to process in the database

## SQLite Properties - SQLite Connection Information
* Connection_State => Current Connection State
* DB_Conn          => Database Connection Type

## SQLite Properties - SQLite Database Information
* DB_Name       => The name of the database to use
* DB_Path       => The path associated with the database to use
* Full_DB_Path  => The full path with file name associated with the database to use

## SQLite Methods
These are the standardized methods to be called for interfacing with SQLite.

### Create_DB
PURPOSE:
Create a database based on the information provided in the SQLiteAPI class.

PARAMETERS:
- Create_Type => If the database should be overwritten or not.

OUTPUT:
- An empty database will be created.

NOTES:
- If Create_Type is set to Retain and the the database already exists, an error will be raised.

### Current_Size
PURPOSE:
Obtain the current size of the database.

### ExecuteNonQuery
PURPOSE:
Execute the SQL command against the SQLite database.

OUTPUT:
- If successful, the command has been executed; otherwise, the database state has been updated 
  to Error and the error message has been updated.

NOTES:
- It is assumed no results are being returned by the command being executed.

### ExecuteQuery
PURPOSE:
Execute the SQL Command against the SQLite database.

OUTPUT:
- If successful, the command has been executed and the results will be placed in the QueryResults property;
  otherwise, the database state will be updated to Error and the Error_MSG will contain the encountered error.

NOTES:
- It is assumed results are being returned by the command being executed.  The results are stored in QueryResults.
- If multiple queries are passed or multple results are generated, each result set is saved in a separate table
  data object within the propery QueryResults.

### Shrink
PURPOSE:
Re-organize the database to use the minimal amount of disk space.

NOTES:
- This leverages the SQLite command "VACUUM".  The VACUUM command rebuilds the database file, repacking
  it into a minimal amount of disk space.
  
  Reference: https://www.sqlite.org/lang_vacuum.html

# How to compile
This was created in Microsoft Visual Studio Community 2022.  Open the file SQLiteAPI.sln in Visual Studio and compile the project.
