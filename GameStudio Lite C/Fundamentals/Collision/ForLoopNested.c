// ForLoopNested.c 
// Using Nested For Loops to populate the screen

fps_max = 60 ; // Define the Frame Rate so game runs the same on different speed computers


void collide_event() // This event is called when Entity bumps into something
{
	ent_remove ( you ) ; 
}

action update_Earth() // Actions for earth.mdl
{
	c_setminmax( me ) ; // Wrap Collision Zone to Model's size

	my.emask |= ( ENABLE_ENTITY ) ; // make entity sensitive for block and entity collision
	my.event = collide_event ; // Define which event will be triggered
	
	while (1) // While game is running, continue to do this:
	{
		// If Up Arrow Key is pressed, subtract 2 from the Z Position, and check for collision
		if ( key_cuu ) c_move( me, vector(0,0,0), vector(0,0,2 * time_step), NULL ) ; 
		// If Down Arrow Key is pressed, add 2 to the Z Position, and check for collision
		if ( key_cud ) c_move( me, vector(0,0,0), vector(0,0,-2 * time_step), NULL ) ; 
		// If Left Arrow Key is pressed, subtract 2 from the Y Position, and check for collision
		if ( key_cul ) c_move( me, vector(0,0,0), vector(0,2 * time_step,0), NULL ) ; 
		// If Right Arrow Key is pressed, add 2 to the Y Position, and check for collision
		if ( key_cur ) c_move( me, vector(0,0,0), vector(0,-2 * time_step,0), NULL ) ; 
		
		wait (1) ; 
	}
}


void main()
{
	level_load("") ; // Load empty level 
	
	// Position the camera at x = -100 ( Back  a bit )
	camera.x = -100 ; 
	
	// Create the Earth Model , Position XYZ, Action update_Earth
	ent_create( "earth.mdl", vector( 0, 45, 30 ), update_Earth ) ; 
	
	int i,j ;
	
	for ( i = 30; i >= -30; i = i - 15 ) 
	{

		for ( j = 45; j >= -45; j = j - 15 ) 
		{
			ent_create( "cube.mdl", vector(0,j,i), c_setminmax ) ; 
			wait (100);
		}

	}

}
