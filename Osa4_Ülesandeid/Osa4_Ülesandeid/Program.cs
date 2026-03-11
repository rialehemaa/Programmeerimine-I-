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
                Console.WriteLine("6 - Itaalia restorani menüü");
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
                    case "6": ItaaliaMenuu();break;
                    case "0": run = false; break;
                }
            }
        }

        //1
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

        //2
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

        //3
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

        //4
        static void OtsiKoostisosa()
        {
            Console.Write("Sisesta koostisosa: ");
            string otsitav = Console.ReadLine();

            if (koostisosad.Contains(otsitav))
                Console.WriteLine("Koostisosa on olemas!");
            else
                Console.WriteLine("Seda koostisosa retseptis ei ole.");
        }

        //5
        static void SalvestaListFaili()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");

            File.WriteAllLines(path, koostisosad);

            Console.WriteLine("Uus retsept on edukalt faili salvestatud!");
        }

        //6
        static void ItaaliaMenuu()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Menuu.txt");
                Console.WriteLine(path); // для проверки пути

                List<Tuple<string, string, double>> menyyList = new List<Tuple<string, string, double>>();

                string[] read = File.ReadAllLines(path);

                foreach (string rida in read)
                {
                    if (string.IsNullOrWhiteSpace(rida))
                        continue;

                    string[] osad = rida.Split(';');

                    if (osad.Length < 3)
                        continue;

                    string roaNimi = osad[0];
                    string koostisosad = osad[1];
                    double hind = double.Parse(osad[2]);

                    menyyList.Add(Tuple.Create(roaNimi, koostisosad, hind));
                }

                Console.WriteLine("\nITAALIA RESTORANI MENÜÜ\n");

                foreach (var roog in menyyList)
                {
                    Console.WriteLine($"{roog.Item1.PadRight(30)} {roog.Item3} €");
                    Console.WriteLine($"   {roog.Item2}");
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga faili lugemisel!");
            }
        }
    }
}