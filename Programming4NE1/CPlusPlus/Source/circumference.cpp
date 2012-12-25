/*	This program calculates the area and circumference
	of a circle using PI as a defined constant.
	Written by: Dillinger from Computer Science book
	Date: 11/18/05
*/
#include <stdio.h>
#define PI 3.1416

int main (void)
{
	/* Local Declarations */
	float circ ;
	float area;

	float radius ;

	/* Statements */

	printf( "\nPlease enter the value of the radius: " ) ;
	scanf( "%f",&radius ) ;

	circ = 2 * PI * radius ;
	area = PI * radius * radius ;

	printf( "\nRadius is :		%10.2f", radius ) ;
	printf( "\nCircumference is :	%10.2f", circ ) ;
	printf( "\nArea is :		%10.2f", area ) ;

return 0 ;
} /* main */
