using System;
using System.Collections.Generic;
using System.Text;

namespace _5OsaFunkTeor

{
    internal class Opilane
    {
        public string Nimi;
        public List<int> Hinded = new List<int>();

        public double Keskmine()
        {
            double summa = 0;

            foreach (int h in Hinded)
                summa += h;

            return summa / Hinded.Count;
        }
    }
}