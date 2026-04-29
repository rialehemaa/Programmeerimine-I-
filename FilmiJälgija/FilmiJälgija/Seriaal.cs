using System;
using System.Collections.Generic;
using System.Text;

namespace FilmiJälgija
{
    public class Seriaal : Meedia, IHinnatav
    {
        public int HooaegadeArv { get; set; }
        public int VaadatudEpisoodid { get; set; }

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
            Console.WriteLine($"Seriaal: {Pealkiri}");
            Console.WriteLine($"aasta: {Aasta}");
            Console.WriteLine($"staatus: {Staatus}");
            Console.WriteLine($"hooajad: {HooaegadeArv}");
            Console.WriteLine($"hinnang: {Hinnang}");
            Console.WriteLine();
        }
    }
}
