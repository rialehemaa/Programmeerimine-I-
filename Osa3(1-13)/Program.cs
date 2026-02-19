using System;
using System.Collections.Generic;

namespace Osa3_1_13_
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

            Console.WriteLine("\n Ülesanne 8: Õpilastega mängimine");

            string[] õpilased = { "Anna", "Bert", "Cärol", "Daan", "Eliis", "Fred", "Grete", "Hanna", "Ivo", "Jaak" };

            õpilased[2] = "Kati";
            õpilased[5] = "Mati";

            Console.WriteLine("\n1. Asendatud nimed:");
            foreach (var nimi in õpilased)
            {
                Console.WriteLine(nimi);
            }

            Console.WriteLine("\n2. While – nimed mis algavad tähega 'A':");
            int w = 0;
            while (w < õpilased.Length)
            {
                if (õpilased[w].StartsWith("A"))
                {
                    Console.WriteLine($"Tere, {õpilased[w]}!");
                }
                w++;
            }

            Console.WriteLine("\n3. For – kõik nimed ja indeksid:");
            for (int i = 0; i < õpilased.Length; i++)
            {
                Console.WriteLine($"[{i}] {õpilased[i]}");
            }

            Console.WriteLine("\n4. Foreach – nimed väikeste tähtedena:");
            foreach (var nimi in õpilased)
            {
                Console.WriteLine(nimi.ToLower());
            }

            Console.WriteLine("\n5. Do-while – tervita kuni nimeni 'Mati':");
            int dw = 0;
            do
            {
                Console.WriteLine($"Tere, {õpilased[dw]}!");
                dw++;
            } while (dw < õpilased.Length && õpilased[dw - 1] != "Mati");


            Console.WriteLine("\n Ülesanne 9: Arvude ruudud");

            int[] arvud9 = { 2, 4, 6, 8, 10, 12 };

            Console.WriteLine("\n1. For – iga arvu ruut:");
            for (int i = 0; i < arvud9.Length; i++)
            {
                Console.WriteLine($"{arvud9[i]}² = {arvud9[i] * arvud9[i]}");
            }

            Console.WriteLine("\n2. Foreach – iga arvu kahekordne väärtus:");
            foreach (var arv in arvud9)
            {
                Console.WriteLine($"{arv} * 2 = {arv * 2}");
            }

            Console.WriteLine("\n3. While – arvud mis jaguvad 3-ga:");
            int loendur = 0;
            int j = 0;
            while (j < arvud9.Length)
            {
                if (arvud9[j] % 3 == 0)
                {
                    loendur++;
                }
                j++;
            }
            Console.WriteLine($"3-ga jaguvaid arve: {loendur}");


            Console.WriteLine("\n Ülesanne 10: Positiivsed ja negatiivsed");

            int[] arvud10 = { 5, -3, 0, 8, -1, 4, -7, 2, 0, -5, 6, 9 };

            int positiivsed = 0;
            int negatiivsed = 0;
            int nullid = 0;

            foreach (var arv in arvud10)
            {
                if (arv > 0)
                {
                    positiivsed++;
                }
                else if (arv < 0)
                {
                    negatiivsed++;
                }
                else
                {
                    nullid++;
                }
            }

            Console.WriteLine($"Positiivseid arve: {positiivsed}");
            Console.WriteLine($"Negatiivseid arve: {negatiivsed}");
            Console.WriteLine($"Nulle:             {nullid}");


            Console.WriteLine("\n Ülesanne 11: Keskmisest suuremad");

            Random juhus = new Random();
            int[] arvud11 = new int[15];

            for (int i = 0; i < arvud11.Length; i++)
            {
                arvud11[i] = juhus.Next(1, 101);
            }

            Console.Write("Genereeritud arvud: ");
            foreach (var arv in arvud11)
            {
                Console.Write($"{arv} ");
            }
            Console.WriteLine();

            int summa11 = 0;
            for (int i = 0; i < arvud11.Length; i++)
            {
                summa11 += arvud11[i];
            }
            double keskmine11 = (double)summa11 / arvud11.Length;
            Console.WriteLine($"\n1. Keskmine väärtus: {keskmine11:F2}");

            Console.WriteLine("\n2. Keskmisest suuremad arvud:");
            foreach (var arv in arvud11)
            {
                if (arv > keskmine11)
                {
                    Console.Write($"{arv} ");
                }
            }
            Console.WriteLine();

            Console.WriteLine("\n3. Do-while – arvud kuni esimese alla 10 olevani:");
            int k11 = 0;
            do
            {
                Console.Write($"{arvud11[k11]} ");
                k11++;
            } while (k11 < arvud11.Length && arvud11[k11 - 1] >= 10);
            Console.WriteLine();


            Console.WriteLine("\n Ülesanne 12: Kõige suurema arvu otsing");

            int[] numbrid = { 12, 56, 78, 2, 90, 43, 88, 67 };

            int suurimVäärtus = numbrid[0];
            int suurimIndeks = 0;

            for (int i = 1; i < numbrid.Length; i++)
            {
                if (numbrid[i] > suurimVäärtus)
                {
                    suurimVäärtus = numbrid[i];
                    suurimIndeks = i;
                }
            }

            Console.WriteLine($"Suurim arv: {suurimVäärtus}");
            Console.WriteLine($"Suurima arvu indeks: {suurimIndeks}");


            Console.WriteLine("\n Ülesanne 13: Paari- ja paaritud loendused");

            List<int> arvud13 = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                arvud13.Add(juhus.Next(1, 101));
            }

            Console.Write("Genereeritud arvud: ");
            foreach (var arv in arvud13)
            {
                Console.Write($"{arv} ");
            }
            Console.WriteLine();

            long paarisarvudeSumma = 0;
            for (int i = 0; i < arvud13.Count; i++)
            {
                if (arvud13[i] % 2 == 0)
                {
                    paarisarvudeSumma += arvud13[i];
                }
            }
            Console.WriteLine($"\nPaarisarvude kogusumma: {paarisarvudeSumma}");

            long paarituteKogusumma = 0;
            int paarituteArv = 0;
            foreach (var arv in arvud13)
            {
                if (arv % 2 != 0)
                {
                    paarituteKogusumma += arv;
                    paarituteArv++;
                }
            }
            double paarituteKeskmine = paarituteArv > 0 ? (double)paarituteKogusumma / paarituteArv : 0;
            Console.WriteLine($"Paaritute arvude keskmine: {paarituteKeskmine:F2}");

            int üle50 = 0;
            int m = 0;
            while (m < arvud13.Count)
            {
                if (arvud13[m] > 50)
                {
                    üle50++;
                }
                m++;
            }
            Console.WriteLine($"Arvud mis on suuremad kui 50: {üle50}");

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
