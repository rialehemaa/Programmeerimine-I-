using System;
using System.Collections.Generic;
using System.Text;

namespace Kontrolltöö
{
    // Ülesanne 4 - Oma Klassi loomine (Auto) 
    // class inimene 5osafunkteor
    internal class Auto
    {
            public string Mudel { get; set; }
            public double KutuseKulu { get; set; }
            public double PaagisOnKutust { get; set; }

            public Auto(string mudel, double kutuseKulu, double paagisOnKutust)
            {
                Mudel = mudel;
                KutuseKulu = kutuseKulu;
                PaagisOnKutust = paagisOnKutust;
            }

            public double ArvutaSoiduulatus()
            {
                return (PaagisOnKutust / KutuseKulu) * 100;
            }
        }
    }
