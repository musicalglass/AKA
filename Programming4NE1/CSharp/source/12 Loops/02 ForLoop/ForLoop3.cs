using System;

class ForLoop
{
    public static void Main()
	{ 
	Console.Write ( "\nHow to become a programmer: \nPress the Enter key\n"  ) ;
	Console.Read () ; 
// Start at 1 ; While Var is less than or equal to 10 ; Increment Var by 1 each loop
        for ( int  iCounter = 1 ; iCounter  <= 10 ; iCounter++ )
		{       //<--  Loop everything between the brackets
		Console.Write ( "Lesson "  ) ;
		Console.Write (  iCounter  ) ;
		Console.Write ( ": Practice\n"  ) ;
		}	// <-- end For Loop
	}
} 
