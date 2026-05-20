using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Loomaaia
{
    internal static class FailiTootlus
    {
        private static string path = "loomad.txt";

        // Salvestame kõik loomad faili loomad.txt
        // Vorming: Lovi;Simba;180;3 või Elevant;Dumbo;3500;1.5;10 või Ahv;Koku;8;2
        internal static void SalvestaLoomad(List<ILoom> loomad)
        {
            try
            {
                List<string> read = new List<string>();

                foreach (ILoom loom in loomad)
                {
                    if (loom is Lovi l)
                    {
                        read.Add($"Lovi;{l.Nimi};{l.Kaal};{l.Vanus}");
                    }
                    else if (loom is Elevant e)
                    {
                        read.Add($"Elevant;{e.Nimi};{e.Kaal};{e.KihvadePikkus};{e.Vanus}");
                    }
                    else if (loom is Ahv a)
                    {
                        read.Add($"Ahv;{a.Nimi};{a.BanaanideArvPaevas};{a.Vanus}");
                    }
                }

                File.WriteAllLines(path, read);
                Console.WriteLine("Loomad on salvestatud faili loomad.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga loomad.txt. Palun vaadake üles ja veenduge et kõik oleks korras.");
            }
        }

        // Laeme loomad failist tagasi mällu
        internal static List<ILoom> LaeLoomad()
        {
            List<ILoom> loomad = new List<ILoom>();

            if (!File.Exists(path))
            {
                return loomad;
            }

            try
            {
                string[] read = File.ReadAllLines(path);

                foreach (string rida in read)
                {
                    if (string.IsNullOrWhiteSpace(rida))
                    {
                        continue;
                    }

                    string[] osad = rida.Split(';');

                    switch (osad[0])
                    {
                        case "Lovi":
                            if (double.TryParse(osad[2], out double loviKaal) &&
                                int.TryParse(osad[3], out int loviVanus))
                            {
                                loomad.Add(new Lovi(osad[1], loviKaal, loviVanus));
                            }
                            break;

                        case "Elevant":
                            if (double.TryParse(osad[2], out double elevantKaal) &&
                                double.TryParse(osad[3], out double kihvad) &&
                                int.TryParse(osad[4], out int elevantVanus))
                            {
                                loomad.Add(new Elevant(osad[1], elevantKaal, kihvad, elevantVanus));
                            }
                            break;

                        case "Ahv":
                            if (int.TryParse(osad[2], out int banaanid) &&
                                int.TryParse(osad[3], out int ahvVanus))
                            {
                                loomad.Add(new Ahv(osad[1], banaanid, ahvVanus));
                            }
                            break;
                    }
                }

                if (loomad.Count > 0)
                {
                    Console.WriteLine($"Laaditud {loomad.Count} looma failist loomad.txt");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga faili lugemisel. Palun kontrolli faili sisu.");
            }

            return loomad;
        }
    }
}