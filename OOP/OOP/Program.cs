using OOP;
using System.Numerics;

//Loome Isik klassi objekti ja kasutame selle omadusi ja meetodit
Isik inimene1 = new Isik();
inimene1.Nimi = "Mati";
inimene1.Sünniaasta = 2000;
inimene1.Tervita(); // Väljund: Tere! Mina olen Mati...


// Päritud Isik klassist, seega saad kasutada Isiku omadusi ja meetodeid
Õpetaja õpetaja1 = new Õpetaja();
õpetaja1.Nimi = "Eve";
õpetaja1.Sünniaasta = 1980;
õpetaja1.Aine = "Matemaatika";
õpetaja1.Tervita(); // Väljund: Tere! Mina olen Eve...
õpetaja1.Õpeta();   // Väljund: Eve õpetab ainet: Matemaatika.


Console.WriteLine("\n--- Õpilase andmed ---");
// 2. Loo Õpilase objekti
Õpilane opilane1 = new Õpilane();
// Päritud Isik klassist
opilane1.Nimi = "Markus";
opilane1.Sünniaasta = 2008;
// Spetsiifilised Õpilane klassile
opilane1.Kool = "Kutsehariduskeskus";
opilane1.Klass = 10;
// Päritud meetod
opilane1.Tervita();
// Õpilase enda meetod
opilane1.Õpi();

// Ootame kasutaja sisestust, et konsooliaken kohe ei sulguks
//Console.ReadLine();

// Polümorfismi näide: ITööline liides ja erinevad klassid, mis seda rakendavad
List<ITööline> palgasaajad = new List<ITööline>();

Koolihaldus minukool = new Koolihaldus();

Õpetaja Õpetaja = new Õpetaja { Nimi = "Oleg", Aine = "Programmeerimine" };
Õpilane Õpilane = new Õpilane { Nimi = "Mari", Klass = 10, Staatus = Õppevorm.Päevane };

minukool.LisaInimene(Õpetaja);
minukool.LisaInimene(Õpilane);

Õpilane mati = new Õpilane();
mati.Nimi = "Mati";
mati.KeskmineHinne = 4.0;
mati.Kool = "Keskkool";
mati.Klass = 9;

//õpilased

Õpilane kadi = new Õpilane();
kadi.Nimi = "Kadi";
kadi.KeskmineHinne = 3.5;
kadi.Kool = "Kutsehariduskeskus";
kadi.Klass = 10;

Õpilane juku = new Õpilane();
juku.Nimi = "Juku";
juku.KeskmineHinne = 4.5;
juku.Kool = "Kutsehariduskeskus";
juku.Klass = 12;

//õpetajad

Õpetaja peter = new Õpetaja();
peter.Nimi = "Peter";
peter.Aine = "C#";
peter.Tunnitasu = 20;
peter.Tunnidkuus = 60;

Õpetaja ioanna = new Õpetaja();
ioanna.Nimi = "Ioanna";
ioanna.Aine = "JavaScript";
ioanna.Tunnitasu = 25;
ioanna.Tunnidkuus = 80;


// Saame samasse listi lisada täiesti erinevaid objekte, sest nad kõik on "ITööline"
palgasaajad.AddRange(new ITööline[] { mati, kadi, juku, peter, ioanna });
//selline variant on ka soobib
//palgasaajad.Add(mati);
//palgasaajad.Add(kadi);
//palgasaajad.Add(juku);
//palgasaajad.Add(peter);
//palgasaajad.Add(ioanna);

minukool.LisaInimene(mati);
minukool.LisaInimene(kadi);
minukool.LisaInimene(juku);
minukool.LisaInimene(peter);
minukool.LisaInimene(ioanna);


// 2. variant täitmine tsükli abil
Random rnd = new Random();
string[] nimed = { "Maria", "Kati", "Juhan", "Anna", "Siim" };

Õppevorm[] vormid = (Õppevorm[])Enum.GetValues(typeof(Õppevorm));

for (int i = 0; i < nimed.Length; i++)
{
    Õpilane õpilane = new Õpilane
    {
        Nimi = nimed[rnd.Next(nimed.Length)],
        Klass = rnd.Next(1, 13),
        Kool = "TTHK",
        KeskmineHinne = rnd.NextDouble() * 5, // Keskmine hinne vahemikus 0–5
        Puudumised = rnd.Next(0, 350),        // Puudumised vahemikus 0–350
        KasOnSotsToend = rnd.Next(0, 2) == 1,
        Staatus = vormid[rnd.Next(vormid.Length)] // Valime juhusliku õppevormi
    };

    palgasaajad.Add(õpilane);
    minukool.LisaInimene(õpilane);

}
minukool.KuvaKõik();

// Nüüd saame ühe tsükliga kõigile palgad/toetused välja arvutada
Console.WriteLine("\n--- Väljamaksed ---");

foreach (ITööline isik in palgasaajad)
{
    // Polümorfism teeb siin maagiat:
    // Õpilase puhul käivitub toetuse loogika, õpetaja puhul palga loogika!
    string tüüp = isik.VäljamakseTüüp.ToString().ToLower();
    Console.WriteLine($"{tüüp} summa: {isik.ArvutaPalk()} eurot. {((Isik)isik).Nimi}le");
    
}


