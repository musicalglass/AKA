using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.ForEachNum
{
    class ArrayONums
    {
        static void Main()
        {
            int LengthOfArray = 5; 
            int[] MyNums = new int[5];

            System.Console.WriteLine("Enter 5 numbers: ");

            for ( int iCounter = 0; iCounter < LengthOfArray; iCounter++ )
            {
                // Parse user input String to Integer and store in Array
                MyNums[iCounter] = int.Parse( Console.ReadLine()); 
            }
            
            // Use a foreach loop to write them all 
            // Note that the foreach loop is READ ONLY! You could not 
            // use the foreach loop for the above input sequence. Try it.
            foreach (int iArraySpace in MyNums) 
            {
                System.Console.Write(iArraySpace);
            }
            System.Console.WriteLine();
        }
    }
}