using System;
using System.Collections.Generic;
using System.Linq;

public class Laborator
{
    public int Id { get; set; }

    public List<float> NoteLaborator { get; set; } = new();

    private float? notaProiect;
    private int pondereProiect;

    private float? notaSeminar;
    private int pondereSeminar;

    public void AdaugaNotaLaborator(float nota)
    {
        if (nota < 0 || nota > 10)
            throw new ArgumentOutOfRangeException(nameof(nota));

        NoteLaborator.Add(nota);
    }

    // =========================
    // PROIECT (CONTROLAT)
    // =========================
    public void SetProiect(float nota, int pondere)
    {
        ValidateNota(nota);
        ValidatePondere(pondere);

        notaProiect = nota;
        pondereProiect = pondere;
    }

    // =========================
    // SEMINAR (CONTROLAT)
    // =========================
    public void SetSeminar(float nota, int pondere)
    {
        ValidateNota(nota);
        ValidatePondere(pondere);

        notaSeminar = nota;
        pondereSeminar = pondere;
    }

    // =========================
    // VALIDĂRI
    // =========================
    private void ValidateNota(float nota)
    {
        if (nota < 0 || nota > 10)
            throw new ArgumentOutOfRangeException(nameof(nota));
    }

    private void ValidatePondere(int pondere)
    {
        if (pondere < 0 || pondere > 100)
            throw new ArgumentOutOfRangeException(nameof(pondere));
    }

    private float MedieLaboratorSimpla()
    {
        return NoteLaborator.Count == 0 ? 0 : NoteLaborator.Average();
    }

    // =========================
    // CALCUL FINAL
    // =========================
    public float CalculMedieLaborator()
    {
        int totalPonderi = pondereProiect + pondereSeminar;

        if (totalPonderi > 100)
            throw new InvalidOperationException("Ponderile depășesc 100%.");

        float medieLab = MedieLaboratorSimpla();

        float pProiect = pondereProiect / 100f;
        float pSeminar = pondereSeminar / 100f;
        float pLab = 1f - (pProiect + pSeminar);

        float rezultat = medieLab * pLab;

        if (notaProiect.HasValue)
            rezultat += notaProiect.Value * pProiect;

        if (notaSeminar.HasValue)
            rezultat += notaSeminar.Value * pSeminar;

        return rezultat;
    }
}