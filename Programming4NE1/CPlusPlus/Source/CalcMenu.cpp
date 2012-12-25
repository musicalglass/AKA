/* CalcMenu.cpp
A Calculator program which demonstrates the use of Menus
Written by: Your Name
Date: 11/25/05
*/
#include <stdio.h>

int main ( void )
{
/* Prototype Declarations */
void getData 	      (	float *num1, float *num2 ) ;
void printResult      (	float num1,
			float num2,	
			float result,
			int option ) ;
int getOption ( void ) ;

float calc ( int option, float num1, float num2 ) ;

/* Local Declarations */
	int option ;

	float num1 ;
	float num2 ;
	float result ;

/* Statements */
	option = getOption ( ) ;
	getData ( &num1, &num2 ) ;
	result = calc ( option, num1, num2 ) ;
	printResult ( num1, num2, result, option ) ;

return 0 ;
}	/* main */
/* ================= getOption =================== */
/* This function shows a menu and reads the user option
Pre: Nothing
Post: Returns the option
*/
int getOption ( void )
{
/* Local Declarations */
	int option ;

/* Statements */
	printf ( "\n\n\n" ) ;
	printf ( "\n\t************************************") ;
	printf ( "\n\t			MENU		**") ;
	printf ( "\n\t					**") ;
	printf ( "\n\t  1. ADD				**") ;
	printf ( "\n\t  1. SUBTRACT			**") ;
	printf ( "\n\t  1. MULTIPLY			**") ;
	printf ( "\n\t  1. DIVIDE			**") ;
	printf ( "\n\t					**") ;
	printf ( "\n\n\n" ) ;
	printf ( "\n\t************************************") ;

	printf ( "\n\nPlease enter your choice " ) ;
	printf ( "and press the Return key: " ) ;
	scanf ( "%d", &option ) ;

return option ;
}	/* getOption */
/* ================== getData ==================== */
/* This function reads two numbers from the keyboard
Pre: Nothing
Post: Read to numbers into Variables in main
*/
void getData	( float *num1,
		float *num2 )
{
/* Statements */
	printf ( "Enter two numbers separated by a space: " ) ;
	scanf ( "%f %f", num1, num2 ) ;

return ;
}	/* getData */
/* =================== calc ===================== */
/* This function determines the type of operation
and calls a function to perform it 
Pre: option contains the operation
num1 & num2  contains data
Post: returns the result
*/
float calc ( int option,
		float num1,
		float num2 )
{
/* Prototype Statements */
	float add ( float num1, float num2 ) ;
	float sub ( float num1, float num2 ) ;
	float mul ( float num1, float num2 ) ;
	float dvd ( float num1, float num2 ) ;


/* Local Declarations */
	float result ;

/* Statements */
	switch ( option )
	{
	case 1 : result = add ( num1, num2 ) ;
			break;
	case 2 : result = sub ( num1, num2 ) ;
			break;
	case 3 : result = mul ( num1, num2 ) ;
			break;
	case 4 : if ( num2 == 0.0 )
			{
			printf ( "\n\a\aError: " ) ;
			printf ( "division by zero ***\n" ) ;
			exit ( 1 ) ;
			}
		else
			result = dvd ( num1, num2 ) ;
		break ;

	/* Better structured programming would validate the
	option in getOption. However we have not yet
	learned the technique to put it there.
	*/
	default : printf ( "\aOption not available\n" ) ;
		exit ( 1 ) ;
	}	/* switch */
return result ;
}	/* calc */
/* =================== add ===================== */
/* This function adds two numbers.
Pre: The two numbers are given as parameters
Post: Return the results
*/
    float add ( float num1,
		float num2 )
{
/* Local Declarations */
	float res ;

/* Statements */
	res = num1 + num2 ;
	return res ;
}	/* add */
/* =================== sub ===================== */
/* This function subtracts two numbers.
Pre: The two numbers are given as parameters
Post: Return the results
*/
    float sub ( float num1,
		float num2 )

{
/* Local Declarations */
	float res ;

/* Statements */
	res = num1 - num2 ;
	return res ;
}	/* sub */
/* =================== mul ===================== */
/* This function multiplies two numbers.
Pre: The two numbers are given as parameters
Post: Return the results
*/
    float mul ( float num1,
		float num2 )

{
/* Local Declarations */
	float res ;

/* Statements */
	res = num1 * num2 ;
	return res ;
}	/* mul */
/* =================== dvd ===================== */
/* This function divides two numbers.
Pre: The two numbers are given as parameters
Post: Return the results
*/
    float dvd ( float num1,
		float num2 )

{
/* Local Declarations */
	float res ;

/* Statements */
	res = num1 / num2 ;
	return res ;
}	/* dvd */
/* ================= printResult =================== */
/* This function prints the result of calculation.
Pre: The two numbers, result and option are given
Post: Prints the numbers and the result
*/
void printResult (	float num1,
			float num2,
			float res,
			int option )
{
/* Statements */
printf ( "\n\n%8.2f", num1 ) ;
switch ( option )
	{
	case 1 : printf ( " + " ) ;
			break ;
	case 2 : printf ( " - " ) ;
			break ;
	case 3 : printf ( " * " ) ;
			break ;
	case 4 : printf ( " / " ) ;
			break ;
	}	/* switchOption */
	printf ( " %8.2f = %8.2f\n", num2, res ) ;
}	/* printResult */
/* ================ End Of Program ================== */
