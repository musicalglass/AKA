// DoWhile.c

#include <acknex.h>
#include <default.c>

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

var counter = 0 ; // Variable to keep track of how many times the Loop repeats

action update_Position() // Action called by the Earth Model
{
	do
	{
		int position_Y = 40 ; // Declare local Variable "position_Y" 
		// Starting at 40, until position_Y is less than or equal to -40, subtract 10 from position_Y each time
		for ( position_Y = 40; -40 <= position_Y; position_Y = position_Y - 10 ) 
		{
		my.y = position_Y ; // Set my Y value to the current value of position_Y
		wait ( 40 ) ; // Wait a bit till next redraw
		}

		counter++ ; // Add 1 to the counter after each Loop
	}
	while( counter < 4 ) ; // Continue Do-ing the Loop While counter is less than 4
	
	wait( 100 ) ; // Pause for a second
	sys_exit(NULL); // Exit the Program

}

function main()
{
	level_load(""); // Load an empty level
	camera.x = -100 ; // Back the Camera up a bit so we can see the Model
	
	// Create the Earth Model, at Position 0,0,0 , and run the Action update_Position
	ent_create("../earth.mdl", NULL, update_Position) ; 
}
