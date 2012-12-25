using System;
class SecretPassword
{
	public static void Main ()
	{
	string sUserInput ; 
	string sSecretPassword = "Open Sesame" ; 

	Console.Write (  "\nWhat is the secret password? \n" ) ;  // Note password will be case sensitive
	sUserInput = Console.ReadLine () ; 

	if ( sUserInput == sSecretPassword ) 
		{
		Console.Write ( "\nWelcome! \n\n" ) ; 
		Console.Write ( "Press the Enter key to exit\n" ) ; 
		Console.ReadLine () ; 
		Console.Write ( "Goodbye. Have a nice day :)\n" ) ; 
		}

	if ( sUserInput != sSecretPassword )
		{
		Console.Write ( "\nSorry, you do not have authorization. \n" ) ; 
		Console.Write ( "Program Terminated :( \n" ) ;
		}
	}
}
