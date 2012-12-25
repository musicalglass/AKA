/* WhileLoop.cpp
Add a list of integers.
Keep going until End Of File
Written by: Your Name
Date:
*/

#include <stdio.h>
int main ( void )
{
/* Local Declarations */
	int x ;
	int sum = 0 ;

/* Statements */
	printf ( "\n Enter some numbers: CTRL Z to stop \n" ) ;
	while ( scanf ( "%d", &x ) != EOF )
		sum += x ;

	printf ( "The total is: %d", sum ) ;
return 0 ;
}	/* main */
