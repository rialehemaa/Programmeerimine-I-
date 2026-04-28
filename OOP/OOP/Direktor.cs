using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Direktor : Õpetaja
    {
        public double Lisatasu { get; set; }

        public double ArvutaPalk()
        {
            return base.ArvutaPalk() + Lisatasu;
        }
    }
}
