using System;
using System.Data.SQLite;

namespace BackendNotesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitializeDatabase db = new InitializeDatabase();


            Curs Geogra = new Curs(3,true);
            Geogra.Distribuita1.Add(3);
            Geogra.Distribuita1.Add(7);
            Geogra.Distribuita2.Add(7);

            Curs Franceza = new Curs(1,true);
            Geogra.Distribuita1.Add(3);
            Geogra.Distribuita1.Add(7);
            Geogra.Distribuita2.Add(7);
/*
            foreach (float nota in Geogra.Distribuita1){
                Console.WriteLine(nota);
            }
*/

//Test CursRepository
            CursRepository cursRepo = new CursRepository();

            cursRepo.Save(Geogra);
            cursRepo.Save(Franceza);

            Geogra.AreDistribuita = false;
            cursRepo.Update(Geogra);
            cursRepo.Delete(Franceza);

//Test LaboratorRepository

            LaboratorRepository inLabRepo = new LaboratorRepository();
            Laborator lab1 = new Laborator(1,6.7f,50,5,50);
            Laborator lab2 = new Laborator(2,6.79f,30,8,70);

            inLabRepo.Save(lab1);
            inLabRepo.Save(lab2);

//Test MaterieRepository
            MaterieRepository inMatRepo = new MaterieRepository();
            Materie Mat1 = new Materie(1,"Cultura si civilizatie",3,34,Geogra,lab1);
            inMatRepo.Save(Mat1);

//
        }
    }


}

            //db.ReadDb();                           --nu functioneaza deocamdata


            // See https://aka.ms/new-console-template for more information

            // Source - https://stackoverflow.com/a/15292958
            // Posted by Max, modified by community. See post 'Timeline' for change history
            // Retrieved 2026-09-17, License - CC BY-SA 4.0


            // Source - https://stackoverflow.com/a/15292958
            // Posted by Max, modified by community. See post 'Timeline' for change history
            // Retrieved 2026-09-17, License - CC BY-SA 4.0
