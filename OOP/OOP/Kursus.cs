using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Kursus
    {
        public string Nimi { get; set; }
        public Õpetaja VastutavÕpetaja { get; set; }

        public void KuvaInfo()
        {
            Console.WriteLine($"Kursus: {Nimi}, Õpetaja: {VastutavÕpetaja.Nimi}");
        }
    }
}
