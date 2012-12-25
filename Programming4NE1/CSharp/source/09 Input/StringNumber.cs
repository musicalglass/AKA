using System;
class StringToNumber
{
    public static void Main ()
	{
	string UserInput ; // Declare a String Variable to store user input
	int StringToNumber ;  // Integer to store Parsed string numbers

	Console.Write ( "Please enter a number: " ) ;  
	UserInput = Console.ReadLine () ; // Store user input in String
	StringToNumber = int.Parse ( UserInput ) ; // Convert input String and store in Integer Variable

        Console.Write ( "You entered: " ) ; 
        Console.Write ( StringToNumber ) ; 
	}
} 
