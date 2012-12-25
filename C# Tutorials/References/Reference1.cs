using System ; 
using System.Text ; 

class AReference
{
	static void Main ( )
	{
	StringBuilder x ; // Declare references
	StringBuilder y ; 

	x = new StringBuilder ( "Hello" ) ;  // Store string value in Reference x
	y = x ;  // Store one Reference in another
	x.Append ( " there!" ) ;  // Change the original...
	Console.Write ( y ) ; // and the Reference to it is updated as well!
	} 
} 