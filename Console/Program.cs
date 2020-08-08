using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            InsertMultipleSamurais();
            AddSamurais();
            GetSamurais("After Add:");
            Console.ReadKey();
        }

        private static void InsertMultipleSamurais()
        {
            var samuraiList = new List<Samurai>();
            samuraiList.Add(new Samurai {Name = "abc"});
            samuraiList.Add(new Samurai {Name = "bcd"});
            samuraiList.Add(new Samurai {Name = "cde"});
            samuraiList.Add(new Samurai {Name = "def"});


            _context.Samurais.AddRange(samuraiList);
            _context.SaveChanges();
        }

        private static void InsertVariousTypes()
        {
            var samurai = new Samurai { Name = "Kickuchio" };
            var clan = new Clan { ClanName = "Imperial" };
            _context.AddRange(samurai,clan);
            _context.SaveChanges();
        }

        private static void AddSamurais()
        {
            var samurai = new Samurai
            {
                Name = "tommy"
            };

            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();

            Console.WriteLine($"{text}:Samurai count is {samurais.Count}");

            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}