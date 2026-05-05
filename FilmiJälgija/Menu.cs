using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FilmiJälgija
{
    public class Menu
    {
        private static readonly ConsoleColor DimColor = ConsoleColor.DarkGray;
        private static readonly ConsoleColor ErrorColor = ConsoleColor.Red;

        // ══════════════════════════════════════════════════════════════════════
        //  AVALIK KÄIVITAMINE
        // ══════════════════════════════════════════════════════════════════════
        public static void Käivita(List<Meedia> meediaList)
        {
            Console.CursorVisible = true;
            while (true)
            {
                Console.Clear();
                PrintHeader();
                PrintNimekiri(meediaList);
                PrintMenu();

                string valik = ReadInput("Valik");

                if (valik == "0") { PrintVälju(); break; }

                switch (valik)
                {
                    case "1": OtsiFilm(meediaList); break;
                    case "2": LisaMenu(meediaList); break;
                    case "3": KustutaFilm(meediaList); break;
                    case "4": SalvestaFaili(meediaList); break;
                    default: PrintError("Vale valik! Proovi uuesti."); Pause(); break;
                }
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  UI KOMPONENDID
        // ══════════════════════════════════════════════════════════════════════

        private static void PrintHeader()
        {
            W(); Console.WriteLine("╔══════════════════════════════════════════════════╗");
            W(); Console.Write("║");
            Y(); Console.Write("         F I L M I J A L G I J A    ");
            W(); Console.WriteLine("              ║");
            W(); Console.WriteLine("╚══════════════════════════════════════════════════╝");
            R();
        }

        private static void PrintNimekiri(List<Meedia> meediaList)
        {
            Console.WriteLine();
            W(); Console.WriteLine("╔══ MEEDIA NIMEKIRI ══════════════════════════════╗");

            if (meediaList.Count == 0)
            {
                G(); Console.WriteLine("║   (nimekiri on tühi)");
                W(); Console.WriteLine("╚═════════════════════════════════════════════════╝");
                R(); Console.WriteLine();
                return;
            }

            int i = 1;
            foreach (var m in meediaList)
            {
                W(); Console.Write("║ ");
                G(); Console.Write($"{i,2}. ");
                SetColor(TypeColor(m));
                Console.Write($"[{TypeLabel(m),-11}]");
                W(); Console.Write($" {m.Pealkiri,-20}");
                G(); Console.Write($"  {m.Aasta}  ");
                PrintStars(m.Hinnang);
                Console.WriteLine();
                i++;
            }

            W(); Console.WriteLine("╚═════════════════════════════════════════════════╝");
            R(); Console.WriteLine();
        }

        private static void PrintMenu()
        {
            W(); Console.WriteLine("╔══ TEGEVUSED ════════════════════════════════════╗");
            PrintMenuItem("1", "Otsi meediaobjekt");
            PrintMenuItem("2", "Lisa uus");
            PrintMenuItem("3", "Kustuta");
            PrintMenuItem("4", "Salvesta faili");
            PrintMenuItem("0", "Välju");
            W(); Console.WriteLine("╚═════════════════════════════════════════════════╝");
            R(); Console.WriteLine();
        }

        private static void PrintMenuItem(string key, string label)
        {
            W(); Console.Write("║  ");
            Y(); Console.Write($" {key} ");
            G(); Console.Write(" →  ");
            W(); Console.WriteLine(label);
        }

        private static void PrintStars(double hinnang)
        {
            int täis = (int)Math.Round(hinnang);
            Y();
            for (int i = 1; i <= 5; i++)
                Console.Write(i <= täis ? "★" : "☆");
            G(); Console.Write($" {hinnang:0.0}");
            R();
        }

        private static void PrintInfoBox(Meedia m)
        {
            Console.WriteLine();
            W(); Console.WriteLine("╔══ LEITUD ═══════════════════════════════════════╗");

            PrintInfoRow("Tüüp", TypeLabel(m), TypeColor(m));
            PrintInfoRow("Pealkiri", m.Pealkiri, ConsoleColor.White);
            PrintInfoRow("Aasta", m.Aasta.ToString(), ConsoleColor.White);
            PrintInfoRow("Staatus", m.Staatus, StatusColor(m.Staatus));

            W(); Console.Write("║  ");
            G(); Console.Write($"  {"Hinnang",-11}");
            PrintStars(m.Hinnang);
            Console.WriteLine();

            if (m is Film f)
                PrintInfoRow("Kestus", $"{f.KestusMinutites} min", ConsoleColor.White);
            else if (m is Seriaal s)
            {
                PrintInfoRow("Hooajad", s.HooaegadeArv.ToString(), ConsoleColor.White);
                PrintInfoRow("Vaadatud ep.", s.VaadatudEpisoodid.ToString(), ConsoleColor.White);
            }
            else if (m is Dokumentaalfilm d)
                PrintInfoRow("Teema", d.Teema, ConsoleColor.White);
            else if (m is Multikas mu)
                PrintInfoRow("Sihtrühm", mu.Sihtrühm, ConsoleColor.White);
            else if (m is Telesaade t)
                PrintInfoRow("Saatejuht", t.Saatejuht, ConsoleColor.White);

            if (!string.IsNullOrEmpty(m.Märkus))
                PrintInfoRow("Märkus", m.Märkus, DimColor);

            W(); Console.WriteLine("╚═════════════════════════════════════════════════╝");
            R(); Console.WriteLine();
        }

        private static void PrintInfoRow(string label, string value, ConsoleColor valColor)
        {
            W(); Console.Write("║  ");
            G(); Console.Write($"  {label,-11}");
            SetColor(valColor); Console.WriteLine(value);
        }

        // ══════════════════════════════════════════════════════════════════════
        //  TEGEVUSED
        // ══════════════════════════════════════════════════════════════════════

        private static void OtsiFilm(List<Meedia> list)
        {
            Console.Clear(); PrintHeader();
            PrintSectionTitle("OTSI MEEDIAOBJEKT");

            string nimi = ReadInput("Pealkiri (või osa sellest)");
            var leitud = list.Where(x => x.Pealkiri.ToLower().Contains(nimi.ToLower())).ToList();

            if (leitud.Count == 0)
            {
                PrintError($"Otsingule '{nimi}' ei leitud tulemusi.");
            }
            else
            {
                Console.WriteLine();
                G(); Console.WriteLine($"  Leitud {leitud.Count} tulemus(t):");
                R();
                foreach (var m in leitud)
                    PrintInfoBox(m);
            }
            Pause();
        }

        private static void LisaMenu(List<Meedia> list)
        {
            Console.Clear(); PrintHeader();
            PrintSectionTitle("LISA UUS MEEDIAOBJEKT");

            W(); Console.WriteLine("  Vali tüüp:"); Console.WriteLine();
            PrintMenuItem("1", "Film");
            PrintMenuItem("2", "Seriaal");
            PrintMenuItem("3", "Dokumentaalfilm");
            PrintMenuItem("4", "Multikas");
            PrintMenuItem("5", "Telesaade");
            Console.WriteLine();

            string valik = ReadInput("Valik");
            switch (valik)
            {
                case "1": LisaFilm(list); break;
                case "2": LisaSeriaal(list); break;
                case "3": LisaDokumentaal(list); break;
                case "4": LisaMultikas(list); break;
                case "5": LisaTelesaade(list); break;
                default: PrintError("Vale valik!"); Pause(); break;
            }
        }

        private static void LisaFilm(List<Meedia> list)
        {
            Console.Clear(); PrintHeader(); PrintSectionTitle("LISA FILM");
            string nimi = ReadInput("Pealkiri");
            if (OnOlemas(list, nimi)) return;
            int aasta = ReadInt("Aasta", 1888, DateTime.Now.Year);
            string stat = ReadStatuus();
            int kestus = ReadInt("Kestus (minutites)", 1, 999);
            double h = ReadHinnang();
            list.Add(new Film { Pealkiri = nimi, Aasta = aasta, Staatus = stat, KestusMinutites = kestus, Hinnang = h });
            PrintSuccess("Film edukalt lisatud.");
            Pause();
        }

        private static void LisaSeriaal(List<Meedia> list)
        {
            Console.Clear(); PrintHeader(); PrintSectionTitle("LISA SERIAAL");
            string nimi = ReadInput("Pealkiri");
            if (OnOlemas(list, nimi)) return;
            int aasta = ReadInt("Aasta", 1888, DateTime.Now.Year);
            string stat = ReadStatuus();
            int hooajad = ReadInt("Hooaegade arv", 1, 100);
            double h = ReadHinnang();
            list.Add(new Seriaal { Pealkiri = nimi, Aasta = aasta, Staatus = stat, HooaegadeArv = hooajad, Hinnang = h });
            PrintSuccess("Seriaal edukalt lisatud.");
            Pause();
        }

        private static void LisaDokumentaal(List<Meedia> list)
        {
            Console.Clear(); PrintHeader(); PrintSectionTitle("LISA DOKUMENTAALFILM");
            string nimi = ReadInput("Pealkiri");
            if (OnOlemas(list, nimi)) return;
            int aasta = ReadInt("Aasta", 1888, DateTime.Now.Year);
            string stat = ReadStatuus();
            string teema = ReadInput("Teema (nt loodus, ajalugu, sport)");
            double h = ReadHinnang();
            list.Add(new Dokumentaalfilm { Pealkiri = nimi, Aasta = aasta, Staatus = stat, Teema = teema, Hinnang = h });
            PrintSuccess("Dokumentaalfilm edukalt lisatud.");
            Pause();
        }

        private static void LisaMultikas(List<Meedia> list)
        {
            Console.Clear(); PrintHeader(); PrintSectionTitle("LISA MULTIKAS");
            string nimi = ReadInput("Pealkiri");
            if (OnOlemas(list, nimi)) return;
            int aasta = ReadInt("Aasta", 1888, DateTime.Now.Year);
            string stat = ReadStatuus();
            string siht = ReadInput("Sihtrühm (nt lapsed, pere, noored)");
            double h = ReadHinnang();
            list.Add(new Multikas { Pealkiri = nimi, Aasta = aasta, Staatus = stat, Sihtrühm = siht, Hinnang = h });
            PrintSuccess("Multikas edukalt lisatud.");
            Pause();
        }

        private static void LisaTelesaade(List<Meedia> list)
        {
            Console.Clear(); PrintHeader(); PrintSectionTitle("LISA TELESAADE");
            string nimi = ReadInput("Pealkiri");
            if (OnOlemas(list, nimi)) return;
            int aasta = ReadInt("Aasta", 1888, DateTime.Now.Year);
            string stat = ReadStatuus();
            string juht = ReadInput("Saatejuht");
            double h = ReadHinnang();
            list.Add(new Telesaade { Pealkiri = nimi, Aasta = aasta, Staatus = stat, Saatejuht = juht, Hinnang = h });
            PrintSuccess("Telesaade edukalt lisatud.");
            Pause();
        }

        private static void KustutaFilm(List<Meedia> list)
        {
            Console.Clear(); PrintHeader(); PrintSectionTitle("KUSTUTA MEEDIAOBJEKT");
            string nimi = ReadInput("Pealkiri");
            var leitud = list.FirstOrDefault(x => x.Pealkiri.ToLower() == nimi.ToLower());

            if (leitud == null)
            {
                PrintError($"'{nimi}' ei leitud nimekirjast.");
            }
            else
            {
                Console.WriteLine();
                Console.Write("  "); W();
                Console.Write($"Kas kustutada '{leitud.Pealkiri}'? (j/e): ");
                R();
                string kinnitus = Console.ReadLine()?.ToLower() ?? "";
                if (kinnitus == "j")
                {
                    list.Remove(leitud);
                    PrintSuccess($"'{leitud.Pealkiri}' kustutatud.");
                }
                else
                {
                    Console.WriteLine();
                    G(); Console.WriteLine("  Kustutamine tühistatud."); R();
                }
            }
            Pause();
        }

        private static void SalvestaFaili(List<Meedia> list)
        {
            Console.Clear(); PrintHeader(); PrintSectionTitle("SALVESTA FAILI");
            try
            {
                using (StreamWriter sw = new StreamWriter("meedia.txt"))
                {
                    foreach (var m in list)
                    {
                        if (m is Film f)
                            sw.WriteLine($"Film,{f.Pealkiri},{f.Aasta},{f.Staatus},{f.Hinnang.ToString(CultureInfo.InvariantCulture)},{f.KestusMinutites}");
                        else if (m is Seriaal s)
                            sw.WriteLine($"Seriaal,{s.Pealkiri},{s.Aasta},{s.Staatus},{s.Hinnang.ToString(CultureInfo.InvariantCulture)},{s.HooaegadeArv}");
                        else if (m is Dokumentaalfilm d)
                            sw.WriteLine($"Dokumentaal,{d.Pealkiri},{d.Aasta},{d.Staatus},{d.Hinnang.ToString(CultureInfo.InvariantCulture)},{d.Teema}");
                        else if (m is Multikas mu)
                            sw.WriteLine($"Multikas,{mu.Pealkiri},{mu.Aasta},{mu.Staatus},{mu.Hinnang.ToString(CultureInfo.InvariantCulture)},{mu.Sihtrühm}");
                        else if (m is Telesaade t)
                            sw.WriteLine($"Telesaade,{t.Pealkiri},{t.Aasta},{t.Staatus},{t.Hinnang.ToString(CultureInfo.InvariantCulture)},{t.Saatejuht}");
                    }
                }
                PrintSuccess($"Salvestatud {list.Count} objekti → meedia.txt");
            }
            catch (Exception ex) { PrintError($"Viga salvestamisel: {ex.Message}"); }
            Pause();
        }

        public static void LaeFailist(List<Meedia> list)
        {
            if (!File.Exists("meedia.txt")) return;
            try
            {
                var lines = File.ReadAllLines("meedia.txt");
                foreach (var line in lines)
                {
                    var p = line.Split(',');
                    if (p.Length < 6) continue;
                    string tüüp = p[0];
                    string nimi = p[1];
                    int aasta = int.Parse(p[2]);
                    string stat = p[3];
                    double hinnang = double.Parse(p[4], CultureInfo.InvariantCulture);
                    switch (tüüp)
                    {
                        case "Film":
                            list.Add(new Film
                            {
                                Pealkiri = nimi,
                                Aasta = aasta,
                                Staatus = stat,
                                KestusMinutites = int.Parse(p[5]),
                                Hinnang = hinnang
                            }); break;
                        case "Seriaal":
                            list.Add(new Seriaal
                            {
                                Pealkiri = nimi,
                                Aasta = aasta,
                                Staatus = stat,
                                HooaegadeArv = int.Parse(p[5]),
                                Hinnang = hinnang
                            }); break;
                        case "Dokumentaal":
                            list.Add(new Dokumentaalfilm
                            {
                                Pealkiri = nimi,
                                Aasta = aasta,
                                Staatus = stat,
                                Teema = p[5],
                                Hinnang = hinnang
                            }); break;
                        case "Multikas":
                            list.Add(new Multikas
                            {
                                Pealkiri = nimi,
                                Aasta = aasta,
                                Staatus = stat,
                                Sihtrühm = p[5],
                                Hinnang = hinnang
                            }); break;
                        case "Telesaade":
                            list.Add(new Telesaade
                            {
                                Pealkiri = nimi,
                                Aasta = aasta,
                                Staatus = stat,
                                Saatejuht = p[5],
                                Hinnang = hinnang
                            }); break;
                    }
                }
            }
            catch { }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  SISENDI ABIFUNKTSIOONID
        // ══════════════════════════════════════════════════════════════════════

        private static string ReadInput(string label)
        {
            Console.Write("  "); W();
            Console.Write($"{label}: ");
            string val = Console.ReadLine() ?? "";
            R();
            return val.Trim();
        }

        private static int ReadInt(string label, int min, int max)
        {
            while (true)
            {
                string raw = ReadInput($"{label} ({min}-{max})");
                if (int.TryParse(raw, out int val) && val >= min && val <= max)
                    return val;
                PrintError($"Palun sisesta arv vahemikus {min}-{max}.");
            }
        }

        private static double ReadHinnang()
        {
            while (true)
            {
                string raw = ReadInput("Hinnang (0.0 - 5.0)");
                if (double.TryParse(raw.Replace(',', '.'), NumberStyles.Any,
                                    CultureInfo.InvariantCulture, out double val)
                    && val >= 0 && val <= 5)
                    return Math.Round(val, 1);
                PrintError("Hinnang peab olema 0 kuni 5 (nt 4.5).");
            }
        }

        private static string ReadStatuus()
        {
            Console.WriteLine();
            Console.Write("  "); W(); Console.Write("Staatus:  ");
            Y(); Console.Write("1"); W(); Console.Write("=vaatamata  ");
            Y(); Console.Write("2"); W(); Console.Write("=vaatan  ");
            Y(); Console.Write("3"); W(); Console.WriteLine("=vaadatud");
            R();
            while (true)
            {
                string raw = ReadInput("Vali (1-3)");
                if (raw == "1") return "vaatamata";
                if (raw == "2") return "vaatan";
                if (raw == "3") return "vaadatud";
                PrintError("Vali 1, 2 või 3.");
            }
        }

        private static bool OnOlemas(List<Meedia> list, string nimi)
        {
            if (list.Any(x => x.Pealkiri.ToLower() == nimi.ToLower()))
            {
                PrintError($"'{nimi}' on juba nimekirjas!");
                Pause();
                return true;
            }
            return false;
        }

        // ══════════════════════════════════════════════════════════════════════
        //  VÄRVIDE ABIFUNKTSIOONID
        // ══════════════════════════════════════════════════════════════════════

        private static ConsoleColor TypeColor(Meedia m) => m switch
        {
            Film => ConsoleColor.Cyan,
            Seriaal => ConsoleColor.Green,
            Dokumentaalfilm => ConsoleColor.Yellow,
            Multikas => ConsoleColor.Magenta,
            Telesaade => ConsoleColor.DarkYellow,
            _ => ConsoleColor.Gray
        };

        private static string TypeLabel(Meedia m) => m switch
        {
            Film => "Film",
            Seriaal => "Seriaal",
            Dokumentaalfilm => "Dokumentaal",
            Multikas => "Multikas",
            Telesaade => "Telesaade",
            _ => "?"
        };

        private static ConsoleColor StatusColor(string staatus) => staatus?.ToLower() switch
        {
            "vaadatud" => ConsoleColor.Green,
            "vaatan" => ConsoleColor.Yellow,
            "vaatamata" => ConsoleColor.DarkGray,
            _ => ConsoleColor.White
        };

        // Lühikesed abid värvimiseks
        private static void W() => Console.ForegroundColor = ConsoleColor.White;
        private static void Y() => Console.ForegroundColor = ConsoleColor.Yellow;
        private static void G() => Console.ForegroundColor = ConsoleColor.DarkGray;
        private static void R() => Console.ResetColor();
        private static void SetColor(ConsoleColor c) => Console.ForegroundColor = c;

        private static void PrintSuccess(string msg)
        {
            Console.WriteLine();
            Console.Write("  "); G();
            Console.WriteLine(msg); R();
        }

        private static void PrintError(string msg)
        {
            Console.WriteLine();
            Console.Write("  ");
            SetColor(ErrorColor);
            Console.WriteLine($"! {msg}"); R();
        }

        private static void PrintSectionTitle(string title)
        {
            Y();
            Console.WriteLine($"  ── {title} " + new string('─', Math.Max(0, 38 - title.Length)));
            R(); Console.WriteLine();
        }

        private static void PrintVälju()
        {
            Console.Clear(); PrintHeader();
            Console.WriteLine();
            Y(); Console.WriteLine("  Head aega!");
            G(); Console.WriteLine("  (Tulge jälle külla - meedia ootab!)");
            R(); Console.WriteLine();
        }

        private static void Pause()
        {
            Console.WriteLine();
            G(); Console.Write("  [Vajuta ENTER jätkamiseks...]"); R();
            Console.ReadLine();
        }
    }
}