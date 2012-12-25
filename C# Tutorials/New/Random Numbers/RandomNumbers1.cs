using System ;
using System.Collections.Generic ;
using System.Text ;
namespace Tutorial.RandomNumbers
{
    class RandomNumber
    {
        static void Main (  ) 
        {
	// Declare an Instance of Random Class outside the Loop
	Random MyRandNumb = new Random() ;

	// Print a random number between 1 and 2,147,483,647 to the screen
	Console.WriteLine( MyRandNumb.Next() ) ; 
        }
    }
}
