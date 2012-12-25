using System ; 
using System.Text ; 

class AReference
{
	static void Main ( )
	{
	StringBuilder x = new StringBuilder ( "Hello" ) ;  
	StringBuilder y = x ;  
	x = null ; // Set original to point at no object
	y.Append ( " there!" ) ;  
	Console.Write ( y ) ; // we can still access the object
	} 
} 