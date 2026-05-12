using System;
using System.Globalization;

namespace Soidukid
{
    /// <summary>
    /// Mootorratas – lisaboonus klass.
    /// kulu = (km / 100) * kütust100km * kütuseHind
    /// </summary>
    public class Mootorratas : ISoiduk
    {
        private string mark;
        private double km, kytusKm, kytusHind;

        public Mootorratas(string mark, double km, double kytusKm, double kytusHind)
        {
            this.mark = mark;
            this.km = km;
            this.kytusKm = kytusKm;
            this.kytusHind = kytusHind;
        }

        public double ArvutaKulu() => (km / 100.0) * kytusKm * kytusHind;
        public double ArvutaVahemaa() => km;

        public string ToCsvRow() =>
            string.Format(CultureInfo.InvariantCulture,
                "mootorratas;{0};{1};{2};{3}", mark, km, kytusKm, kytusHind);

        public override string ToString() =>
            $"Mootorratas ({mark}): vahemaa={km} km, kulu={ArvutaKulu():F2} EUR";
    }
}