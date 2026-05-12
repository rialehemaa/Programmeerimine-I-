using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace Soidukid
{
    /// <summary>
    /// Menu klass – sisaldab kogu kasutajaliidest:
    /// sisselogimist, pohimenüüd, soidukite lisamist,
    /// kustutamist, tulemuste kuvamist ja faili salvestamist.
    /// </summary>
    class Menu
    {
        private readonly KasutajaHaldur haldur;

        // Iga kasutaja soidukid salvestatakse eraldi faili: soidukid_<nimi>.txt
        private static string SoidukiFail(string kasutaja) =>
            $"soidukid_{kasutaja.ToLower()}.txt";

        public Menu(KasutajaHaldur haldur)
        {
            this.haldur = haldur;
        }

        // Peatsükkel – käivitatakse Program.cs-st
        public void Kaivita()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("TRANSPORDI JAGAMINE");
                Console.WriteLine();

                string? kasutaja = SisslogimiseMenu();
                if (kasutaja == null) break;

                var soidukid = new List<ISoiduk>();
                LaeFailist(soidukid, SoidukiFail(kasutaja));

                PohiMenu(soidukid, kasutaja);

                SalvestaFaili(soidukid, SoidukiFail(kasutaja));
            }

            Console.WriteLine("Head aega!");
        }

        // ── Sisselogimise menu ────────────────────────────────────────────────
        // Tagastab kasutajanime voi null kui vaeljutakse

        private string? SisslogimiseMenu()
        {
            while (true)
            {
                Console.WriteLine("Palun valige:");
                Console.WriteLine("1 -> Logi sisse");
                Console.WriteLine("2 -> Registreeru");
                Console.WriteLine("0 -> Valju");
                Console.WriteLine();

                string valik = LoeRida("Valik");

                switch (valik)
                {
                    case "1":
                        {
                            string nimi = LoeRida("Kasutajanimi");
                            string parool = LoeParool("Parool");

                            if (haldur.Logi(nimi, parool))
                            {
                                Console.WriteLine($"Tere, {nimi}!");
                                Console.WriteLine();
                                return nimi;
                            }
                            Console.WriteLine("! Vale kasutajanimi voi parool.");
                            Console.WriteLine();
                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine();
                            Console.WriteLine("-- Uue kasutaja registreerimine --");
                            string nimi = LoeRida("Vali kasutajanimi");

                            if (haldur.OnOlemas(nimi))
                            {
                                Console.WriteLine($"! Kasutajanimi '{nimi}' on juba voetud.");
                                Console.WriteLine();
                                break;
                            }

                            string parool = LoeParool("Vali parool (min 3 tahemarki)");
                            if (parool.Length < 3)
                            {
                                Console.WriteLine("! Parool peab olema vahemalt 3 tahemarki pikk.");
                                Console.WriteLine();
                                break;
                            }

                            string kinnitus = LoeParool("Korda parooli");
                            if (parool != kinnitus)
                            {
                                Console.WriteLine("! Paroolid ei klapi.");
                                Console.WriteLine();
                                break;
                            }

                            haldur.Registreeri(nimi, parool);
                            Console.WriteLine($"Kasutaja '{nimi}' registreeritud.");
                            Console.WriteLine();
                            return nimi;
                        }

                    case "0":
                        return null;

                    default:
                        Console.WriteLine("! Vale valik.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        // ── Pohimenu ─────────────────────────────────────────────────────────

        private void PohiMenu(List<ISoiduk> soidukid, string kasutaja)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Kasutaja: {kasutaja}   Soidukeid: {soidukid.Count}");
                Console.WriteLine();
                Console.WriteLine("Mida soovite teha?");
                Console.WriteLine();
                Console.WriteLine("1 -> Lisa auto");
                Console.WriteLine("2 -> Lisa veoauto");//грузовик
                Console.WriteLine("3 -> Lisa elektritoeukeratas");//електросамокат
                Console.WriteLine("4 -> Lisa mootorratas");//мотоцикл
                Console.WriteLine("5 -> Kuva tulemused");
                Console.WriteLine("6 -> Kustuta soiduk");
                Console.WriteLine("0 -> Logi valja");
                Console.WriteLine();

                string valik = LoeRida("Valik");

                switch (valik)
                {
                    case "1": LisaAutoJarjest(soidukid); break;
                    case "2": LisaVeoautoJarjest(soidukid); break;
                    case "3": LisaElektritoeukeratosJarjest(soidukid); break;
                    case "4": LisaMootoratosJarjest(soidukid); break;
                    case "5": KuvaTulemused(soidukid); break;
                    case "6": KustutaSoiduk(soidukid); break;
                    case "0":
                        SalvestaFaili(soidukid, SoidukiFail(kasutaja));
                        Console.WriteLine($"Andmed salvestatud. Head aega, {kasutaja}!");
                        return;
                    default:
                        Console.WriteLine("! Vale valik.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        // ── Soidukite lisamine ────────────────────────────────────────────────

        private void LisaAutoJarjest(List<ISoiduk> list)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("-- Auto lisamine --");
                string mark = LoeRida("Mark (nt Toyota Corolla)");
                double km = LoeDouble("Vahemaa (km)", 0.1, 100000);
                double kytusKm = LoeDouble("Kuetusekulu (l/100km)", 0.1, 50);
                double hind = LoeDouble("Kuetuse hind (EUR/l)", 0.01, 5);
                list.Add(new Auto(mark, km, kytusKm, hind));
                Console.WriteLine("Auto lisatud.");
                Console.WriteLine();
            } while (JatkaTsukkel("Lisa veel uks auto?"));
        }

        private void LisaVeoautoJarjest(List<ISoiduk> list)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("-- Veoauto lisamine --");
                string mark = LoeRida("Mark (nt Volvo FH)");
                double km = LoeDouble("Vahemaa (km)", 0.1, 100000);
                double kytusKm = LoeDouble("Kuetusekulu (l/100km)", 1, 100);
                double hind = LoeDouble("Kuetuse hind (EUR/l)", 0.01, 5);
                double koormus = LoeDouble("Koormus (tonnides)", 0.1, 50);
                list.Add(new Veoauto(mark, km, kytusKm, hind, koormus));
                Console.WriteLine("Veoauto lisatud.");
                Console.WriteLine();
            } while (JatkaTsukkel("Lisa veel uks veoauto?"));
        }

        private void LisaElektritoeukeratosJarjest(List<ISoiduk> list)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("-- Elektritoeukeratas lisamine --");
                string mudel = LoeRida("Mudel (nt Xiaomi Pro 2)");
                double km = LoeDouble("Vahemaa (km)", 0.1, 10000);
                double kWh = LoeDouble("Energiatarve (kWh/100km)", 0.1, 30);
                double hind = LoeDouble("Elektri hind (EUR/kWh)", 0.01, 2);
                list.Add(new Elektritoeukeratas(mudel, km, kWh, hind));
                Console.WriteLine("Elektritoeukeratas lisatud.");
                Console.WriteLine();
            } while (JatkaTsukkel("Lisa veel uks elektritoeukeratas?"));
        }

        private void LisaMootoratosJarjest(List<ISoiduk> list)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("-- Mootorratas lisamine --");
                string mark = LoeRida("Mark (nt Honda CB500)");
                double km = LoeDouble("Vahemaa (km)", 0.1, 100000);
                double kytusKm = LoeDouble("Kuetusekulu (l/100km)", 0.1, 30);
                double hind = LoeDouble("Kuetuse hind (EUR/l)", 0.01, 5);
                list.Add(new Mootorratas(mark, km, kytusKm, hind));
                Console.WriteLine("Mootorratas lisatud.");
                Console.WriteLine();
            } while (JatkaTsukkel("Lisa veel uks mootorratas?"));
        }

        // ── Soiduki kustutamine ───────────────────────────────────────────────
        // Naaitab nimekirja ja kysib, millise numbri kasutaja soovib kustutada

        private void KustutaSoiduk(List<ISoiduk> list)
        {
            Console.WriteLine();

            if (list.Count == 0)
            {
                Console.WriteLine("Nimekiri on tuhi, midagi pole kustutada.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Nimekiri:");
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{i + 1,2}. {list[i]}");

            Console.WriteLine();

            int nr = LoeInt("Kustuta number", 1, list.Count);
            string kustutatud = list[nr - 1].ToString() ?? "";
            list.RemoveAt(nr - 1);

            Console.WriteLine($"Kustutatud: {kustutatud}");
            Console.WriteLine();
        }

        // ── Tulemuste kuvamine ────────────────────────────────────────────────

        private void KuvaTulemused(List<ISoiduk> list)
        {
            Console.WriteLine();
            Console.WriteLine("TULEMUSED:");
            Console.WriteLine();

            if (list.Count == 0)
            {
                Console.WriteLine("(nimekiri on tuhi)");
                Console.WriteLine();
                Console.Write("[Vajuta ENTER jatkamiseks...]");
                Console.ReadLine();
                return;
            }

            double koguKulu = 0;
            int i = 1;
            foreach (ISoiduk s in list)
            {
                Console.WriteLine($"{i,2}. {s}");  // kutsub ToString()
                koguKulu += s.ArvutaKulu();
                i++;
            }

            Console.WriteLine();
            Console.WriteLine($"KOKKU KULU: {koguKulu:F2} EUR");
            Console.WriteLine();
            Console.Write("[Vajuta ENTER jatkamiseks...]");
            Console.ReadLine();
        }

        // ── Failist laadimine ─────────────────────────────────────────────────
        // Vorming: tuuep;parameeter1;parameeter2;...

        private void LaeFailist(List<ISoiduk> list, string fail)
        {
            if (!File.Exists(fail)) return;
            try
            {
                int count = 0;
                foreach (var rida in File.ReadAllLines(fail))
                {
                    if (string.IsNullOrWhiteSpace(rida)) continue;
                    var p = rida.Split(';');

                    switch (p[0].Trim().ToLower())
                    {
                        case "auto":
                            list.Add(new Auto(p[1], Parse(p[2]), Parse(p[3]), Parse(p[4])));
                            count++; break;
                        case "veoauto":
                            list.Add(new Veoauto(p[1], Parse(p[2]), Parse(p[3]), Parse(p[4]), Parse(p[5])));
                            count++; break;
                        case "elektritoeukeratas":
                            list.Add(new Elektritoeukeratas(p[1], Parse(p[2]), Parse(p[3]), Parse(p[4])));
                            count++; break;
                        case "mootorratas":
                            list.Add(new Mootorratas(p[1], Parse(p[2]), Parse(p[3]), Parse(p[4])));
                            count++; break;
                    }
                }
                if (count > 0)
                    Console.WriteLine($"Laaditud {count} soeidukit failist '{fail}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"! Viga faili lugemisel: {ex.Message}");
            }
        }

        // ── Faili salvestamine ────────────────────────────────────────────────
        // Kasutab ToCsvRow() meetodit igalt soidukilt

        private void SalvestaFaili(List<ISoiduk> list, string fail)
        {
            try
            {
                var read = new List<string>();
                foreach (var s in list)
                {
                    string rida = s switch
                    {
                        Auto a => a.ToCsvRow(),
                        Veoauto v => v.ToCsvRow(),
                        Elektritoeukeratas e => e.ToCsvRow(),
                        Mootorratas m => m.ToCsvRow(),
                        _ => ""
                    };
                    if (!string.IsNullOrEmpty(rida)) read.Add(rida);
                }
                File.WriteAllLines(fail, read);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"! Viga faili salvestamisel: {ex.Message}");
            }
        }

        // ── Abimeetodid ───────────────────────────────────────────────────────

        // Kysib kasutajalt kinnitust (j/e)
        private bool JatkaTsukkel(string kysimus)
        {
            Console.Write($"{kysimus} (j/e): ");
            string v = (Console.ReadLine() ?? "").Trim().ToLower();
            Console.WriteLine();
            return v == "j";
        }

        // Loeb parooli ilma ekraanil kuvamata (tarnid)
        private string LoeParool(string silt)
        {
            Console.Write($"{silt}: ");
            var sb = new System.Text.StringBuilder();
            while (true)
            {
                var k = Console.ReadKey(intercept: true);
                if (k.Key == ConsoleKey.Enter) break;
                if (k.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0) { sb.Remove(sb.Length - 1, 1); Console.Write("\b \b"); }
                }
                else
                {
                    sb.Append(k.KeyChar);
                    Console.Write('*');
                }
            }
            Console.WriteLine();
            return sb.ToString();
        }

        // Loeb mittetyhja tekstirida
        private string LoeRida(string silt)
        {
            while (true)
            {
                Console.Write($"{silt}: ");
                string? val = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(val)) return val;
                Console.WriteLine("! Vaeli ei tohi olla tuhi.");
            }
        }

        // Loeb arvu maaratud vahemikus, aktsepteerib koma ja punkti
        private double LoeDouble(string silt, double min, double max)
        {
            while (true)
            {
                Console.Write($"{silt} ({min}-{max}): ");
                string? raw = Console.ReadLine()?.Replace(',', '.');
                if (double.TryParse(raw, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double val)
                    && val >= min && val <= max)
                    return val;
                Console.WriteLine($"! Palun sisesta arv vahemikus {min}-{max}.");
            }
        }

        // Loeb taisarvu maaratud vahemikus
        private int LoeInt(string silt, int min, int max)
        {
            while (true)
            {
                Console.Write($"{silt} ({min}-{max}): ");
                string? raw = Console.ReadLine();
                if (int.TryParse(raw, out int val) && val >= min && val <= max)
                    return val;
                Console.WriteLine($"! Palun sisesta taiesarv vahemikus {min}-{max}.");
            }
        }

        // Parsib double'i InvariantCulture'iga
        private double Parse(string s) =>
            double.Parse(s.Trim(), CultureInfo.InvariantCulture);
    }
}