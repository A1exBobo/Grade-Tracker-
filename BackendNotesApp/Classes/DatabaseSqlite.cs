using Microsoft.Data.Sqlite;
using System;
using System.IO;

public static class DatabaseSqlite
{
    private const string DefaultFileName = "notesapp.db";
    private const string DefaultFolderName = "data";

    public static string GetDatabaseFilePath()
    {
        string baseDir = AppContext.BaseDirectory;
        string dataDir = Path.Combine(baseDir, DefaultFolderName);
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        return Path.Combine(dataDir, DefaultFileName);
    }

    public static string GetConnectionString()
    {
        string dbPath = GetDatabaseFilePath();
        return new SqliteConnectionStringBuilder { DataSource = dbPath }.ToString();
    }

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(GetConnectionString());
    }

    public static void EnsureDatabaseFileExists()
    {
        string dbPath = GetDatabaseFilePath();
        if (!File.Exists(dbPath))
        {
            using var conn = GetConnection();
            conn.Open();
        }
    }
}


///hjkdhwfgeidgiyqryef
/// f
/// erglhitrhg
/// fheriughitrhwi