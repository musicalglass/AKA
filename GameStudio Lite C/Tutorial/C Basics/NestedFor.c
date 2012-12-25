// NestedFor.c
// One For Loop inside another
// The inner Loop does it's thing once through, 
// then the outer Loop is incremented, 
// and the inner Loop does it's thing again, etc.

#include <acknex.h>
#include <default.c>

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

void main()
{	
	level_load(""); // Load an empty level
	camera.x = -100 ; // Back the Camera up a bit so we can see the Model

	int row = 50 ; // Declare local Variable for rows (across)
	int column = 40 ; // Declare local Variable for columns (down)

	for ( column = 40; -40 <= column; column = column - 20 ) // Starting at the top and going down 20
	{
		for ( row = 50; -50 <= row; row = row - 25 ) // Starting at the left and going right 25
		{
		// Create "my" Entity, at default 0,0,0 , no Action
		me = ent_create("../earth.mdl", NULL, NULL) ; 
		my.y = row ; // Set my Y value to the Loop's current value of row
		my.z = column ; // This will be reset by the outer For Loop when this Loop is completed
		
		// Pause between redraws 
		wait ( 10 ) ; // If you remove this line they all draw at the same time
		}
	}
}
