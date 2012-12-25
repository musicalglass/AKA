/* Add Two Digits
Demonstrates the results of logical operators.
Written by: Dillinger
Date: 11/23/05
*/
#include <stdio.h>

int main ( void )
{

/* Local Declarations */
	int a = 5 ;
	int b = -3 ;
	int c = 0 ;

/* Statements */
	printf ( " %2d &&  %2d is %2d\n", a, b, a &&  b ) ;
	printf ( " %2d &&  %2d is %2d\n", a, c, a &&  c ) ;
	printf ( " %2d &&  %2d is %2d\n", c, a, c &&  a ) ;
	printf ( " %2d ||  %2d is %2d\n", a, c, a ||  c ) ;
	printf ( " %2d ||  %2d is %2d\n", c, a, c ||  a ) ;
	printf ( " %2d ||  %2d is %2d\n", c, c, c ||  c ) ;
	printf ( "!%2d && !%2d is %2d\n", a, c,!a && !c ) ;
	printf ( "!%2d &&  %2d is %2d\n", a, c,!a &&  c ) ;
	printf ( "%2d &&  !%2d is %2d\n", a, c, a && !c ) ;
return 0 ;
} /* main */

