using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Uss
    {
        // Ussi keha on Punkt objektide nimekiri - esimene on pea, viimane on saba
        private List<Punkt> keha = new List<Punkt>();

        public Suund PraeguneSuund { get; set; }

        public Uss(int algX, int algY, int pikkus)
        {
            PraeguneSuund = Suund.Paremale; // Alguses liigub paremale

            // Loome ussi algse keha
            for (int i = 0; i < pikkus; i++)
            {
                Punkt p = new Punkt(algX - i, algY, '*');
                keha.Add(p);
                p.Joonista();
            }
        }

        // Liigutab ussi praeguse suuna järgi
        public void Liigu()
        {
            // 1. Leiame praeguse pea asukoha
            Punkt pea = keha.First();
            Punkt uusPea = new Punkt(pea.X, pea.Y, '*');

            // 2. Arvutame uue pea asukoha vastavalt suunale
            switch (PraeguneSuund)
            {
                case Suund.Paremale: uusPea.X++; break;
                case Suund.Vasakule: uusPea.X--; break;
                case Suund.Alla: uusPea.Y++; break;
                case Suund.Üles: uusPea.Y--; break;
            }

            // 3. Lisame uue pea listi algusesse ja joonistame
            keha.Insert(0, uusPea);
            uusPea.Joonista();

            // 4. Kustutame sabaotsa, et simuleerida liikumist
            Punkt saba = keha.Last();
            saba.Kustuta();
            keha.Remove(saba);
        }

        // Tagastab ussi pea (esimese elemendi)
        public Punkt HangiPea()
        {
            return keha.First();
        }

        // Ussi kasvamine - lisab saba lõppu uue punkti
        public void Kasva()
        {
            keha.Add(new Punkt(keha.Last().X, keha.Last().Y, '*'));
        }

        // Kontrollib, kas uss hammustas ennast (pea kattub kehaga)
        public bool OnHammustandItennast()
        {
            Punkt pea = keha.First();
            // Kontrollime alates teisest elemendist (indeks 1)
            return keha.Skip(1).Any(p => p.X == pea.X && p.Y == pea.Y);
        }

        // Ussi praegune pikkus (skooriarvestuseks)
        public int Pikkus => keha.Count;
    }
}