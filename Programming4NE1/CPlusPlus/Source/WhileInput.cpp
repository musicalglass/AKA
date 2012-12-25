/* WhileInput.cpp 
   Countdown from user specified number to 1 */
#include <iostream>
using namespace std;       

int main ()
{
         int Counter ;

         cout << "Enter the starting number: ";
         cin >> Counter ;

         while ( Counter >= 1 )
         {
         cout << Counter << endl ;
         --Counter;
         }

cout << "Blastoff!" << endl ;

return 0;
}
 