using System ;
using System.Collections.Generic ;
using System.Text ;
namespace Tutorial.RandomNumbers
{
    class RandomFromZero
    {
        static void Main (  ) 
        {
	// Declare an Instance of Random Class
	Random MyRandNumb = new Random() ;

	// Print a random number between 0 and 9 to the screen
	Console.WriteLine( MyRandNumb.Next(10) ) ; // <--- Specify Max number + 1
        }
    }
}
