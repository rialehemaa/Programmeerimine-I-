using System;
using System.Collections.Generic;
using System.Text;

namespace praktikum
{
    public enum KolmnurgaTüüp
    {
        Vigane,       // Kui kolmnurka ei saa eksisteerida
        Võrdkülgne,   // Kõik küljed on sama pikad
        Võrdhaarne,   // Kaks külge on sama pikad
        Erikülgne     // Kõik küljed on erineva pikkusega
    }
    public class Kolmnurk : IKujund
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public KolmnurgaTüüp Tüüp { get; private set; }

        public Kolmnurk(double a, double b, double c)
        {
            // Valideerimine: kas selline kolmnurk saab eksisteerida?
            if (a + b > c && a + c > b && b + c > a)
            {
                A = a;
                B = b;
                C = c;
                // Kui andmed on õiged, määrame kohe ka kolmnurga tüübi
                MääraTüüp();
            }
            else
            {
                Console.WriteLine("⚠️ Viga: Selliste külgedega kolmnurka ei saa matemaatiliselt eksisteerida!");
                A = 0; B = 0; C = 0; // Nullime vigased andmed
                Tüüp = KolmnurgaTüüp.Vigane; // Vigane sisend saab vastava staatuse
            }
        }
        // Privaatne abimeetod, sest ainult klass ise peab saama oma tüüpi arvutada
        private void MääraTüüp()
        {
            if (A == B && B == C)
            {
                Tüüp = KolmnurgaTüüp.Võrdkülgne;
            }
            else if (A == B || B == C || A == C)
            {
                Tüüp = KolmnurgaTüüp.Võrdhaarne;
            }
            else
            {
                Tüüp = KolmnurgaTüüp.Erikülgne;
            }
        }
        public double ArvutaÜmbermõõt() => A + B + C;

        public double ArvutaPindala()
        {
            if (Tüüp == KolmnurgaTüüp.Vigane) return 0; // Kui kolmnurk on vigane, on pindala 0

            // Pindala arvutamine Heroni valemi abil
            double s = ArvutaÜmbermõõt() / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
    }
}
