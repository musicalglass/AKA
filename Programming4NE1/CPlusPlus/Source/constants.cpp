/*	This program demonstrates three ways to use constants.
	Written by: Dillinger from Computer Science book
	Date written: 11/18/05
*/
#include <stdio.h>
#define PI 3.1415926536

int main ( void )
{
/* Local Declarations */
	const double pi = 3.1415926536 ;

/* Statements */
	printf("Defined constant PI: %13.10f\n", PI ) ;
	printf("Memory constant pi:  %13.10f\n", pi ) ;
	printf("Literal constant:    %13.10f\n", 3.1415026536 ) ;
return 0 ;
} /* main */
