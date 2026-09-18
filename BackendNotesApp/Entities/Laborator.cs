using BackendNotesApp;
public class Laborator
{
    public int Id{get;set;}
    public List<float>? NoteLaborator{get;set;}

    public float NotaProiect{get;set;}
    public int PondereProiect{get;set;}
    public float NotaSeminar{get;set;}
    public int PondereSeminar{get;set;}

    public Laborator(int id,float notaProiect,int pondereProiect, float notaSeminar,int pondereSeminar)
    {
        Id = id;
        NotaProiect = notaProiect;
        PondereProiect = pondereProiect ;
        NotaSeminar = notaSeminar;
        PondereSeminar = pondereSeminar;
    }

}