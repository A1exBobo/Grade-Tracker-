using BackendNotesApp;
using System.Data.SQLite;

public class LaboratorRepository : IRepository
{
    private readonly string _connectionString = "Data Source=MyDatabase.sqlite;Version=3;";

    public void Save(Laborator laborator)
    {
         using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
            String query = "INSERT INTO Laborator(ID,NotaProiect,PondereProiect,NotaSeminar,PondereSeminar) VALUES (@ID,@NotaProiect,@PondereProiect,@NotaSeminar,@PondereSeminar)";

                using(SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", laborator.Id);
                    command.Parameters.AddWithValue("@NotaProiect", laborator.NotaProiect);
                    command.Parameters.AddWithValue("@PondereProiect", laborator.PondereProiect);
                    command.Parameters.AddWithValue("@NotaSeminar", laborator.NotaSeminar);
                    command.Parameters.AddWithValue("@PondereSeminar", laborator.PondereSeminar);


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if(result < 0)
                        Console.WriteLine("Eroare:Insert(laborator)\nEroare la inserarea laboratorului.");
                }
            }
    }

    public void Update(Laborator laborator)
    {
        ;
    }

    public void Delete(int id)
    {
        
    }

    public void Get(int id)
    {
        ;
    }


}