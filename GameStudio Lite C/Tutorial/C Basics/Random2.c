// Random2.c
// Print Random Numbers to screen

#include <acknex.h>
#include <default.c>

var myRandom = 0 ;

PANEL* debugPanel =
{
	digits(35, 24, "myRandom = %0.f", Arial#20b, 1, myRandom);
	flags = VISIBLE;
}


void main()
{	
	level_load("") ; // Load an empty level
	
	random_seed( 0 ) ; // Initialize the random number
	
	// As long as the game is running, continue to repeat this process over and over
	while (1) 
	{
		if( key_space ) 
		myRandom = integer( random(4) ) + 1 ;	// Update myRandom to a Random Number between 1 and 4

	wait ( 1) ; 
	}

}
