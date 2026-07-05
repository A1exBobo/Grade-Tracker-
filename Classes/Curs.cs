using System;
using System.Collections.Generic;
using System.Linq;

public class Curs
{
    public int Id { get; set; }

    public bool AreDistribuita { get; set; }

    public List<float> Distribuita1 { get; set; } = new();
    public List<float> Distribuita2 { get; set; } = new();

    public Curs(bool areDistribuita)
    {
        AreDistribuita = areDistribuita;
    }

    // =========================
    // ADĂUGARE DISTRIBUITA 1
    // =========================
    public void AdaugaDistribuita1(float nota)
    {
        Validate(nota);

        if (!AreDistribuita)
            throw new InvalidOperationException("Cursul nu are distribuție.");

        if (Distribuita1.Count >= 3)
            throw new InvalidOperationException("Max 3 încercări pentru Distribuita 1.");

        Distribuita1.Add(nota);
    }

    // =========================
    // ADĂUGARE DISTRIBUITA 2
    // =========================
    public void AdaugaDistribuita2(float nota)
    {
        Validate(nota);

        if (!AreDistribuita)
            throw new InvalidOperationException("Cursul nu are distribuție.");

        if (Distribuita2.Count >= 3)
            throw new InvalidOperationException("Max 3 încercări pentru Distribuita 2.");

        Distribuita2.Add(nota);
    }
    // =========================
    // ADAUGA NOTA
    // =========================
    public void AdaugaNota(float nota)
{
    Validate(nota);

    if (AreDistribuita)
        throw new InvalidOperationException("Cursul are distribuție. Folosește AdaugaDistribuita1/2.");

    Distribuita1.Add(nota);
}

    // =========================
    // VALIDARE NOTA
    // =========================
    private void Validate(float nota)
    {
        if (nota < 0 || nota > 10)
            throw new ArgumentOutOfRangeException(nameof(nota));
    }

    // =========================
    // CALCUL MEDIE CURS
    // =========================
    public float CalculMedie()
    {
        if (!AreDistribuita)
        {
            var all = Distribuita1.Concat(Distribuita2).ToList();
            return all.Count == 0 ? 0 : all.Max();
        }

        float max1 = Distribuita1.Count > 0 ? Distribuita1.Max() : 0;
        float max2 = Distribuita2.Count > 0 ? Distribuita2.Max() : 0;

        return (max1 + max2) / 2f;
    }
}