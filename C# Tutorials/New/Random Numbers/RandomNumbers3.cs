using System ;
using System.Collections.Generic ;
using System.Text ;

namespace Tutorial.RandomNumbers
{
    class RandomFirstAndLast
    {
        static void Main (  ) 
        {
   	// Declare an Instance of Random Class
		  Random ComfortablyNumb = new Random() ;

       // Print a random number between 10 and 20 to the screen
         Console.WriteLine( ComfortablyNumb.Next(10, 21) ) ; 
        }
    }
}
