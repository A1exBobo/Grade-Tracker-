public class Semestru
{
   int Id;
   public List<Materie> Materii { get; set; } = [];

   public Semestru(int id,List<Materie> materii)
   {
      Id = id;
      Materii = materii;
   }
}