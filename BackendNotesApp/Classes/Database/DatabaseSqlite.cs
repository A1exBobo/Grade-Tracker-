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
        return new SqliteConnectionStringBuilder { DataSource = GetDatabaseFilePath() }.ToString();
    }

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(GetConnectionString());
    }

    public static void InitializeDatabase(string initSqlFilePath = "init.sql")
    {
        string dbPath = GetDatabaseFilePath();
        bool dbExisted = File.Exists(dbPath);

        using var conn = GetConnection();
        conn.Open();

        // Dacă baza de date nu exista sau este goală, rulăm init.sql
        if (!dbExisted && File.Exists(initSqlFilePath))
        {
            string script = File.ReadAllText(initSqlFilePath);
            using var cmd = conn.CreateCommand();
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Baza de date a fost inițializată cu succes!");
        }
    }

    public static void VerifyTables()
    {
        using var conn = GetConnection();
        conn.Open();

        using var cmd = conn.CreateCommand();
        // Interogare specifică SQLite pentru a lista toate tabelele create
        cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";

        using var reader = cmd.ExecuteReader();
        Console.WriteLine("\nTabele găsite în baza de date:");
        while (reader.Read())
        {
            Console.WriteLine($"- {reader.GetString(0)}");
        }
    }
}