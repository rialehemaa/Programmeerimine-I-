namespace Kontrolltöö
{
    internal class StartPage
    {
        private static bool jooksutab;

        static void Main(string[] args)
        {
            bool jookustab = true;
            while (jookustab)
            {
                Console.WriteLine("Menü");
                Console.WriteLine("Kutuse kalkulaator");
                Console.WriteLine("Isikukoodi dekooder");
            }
            string valik = Console.ReadLine();

            switch (valik)
            {
                case "1":
                    Alamfunktsioonid.KytuseKalkulaator();
                    break;

                case "2":
                    Alamfunktsioonid.Isikukood();
                    break;

                case "3":
                    
                    break;

                case "0":
                    jooksutab = false;
                    break;

                default:
                    Console.WriteLine("Vale valik!");
                    break;
            }
        }

    }
}
