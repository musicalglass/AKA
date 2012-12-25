/* RandomTypes.cpp
   Generate a non repeating sequence of numbers
   using computer's internal clock as a seed number
   Written by: Your_Name
   Date: 11/24/05
*/
#include <iostream>

using namespace std ;       

int main ( void )
{

/* Local Declarations */
         int a; 

/* Statements */

         srand ( time ( NULL ) ); // set random Seed number using time

         cout << "Random number from 0 to 10: " ; 
         a = rand () % 10 ; 
         cout << a << endl ; 

         cout << "Random number from 1 to 10: " ; 
         a = ( rand () % 10 ) + 1 ; 
         cout << a << endl ; 

         cout << "Random number from 1 to 100: " ; 
         a = ( rand () % 100 ) + 1 ; 
         cout << a << endl ; 

         cout << "Random number from 10 to 40: " ; 
         a = ( rand () % 30 ) + 10 ; 
         cout << a << endl ; 

         cout << "Random number from -10 to 10: " ; 
         a = rand () % 20 - 10 ; 
         cout << a << endl ; 

         cout << "Random number from 2 to 20 in increments of 2: " ; 
         a = ( ( rand () % 10 ) + 1 ) * 2  ; 
         cout << a << endl ; 

         cout << "Random number from 10 to 100 in increments of 10: " ; 
         a = ( ( rand () % 10 ) + 1 ) * 10 ; 
         cout << a << endl ; 

return 0 ;
} /* main */
