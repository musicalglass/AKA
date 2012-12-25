/* Add Two Digits
This program reads long integers from the keyboard
and prints them with leading zeros in the form
006,856 with a comma between the 3rd & 4th digits
Written by: Your Name
Date: 11/24/05
*/
#include <stdio.h>

int main ( void )
{

/* Prototype Declarations */
void printWithComma ( long num ) ;

/* Local Declarations */	
	long number ;

/* Statements */

	printf ( "\nEnter a number with up to 6 digits: ") ;
	scanf ( "%d", &number ) ;
	printWithComma ( number ) ;

	return 0 ;
} /* main */

/* ================== printWithComma ==================== */
/* This funtion divides num into two three-digit
	numbers and prints them with a comma inserted
	Pre: num is a 6 digit number
	Post: num has been printed with a comma inserted
*/
void printWithComma ( long num )
{
/* Local Declarations */
	int thousands ;
	int hundreds ;

/* Statements */
	thousands = num / 1000 ;
	hundreds = num % 1000 ;

	printf ( "\nThe number you entered is \t%03d,%03d",
			thousands, hundreds ) ;
	return ;
} /* printWithComma */