using System;
public class MathQuiz
{
    static void Main()
    {
        // Local Declarations
        const int ArrayMod = 10; 
        //create an 11 x 11 2-Dimensional Array 0 - 10
        int[,] MultiTable = new int[ArrayMod, ArrayMod];

        // Number the Zero Cells in both dimesions
        for (int iCounter = 1; iCounter < ArrayMod; iCounter++)
            MultiTable[iCounter, 0] = iCounter;

        for (int iCounter = 1; iCounter < ArrayMod; iCounter++)
            MultiTable[0, iCounter] = iCounter; 

        // Shuffle the fields
        // Declare an Instance of Random Class outside the Loop
        Random MyRandNumb = new Random();

		// Shuffle Array 1st Dimension
	        for (int iCounter = 1; iCounter < ArrayMod; iCounter++) 
		 {
		 // Generate Random number from 1 to CardNum - 1
		int Swap = MyRandNumb.Next( 1, ArrayMod );

		MultiTable[ 0, 0 ] = MultiTable[ iCounter, 0 ]; // Store consecutive card in extra space 0,0
		MultiTable[ iCounter, 0 ] = MultiTable[ Swap, 0 ]; // Swap two random cards ?, 0
		MultiTable[ Swap, 0 ] = MultiTable[ 0, 0 ]; // Put spare card back in leftover space
		}

				//Shuffle Array 2nd Dimension once before reading each row
        for (int kCounter = 1; kCounter < ArrayMod; kCounter++)
        {
            // Generate Random number from 1 to CardNum - 1
            int Swap = MyRandNumb.Next(1, ArrayMod);

            MultiTable[0, 0] = MultiTable[0, kCounter]; // Store consecutive card in extra space 0,0
            MultiTable[0, kCounter] = MultiTable[0, Swap]; // Swap two random cards 0, ?
            MultiTable[0, Swap] = MultiTable[0, 0]; // Put spare card back in leftover space
        }
// ---------------------------------

        // Step through the Array
        // 1, 1 - 9
        // 2, 1 - 9
        // 3, 1 - 9 etc.
        for (int iCounter = 1; iCounter < ( ArrayMod ) ; iCounter++)  
        {
		//Shuffle Array 2nd Dimension once before reading each row
	        for (int hCounter = 1; hCounter < ArrayMod; hCounter++) 
		 {
		 // Generate Random number from 1 to CardNum - 1
		int Swap = MyRandNumb.Next( 1, ArrayMod );

		MultiTable[ 0, 0 ] = MultiTable[ hCounter, 0 ]; // Store consecutive card in extra space 0,0
		MultiTable[ hCounter, 0 ] = MultiTable[ Swap, 0 ]; // Swap two random cards ?, 0
		MultiTable[ Swap, 0 ] = MultiTable[ 0, 0 ]; // Put spare card back in leftover space
		}

		for (int jCounter = 1; jCounter < ( ArrayMod ); jCounter++)
		{
                Console.Write( MultiTable[ 0, jCounter ] );
                Console.Write( " X " );
                Console.Write(MultiTable[ iCounter, 0] );
		Console.Write("   ");
		}
            Console.Write(" \n ");
        }

        //Quiz the user based on the corresponding Zero cells

        //Store the elapsed time of each answer in the 2 Dimensional Array

        // Calculate the average answer time

        // Begin new quiz using slower than average times

    }
}