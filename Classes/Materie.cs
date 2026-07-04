class Materie
{
    public string? Nume { get; set; }
    public int numarCredite { get; set; }

    public float PondereCurs { get; set; }

    public Laborator? Laborator { get; set; }

    public bool LabHasProject { get; set; }

    public bool LabHasSeminar { get; set; }

    public bool CursHasDistribuita { get; set; }
    public Curs? Curs { get; set; }


    public Materie(string? nume, int numarCredite, float pondereCurs, Laborator? laborator, bool labHasProject, bool labHasSeminar, bool cursHasDistribuita, Curs? curs)
    {
        Nume = nume;
        this.numarCredite = numarCredite;
        PondereCurs = pondereCurs;
        Laborator = laborator;
        LabHasProject = labHasProject;
        LabHasSeminar = labHasSeminar;
        CursHasDistribuita = cursHasDistribuita;
        Curs = curs;
    }
    public float CalculMedieMaterie()
    {
        float? medieCurs = Curs?.CalculMedieCurs(CursHasDistribuita);
        float? medieLab = Laborator?.CalculMedieLaborator(LabHasProject, LabHasSeminar);

        if (medieCurs == null || medieLab == null)
        {
            return 0f;
        }

        return (medieCurs.Value * PondereCurs) + (medieLab.Value * (1 - PondereCurs));
    }

    
}