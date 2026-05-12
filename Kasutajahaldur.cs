using System;
using System.Collections.Generic;
using System.IO;

namespace Soidukid
{
    /// <summary>
    /// Kasutajahaldur – salvestab ja laeb kasutajaid kasutajad.txt failist.
    /// Parool salvestatakse lihttekstina (õppeprojekt – tootmises kasuta räsimist!).
    /// Fail formaat: kasutajanimi;parool  (üks rida = üks kasutaja)
    /// </summary>
    public class KasutajaHaldur
    {
        private const string FAIL = "kasutajad.txt";

        // Kõik registreeritud kasutajad: võti=kasutajanimi, väärtus=parool
        private Dictionary<string, string> kasutajad = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public KasutajaHaldur()
        {
            LaeKasutajad();
        }

        /// <summary>Laeb kasutajad failist mällu.</summary>
        private void LaeKasutajad()
        {
            if (!File.Exists(FAIL)) return;
            foreach (var rida in File.ReadAllLines(FAIL))
            {
                if (string.IsNullOrWhiteSpace(rida)) continue;
                var p = rida.Split(';');
                if (p.Length >= 2)
                    kasutajad[p[0].Trim()] = p[1].Trim();
            }
        }

        /// <summary>Salvestab kõik kasutajad faili.</summary>
        private void SalvestaKasutajad()
        {
            var read = new List<string>();
            foreach (var kv in kasutajad)
                read.Add($"{kv.Key};{kv.Value}");
            File.WriteAllLines(FAIL, read);
        }

        /// <summary>Kontrollib, kas kasutajanimi on juba võetud.</summary>
        public bool OnOlemas(string nimi) => kasutajad.ContainsKey(nimi);

        /// <summary>Registreerib uue kasutaja. Tagastab false kui nimi on võetud.</summary>
        public bool Registreeri(string nimi, string parool)
        {
            if (OnOlemas(nimi)) return false;
            kasutajad[nimi] = parool;
            SalvestaKasutajad();
            return true;
        }

        /// <summary>Kontrollib kasutajanime ja parooli. Tagastab true kui õige.</summary>
        public bool Logi(string nimi, string parool)
        {
            return kasutajad.TryGetValue(nimi, out string? salvestatud)
                   && salvestatud == parool;
        }

        /// <summary>Tagastab kõigi registreeritud kasutajanimede loendi.</summary>
        public IEnumerable<string> KõikNimed() => kasutajad.Keys;
    }
}