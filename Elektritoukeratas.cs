using System;
using System.Globalization;

namespace Soidukid
{
    /// <summary>
    /// Elektritõukeratas – energiakulu kWh/100km järgi:
    /// kulu = (km / 100) * kWhKm * elektriHind
    /// </summary>
    public class Elektritoeukeratas : ISoiduk
    {
        private string mudel;
        private double km, kWhKm, elektriHind;

        public Elektritoeukeratas(string mudel, double km, double kWhKm, double elektriHind)
        {
            this.mudel = mudel;
            this.km = km;
            this.kWhKm = kWhKm;
            this.elektriHind = elektriHind;
        }

        public double ArvutaKulu() => (km / 100.0) * kWhKm * elektriHind;
        public double ArvutaVahemaa() => km;

        public string ToCsvRow() =>
            string.Format(CultureInfo.InvariantCulture,
                "elektritoeukeratas;{0};{1};{2};{3}", mudel, km, kWhKm, elektriHind);

        public override string ToString() =>
            $"Elektritõukeratas ({mudel}): vahemaa={km} km, kulu={ArvutaKulu():F2} EUR";
    }
}