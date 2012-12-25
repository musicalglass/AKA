/* Print decreasing number series from user specified limit to 1
   Written by: Your_Name
   Date:
*/       

#include <iostream>
using namespace std;
int main ( void )

{
         /* Local Declarations */
         int i ; 
         int limit ;

/* Statements */
         cout << endl << " This program will count down from " << endl ;
         cout << " the number you specify to 1." << endl  << endl ;

         cout << " Please enter a number: " ;
         cin >> limit ;

      for ( i = limit ; i >= 1 ; i-- )
         cout <<  i << endl ; 

return 0 ;
} /* main */
