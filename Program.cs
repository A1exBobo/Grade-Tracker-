// See https://aka.ms/new-console-template for more information


Laborator LabPCLP = new Laborator
{
    NoteLaborator = new float[] { 8.5f, 9.0f, 7.5f },
    notaProiect = 9.5f,
    PondereProiect = 30,
    notaSeminar = 8.0f,
    PondereSeminar = 20
};

Curs CursPCLP = new Curs
{
    areDistribuita = true,
    NoteDistribuite = new Tuple<float, float>[]
    {
        new Tuple<float, float>(8.0f, 9.0f),
        new Tuple<float, float>(7.5f, 8.5f)
    }
};

Materie PCLP = new Materie(
    nume: "Programare Calculatoare si Limbaje de Programare",
    numarCredite: 5,
    pondereCurs: 0.6f,
    laborator: LabPCLP,
    labHasProject: true,
    labHasSeminar: false,
    cursHasDistribuita: true,
    curs: CursPCLP
);

float medieLaborator = LabPCLP.CalculMedieLaborator(PCLP.LabHasProject, PCLP.LabHasSeminar);
float medieCurs = CursPCLP.CalculMedieCurs(CursPCLP.areDistribuita);
float mediePclp = PCLP.CalculMedieMaterie();

Console.WriteLine($"Media la materia {PCLP.Nume} este: {mediePclp}.");
Console.WriteLine($"Media la laboratorul {PCLP.Nume} este: {medieLaborator}.");
Console.WriteLine($"Media la cursul {PCLP.Nume} este: {medieCurs}.");