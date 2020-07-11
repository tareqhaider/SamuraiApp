using Data;
using Domain;
using System;
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
            AddSamurais();
            GetSamurais("After Add:");
            Console.ReadKey();
        }

        private static void AddSamurais()
        {
            var samurai = new Samurai 
            { 
                Name = "julie"
            };

            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();

            Console.WriteLine($"{text}:Samurai count is {samurais.Count}");

            foreach(var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
