using BackendNotesApp;
using System.Data.SQLite;


public class MaterieRepository : IRepository
{
 private readonly string _connectionString = "Data Source=MyDatabase.sqlite;Version=3;";

    public void Save(Materie materie)
    {
         using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
            String query = "INSERT INTO Materie(ID,Nume,NumarCredite,PondereCurs,CursID,LaboratorID) VALUES (@ID,@Nume,@NumarCredite,@PondereCurs,@CursID,@LaboratorID)";

                using(SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", materie.Id);
                    command.Parameters.AddWithValue("@Nume", materie.Nume);
                    command.Parameters.AddWithValue("@NumarCredite", materie.NumarCredite);
                    command.Parameters.AddWithValue("@PondereCurs", materie.PondereCurs);
                    command.Parameters.AddWithValue("@CursID", materie.Curs.Id);
                    command.Parameters.AddWithValue("@LaboratorID", materie.Laborator.Id);



                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if(result < 0)
                        Console.WriteLine("Eroare:Insert(laborator)\nEroare la inserarea laboratorului.");
                }
            }
    }

    public void Update(Materie materie)
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