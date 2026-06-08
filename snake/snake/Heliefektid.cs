using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public static class Heliefektid
    {
        // Mängib heli, kui uss sööb toidu ära
        public static void MängiSöömist()
        {
            // Käivitame uue ülesandena, et mäng ei jääks heli ootama
            Task.Run(() => Console.Beep(800, 100));
        }

        // Mängib heli, kui mäng on läbi
        public static void MängiKaotust()
        {
            Task.Run(() =>
            {
                Console.Beep(400, 200);
                Console.Beep(300, 200);
                Console.Beep(200, 400);
            });
        }
    }
}