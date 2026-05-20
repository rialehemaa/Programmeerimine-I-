using System;
using System.Collections.Generic;
using System.Text;

namespace Loomaaia
{
    public class Ahv : ILoom
    {
        public int BanaanideArvPaevas { get; private set; } // Omadused
        public int Vanus { get; private set; }               // Boonus
        public string Nimi { get; private set; }             // Boonus
        public string ToiduTuup => "Taimne";

        public Ahv(string nimi, int banaanideArv, int vanus = 2)
        {
            Nimi = nimi;

            // Banaanide arv ei saa olla negatiivne!
            if (banaanideArv < 0)
            {
                Console.WriteLine("Banaanide arv ei saa olla negatiivne! Määran vaikimisi 0.");
                BanaanideArvPaevas = 0;
            }
            else
            {
                BanaanideArvPaevas = banaanideArv;
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

            // Üks banaan kaalub keskmiselt 0.2 kg.
            // Toiduvajadus on lihtsalt: BanaanideArvPaevas * 0.2.
            return BanaanideArvPaevas * 0.2;
        }

        public void KuvaInfo()
        {
            if (Vanus < 1)
            {
                Console.WriteLine($"Ahv | Nimi: {Nimi} | Vanus: {Vanus} a | Toiduvajadus: {ArvutaToiduvajadus()} kg/paev (piimasegu) | Toit: {ToiduTuup}");
            }
            else
            {
                Console.WriteLine($"Ahv | Nimi: {Nimi} | Banaane: {BanaanideArvPaevas} tk | Vanus: {Vanus} a | Toiduvajadus: {ArvutaToiduvajadus()} kg/paev | Toit: {ToiduTuup}");
            }
        }
    }
}