using System ; 
class RefOut
{ 
static void Split ( string name , out string firstNames , out string lastName )
{ 
int i = name.LastIndexOf ( ' ' ) ; 
firstNames = name.Substring ( 0 , i ) ; 
lastName = name.Substring ( i + 1 ) ; 
 }

	static void Main ( )
	{ 
	string a , b ; 
	Split ( "Nuno Bettencourt" , out a , out b ) ; 
	Console.Write ( "firstNames: {0}, lastName: {1}" , a , b ) ; 
	} 
} 
