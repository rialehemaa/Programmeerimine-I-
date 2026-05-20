using System;
using System.Collections.Generic;
using System.Text;

namespace Loomaaia
{
    public class Elevant : ILoom
    {
        public double Kaal { get; private set; }         // Omadused
        public double KihvadePikkus { get; private set; } // Omadused
        public int Vanus { get; private set; }            // Boonus
        public string Nimi { get; private set; }          // Boonus
        public string ToiduTuup => "Taimne";

        public Elevant(string nimi, double kaal, double kihvadePikkus, int vanus = 5)
        {
            Nimi = nimi;

            // Kui kaal on alla 0, määra vaikimisi kaaluks 2000 kg.
            if (kaal < 0)
            {
                Console.WriteLine("Vigane kaal! Määran vaikimisi kaaluks 2000 kg.");
                Kaal = 2000;
            }
            else
            {
                Kaal = kaal;
            }

            KihvadePikkus = kihvadePikkus;
            Vanus = vanus;
        }

        public double ArvutaToiduvajadus()
        {
            // Vanusekontroll: loompõrsas sööb piimasegu
            if (Vanus < 1)
            {
                return 0.5;
            }

            return (Kaal * 0.10) + (KihvadePikkus * 20); // (Valem: (Kaal * 0.10) + (KihvadePikkus * 20))
        }

        public void KuvaInfo()
        {
            if (Vanus < 1)
            {
                Console.WriteLine($"Elevant | Nimi: {Nimi} | Kaal: {Kaal} kg | Vanus: {Vanus} a | Toiduvajadus: {ArvutaToiduvajadus()} kg/paev (piimasegu) | Toit: {ToiduTuup}");
            }
            else
            {
                Console.WriteLine($"Elevant | Nimi: {Nimi} | Kaal: {Kaal} kg | Kihvad: {KihvadePikkus} m | Vanus: {Vanus} a | Toiduvajadus: {ArvutaToiduvajadus()} kg/paev | Toit: {ToiduTuup}");
            }
        }
    }
}