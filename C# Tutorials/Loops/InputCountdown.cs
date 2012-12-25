using System;

public class InputCountdown
{
        static void Main ()
        {
        Console.WriteLine ( "Enter Limit" ) ; 

        int iLimit = int.Parse ( Console.ReadLine () ) ;

	for ( int iCounter = iLimit ; iCounter  >= 1 ; iCounter-- )
	{
	Console.WriteLine ( iCounter ) ;
	}

        Console.WriteLine ("Blastoff!") ;

        Console.WriteLine ( "\nPress Enter to Exit" ) ;
        Console.ReadLine () ;
        }
}
