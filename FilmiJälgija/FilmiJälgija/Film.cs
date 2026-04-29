using System;
using System.Collections.Generic;
using System.Text;

namespace FilmiJälgija
{
    public class Film : Meedia, IHinnatav
    {
        public int KestusMinutites { get; set; }

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
            Console.WriteLine($"Film: {Pealkiri}");
            Console.WriteLine($"aasta: {Aasta}");
            Console.WriteLine($"staatus: {Staatus}");
            Console.WriteLine($"kestus: {KestusMinutites} min");
            Console.WriteLine($"hinnang: {Hinnang}");
            Console.WriteLine();
        }
    }
}
