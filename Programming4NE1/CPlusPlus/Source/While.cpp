/* While.cpp 
   Countdown from constant number to 1 
*/
#include <iostream>
using namespace std;       

int main ( void )
{
         int Counter = 10;

         while ( Counter >= 1 )
           {
             cout << Counter ;
             --Counter ;
             cout << endl ;
           }

         cout << "Blastoff!" ;

return 0;
} 	/* main */
