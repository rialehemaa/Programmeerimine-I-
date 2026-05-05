using System;
using System.Collections.Generic;
using System.Text;

namespace FilmiJälgija
{
    public class Telesaade : Meedia, IHinnatav
    {
        public string Saatejuht { get; set; }
        public int EpisoodideArv { get; set; }

        public void LisaHinnang(double hinnang)
        {
            if (hinnang < 0 || hinnang > 5)
            {
                Console.WriteLine("Vigane hinnang!");
                return;
            }

            Hinnang = hinnang;
        }

        public override void KuvaInfo()
        {
            Console.WriteLine($"Telesaade: {Pealkiri}");
            Console.WriteLine($"saatejuht: {Saatejuht}");
            Console.WriteLine($"hinnang: {Hinnang}");
            Console.WriteLine();
        }
    }
}