using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class ArrayChar
    {
        static void Main()
        {
            int LengthOfArray = 5; 
            int[] MyNums = new int[5];

            System.Console.WriteLine("Enter 5 numbers: ");
            // Use a for loop to read user input to array
            for ( int iCounter = 0 ; iCounter < LengthOfArray ; iCounter++ ) 
            {
                MyNums[iCounter] = int.Parse(Console.ReadLine());
            }

            foreach (int i in MyNums) // Use a foreach loop to write them all
            {
                System.Console.Write(" {0}", i);
            }

        }
    }
}
