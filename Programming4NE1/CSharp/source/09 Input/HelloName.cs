using System;
class HelloName
{
    public static void Main ()
	{
	
	string UserInput ; // Declare a String Variable

	// Statements
	Console.Write ( "What is your name? " ) ;  // Prompt the user for input
	UserInput = Console.ReadLine() ;  // Store whatever user types in Variable

        Console.Write ( "Hello, {0}! " , UserInput ) ; 
	}
} 
