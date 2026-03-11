using System;

namespace Naidis_IKTpv25
{
    public class MainPageItaalia_Klassidega
    {
        public static void Main(string[] args)
        {
            bool tootab = true;

            Itaalia_Funktsioonid_Klassidega.LaeAndmedFailist();
            Console.WriteLine("\nVajuta Enter, et avada menüü...");
            Console.ReadLine();

            while (tootab)
            {
                Console.Clear(); 
                Console.WriteLine("PEAMENÜÜ");
                Console.WriteLine("1 - Lae andmed uuesti failist mällu");
                Console.WriteLine("2 - Kuva restorani menüü");
                Console.WriteLine("3 - Lisa uus toit mällu");
                Console.WriteLine("4 - Otsi toitu nime järgi");
                Console.WriteLine("5 - Kustuta toit mälust");
                Console.WriteLine("6 - Salvesta muudatused faili");
                Console.WriteLine("0 - Välju");
                Console.Write("Vali tegevus (0-6): ");

                string valik = Console.ReadLine();
                Console.Clear();

                switch (valik)
                {
                    case "1":
                        Itaalia_Funktsioonid_Klassidega.LaeAndmedFailist();
                        break;
                    case "2":
                        Itaalia_Funktsioonid_Klassidega.ItaaliaRestoran();
                        break;
                    case "3":
                        Itaalia_Funktsioonid_Klassidega.LisaUusToit();
                        break;
                    case "4":
                        Itaalia_Funktsioonid_Klassidega.OtsiToitu();
                        break;
                    case "5":
                        Itaalia_Funktsioonid_Klassidega.KustutaToit();
                        break;
                    case "6":
                        Itaalia_Funktsioonid_Klassidega.SalvestaFaili();
                        break;
                    case "0":
                        Console.WriteLine("Programm suletud. Arrivederci!");
                        tootab = false;
                        break;
                    default:
                        Console.WriteLine("Vigane valik! Sisesta number 0 ja 6 vahel.");
                        break;
                }

                if (tootab)
                {
                    Console.WriteLine("\nVajuta Enter, et minna tagasi peamenüüsse...");
                    Console.ReadLine();
                }
            }
        }
    }
}