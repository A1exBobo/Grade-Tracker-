using System;
using System.Collections.Generic;
using System.Linq;

public class Curs
{
    public bool areDistribuita { get; set; }

    public Tuple<float, float>[]? NoteDistribuite { get; set; }

    public float[]? NoteCurs { get; set; }



    public float CalculMedieCurs()
    {
        if (NoteCurs == null || NoteCurs.Length == 0)
            return 0f;
        
        float sum = 0;
        foreach (float nota in NoteCurs)
            sum += nota;
        
        return sum / NoteCurs.Length;
    }

    public float CalculMedieCurs(bool areDistribuita)
    {
        if (areDistribuita)
        {
            if (NoteDistribuite == null || NoteDistribuite.Length == 0)
                return 0f;

            var mediaDistribuita = new List<float>();
            foreach (var nota in NoteDistribuite)
            {
                mediaDistribuita.Add((nota.Item1 + nota.Item2) / 2f);
            } 
            return mediaDistribuita.Max();
        }
        else
        {
            return CalculMedieCurs();
        }
    }
}