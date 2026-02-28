using System;
using System.Collections.Generic;
using System.Text;

namespace naidis_iktpv25
{
    public static class Osa2_funktsioonid
    {
        // MENÜÜ 
        public static void Menuu()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("\nOSA 2");
                Console.WriteLine("1 - Juku ja kino");
                Console.WriteLine("2 - Pinginaabrid");
                Console.WriteLine("3 - Ruum ja remont");
                Console.WriteLine("4 - Alghind (30% soodustus)");
                Console.WriteLine("5 - Temperatuur");
                Console.WriteLine("6 - Pikkus");
                Console.WriteLine("7 - Pikkus ja sugu");
                Console.WriteLine("8 - Pood");
                Console.WriteLine("0 - Tagasi");
                Console.Write("Valik: ");

                string v = Console.ReadLine();

                switch (v)
                {
                    case "1": JukuKino(); break;
                    case "2": Pinginaabrid(); break;
                    case "3": RuumRemont(); break;
                    case "4": Alghind(); break;
                    case "5": Temperatuur(); break;
                    case "6": Pikkus(); break;
                    case "7": PikkusJaSugu(); break;
                    case "8": Pood(); break;
                    case "0": run = false; break;
                    default: Console.WriteLine("Vale valik!"); break;
                }
            }
        }

        // 1. JUKU JA KINO 
        static void JukuKino()
        {
            Console.Write("Sisesta nimi: ");
            string nimi = Console.ReadLine();

            if (nimi.ToLower() == "juku")
            {
                Console.Write("Sisesta vanus: ");
                int vanus = int.Parse(Console.ReadLine());

                if (vanus < 0 || vanus > 100)
                    Console.WriteLine("Viga andmetega");
                else if (vanus < 6)
                    Console.WriteLine("Tasuta pilet");
                else if (vanus <= 14)
                    Console.WriteLine("Lastepilet");
                else if (vanus <= 65)
                    Console.WriteLine("Täispilet");
                else
                    Console.WriteLine("Sooduspilet");
            }
            else
            {
                Console.WriteLine("Ei lähe kinno");
            }
        }

        // 2. PINGINAABRID 
        static void Pinginaabrid()
        {
            Console.Write("Esimene nimi: ");
            string n1 = Console.ReadLine();
            Console.Write("Teine nimi: ");
            string n2 = Console.ReadLine();

            Console.WriteLine($"{n1} ja {n2} on täna pinginaabrid");
        }

        // 3. RUUM JA REMONT
        static void RuumRemont()
        {
            Console.Write("Seina pikkus: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Seina laius: ");
            double b = double.Parse(Console.ReadLine());

            double pindala = a * b;
            Console.WriteLine($"Põranda pindala: {pindala} m2");

            Console.Write("Kas soovid remonti? (jah/ei): ");
            if (Console.ReadLine().ToLower() == "jah")
            {
                Console.Write("Hind ruutmeetri kohta: ");
                double hind = double.Parse(Console.ReadLine());
                Console.WriteLine($"Remondi hind: {hind * pindala} EURO");
            }
        }

        // 4. ALGHIND (30%) 
        static void Alghind()
        {
            Console.Write("Sisesta soodushind: ");
            double soodus = double.Parse(Console.ReadLine());

            double alg = soodus / 0.7;
            Console.WriteLine($"Alghind: {alg:F2} EURO");
        }

        // 5. TEMPERATUUR
        static void Temperatuur()
        {
            Console.Write("Sisesta temperatuur: ");
            int t = int.Parse(Console.ReadLine());

            if (t > 18)
                Console.WriteLine("Soe (soovitatav toasoojus)");
            else
                Console.WriteLine("Jahe");
        }

        // 6. PIKKUS
        static void Pikkus()
        {
            Console.Write("Sisesta pikkus (cm): ");
            int p = int.Parse(Console.ReadLine());

            if (p < 160)
                Console.WriteLine("Lühike");
            else if (p < 180)
                Console.WriteLine("Keskmine");
            else
                Console.WriteLine("Pikk");
        }

        // 7. PIKKUS JA SUGU
        static void PikkusJaSugu()
        {
            Console.Write("Sisesta sugu (m/n): ");
            string sugu = Console.ReadLine();

            Console.Write("Sisesta pikkus (cm): ");
            int p = int.Parse(Console.ReadLine());

            if (sugu == "m")
            {
                if (p < 170) Console.WriteLine("Lühike mees");
                else if (p < 185) Console.WriteLine("Keskmine mees");
                else Console.WriteLine("Pikk mees");
            }
            else
            {
                if (p < 160) Console.WriteLine("Lühike naine");
                else if (p < 175) Console.WriteLine("Keskmine naine");
                else Console.WriteLine("Pikk naine");
            }
        }

        // 8. POOD
        static void Pood()
        {
            double summa = 0;

            Console.Write("Kas ostad piima? (jah/ei): ");
            if (Console.ReadLine() == "jah") summa += 1.5;

            Console.Write("Kas ostad saia? (jah/ei): ");
            if (Console.ReadLine() == "jah") summa += 1.0;

            Console.Write("Kas ostad leiba? (jah/ei): ");
            if (Console.ReadLine() == "jah") summa += 1.2;

            Console.WriteLine($"Kokku maksab: {summa} EURO");
        }
    }
}