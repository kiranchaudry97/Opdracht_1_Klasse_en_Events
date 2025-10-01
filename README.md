# Opdracht 1: Klasse en Events - Boekwinkel Bestellingssysteem

## Overzicht
Dit project is een console-applicatie voor een boekwinkel die boeken en tijdschriften verkoopt. Voor tijdschriften kunnen ook abonnementen worden afgesloten.
Het systeem demonstreert het gebruik van klassenhiërarchie, generieke klassen, events en tuple-waarden in C#.

## Functionaliteiten
- **Boeken en Tijdschriften beheren**
  - Toevoegen, weergeven en bestellen van boeken en tijdschriften.
- **Abonnementen op tijdschriften**
  - Verschijningsperiode: Dagelijks, Wekelijks, Maandelijks (via enum).
- **Bestellingen**
  - Generieke klasse `Bestelling<T>` voor het plaatsen van bestellingen.
  - Uniek volgnummer voor elke bestelling.
  - Event dat een bevestiging geeft bij het plaatsen van een bestelling.
  - Tuple als returnwaarde bij het bestellen (ISBN, aantal, totaalprijs).

## Klassenstructuur

### Boek
- Eigenschappen: `Isbn`, `Naam`, `Uitgever`, `Prijs` (met validatie tussen 5 en 50 euro).
- Methoden: Constructor, `ToString` (overridden), `Lees` (voor invoer via console).

### Tijdschrift (afgeleid van Boek)
- Extra eigenschap: `Verschijningsperiode` (enum).
- Methoden: Overridden `ToString` en `Lees`.

### Bestelling<T>
- Generieke klasse voor bestellingen van boeken of tijdschriften.
- Eigenschappen: `Id`, `Item`, `Datum`, `Aantal`, `Periode` (optioneel).
- Methode: `Bestel()` retourneert een tuple en triggert een event.

## Gebruik
1. Start de applicatie.
2. Voeg boeken en tijdschriften toe via het hoofdmenu.
3. Bekijk de lijst van boeken/tijdschriften.
4. Plaats een bestelling en ontvang een bevestiging via een event en tuple-output.

## Screenshot 

 ![image alt]()
* beschrijving *
