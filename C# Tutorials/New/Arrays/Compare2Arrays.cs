using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class ArrayChar
    {
        static void Main()
        {
            int LengthOfArray = 3;
            int MyCounter = 0;
            int[] RandNums = new int[LengthOfArray];
            int[] MyNums = new int[LengthOfArray];

            Random r = new Random();
            // Use a for loop to fill array with Random Numbers
            for (int iCounter = 0; iCounter < LengthOfArray; iCounter++) 
            {
                RandNums[iCounter] = r.Next(10);
            }

            // Use a foreach loop to write Random Numbers to screen
            Console.Write("Debug Hint: ");
            foreach (int iArraySpace in RandNums)
            {
                Console.Write(iArraySpace);
            }
            Console.WriteLine("\nThe Computer has a random {0} digit number in memory. ", LengthOfArray);
            Console.WriteLine( "Enter {0} numbers: ", LengthOfArray );
            // Use a for loop to read user input to array
            for ( int iCounter = 0; iCounter < LengthOfArray; iCounter++ ) 
            {
                MyNums[iCounter] = int.Parse( Console.ReadLine());
            }
 // Count the number of correct guesses
            for (int iCounter = 0; iCounter < LengthOfArray; iCounter++) 
            {
                if ( RandNums[iCounter] == MyNums[iCounter] )
                MyCounter++ ;
            }

            Console.Write("\nRandom Number: " );
            foreach (int iArraySpace in RandNums) // Use a foreach loop to display Random Numbers
            {
                Console.Write(iArraySpace);
            }
            Console.Write("\nUser Guessed; ");
            foreach (int iArraySpace in MyNums) // Use a foreach loop to display User Input
            {
                Console.Write(iArraySpace);
            }

            Console.WriteLine("\nNumber of Correct Guesses: {0}", MyCounter);
        }
    }
}
