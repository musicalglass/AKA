/* Else If / Switch Statements
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

/* Statements */
	if ( score >= 90 )
		grade = 'A' ;
	else if ( score >= 80 )
		grade = 'B' ;
	else if ( score >= 70 )
		grade = 'C' ;
	else if ( score >= 60 )
		grade = 'D' ;
	else grade = 'F' ;
return grade ;
}	/* scoreToGrade */
