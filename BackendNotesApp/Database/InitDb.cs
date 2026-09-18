using System;
using System.Data.SQLite;
using BackendNotesApp;

    public class InitializeDatabase
    {
        private readonly string _connectionString = "Data Source=MyDatabase.sqlite;Version=3;";

        public InitializeDatabase()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(_connectionString);
            // this creates a zero-byte file
            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            m_dbConnection.Open();

            //string sql = "CREATE TABLE Curs(ID int primary key,AreDistribuita boolean not null);";


            SQLiteCommand command = new SQLiteCommand("CREATE TABLE Curs(ID int primary key,AreDistribuita boolean not null);"+
            "CREATE TABLE Semestru(ID int primary key,Numar int CHECK (Numar > 0 AND Numar <= 2) not null);"+
            "CREATE TABLE Laborator(ID int,NotaProiect float,PondereProiect int not null,NotaSeminar float,PondereSeminar int not null);"+
            "CREATE TABLE Materie(ID int,Nume varchar(50) not null,NumarCredite int not null,PondereCurs int not null,CursID int not null,LaboratorID int);"+
            "CREATE TABLE NotaLaborator(ID int,LaboratorID int not null,Nota float);"+
            "CREATE TABLE Distribuita(ID int,CursID int not null,NumarEvaluare int not null,Nota float);", m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();



        }

        public void ReadDb()
        {
            /*afisarea bazei de date 

                SQLiteConnection m_dbConnection = new SQLiteConnection(_connectionString);


                m_dbConnection.Open();

                string sql = "SELECT * from Curs;";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                
                int i = 0;
                while(reader.Read())                          //reader.Read() returneaza true sau false 
                {
                Console.WriteLine(reader[i].ToString());
                    if (i > 100)
                    {
                        break;
                    }
                    else
                    {
                        i++;
                    }         
                }
                m_dbConnection.Close();
                Console.WriteLine("i="+i);

            */    

            Console.WriteLine("Atentie! Functia ReadDb nu a fost implementata.");
        }
    }





            // Source - https://stackoverflow.com/a/7387108
            // Posted by marc_s, modified by community. See post 'Timeline' for change history
            // Retrieved 2026-09-18, License - CC BY-SA 4.0