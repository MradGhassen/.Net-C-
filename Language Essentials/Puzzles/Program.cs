// Random Array
// Create a function called RandomArray() that returns an integer array
static void randomArray()
{
    List<int> randlist = new List<int>();
// Create an empty array that will hold 10 integer values.
            Random rand = new Random();
// Loop through the array and assign each index a random integer value between 5 and 25.
            for(int i = 0; i < 10; i++){
                randlist.Add(rand.Next(5,25));
            }
            int[] numArray = randlist.ToArray();
            
            foreach(int value in randlist){
                Console.WriteLine(value);
            }
// Print the min and max values of the array
// Print the sum of all the values
            int max = numArray[0];
            int min = numArray[0];
            int sum = numArray[0];
            for(int i = 1; i < numArray.Length; i++){
                if(numArray[i] < min){
                    min = numArray[i];
                }
                if(numArray[i] > max){
                    max = numArray[i];
                }
                sum += numArray[i];
            }
            Console.WriteLine("Min = "+min+" Max = "+max+".");
            Console.WriteLine("Sum of array values = "+sum+".");
}
randomArray();

// Coin Flip
// Create a function called TossCoin() that returns a string

static string TossCoin()
{
// Have the function print "Tossing a Coin!"
    Console.WriteLine("Tossing a Coin!");
// Randomize a coin toss with a result signaling either side of the coin
    List<int> randlist = new List<int>();

            Random rand = new Random();
            
            for(int x = 0; x < 100; x++){
                randlist.Add(rand.Next(5,1000));
            }
            int[] numArray = randlist.ToArray();
            int sum = numArray[0];
            
            for(int i = 0; i < numArray.Length; i++){
                sum += numArray[i];
            }

            int randcoin = sum*101;
            randcoin = randcoin/51;
            Console.WriteLine(randcoin);
//Have the function print either "Heads" or "Tails"
// Finally, return the result
            string coin;
            if(randcoin % 2 != 0){
                coin = "Heads";
            } else {
                coin = "Tails";
            }
            Console.WriteLine("your toss was : "+coin+" ");
            return coin;
}
TossCoin();

// Names
// Build a function Names that returns a list of strings. In this function:
static void Names ()
{
    List<string> Namelist = new List<string>();
// Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
    Namelist.Add("Todd");
    Namelist.Add("Tiffany");
    Namelist.Add("Charlie");
    Namelist.Add("Geneva");
    Namelist.Add("Sydney");
    foreach(string name in Namelist)
            {
// Return a list that only includes names longer than 5 characters
                int l = name.Length;
                if ( l > 5 ) 
                {
                    Console.WriteLine(name);
                }
            }
}
Names();
