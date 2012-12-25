using System ; 

class OperatorPrecedence
{ 
	static void Main ( )
	{ 
	Console.Write ( 1 + 2 * 3) ; // This will multiply 2 X 3 first
	Console.Write ( (1 + 2 ) * 3) ; // This forces it to add 1 + 2 first
	Console.Write ( 2 * 2 + 3) ; 
	Console.Write ( 2 * ( 2 + 3 ) ) ; 
	} 
} 
