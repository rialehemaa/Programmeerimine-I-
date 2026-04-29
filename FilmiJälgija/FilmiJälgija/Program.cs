using System;
using System.Collections.Generic;


namespace FilmiJälgija
{
    class Program
    {
            static void Main()
            {
                List<Meedia> meediaList = new List<Meedia>();

            Menu.LaeFailist(meediaList); 

            Menu.Käivita(meediaList);

                Console.WriteLine("\nMEEDIA NIMEKIRI ");

                foreach (Meedia m in meediaList)
                {
                    m.KuvaInfo();
                }
            }
        }
    }