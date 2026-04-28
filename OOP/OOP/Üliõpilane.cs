using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Üliõpilane : Õpilane
        {
            public string Eriala { get; set; }

            public override void Kirjelda()
            {
                Console.WriteLine($"Mina olen üliõpilane {Nimi}, õpin erialal {Eriala}, vorm: {Staatus}");
            }
        }
}