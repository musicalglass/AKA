using System;
public class MathQuiz
{
    static void Main()
    {
        // Local Declarations
        const int ArraySize = 10;
        int SwapSpace = 0;
        int UserAnswer = 0;
        bool ToggleTimer = true;
        DateTime startTime = DateTime.Now;

        //create an 10 x 10 2-Dimensional Array 0 to 9
        double[,] MultiTable = new double[ArraySize, ArraySize];

        // Declare an Instance of Random Class outside the Loop
        Random MyRandNumb = new Random();

        // Create 4, one dimensional arrays for Multiplicands, Multiplyers, Queue and Elapsed Time
        int[] Multiplicands = new int[ArraySize * ArraySize];
        int[] Multiplyers = new int[ArraySize * ArraySize];
        int[] Queue = new int[ArraySize * ArraySize];
        double[] ElapsedTime = new double[ArraySize * ArraySize];


        // Fill Multiplicands and Multiplyers Arrays with seed numbers
        for (int hCounter = 0; hCounter < ArraySize; hCounter++)
        {
            for (int iCounter = (hCounter * ArraySize); iCounter < ((hCounter * ArraySize) + ArraySize); iCounter++)
            {  //  000000000, 111111111, 222... etc.
                Multiplicands[iCounter] = hCounter;
            }
        }

        for (int hCounter = 0; hCounter < ArraySize; hCounter++)
        {   // 123456789, 123456789, 123... etc.
            for (int iCounter = 0; iCounter < (ArraySize); iCounter++)
            {
                Multiplyers[iCounter + (hCounter * ArraySize)] = iCounter;
            }
        }

        // Number the Queue
        for (int iCounter = 0; iCounter < ArraySize * ArraySize; iCounter++)
        {
            Queue[iCounter] = iCounter;
        }

        //Shuffle the Queue in 4 separate overlapping segments so it starts easy and gets harder
        // 0-27  18-45 36-63 54-81
        // 0 - 3   2 - 5   4 - 7    6 - 9      ( * 9 or SizeOfArray )
        for (int iCounter = 0; iCounter < 9; iCounter++)
        {
            for (int kCounter = ((iCounter * 9) + 1); kCounter < (((iCounter + 3) * 9) + 1); kCounter++)
            {
                // Generate Random number from 1 to ArraySize * ArraySize
                int Swap = MyRandNumb.Next((1 + (iCounter * 9)), ((iCounter + 3) * 9));

                SwapSpace = Queue[kCounter]; // Store each cell temporarily in SwapSpace Variable
                Queue[kCounter] = Queue[Swap]; // Swap two random cells
                Queue[Swap] = SwapSpace; // Put SwapSpace Variable back in leftover cell
            }
            iCounter++;
        }

        //Quiz the user based on the Current Queue Number
        // Use a For Loop to print it to the screen
        for (int jCounter = 0; jCounter < (ArraySize * ArraySize); jCounter++)
        {
            if (ToggleTimer == true)
            {
                startTime = DateTime.Now;
            }
        StartHere:
            Console.WriteLine("{0} X {1} = ", Multiplicands[Queue[jCounter]], Multiplyers[Queue[jCounter]]);
            try
            {
                UserAnswer = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nThat does not compute!\n ");
                Console.WriteLine("Expected whole number input. ");
                Console.WriteLine("Please try again.\n ");
                goto StartHere;
            }

            if (UserAnswer == (Multiplicands[Queue[jCounter]] * Multiplyers[Queue[jCounter]]))
            {
                Console.WriteLine("Correct!");
                DateTime stopTime = DateTime.Now;
                TimeSpan TimeElapsed = (stopTime - startTime);
                Console.Write("Elapsed Time:  ");
                Console.WriteLine(TimeElapsed.TotalSeconds);
                ToggleTimer = true;
                //Store the elapsed time of each answer in the MultiTable Array
                MultiTable[Multiplicands[Queue[jCounter]], Multiplyers[Queue[jCounter]]] = TimeElapsed.TotalSeconds;
            }
            else
            {
                Console.WriteLine("Nope, try again");
                ToggleTimer = false;
                jCounter--;
            }

        }

        // Calculate the average answer time
	// Unused cell @ Array Space 0 is useful for temporarily swapping FloatDoubles
        ElapsedTime [ 0 ] = 0.0 ;  // Should be zeroed but let's make sure
        foreach (double elementValue in MultiTable) // Read entire 2 Dim Array using Foreach
        {
            ElapsedTime [ 0 ] = ElapsedTime [ 0 ] + elementValue ;  // Add all the values together
        }
        Console.Write( "The average response time was: " ) ;
	// Divide total by the number of Array Cells and Voila!
	ElapsedTime [ 0 ] = ElapsedTime [ 0 ] / ( ArraySize * ArraySize ) ; // Store the Average at Cell 0
        Console.WriteLine( ElapsedTime [ 0 ]  ) ; // Print it


        // Begin new quiz using slower than average times

    }
}