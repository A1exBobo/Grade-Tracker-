using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // =========================
        // LABORATOR SSC
        // =========================
        Laborator LabSSC = new Laborator();

        LabSSC.AdaugaNotaLaborator(6.0f);
        LabSSC.AdaugaNotaLaborator(7.0f);

        LabSSC.SetProiect(7.83f, 30);
        //LabSSC.SetSeminar(8.0f, 20);           //la acesta materie nu am avut seminar, deci nu am apelat metoda SetSeminar

        // =========================
        // CURS SSC
        // =========================
        Curs CursSSC = new Curs(areDistribuita: false);

        CursSSC.AdaugaNota(5.0f);



        // =========================
        // MATERIE SSC
        // =========================
        Materie SSC = new Materie(
            nume: "Securitatea sistemelor de calcul",
            numarCredite: 5,
            pondereCurs: 0.6f
        )
        {
            Curs = CursSSC,
            Laborator = LabSSC
        };

        // =========================
        // CALCULE
        // =========================
        float medieLaboratorSSC = LabSSC.CalculMedieLaborator();
        float medieCursSSC = CursSSC.CalculMedie();
        float medieSSC = SSC.CalculMedieMaterie();

        // =========================
        // OUTPUT
        // =========================
        Console.WriteLine($"Media la materia {SSC.Nume} este: {medieSSC}.");
        Console.WriteLine($"Media la laboratorul {SSC.Nume} este: {medieLaboratorSSC}.");
        Console.WriteLine($"Media la cursul {SSC.Nume} este: {medieCursSSC}.");
    }
}