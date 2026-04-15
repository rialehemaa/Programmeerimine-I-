using System;
using System.Collections.Generic;
using System.Text;
using static OOP.ITööline;

namespace OOP
{
    public enum TööTüüp
    {
        Palk,
        Toetus
    }
   
    public interface ITööline
    {
        TööTüüp VäljamakseTüüp { get; set; } // Töö tüübi omadus
        double ArvutaPalk(); // Ainult meetodi allkiri
    }
}
