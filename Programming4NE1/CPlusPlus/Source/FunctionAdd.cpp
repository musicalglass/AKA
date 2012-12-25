/* FunctionAdd.cpp
   Demonstrates passing parameters to 
   a function for simple addition
*/
#include <iostream>
using namespace std ;

int Addition ( int num1 , int num2 )
{
  int sum ;
  sum = num1 + num2 ;
  return ( sum ) ;
}

int main ()
{
  int My_Answer = Addition ( 1 , 2 ) ;
  cout << "The result is " << My_Answer ;
  return 0 ;
}
