/* Function Calls - This program demonstrates 
calling a function which multiplies two numbers
Written by: Dillinger from Computer Science book
Date: 11/23/05
*/
#include <stdio.h>
int main ( void )
{
	/* Prototype Declarations */
	int multiply (int num1, int num2 ) ;

	/* Local Declarations */
	int multiplier ;
	int multiplicand ;
	int product ;


	/* Statements */
	printf( "Enter two integers: " ) ;
	scanf ( "%d%d", &multiplier, &multiplicand ) ;

	product = multiply ( multiplier, multiplicand ) ;

	printf ( "Product of %d & %d is %d\n", multiplier, multiplicand, product ) ;

	return 0 ;
} /* main */

int multiply ( int num1, int num2 )
{
/* Statements */
	return ( num1 * num2 ) ;
} /* multiply */
