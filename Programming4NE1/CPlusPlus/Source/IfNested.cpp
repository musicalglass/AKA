/* A Nested If Statement
Three way selction using If Statement
Written by: Your Name
Date: 11/23/05
*/
#include <stdio.h>

int main ( void )
{

/* Local Declarations */
	int a ;
	int b ;

/* Statements */
	printf ( "Please enter two integers: " ) ;
	scanf ( "%d %d", &a, &b ) ;

	if ( a <= b )
		if ( a < b )
		printf ( "%d < %d\n", a, b ) ;
	else
		printf ( "%d == %d\n", a, b ) ;
	else
		printf ( "%d > %d\n", a, b ) ;

return 0 ;
} /* main */

