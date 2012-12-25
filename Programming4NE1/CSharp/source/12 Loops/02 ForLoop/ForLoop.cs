using System;

class ForLoop
{
    public static void Main()
	{
	// Variable Declaration
	int  iCounter ; // It's just as easy to declare this within the For Loop itself

   // Starting at 0 ; While Var is less than 10 ; Increment Var by 1 each loop
        for ( iCounter = 0 ; iCounter  < 10 ; iCounter++ )
             Console.Write ( "{0} " , iCounter  ) ; // Insert Variable into output string followed by a space
	}
} 
