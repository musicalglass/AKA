/* DeckCards.cpp
   Create an Array of 52 Cards (53 technically)
   Store Value from 1 to 52 in corresponding Array location
   using a For Loop  ( ignoring location 0 )
   Then print the values to the screen
*/
#include <iostream>
using namespace std ;

int main ( void )
{

/* Local Declarations */
	int i ; 
	int Cards = 52; 

/*  Create an Array of 53 cards */
	int Deck[52] ; 

/*  Starting at 1, cycle through each and 
   insert the appropriate number 
   by assigning the current value of i
   to the corresponging array location
   each time the loop cycles through
*/
   for ( i = 1 ; i <= Cards ; i++ )
   Deck[i] = i ;

   cout << endl ;

/*  Print them out sequencially */
   for ( i = 1 ; i <= Cards ; i++ )
{
   cout << Deck[i] ;
   cout << endl ;
}

return 0 ;
}	/* main */
