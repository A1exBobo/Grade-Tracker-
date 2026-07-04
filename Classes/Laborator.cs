class Laborator
{
    public float[]? NoteLaborator { get; set; }

    public float notaProiect { get; set; }
    public int PondereProiect { get; set; }

    public float notaSeminar { get; set; }
    public int PondereSeminar { get; set; }


    private float CalculMedieLaborator()
    {
        if (NoteLaborator == null || NoteLaborator.Length == 0)
            return 0f;
        
        float sum = 0;
        foreach (float nota in NoteLaborator)
            sum += nota;
        
        return sum / NoteLaborator.Length;
    }

    public float CalculMedieLaborator(bool hasProj)
    {

        if (!VerificaPondere())
        {
            return 0f;
        }
        
        if (NoteLaborator == null || NoteLaborator.Length == 0)
            return 0f;

        if (hasProj)
        {
            float sum = 0;
            foreach (float nota in NoteLaborator) sum += nota;

            return (sum / NoteLaborator.Length) * (1 - PondereProiect / 100f) + notaProiect * (PondereProiect / 100f); 
            
        }
        else
        {
            CalculMedieLaborator();
        }
        Console.WriteLine("CalculMedieLaborator(bool hasProj) called with hasProj = " + hasProj);
        return 222;
    }

    public float CalculMedieLaborator(bool hasProj,bool hasSem)
    {
        if (!VerificaPondere())
        {
            return 0f;
        }

         if (NoteLaborator == null || NoteLaborator.Length == 0)
            return 0f;

        if (hasProj && hasSem)
        {
           float sum = 0;
            foreach (float nota in NoteLaborator) sum += nota;

            return sum / NoteLaborator.Length * (1 - PondereProiect / 100f) + notaProiect * (PondereProiect / 100f) + notaSeminar * (PondereSeminar / 100f);
        }
        else
        {
            return CalculMedieLaborator();
        }
    }

    private bool VerificaPondere()
    {
        if(PondereProiect + PondereSeminar > 100)
        {
            Console.WriteLine("Ponderea proiectului si seminarului depaseste 100%");
            return false;
        }

       if(PondereProiect + PondereSeminar == 100)
        {
            Console.WriteLine("Ponderea proiectului si seminarului este 100%. Notele de laborattor nu vor fi luate in considerare");
            return false;
        }

        return true;
    }


}