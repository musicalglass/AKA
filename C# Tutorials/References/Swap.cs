using System ; 

class SwapStuff

{ 
static void Swap ( ref string a , ref string b )
{ 
string temp = a ; 
a = b ; 
b = temp ; 
 }
	static void Main ( )
	{ 
	string x = "Day" ; 
	string y = "Night" ; 
	Swap ( ref x , ref y ) ; 
	System.Console.Write ( "x is {0} , y is {1}" , x , y ) ; 
	} 
} 
