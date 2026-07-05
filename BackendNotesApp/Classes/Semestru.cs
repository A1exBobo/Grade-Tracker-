/*
fiecare semestru are materii 
fiecare materie are un numar de credite 
are un curs , un laborator(si fiecare laborator are un proiect sau un seminar care valoreaza o parte din ponderea laboratorului)

*/

class Semestru
{
   public List<Materie>? Materii { get; set; }

   public float CalcMediaSemestru()
   {
        return 1000;
   }
}