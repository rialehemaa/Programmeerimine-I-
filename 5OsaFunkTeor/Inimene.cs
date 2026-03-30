using System;
using System.Collections.Generic;
using System.Text;

namespace _5OsaFunkTeor
{
    public class Inimene
    {
        public string Nimi { get; set; }
        public int Vanus { get; set; }
        public string Sugu { get; set; } // "M" või "N"
        public double Pikkus { get; set; } // cm
        public double Kaal { get; set; }   // kg
        public double Aktiivsustase { get; set; }

        public Inimene(string nimi, int vanus, string sugu, double pikkus, double kaal, double aktiivsustase)
        {
            Nimi = nimi;
            Vanus = vanus;
            Sugu = sugu;
            Pikkus = pikkus;
            Kaal = kaal;
            Aktiivsustase = aktiivsustase;
        }

        public Inimene()
        {
        }

        public double ArvutaKalorid()
        {
            double bmr;

            if (Sugu.ToLower() == "m")
            {
                bmr = 10 * Kaal + 6.25 * Pikkus - 5 * Vanus + 5;
            }
            else
            {
                bmr = 10 * Kaal + 6.25 * Pikkus - 5 * Vanus - 161;
            }

            return bmr * Aktiivsustase;
        }
    }
}
