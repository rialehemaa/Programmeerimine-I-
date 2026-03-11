using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_IKTpv25
{
    public class Menuu
    {
        public string Nimetus { get; set; }
        public List<string> Koostisosad { get; set; }
        public double Hind { get; set; }

        public Menuu(string nimetus, List<string> kostisosad, double hind)
        {
            Nimetus = nimetus;
            Koostisosad = kostisosad;
            Hind = hind;
        }
        public string VormindaFailiJaoks()
        {
            string ainedKoos = string.Join(", ", Koostisosad);
            return $"{Nimetus};{ainedKoos};{Hind.ToString("F2").Replace(',', '.')}";
        }
    }
}