int[] samples = { 2, 10, 3 };
int[] sampleAllNegative = { -5, -2, -6 };
int[] shiftingExample = { 1, 5, 10, 7, 2 };
int[] sampleNumToString = { -1, 13, 2 };

// #1 Print 1-255
static void PrintNumbers()
{
    int i = 1;
    while (i < 256)
    {
        Console.WriteLine(i);
        i++;
    }
}
PrintNumbers();

// #2 Print odd numbers between 1-255
static void PrintOdds()
{
    int i = 1;
    while (i < 256)
    {
        Console.WriteLine(i);
        i += 2;
    }
}
PrintOdds();

// #3 Print all of the numbers from 0 to 255, but this time, also print the sum as you go 
static void PrintSum()
{
    int i = 1;
    int sum = 0;
    while (i < 256)
    {
        sum += i;
        Console.WriteLine($"New number:{i} Sum:{sum}");
        i++;
    }
}
PrintSum();

// #4 Iterating Through an Array
static void LoopArray(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        Console.WriteLine(numbers[i]);
    }
}
LoopArray(samples);

// #5 Find Max
static int FindMax(int[] numbers)
{
    int max = numbers[0];
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
            max = numbers[i];
    }
    return (max);
}
FindMax(sampleAllNegative);

// #6 Get Average
static void GetAverage(int[] numbers)
{
    int sum = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }
    int avg = sum / numbers.Length;
    Console.WriteLine(avg);
}
GetAverage(samples);

// #7 Array with Odd Numbers
static int[] OddArray()
{
    int[] allOdds = new int[256 / 2];
    for (int i = 1; i <= 255; i += 2)
    {
        allOdds[i / 2] = i;
    }

    return (allOdds);
}
OddArray();

// #8 Greater than Y
static int GreaterThanY(int[] numbers, int y)
{
    int idxTally = 0;
    foreach (int num in numbers)
    {
        if (num > y)
            idxTally++;
    }
    return idxTally;
}
GreaterThanY(samples, 3);

// #9 Square the Values
static void SquareArrayValues(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = numbers[i] * numbers[i];
    }
}
SquareArrayValues(samples);
SquareArrayValues(sampleAllNegative);

// #10 Eliminate Negative Numbers
static void EliminateNegatives(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] < 0)
            numbers[i] = 0;
        else
            numbers[i] = numbers[i];
    }
}
EliminateNegatives(sampleAllNegative);

// #11 Min, Max, and Average
static void MinMaxAverage(int[] numbers)
{
    int max = numbers[0];
    int min = numbers[0];

    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
            max = numbers[i];

        if (numbers[i] < min)
            min = numbers[i];
    }

    int avg = (min + max) / 2;
}
MinMaxAverage(samples);
MinMaxAverage(sampleAllNegative);

// #12 Shifting the values in an array
static void ShiftValues(int[] numbers)
{
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        numbers[i] = numbers[i + 1];
    }

    numbers[numbers.Length - 1] = 0;
}
ShiftValues(shiftingExample);

// #13 Number to String
static object[] NumToString(int[] numbers)
{
    object[] objects = new object[numbers.Length];
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] < 0)
            objects[i] = "Dojo";
        else
            objects[i] = numbers[i];
    }
    return objects;
}
NumToString(sampleAllNegative);
