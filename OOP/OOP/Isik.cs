using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Isik
    {
        //// Omadused ehk väljad
        //public string Nimi;
        //public int Vanus;

        //// Tegevus ehk meetod
        //public void Tervita()
        //{
        //    Console.WriteLine($"Tere! Mina olen {Nimi} ja ma olen {Vanus} aastat vana.");
        //}


        // Privaatne väli - otse ligi ei saa
        private int sünniaasta;

        // Avalik omadus (Property) automaatse get/set logikaga
        public string Nimi { get; set; }

        // Kontrollitud omadus
        public int Sünniaasta
        {
            get { return sünniaasta; }
            set
            {
                if (value > 1900 && value <= DateTime.Now.Year)
                    sünniaasta = value;
                else
                    Console.WriteLine("Vigane sünniaasta!");
            }
        }

        // Arvutatud omadus (ainult lugemiseks / getter)
        public int Vanus => DateTime.Now.Year - sünniaasta;

       
        internal void Tervita()
        {
            if (string.IsNullOrEmpty(Nimi) || sünniaasta == 0)
            {
                Console.WriteLine($"Tere! Mina olen{Nimi} ja ma olen {Vanus} aastat vana. Olen");
            }
            else
            { }
        }
        public virtual void Kirjelda()
        {
            Console.WriteLine("Isik");
        }
    }
 }


