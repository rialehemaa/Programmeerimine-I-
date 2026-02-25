using System;
using System.Collections.Generic;
using System.Text;

namespace Kontrolltöö;

public class Alamfunktsioonid
{
    public static void KytuseKalkulaator()
    {
        Console.WriteLine("Ülesanne 1");
        Console.WriteLine("Sisesta läbitud teepikkus (km):");
        double km = double.Parse(Console.ReadLine());
        Console.WriteLine("Sisesta kütusekulu 100km kohta (l):");
        double kulu100 = double.Parse(Console.ReadLine());
        Console.WriteLine("Sisesta kütuse liitri hind kohta (€):");
        double hind = double.Parse(Console.ReadLine());
        double kytusKokku = (km / 100) * kulu100;
        double maksumus = kytusKokku * hind;
        Console.WriteLine("$Kütust kulus kokku:{kytusKokku:F2} l");
        Console.WriteLine("$Reisi maksumus: {maksumus:F2} €");

    }
    public static void Isikukood()
    {
        Console.WriteLine("Ülesanne 2");
        Console.WriteLine("Sisesta isikukood:");
        string ik = Console.ReadLine();
        if (ik.Length != 11)
        {
            Console.WriteLine("Viga.Peab olla 11 märki!");
            return;
        }
        int esimene = int.Parse(ik.Substring(0, 11));
        string sugu;
        if (esimene == 1 || esimene == 3 || esimene == 5)
            sugu = "Mees";
        else if (esimene == 2 || esimene == 4 || esimene == 6)
            sugu = "Naine";
        else
            sugu = "Tundmatu";

        string aasta = ik.Substring(1, 2);
        string kuu = ik.Substring(3, 2);
        string paev = ik.Substring(5, 2);
        Console.WriteLine("Oled {sugu}, sündinud {paev}.{kuu}.{aasta}.");
    }

         public static void TaringuMang()
    {
        Random rnd = new Random();
        List<int> summad = new List<int>();
        int duublid = 0;
        int kogusumma = 0;

        for (int i = 0; i < 10; i++)
        {
            int t1 = rnd.Next(1, 7);
            int t2 = rnd.Next(1, 7);
            int summa = t1 + t2;

            if (t1 == t2)
                duublid++;

            summad.Add(summa);
            kogusumma += summa;
        }

        Console.WriteLine("Viskete summad:");
        foreach (int s in summad)
            Console.Write(s + " ");

        Console.WriteLine();
        Console.WriteLine($"Duubleid: {duublid}");
        Console.WriteLine($"Kõikide visete kogusumma: {kogusumma}");
    }
}

