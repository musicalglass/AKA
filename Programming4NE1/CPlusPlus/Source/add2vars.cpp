/* Add2Vars.cpp
   Adding Variables
   This program adds two numbers
   input by the user
   Written by: Your Name
   Date: 11/23/05
*/       

#include <iostream> 
using namespace std; 

int main ( void )
{
/* Local Declarations */
         int num1 ;
         int num2 ;

 /* Statements */
         cout << "Please enter two numbers: " ;
         cin >> num1 >> num2 ;

         int sum = num1 + num2 ; 

         cout << "The sum of " ; 
         cout << num1 << " and " << num2 ; 
         cout << " is " << sum ; 

return 0 ;
} /* main */
