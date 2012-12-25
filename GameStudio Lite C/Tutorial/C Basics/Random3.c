// Random3.c
// Print Random Numbers to screen when spacebar is pressed

#include <acknex.h>
#include <default.c>

var myRandom = 0 ;
random_seed( 0 ) ; // Initialize the random number

PANEL* debugPanel =
{
	digits( 35, 24, "myRandom = %0.2f", Arial#20b, 1, myRandom ) ; 
	flags = VISIBLE ; 
}

void myRandomFunction()
{
	myRandom = integer( random(4) ) + 1 ;	// Update myRandom to a Random Number between 1 and 4
}

void main()
{	
	level_load("") ; // Load an empty level

	on_space = myRandomFunction ; // Call the Function one time when the Space key is detected
}
