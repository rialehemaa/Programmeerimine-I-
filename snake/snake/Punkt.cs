using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    // Määrab ära 4 võimalikku liikumissuunda
    public enum Suund
    {
        Üles,
        Alla,
        Vasakule,
        Paremale
    }

    public class Punkt
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Sümbol { get; set; } // '*' ussi jaoks, '@' toidu jaoks, '#' seina jaoks

        public Punkt(int x, int y, char sümbol)
        {
            X = x;
            Y = y;
            Sümbol = sümbol;
        }

        // Joonistab punkti konsooli õigesse kohta
        public void Joonista()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sümbol);
        }

        // Puhastab punkti asukoha (kustutab ekraanilt)
        public void Kustuta()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}