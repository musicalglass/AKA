/* 3 Random Numbers
Generated random numbers in 3 different series
using clock as seed number
Written by: Your Name
Date: 11/24/05
*/
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main ( void )
{

/* Local Declarations */
	int a;	
	int b;	
	int c;	


/* Statements */
	srand ( time ( NULL ) ) ;
	/* range is 3 through 7 */
	a = rand () % 5 + 3 ;	/* 8 - 3 = 5 */

	/* range is 20 through 50 */
	b = rand () % 31 + 20 ;	/* 51 - 20 = 31 */

	/* range is -6 through 15 */
	c = rand () % 22  - 6 ;	/* 16 - ( -6 ) = 22 */

	printf ( "Range 3 to 7: %2d\n", a ) ;
	printf ( "Range 20 to 50: %2d\n", b ) ;
	printf ( "Range -6 to 15: %2d\n", c );
} /* main */
