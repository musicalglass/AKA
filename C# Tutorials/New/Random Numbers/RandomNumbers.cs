using System ;
using System.Collections.Generic ;
using System.Text ;
namespace Tutorial.RandomNumbers
{
    class RandomNumbers
    {
        static void Main (  ) 
        {
            // Declare an Instance of Random Class outside the Loop
            Random MyRandNumb = new Random() ;

            for ( int i = 0 ; i < 10 ; i++ )
            {
                Console.WriteLine( MyRandNumb.Next() ) ; // Use it over and over
            }

            for  (int i = 0 ; i < 10 ; i++ )
            {
                Console.WriteLine(MyRandNumb.Next(10, 20) ) ; 
            }
        }
    }
}
