/* Three Basic Arrays */
/* Create an array to hold integer values 0 through 9 */
using System.Linq.Expressions;

int[] arrayOfInts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
/* Create an array of the names "Tim", "Martin", "Nikki", & "Sara" */

/* Create an array of the names "Tim", "Martin", "Nikki", & "Sara" */

/* Create an array of the names "Tim", "Martin", "Nikki", & "Sara" */
string[] names = new string[] { "Tim", "Martin", "Nikki", "Sara" };

/* Create an array of length 10 that alternates between true and false values, starting with true */

bool[] alternates = [true, false, true, false, true, false, true, false, true, false];

/* List of Flavors */
/* Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!) */

List<string> ice_cream = new List<string>();
ice_cream.Add("orio");
ice_cream.Add("blackberry");
ice_cream.Add("strawberry");
ice_cream.Add("mohito");
ice_cream.Add("mango");
/* Output the length of this list after building it */
Console.WriteLine($"We currently know of {ice_cream.Count} ice creams flavor");
/* Output the third flavor in the list, then remove this value */
Console.WriteLine(ice_cream[2]);
ice_cream.Remove(ice_cream[2]);
/* Output the new length of the list (It should just be one fewer!)*/
Console.WriteLine($"We currently know of {ice_cream.Count} ice creams flavor");

/* User Info Dictionary */
/* Create a dictionary that will store both string keys as well as string values */
Dictionary<string, string> dictionary = new Dictionary<string, string>();
/* Add key/value pairs to this dictionary where:
    each key is a name from your names array
    each value is a randomly selected flavor from your flavors list.
*/
dictionary.Add("Name", "Tim");
dictionary.Add("Name", "Martin");
dictionary.Add("Name", "Nikki");
dictionary.Add("Name", "Sara");
dictionary.Add("flavor", "strawberry");
dictionary.Add("flavor", "mohito");
dictionary.Add("flavor", "blackberry");
dictionary.Add("flavor", "orio");
/* Loop through the dictionary and print out each user's name and their associated ice cream flavor */
foreach (var entry in dictionary)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}
