/* Switch Statements
This program reads a test score, calculates the letter grade and prints it.
Written by: Your Name
Date: 11/25/05
*/
#include <stdio.h>

int main ( void )
{
/* Prototype Declarations */
	char scoreToGrade ( int score ) ;

/* Local Declarations */
	int score ;
	char grade ;

/* Statements */
	printf ( "\nEnter the test score ( 0 - 100 ): " ) ;
	scanf ( "%d", &score ) ;

	grade = scoreToGrade ( score ) ;
	printf ( "The grade is: %c\n", grade ) ;

return 0 ;
} /* main */

/* ================== sourceToGrade ===================== */
	char scoreToGrade ( int score )
/* This funtion calculates the letter grade for a score
using the Switch statement
Pre: the parameter score
Post: Returns the grade letter
*/
{
/* Local Declarations */
	char grade ;
	int temp ;

/* Statements */
	temp = score / 10 ;
	switch ( temp )
	{
		case 10:
		case 9:	grade = 'A' ;
			break ;
		case 8:	grade = 'B' ;
			break ;
		case 7:	grade = 'C' ;
			break ;
		case 6:	grade = 'D' ;
			break ;
		default:grade = 'F' ;
	} /* switch */

return grade ;
}	/* scoreToGrade */
