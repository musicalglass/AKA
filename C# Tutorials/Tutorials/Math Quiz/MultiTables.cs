using System ; 

class MultiplicationTables
{ 
	static void Main ( )
	{ 
	int iLimit = 10 ; 
	int iMultiplicand = 1 ; 
	int iMultiplyer = 1 ;

		while  ( iMultiplicand <= iLimit ) 
		{

		Console.Write ( "{0} * {1} = " , iMultiplicand , iMultiplyer ) ; 
		Console.WriteLine ( iMultiplicand * iMultiplyer ) ; 
		Console.ReadLine () ;
		iMultiplyer++ ; 
			if ( iMultiplyer == iLimit )
			{
			iMultiplicand++ ; 
			iMultiplyer = 1 ; 
			}
		}
		Console.Write ( "Terminated :|" ) ; 
	} 
} 
