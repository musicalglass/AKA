using System ; 
using System.IO ;
using System.Text ; 

class StringWrite
{ 
	static void Main ( )
	{ 
	StringBuilder sb = new StringBuilder ( ) ;
	StringWriter sw = new StringWriter ( sb ) ; 
	WriteHello ( sw ) ; 
	Console.WriteLine ( sb ) ;
	} 
	static void WriteHello ( TextWriter tw ) 
	{
	tw.Write ( "Hello, String I/O! " ) ;
	}
} 
