using System.Data.SQLite;

namespace BackendNotesApp
{
    public class CursRepository : IRepository
    {
        private readonly string _connectionString = "Data Source=MyDatabase.sqlite;Version=3;";

        public void Save(Curs curs)
        {
            using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
            String query = "INSERT INTO Curs(ID,AreDistribuita) VALUES (@ID,@AreDistribuita)";

                using(SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", curs.Id);
                    command.Parameters.AddWithValue("@AreDistribuita", curs.AreDistribuita);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if(result < 0)
                        Console.WriteLine("Eroare:Insert(curs)\nEroare la inserarea cursului.");
                }
            }

        }

        public void Update(Curs curs)
        {
      
            using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
            String query = $"UPDATE Curs SET AreDistribuita = {curs.AreDistribuita} WHERE Id = {curs.Id};  ";

                using(SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AreDistribuita", curs.AreDistribuita);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if(result < 0)
                        Console.WriteLine("Eroare: Update(Curs)\nEroare la modificarea cursului.");
                }
            }

        }

        public void Delete(Curs curs)
        {
             using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
            String query = $"DELETE FROM Curs WHERE Id = {curs.Id}; ";

            }

            //Ceva nu a functionat aici sau e nevoie de extra verificari 

        }

        public void Get(Curs curs)
        {
                  using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
            String query = $"SELECT * FROM Curs WHERE Id = {curs.Id}; ";

            }
        }

        //Ceva nu a functionat aici sau e nevoie de extra verificari 

    }



    // Source - https://stackoverflow.com/a/19956944
    // Posted by Andrew Paes, modified by community. See post 'Timeline' for change history
    // Retrieved 2026-09-17, License - CC BY-SA 3.0
}