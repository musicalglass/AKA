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
            int[] RandNums = new int[LengthOfArray];

            Random r = new Random();
            // Use a for loop to fill array with Random Numbers
            for (int iCounter = 0; iCounter < LengthOfArray; iCounter++) 
            {
                RandNums[iCounter] = r.Next(10);
            }

            // Use a foreach loop to write Random Numbers to screen
            foreach (int iArraySpace in RandNums)
            {
                Console.Write(iArraySpace);
            }

        }
    }
}
