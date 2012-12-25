// RandomNumbers4.cs
// Use a loop to print out 10 numbers between 10 and 20
using System ;
using System.Collections.Generic ;
using System.Text ;
namespace Tutorial.RandomNumbers
{
    class RandomForLoop
    {
        static void Main (  ) 
        {
            // Declare an Instance of Random Class outside the Loop
            Random MyRandNumb = new Random() ;
	
            for  (int i = 0 ; i < 10 ; i++ )
            {
                Console.WriteLine(MyRandNumb.Next(10, 1 + 20) ) ;  // Use it over and over
            }
	    // Note how I added 1 to the MaxNumber 20, now low and high are WYSIWYG
        }
    }
}
