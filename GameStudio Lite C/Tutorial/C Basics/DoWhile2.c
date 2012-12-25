// DoWhile2.c

#include <acknex.h>
#include <default.c>

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

var counter = 0 ; // Variable to keep track of how many times the loop plays

action update_Position() // Action called by the Earth Model
{	
	my.z = 30 ; 
	
	int i = 0 ; // Declare local Variable for position
do
	{
	// Move right using For Loop
		for ( i = 40; -40 <= i; i = i - 10 ) 
		{
		my.y = i ; // Set my Y value to the current value of right
		wait ( 50 );
		}

	// Move down using For Loop
		for ( i = 30; -30 <= i; i = i - 10 ) 
		{
		my.z = i ; // Set my Y value to the current value of right
		wait ( 50 );
		}

	// Move left using For Loop
		for ( i = -40; 40 >= i; i = i + 10 ) 
		{
		my.y = i ; // Set my Y value to the current value of right
		wait ( 50 );
		}

	// Move up using For Loop
		for ( i = -30; 30 >= i; i = i + 10 ) 
		{
		my.z = i ; // Set my Y value to the current value of right
		wait ( 50 );
		}

	counter++ ; // Add 1 to the counter at the end of each Loop
	}
	while ( counter < 2 ); // Continue Do Loop until counter reaches 2
	
	wait( 100 ) ; // Pause for a second
	sys_exit(NULL); // Exit the program
}

function main()
{
	level_load(""); // Load an empty level
	camera.x = -100 ; // Back the Camera up a bit so we can see the Model
	
		// Create the Earth Model, at Position 0,0,0 , and run the Action update_Position
	ent_create("../earth.mdl", NULL, update_Position) ; 

}
