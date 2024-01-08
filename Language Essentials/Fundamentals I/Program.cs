/*Create a Loop that prints all values from 1-255 */

for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

/* Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both */

for (int i = 1; i <= 100; i++)
{
    if ( i % 3 == 0 || i % 5 == 0 )
    {
    Console.WriteLine(i);
    }
}

/* Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5*/

for (int i = 1; i <= 100; i++)
{
    if ( i % 3 == 0 )
    {
    Console.WriteLine("Fizz");
    }
    if ( i % 5 == 0)
    {
    Console.WriteLine("Buzz");
    }
    if (  i % 3 == 0 && i % 5 == 0)
    {
    Console.WriteLine("FizzBuzz");
    }
}

/* (Optional) If you used "for" loops for your solution, try doing the same with "while" loops. Vice-versa if you used "while" loops! */ 

int num = 1;
while (num < 256)
{
    Console.WriteLine(num);
    num++ ;
}
