#include <iostream>

using namespace std ;

int main ( void )
{
/* Create an Array of 53 Cards
	Store Value from 1 to 52 in corresponding Array location,
	shuffle the deck,
	and Print the values to the screen
*/
/* Local Declarations */
        const int Cards_Num = 52 ;
	int Deck[ Cards_Num ] ; // Create an Array of 53 cards 0 - 52

/*  Starting at 0, cycle through each and insert consecutive number */
   for ( int i = 0 ; i <= Cards_Num ; i++ )
   Deck[ i ] = i ;

   cout << endl ; 

/*  Print them out sequentially */
   for ( int i = 1 ; i <= Cards_Num ; i++ )
   cout <<  Deck[ i ] << " " ;

   cout << endl << endl ;

/* ========= Shuffle the deck ======== */
/* Set Random Seed = Time   Requires include time.h */
    srand ( time ( NULL ) ) ;

   for ( int i = 1 ; i <= Cards_Num ; i++ ) 
{
	int a = ( rand() % Cards_Num ) + 1 ;
	int b = ( rand() % Cards_Num ) + 1 ;

	Deck[ 0 ] = Deck[ b ] ; // Store random card in extra space 0
	Deck[ b ] = Deck[ a ] ; // Swap two random cards
	Deck[ a ] = Deck[ 0 ] ; // Put spare card back in leftover space
}
  
/* Print them out sequentially */
   for ( int i = 1 ; i <= Cards_Num ; i++ )
   cout << Deck[ i ] << " " ;

   cout << endl ; 
return 0 ;
}	/* main */
