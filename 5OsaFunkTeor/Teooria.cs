
using System;
using System.Collections;
using System.Collections.Generic;

namespace _5OsaFunkTeor
{
    internal class Teooria
    {
        public static void ArrayListDemo()
        {
            Console.WriteLine("ArrayList (System.Collections)"); // 1. ArrayList 

            ArrayList nimed = new ArrayList();
            nimed.Add("Kati");
            nimed.Add("Mati");
            nimed.Add("Juku");

            if (nimed.Contains("Mati"))
                Console.WriteLine("Mati olemas");

            Console.WriteLine("Nimesid kokku: " + nimed.Count);

            nimed.Insert(1, "Sass");

            Console.WriteLine("Mati indeks: " + nimed.IndexOf("Mati"));
            Console.WriteLine("Mari indeks: " + nimed.IndexOf("Mari"));

            foreach (string nimi in nimed)
                Console.WriteLine(nimi);
        }

        public static void TupleDemo()
        {
            Console.WriteLine("Tuple (järjendid)"); // 2. Tuple 

            Tuple<float, char> route = new Tuple<float, char>(2.5f, 'N');

            Console.WriteLine($"Vahemaa: {route.Item1}, Suund: {route.Item2}");
        }

        public static void ListDemo()
        {
            Console.WriteLine("List (System.Collections.Generic)"); // 3. List 

            List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "Kadi" });
            people.Add(new Person() { Name = "Mirje" });

            foreach (Person p in people)
                Console.WriteLine(p.Name);
        }
        public static void LinkedListDemo()
        {
            Console.WriteLine("LinkedList (System.Collections.Generic)"); // 4. LinkedList 

            LinkedList<int> loetelu = new LinkedList<int>();
            loetelu.AddLast(5);
            loetelu.AddLast(3);
            loetelu.AddFirst(0);

            foreach (int arv in loetelu)
                Console.WriteLine(arv);

            loetelu.RemoveFirst();
            loetelu.RemoveLast();
            loetelu.AddLast(555);
            loetelu.Remove(555);
        }

        public static void DictionaryDemo()
        {
            Console.WriteLine("Dictionary <TKey, TValue> – Sõnastik"); // 5. Dictionary 

            Dictionary<int, string> riigid = new Dictionary<int, string>();
            riigid.Add(1, "Hiina");
            riigid.Add(2, "Eesti");
            riigid.Add(3, "Itaalia");

            foreach (var paar in riigid)
                Console.WriteLine($"{paar.Key} - {paar.Value}");

            string pealinn = riigid[2];
            riigid[2] = "Eestimaa";
            riigid.Remove(3);

            Console.WriteLine();

            Dictionary<char, Person> inimesed = new Dictionary<char, Person>();
            inimesed.Add('k', new Person() { Name = "Kadi" });
            inimesed.Add('m', new Person() { Name = "Mait" });

            foreach (var entry in inimesed)
                Console.WriteLine($"{entry.Key} - {entry.Value.Name}");
        }
    }

    internal class Person
    {
        public string Name { get; set; }
    }
}