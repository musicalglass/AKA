/* Here we use a Float Variable to store the result of dividing two Integers. 
   Try 20 divided by 7 now */
using System;
class DivideTwoNums
{
    public static void Main ()
	{
	// Variable Declarations
	int iNumb1 ; 
	int iNumb2 ; 
	float fResult ;  // <-- Declare Float Variable for storing decimals

	// Statements
	Console.Write ( "\nThis program will divide two numbers\nEnter the first number: " ) ; 
	iNumb1 = int.Parse ( Console.ReadLine () ) ; 

	Console.Write ( "Enter the second number: " ) ; 
	iNumb2 = int.Parse ( Console.ReadLine () ) ; 

	fResult = ( float )iNumb1 / ( float )iNumb2 ;  // <-- Store results in Float Variable

	Console.Write ( "The result of {0} divided by {1} is {2}\n" , iNumb1 , iNumb2 , fResult ) ; 
	}
} 
