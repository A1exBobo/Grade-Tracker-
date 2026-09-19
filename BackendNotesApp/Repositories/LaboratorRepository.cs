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
        using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
            String NotaProiect = laborator.NotaProiect.ToString();
            String query = $" UPDATE Laborator "+
                           $" SET NotaProiect = {laborator.NotaProiect.ToString().Replace(',','.')}," +
                           $" PondereProiect = {laborator.PondereProiect},"+
                           $" NotaSeminar = {laborator.NotaSeminar.ToString().Replace(',','.')},"+
                           $" PondereSeminar = {laborator.PondereSeminar}"+
                           $" WHERE ID = {laborator.Id}";

            //Console.WriteLine(query);

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

    public void Delete(Laborator laborator)
    {
        using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
            String query = $"DELETE FROM Laborator WHERE Id = {laborator.Id}; ";      //ar trebui sa stearga si cursurile si celelalte 
                using(SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if(result < 0)
                        Console.WriteLine($"Eroare:Delete(materie)\nEroare la stergerea laboratorului cu id - ul: {laborator.Id}.");
                }

            }
    }

    public void Get(int id)
    {
        ;
    }


}