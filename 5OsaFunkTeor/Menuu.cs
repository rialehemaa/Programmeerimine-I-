using System;
using System.Collections.Generic;
using System.Text;

namespace _5OsaFunkTeor
{
    internal class Menu
    {
        public static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("\nPEAMENU");
                Console.WriteLine("1 - Teooria");
                Console.WriteLine("2 - Ulesanded");
                Console.WriteLine("0 - Välju");

                Console.Write("Valik: ");
                string v = Console.ReadLine() ?? "";

                switch (v)
                {
                    case "1": TeooriaMenu(); break;
                    case "2": UlesandedMenu(); break;
                    case "0": run = false; break;
                }

                static void TeooriaMenu()
                {
                    bool run = true;

                    while (run)
                    {
                        Console.WriteLine("\nTEOORIA");
                        Console.WriteLine("1 - ArrayList");
                        Console.WriteLine("2 - Tuple");
                        Console.WriteLine("3 - List");
                        Console.WriteLine("4 - LinkedList");
                        Console.WriteLine("5 - Dictionary");
                        Console.WriteLine("0 - Tagasi");
                        Console.Write("Valik: ");

                        string v = Console.ReadLine();

                        switch (v)
                        {
                            case "1": Teooria.ArrayListDemo(); break;
                            case "2": Teooria.TupleDemo(); break;
                            case "3": Teooria.ListDemo(); break;
                            case "4": Teooria.LinkedListDemo(); break;
                            case "5": Teooria.DictionaryDemo(); break;
                            case "0": run = false; break;
                        }
                    }
                }

                static void UlesandedMenu()
                {
                    bool run = true;

                    while (run)
                    {
                        Console.WriteLine("\nÜLESANDED");
                        Console.WriteLine("1 - Kalorite kalkulaator");
                        Console.WriteLine("2 - Maakonnad");
                        Console.WriteLine("3 - Õpilased");
                        Console.WriteLine("4 - Filmid");
                        Console.WriteLine("5 - Statistika");
                        Console.WriteLine("6 - Lemmikloomad");
                        Console.WriteLine("7 - Valuuta");
                        Console.WriteLine("0 - Tagasi");
                        Console.Write("Valik: ");

                        string v = Console.ReadLine();

                        switch (v)
                        {
                            case "1": Ulesanded.Kalorid(); break;
                            case "2": Ulesanded.Maakonnad(); break;
                            case "3": Ulesanded.Opilased(); break;
                            case "4": Ulesanded.Filmid(); break;
                            case "5": Ulesanded.Statistika(); break;
                            case "6": Ulesanded.Lemmikloomad(); break;
                            case "7": Ulesanded.Valuuta(); break;
                            case "0": run = false; break;
                        }
                    }
                }
            }
        }
    }
}
