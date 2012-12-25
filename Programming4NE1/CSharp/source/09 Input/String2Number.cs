using System;
class StringToNumber
{
    public static void Main ()
	{
	Console.Write ( "Please enter a number: " ) ; 

	/* Declare a Variable, convert user input String to Integer and
	store value in variable.  All on one line */
	int StringToNumber = int.Parse ( Console.ReadLine () ) ; 

        // Insert Variable into a sentence
	Console.Write ( "You entered: {0}." , StringToNumber ) ; 
	}
} 
