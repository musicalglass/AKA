using System;

class GuessNumber
{
	public static void Main()
	{
	int iSecretNumber = 7 ; 

	Console.Write (  "Enter the secret number: " ) ;
	int iMyNumber  = int.Parse ( Console.ReadLine () ) ; 	

	if  ( iMyNumber == iSecretNumber ) 
	Console.Write (  "Yep" ) ;

	if  ( iMyNumber != iSecretNumber ) 
	Console.Write (  "Nope" ) ;
	}
}