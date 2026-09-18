using System;
using System.Data.SQLite;
using BackendNotesApp;

    public class InitializeDatabase
    {
        public InitializeDatabase()
        {
            // this creates a zero-byte file
            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            string connectionString = "Data Source=MyDatabase.sqlite;Version=3;";
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "Create Table highscores (name varchar(20), score int)";            // you could also write sql = "CREATE TABLE IF NOT EXISTS highscores ..."

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "Insert into highscores (name, score) values ('Me', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            //afisarea bazei de date 

            sql = "SELECT score, name, Length(name) as Name_Length FROM highscores WHERE score > 799";
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
            Console.WriteLine(reader[0].ToString()  + " " 
                            +  reader[1].ToString()  + " " 
                            +  reader[2].ToString());            
            }
            m_dbConnection.Close();


        }
    }