
public class Materie
{
    public int Id{get;set;}
    public string Nume{get;set;}

    public int NumarCredite{get;set;}
    public float PondereCurs{get;set;}
    public Curs Curs;
    public Laborator Laborator;

    public Materie(int id,string nume,int numarCredite,float pondereCurs,Curs curs,Laborator laborator)
    {
        Id = id;
        Nume = nume;
        NumarCredite = numarCredite;
        PondereCurs = pondereCurs;
        Curs = curs;
        Laborator = laborator;
    }

}