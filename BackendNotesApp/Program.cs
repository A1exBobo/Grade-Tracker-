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
            CursRepository cursRepo = new CursRepository();

            cursRepo.Save(Geogra);
            cursRepo.Save(Franceza);




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
