using System.Data.SQLite;
internal class Database
{
    private SQLiteConection connection;

    public Database()
    {
        connection = new SQLiteConection("Data Source=/path/to/file.db");
    } 
    public void Open()
    {
        this.Open(); 
    }
    public void Close()
    {
        this.Close(); 
    }
    public void ExecuteQuery()
    {
        ; 
    }

}