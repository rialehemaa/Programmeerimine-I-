using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace _5OsaFunkTeor
{
    internal class Ulesanded
    {
        // 1
        public static void Kalorid()
        {
            Console.WriteLine("Kalorite kalkulaator");

            List<Toode> toidud = new List<Toode>()
            {
              new Toode("Õun", 52),
              new Toode("Kana", 239),
              new Toode("Riis", 130)
            };

            Console.Write("Sisesta nimi: ");
            string nimi = Console.ReadLine();

            Console.Write("Vanus: ");
            int vanus = int.Parse(Console.ReadLine());

            Console.Write("Sugu (M/N): ");
            string sugu = Console.ReadLine();

            Console.Write("Pikkus (cm): ");
            double pikkus = double.Parse(Console.ReadLine());

            Console.Write("Kaal (kg): ");
            double kaal = double.Parse(Console.ReadLine());

            Console.Write("Aktiivsustase (1.2–1.9): ");
            double aktiivsus = double.Parse(Console.ReadLine());

            Inimene inimene = new Inimene(nimi, vanus, sugu, pikkus, kaal, aktiivsus);

            double kalorid = inimene.ArvutaKalorid();

            Console.WriteLine($"\nPäevane kalorivajadus: {kalorid:F2} kcal\n");

            foreach (var t in toidud)
            {
                double grammid = (kalorid / t.Kalorid100g) * 100;
                Console.WriteLine($"{t.Nimi}: {grammid:F2} g");
            }
        }

        // 2
        public static void Maakonnad()
        {
            Dictionary<string, string> mk = new Dictionary<string, string>();

            mk.Add("Harjumaa", "Tallinn");
            mk.Add("Tartumaa", "Tartu");
            mk.Add("Pärnumaa", "Pärnu");

            // Maakond на Pealinn
            Console.Write("Sisesta maakond: ");
            string m = Console.ReadLine();

            if (mk.ContainsKey(m))
                Console.WriteLine("Pealinn: " + mk[m]);
            else
                Console.WriteLine("Ei leitud");

            // Linn на Maakond
            Console.Write("\nSisesta linn: ");
            string linn = Console.ReadLine();

            bool leitud = false;

            foreach (var paar in mk)
            {
                if (paar.Value.ToLower() == linn.ToLower())
                {
                    Console.WriteLine("Maakond: " + paar.Key);
                    leitud = true;
                }
            }

            if (!leitud)
                Console.WriteLine("Ei leitud");

            // добавление нового
            Console.Write("\nKas tahad lisada uue? (jah/ei): ");
            string vastus = Console.ReadLine();

            if (vastus.ToLower() == "jah")
            {
                Console.Write("Maakond: ");
                string uusM = Console.ReadLine();

                Console.Write("Pealinn: ");
                string uusL = Console.ReadLine();

                mk.Add(uusM, uusL);
                Console.WriteLine("Lisatud!");
            }

            // доп игра
            // 🔹 mäng
            Console.Write("\nMäng? (jah/ei): ");
            string mang = Console.ReadLine();

            if (mang.ToLower() == "jah")
            {
                Random rnd = new Random();
                int oiged = 0;
                int kokku = 3;

                List<string> keys = new List<string>(mk.Keys);

                for (int i = 0; i < kokku; i++)
                {
                    if (keys.Count == 0) break; // защита

                    string k = keys[rnd.Next(keys.Count)];
                    keys.Remove(k); // ❗ чтобы не повторялось

                    Console.Write($"Mis on {k} pealinn? ");
                    string v = Console.ReadLine();

                    if (mk[k].ToLower() == v.ToLower())
                    {
                        Console.WriteLine("Õige!");
                        oiged++;
                    }
                    else
                    {
                        Console.WriteLine($"Vale! Õige: {mk[k]}");
                    }
                }

                double protsent = (double)oiged / kokku * 100;

                Console.WriteLine($"Tulemus: {protsent:F2}%");
            }
        }


        // 3
        public static void Opilased()
        {
            Console.WriteLine("Õpilased:");

            List<Opilane> opilased = new List<Opilane>();

            // три ученика
            for (int i = 0; i < 3; i++)
            {
                Opilane o = new Opilane();

                Console.Write("Sisesta nimi: ");
                o.Nimi = Console.ReadLine();

                Console.Write("Mitu hinnet (3-5): ");
                int n = int.Parse(Console.ReadLine());

                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Hinne {j + 1}: ");
                    o.Hinded.Add(int.Parse(Console.ReadLine()));
                }

                opilased.Add(o);
                Console.WriteLine();
            }

            //вывод средних
            double max = 0;
            string parim = "";

            foreach (Opilane o in opilased)
            {
                double keskmine = o.Keskmine();

                Console.WriteLine($"{o.Nimi} keskmine: {Math.Round(keskmine, 2)}");

                if (keskmine > max)
                {
                    max = keskmine;
                    parim = o.Nimi;
                }
            }
            Console.WriteLine($"\nParim õpilane: {parim}");
        }

        // 4
        public static void Filmid()
        {
            Console.WriteLine("Filmid");

            List<Film> filmid = new List<Film>();

            // добавляем 5 фильмов вручную
            filmid.Add(new Film() { Pealkiri = "Titanic", Aasta = 1997, Zanr = "Romantika" });
            filmid.Add(new Film() { Pealkiri = "Avatar", Aasta = 2009, Zanr = "Ulme" });
            filmid.Add(new Film() { Pealkiri = "Matrix", Aasta = 1999, Zanr = "Ulme" });
            filmid.Add(new Film() { Pealkiri = "Joker", Aasta = 2019, Zanr = "Draama" });
            filmid.Add(new Film() { Pealkiri = "Frozen", Aasta = 2013, Zanr = "Animatsioon" });

            // ищем фильм по жанру
            Console.Write("Sisesta žanr: ");
            string otsitav = Console.ReadLine();

            Console.WriteLine("Leitud filmid:");

            foreach (Film f in filmid)
            {
                if (f.Zanr.ToLower() == otsitav.ToLower())
                {
                    Console.WriteLine($"{f.Pealkiri} ({f.Aasta})");
                }
            }

            // самий новий фильм
            Film uusim = filmid[0];

            foreach (Film f in filmid)
            {
                if (f.Aasta > uusim.Aasta)
                    uusim = f;
            }

            Console.WriteLine($"Uusim film: {uusim.Pealkiri} ({uusim.Aasta})");

            // сгрупировка
            Dictionary<string, List<Film>> grupid = new Dictionary<string, List<Film>>();

            foreach (Film f in filmid)
            {
                if (!grupid.ContainsKey(f.Zanr))
                {
                    grupid.Add(f.Zanr, new List<Film>());
                }

                grupid[f.Zanr].Add(f);
            }

            Console.WriteLine("\nFilmid žanrite kaupa:");

            foreach (var paar in grupid)
            {
                Console.WriteLine($"{paar.Key}:");

                foreach (Film f in paar.Value)
                {
                    Console.WriteLine($"- {f.Pealkiri}");
                }
            }
        }

        // 5
        public static void Statistika()
        {
            Console.Write("Sisesta arvud: ");
            string[] sis = Console.ReadLine().Split(' ');

            double[] arvud = new double[sis.Length];

            for (int i = 0; i < sis.Length; i++)
                arvud[i] = double.Parse(sis[i]);

            double max = arvud[0];
            double min = arvud[0];
            double sum = 0;

            foreach (double a in arvud)
            {
                if (a > max) max = a;
                if (a < min) min = a;
                sum += a;
            }

            double avg = sum / arvud.Length;

            int count = 0;

            foreach (double a in arvud)
            {
                if (a > avg)
                    count++;
            }

            Console.WriteLine("Summa: " + sum);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Keskmine: " + Math.Round(avg, 2));
            Console.WriteLine("Suuremad kui keskmine: " + count);
        }

        // 6
        public static void Lemmikloomad()
        {
            List<Lemmikloom> loomad = new List<Lemmikloom>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Liik: ");
                string liik = Console.ReadLine();

                Console.Write("Vanus: ");
                int vanus = int.Parse(Console.ReadLine());

                loomad.Add(new Lemmikloom { Nimi = nimi, Liik = liik, Vanus = vanus });
            }

            int sum = 0;
            Lemmikloom vanim = loomad[0];

            foreach (Lemmikloom l in loomad)
            {
                if (l.Liik.ToLower() == "kass")
                    Console.WriteLine("Kass: " + l.Nimi);

                sum += l.Vanus;

                if (l.Vanus > vanim.Vanus)
                    vanim = l;
            }

            Console.WriteLine("Keskmine vanus: " + Math.Round((double)sum / loomad.Count, 2));
            Console.WriteLine("Vanim loom: " + vanim.Nimi + " (" + vanim.Vanus + " a)");
        }

        // 7
        public static void Valuuta()
        {
            List<Valuuta> valuutad = new List<Valuuta>();

            valuutad.Add(new Valuuta { Nimetus = "USD", KurssEurSuhte = 1.1 });
            valuutad.Add(new Valuuta { Nimetus = "EUR", KurssEurSuhte = 1 });

            Console.Write("Summa: ");
            double s = double.Parse(Console.ReadLine());

            Console.Write("Valuuta: ");
            string v = Console.ReadLine();

            foreach (Valuuta val in valuutad)
            {
                if (val.Nimetus.ToLower() == v.ToLower())
                {
                    double eur = s * val.KurssEurSuhte;

                    Console.WriteLine("EUR: " + eur);

                    double tagasi = eur / val.KurssEurSuhte;
                    Console.WriteLine("Tagasi: " + tagasi);
                }
            }
        }
    }

}