using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CIT_195_Lesson_8_LINQ_query
{
    class famousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<famousPeople> stemPeople = new List<famousPeople>() {
                new famousPeople() {Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
                new famousPeople() {Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
                new famousPeople() {Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
                new famousPeople() {Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
                new famousPeople() {Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
                new famousPeople() {Name = "Tu YouYou", BirthYear= 1930 },
                new famousPeople() {Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
                new famousPeople() {Name = "Lydia Villa-Komaroff", BirthYear=1947},
                new famousPeople() {Name = "Mae C. Jemison", BirthYear=1956},
                new famousPeople() {Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
                new famousPeople() {Name = "Tim Berners-Lee", BirthYear=1955 },
                new famousPeople() {Name = "Terence Tao", BirthYear=1975 },
                new famousPeople() {Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
                new famousPeople() {Name = "George Washington Carver", DeathYear=1943 },
                new famousPeople() {Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
                new famousPeople() {Name = "Bill Gates", BirthYear=1955 }
            };

            var nineteeners = from s in stemPeople
                              where s.BirthYear > 1900
                              select s;
            var doubleletters = from s in stemPeople
                                where s.Name.Contains("ll")
                                select s;
            var younger = stemPeople.Count(s => s.BirthYear > 1950);

            var older = from s in stemPeople
                        where s.BirthYear > 1919
                        where s.BirthYear < 2001
                        select s;

            var number = older.Count();

            var reordered = from s in stemPeople
                            orderby s.BirthYear ascending
                            select s;

            var passedOn = from s in stemPeople
                           where s.DeathYear > 1960
                           where s.DeathYear < 2015
                           orderby s.Name ascending
                           select s;

            Console.WriteLine();
            Console.WriteLine("Born in the 20th Century:");
            Console.WriteLine();
            foreach (var t in nineteeners)
            {
                Console.WriteLine($"{t.Name}\nBorn: {t.BirthYear}  Died: {t.DeathYear}");
            }
            Console.WriteLine();

            Console.WriteLine("Two 'L's in their name:");
            Console.WriteLine();
            foreach (var t in doubleletters)
            {
                Console.WriteLine($"{t.Name}\nBorn: {t.BirthYear}  Died: {t.DeathYear}");
            }
            Console.WriteLine();

            Console.WriteLine($"{younger} people in the list were born after 1950.");
            Console.WriteLine();

            Console.WriteLine("Born between 1920 and 2000:");
            Console.WriteLine();
            foreach (var t in older)
            {
                Console.WriteLine($"{t.Name}\nBorn: {t.BirthYear}  Died: {t.DeathYear}");
            }
            Console.WriteLine($"{number} people in the above list");
            Console.WriteLine();

            Console.WriteLine("Reordered by Birth Year, ascending:");
            Console.WriteLine();
            foreach (var t in reordered)
            {
                Console.WriteLine($"{t.Name}\nBorn: {t.BirthYear}  Died: {t.DeathYear}");
            }
            Console.WriteLine();

            Console.WriteLine("Already died, but not too recently:");
            Console.WriteLine();
            foreach (var t in passedOn)
            {
                Console.WriteLine($"{t.Name}\nBorn: {t.BirthYear}  Died: {t.DeathYear}");
            }
            Console.WriteLine();
        }
    }

}

