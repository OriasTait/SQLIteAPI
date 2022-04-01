# SQLiteAPI
Standardized processes, methods and routines for interfacing with a SQLite database.

## Notes for C#
In order to use the SQLiteAPI, the following NuGet package must be installed for the project that uses this library:
* System.Data.SQLite.Core

## Notes for Unity
Include the following dlls in your unity project.
- SQLiteAPI.dll
- System.Data.SQLite.dll
- SQLite.Interop.dll

The syntax will be the same as shown in these examples.

## Pros
### SQL-like database without the overhead
The database behaves like a large Relational Database without the additional services or applications to be installed.

## Cons
### SQLite is a designed for single user on the same machine
* The database used by an application is expected to be on the same machine as the calling application.  It is known to cause corruption with
  the database if it is accessed by multiple connections, different operating systgems or resting on a network drive.

* The connection string includes the full path to the database.  A Universal Naming Convention (UNC) path will not work.

### SQLite is not encrypted
* The SQLite drivers used are the ones directly from the developers.  This version does not include encryption or password capability.
  In order to minimize the complexity of this solution, the 3rd party tools that can be encorporated for this functionality are not
  being used.

=============

# The API

## SQLite Methods
These are the standardized methods to be called for interfacing with SQLite.

### Create_DB

=============

#How to compile
This was created in Microsoft Visual Studio Community 2019.  Open the file SQLiteAPI.sln in Visual Studio and compile the project.