using System;
using System.Collections.Generic;
using System.Text;

namespace FilmiJälgija
{
    public class Dokumentaalfilm : Meedia, IHinnatav
    {
        public string Teema { get; set; }

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
            Console.WriteLine($"Dokumentaalfilm: {Pealkiri}");
            Console.WriteLine($"teema: {Teema}");
            Console.WriteLine($"hinnang: {Hinnang}");
            Console.WriteLine();
        }
    }
}