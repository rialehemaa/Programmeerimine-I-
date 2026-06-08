using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public static class Edetabel
    {
        private static string failiTee = "skoorid.txt";

        // Salvestab tulemuse faili
        public static void Salvesta(string nimi, int skoor)
        {
            File.AppendAllLines(failiTee, new[] { $"{nimi};{skoor}" });
        }

        // Kuvab TOP 5 tulemust ekraanile
        public static void KuvaEdetabel()
        {
            if (!File.Exists(failiTee)) return;

            var skoorid = File.ReadAllLines(failiTee)
                .Select(rida => rida.Split(';'))
                .Where(osad => osad.Length == 2)
                .Select(osad => new { Nimi = osad[0], Punktid = int.Parse(osad[1]) })
                .OrderByDescending(x => x.Punktid)
                .Take(5); // Ainult TOP 5

            Console.WriteLine("--- TOP 5 EDETABEL ---");
            foreach (var s in skoorid)
            {
                Console.WriteLine($"{s.Nimi}: {s.Punktid} punkti");
            }
        }
    }
}