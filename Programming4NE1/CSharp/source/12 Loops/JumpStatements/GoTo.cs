using System ; 

class CheeseTrees
{ 
	static void Main ( )
	{ 
	
	int x = 0 ; 
	int y ;

	start:
	y = 0 ; 
	x++ ; 

		while ( true )
		{
		Console.WriteLine ( y ) ; 
		y++ ; 
		if ( x ==4 ) break ;
		if ( y == 5 ) goto start ; 
		}
		Console.Write ( "Program terminated" ) ; 
	} 
} 
