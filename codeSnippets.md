# Code snippets for future use

### Get all tables from SQL
It is as simple as this:
```cs
DataTable t = _conn.GetSchema("Tables");
```
where _conn is a SqlConnection object that has already been connected to the correct database.
[Sauce](http://stackoverflow.com/questions/3005095/can-i-get-name-of-all-tables-of-sql-server-database-in-c-sharp-application)

### Get all tables from an ODBC database
```cs
using(DataTable tableschema = conn.GetSchema("TABLES"))
{
    // first column name
    foreach(DataRow row in tableschema.Rows)
    {
        lstBoxLogs.Items.Add(row["TABLE_NAME"].ToString());
    }
}
```
[Sauce](http://stackoverflow.com/a/8695383)

### Get the current logged in user
```cs
var windowsIdentity = WindowsIdentity.GetCurrent();
if (windowsIdentity != null)
{
    MessageBox.Show("Gebruikersnaam: " + windowsIdentity.Name);
}
else
{
    MessageBox.Show("Couldn't get the current username.\nBruh....\nSomething's wrong...");
}
```
[Sauce](http://stackoverflow.com/a/1240379)
