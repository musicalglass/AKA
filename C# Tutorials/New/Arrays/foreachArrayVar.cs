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

            System.Console.WriteLine( "\nEnter {0} numbers: ", LengthOfArray );
            // Use a for loop to read user input to array
            for ( int iCounter = 0; iCounter < LengthOfArray; iCounter++ ) 
            {
                MyNums[iCounter] = int.Parse( Console.ReadLine());
            }

            for (int iCounter = 0; iCounter < LengthOfArray; iCounter++)  // Count the number of correct guesses
            {
                if ( RandNums[iCounter] == MyNums[iCounter] )
                MyCounter++ ;
            }

            Console.Write("\nRandom Number: " );
            foreach (int i in RandNums) // Use a foreach loop to write them all
            {
                Console.Write(i);
            }
            Console.Write("\nUser Guessed; ");
            foreach (int i in MyNums) // Use a foreach loop to write them all
            {
                Console.Write(i);
            }

            Console.WriteLine("\nNumber of Correct Guesses: {0}", MyCounter);
        }
    }
}
