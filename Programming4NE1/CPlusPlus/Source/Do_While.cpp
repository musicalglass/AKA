/* Do_While.cpp
Add a list of integers.
Keep going until End Of File
Written by: Your_Name
Date:
*/

#include <iostream>
using namespace std ; 

int main ( void )
{
/* Local Declarations */
	int User_Input ;
	int sum = 0 ;

/* Statements */
	cout << "Enter some numbers ( 0 to stop ) : " << endl ;

	do
{
        cin >> User_Input ; 
	sum += User_Input ;
	cout << "Total: "<< sum  << endl ;
}
	while ( User_Input != 0 ) ;

	cout << endl << "Program terminated " <<endl ;
	cout << "Have a day. :|" << endl ; 
return 0 ;
}	/* main */
