/*	Display the decimal value of selected characters.
	Written by: Dillinger from Computer Science book
	Date written: 11/18/05
*/

#include <stdio.h>
int main ( void )

{
/* Local Declarations */
	char A		= 'A' ;
	char a		= 'a' ;
	char B		= 'B' ;
	char b		= 'b' ;
	char Zed	= 'Z' ;
	char zed	= 'z' ;
	char zero	= '0' ;
	char eight	= '8' ;
	char NL		= '\n' ;	/* newline */
	char HT		= '\t' ;	/* horizontal tab */
	char VT		= '\v' ;	/* vertical tab */
	char SP		= ' ' ;	/* blank or space */
	char BEL	= '\a' ;	/* alert (bell) */
	char dblQuote	= '"' ;	/* double quote */
	char backSlash	= '\\' ;	/* backslash itself*/
	char oneQuote	= '\'' ;	/* single quote itself*/


/* Statements */
 printf( "\nASCII for char 'A' is: %d", A ) ;
 printf( "\nASCII for char 'a' is: %d", a ) ;
 printf( "\nASCII for char 'B' is: %d", B ) ;
 printf( "\nASCII for char 'b' is: %d", b ) ;
 printf( "\nASCII for char 'Z' is: %d", Zed ) ;
 printf( "\nASCII for char 'z' is: %d", zed ) ;
 printf( "\nASCII for char '0' is: %d", zero ) ;
 printf( "\nASCII for char '8' is: %d", eight ) ;
 printf( "\nASCII for char '\\n' is: %d", NL ) ;
 printf( "\nASCII for char '\\t' is: %d", HT ) ;
 printf( "\nASCII for char '\\v' is: %d", VT ) ;
 printf( "\nASCII for char ' ' is: %d", SP ) ;
 printf( "\nASCII for char '\\a' is: %d", BEL ) ;
 printf( "\nASCII for char '\"' is: %d", dblQuote ) ;
 printf( "\nASCII for char '\\' is: %d", backSlash ) ;
 printf( "\nASCII for char '\'' is: %d", oneQuote ) ;

return 0;
} /* main */

