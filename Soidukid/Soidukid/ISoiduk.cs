using System;

namespace Soidukid
{
    /// <summary>
    /// Põhiliides kõigile sõidukitele.
    /// Iga sõiduk peab oskama arvutada kulu ja vahemaad.
    /// </summary>
    public interface ISoiduk
    {
        /// <summary>Tagastab sõidu kulu eurodes.</summary>
        double ArvutaKulu();

        /// <summary>Tagastab läbitud vahemaa kilomeetrites.</summary>
        double ArvutaVahemaa();
    }
}