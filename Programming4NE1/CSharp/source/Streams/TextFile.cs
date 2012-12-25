using System ; 
using System.IO ;

class StreamTextFile
{ 
	static void Main ( )
	{ 
	Stream s = new FileStream ( "foo.txt" , FileMode.Create ) ; 
	s.WriteByte ( 67 ) ; 
	s.WriteByte ( 35 ) ; 
	s.Close ( ) ;
	} 
} 
