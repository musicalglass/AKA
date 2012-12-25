
// Namespace Declaration
using System;

// Program start class
class HelloInt2
{
    // Main begins program execution.
    public static void Main ( )
    {
        // Write to console / get input
        Console.Write ( "Please enter a number:  " ) ;

	int StringToNumber = int.Parse ( Console.ReadLine () ) ; // Declare, Convert and Store all in one line
        Console.Write ( "You entered {0} " , StringToNumber ) ; 
    }
} 
