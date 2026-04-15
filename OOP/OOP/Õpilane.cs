using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public enum Õppevorm
    {
        Päevane,
        Kaugõpe,
        Ekstern,
        AkadeemilinePuhkus
    }

    // Õpilane pärib klassist Isik
    public class Õpilane : Isik, ITööline
    {
        public string Kool { get; set; }
        public int Klass { get; set; }

        public double KeskmineHinne { get; set; } // põhitoetus 60eur

        public int Puudumised { get; set; } = 0; // põhitoetus

        public bool KasOnSotsToend { get; set; } = false; // eritoetus 120eur

        public void Õpi()
        {
            Console.WriteLine($"{Nimi} õpib {Kool} {Klass}. klassis.");
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen õpilane {Nimi} ja käin {Klass}. klassis.");
        }

        public double ArvutaPalk()
        {
            //KeskmineHinne minimum 3,8 
            //Puudumised minimum 30
           
            double põhitoetus = 0;
            double eritoetus = 0;

            if (KeskmineHinne >= 3.8 && Puudumised <= 30)
            {
                põhitoetus += 60;
            }

            if (KasOnSotsToend) // Kui olemas SotsToend
            {
                eritoetus += 120;
            }

            return põhitoetus + eritoetus;
        }

        public TööTüüp VäljamakseTüüp { get; set; } = TööTüüp.Toetus;
        public Õppevorm Staatus { get; internal set; }
    }
 }

