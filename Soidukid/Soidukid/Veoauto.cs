using System;
using System.Globalization;

namespace Soidukid
{
    /// <summary>
    /// Veoauto (грузовик) – kulu arvutatakse sarnaselt autoga.
    /// kulu = (km / 100) * kütust100km * kütuseHind
    /// Lisaks salvestatakse koormus tonnides (informatiivne).
    /// </summary>
    public class Veoauto : ISoiduk
    {
        private string mark;       // Mark, nt "Volvo FH"
        private double km;         // Läbitud vahemaa
        private double kytusKm;    // Kütusekulu l/100km
        private double kytusHind;  // Kütuse hind EUR/l
        private double koormus;    // Koormus tonnides

        public Veoauto(string mark, double km, double kytusKm, double kytusHind, double koormus)
        {
            this.mark = mark;
            this.km = km;
            this.kytusKm = kytusKm;
            this.kytusHind = kytusHind;
            this.koormus = koormus;
        }

        /// <summary>Arvutab kütusekulu eurodes.</summary>
        public double ArvutaKulu() => (km / 100.0) * kytusKm * kytusHind;

        /// <summary>Tagastab vahemaa.</summary>
        public double ArvutaVahemaa() => km;

        /// <summary>Tagastab CSV-rea faili salvestamiseks.</summary>
        public string ToCsvRow() =>
            string.Format(CultureInfo.InvariantCulture,
                "veoauto;{0};{1};{2};{3};{4}", mark, km, kytusKm, kytusHind, koormus);

        public override string ToString() =>
            $"Veoauto ({mark}): vahemaa={km} km, koormus={koormus} t, kulu={ArvutaKulu():F2} EUR";
    }
}