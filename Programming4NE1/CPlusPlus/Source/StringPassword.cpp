/* PasswordArray.cpp
User input must match string exactly
*/
#include <iostream>
#include <string>
using namespace std ;

int main ( void )
{
/* Local Declarations */
string User_Input ; 
string Password = "Open_Sesame" ; 

/* Statements */
cout << "Please enter your password " ;
cin >> User_Input ;
if ( User_Input == Password )
cout << "Welcome!" ;

if ( User_Input != Password )
cout << "Sorry, you do not have authorization" ;

return 0 ;
} /* main */