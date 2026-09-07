
internal class Materie
{
    public int Id{get;set;}
    public string? Nume{get;set;}

    public int NumarCredite{get;set;}
    public float PondereCurs{get;set;}
    public Curs Curs;
    public Laborator Laborator;

}