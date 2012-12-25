// Variables.c
// Display a 3D Model onscreen

#include <acknex.h>
#include <default.c>


action update_Position() // Action called by the Earth Model
{
	while (1) // As long as the game is running, continue to repeat this process over and over
	{
		if ( key_space ) // If this condition is True...
		{
			my.y = -30 ; // ..do this
		}
		else // Otherwise,... 
		{
			my.y = 30 ; // ..do that
		}
      
	wait (1); // Release the processing power back to the Operating System for a moment
	}
}


void main()
{	
	level_load(""); // Load an empty level
	
	camera.x = -100 ; // Back the Camera up a bit so we can see the Model

	// Create the Earth Model, at Position 0,0,0 , and run the Action update_Position
	ent_create("../earth.mdl", NULL, update_Position) ; 
}
