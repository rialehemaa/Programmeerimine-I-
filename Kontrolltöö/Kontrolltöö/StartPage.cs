using Kontrolltöö;
using System;

namespace Kontrolltoo
{
    class StartPage

    {
        static void Main(string[] args)
        {
            bool jooksutab = true;

            while (jooksutab)
            {
                Console.WriteLine("MENÜÜ");
                Console.WriteLine("1 - Kütuse kalkulaator");
                Console.WriteLine("2 - Isikukoodi analüüs");
                Console.WriteLine("3 - Täringumäng");
                Console.WriteLine("4 - Palgaarvestus");
                Console.WriteLine("0 - Välju");
                Console.Write("Vali tegevus: ");

                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        Alamfunktsioonid.KytuseKalkulaator();
                        break;

                    case "2":
                        Alamfunktsioonid.Isikukood();
                        break;

                    case "3":
                        Alamfunktsioonid.TaringuMang();
                        break;

                    case "4":
                        Console.Write("Sisesta brutopalk: ");
                        double bruto = double.Parse(Console.ReadLine());

                        var tulemus = Alamfunktsioonid.ArvutaPalk(bruto);

                        Console.WriteLine($"Maksuvaba tulu: {tulemus.Item1:F2} EUR");
                        Console.WriteLine($"Netopalk: {tulemus.Item2:F2} EUR");
                        break;

                    case "0":
                        jooksutab = false;
                        break;

                    default:
                        Console.WriteLine("Vale valik!");
                        break;
                }
            }
        }
    }
}