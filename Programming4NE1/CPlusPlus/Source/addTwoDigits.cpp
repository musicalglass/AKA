/* Add Two Digits
This program extracts and adds the least significant digits 
of an integer using functions.
Written by: Your Name
Date: 11/23/05
*/
#include <stdio.h>

int main ( void )
{

/* Prototype Declarations */
int addTwoDigits ( int num ) ;

/* Local Declarations */
	int number ;
	int sum;
	
/* Statements */
	printf( "\nEnter an integer: " ) ;
scanf ( "%d, &number " ) ;
	sum = addTwoDigits ( number ) ;
	printf ("\nSum of last two digits is: %d", sum) ;

	return 0 ;
} /* main */

/* ============= addTwoDigits ================== */
int addTwoDigits ( int number )
/* Adds the first two digits of an integer.
	Pre: num contains an integer
	Post: Returns the sum of two least significant digits
*/
{
/* Prototype Declarations */
int firstDigit ( int ) ;
int secondDigit ( int ) ;

/* Local Declarations */
	int result ;

 /* Statements */
	result = firstDigit(number) + secondDigit(number) ;
	return result ;
}	/* addTwoDigits */

/* ============= firstDigit ================== */
/* Extract the least significant digit of an integer.
	Pre: num contains an integer
	Post: Returns least significant digit
*/
int firstDigit ( int num )
{
/* Statements */
	return ( num % 10 ) ;
} /* firstDigit */

/* ================ secondDigit =============== */
/* Extract second least significant digit (10s )
	Pre: num is an integer
	Post: Returns digit in 10s position
*/
int secondDigit (int num )
{
/* Local Declarations */
int result ;

/* Statements */result = ( num / 10 ) % 10 ;
	return result ;
}	/* secondDigit */
