using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class ArrayChar
    {
        static void Main()
        {
            int LevelDifficulty = 3;
            int NumberCorrect;
            int NumberOfMatches;
            int[] RandNums = new int[LevelDifficulty];
            int[] UserInput = new int[LevelDifficulty];
            int[] TempArray = new int[LevelDifficulty];

            Random r = new Random();
            // Use a for loop to fill array with Random Numbers
            for (int iCounter = 0; iCounter < LevelDifficulty; iCounter++)
            {
                RandNums[iCounter] = r.Next(10);
            }

            // Use a foreach loop to write Random Numbers to screen
            Console.Write("Debug Hint: ");
            foreach (int iArraySpace in RandNums)
            {
                Console.Write(iArraySpace);
            }

            Console.WriteLine("\nThe Computer has a random {0} digit number in memory. ", LevelDifficulty);
            Console.WriteLine("Enter {0} numbers: ", LevelDifficulty);

      do
      {
          NumberCorrect = 0;
          NumberOfMatches = 0; 
            // Use a for loop to read user input to array
            for (int iCounter = 0; iCounter < LevelDifficulty; iCounter++)
            {
                UserInput[iCounter] = int.Parse(Console.ReadLine());
            }
            // Count the number of correct guesses
            for (int iCounter = 0; iCounter < LevelDifficulty; iCounter++)
            {
                if (RandNums[iCounter] == UserInput[iCounter])
                    NumberCorrect++;
            }

            Console.Write("\nRandom Number: ");
            foreach (int iArraySpace in RandNums) // Use a foreach loop to display Random Numbers
            {
                Console.Write(iArraySpace);
            }
            Console.Write("\nUser Guessed; ");
            foreach (int iArraySpace in UserInput) // Use a foreach loop to display User Input
            {
                Console.Write(iArraySpace);
            }

		// Copy RandNums to TempArray using a For Loop
		 for (int iArrayCell = 0; iArrayCell < LevelDifficulty; iArrayCell++)
		{
		    TempArray[iArrayCell] = RandNums[iArrayCell]; 
		}

                // Use a for loop to iterate through each of MyNum Array Cells
                for (int aCounter = 0; aCounter < LevelDifficulty; aCounter++)
                {
                    // Compare each cell consecutively to each of the other's
                    for (int bCounter = 0; bCounter < LevelDifficulty; bCounter++)
                    {
                        if (UserInput[aCounter] == TempArray[bCounter])
                        {
                            TempArray[aCounter] = TempArray[aCounter] + 10;
                            NumberOfMatches++;
                            break;
                        }
                    }
                }
                Console.WriteLine("\nYou have {0} right", NumberOfMatches);
                Console.WriteLine("{0} In the correct order", NumberCorrect); 
            } while (NumberCorrect != LevelDifficulty);
            Console.WriteLine("Correct"); 
        }
    }
}
