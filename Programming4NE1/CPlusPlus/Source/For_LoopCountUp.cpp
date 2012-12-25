/* ForLoopCountUp.cpp
  Print increasing number series 
  from 1 to user specified limit
  Written by: Your_Name
  Date:
*/

#include <iostream>
using namespace std ;
int main ( void )
{
/* Local Declarations */
	int i ;
	int limit ;

/* Statements */
	cout << "This program will count up from 1" ;
	cout << " to the number you specify." << endl ;
	cout << "Please enter a number: " ;
	cin >> limit ;

      for ( i = 1 ; i <= limit ; i++ )
	cout <<  i << endl ;

return 0 ;
}	/* main */
