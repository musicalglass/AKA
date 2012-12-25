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

            System.Console.WriteLine("Enter {0} numbers: ", LengthOfArray);

            // Use a for loop to read user input to Array
            for (int iCounter = 0; iCounter < LengthOfArray; iCounter++) 
            {
                MyNums[iCounter] = int.Parse(Console.ReadLine());
            }

            foreach (int i in MyNums) // Use a foreach loop to write them all
            {
                System.Console.Write(i);
            }
            System.Console.WriteLine();
        }
    }
}
