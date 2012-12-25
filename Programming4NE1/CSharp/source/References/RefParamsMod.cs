using System ; 
class RefParamsMod
{ 
static int Add ( params int [ ] iMyArray )
{ 
int sum = 0 ; 
foreach ( int i in iMyArray )
sum += i ; 
return sum ; 
 }

	static void Main ( )
	{ 
	int i = Add ( 1 , 2 , 3 , 4 ) ; 
	Console.Write ( i ) ; 
	} 
} 
