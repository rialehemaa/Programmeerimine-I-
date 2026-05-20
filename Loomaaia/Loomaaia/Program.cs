using Loomaaia;
using System;
using System.Collections.Generic;
using System.Text;

// lühike selgitus: 
// Lisasin igale loomale kaks uut omadust: Nimi (string) ja Vanus (int).
// Kasutaja saab looma lisamisel talle nime anda ja vanuse sisestada.
// Kui loom on alla 1 aasta vana, sööb ta piimasegu (0.5 kg päevas).
// Nimi ja vanus salvestatakse faili loomad.txt ja kuvatakse KuvaInfo() meetodis.

namespace Loomaaia
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Laeme varasemad loomad failist käivitumisel
            List<ILoom> loomad = FailiTootlus.LaeLoomad();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("LOOMAAIA TOIDUKALKULAATOR   ");
                Console.WriteLine();
                Console.WriteLine("1 --- Lisa Lõvi");
                Console.WriteLine("2 --- Lisa Elevant");
                Console.WriteLine("3 --- Lisa Ahv");
                Console.WriteLine("4 --- Kuva statistika");
                Console.WriteLine("0 --- Lõpeta ja kuva kokkuvõte");
                Console.WriteLine();
                Console.Write("Sinu valitud number: ");

                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        LisaLovi(loomad);
                        break;

                    case "2":
                        LisaElevant(loomad);
                        break;

                    case "3":
                        LisaAhv(loomad);
                        break;

                    case "4":
                        KuvaStatistika(loomad);
                        break;

                    case "0":
                        // Salvestame enne lõppu kõik loomad faili
                        FailiTootlus.SalvestaLoomad(loomad);

                        Console.WriteLine();
                        Console.WriteLine("LÕPPARUANNE");
                        Console.WriteLine();

                        double koguSumma = 0;
                        double lihaSumma = 0;
                        double taimneSumma = 0;

                        foreach (ILoom loom in loomad)
                        {
                            loom.KuvaInfo();
                            double vajadus = loom.ArvutaToiduvajadus();
                            koguSumma = koguSumma + vajadus;

                            if (loom.ToiduTuup == "Liha")
                            {
                                lihaSumma = lihaSumma + vajadus;
                            }
                            else
                            {
                                taimneSumma = taimneSumma + vajadus;
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Kogu liha vajadus: {lihaSumma} kg");
                        Console.WriteLine($"Kogu taimse toidu vajadus: {taimneSumma} kg");
                        Console.WriteLine();
                        Console.WriteLine($"KOGU LOOMAAIA PÄEVANE TOIDUVAJADUS ON: {koguSumma} kg.");
                        Console.WriteLine();
                        Console.WriteLine("Vajuta Enter, et sulgeda...");
                        Console.ReadLine();
                        return;

                    default:
                        Console.WriteLine("Tundmatu valik. Vajuta Enter...");
                        Console.ReadLine();
                        continue;
                }

                Console.WriteLine("\nVajuta Enter, et menüüsse tagasi minna...");
                Console.ReadLine();
            }

            // ── Loomade lisamise meetodid ──────────────────────────────────────────

            static void LisaLovi(List<ILoom> loomad)
            {
                Console.Clear();
                Console.WriteLine("Lisa Lõvi\n");

                Console.Write("Sisesta lõvi nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Sisesta lõvi kaal (kg): ");
                if (!double.TryParse(Console.ReadLine(), out double kaal))
                {
                    Console.WriteLine(" Vigane sisend! Määran vaikimisi kaaluks 150 kg.");
                    kaal = 150;
                }

                Console.Write("Sisesta lõvi vanus (aastates): ");
                if (!int.TryParse(Console.ReadLine(), out int vanus))
                {
                    Console.WriteLine(" Vigane vanus! Määran vaikimisi 2.");
                    vanus = 2;
                }

                Lovi lovi = new Lovi(nimi, kaal, vanus);
                loomad.Add(lovi);
                Console.WriteLine($" {nimi} lisatud! Toiduvajadus: {lovi.ArvutaToiduvajadus()} kg/päev");
            }

            static void LisaElevant(List<ILoom> loomad)
            {
                Console.Clear();
                Console.WriteLine("Lisa Elevant\n");

                Console.Write("Sisesta elevandi nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Sisesta elevandi kaal (kg): ");
                if (!double.TryParse(Console.ReadLine(), out double kaal))
                {
                    Console.WriteLine(" Vigane sisend! Määran vaikimisi kaaluks 2000 kg.");
                    kaal = 2000;
                }

                Console.Write("Sisesta kihvade pikkus (m): ");
                if (!double.TryParse(Console.ReadLine(), out double kihvad))
                {
                    Console.WriteLine(" Vigane sisend! Määran kihvade pikkuseks 0.");
                    kihvad = 0;
                }

                Console.Write("Sisesta elevandi vanus (aastates): ");
                if (!int.TryParse(Console.ReadLine(), out int vanus))
                {
                    Console.WriteLine(" Vigane vanus! Määran vaikimisi 5.");
                    vanus = 5;
                }

                Elevant elevant = new Elevant(nimi, kaal, kihvad, vanus);
                loomad.Add(elevant);
                Console.WriteLine($" {nimi} lisatud! Toiduvajadus: {elevant.ArvutaToiduvajadus()} kg/päev");
            }

            static void LisaAhv(List<ILoom> loomad)
            {
                Console.Clear();
                Console.WriteLine("Lisa Ahv\n");

                Console.Write("Sisesta ahvi nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Sisesta banaanide arv päevas: ");
                if (!int.TryParse(Console.ReadLine(), out int banaanid))
                {
                    Console.WriteLine(" Vigane sisend! Määran vaikimisi 5 banaani.");
                    banaanid = 5;
                }

                Console.Write("Sisesta ahvi vanus (aastates): ");
                if (!int.TryParse(Console.ReadLine(), out int vanus))
                {
                    Console.WriteLine(" Vigane vanus! Määran vaikimisi 2.");
                    vanus = 2;
                }

                Ahv ahv = new Ahv(nimi, banaanid, vanus);
                loomad.Add(ahv);
                Console.WriteLine($" {nimi} lisatud! Toiduvajadus: {ahv.ArvutaToiduvajadus()} kg/päev");
            }


            static void KuvaStatistika(List<ILoom> loomad)
            {
                Console.Clear();
                Console.WriteLine("STATISTIKA");
                Console.WriteLine();

                // Kontrollime et loomaaias on üldse loomi
                if (loomad.Count == 0)
                {
                    Console.WriteLine("Loomaaias pole veel ühtegi looma!");
                    return;
                }

                // LINQ - suurima toiduvajadusega loom
                ILoom suurimSoodik = loomad.OrderByDescending(l => l.ArvutaToiduvajadus()).First();
                Console.WriteLine($" Kõige suurem söödik:");
                suurimSoodik.KuvaInfo();

                Console.WriteLine();

                // LINQ - väiksema toiduvajadusega loom
                ILoom vaiksemSoodik = loomad.OrderBy(l => l.ArvutaToiduvajadus()).First();
                Console.WriteLine($" Kõige väiksem söödik:");
                vaiksemSoodik.KuvaInfo();

                Console.WriteLine();

                // LINQ - keskmine toidukulu
                double keskmine = loomad.Average(l => l.ArvutaToiduvajadus());
                Console.WriteLine($" Loomade keskmine toidukulu: {Math.Round(keskmine, 2)} kg/päev");
            }

        }
    }
}

