using System ; 
using System.Text ; 

class AReference
{
	static void Main ( )
	{
	StringBuilder x = new StringBuilder ( "Hello" ) ;  // Declare Reference and assign value to it
	StringBuilder y = x ;  // Declare another Reference and make it a Clone
	y.Append ( " there!" ) ;  // Change the duplicate...
	Console.Write ( x ) ; // and the original is updated as well!
	} 
} 