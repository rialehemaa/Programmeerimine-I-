using System;
using System.Collections.Generic;
using System.Text;

namespace FilmiJälgija
{
    public class Multikas : Meedia, IHinnatav
    {
        public string Sihtrühm { get; set; }

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
            Console.WriteLine($"Multikas: {Pealkiri}");
            Console.WriteLine($"sihtrühm: {Sihtrühm}");
            Console.WriteLine($"hinnang: {Hinnang}");
            Console.WriteLine();
        }
    }
}