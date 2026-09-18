using System.Data.Common;
using BackendNotesApp;
public class Curs
{
    public int Id {get;set;}
    public bool AreDistribuita {get;set;}

    public List<float> Distribuita1 {get; set;} = [];
    public List<float> Distribuita2 {get; set;} = [];

    public Curs(int id,bool areDistribuita)
    {
        Id = id;
        AreDistribuita = areDistribuita;
    }

}