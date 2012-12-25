// ForLoop2.c
// Draw a row of Entities using a For Loop

#include <acknex.h>
#include <default.c>


void main()
{	
	level_load(""); // Load an empty level
	camera.x = -100 ; // Back the Camera up a bit so we can see the Model

	int i = 0 ; // Declare local Variable "i" 
	// Starting at 50, until i is less than or equal to -50, subtract 25 from i each time
	for ( i = 50; -50 <= i; i = i - 25 ) 
	{
		// Create "my" Entity, at default 0,0,0 , no Action
		ent_create("../earth.mdl", NULL, NULL) ; 
		my.y = i ; // Set my Y value to the current value of i
		wait (200);
	}
}
