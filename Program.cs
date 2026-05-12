using System;
using System.Collections.Generic;

namespace Soidukid
{
    /// <summary>
    /// Peaprogramm – ainult käivitamine.
    /// Kogu menüüloogika asub Menu klassis.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var haldur = new KasutajaHaldur();
            var menu = new Menu(haldur);
            menu.Kaivita();
        }
    }
}