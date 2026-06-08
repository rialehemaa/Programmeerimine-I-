using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Toit
    {
        private Random rnd = new Random();
        private int ekraaniLaius;
        private int ekraaniKõrgus;
        private int offsetY; // Mitu rida ülevalt jätta infopaneelile

        // Toidu asukoht ekraanil
        public Punkt Asukoht { get; private set; }

        public Toit(int laius, int kõrgus, int offsetY = 0)
        {
            ekraaniLaius = laius;
            ekraaniKõrgus = kõrgus;
            this.offsetY = offsetY;
            LooUusToit(); // Loome kohe alguses esimese toidu
        }

        // Loob uue toidu suvalisse kohta ekraanil (seintest sees)
        public void LooUusToit()
        {
            int x = rnd.Next(2, ekraaniLaius - 2);
            int y = rnd.Next(2 + offsetY, ekraaniKõrgus - 2 + offsetY);
            Asukoht = new Punkt(x, y, '@'); // Toit näeb välja nagu '@'
            Asukoht.Joonista();
        }
    }
}