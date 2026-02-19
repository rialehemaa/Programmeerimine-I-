using System;

class Startclass
{
    public static string Kuu_nimetus(int kuu_nr)
    {
        string kuu = "";
        switch (kuu_nr)
        {
            case 1: kuu = "Jaanuar"; break;
            case 2: kuu = "Veebruar"; break;
            case 3: kuu = "Märts"; break;
            case 4: kuu = "Aprill"; break;
            case 5: kuu = "Mai"; break;
            case 6: kuu = "Juuni"; break;
            case 7: kuu = "Juuli"; break;
            case 8: kuu = "August"; break;
            case 9: kuu = "September"; break;
            case 10: kuu = "Oktoober"; break;
            case 11: kuu = "November"; break;
            case 12: kuu = "Detsember"; break;
            default: kuu = "???"; break;
        }
        return kuu;
    }

    public static string Hooaeg(int kuu_nr)
    {
        string hoo = "";
        if (kuu_nr == 1 || kuu_nr == 2 || kuu_nr == 12)
            hoo = "Talv";
        else if (kuu_nr > 2 && kuu_nr < 6)
            hoo = "Kevad";
        else if (kuu_nr > 5 && kuu_nr < 9)
            hoo = "Suvi";
        else if (kuu_nr > 8 && kuu_nr < 12)
            hoo = "Sügis";
        else
            hoo = "???";
        return hoo;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ülesanne 1: Kino");
        Console.Write("Sisesta oma eesnimi: ");
        string eesnimi = Console.ReadLine();
        Console.WriteLine("Tere, " + eesnimi + "!");

        if (eesnimi.ToLower() == "juku")
        {
            Console.WriteLine("Tule minu juurde külla! Lähme kinno!");
            Console.Write("Sisesta Juku vanus: ");
            int vanus = int.Parse(Console.ReadLine());

            if (vanus < 0 || vanus > 100)
                Console.WriteLine("Viga andmetega! Vanus ei ole realistlik.");
            else if (vanus < 6)
                Console.WriteLine("Juku pilet: TASUTA");
            else if (vanus <= 14)
                Console.WriteLine("Juku pilet: LASTEPILET");
            else if (vanus <= 65)
                Console.WriteLine("Juku pilet: TÄISPILET");
            else
                Console.WriteLine("Juku pilet: SOODUSPILET");
        }
        else
        {
            Console.WriteLine("Täna mind kodus pole!");
        }

        Console.WriteLine("\nÜlesanne 2: Pinginaabrid");
        Console.Write("Sisesta esimese inimese nimi: ");
        string nimi1 = Console.ReadLine();
        Console.Write("Sisesta teise inimese nimi: ");
        string nimi2 = Console.ReadLine();
        Console.WriteLine("{0} ja {1} on täna pinginaabrid!", nimi1, nimi2);

        Console.WriteLine("\nÜlesanne 3: Toa pindala ja remont");
        Console.Write("Sisesta toa pikkus (m): ");
        double pikkus = double.Parse(Console.ReadLine());
        Console.Write("Sisesta toa laius (m): ");
        double laius = double.Parse(Console.ReadLine());
        double pindala = pikkus * laius;
        Console.WriteLine("Põranda pindala on {0} m²", pindala);

        Console.Write("Kas soovite remonti teha? (jah/ei): ");
        string remont = Console.ReadLine();
        if (remont.ToLower() == "jah")
        {
            Console.Write("Sisesta ruutmeetri hind (€): ");
            double rmHind = double.Parse(Console.ReadLine());
            Console.WriteLine("Põranda vahetamise koguhind: {0:F2} €", pindala * rmHind);
        }
        else
        {
            Console.WriteLine("Remont jäetakse tegemata.");
        }

        Console.WriteLine("\nÜlesanne 4: Alghind 30% soodusest");
        Console.Write("Sisesta soodushind (€): ");
        double soodushind = double.Parse(Console.ReadLine());
        Console.WriteLine("Alghind (enne 30% soodustust): {0:F2} €", soodushind / 0.70);

        Console.WriteLine("\nÜlesanne 5: Temperatuur");
        Console.Write("Sisesta temperatuur (°C): ");
        double temp = double.Parse(Console.ReadLine());
        if (temp > 18)
            Console.WriteLine("Temperatuur on üle soovitusliku 18 kraadi.");
        else if (temp == 18)
            Console.WriteLine("Temperatuur on täpselt soovituslik 18 kraadi.");
        else
            Console.WriteLine("Temperatuur on alla soovitusliku 18 kraadi.");

        Console.WriteLine("\nÜlesanne 6: Pikkus");
        Console.Write("Sisesta oma pikkus (cm): ");
        int pikkus6 = int.Parse(Console.ReadLine());
        if (pikkus6 < 165)
            Console.WriteLine("Sa oled lühike.");
        else if (pikkus6 <= 185)
            Console.WriteLine("Sa oled keskmise pikkusega.");
        else
            Console.WriteLine("Sa oled pikk.");

        Console.WriteLine("\nÜlesanne 7: Pikkus ja sugu");
        Console.Write("Sisesta oma pikkus (cm): ");
        int pikkus7 = int.Parse(Console.ReadLine());
        Console.Write("Sisesta oma sugu (mees/naine): ");
        string sugu = Console.ReadLine().ToLower();

        if (sugu == "mees")
        {
            if (pikkus7 < 170)
                Console.WriteLine("Mees: lühike.");
            else if (pikkus7 <= 185)
                Console.WriteLine("Mees: keskmise pikkusega.");
            else
                Console.WriteLine("Mees: pikk.");
        }
        else if (sugu == "naine")
        {
            if (pikkus7 < 158)
                Console.WriteLine("Naine: lühike.");
            else if (pikkus7 <= 173)
                Console.WriteLine("Naine: keskmise pikkusega.");
            else
                Console.WriteLine("Naine: pikk.");
        }
        else
        {
            Console.WriteLine("Tundmatu sugu.");
        }

        Console.WriteLine("\nÜlesanne 8: Pood");
        double koguhind = 0;
        string ostetud = "";

        Console.Write("Kas soovite osta piima? (jah/ei): ");
        if (Console.ReadLine().ToLower() == "jah")
        {
            koguhind += 1.29;
            ostetud += "piim (1.29€)  ";
        }

        Console.Write("Kas soovite osta saia? (jah/ei): ");
        if (Console.ReadLine().ToLower() == "jah")
        {
            koguhind += 0.89;
            ostetud += "sai (0.89€)  ";
        }

        Console.Write("Kas soovite osta leiba? (jah/ei): ");
        if (Console.ReadLine().ToLower() == "jah")
        {
            koguhind += 1.59;
            ostetud += "leib (1.59€)  ";
        }

        if (koguhind > 0)
            Console.WriteLine("Ostetud: {0}\nKogusumma: {1:F2} €", ostetud, koguhind);
        else
            Console.WriteLine("Te ei ostnud midagi.");

        Console.WriteLine("\nDemo: Kuu nimetus ja hooaeg");
        Console.Write("Sisesta kuu number (1-12): ");
        int kuuNr = int.Parse(Console.ReadLine());
        Console.WriteLine("Kuu: {0}", Kuu_nimetus(kuuNr));
        Console.WriteLine("Hooaeg: {0}", Hooaeg(kuuNr));

        Console.WriteLine("\nProgramm lõpetatud. Vajuta Enter...");
        Console.ReadLine();
    }
}
