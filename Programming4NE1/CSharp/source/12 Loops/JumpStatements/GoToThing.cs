// Note couldn't name file GoTo.cs
// goto is a Command Prompt command
using System ; 

class CheeseTrees
{ 
	static void Main ( )
	{ 
	
	int iCounter = 0 ; 
	int iRepeat ;
	int iCounterLimit = 5 ; 
	int iRepeatLimit = 4 ; 

	start:
	iRepeat = 0 ; 
	iCounter++ ; 
	Console.WriteLine () ; 
	     
		while ( true )
		{
		if ( iCounter > iCounterLimit ) break ;
		Console.WriteLine ( iRepeat ) ; 
		iRepeat++ ; 
		if ( iRepeat > iRepeatLimit ) goto start ; 
		}
	} 
} 
