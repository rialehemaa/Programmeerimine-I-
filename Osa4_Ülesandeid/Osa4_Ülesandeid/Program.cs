using System;
using System.Collections.Generic;
using System.IO;

namespace Osa4_Ülesandeid
{
    internal class Program
    {
        static List<string> koostisosad = new List<string>();

        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("\nOSA 4");
                Console.WriteLine("1 - Lemmiktoidu salvestamine faili");
                Console.WriteLine("2 - Kogu menüü kuvamine");
                Console.WriteLine("3 - Koostisosade muutmine listis");
                Console.WriteLine("4 - Külmkapi kontroll");
                Console.WriteLine("5 - Uuendatud nimekirja salvestamine");
                Console.WriteLine("0 - Välju");
                Console.Write("Valik: ");

                string v = Console.ReadLine();

                switch (v)
                {
                    case "1": SalvestaToit(); break;
                    case "2": LoeMenuu(); break;
                    case "3": MuudaKoostisosad(); break;
                    case "4": OtsiKoostisosa(); break;
                    case "5": SalvestaListFaili(); break;
                    case "0": run = false; break;
                }
            }
        }

        // ÜLESANNE 1
        static void SalvestaToit()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");

                StreamWriter text = new StreamWriter(path, true);

                Console.Write("Sisesta Itaalia toidu nimi: ");
                string toit = Console.ReadLine();

                text.WriteLine(toit);

                text.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga faili kirjutamisel.");
            }
        }

        // ÜLESANNE 2
        static void LoeMenuu()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");

                StreamReader text = new StreamReader(path);

                string laused = text.ReadToEnd();

                text.Close();

                Console.WriteLine("\nRETSEPTID");
                Console.WriteLine(laused);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga.");
            }
        }

        // ÜLESANNE 3
        static void MuudaKoostisosad()
        {
            koostisosad.Clear();

            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");

                foreach (string rida in File.ReadAllLines(path))
                {
                    koostisosad.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga faili lugemisel.");
            }

            if (koostisosad.Count > 0)
                koostisosad[0] = "Kvaliteetne oliiviõli";

            koostisosad.Remove("Ketšup");

            Console.WriteLine("\nUUS LIST");

            foreach (string k in koostisosad)
            {
                Console.WriteLine(k);
            }
        }

        // ÜLESANNE 4
        static void OtsiKoostisosa()
        {
            Console.Write("Sisesta koostisosa: ");
            string otsitav = Console.ReadLine();

            if (koostisosad.Contains(otsitav))
                Console.WriteLine("Koostisosa on olemas!");
            else
                Console.WriteLine("Seda koostisosa retseptis ei ole.");
        }

        // ÜLESANNE 5
        static void SalvestaListFaili()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");

            File.WriteAllLines(path, koostisosad);

            Console.WriteLine("Uus retsept on edukalt faili salvestatud!");
        }
    }
}