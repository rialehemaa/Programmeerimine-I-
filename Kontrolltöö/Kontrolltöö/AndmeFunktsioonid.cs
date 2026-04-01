using System;
using System.Collections.Generic;
using System.Text;

namespace Kontrolltöö
{
    internal class AndmeFunktsioonid
    {
        // Ülesanne 1 - Logi pidamine (Failikirjutamine)
        public static void KirjutaLogi(string message)
        {
            using (StreamWriter sw = new StreamWriter("logi.txt", true))
            {
                sw.WriteLine($"[{DateTime.Now}] - {message}");
            }
        }

        // Ülesanne 2 - Sõnastik ja Otsing (Dictionary) 
        public static void RiigiOtsing()
        {
            Dictionary<string, string> countries = new Dictionary<string, string>();//5Osa.2(Maakonnad)
            
            countries.Add( "EE", "Eesti" );
            countries.Add( "FI", "Soome" );
            countries.Add( "DE", "Saksamaa" );
           
            Console.Write("Sisesta riigi kood: ");
            string code = Console.ReadLine().Trim().ToUpper();

            if (countries.ContainsKey(code))
            { 
                Console.WriteLine($"Riik: {countries[code]}");
            }
            else
            { 
                Console.Write("Riiki ei leitud. Sisesta riigi nimi: ");
                string name = Console.ReadLine();
                countries.Add(code, name);
            }

        Console.WriteLine("\nKoik riigid:");
            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Key} --- {item.Value}");
            }
        }

        //Ülesanne 3 - Failist lugemine ja analüüs 
        public static Tuple<int, double> LoeJaArvuta(string path)
        {
            //4Osa.LoeFail
            try
            {
                string text = File.ReadAllText(path);
                string[] numbers = text.Split(',');

                List<int> list = new List<int>();

                foreach (string num in numbers)
                {
                    list.Add(int.Parse(num));
                }

                int sum = list.Sum();
                double avg = list.Average();

                return new Tuple<int, double>(sum, avg);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda!");
                return new Tuple<int, double>(0, 0);
            }
        }

        //5 Ülesanne 5 - Autopargi haldus (List ja loogika) 
        public static void HaldaAutosid()
        {
            List<Auto> cars = new List<Auto>()
            {
                new Auto("Toyota", 5.5, 40),
                new Auto("BMW", 8.0, 15),
                new Auto("Audi", 7.0, 9),
                new Auto("Fiat", 12.0, 57)
            };

            //5Osa.3

            Auto parimCar = cars.OrderByDescending(c => c.ArvutaSoiduulatus()).First();
            Console.WriteLine($"Koige suurem soiduulatus: {parimCar.Mudel}");

            Console.WriteLine("Vahese kutusega autod (<10L):");
            foreach (var car in cars)
            {
                if (car.PaagisOnKutust > 10)
                {
                    Console.WriteLine(car.Mudel);
                }
            }

            SalvestaAutodFaili(cars);

        }
        // 4Osa.SalvestaFail
       static void SalvestaAutodFaili(List<Auto> cars)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "autod.txt");
            StreamWriter text = new StreamWriter("autod.txt"); // 4Osa.LoeFail
         
                foreach (Auto car in cars)
                {
                    text.WriteLine($"{car.Mudel},{car.KutuseKulu},{car.PaagisOnKutust}");
                }
            }
        }
} 

       