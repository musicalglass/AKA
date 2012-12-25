using System ;
using System.Collections.Generic ;
using System.Text ;
namespace Tutorial.RandomNumbers
{
    class FlipACoin
    {
        static void Main (  ) 
        {
	// Declare an Instance of Random Class
	Random MyRandNumb = new Random() ;

	// Generate a random number from 0 to 1
	int MyVariable = MyRandNumb.Next(1++) ;

		//  Print out different text based on the decision
		if ( My_Coin == 0 ) 
		Console.Write ( "Heads" ) ; 
		if ( My_Coin == 1 ) 
		Console.Write ( "Tails" ) ; 
        }
    }
}

