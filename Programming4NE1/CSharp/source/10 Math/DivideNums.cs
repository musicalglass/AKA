/* Notice that an Integer Variable can only contain whole numbers
    try entering 20 divided by 7. Then try 21 / 7 */
using System;
class DivideTwoNums
{
    public static void Main ()
	{
	// Variable Declarations
	string sUserInput ; 
	int iNumb1 ; 
	int iNumb2 ; 
	int iResult ; 

	// Statements
	Console.Write ( "\nThis program will divide two numbers\n\n" ) ; 
	Console.Write ( "Enter the first number: " ) ; 
	sUserInput = Console.ReadLine () ; // Get input String from user
	iNumb1 = int.Parse ( sUserInput ) ;  // Convert String to Integer

	Console.Write ( "Enter the second number: " ) ; 
	iNumb2 = int.Parse ( Console.ReadLine () ) ;  // This does the SAME THING using one line

	iResult = iNumb1 / iNumb2 ;  // Divide first Variable by second Variable

	Console.Write ( "The result of {0} divided by {1} is {2}.\n" , iNumb1 , iNumb2 , iResult ) ; 
	}
} 
