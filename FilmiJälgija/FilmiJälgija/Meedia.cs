using System;
using System.Collections.Generic;
using System.Text;

namespace FilmiJälgija
{
    public abstract class Meedia
    {
        public string Pealkiri { get; set; }
        public int Aasta { get; set; }
        public string Staatus { get; set; }
        public double Hinnang { get; set; }
        public string Märkus { get; set; }

        public abstract void KuvaInfo();
    }
}
