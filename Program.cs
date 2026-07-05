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


//------------------------------------------------------------------------
Laborator LabSSC = new Laborator
{
    NoteLaborator = new float[] { 7.0f, 7.0f },
    notaProiect = 7.83f,
    PondereProiect = 60,
    notaSeminar = 8.0f,
    PondereSeminar = 20
};

Curs CursSSC = new Curs
{
    areDistribuita = true,
    NoteDistribuite = new Tuple<float, float>[]
    {
        new Tuple<float, float>(5.0f, 5.0f),          //note curente
        new Tuple<float, float>(7.0f, 7.0f)          //posibile note 
    }
};

Materie SSC = new Materie(
    nume: "Securitatea sistemelor de calcul",
    numarCredite: 5,
    pondereCurs: 0.6f,
    laborator: LabSSC,
    labHasProject: false,
    labHasSeminar: false,
    cursHasDistribuita: true,
    curs: CursSSC
);

float medieLaboratorSSC = LabSSC.CalculMedieLaborator(SSC.LabHasProject, SSC.LabHasSeminar);
float medieCursSSC = CursSSC.CalculMedieCurs(CursSSC.areDistribuita);
float medieSSC = SSC.CalculMedieMaterie();

Console.WriteLine($"Media la materia {SSC.Nume} este: {medieSSC}.");
Console.WriteLine($"Media la laboratorul {SSC.Nume} este: {medieLaboratorSSC}.");
Console.WriteLine($"Media la cursul {SSC.Nume} este: {medieCursSSC}.");
