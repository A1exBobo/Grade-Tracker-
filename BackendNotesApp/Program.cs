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

/*
==========================
DATABASE DESIGN NOTES
==========================

GENERAL:
- Toate clasele vor fi mapate ca entități EF Core.
- Se folosesc Id-uri ca Primary Key.
- List<float> este acceptabil pentru proiect simplu, dar în producție ar fi înlocuit cu entitate Nota.

==========================
CURS
==========================
- Id → Primary Key
- AreDistribuita → bool (control logică business)
- Distribuita1 → collection de note (incercări subiect 1)
- Distribuita2 → collection de note (incercări subiect 2)

RELATIONARE:
- 1 Curs → many notes (prin cele 2 liste)

OBSERVAȚII:
- Distribuirea notelor este controlată la nivel de aplicație, NU DB.
- Nu există tabel separat pentru Distribuita1/2 (logic split în memorie).

==========================
LABORATOR
==========================
- Id → Primary Key
- NoteLaborator → listă valori (1-N relationship implicit sau owned collection)
- NotaProiect → scalar (nullable)
- PondereProiect → int (0-100)
- NotaSeminar → scalar (nullable)
- PondereSeminar → int (0-100)

OBSERVAȚII:
- Proiect și Seminar sunt componente opționale.
- Ponderile trebuie validate în business logic (sum <= 100).

==========================
MATERIE
==========================
- Id → Primary Key
- Nume → string
- NumarCredite → int
- PondereCurs → float (0-1)
- Curs → navigation property (1-1 sau 1-N)
- Laborator → navigation property (1-1 sau 1-N)

OBSERVAȚII:
- Materie este AGREGATOR (nu conține logică de note).
- Doar combină rezultatele din Curs + Laborator.

==========================
REGULI IMPORTANTE
==========================
- Nu se stochează media în DB (este calculată).
- Nu se duplică datele (ex: nu salvăm și media și notele).
- Toate validările sunt în domain model (nu în DB).
- EF Core se folosește doar pentru persistare, nu logică.
*/