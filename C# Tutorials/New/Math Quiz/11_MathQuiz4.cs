using System;
using System.Media;

public class MathQuiz
{
    static void Main()
    {
        // Local Declarations
        const int ArraySize = 10;
        int SwapSpace = 0;
        bool ToggleTimer = true;
        DateTime startTime = DateTime.Now;

        //create a 10 x 10 2-Dimensional Array 0 to 9
        double[,] MultiTable = new double[ArraySize, ArraySize];

        // Declare an Instance of Random Class outside the Loop
        Random MyRandNumb = new Random();

        // Create 4, one dimensional arrays for Multiplicands, Multiplyers, Queue and Elapsed Time
        int[] Multiplicands = new int[ArraySize * ArraySize];
        int[] Multiplyers = new int[ArraySize * ArraySize];
        int[] Queue = new int[ArraySize * ArraySize];
        double[] ElapsedTime = new double[ArraySize * ArraySize];

            Console.WriteLine("\n\nWelcome to Dillinger's Math Quiz program.\n");
	            System.Threading.Thread.Sleep(3000);
	    Console.WriteLine("First let's go through the multiplication tables");
            Console.WriteLine("and calculate your average response time.\n");
	    System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Press the Enter key to Begin.");
            Console.ReadLine();

	    int UserAnswer = 0; //

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
        for (int jCounter = 1; jCounter < (ArraySize * ArraySize); jCounter++)
        {
            if (ToggleTimer == true)   // Don't reset the timer for Retry
            {
                startTime = DateTime.Now; // Get the current time
            }
        StartHere:
            Console.Write("\n{0} X {1} = ", 
                Multiplicands[Queue[jCounter]], Multiplyers[Queue[jCounter]]);
            try
            {   // Convert User input to numerical Integer
                UserAnswer = int.Parse(Console.ReadLine());
            }
            catch
            {
                SystemSounds.Exclamation.Play();
                Console.WriteLine("\nThat does not compute!\n ");
                Console.WriteLine("Expected whole number input. ");
                Console.WriteLine("Please try again.\n ");
                goto StartHere;
            }

            if (UserAnswer == (Multiplicands[Queue[jCounter]] * Multiplyers[Queue[jCounter]]))
            {   // if user answer is correct...
                DateTime stopTime = DateTime.Now; // get the current time
                TimeSpan TimeElapsed = (stopTime - startTime); // Calculate elapsed time
                Console.Write("Elapsed Time:  ");
                Console.WriteLine(TimeElapsed.TotalSeconds);
                ToggleTimer = true;
                //Store the elapsed time of each answer in the MultiTable Array
                MultiTable[Multiplicands[Queue[jCounter]], Multiplyers[Queue[jCounter]]] = TimeElapsed.TotalSeconds;
            }
            else
            {
                Console.Beep(100 , 500);
                Console.WriteLine("\nNope, try again");
                ToggleTimer = false;
                jCounter--;
            }
        }

        // Calculate the average answer time
        // Unused cell @ Array Space 0 is useful for temporarily swapping FloatDoubles
        ElapsedTime[0] = 0.0;  // Should be zeroed but let's make sure
        foreach (double elementValue in MultiTable) // Read entire 2 Dim Array using Foreach
        {
            ElapsedTime[0] = ElapsedTime[0] + elementValue;  // Add all the values together
        }
	SystemSounds.Asterisk.Play();
        Console.WriteLine("\n\nGood!\n");
	System.Threading.Thread.Sleep(3000);
        Console.Write("\nThe average response time was: ");
        // Divide total by the number of Array Cells and Voila!
        ElapsedTime[0] = ElapsedTime[0] / (ArraySize * ArraySize); // Store the Average at Cell 0
        Console.WriteLine("{0} seconds.\n",ElapsedTime[0]); // Print it
	System.Threading.Thread.Sleep(3000);
        Console.WriteLine("Let's focus on the ones that took longer than average: \n");
        System.Threading.Thread.Sleep(3000);
        Console.WriteLine("Press the Enter key to continue\n");
        Console.ReadLine();
	UserAnswer = 0; 

        // Begin new quiz using slower than average times
        // Renumber the Queue
        for (int iCounter = 0; iCounter < ArraySize * ArraySize; iCounter++)
        {
            Queue[iCounter] = iCounter;
        }

        for (int iCounter = 1; iCounter < (ArraySize * ArraySize); iCounter++)
        {
            // Step through the table
            // Using the Queue Cell coords as Multiplicants, 

            // If Elapsed Time in cell is 0.0 OR
            // If Elapsed time is Less than or equal to Average Time, skip it
            if ((MultiTable[Multiplicands[Queue[iCounter]], Multiplyers[Queue[iCounter]]] != 0.0)
                || (MultiTable[Multiplicands[Queue[iCounter]], Multiplyers[Queue[iCounter]]] > ElapsedTime[0]))
            {

                // Print the iCounter correct answer

                Console.WriteLine("{0} X {1} = {2} \n", 
		Multiplicands[Queue[iCounter]], Multiplyers[Queue[iCounter]], (Multiplicands[Queue[iCounter]] * Multiplyers[Queue[iCounter]]));
                System.Threading.Thread.Sleep(1000);
                // Quiz the user on iCounter
                if (ToggleTimer == true)
                {
                    startTime = DateTime.Now;
                }
            StartHere2:
                Console.Write("\n\nWhat is {0} X {1} ? ", 
                    Multiplicands[Queue[iCounter]], Multiplyers[Queue[iCounter]]);
                try
                {
                    UserAnswer = int.Parse(Console.ReadLine());
                }
                catch
                {
                    SystemSounds.Exclamation.Play();
                    Console.WriteLine("\nThat does not compute!\n ");
                    Console.WriteLine("Expected whole number input. ");
                    Console.WriteLine("Please try again.\n ");
                    goto StartHere2;
                }

                if (UserAnswer == 
                    (Multiplicands[Queue[iCounter]] * Multiplyers[Queue[iCounter]]))
                {
                    DateTime stopTime = DateTime.Now;
                    TimeSpan TimeElapsed = (stopTime - startTime);
                    Console.Write("Elapsed Time:  ");
                    Console.WriteLine(TimeElapsed.TotalSeconds);
                    ToggleTimer = true;
                    //Store the elapsed time of each answer in the MultiTable Array
                    MultiTable[Multiplicands[Queue[iCounter]], Multiplyers[Queue[iCounter]]] = TimeElapsed.TotalSeconds;
                }
                else
                {
                    Console.Beep(100 , 500);
                    Console.WriteLine("\nNope, try again");
                    ToggleTimer = false;
		    goto StartHere2;
                }
            } // end if

            //  Quiz 1 - IF iCounter is >=3 Quiz iCounter - 2
            if (iCounter >= 3)
            {

                // Quiz the user on iCounter - 2
                if (ToggleTimer == true)
                {
                    startTime = DateTime.Now;
                }
            StartHere3:
                Console.Write("\nWhat is {0} X {1} ? ", 
                    Multiplicands[Queue[iCounter - 2]], Multiplyers[Queue[iCounter - 2]]);
                try
                {
                    UserAnswer = int.Parse(Console.ReadLine());
                }
                catch
                {
                    SystemSounds.Exclamation.Play();
                    Console.WriteLine("\nThat does not compute!\n ");
                    Console.WriteLine("Expected whole number input. ");
                    Console.WriteLine("Please try again.\n ");
                    goto StartHere3;
                }

                if (UserAnswer == (Multiplicands[Queue[iCounter - 2]] * Multiplyers[Queue[iCounter - 2]]))
                {
                    DateTime stopTime = DateTime.Now;
                    TimeSpan TimeElapsed = (stopTime - startTime);
                    Console.Write("Elapsed Time:  ");
                    Console.WriteLine(TimeElapsed.TotalSeconds);
                    Console.Write("Previous Elapsed Time:  ");
                    Console.WriteLine(MultiTable[Multiplicands[Queue[iCounter - 2]], Multiplyers[Queue[iCounter - 2]]]);
                    ToggleTimer = true;
                    // Subtract the difference from user's previous anwer
                    if (TimeElapsed.TotalSeconds < MultiTable[Multiplicands[Queue[iCounter - 2]], Multiplyers[Queue[iCounter - 2]]])
                    {
			SystemSounds.Asterisk.Play();
                        Console.Write("You were {0} seconds faster this time!\n",
                        MultiTable[Multiplicands[Queue[iCounter - 2]], Multiplyers[Queue[iCounter - 2]]] -
                        TimeElapsed.TotalSeconds);
                    }
                }
                else
                {
                    Console.Beep(100 , 500);
                    Console.WriteLine("\nNope, try again");
                    ToggleTimer = false;
                    goto StartHere3;
                }

                // If iCounter is >= 3 ,  Random Quiz from 1 to Current - 1 
                if (ToggleTimer == true)
                {
                    startTime = DateTime.Now;
                }
                SwapSpace = MyRandNumb.Next(1, iCounter - 1); // Use Swap Variable to store Rrandom Number
            StartHere4:
                Console.Write("\nWhat is {0} X {1} ? ", Multiplicands[Queue[SwapSpace]], Multiplyers[Queue[SwapSpace]]);
                try
                {
                    UserAnswer = int.Parse(Console.ReadLine());
                }
                catch
                {
                    SystemSounds.Exclamation.Play();
                    Console.WriteLine("\nThat does not compute!\n ");
                    Console.WriteLine("Expected whole number input. ");
                    Console.WriteLine("Please try again.\n ");
                    goto StartHere4;
                }

                if (UserAnswer == (Multiplicands[Queue[SwapSpace]] * Multiplyers[Queue[SwapSpace]]))
                {
                    DateTime stopTime = DateTime.Now;
                    TimeSpan TimeElapsed = (stopTime - startTime);
                    Console.Write("Elapsed Time:  ");
                    Console.WriteLine(TimeElapsed.TotalSeconds);
                    Console.Write("Previous Elapsed Time:  ");
                    Console.WriteLine(MultiTable[Multiplicands[Queue[SwapSpace]], Multiplyers[Queue[SwapSpace]]]);
                    ToggleTimer = true;
                    // Subtract the difference from user's previous anwer
                    if (TimeElapsed.TotalSeconds < MultiTable[Multiplicands[Queue[SwapSpace]], Multiplyers[Queue[SwapSpace]]])
                    {
			SystemSounds.Asterisk.Play();
                        Console.Write("You were {0} seconds faster this time!\n",
                        MultiTable[Multiplicands[Queue[SwapSpace]], Multiplyers[Queue[SwapSpace]]] -
                        TimeElapsed.TotalSeconds);
                    }
                }
                else
                {
                    Console.Beep(100 , 500);
                    Console.WriteLine("\nNope, try again");
                    ToggleTimer = false;
                    goto StartHere4;
                }

            } // end if

        }
            Console.WriteLine("You have reached the end.");
            Console.WriteLine("Press the Enter key to terminate.");
            Console.ReadLine();
    }
}