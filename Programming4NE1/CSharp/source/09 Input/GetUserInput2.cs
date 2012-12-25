using System;
class UserInput
{
    public static void Main ()
	{
	string UserInput ; // Declare a String Variable

	// Use \n to make blinking cursor appear on next line
	Console.Write ( "Please enter some text:\n" ) ;  // <-- Instead of user type appearing here
	// <-- User now types here
	UserInput = Console.ReadLine() ;  

        Console.Write ( "You entered: " ) ; 
        Console.Write ( UserInput ) ; 
	}
} 
