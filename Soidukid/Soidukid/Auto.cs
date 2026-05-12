using System;
using System.Globalization;

namespace Soidukid
{
    /// <summary>
    /// Sõiduauto – arvutab kütusekulu valemi järgi:
    /// kulu = (km / 100) * kütust100km * kütuseHind
    /// </summary>
    public class Auto : ISoiduk
    {
        private string mark;       // Marginimi, nt "Toyota Corolla"
        private double km;         // Läbitud vahemaa
        private double kytusKm;    // Kütusekulu liitrites 100 km kohta
        private double kytusHind;  // Kütuse hind EUR/l

        public Auto(string mark, double km, double kytusKm, double kytusHind)
        {
            this.mark = mark;
            this.km = km;
            this.kytusKm = kytusKm;
            this.kytusHind = kytusHind;
        }

        /// <summary>Arvutab kütusekulu eurodes.</summary>
        public double ArvutaKulu() => (km / 100.0) * kytusKm * kytusHind;

        /// <summary>Tagastab vahemaa.</summary>
        public double ArvutaVahemaa() => km;

        /// <summary>Tagastab CSV-rea faili salvestamiseks.</summary>
        public string ToCsvRow() =>
            string.Format(CultureInfo.InvariantCulture,
                "auto;{0};{1};{2};{3}", mark, km, kytusKm, kytusHind);

        public override string ToString() =>
            $"Auto ({mark}): vahemaa={km} km, kulu={ArvutaKulu():F2} EUR";
    }
}