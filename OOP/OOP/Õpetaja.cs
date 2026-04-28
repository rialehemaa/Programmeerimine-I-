using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    // Õpetaja pärib klassist Isik (koolon tähistab pärimist)
    public class Õpetaja : Isik, ITööline, IHindaja
    {
        public Õpetaja() : base()
        {
        }

        public Õpetaja(string nimi, string aine, double tunnitasu) : base(nimi)
        {
            Aine = aine;
            Tunnitasu = tunnitasu;
        }

        public string Aine { get; set; }
            public double Tunnitasu { get; set; }
            public int Tunnidkuus { get; set; }
            public TööTüüp VäljamakseTüüp { get; set; } = TööTüüp.Palk;

            public void Õpeta()
            {
                Console.WriteLine($"{Nimi} õpetab ainet: {Aine}.");
            }

            // override kirjutab abstraktse meetodi üle
            public override void Kirjelda()
            {
                Console.WriteLine($"Mina olen õpetaja {Nimi} ja ma õpetan: {Aine}.");
            }

            // ITööline liidese meetodi realiseerimine
            public double ArvutaPalk()
            {
                return Tunnitasu * Tunnidkuus; // Palk arvutatakse tunnitasu ja töötatud tundide järgi
            }
            public void Hinda(string hinne)
            {
            Console.WriteLine($"{Nimi} pani hindeks: {hinne}");
            }
        
    }
 }


