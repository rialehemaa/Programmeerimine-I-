using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace FilmiJälgija
{
    public class Menu
    {
        
        public static void Käivita(List<Meedia> meediaList)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("OLEMAS NIMEKIRJAD:");

                foreach (var m in meediaList)
                {
                    Console.WriteLine($"* {m.Pealkiri}");
                }

                Console.WriteLine("\n1 - Otsi film");
                Console.WriteLine("2 - Lisa uus");
                Console.WriteLine("3 - Kustuta film");
                Console.WriteLine("4 - Salvesta");
                Console.WriteLine("0 - Välju");

                Console.Write("Valik: ");
                string valik = Console.ReadLine();

                if (valik == "0")
                    break;

                switch (valik)
                {
                    case "1":
                        OtsiFilm(meediaList);
                        break;

                    case "2":
                        LisaMenu(meediaList);
                        break;

                    case "3":
                        KustutaFilm(meediaList);
                        break;

                    case "4":
                        SalvestaFaili(meediaList);
                        break;

                    default:
                        Console.WriteLine("Vale valik!");
                        break;
                }
            }
        }

        private static void LisaMenu(List<Meedia> list)
        {
            Console.WriteLine("\nLisa midagi uus :");

            Console.WriteLine("1 - Film");
            Console.WriteLine("2 - Seriaal");
            Console.WriteLine("3 - Dokumentaalfilm");
            Console.WriteLine("4 - Multikas");
            Console.WriteLine("5 - Telesaade");

            Console.Write("Valik: ");
            string valik = Console.ReadLine();

            switch (valik)
            {
                case "1":
                    LisaFilm(list);
                    break;

                case "2":
                    LisaSeriaal(list);
                    break;

                case "3":
                    LisaDokumentaal(list);
                    break;
                    
                case "4":
                    LisaMultikas(list);
                    break;

                case "5":
                    LisaTelesaade(list);
                    break;

                default:
                    Console.WriteLine("Vale valik!");
                    break;
            }
        }

        private static void LisaFilm(List<Meedia> list)
        {
            Console.Write("Pealkiri: ");
            string nimi = Console.ReadLine()!;

            if (list.Any(x => x.Pealkiri.ToLower() == nimi.ToLower()))
            {
                Console.WriteLine("See film juba eksisteerib!");
                Console.ReadKey();
                return;
            }

            Console.Write("Aasta: ");
            int aasta = int.Parse(Console.ReadLine()!);

            Console.Write("Staatus: ");
            string staatus = Console.ReadLine()!;

            Console.Write("Kestus: ");
            int kestus = int.Parse(Console.ReadLine()!);

            Film film = new Film
            {
                Pealkiri = nimi,
                Aasta = aasta,
                Staatus = staatus,
                KestusMinutites = kestus
            };

            Console.Write("Hinnang: ");
            film.LisaHinnang(double.Parse(Console.ReadLine()!));

            list.Add(film);

            Console.WriteLine("Film lisatud!");
            Console.ReadKey();
        }

        private static void LisaSeriaal(List<Meedia> list)
        {
            Console.Write("Pealkiri: ");
            string nimi = Console.ReadLine();

            if (list.Any(x => x.Pealkiri.ToLower() == nimi.ToLower()))
            {
                Console.WriteLine("See seriaal juba eksisteerib!");
                Console.ReadKey();
                return;
            }

            Console.Write("Aasta: ");
            int aasta = int.Parse(Console.ReadLine());

            Console.Write("Staatus: ");
            string staatus = Console.ReadLine();

            Console.Write("Hooaegade arv: ");
            int hooajad = int.Parse(Console.ReadLine());

            Seriaal seriaal = new Seriaal
            {
                Pealkiri = nimi,
                Aasta = aasta,
                Staatus = staatus,
                HooaegadeArv = hooajad
            };

            Console.Write("Hinnang: ");
            seriaal.LisaHinnang(double.Parse(Console.ReadLine()));

            list.Add(seriaal);

            Console.WriteLine("Seriaal lisatud!");
            Console.ReadKey();
        }

        private static void LisaDokumentaal(List<Meedia> list)
        {
            Console.Write("Pealkiri: ");
            string nimi = Console.ReadLine();

            if (list.Any(x => x.Pealkiri.ToLower() == nimi.ToLower()))
            {
                Console.WriteLine("See dokumentaal juba eksisteerib!");
                Console.ReadKey();
                return;
            }

            Console.Write("Aasta: ");
            int aasta = int.Parse(Console.ReadLine());

            Console.Write("Staatus: ");
            string staatus = Console.ReadLine();

            Console.Write("Teema: ");
            string teema = Console.ReadLine();

            Dokumentaalfilm dok = new Dokumentaalfilm
            {
                Pealkiri = nimi,
                Aasta = aasta,
                Staatus = staatus,
                Teema = teema
            };

            Console.Write("Hinnang: ");
            dok.LisaHinnang(double.Parse(Console.ReadLine()));

            list.Add(dok);

            Console.WriteLine("Dokumentaal lisatud!");
            Console.ReadKey();
        }

        private static void LisaMultikas(List<Meedia> list)
        {
            Console.Write("Pealkiri: ");
            string nimi = Console.ReadLine();

            if (list.Any(x => x.Pealkiri.ToLower() == nimi.ToLower()))
            {
                Console.WriteLine("See multikas juba eksisteerib!");
                Console.ReadKey();
                return;
            }

            Console.Write("Aasta: ");
            int aasta = int.Parse(Console.ReadLine());

            Console.Write("Staatus: ");
            string staatus = Console.ReadLine();

            Console.Write("Sihtrühm: ");
            string sihtrühm = Console.ReadLine();

            Multikas multikas = new Multikas
            {
                Pealkiri = nimi,
                Aasta = aasta,
                Staatus = staatus,
                Sihtrühm = sihtrühm
            };

            Console.Write("Hinnang: ");
            multikas.LisaHinnang(double.Parse(Console.ReadLine()));

            list.Add(multikas);

            Console.WriteLine("Multikas lisatud!");
            Console.ReadKey();
        }

        private static void LisaTelesaade(List<Meedia> list)
        {
            Console.Write("Pealkiri: ");
            string nimi = Console.ReadLine();

            if (list.Any(x => x.Pealkiri.ToLower() == nimi.ToLower()))
            {
                Console.WriteLine("See telesaade juba eksisteerib!");
                Console.ReadKey();
                return;
            }

            Console.Write("Aasta: ");
            int aasta = int.Parse(Console.ReadLine());

            Console.Write("Staatus: ");
            string staatus = Console.ReadLine();

            Console.Write("Saatejuht: ");
            string saatejuht = Console.ReadLine();

            Telesaade saade = new Telesaade
            {
                Pealkiri = nimi,
                Aasta = aasta,
                Staatus = staatus,
                Saatejuht = saatejuht
            };

            Console.Write("Hinnang: ");
            saade.LisaHinnang(double.Parse(Console.ReadLine()));

            list.Add(saade);

            Console.WriteLine("Telesaade lisatud!");
            Console.ReadKey();
        }
        private static void KustutaFilm(List<Meedia> list)
        {
            Console.Write("Sisesta filmi nimi kustutamiseks: ");
            string nimi = Console.ReadLine()!.ToLower();

            var leitud = list.FirstOrDefault(x => x.Pealkiri.ToLower() == nimi);

            if (leitud != null)
            {
                list.Remove(leitud);
                Console.WriteLine("Film kustutatud!");
            }
            else
            {
                Console.WriteLine("Filmi ei leitud.");
            }

            Console.ReadKey();
        }

        private static void OtsiFilm(List<Meedia> list)
        {
            Console.Write("Sisesta nimi: ");
            string nimi = Console.ReadLine().ToLower();

            foreach (var m in list)
            {
                if (m.Pealkiri.ToLower().Contains(nimi))
                {
                    Console.WriteLine("\nLeitud:");
                    m.KuvaInfo();
                    return;
                }
            }

            Console.WriteLine("Ei leitud.");
        }

        private static void SalvestaFaili(List<Meedia> list)
        {
            using (StreamWriter sw = new StreamWriter("meedia.txt"))
            {
                foreach (var m in list)
                {
                    if (m is Film f)
                    {
                        sw.WriteLine($"Film,{f.Pealkiri},{f.Aasta},{f.Staatus},{f.Hinnang},{f.KestusMinutites}");
                    }
                    else if (m is Seriaal s)
                    {
                        sw.WriteLine($"Seriaal,{s.Pealkiri},{s.Aasta},{s.Staatus},{s.Hinnang},{s.HooaegadeArv}");
                    }
                    else if (m is Dokumentaalfilm d)
                    {
                        sw.WriteLine($"Dokumentaal,{d.Pealkiri},{d.Aasta},{d.Staatus},{d.Hinnang},{d.Teema}");
                    }
                    else if (m is Multikas mu)
                    {
                        sw.WriteLine($"Multikas,{mu.Pealkiri},{mu.Aasta},{mu.Staatus},{mu.Hinnang},{mu.Sihtrühm}");
                    }
                    else if (m is Telesaade t)
                    {
                        sw.WriteLine($"Telesaade,{t.Pealkiri},{t.Aasta},{t.Staatus},{t.Hinnang},{t.Saatejuht}");
                    }
                }
            }
        }

        public static void LaeFailist(List<Meedia> list)
        {
            if (!File.Exists("meedia.txt"))
                return;

            var lines = File.ReadAllLines("meedia.txt");

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                string tüüp = parts[0];
                string nimi = parts[1];
                int aasta = int.Parse(parts[2]);
                string staatus = parts[3];
                double hinnang = double.Parse(parts[4]);

                switch (tüüp)
                {
                    case "Film":
                        list.Add(new Film
                        {
                            Pealkiri = nimi,
                            Aasta = aasta,
                            Staatus = staatus,
                            KestusMinutites = int.Parse(parts[5]),
                            Hinnang = hinnang
                        });
                        break;

                    case "Seriaal":
                        list.Add(new Seriaal
                        {
                            Pealkiri = nimi,
                            Aasta = aasta,
                            Staatus = staatus,
                            HooaegadeArv = int.Parse(parts[5]),
                            Hinnang = hinnang
                        });
                        break;

                    case "Dokumentaal":
                        list.Add(new Dokumentaalfilm
                        {
                            Pealkiri = nimi,
                            Aasta = aasta,
                            Staatus = staatus,
                            Teema = parts[5],
                            Hinnang = hinnang
                        });
                        break;

                    case "Multikas":
                        list.Add(new Multikas
                        {
                            Pealkiri = nimi,
                            Aasta = aasta,
                            Staatus = staatus,
                            Sihtrühm = parts[5],
                            Hinnang = hinnang
                        });
                        break;

                    case "Telesaade":
                        list.Add(new Telesaade
                        {
                            Pealkiri = nimi,
                            Aasta = aasta,
                            Staatus = staatus,
                            Saatejuht = parts[5],
                            Hinnang = hinnang
                        });
                        break;
                }
            }
        }
    }
}

