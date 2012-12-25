/* Simple Calculator using Functions to Add and Subtract two integers
Written by: Your Name
Date: 11/24/05
*/
#include <stdio.h>

int main ( void )
{

/* Prototype Declarations */
	int add ( int a, int b ) ;
	int subtract ( int a, int b ) ;

/* Local Declarations */
	int a ;
	int b ;
	int sum ;
	int diff ;

/* Statements */
	/* Prompt user for input and get data */
	printf ( "\nPlease enter two integer numbers: " ) ;

/* Read numbers into a and b */
	scanf ( "%d %d", &a, &b ) ;

/* Calculate the Sum and Difference */
	sum = add ( a, b ) ;
	diff = subtract ( a, b ) ;

	printf ( "\n\n%4d + %4d = %4d\n", a, b, sum ) ;
	printf ( "%4d - %4d = %4d\n", a, b, diff ) ;

/* Close Program */
	printf ( "\nThank you for using my calculator\n" ) ;

return 0 ;
}	/* main */

/* ==================== add ====================== */
	int add ( int a, int b )
/* This function adds two integers and returns the sum
Pre : Parameters a and b
Post: Return a + b
*/
{
	return ( a + b ) ;
}	/* add */

/* ================== subtract ==================== */
	int subtract ( int a, int b )
/* This function returns the difference of two integers
Pre : Parameters a and b
Post: Return a - b
*/
{
	return ( a - b ) ;
}	/* subtract */

