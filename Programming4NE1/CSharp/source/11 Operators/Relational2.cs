using System;

class MysteryNumber
{
	public static void Main()
	{
	int iMysteryNumber = 10 ; 

	Console.Write (  "\nEnter a number: " ) ;
	int iMyNumber  = int.Parse ( Console.ReadLine () ) ; 	

	if  ( iMyNumber < iMysteryNumber ) 
	Console.Write (  "The number you entered is Less Than the mystery number\n" ) ;

	if  ( iMyNumber > iMysteryNumber ) 
	Console.Write (  "The number you entered is Greater Than the mystery number\n" ) ;

	if  ( iMyNumber == iMysteryNumber ) 
	Console.Write (  "You have entered the mystery number!\n" ) ;
	}
}