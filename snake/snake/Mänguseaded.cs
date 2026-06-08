using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class MänguSeaded
    {
        public int Laius { get; set; }
        public int Kõrgus { get; set; }
        public int KiirusMS { get; set; } // Viivitus millisekundites - mida vähem, seda kiirem

        public MänguSeaded(int tase)
        {
            // Raskusastme valik
            switch (tase)
            {
                case 1: KiirusMS = 200; Laius = 40; Kõrgus = 20; break; // Lihtne
                case 2: KiirusMS = 100; Laius = 30; Kõrgus = 15; break; // Keskmine
                case 3: KiirusMS = 50; Laius = 20; Kõrgus = 10; break; // Raske
                default: KiirusMS = 150; Laius = 40; Kõrgus = 20; break;
            }
        }
    }
}