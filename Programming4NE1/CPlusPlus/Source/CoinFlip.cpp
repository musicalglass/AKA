/* CoinFlip.cpp
   This program uses a random number generator
   to output one of two possible strings
*/
#include <iostream>
using namespace std ; 
int main ( void ) 
{ 
srand( time( NULL ) ) ; // set random Seed number using time
int My_Coin ; 
My_Coin = rand () % 2 ; 

if ( My_Coin == 0 ) 
cout << "Heads" ; 

if ( My_Coin == 1 ) 
cout << "Tails" ; 

return 0 ; 
}
