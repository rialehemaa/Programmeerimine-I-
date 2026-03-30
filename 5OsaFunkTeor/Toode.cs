using System;
using System.Collections.Generic;
using System.Text;

namespace _5OsaFunkTeor
{
    public class Toode
    {
        public string Nimi { get; set; }
        public double Kalorid100g { get; set; }

        public Toode() { }

        public Toode(string nimi, double kalorid100g)
        {
            Nimi = nimi;
            Kalorid100g = kalorid100g;
        }
    }
}

