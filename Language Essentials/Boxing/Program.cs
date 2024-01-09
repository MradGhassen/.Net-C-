// Create an empty list of type object
List<object> boxs = new List<object>();

// Add the following values to the list: 7, 28, -1, true, "chair"
boxs.Add(7);
boxs.Add(28);
boxs.Add(-1);
boxs.Add(true);
boxs.Add("chair");

// Loop through the list and print all values 
// Add all values that are Int type together and output the sum
int sum = 0;
foreach (var box in boxs)
{
    Console.WriteLine(box);
    if (box is int)
    {
        sum += (int)box;
    }
}
Console.WriteLine(sum);
