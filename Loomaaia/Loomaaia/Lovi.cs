using System;
using System.Collections.Generic;
using System.Text;

namespace Loomaaia
{
    public class Lovi : ILoom
    {
        public double Kaal { get; private set; } // Omadus
        public int Vanus { get; private set; }   // Boonus
        public string Nimi { get; private set; } // Boonus
        public string ToiduTuup => "Liha";

        public Lovi(string nimi, double kaal, int vanus = 2)
        {
            Nimi = nimi;

            // Valideerimine: Lõvi kaal peab olema suurem kui 0 ja väiksem kui 400 kg
            if (kaal > 0 && kaal < 400)
            {
                Kaal = kaal;
            }
            else
            {
                // Kui sisestatakse vigane kaal, anna veateade ja määra kaaluks 150 kg.
                Console.WriteLine("Vigane kaal! Määran vaikimisi kaaluks 150 kg.");
                Kaal = 150;
            }

            Vanus = vanus;
        }

        public double ArvutaToiduvajadus()
        {
            // Vanusekontroll: loompõrsas sööb piimasegu
            if (Vanus < 1)
            {
                return 0.5;
            }

            return Kaal * 0.05;
        }

        public void KuvaInfo()
        {
            if (Vanus < 1)
            {
                Console.WriteLine($"Lovi | Nimi: {Nimi} | Kaal: {Kaal} kg | Vanus: {Vanus} a | Toiduvajadus: {ArvutaToiduvajadus()} kg/paev (piimasegu) | Toit: {ToiduTuup}");
            }
            else
            {
                Console.WriteLine($"Lovi | Nimi: {Nimi} | Kaal: {Kaal} kg | Vanus: {Vanus} a | Toiduvajadus: {ArvutaToiduvajadus()} kg/paev | Toit: {ToiduTuup}");
            }
        }
    }
}