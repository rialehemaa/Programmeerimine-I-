using System;
using System.Collections.Generic;

namespace FilmiJälgija
{
    class Program
    {
        static void Main()
        {
            // Toetab Unicode sümboleid (tärnid, kastid jne)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "FilmiJälgija — meedia nimekiri";

            List<Meedia> meediaList = new List<Meedia>();
            Menu.LaeFailist(meediaList);
            Menu.Käivita(meediaList);
        }
    }
}