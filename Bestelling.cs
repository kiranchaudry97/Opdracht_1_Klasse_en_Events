using Opdracht_1_Klasse_en_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Bestelling<T>
{
    // Statische teller voor unieke ID's
    private static int teller = 1;

    // Event
    public event Action<string> BestellingBevestigd;

    // Eigenschappen
    public int Id { get; private set; }
    public T Item { get; set; }
    public DateTime Datum { get; set; }
    public int Aantal { get; set; }
    public Verschijningsperiode? Periode { get; set; } // enkel voor tijdschriften

    // Constructor
    public Bestelling(T item, int aantal, Verschijningsperiode? periode = null)
    {
        Id = teller++;
        Item = item;
        Aantal = aantal;
        Datum = DateTime.Now;

        // Periode alleen instellen indien het een tijdschrift is
        if (item is Tijdschrift)
        {
            Periode = periode;
        }
    }

    // Bestel-methode met Tuple-output
    public Tuple<int, int, int> Bestel()
    {
        int isbn = 0;
        int totaalPrijs = 0;

        if (Item is Boek boek)
        {
            isbn = boek.Isbn;
            totaalPrijs = boek.Prijs * Aantal;

            // Event triggeren
            BestellingBevestigd?.Invoke($"Bestelling #{Id} bevestigd voor boek: {boek.Naam}, aantal: {Aantal}, totaalprijs: €{totaalPrijs}");
            return Tuple.Create(isbn, Aantal, totaalPrijs);
        }
        else
        {
            throw new InvalidOperationException("Alleen boeken kunnen besteld worden met deze methode.");
        }
    }

    // Voor extra gebruiksgemak
    public override string ToString()
    {
        return $"Bestelling #{Id} - {Item}\nAantal: {Aantal} - Datum: {Datum:d}" +
               (Periode != null ? $"\nPeriode: {Periode}" : "");
    }
}
