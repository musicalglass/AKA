
// Namespace Declaration
using System;

// Program start class
class HelloInt
{
    // Main begins program execution.
    public static void Main ( )
    {
        string UserInput ; // Declare a String Variable to store user input
	int StringToNumber ; // Declare Integer to store converted text to number

        // Write to console / get input
        Console.Write ( "Please enter a number:  " ) ;
	UserInput = Console.ReadLine () ; // Store user input in String
	StringToNumber = int.Parse ( UserInput ) ; // Convert input String and store in Integer Variable
        Console.Write ( "You entered {0} " , StringToNumber ) ; 
    }
} 
