using System;
using System.Collections.Generic;
using System.IO;

namespace naidis_iktpv25
{
    public static class Osa4_funktsioonid
    {
        public static void Menuu()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("\nOSA 4");
                Console.WriteLine("1 - Kirjuta faili");
                Console.WriteLine("2 - Loe fail");
                Console.WriteLine("3 - Loe fail Listi");
                Console.WriteLine("4 - Muuda Listi");
                Console.WriteLine("5 - Otsi kuud");
                Console.WriteLine("6 - Salvesta List faili");
                Console.WriteLine("0 - Tagasi");
                Console.Write("Valik: ");

                string v = Console.ReadLine();

                switch (v)
                {
                    case "1": KirjutaFaili(); break;
                    case "2": LoeFail(); break;
                    case "3": LoeListi(); break;
                    case "4": MuudaListi(); break;
                    case "5": OtsiKuu(); break;
                    case "6": SalvestaFail(); break;
                    case "0": run = false; break;
                }
            }
        }

        static void KirjutaFaili()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt"); //@"..\..\..\Kuud.txt"
                StreamWriter text = new StreamWriter(path, true); // true = lisa lõppu
                Console.WriteLine("Sisesta mingi tekst: ");
                string lause = Console.ReadLine();
                text.WriteLine(lause);
                text.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
            }
        }

        static void LoeFail()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");

                StreamReader text = new StreamReader(path);
                string laused = text.ReadToEnd();
                text.Close();

                Console.WriteLine(laused);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
            }
        }

        private static List<string> kuude_list = new List<string>();

        static void LoeListi()
        {
            List<string> kuude_list = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");
                foreach (string rida in File.ReadAllLines(path))
                {
                    kuude_list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }
        }

        static void MuudaListi()
        {
            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }

            kuude_list.Remove("Juuni");

            if (kuude_list.Count > 0)
                kuude_list[0] = "Veeel kuuu";

            Console.WriteLine("--------------Kustutasime juuni-----------");

            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }
        }


        static void OtsiKuu()
        {
            Console.WriteLine("Sisesta kuu nimi, mida otsida:");
            string otsitav = Console.ReadLine();

            if (kuude_list.Contains(otsitav))
                Console.WriteLine("Kuu " + otsitav + " on olemas.");
            else
                Console.WriteLine("Sellist kuud pole.");
        }

        static void SalvestaFail()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");

            File.WriteAllLines(path, kuude_list);

            Console.WriteLine("Andmed on salvestatud.");
        }
    }
}
