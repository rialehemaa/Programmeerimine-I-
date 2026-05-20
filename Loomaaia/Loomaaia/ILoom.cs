using System;
using System.Collections.Generic;
using System.Text;

namespace Loomaaia
{
    
    public interface ILoom
    {
        //Selline komeentar ma võttab praktikum, IKujund.cs
        // Liides kirjeldab AINULT meetodite allkirju. Sisu siia me ei kirjutame.
        // Iga klass(Ahv,Elevant,Lovi), mis seda liidest rakendab,
        // PEAB need meetodid ise looma.
        double ArvutaToiduvajadus();
        void KuvaInfo();
        string ToiduTuup { get; }  // "Liha" või "Taimne"
    }


}
