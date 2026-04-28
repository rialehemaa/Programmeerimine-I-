using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOP
{
    public class Koolihaldus
    {
        // Kapseldatud list
        private List<Isik> inimesed = new List<Isik>();

        public void LisaInimene(Isik isik)
        {
            inimesed.Add(isik);
        }

        public void KuvaKõik()
        {
            Console.WriteLine("\n--- KOOLI NIMEKIRI ---");
            foreach (var isik in inimesed)
            {
                // Polümorfism teeb siin imesid! 
                // C# teab ise, kas käivitada Õpetaja või Õpilase Kirjelda() meetod.
                isik.Kirjelda();
            }
        }

        public void KuvaAinultOpilased()
        {
            Console.WriteLine("\n--- AINULT ÕPILASED ---");

            foreach (var isik in inimesed)
            {
                if (isik is Õpilane)
                {
                    isik.Kirjelda();
                }
            }
        }

        public void OtsiNimeJärgi(string otsitavNimi)
        {
            foreach (var isik in inimesed)
            {
                if (isik.Nimi.Contains(otsitavNimi))
                {
                    isik.Kirjelda();
                }
            }
        }
    }
}
