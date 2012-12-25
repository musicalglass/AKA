using System ; 

class MyStrings
{ 
	static void Main ( )
	{ 
	ArrayList a = new ArrayList( ) ;
	a.Add ( 'Vernon" ) ; 
	a.Add ( 'Corey" ) ; 
	a.Add ( 'William" ) ; 
	a.Add ( 'Muzz" ) ; 
	a.Sort ( ) ; 
	for ( int = 0 ; i < a.Count ; i++ ) 
	Console.WriteLine ( a [ i ] ) ;
	} 
} 
