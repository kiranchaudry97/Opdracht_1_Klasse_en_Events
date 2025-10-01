using System;

namespace Opdracht_1_Klasse_en_Events
{
    internal class Boek
    {
        public string Naam { get; set; }
        public string Uitgever { get; set; }

        private int _prijs;

        // Prijs met validatie (altijd tussen 5 en 50 euro)
        public int Prijs
        {
            get => _prijs;
            set
            {
                if (value < 5)
                    _prijs = 5;
                else if (value > 50)
                    _prijs = 50;
                else
                    _prijs = value;
            }
        }

        public int Isbn { get; set; }

        public Boek(string naam, string uitgever, int prijs, int isbn)
        {
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs;
            Isbn = isbn;
        }

        public Boek()
        {
        }

        public override string ToString()
        {
            return $"Boekgegevens:\n" +
                   $"- Naam: {Naam}\n" +
                   $"- Uitgever: {Uitgever}\n" +
                   $"- Prijs: {Prijs} euro\n" +
                   $"- ISBN: {Isbn}";
        }

        public void Lees()
        {
            Console.Write("Type de naam van het boek: ");
            Naam = Console.ReadLine();

            Console.Write("Type de naam van de uitgever: ");
            Uitgever = Console.ReadLine();

                            int prijs;
            Console.Write("Type de prijs van het boek (in euro's): ");
            while (!int.TryParse(Console.ReadLine(), out prijs))
            {
                Console.Write("Ongeldige invoer. Geef een geheel getal voor de prijs: ");
            }
            Prijs = prijs;

            int isbn;
            Console.Write("Geef het ISBN-nummer: ");
            while (!int.TryParse(Console.ReadLine(), out isbn))
            {
                Console.Write("Ongeldige invoer. Geef een geheel getal voor het ISBN: ");
            }
            Isbn = isbn;
        }
    }
}
