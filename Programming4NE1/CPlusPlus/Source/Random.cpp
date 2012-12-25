/* Random.cpp
   Generate a non repeating sequence of numbers
   Written by: Your Name
   Date: 11/24/05
*/
#include <iostream>
#include <stdlib>
using namespace std ;

int main ( void )
{

/* Local Declarations */
	int a; 

/* Statements */

	a = ( rand () % 10 ) + 1 ;	// assign random number 1 - 10
        cout << a << endl ;     // print

	a = ( rand () % 10 ) + 1 ;	// re-assign new random number, etc.
        cout << a << endl ; 

	a = ( rand () % 10 ) + 1 ;	
        cout << a << endl ; 

	a = ( rand () % 10 ) + 1 ;	
        cout << a << endl ; 

} /* main */
