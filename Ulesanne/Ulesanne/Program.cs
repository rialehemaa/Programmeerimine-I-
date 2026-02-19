
using System;
using System.Collections.Generic;

namespace Ülesanned
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Ülesanne 1: Juhuslike arvude ruudud");
            ArvuTöötlus töötlus = new ArvuTöötlus();
            int[] ruudud = töötlus.GenereeriRuudud(1, 20);

            Console.WriteLine("\n Ülesanne 2: Viie arvu analüüs");
            double[] sisendArvud = Tööriistad.Tekstist_arvud();
            var (summa, keskmine, korrutis) = Tööriistad.AnalüüsiArve(sisendArvud);
            Console.WriteLine($"Summa:    {summa}");
            Console.WriteLine($"Keskmine: {keskmine:F2}");
            Console.WriteLine($"Korrutis: {korrutis}");

            Console.WriteLine("\n Ülesanne 3: Nimed ja vanused ");
            List<Inimene> inimesed = new List<Inimene>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Sisesta {i + 1}. inimese nimi: ");
                string nimi = Console.ReadLine();
                Console.Write($"Sisesta {nimi} vanus: ");
                int vanus = int.Parse(Console.ReadLine());
                inimesed.Add(new Inimene { Nimi = nimi, Vanus = vanus });
            }
            var (vanuseSumma, vanusKeskmine, vanim, noorim) = Tööriistad.Statistika(inimesed);
            Console.WriteLine($"Vanuste summa:    {vanuseSumma}");
            Console.WriteLine($"Vanuste keskmine: {vanusKeskmine:F1}");
            Console.WriteLine($"Vanim inimene:    {vanim.Nimi} ({vanim.Vanus} aastat)");
            Console.WriteLine($"Noorim inimene:   {noorim.Nimi} ({noorim.Vanus} aastat)");

            Console.WriteLine("\n Ülesanne 4: Osta elevant ära! ");
            List<string> sisestused = Tööriistad.KuniMärksõnani("osta", "Osta elevant ära!");
            Console.WriteLine("\nKõik sisestused:");
            foreach (var sisestus in sisestused)
            {
                Console.WriteLine($"  - {sisestus}");
            }

            Console.WriteLine("\n Ülesanne 5: Arvamise mäng ");
            string jätka = "jah";
            while (jätka == "jah")
            {
                Tööriistad.ArvaArv();
                Console.Write("Kas soovid uuesti mängida? (jah/ei): ");
                jätka = Console.ReadLine().ToLower().Trim();
            }

            Console.WriteLine("\n Ülesanne 6: Suurim neliarvuline arv ");
            int[] neljaNumbrit = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Sisesta {i + 1}. number (0-9): ");
                if (int.TryParse(Console.ReadLine(), out int arv) && arv >= 0 && arv <= 9)
                {
                    neljaNumbrit[i] = arv;
                }
                else
                {
                    Console.WriteLine("Vigane sisestus! Sisesta number vahemikus 0-9.");
                    i--;
                }
            }
            int suurimArv = Tööriistad.SuurimNeliarv(neljaNumbrit);
            Console.WriteLine($"Suurim võimalik nelikohaline arv: {suurimArv}");

            Console.WriteLine("\n Ülesanne 7: Korrutustabel");
            Console.Write("Sisesta ridade arv: ");
            int ridu = int.Parse(Console.ReadLine());
            Console.Write("Sisesta veergude arv: ");
            int veerge = int.Parse(Console.ReadLine());
            int[,] tabel = Tööriistad.GenereeriKorrutustabel(ridu, veerge);
            Console.Write("\nSisesta rida mille tulemust soovid (nt 7): ");
            int otsinguRida = int.Parse(Console.ReadLine());
            Console.Write("Sisesta veerg mille tulemust soovid (nt 8): ");
            int otsinguVeerg = int.Parse(Console.ReadLine());
            if (otsinguRida >= 1 && otsinguRida <= ridu && otsinguVeerg >= 1 && otsinguVeerg <= veerge)
            {
                Console.WriteLine($"{otsinguRida} x {otsinguVeerg} = {tabel[otsinguRida - 1, otsinguVeerg - 1]}");
            }
            else
            {
                Console.WriteLine("Vigane otsing, arv on väljaspool tabeli piire.");
            }
        }
    }

    class ArvuTöötlus
    {
        public int[] GenereeriRuudud(int min, int max)
        {
            Random juhus = new Random();
            int N = juhus.Next(min, max + 1);
            int M = juhus.Next(min, max + 1);
            int algus = Math.Min(N, M);
            int lõpp = Math.Max(N, M);

            Console.WriteLine($"Genereeriti arvud N={N} ja M={M}, vahemik [{algus}, {lõpp}]");

            int pikkus = lõpp - algus + 1;
            int[] ruudud = new int[pikkus];

            for (int i = 0; i < pikkus; i++)
            {
                int praeguneArv = algus + i;
                ruudud[i] = praeguneArv * praeguneArv;
                Console.WriteLine($"{praeguneArv} → {ruudud[i]}");
            }

            return ruudud;
        }
    }

    class Inimene
    {
        public string Nimi { get; set; }
        public int Vanus { get; set; }
    }

    static class Tööriistad
    {
        public static double[] Tekstist_arvud()
        {
            Console.Write("Mitu arvu soovid sisestada? ");
            int kogus = int.Parse(Console.ReadLine());
            double[] arvud = new double[kogus];
            for (int i = 0; i < kogus; i++)
            {
                Console.Write($"  Sisesta {i + 1}. arv: ");
                arvud[i] = double.Parse(Console.ReadLine());
            }
            return arvud;
        }

        public static (double, double, double) AnalüüsiArve(double[] arvud)
        {
            double summa = 0;
            double korrutis = 1;
            foreach (var arv in arvud)
            {
                summa += arv;
                korrutis *= arv;
            }
            double keskmine = summa / arvud.Length;
            return (summa, keskmine, korrutis);
        }

        public static (int, double, Inimene, Inimene) Statistika(List<Inimene> inimesed)
        {
            int vanuseSumma = 0;
            Inimene vanim = inimesed[0];
            Inimene noorim = inimesed[0];
            foreach (var inimene in inimesed)
            {
                vanuseSumma += inimene.Vanus;
                if (inimene.Vanus > vanim.Vanus)
                    vanim = inimene;
                if (inimene.Vanus < noorim.Vanus)
                    noorim = inimene;
            }
            double vanusKeskmine = (double)vanuseSumma / inimesed.Count;
            return (vanuseSumma, vanusKeskmine, vanim, noorim);
        }

        public static List<string> KuniMärksõnani(string märksõna, string fraas)
        {
            List<string> sisestused = new List<string>();
            string praeguneS = "";
            while (praeguneS != märksõna)
            {
                Console.WriteLine(fraas);
                Console.Write("Sinu sisestus: ");
                praeguneS = Console.ReadLine();
                sisestused.Add(praeguneS);
            }
            return sisestused;
        }

        public static void ArvaArv()
        {
            Random juhus = new Random();
            int saladuslik = juhus.Next(1, 101);
            int katseid = 5;
            bool õigeArvamine = false;

            Console.WriteLine("Ma mõtlen arvu vahemikus 1-100. Sul on 5 katset.");

            for (int i = 1; i <= katseid; i++)
            {
                Console.Write($"Katse {i}/{katseid}: ");
                int arva = int.Parse(Console.ReadLine());
                if (arva == saladuslik)
                {
                    Console.WriteLine($"Õige! Arv oligi {saladuslik}! Arvasid {i}. katsega!");
                    õigeArvamine = true;
                    break;
                }
                else if (arva > saladuslik)
                {
                    Console.WriteLine("Liiga suur! Proovi väiksemaga.");
                }
                else
                {
                    Console.WriteLine("Liiga väike! Proovi suuremaga.");
                }
            }

            if (!õigeArvamine)
            {
                Console.WriteLine($"Katsed otsas! Saladuslik arv oli {saladuslik}.");
            }
        }

        public static int SuurimNeliarv(int[] arvud)
        {
            foreach (var arv in arvud)
            {
                if (arv < 0 || arv > 9)
                {
                    Console.WriteLine($"Viga: arv {arv} ei ole vahemikus 0-9!");
                    return -1;
                }
            }
            int[] sorteeritud = (int[])arvud.Clone();
            Array.Sort(sorteeritud);
            Array.Reverse(sorteeritud);
            int tulemus = sorteeritud[0] * 1000
                        + sorteeritud[1] * 100
                        + sorteeritud[2] * 10
                        + sorteeritud[3];
            return tulemus;
        }

        public static int[,] GenereeriKorrutustabel(int ridadeArv, int veergudeArv)
        {
            int[,] tabel = new int[ridadeArv, veergudeArv];
            for (int rida = 0; rida < ridadeArv; rida++)
            {
                for (int veerg = 0; veerg < veergudeArv; veerg++)
                {
                    tabel[rida, veerg] = (rida + 1) * (veerg + 1);
                }
            }
            for (int rida = 0; rida < ridadeArv; rida++)
            {
                for (int veerg = 0; veerg < veergudeArv; veerg++)
                {
                    Console.Write(tabel[rida, veerg].ToString().PadLeft(5));
                }
                Console.WriteLine();
            }
            return tabel;
        }
    }
}
