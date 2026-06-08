using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Kaart
    {
        public List<Punkt> Takistused { get; private set; } = new List<Punkt>();

        // offsetY - mitu rida ülevalt jätta infopaneelile
        public Kaart(int laius, int kõrgus, int offsetY = 0)
        {
            // Ülemine ja alumine sein
            for (int x = 0; x < laius; x++)
            {
                Takistused.Add(new Punkt(x, offsetY, '#'));
                Takistused.Add(new Punkt(x, kõrgus - 1 + offsetY, '#'));
            }

            // Vasak ja parem sein
            for (int y = offsetY; y < kõrgus + offsetY; y++)
            {
                Takistused.Add(new Punkt(0, y, '#'));
                Takistused.Add(new Punkt(laius - 1, y, '#'));
            }
        }

        // Joonistab kõik seinad ekraanile
        public void Joonista()
        {
            foreach (var p in Takistused)
            {
                p.Joonista();
            }
        }

        // Kontrollib, kas antud punkt kattub mõne takistusega
        public bool OnKokkupõrge(Punkt pea)
        {
            return Takistused.Any(t => t.X == pea.X && t.Y == pea.Y);
        }
    }
}