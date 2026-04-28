using System;
using System.Collections.Generic;
using System.Text;

namespace praktikum
{
    public class Ristkülik : IKujund
    {
        public double Pikkus { get; set; }
        public double Laius { get; set; }

        public Ristkülik(double pikkus, double laius)
        {
            Pikkus = pikkus;
            Laius = laius;
        }

        public double ArvutaPindala() => Pikkus * Laius;
        public double ArvutaÜmbermõõt() => 2 * (Pikkus + Laius);
    }
}
