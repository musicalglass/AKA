using System;
class GiveAndTake
{
    public static void Main ()
	{
	
	int iNumb = 0; // Start with a value of zero

	Console.Write ( "\n {0} \n " , iNumb )  ;  // Write it to the screen

	iNumb = iNumb + 1 ;  // Increase the value of Variable by 1

	Console.Write ( "{0} \n " , iNumb )  ; 

	iNumb++ ; // This also increases the value by one

	Console.Write ( "{0} \n " , iNumb )  ; 

	iNumb = iNumb - 1 ; // Decrease the value of Variable by 1

	Console.Write ( "{0} \n " , iNumb )  ; 

	iNumb-- ; // Same as above

	Console.Write ( "{0} \n" , iNumb )  ; 

	iNumb-- ; 

	Console.Write ( "{0} \n" , iNumb )  ; 
	}
} 
