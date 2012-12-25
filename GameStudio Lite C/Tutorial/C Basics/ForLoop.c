// Variables.c
// Display a 3D Model onscreen

#include <acknex.h>
#include <default.c>


action update_Position() // Action called by the Earth Model
{
	int i = 0;
	for (i = 50; i >= -50; i = i - 25) 
	{
		my.y = i ;
		wait (400);
	}

}


void main()
{	
	level_load(""); // Load an empty level
	
	camera.x = -100 ; // Back the Camera up a bit so we can see the Model

	// Create the Earth Model, at Position 0,0,0 , and run the Action update_Position
	ent_create("../earth.mdl", NULL, update_Position) ; 
}
