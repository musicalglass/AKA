using System ; 

class MyReference

{ 
static void MyRef ( ref int p ) { ++p ; }
	static void Main ( )
	{ 
	int x = 8 ; 
	MyRef ( ref x ) ;  // Send reference of x to MyRef
	Console.Write ( x ) ; // x is now 9
	} 
} 
