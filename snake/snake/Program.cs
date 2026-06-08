using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Ussimang";

            while (true)
            {
                int valik = KuvaPohinenu();

                if (valik == 1)
                {
                    int tase = KuvaRaskusmenuu();
                    MängiMängu(tase);
                }
                else if (valik == 2)
                {
                    Console.Clear();
                    Edetabel.KuvaEdetabel();
                    Console.WriteLine("\nVajuta Enter...");
                    Console.ReadLine();
                }
                else if (valik == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Nagemist!");
                    Thread.Sleep(800);
                    return;
                }
            }
        }

        // =====================
        //      PEAMENÜÜ
        // =====================
        static int KuvaPohinenu()
        {
            // Taastame akna suuruse menüü jaoks
            try { Console.SetWindowSize(50, 25); } catch { }

            int valitud = 1;
            ConsoleKey klahv;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("  ██╗   ██╗███████╗███████╗");
                Console.WriteLine("  ██║   ██║██╔════╝██╔════╝");
                Console.WriteLine("  ██║   ██║███████╗███████╗");
                Console.WriteLine("  ██║   ██║╚════██║╚════██║");
                Console.WriteLine("  ╚██████╔╝███████║███████║");
                Console.WriteLine("   ╚═════╝ ╚══════╝╚══════╝");
                Console.WriteLine("        U S S I M A N G");
                Console.WriteLine();

                Console.WriteLine("   +============================+");

                string[] punktid = { "Alusta mangu", "Edetabel", "Valju" };
                for (int i = 0; i < punktid.Length; i++)
                {
                    if (i + 1 == valitud)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"   |  >>> {punktid[i],-22}|");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   |      {punktid[i],-22}|");
                    }
                }

                Console.WriteLine("   +============================+");
                Console.WriteLine();

                klahv = Console.ReadKey(true).Key;
                if (klahv == ConsoleKey.UpArrow && valitud > 1) valitud--;
                else if (klahv == ConsoleKey.DownArrow && valitud < 3) valitud++;

            } while (klahv != ConsoleKey.Enter);

            return valitud;
        }

        // =====================
        //   RASKUSASTE MENÜÜ
        // =====================
        static int KuvaRaskusmenuu()
        {
            int valitud = 1;
            ConsoleKey klahv;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("   +============================+");
                Console.WriteLine("   |      VALI RASKUSASTE       |");
                Console.WriteLine("   +============================+");

                string[] tasemed = { "Lihtne   (aeglane) ", "Keskmine (normaalne)", "Raske    (kiire)   " };
                for (int i = 0; i < tasemed.Length; i++)
                {
                    if (i + 1 == valitud)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"   |  >>> {tasemed[i],-22}|");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   |      {tasemed[i],-22}|");
                    }
                }

                Console.WriteLine("   +============================+");
                Console.WriteLine();

                klahv = Console.ReadKey(true).Key;
                if (klahv == ConsoleKey.UpArrow && valitud > 1) valitud--;
                else if (klahv == ConsoleKey.DownArrow && valitud < 3) valitud++;

            } while (klahv != ConsoleKey.Enter);

            return valitud;
        }

        // =====================
        //      MÄNGU LOOGIKA
        // =====================
        static void MängiMängu(int tase)
        {
            MänguSeaded seaded = new MänguSeaded(tase);

            // OLULINE: kõigepealt buffer, siis aken, siis ootame, siis Clear
            try
            {
                Console.SetBufferSize(seaded.Laius + 2, seaded.Kõrgus + 3);
                Console.SetWindowSize(seaded.Laius + 2, seaded.Kõrgus + 3);
            }
            catch { }

            Thread.Sleep(200);
            Console.Clear();
            Thread.Sleep(50);
            Console.CursorVisible = false;

            // offsetY = 1: rida 0 on infopaneel, mäng algab reast 1
            Kaart kaart = new Kaart(seaded.Laius, seaded.Kõrgus, offsetY: 1);
            Uss uss = new Uss(seaded.Laius / 2, seaded.Kõrgus / 2 + 1, 3);
            Toit toit = new Toit(seaded.Laius, seaded.Kõrgus, offsetY: 1);

            int skoor = 0;
            int elud = 3;

            kaart.Joonista();
            UuendaInfopaneel(skoor, elud, seaded.Laius);

            // MÄNGU TSÜKKEL
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klahv = Console.ReadKey(true);

                    if (klahv.Key == ConsoleKey.UpArrow && uss.PraeguneSuund != Suund.Alla)
                        uss.PraeguneSuund = Suund.Üles;
                    else if (klahv.Key == ConsoleKey.DownArrow && uss.PraeguneSuund != Suund.Üles)
                        uss.PraeguneSuund = Suund.Alla;
                    else if (klahv.Key == ConsoleKey.LeftArrow && uss.PraeguneSuund != Suund.Paremale)
                        uss.PraeguneSuund = Suund.Vasakule;
                    else if (klahv.Key == ConsoleKey.RightArrow && uss.PraeguneSuund != Suund.Vasakule)
                        uss.PraeguneSuund = Suund.Paremale;
                    else if (klahv.Key == ConsoleKey.Escape)
                        break;
                }

                uss.Liigu();
                Punkt pea = uss.HangiPea();

                // Kokkupõrge seinaga või iseendaga
                if (kaart.OnKokkupõrge(pea) || uss.OnHammustandItennast())
                {
                    Heliefektid.MängiKaotust();
                    elud--;
                    UuendaInfopaneel(skoor, elud, seaded.Laius);

                    if (elud <= 0) break;

                    // Veel elusid - taaskäivitame ussi
                    Thread.Sleep(800);
                    Console.Clear();
                    kaart.Joonista();
                    uss = new Uss(seaded.Laius / 2, seaded.Kõrgus / 2 + 1, 3);
                    toit.LooUusToit();
                    UuendaInfopaneel(skoor, elud, seaded.Laius);
                    continue;
                }

                // Toidu söömine
                if (pea.X == toit.Asukoht.X && pea.Y == toit.Asukoht.Y)
                {
                    skoor += 10;
                    uss.Kasva();
                    toit.LooUusToit();
                    Heliefektid.MängiSöömist();
                    UuendaInfopaneel(skoor, elud, seaded.Laius);
                }

                int kiirus = Math.Max(50, seaded.KiirusMS - (skoor / 50) * 10);
                Thread.Sleep(kiirus);
            }

            // MÄNGU LÕPP - taastame akna suuruse ENNE kuvamist
            try
            {
                Console.SetBufferSize(50, 25);
                Console.SetWindowSize(50, 25);
            }
            catch { }

            Thread.Sleep(200);
            Console.Clear();
            Thread.Sleep(50);
            Console.CursorVisible = false;

            Console.WriteLine();
            Console.WriteLine("   +============================+");
            Console.WriteLine("   |        MANG LABI!          |");
            Console.WriteLine($"   |   Sinu skoor: {skoor,-13}|");
            Console.WriteLine("   +============================+");
            Console.WriteLine();
            Console.CursorVisible = true;
            Console.Write("   Sisesta oma nimi: ");
            string nimi = Console.ReadLine();
            Console.CursorVisible = false;

            if (!string.IsNullOrEmpty(nimi))
            {
                Edetabel.Salvesta(nimi, skoor);
            }
        }

        // Uuendab infopaneeli (rida 0) - skoor vasakul, elud paremal
        static void UuendaInfopaneel(int skoor, int elud, int laius)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', laius + 2));

            Console.SetCursorPosition(1, 0);
            Console.Write($"Skoor: {skoor}");

            // Elud: tärnid = elusid järel, miinused = kaotatud
            string eludTekst = $"Elud: {new string('*', elud)}{new string('-', 3 - elud)}";
            Console.SetCursorPosition(laius - eludTekst.Length, 0);
            Console.Write(eludTekst);
        }
    }
}