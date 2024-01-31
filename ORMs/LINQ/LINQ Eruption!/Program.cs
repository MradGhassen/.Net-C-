// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
// Use LINQ to find the first eruption that is in Chile and print the result.
IEnumerable<Eruption> firsteruptionChile = eruptions.FirstOrDefault(c => c.Location == "Chile");
PrintEach(firsteruptionChile, "the first eruption that is in Chile.");
// Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
IEnumerable<Eruption> firstEruptionHawaiian = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");
PrintEach(firstEruptionHawaiian, "the first eruption that is in Hawaiian Is.");
// Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
IEnumerable<Eruption> firstEruptionNewZealand = eruptions.FirstOrDefault(c => c.Location == "New Zealand").Min(m => m.Year == 1900 );
PrintEach(firstEruptionNewZealand, "the first eruption that is in New Zealand.");
// Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> allEruptionElevation = eruptions.Min(m => m.ElevationInMeters == 2000 );
PrintEach(allEruptionElevation, "the volcano's elevation is over 2000m.");
// Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
IEnumerable<Eruption> allEruptionStarts = eruptions.Where(m => m.Volcano.StartsWith("L") );
IEnumerable<Eruption> allEruptionStartsSum = eruptions.Sum(m => m.Volcano.StartsWith("L") );
PrintEach(allEruptionStarts, "all eruptions where the volcano's name starts with L");
PrintEach(allEruptionStartsSum, "the number of eruptions found");
// Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
IEnumerable<Eruption> highestElevation = eruptions.Max(m => m.ElevationInMeters);
Console.WriteLine(highestElevatio.ElevationInMeters);
// Use the highest elevation variable to find a print the name of the Volcano with that elevation.
Console.WriteLine(highestElevatio.Volcano);
// Print all Volcano names alphabetically.
IEnumerable<Eruption> allVolcano = eruptions.OrderBy(m => m.Volcano).ToList();
PrintEach(allVolcano, "all Volcano names");
// Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> allVolcanoBefore = eruptions.Max(m => m.Year == 1000).OrderBy(m => m.Volcano).ToList();
PrintEach(allVolcanoBefore, "all Volcano before the year 1000 CE");

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
