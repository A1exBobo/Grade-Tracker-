using System;

public class Materie
{
    public int Id { get; set; }

    public string? Nume { get; set; }

    public int NumarCredite { get; set; }

    // 0 - 1 (ex: 0.6 = 60% curs, 40% laborator)
    public float PondereCurs { get; set; }

    public Curs? Curs { get; set; }
    public Laborator? Laborator { get; set; }

    public Materie() { }

    public Materie(string? nume, int numarCredite, float pondereCurs)
    {
        Nume = nume;
        NumarCredite = numarCredite;
        PondereCurs = pondereCurs;
    }

    private void Validate()
    {
        if (PondereCurs < 0 || PondereCurs > 1)
            throw new InvalidOperationException("PondereCurs trebuie să fie între 0 și 1.");

        if (Curs == null && Laborator == null)
            throw new InvalidOperationException("Materie fără Curs și Laborator.");
    }

    public float CalculMedieMaterie()
    {
        Validate();

        float medieCurs = Curs?.CalculMedie() ?? 0f;
        float medieLab = Laborator?.CalculMedieLaborator() ?? 0f;

        bool areCurs = Curs != null;
        bool areLab = Laborator != null;

        if (areCurs && areLab)
        {
            return (medieCurs * PondereCurs) +
                   (medieLab * (1 - PondereCurs));
        }

        if (areCurs)
            return medieCurs;

        return medieLab;
    }
}