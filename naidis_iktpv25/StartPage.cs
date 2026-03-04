using naidis_iktpv25;
using System;
using System.Collections.Generic;
using System.Text;

namespace Näidis_IKTpv25
{
    class StartPage
    {
        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("PEAMENÜÜ ");
                Console.WriteLine("1 - Osa 2 ülesanded");
                Console.WriteLine("2 - Osa 3 ülesanded");
                Console.WriteLine("3 - Osa 4 ülesanded");
                Console.WriteLine("0 - Välju");
                Console.Write("Valik: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Osa2_funktsioonid.Menuu();
                        break;
                    case "2":
                        Osa3_funktsioonid.Menuu();
                        break;
                    case "3":
                        Osa4_funktsioonid.Menuu();
                        break;
                    case "0":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Vale valik!");
                        break;
                }
            }
        }
    }
}
