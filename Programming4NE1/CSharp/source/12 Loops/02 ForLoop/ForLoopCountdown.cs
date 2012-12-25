using System;

public class Countdown
{
        static void Main()
        {
	Console.WriteLine("Enter Limit");
	int iLimit = int.Parse ( Console.ReadLine () ) ;
		for ( int i = iLimit ; i >= 1 ; i-- )
		{
		Console.WriteLine( i );
		}
	Console.WriteLine("Blastoff!");
	Console.ReadLine();
        }
}
