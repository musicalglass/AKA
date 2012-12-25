using System;
class AddTwoNums
{
    public static void Main ()
	{
	Console.Write ( "\nEnter the first number: " ) ; 
	int UserInput1 = int.Parse ( Console.ReadLine () ) ; 
	Console.Write ( "Enter the second number: " ) ; 
	int UserInput2 = int.Parse ( Console.ReadLine () ) ; 

	int iSum = UserInput1 + UserInput2 ; 

        // Insert multiple Variables into a sentence
	Console.Write ( "The sum of {0} and {1} is {2}.\n" , UserInput1 , UserInput2 , iSum ) ; 
	}
} 
