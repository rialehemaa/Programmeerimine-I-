using System;
using System.Collections.Generic;
using System.Text;

namespace Kontrolltöö
    {
       internal class StartPage
        {
        public static void Main(string[] args)
        {
            Menuu();
        }
        public static void Menuu()
            {
             bool run = true; 
             while (run)
                {
                    Console.WriteLine("\nMenuu");
                    Console.WriteLine("1 - Kirjuta logi");
                    Console.WriteLine("2 - Riigi otsing");
                    Console.WriteLine("3 - Loe ja arvuta");
                    Console.WriteLine("4 - Halda autosid");
                    Console.WriteLine("0 - Valju");

                    string v = Console.ReadLine();

                    switch (v)
                    {
                        case "1":
                            AndmeFunktsioonid.KirjutaLogi("Kasutaja logis sisse");
                            break;

                        case "2":
                            AndmeFunktsioonid.RiigiOtsing();
                            break;

                        case "3":
                            var result = AndmeFunktsioonid.LoeJaArvuta("arvud.txt");
                            Console.WriteLine($"Summa: {result.Item1}, Keskmine: {result.Item2}");
                            break;

                        case "4":
                            AndmeFunktsioonid.HaldaAutosid();
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Vale valik!");
                            break;
                    }
                }
            }
        }
    }
