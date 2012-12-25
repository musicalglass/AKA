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
            int NumberCorrect;
            int NumberOfMatches;
            int[] RandNums = new int[LengthOfArray];
            int[] MyNums = new int[LengthOfArray];
            int[] TempArray = new int[LengthOfArray];

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
            Console.WriteLine("Enter {0} numbers: ", LengthOfArray);

      do
      {
          NumberCorrect = 0;
          NumberOfMatches = 0; 
            // Use a for loop to read user input to array
            for (int iCounter = 0; iCounter < LengthOfArray; iCounter++)
            {
                MyNums[iCounter] = int.Parse(Console.ReadLine());
            }
            // Count the number of correct guesses
            for (int iCounter = 0; iCounter < LengthOfArray; iCounter++)
            {
                if (RandNums[iCounter] == MyNums[iCounter])
                    NumberCorrect++;
            }

            Console.Write("\nRandom Number: ");
            foreach (int iArraySpace in RandNums) // Use a foreach loop to display Random Numbers
            {
                Console.Write(iArraySpace);
            }
            Console.Write("\nUser Guessed; ");
            foreach (int iArraySpace in MyNums) // Use a foreach loop to display User Input
            {
                Console.Write(iArraySpace);
            }


    for (int iArrayCell = 0; iArrayCell < LengthOfArray; iArrayCell++)
			{
			TempArray[iArrayCell] = RandNums[iArrayCell]; 
			}




                // Use a for loop to iterate through each of MyNum Array Cells
                for (int aCounter = 0; aCounter < LengthOfArray; aCounter++)
                {
                    // Compare each cell consecutively to each of the other's
                    for (int bCounter = 0; bCounter < LengthOfArray; bCounter++)
                    {
                        if (MyNums[aCounter] == TempArray[bCounter])
                        {
                            TempArray[aCounter] = TempArray[aCounter] + 10;
                            NumberOfMatches++;
                            break;
                        }
                    }
                }
                Console.WriteLine("\nYou have {0} right", NumberOfMatches);
                Console.WriteLine("{0} In the correct order", NumberCorrect); 
            } while (NumberCorrect != LengthOfArray);
            Console.WriteLine("Correct"); 
        }
    }
}
