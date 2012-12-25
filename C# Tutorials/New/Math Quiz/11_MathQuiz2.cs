using System;
public class MathQuiz
{
    static void Main()
    {
        // Local Declarations
        const int ArraySize = 10;
        int SwapSpace = 0;
	int UserAnswer ;
	bool ToggleInput = true ;
	DateTime startTime = DateTime.Now;

        //create an 10 x 10 2-Dimensional Array 0 to 9
        int[,] MultiTable = new int[ArraySize, ArraySize];

        // Declare an Instance of Random Class outside the Loop
        Random MyRandNumb = new Random();

        // Create 4, one dimensional arrays for Multiplicands, Multiplyers, Queue and Elapsed Time
        int[] Multiplicands = new int[ArraySize * ArraySize];
        int[] Multiplyers = new int[ArraySize * ArraySize];
        int[] Queue = new int[ArraySize * ArraySize];
        float[] ElapsedTime = new float[ArraySize * ArraySize];


        // Fill Multiplicands and Multiplyers Arrays with seed numbers
        for (int hCounter = 0; hCounter < ArraySize; hCounter++)
        {
            for (int iCounter = ( hCounter * ArraySize ) ; iCounter < ( ( hCounter * ArraySize ) + ArraySize ) ; iCounter++)
            {  //  000000000, 111111111, 222... etc.
                Multiplicands[iCounter] = hCounter;
            } 
        }

	for (int hCounter = 0; hCounter < ArraySize ; hCounter++)
        {   // 123456789, 123456789, 123... etc.
            for (int iCounter = 0 ; iCounter < ( ArraySize ) ; iCounter++)
            {
                Multiplyers[ iCounter + ( hCounter *  ArraySize ) ] = iCounter ;
            } 
        }

        // Number the Queue
        for (int iCounter = 0; iCounter < ArraySize * ArraySize; iCounter++)
        {
            Queue[iCounter] = iCounter;
        }

        //Shuffle the Queue in 4 separate overlapping segments so it starts easy and gets harder
        // 0-27  18-45 36-63 54-81
        // 0 - 3   2 - 5  4 - 7  6 - 9

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
        for ( int jCounter = 0; jCounter < ( ArraySize * ArraySize ); jCounter++ )
        {
	if ( ToggleInput == true )
	{
	 startTime = DateTime.Now;
	}

         Console.WriteLine( "{0} X {1} = ", Multiplicands[ Queue[ jCounter ] ] , Multiplyers[ Queue[ jCounter ] ] )  ;
	UserAnswer = int.Parse ( Console.ReadLine () ) ;
	if ( UserAnswer == ( Multiplicands[ Queue[ jCounter ] ] * Multiplyers[ Queue[ jCounter ] ]  ) )
	{
	Console.WriteLine( "Correct!" )  ;
	DateTime stopTime = DateTime.Now;
	TimeSpan TimeElapsed = ( stopTime - startTime ) ;
	Console.Write( "Elapsed Time:  " )  ;
	Console.WriteLine( TimeElapsed.TotalSeconds )  ;
	ToggleInput = true ;
	}
	else
	{
	Console.WriteLine( "Nope, try again" )  ;
	ToggleInput = false ;
	jCounter-- ;
	}
        }

        //Store the elapsed time of each answer in the ElapsedTime Array

        // Calculate the average answer time

        // Begin new quiz using slower than average times

    }
}