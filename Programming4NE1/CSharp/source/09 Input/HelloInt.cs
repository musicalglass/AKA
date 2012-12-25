
// Namespace Declaration
using System;

// Program start class
class HelloName
{
    // Main begins program execution.
    public static void Main ( )
    {
        // Write to console / get input
        Console.Write ( "What is your name?: " ) ;
	int MyVariable = Console.ReadLine( ) ; 
        Console.Write ( "Hello, {0}! " , MyVariable ) ; 
    }
} 
