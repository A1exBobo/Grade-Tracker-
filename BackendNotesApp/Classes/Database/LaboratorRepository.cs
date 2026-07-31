using Microsoft.Data.Sqlite;
using System.Collections.Generic;

public class LaboratorRepository
{
    public Laborator? GetById(int id)
    {
        using var conn = DatabaseSqlite.GetConnection();
        conn.Open();

        // 1. Extragere date Laborator (inclusiv Proiect și Seminar)
        using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            SELECT ID, NotaProiect, PondereProiect, NotaSeminar, PondereSeminar 
            FROM Laborator 
            WHERE ID = @id;";
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = cmd.ExecuteReader();
        if (!reader.Read()) return null;

        var lab = new Laborator
        {
            Id = reader.GetInt32(0)
        };

        // Setăm Proiect dacă există valoare în BD
        if (!reader.IsDBNull(1))
        {
            float notaP = reader.GetFloat(1);
            int pondereP = reader.GetInt32(2);
            lab.SetProiect(notaP, pondereP);
        }

        // Setăm Seminar dacă există valoare în BD
        if (!reader.IsDBNull(3))
        {
            float notaS = reader.GetFloat(3);
            int pondereS = reader.GetInt32(4);
            lab.SetSeminar(notaS, pondereS);
        }

        // 2. Extragere lista de NoteLaborator
        lab.NoteLaborator = GetNoteLaborator(id, conn);

        return lab;
    }

    private List<float> GetNoteLaborator(int laboratorId, SqliteConnection conn)
    {
        var note = new List<float>();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT Nota FROM NotaLaborator WHERE LaboratorId = @labId AND Nota IS NOT NULL;";
        cmd.Parameters.AddWithValue("@labId", laboratorId);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            note.Add(reader.GetFloat(0));
        }

        return note;
    }
}