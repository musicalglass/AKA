// Random.c
// Move model to Random Positions

#include <acknex.h>
#include <default.c>


action update_Position() // Action called by the Earth Model
{
	random_seed( 0 ); // Initialize the random number
	
	while (1) // As long as the game is running, continue to repeat this process over and over
	{
		// Randomly change the Position of the Entity that calls this Action
		my.y = random(60)-30  ; // Update Entity Position to a Random Number between -30 to 30
      my.z = random(60)-30  ;
      
	wait (400); // Wait a few seconds before executing While Loop again
	}
}


void main()
{	
	level_load(""); // Load an empty level
	
	camera.x = -100 ; // Back the Camera up a bit so we can see the Model

	// Create the Earth Model, at Position 0,0,0 , and run the Action update_Position
	ent_create("../earth.mdl", NULL, update_Position) ; 
}
