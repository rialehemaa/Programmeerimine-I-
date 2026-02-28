using System;
using System.Collections.Generic;
using System.Text;

namespace naidis_iktpv25
{
    public static class Osa3_funktsioonid
    {
        // MENÜÜ
        public static void Menuu()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("\nOSA 3 ");
                Console.WriteLine("1  - Juhuslike arvude ruudud");
                Console.WriteLine("2  - Viie arvu analüüs");
                Console.WriteLine("3  - Nimed ja vanused");
                Console.WriteLine("4  - Osta elevant ära");
                Console.WriteLine("5  - Arvamise mäng");
                Console.WriteLine("6  - Suurim neliarvuline arv");
                Console.WriteLine("7  - Korrutustabel");
                Console.WriteLine("8  - Õpilastega mängimine");
                Console.WriteLine("9  - Arvude ruudud");
                Console.WriteLine("10 - Positiivsed ja negatiivsed");
                Console.WriteLine("11 - Keskmisest suuremad");
                Console.WriteLine("12 - Kõige suurema arvu otsing");
                Console.WriteLine("13 - Paaris ja paaritud");
                Console.WriteLine("0  - Tagasi");
                Console.Write("Valik: ");

                string v = Console.ReadLine();
                switch (v)
                {
                    case "1": ArvuTootlus(); break;
                    case "2": ViieArvuAnalyys(); break;
                    case "3": NimedJaVanused(); break;
                    case "4": KuniMarksõnani("osta elevant ära", "Osta elevant ära!"); break;
                    case "5": ArvaArv(); break;
                    case "6": SuurimNeliarv(); break;
                    case "7":

                        Console.Write("Sisesta ridade arv: ");
                        int ridu = int.Parse(Console.ReadLine());

                        Console.Write("Sisesta veergude arv: ");
                        int veerge = int.Parse(Console.ReadLine());

                        int[,] tabel = GenereeriKorrutustabel(ridu, veerge);

                        Console.Write("\nSisesta rida mille tulemust soovid (nt 7): ");
                        int otsinguRida = int.Parse(Console.ReadLine());

                        Console.Write("Sisesta veerg mille tulemust soovid (nt 8): ");
                        int otsinguVeerg = int.Parse(Console.ReadLine());

                        if (otsinguRida >= 1 && otsinguRida <= ridu &&
                            otsinguVeerg >= 1 && otsinguVeerg <= veerge)
                        {
                            Console.WriteLine($"{otsinguRida} x {otsinguVeerg} = {tabel[otsinguRida - 1, otsinguVeerg - 1]}");
                        }
                        else
                        {
                            Console.WriteLine("Vigane otsing, arv on väljaspool tabeli piire.");
                        }
                        break;

                    case "8": Opilased(); break;
                    case "9": ArvudeRuudud(); break;
                    case "10": PosNegNull(); break;
                    case "11": KeskmisestSuuremad(); break;
                    case "12": SuurimArv(); break;
                    case "13": PaarisPaaritu(); break;
                    case "0": run = false; break;
                }
            }
        }

        //  1. JUHUSLIKE ARVUDE RUUDUD

        static void ArvuTootlus()
        {
            Random r = new Random();
            int a = r.Next(1, 10);
            int b = r.Next(1, 10);
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);

            for (int i = min; i <= max; i++)
                Console.WriteLine($"{i} -- {i * i}");
        }

        //  2. VIIE ARVU ANALÜÜS

        static void ViieArvuAnalyys()
        {
            double[] arvud = new double[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Sisesta arv: ");
                arvud[i] = double.Parse(Console.ReadLine());
            }

            double sum = 0, prod = 1;
            foreach (double x in arvud)
            {
                sum += x;
                prod *= x;
            }

            Console.WriteLine($"Summa: {sum}");
            Console.WriteLine($"Keskmine: {sum / 5}");
            Console.WriteLine($"Korrutis: {prod}");
        }

        //  3. NIMED JA VANUSED

        class Inimene
        {
            public string Nimi;
            public int Vanus;
        }

        static void NimedJaVanused()
        {
            List<Inimene> inimesed = new List<Inimene>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Nimi: ");
                string n = Console.ReadLine();
                Console.Write("Vanus: ");
                int v = int.Parse(Console.ReadLine());
                inimesed.Add(new Inimene { Nimi = n, Vanus = v });
            }

            int sum = 0;
            Inimene noorim = inimesed[0];
            Inimene vanim = inimesed[0];

            foreach (var i in inimesed)
            {
                sum += i.Vanus;
                if (i.Vanus < noorim.Vanus) noorim = i;
                if (i.Vanus > vanim.Vanus) vanim = i;
            }

            Console.WriteLine($"Summa: {sum}");
            Console.WriteLine($"Keskmine: {(double)sum / inimesed.Count}");
            Console.WriteLine($"Noorim: {noorim.Nimi}");
            Console.WriteLine($"Vanim: {vanim.Nimi}");
        }

        //  4. OSTA ELEVANT ÄRA

        static void KuniMarksõnani(string marksona, string fraas)
        {
            List<string> vastused = new List<string>();
            string s;
            do
            {
                Console.WriteLine(fraas);
                s = Console.ReadLine();
                vastused.Add(s);
            } while (s != marksona);

            Console.WriteLine("Kõik vastused:");
            foreach (var v in vastused)
                Console.WriteLine(v);
        }

        //  5. ARVAMISE MÄNG
        static void ArvaArv()
        {
            string jatka = "jah";

            while (jatka == "jah")
            {
                Random juhus = new Random();
                int saladuslik = juhus.Next(1, 101);
                int katseid = 5;
                bool oigeArvamine = false;

                Console.WriteLine("Ma mõtlen arvu vahemikus 1–100. Sul on 5 katset.");

                for (int i = 1; i <= katseid; i++)
                {
                    Console.Write($"Katse {i}/{katseid}: ");
                    int arva = int.Parse(Console.ReadLine());

                    if (arva == saladuslik)
                    {
                        Console.WriteLine($"Õige! Arv oligi {saladuslik}! Arvasid {i}. katsega!");
                        oigeArvamine = true;
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

                if (!oigeArvamine)
                {
                    Console.WriteLine($"Katsed otsas! Minu arv oli {saladuslik}.");
                }

                Console.Write("Kas soovid uuesti mängida? (jah/ei): ");
                jatka = Console.ReadLine().ToLower().Trim();
            }
        }

        //  6. SUURIM NELIARVULINE ARV

        static void SuurimNeliarv()
        {
            int[] a = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Sisesta arv (0-9): ");
                a[i] = int.Parse(Console.ReadLine());
                if (a[i] < 0 || a[i] > 9) return;
            }

            Array.Sort(a);
            Array.Reverse(a);
            Console.WriteLine($"Suurim arv: {a[0]}{a[1]}{a[2]}{a[3]}");
        }

        //  7. KORRUTUSTABEL
        static int[,] GenereeriKorrutustabel(int ridadeArv, int veergudeArv)
        {
            int[,] tabel = new int[ridadeArv, veergudeArv];

            // täidame tabeli
            for (int rida = 0; rida < ridadeArv; rida++)
            {
                for (int veerg = 0; veerg < veergudeArv; veerg++)
                {
                    tabel[rida, veerg] = (rida + 1) * (veerg + 1);
                }
            }

            // kuvame tabeli
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

        //  8. ÕPILASTEGA MÄNGIMINE

        static void Opilased()
        {
            string[] nimed = { "Anna", "Juku", "Mari", "Peeter", "Aino", "Karl", "Liis", "Aadu", "Mati", "Eeva" };
            nimed[2] = "Kati";
            nimed[5] = "Mati";

            int i = 0;
            while (i < nimed.Length)
            {
                if (nimed[i].StartsWith("A"))
                    Console.WriteLine("Tere " + nimed[i]);
                i++;
            }

            for (int j = 0; j < nimed.Length; j++)
                Console.WriteLine($"{j}: {nimed[j]}");

            foreach (var n in nimed)
                Console.WriteLine(n.ToLower());

            int k = 0;
            do
            {
                Console.WriteLine("Tere " + nimed[k]);
                k++;
            } while (nimed[k - 1] != "Mati");
        }

        //  9. ARVUDE RUUDUD

        static void ArvudeRuudud()
        {
            int[] a = { 2, 4, 6, 8, 10, 12 };
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i] * a[i]);

            foreach (int x in a)
                Console.WriteLine(x * 2);

            int c = 0, k = 0;
            while (k < a.Length)
            {
                if (a[k] % 3 == 0) c++;
                k++;
            }
            Console.WriteLine("Jagub 3-ga: " + c);
        }

        // 10. POSITIIVSED JA NEGATIIVSED

        static void PosNegNull()
        {
            int[] a = { 5, -3, 0, 8, -1, 4, -7, 2, 0, -5, 6, 9 };
            int p = 0, n = 0, z = 0;
            foreach (int x in a)
            {
                if (x > 0) p++;
                else if (x < 0) n++;
                else z++;
            }
            Console.WriteLine($"Pos: {p}, Neg: {n}, Null: {z}");
        }

        // 11. KESKMISEST SUUREMAD

        static void KeskmisestSuuremad()
        {
            Random r = new Random();
            int[] a = new int[15];
            int sum = 0;
            for (int i = 0; i < 15; i++)
            {
                a[i] = r.Next(1, 101);
                sum += a[i];
            }
            double avg = (double)sum / 15;
            Console.WriteLine("Keskmine: " + avg);

            int k = 0;
            do
            {
                if (a[k] > avg) Console.WriteLine(a[k]);
                k++;
            } while (k < a.Length && a[k - 1] >= 10);
        }

        // 12. KÕIGE SUUREMA ARVU OTSING

        static void SuurimArv()
        {
            int[] a = { 12, 56, 78, 2, 90, 43, 88, 67 };
            int max = a[0], idx = 0;
            for (int i = 1; i < a.Length; i++)
                if (a[i] > max) { max = a[i]; idx = i; }
            Console.WriteLine($"Suurim: {max}, indeks: {idx}");
        }

        // 13. PAARIS JA PAARITUD
        static void PaarisPaaritu()
        {
            Random r = new Random();
            List<int> a = new List<int>();
            for (int i = 0; i < 20; i++) a.Add(r.Next(1, 101));

            int sumEven = 0, countOdd = 0, sumOdd = 0, over50 = 0;

            for (int i = 0; i < a.Count; i++)
                if (a[i] % 2 == 0) sumEven += a[i];

            foreach (int x in a)
                if (x % 2 != 0) { sumOdd += x; countOdd++; }

            int k = 0;
            while (k < a.Count)
            {
                if (a[k] > 50) over50++;
                k++;
            }

            Console.WriteLine($"Paaris summa: {sumEven}");
            Console.WriteLine($"Paaritute keskmine: {(double)sumOdd / countOdd}");
            Console.WriteLine($">50: {over50}");
        }
    }
}