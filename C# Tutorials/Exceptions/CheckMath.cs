using System ; 

class OverflowCheck
{ 
	static void Main ( )
	{ 
	int a = 1000000 ;
	int b = 1000000 ;
	int c = checked ( a * b ) ; 
	} 
} 
