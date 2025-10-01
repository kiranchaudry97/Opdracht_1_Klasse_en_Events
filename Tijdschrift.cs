using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1_Klasse_en_Events // bestand naam aangemaakt en met de klasse van tijdschrift gekoppeld
{

    // enum voor de verschijningsperiode
    public enum Verschijningsperiode
    {
        Dagelijks,
        Wekelijks,
        Maandelijks
    }

    // Tijdschrift klasse die erft van Boek
    internal class Tijdschrift : Boek
    {
        // Eigenschap voor de verschijningsperiode
        public Verschijningsperiode Periode { get; set; }

        // Constructor van Tijdschrift die de basis constructor van Boek aanroept en zie je inhoudt
        public Tijdschrift(string naam, string uitgever, int prijs, int isbn, Verschijningsperiode periode)
            : base(naam, uitgever, prijs, isbn)
        {
            // Initialiseer de Periode eigenschap
            Periode = periode;
        }

        // Parameterloze constructor
        public Tijdschrift()
        {
        }

        // Override van ToString om ook de verschijningsperiode weer te geven
        public override string ToString()

        // override keyword toegevoegd
        {
            return base.ToString() + $"\n- Verschijningsperiode: {Periode}";
        }

        // Override van Lees om ook de verschijningsperiode in te lezen
        public new void Lees()
        {
            base.Lees(); // om de Lees methode van de basis klasse aan te roepen

            // Inlezen van de verschijningsperiode
            Console.WriteLine("Kies de verschijningsperiode:");
            Console.WriteLine("0 - Dagelijks");
            Console.WriteLine("1 - Wekelijks");
            Console.WriteLine("2 - Maandelijks");

            // de invoer valideren van de gebruiker
            int keuze;
            while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 0 || keuze > 2)
            {
                // indien de invoer ongeldig is, wordt de gebruiker gevraagd om opnieuw te proberen
                Console.Write("Ongeldige invoer. Kies 0, 1 of 2: ");
            }
            // de gekozen waarde omzetten naar de enum en toewijzen aan de Periode eigenschap
            Periode = (Verschijningsperiode)keuze;
        }
    }
}
