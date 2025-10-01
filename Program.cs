using System;
using System.Collections.Generic;

namespace Opdracht_1_Klasse_en_Events
{
    internal class Program
    {
        static List<Boek> boeken = new List<Boek>();
        static List<Tijdschrift> tijdschriften = new List<Tijdschrift>();

        static void Main(string[] args)
        {
            bool doorgaan = true;

            while (doorgaan)

                // keuze menu aanmaken
            {
                Console.Clear();
                Console.WriteLine("=== Hoofdmenu ===");
                Console.WriteLine("1. Voeg een boek toe");
                Console.WriteLine("2. Voeg een tijdschrift toe");
                Console.WriteLine("3. Toon alle boeken");
                Console.WriteLine("4. Toon alle tijdschriften");
                Console.WriteLine("5. Bestel een boek");
                Console.WriteLine("6. Bestel een tijdschrift");
                Console.WriteLine("0. Afsluiten");
                Console.Write("Keuze: ");

                // de keuze inlezen en verwerken

                string keuze = Console.ReadLine();

                // de gekozen keuze verwerken
                // switch statement

                switch (keuze)
                {

                    // case aangemaakt voor elke keuze
                    case "1":
                        Boek nieuwBoek = new Boek();
                        nieuwBoek.Lees();
                        boeken.Add(nieuwBoek);
                        Console.WriteLine("Boek toegevoegd!");
                        break;

                    case "2":
                        Tijdschrift nieuwTs = new Tijdschrift();
                        nieuwTs.Lees();
                        tijdschriften.Add(nieuwTs);
                        Console.WriteLine("Tijdschrift toegevoegd!");
                        break;

                    case "3":
                        Console.WriteLine("\n-- Boeken --");
                        foreach (var b in boeken)
                            Console.WriteLine(b + "\n");
                        break;

                    case "4":
                        Console.WriteLine("\n-- Tijdschriften --");
                        foreach (var t in tijdschriften)
                            Console.WriteLine(t + "\n");
                        break;

                    case "5":
                        BestelBoek();
                        break;

                    case "6":
                        BestelTijdschrift();
                        break;

                    case "0":
                        doorgaan = false;
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze!");
                        break;
                }

                // gekozen keuze tonen en wachten op een toets

                Console.WriteLine("\nDruk op een toets om verder te gaan...");
                Console.ReadKey();
            }
        }
        // bestelboek methode aanmaken met tuple output
        static void BestelBoek()
        {
            if (boeken.Count == 0)


            {
                // tekst tonen als er geen boeken zijn om te bestellen
                Console.WriteLine("Er zijn nog geen boeken om te bestellen.");
                // return om de methode te verlaten
                return;
            }
            // lijst van boeken tonen met index 
            Console.WriteLine("\nKies een boek om te bestellen:");

            // for lus om alle boeken te tonen met index
            for (int i = 0; i < boeken.Count; i++)
            {
                // index begint vanaf 1 toont de naam van het boek
                Console.WriteLine($"{i + 1}. {boeken[i].Naam}");
            }
            // de gebruiker vragen om een keuze te maken
            Console.Write("Jouw keuze: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > boeken.Count)

            {

                // vermelden van ongeldige keuze
                Console.WriteLine("Ongeldige keuze.");
                return;
            }
            // de gekozen boek opslaan in een variabele
            Boek gekozenBoek = boeken[index - 1];

            // de gebruiker vragen om het aantal te bestellen van boeken die ze willen bestellen en te kunnen inlezen en verwerken
            Console.Write("Aantal te bestellen: ");

            // anders als de invoer ongeldig is of minder dan 1 wordt aantal vermeld als ongeldig
            if (!int.TryParse(Console.ReadLine(), out int aantal) || aantal < 1)
            {
                // het bericht tonen als het aantal ongeldig is
                Console.WriteLine("Ongeldig aantal.");
                return;
            }
            // een nieuwe bestelling aanmaken met het gekozen boek en het aantal
            var bestelling = new Bestelling<Boek>(gekozenBoek, aantal);
            bestelling.BestellingBevestigd += msg => Console.WriteLine($"✅ EVENT: {msg}");
            var tuple = bestelling.Bestel();

            // de tulp informatie tonen

            Console.WriteLine($"\n Tuple info:");
            Console.WriteLine($"ISBN: {tuple.Item1}");
            Console.WriteLine($"Aantal: {tuple.Item2}");
            Console.WriteLine($"Totaalprijs: €{tuple.Item3}");
        }

    x        // methode om een tijdschrift te bestellen met tuple-output en event
        static void BestelTijdschrift()
        {
            // Controleer of er tijdschriften zijn om te bestellen
            if (tijdschriften.Count == 0)
            {
                Console.WriteLine("Er zijn nog geen tijdschriften om te bestellen.");
                return;
            }

            // Toon alle beschikbare tijdschriften met index
            Console.WriteLine("\nKies een tijdschrift om te bestellen:");
            for (int i = 0; i < tijdschriften.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tijdschriften[i].Naam}");
            }

            // Vraag de gebruiker om een keuze te maken
            Console.Write("Jouw keuze: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > tijdschriften.Count)
            {
                Console.WriteLine("Ongeldige keuze.");
                return;
            }

            // Haal het gekozen tijdschrift op
            Tijdschrift gekozenTs = tijdschriften[index - 1];

            // Vraag het aantal te bestellen exemplaren
            Console.Write("Aantal exemplaren: ");
            if (!int.TryParse(Console.ReadLine(), out int aantal) || aantal < 1)
            {
                Console.WriteLine("Ongeldig aantal.");
                return;
            }

            // Maak een nieuwe bestelling aan voor het gekozen tijdschrift
            var bestelling = new Bestelling<Tijdschrift>(gekozenTs, aantal, gekozenTs.Periode);

            // Voeg een event handler toe die een bevestigingsbericht toont
            bestelling.BestellingBevestigd += msg => Console.WriteLine($" EVENT: {msg}");

            // Roep de Bestel-methode aan die een tuple retourneert en het event triggert
            var tuple = bestelling.Bestel();

            // Toon de tuple-informatie en de verschijningsperiode
            Console.WriteLine($"\n Tuple info:");
            Console.WriteLine($"ISBN: {tuple.Item1}");
            Console.WriteLine($"Aantal: {tuple.Item2}");
            Console.WriteLine($"Totaalprijs: €{tuple.Item3}");
            Console.WriteLine($"Periode: {gekozenTs.Periode}");
        }
    }
}
