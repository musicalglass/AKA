/* Do_While.cs
Add a list of integers. Keep going until End Of File
Written by: Your_Name
Date:
*/

using System;

public class DoWhile
{
        static void Main ()
        {	
	/* Local Declarations */
	int iUser_Input ;
	int iSum = 0 ;

	/* Statements */
        Console.WriteLine ( "Enter some numbers ( 0 to stop ) :\n" ) ; 

	do
		{
		iUser_Input = int.Parse ( Console.ReadLine () ) ;
		iSum += iUser_Input ;
		        try
        {
		Console.WriteLine ( "Total: {0}", iSum ) ;
        }
        catch
        {
		Console.WriteLine ( "That does not compute. \n" ) ;
		Console.WriteLine ( "Expected numerical input." ) ;
		Console.WriteLine ( "Followed by a Return after each number." ) ;
        }

		}
	while ( iUser_Input != 0 ) ;

	Console.WriteLine ( "\nProgram terminated" ) ; 
	Console.WriteLine ( "Have a day. :| \n" ) ; 
	}	// end Main
}	// end class DoWhile
