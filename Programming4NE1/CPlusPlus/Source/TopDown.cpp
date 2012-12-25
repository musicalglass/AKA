/* Sample of top down development using stubs
Written by: Your Name
Date: 11/24/05
*/
#include <stdio.h>

int main ( void )
{

/* Prototype Declarations */
	int initialize	( void ) ;
	int process	( void ) ;
	int endOfJob	( void ) ;

/* Local Declarations */

/* Statements */
	printf ( "Begin Program\n\n" ) ;

	initialize	( ) ;
	process		( ) ;
	endOfJob	( ) ;

/* Close Program */
	printf ( "\nThe End\n" ) ;

	return 0 ;
} /* main */

/* ============= initialize ============== */
int initialize ( void )
/* Stub for Initialize */
{

/* Local Declarations */

/* Statements */
	printf ( "In Initialize: \n" ) ;

return 0 ;
}	/* initialize */

/* ============== process =============== */
int process ( void )
/* Stub for Process */
{

/* Local Declarations */

/* Statements */
	printf ( "In Process: \n" ) ;

return 0 ;
}	/* Process */

/* ============= endOfJob ============== */
int endOfJob ( void )
/* Stub for endOfJob */
{

/* Local Declarations */

/* Statements */
	printf ( "In endOfJob : \n" ) ;

return 0 ;
}	/* endOfJob */
